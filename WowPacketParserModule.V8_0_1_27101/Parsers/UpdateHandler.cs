using System;
using System.Collections;
using System.Collections.Generic;
using WowPacketParser.Enums;
using WowPacketParser.Enums.Version;
using WowPacketParser.Misc;
using WowPacketParser.Parsing;
using WowPacketParser.Store;
using WowPacketParser.Store.Objects;
using WowPacketParserModule.V7_0_3_22248.Parsers;
using CoreParsers = WowPacketParser.Parsing.Parsers;
using SplineFlag = WowPacketParserModule.V7_0_3_22248.Enums.SplineFlag;
using LegacyUpdateFields = WowPacketParser.Enums.Version.UpdateFields;
using System.Reflection;
using UFs = WowPacketParserModule.V8_0_1_27101.UpdateFields;

namespace WowPacketParserModule.V8_0_1_27101.Parsers
{
    public static class UpdateHandler
    {
        [HasSniffData] // in ReadCreateObjectBlock
        [Parser(Opcode.SMSG_UPDATE_OBJECT)]
        public static void HandleUpdateObject(Packet packet)
        {
            packet.AsHex();
            var count = packet.ReadUInt32("NumObjUpdates");
            uint map = packet.ReadUInt16<MapId>("MapID");
            packet.ResetBitReader();
            var hasDestroyObject = packet.ReadBit("HasDestroyObjects");
            if (hasDestroyObject)
            {
                packet.ReadInt16("Int0");
                var destroyObjCount = packet.ReadUInt32("DestroyObjectsCount");
                for (var i = 0; i < destroyObjCount; i++)
                    packet.ReadPackedGuid128("Object GUID", i);
            }
            packet.ReadUInt32("Data size");

            for (var i = 0; i < count; i++)
            {
                var type = packet.ReadByte();
                var typeString = ((UpdateTypeCataclysm)type).ToString();

                packet.AddValue("UpdateType", typeString, i);
                switch (typeString)
                {
                    case "Values":
                    {
                        var guid = packet.ReadPackedGuid128("Object Guid", i);
                        if (ClientVersion.AddedInVersion(ClientVersionBuild.V8_1_0_28724))
                            ReadValuesUpdateBlock(packet, guid, i);
                        else
                            CoreParsers.UpdateHandler.ReadValuesUpdateBlock(packet, guid, i);
                        break;
                    }
                    case "CreateObject1":
                    case "CreateObject2":
                    {
                        var guid = packet.ReadPackedGuid128("Object Guid", i);
                        ReadCreateObjectBlock(packet, guid, map, i);
                        break;
                    }
                }
            }
        }

        public static Dictionary<Type, List<FieldInfo>> BitFields = new Dictionary<Type, List<FieldInfo>>();
        public static Dictionary<Type, List<FieldInfo>> DynamicFields = new Dictionary<Type, List<FieldInfo>>();
        public static Dictionary<Type, List<FieldInfo>> NormalFields = new Dictionary<Type, List<FieldInfo>>();
        public static Dictionary<Type, List<FieldInfo>> ArrayFields = new Dictionary<Type, List<FieldInfo>>();

        public static void InitializeFields(object obj)
        {
            if (NormalFields.ContainsKey(obj.GetType()) || DynamicFields.ContainsKey(obj.GetType()) || ArrayFields.ContainsKey(obj.GetType()))
                return;

            BitFields.Add(obj.GetType(), new List<FieldInfo>());
            DynamicFields.Add(obj.GetType(), new List<FieldInfo>());
            NormalFields.Add(obj.GetType(), new List<FieldInfo>());
            ArrayFields.Add(obj.GetType(), new List<FieldInfo>());
            foreach (FieldInfo field in obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                if (field.GetCustomAttribute<UFs.UFDynamicCounterAttribute>() != null)
                    continue;

                if (field.GetCustomAttribute<UFs.UFDynamicFieldAttribute>() != null)
                    DynamicFields[obj.GetType()].Add(field);
                else if (field.GetCustomAttribute<UFs.UFArrayAttribute>() != null)
                    ArrayFields[obj.GetType()].Add(field);
                // else if (field.GetCustomAttribute(UFs.UFBitAttribute>() != null)
                //     BitFields[obj.GetType()].Add(field);
                else
                    NormalFields[obj.GetType()].Add(field);

                if (field.FieldType.IsSubclassOf(typeof(UFs.UpdateFieldStructure)))
                    InitializeFields(field.GetValue(obj));
            }
        }

        public static void ParseUpdateField(Packet packet, FieldInfo fieldInfo, BitArray parentUpdateMask, object obj, params object[] indexes)
        {
            if (fieldInfo.FieldType.IsSubclassOf(typeof(UFs.UpdateFieldStructure)))
            {
                UFs.UpdateFieldStructure structure = (UFs.UpdateFieldStructure)fieldInfo.GetValue(obj);
                ReadSubstructureUpdateMask(packet, structure.GetFieldNum(), structure, parentUpdateMask, indexes, structure.GetType().Name);
            }
            else if (fieldInfo.FieldType == typeof(UFs.UpdateField))
            {
                ReadField(packet, (UFs.UpdateField)fieldInfo.GetValue(obj), fieldInfo, indexes);
            }
            else
            {
                throw new NotImplementedException("ParseUpdateField: Not implemented type: " + fieldInfo.FieldType.ToString());
            }
        }

        public static void ReadBitUpdates(Packet packet, BitArray updateMask, object obj, params object[] index)
        {
            UFs.UpdateField uf = null;
            foreach (FieldInfo field in BitFields[obj.GetType()])
            {
                uf = (UFs.UpdateField)field.GetValue(obj);
                if (updateMask.Get((int)Math.Floor((float)uf.GetUpdateBit() / 32) * 32) == false) // enable bit has to be set for mask block ( & 1)
                    continue;
                if (updateMask.Get(uf.GetUpdateBit()) == false) // this field is not being updated
                    continue;
                //ParseUpdateField(packet, guid, field, updateMask, obj, index);
            }
        }

        public static void ReadDynamicUpdates(Packet packet, BitArray updateMask, object obj, params object[] index)
        {
            List<List<int>> dynMasks = new List<List<int>>();
            List<uint> counts = new List<uint>();
            UFs.UpdateField uf = null;
            UFs.UFDynamicFieldAttribute dynFieldAttribute = null;

            int currentDynField = -1;
            foreach (FieldInfo dynField in DynamicFields[obj.GetType()])
            {
                currentDynField++;

                uf = (UFs.UpdateField)dynField.GetValue(obj);
                if (updateMask.Get((int)Math.Floor((float)uf.GetUpdateBit() / 32) * 32) == false) // enable bit has to be set for mask block ( & 1)
                    continue;
                if (updateMask.Get(uf.GetUpdateBit()) == false) // this field is not being updated
                    continue;

                if (!dynField.FieldType.IsSubclassOf(typeof(UFs.UpdateFieldStructure))) 
                    packet.ResetBitReader();
                uint count = packet.ReadBits("DynamicCount", 32, index, currentDynField);

                dynFieldAttribute = dynField.GetCustomAttribute<UFs.UFDynamicFieldAttribute>();
                if (dynFieldAttribute.SetSpecificEnabled)
                {
                    dynMasks.Add(ReadDynamicUpdateMask(packet, count, index, currentDynField));
                    counts.Add(count);
                }
                else
                {
                    if (currentDynField == 0) // first dynamic field is always read completely if its not special
                    {
                        for (int i = 0; i < count; i++)
                            ParseUpdateField(packet, dynField, null, obj, index, currentDynField);
                    }
                    else
                    {
                        dynMasks.Add(null);
                        counts.Add(count);
                    }
                }
            }

            // read data
            currentDynField = 0;
            bool skippedFirstField = false;
            foreach (FieldInfo dynField in DynamicFields[obj.GetType()])
            {
                dynFieldAttribute = dynField.GetCustomAttribute<UFs.UFDynamicFieldAttribute>();
                if (!skippedFirstField)
                {
                    skippedFirstField = true;

                    // if field is not special we've already read data in previous loop
                    if (!dynFieldAttribute.SetSpecificEnabled)
                        continue;
                }

                uf = (UFs.UpdateField)dynField.GetValue(obj);
                if (updateMask.Get((int)Math.Floor((float)uf.GetUpdateBit() / 32) * 32) == false) // enable bit has to be set for mask block ( & 1)
                    continue;
                if (updateMask.Get(uf.GetUpdateBit()) == false) // this field is not being updated
                    continue;

                if (counts[currentDynField] == 0)
                    continue;

                for (int i = 0; i <= counts[currentDynField]; i++)
                {
                    if (dynFieldAttribute.SetSpecificEnabled)
                    {
                        if ((dynMasks[currentDynField][i >> 5] & (i & 0x1F)) == 0)
                            continue;
                    }
                    ParseUpdateField(packet, dynField, null, obj, index, i);
                }
                currentDynField++;
            }
        }

        public static void ReadNormalUpdates(Packet packet, BitArray updateMask, object obj, params object[] index)
        {
            UFs.UpdateField uf = null;
            foreach (FieldInfo field in NormalFields[obj.GetType()])
            { 
                uf = (UFs.UpdateField)field.GetValue(obj);
                if (updateMask.Get((int)Math.Floor((float)uf.GetUpdateBit() / 32) * 32) == false) // enable bit has to be set for mask block ( & 1)
                    continue;
                if (updateMask.Get(uf.GetUpdateBit()) == false) // this field is not being updated
                    continue;
                ParseUpdateField(packet, field, updateMask, obj, index);
            }
        }

        public static void ReadArrayUpdates(Packet packet, BitArray updateMask, object obj, params object[] index)
        {
            UFs.UFArrayAttribute array = null;
            UFs.UpdateField uf = null;
            List<FieldInfo> fields = ArrayFields[obj.GetType()];
            for (int fieldId = 0; fieldId < fields.Count; fieldId++)
            {
                uf = (UFs.UpdateField)fields[fieldId].GetValue(obj);
                if (updateMask.Get(uf.GetUpdateBit()) == false)
                    continue;

                array = fields[fieldId].GetCustomAttribute<UFs.UFArrayAttribute>();

                // @TODO: move count stuff to init and do it only !once!
                // count merged field num
                int mergeNum = 0;
                for (int i = 1; (fieldId + i) < fields.Count; i++)
                {
                    if (fields[fieldId + i].GetCustomAttribute<UFs.UFArrayAttribute>().Length != array.Length)
                        break;
                    mergeNum++;
                }

                if (mergeNum > 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        for (int curFieldId = fieldId; curFieldId <= (fieldId + mergeNum); curFieldId++)
                        {
                            if (fields[curFieldId].FieldType.IsSubclassOf(typeof(UFs.UpdateFieldStructure)))
                            {
                                UFs.UpdateFieldStructure structure = (UFs.UpdateFieldStructure)fields[curFieldId].GetValue(obj);

                                if (DynamicFields.ContainsKey(structure.GetType()) && DynamicFields[structure.GetType()].Count > 0)
                                {
                                    packet.AddValue("MergedArrays: DynamicFields are NYI: " + structure.GetType().ToString(), index);
                                }

                                foreach (FieldInfo subField in NormalFields[structure.GetType()])
                                {
                                    uf = (UFs.UpdateField)subField.GetValue(structure);
                                    if (updateMask.Get(uf.GetUpdateBit() + i) == false) // this field is not being updated
                                        continue;

                                    if (subField.FieldType == typeof(UFs.UpdateField))
                                    {
                                        ReadField(packet, (UFs.UpdateField)subField.GetValue(structure), subField, index, structure.GetType().Name.ToString(), i);
                                    }
                                    else
                                    {
                                        packet.AddValue("MergedArrays: NOT SUPPORTED FieldType: " + subField.FieldType.ToString(), index);
                                    }
                                }

                                if (ArrayFields.ContainsKey(structure.GetType()) && ArrayFields[structure.GetType()].Count > 0)
                                {
                                    packet.AddValue("MergedArrays: ArrayFields are NYI: " + structure.GetType().ToString(), index);
                                }
                            }
                            else
                            {
                                uf = (UFs.UpdateField)fields[curFieldId].GetValue(obj);
                                if (updateMask.Get(uf.GetUpdateBit() + i + 1) == false) // this field is not being updated
                                    continue;
                                ReadField(packet, uf, fields[curFieldId], index, i);
                            }
                        }
                    }
                    fieldId += mergeNum; // skip already read fields
                }
                else
                {
                    bool isNormalArrayOrOwnBitMask = true;
                    if (fields[fieldId].FieldType.IsSubclassOf(typeof(UFs.UpdateFieldStructure)))
                    {
                        UFs.UpdateFieldStructure structure = (UFs.UpdateFieldStructure)fields[fieldId].GetValue(obj);

                        // if the substructure is using the <main structure> mask for its fields
                        if (structure.GetFieldNum() == 0)
                        {
                            isNormalArrayOrOwnBitMask = false;
                            for (int i = 0; i < array.Length; i++)
                            {
                                foreach (FieldInfo subField in NormalFields[structure.GetType()])
                                {
                                    uf = (UFs.UpdateField)subField.GetValue(structure);
                                    if (updateMask.Get(uf.GetUpdateBit() + i) == false) // this field is not being updated
                                        continue;

                                    if (subField.FieldType == typeof(UFs.UpdateField))
                                        ReadField(packet, (UFs.UpdateField)subField.GetValue(structure), subField, index, structure.GetType().Name.ToString(), i);
                                    else
                                        packet.AddValue("Arrays: NOT SUPPORTED FieldType: " + subField.FieldType.ToString(), index);
                                }
                            }
                        }
                    }

                    // if array is no substructure or reads its own mask for its fields first
                    if (isNormalArrayOrOwnBitMask)
                    {
                        for (int i = 1; i <= array.Length; i++)
                        {
                            if (updateMask.Get(uf.GetUpdateBit() + i) == false)
                                continue;
                            if (fields[fieldId].FieldType.IsSubclassOf(typeof(UFs.UpdateFieldStructure)))
                                ParseUpdateField(packet, fields[fieldId], updateMask, obj, index, fields[fieldId].GetValue(obj).GetType().Name.ToString(), i - 1);
                            else
                                ParseUpdateField(packet, fields[fieldId], updateMask, obj, index, i - 1);
                        }
                    }
                }
            }
        }

        public static void ReadSubstructureUpdateData(Packet packet, BitArray updateMask, object obj, params object[] index)
        {
            // ReadBitUpdates(packet, updateMask, obj, index); // used in (active) player
            ReadDynamicUpdates(packet, updateMask, obj, index);
            ReadNormalUpdates(packet, updateMask, obj, index);
            ReadArrayUpdates(packet, updateMask, obj, index);
        }

        private static List<int> ReadDynamicUpdateMask(Packet packet, uint count, params object[] index)
        {
            List<int> mask = new List<int>();
            var bitCount = count;
            uint i = 0;

            // read in 4 byte blocks
            while (bitCount > 32) 
            {
                mask.Add((int)packet.ReadUInt32("DynamicMask", index, i));
                i++;
                bitCount -= 32;
            }

            // read remaining bits
            if (bitCount > 0)
            {
                //packet.ResetBitReader();
                mask.Add((int)packet.ReadBits("DynamicMaskRemaining", (int)bitCount));
            }
            return mask;
        }

        public static int asddf = 0;

        public static void ReadSubstructureUpdateMask(Packet packet, int fieldNum, object obj, BitArray parentUpdateMask, params object[] index)
        {
            InitializeFields(obj); // @TODO: move me somewhere generic

            BitArray updateMask = null;
            int[] updateMaskInts = null;

            if (fieldNum == 0)
            {
                ReadSubstructureUpdateData(packet, parentUpdateMask, obj, index);
                return;
            }

            packet.ResetBitReader();
            if (fieldNum == 32)
            {
                var preUpdateMask = packet.ReadBit();
                if (preUpdateMask == true)
                {
                    updateMaskInts = new int[1];
                    updateMaskInts[0] = (int)packet.ReadBits("zz", 32);
                }
                else
                {
                    // should never happen i guess?
                    //packet.AddValue("ERROR", "NULL MASK for " + obj.GetType(), index);
                    return;
                }
            }
            else if (fieldNum > 32)
            {
                int blockNum = (int)Math.Floor((float)fieldNum / 32);
                updateMaskInts = new int[blockNum];
                uint updateMaskUnk = packet.ReadBits("maskunk", blockNum);
                int v9 = 1;
                for (int i = 0; i < blockNum; i++)
                {
                    if ((v9 & (updateMaskUnk + (i >> 5))) == v9)
                        updateMaskInts[i] = (int)packet.ReadBits("xx", 32, i);
                    v9 = 1 << (i + 1);
                }
            }
            else
            {
                updateMaskInts = new int[1];
                updateMaskInts[0] = (int)packet.ReadBits("yy", fieldNum);
            }
            updateMask = new BitArray(updateMaskInts);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < updateMask.Count; i++)
            {
                if (updateMask.Get(i) == true)
                {
                    sb.Append(i);
                    sb.Append(" ");
                }
            }
            if (sb.Length > 0)
                packet.AddValue("UpdateMaskBits", sb.ToString(), index, "Mask");
            ReadSubstructureUpdateData(packet, updateMask, obj, index);
        }

        public static void ReadValuesUpdateBlock(Packet packet, WowGuid guid, int index)
        {
            packet.ReadUInt32("ValuesBlockSize", index);
            var flags = packet.ReadUInt32("Flags", index);

            dynamicLoopCounts.Clear();

            // @TODO: move me into class to be able to use different shit between patches
            if ((flags & (1 << (int)ObjectType.Object)) > 0)
            {
                ReadSubstructureUpdateMask(packet, 4, new UFs.CGObject_C(), null, index, "Object");
            }
            if ((flags & (1 << (int)ObjectType.Item)) > 0)
            {
                ReadSubstructureUpdateMask(packet, 2 * 32, new UFs.CGItem_C(), null, index, "Item");
            }
            if ((flags & (1 << (int)ObjectType.Container)) > 0)
            {
                ReadSubstructureUpdateMask(packet, 2 * 32, new UFs.CGContainer_C(), null, index, "Container");
            }
            if ((flags & (1 << (int)ObjectType.AzeriteEmpoweredItem)) > 0)
            {
                ReadSubstructureUpdateMask(packet, 1 * 32, new UFs.CGAzeriteEmpoweredItem_C(), null, index, "AzeriteEmpoweredItem");
            }
            if ((flags & (1 << (int)ObjectType.AzeriteItem)) > 0)
            {
                ReadSubstructureUpdateMask(packet, 6, new UFs.CGAzeriteItem_C(), null, index, "AzeriteItem");
            }
            if ((flags & (1 << (int)ObjectType.Unit)) > 0)
            {
                ReadSubstructureUpdateMask(packet, 6 * 32, new UFs.CGUnit_C(), null, index, "Unit");
            }
            if ((flags & (1 << (int)ObjectType.Player)) > 0)
            {
                ReadSubstructureUpdateMask(packet, 6 * 32, new UFs.CGPlayer_C(), null, index, "Player");
            }
            if ((flags & (1 << (int)ObjectType.ActivePlayer)) > 0)
            {
                // handled differently
                // ReadSubstructureUpdateMask(packet, 4 * 32, new UFs.CGActivePlayer_C(), null, index, "ActivePlayer");
            }
            if ((flags & (1 << (int)ObjectType.GameObject)) > 0)
            {
                ReadSubstructureUpdateMask(packet, 20, new UFs.CGGameObject_C(), null, index, "GameObject");
            }
            if ((flags & (1 << (int)ObjectType.DynamicObject)) > 0)
            {
                ReadSubstructureUpdateMask(packet, 7, new UFs.CGDynamicObject_C(), null, index, "DynamicObject");
            }
            if ((flags & (1 << (int)ObjectType.Corpse)) > 0)
            {
                ReadSubstructureUpdateMask(packet, 2 * 32, new UFs.CGCorpse_C(), null, index, "Corpse");
            }
            if ((flags & (1 << (int)ObjectType.AreaTrigger)) > 0)
            {
                ReadSubstructureUpdateMask(packet, 14, new UFs.CGAreaTrigger_C(), null, index, "AreaTrigger");
            }
            if ((flags & (1 << (int)ObjectType.SceneObject)) > 0)
            {
                ReadSubstructureUpdateMask(packet, 5, new UFs.CGSceneObject_C(), null, index, "SceneObject");
            }
            if ((flags & (1 << (int)ObjectType.Conversation)) > 0)
            {
                ReadSubstructureUpdateMask(packet, 4, new UFs.CGConversation_C(), null, index, "Conversation");
            }
        }

        public static object ReadField(Packet packet, UFs.UpdateField uf, FieldInfo fieldInfo, params object[] idx)
        {
            string name = fieldInfo.Name;
            UFs.UFBitsAttribute bitsAttr = fieldInfo.GetCustomAttribute<UFs.UFBitsAttribute>();
            int bits = 0;
            bool resetBitReader = true;

            if (bitsAttr != null)
                bits = bitsAttr.Length;

            if (previousUFType == UpdateFieldType.Bits)
                resetBitReader = false;

            previousUFType = uf.GetUpdateFieldType();

            switch (uf.GetUpdateFieldType())
            {
                case UpdateFieldType.Sbyte:
                    return packet.ReadSByte(name, idx);
                case UpdateFieldType.Byte:
                    return packet.ReadByte(name, idx);
                case UpdateFieldType.Short:
                    return packet.ReadInt16(name, idx);
                case UpdateFieldType.Ushort:
                    return packet.ReadUInt16(name, idx);
                case UpdateFieldType.Int:
                    return packet.ReadInt32(name, idx);
                case UpdateFieldType.Uint:
                    return packet.ReadUInt32(name, idx);
                case UpdateFieldType.Long:
                    return packet.ReadInt64(name, idx);
                case UpdateFieldType.Ulong:
                    return packet.ReadUInt64(name, idx);
                case UpdateFieldType.Float:
                    return packet.ReadSingle(name, idx);
                case UpdateFieldType.Time:
                    return packet.ReadTime(name, idx);
                case UpdateFieldType.Guid:
                    return packet.ReadPackedGuid128(name, idx);
                case UpdateFieldType.Bits:
                {
                    if (resetBitReader)
                        packet.ResetBitReader();
                    return packet.ReadBits(name, bits, idx);
                }
                default:
                    throw new NotImplementedException("ReadCreateField: Not implemented type: " + uf.GetUpdateFieldType().ToString());
            }
        }

        public static void ReadMainStructure(Packet packet, object obj, uint flags, uint loopCount, params object[] index)
        {
            dynamicLoopCounts.Clear();
            ReadSubstructure(packet, obj, flags, loopCount, index);
        }

        public static void ReadSubstructure(Packet packet, object obj, uint flags, uint loopCount, params object[] index)
        {
            if (loopCount == 0)
                return;

            if (loopCount != 1)
            {
                for (int i = 0; i < loopCount; i++)
                {
                    foreach (FieldInfo field in obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance))
                        ParseCreateField(packet, flags, field, obj, index, i);
                }
            }
            else
            {
                foreach (FieldInfo field in obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance))
                    ParseCreateField(packet, flags, field, obj, index);
            }
        }

        public static Dictionary<int /*bit*/, uint /*loopcount*/> dynamicLoopCounts = new Dictionary<int, uint>();
        public static UpdateFieldType previousUFType;

        public static void ParseCreateField(Packet packet, uint flags, FieldInfo fieldInfo, object obj, params object[] indexes)
        {
            UFs.UFDynamicFieldAttribute dynamicField = fieldInfo.GetCustomAttribute<UFs.UFDynamicFieldAttribute>();
            UFs.UFArrayAttribute array = fieldInfo.GetCustomAttribute<UFs.UFArrayAttribute>();
            object fieldVal = fieldInfo.GetValue(obj);
            uint loopCount = 1;
            if (array != null)
                loopCount = array.Length;
            else if (dynamicField != null)
                loopCount = dynamicLoopCounts[((UFs.UpdateField)fieldVal).GetUpdateBit()];

            UFs.UpdateField uf = (UFs.UpdateField)fieldVal;
            if (uf.GetRequiredCreationFlag() > 0 && (flags & uf.GetRequiredCreationFlag()) == 0)
                return;

            if (fieldInfo.FieldType.IsSubclassOf(typeof(UFs.UpdateFieldStructure)))
            {
                ReadSubstructure(packet, fieldVal, flags, loopCount, indexes);
            }
            else if (fieldInfo.FieldType == typeof(UFs.UpdateField))
            {
                UFs.UFDynamicCounterAttribute counter = fieldInfo.GetCustomAttribute<UFs.UFDynamicCounterAttribute>();
                if (loopCount == 1)
                {
                    object val = ReadField(packet, uf, fieldInfo, indexes);
                    if (counter != null)
                        dynamicLoopCounts.Add(uf.GetUpdateBit(), Convert.ToUInt32(val));
                }
                else
                {
                    for (int i = 0; i < loopCount; i++)
                    {
                        ReadField(packet, uf, fieldInfo, indexes, i);
                    }
                }
            }
            else
            {
                throw new NotImplementedException("ParseField: Not implemented type: " + fieldInfo.FieldType.ToString());
            }
        }

        private static void ReadValuesCreateBlock(Dictionary<int, UpdateField> dict, Dictionary<int, List<UpdateField>> dynDict, Packet packet, ObjectType type, object index)
        {
            packet.ReadUInt32("ValuesBlockSize", index);
            uint flags = packet.ReadByte("Flags", index);

            if (type == ObjectType.Object)
            {
                ReadMainStructure(packet, new UFs.CGObject_C(), flags, 1, index);
            }
            else if (type == ObjectType.Item)
            {
                ReadMainStructure(packet, new UFs.CGObject_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGItem_C(), flags, 1, index);
            }
            else if (type == ObjectType.Container)
            {
                ReadMainStructure(packet, new UFs.CGObject_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGItem_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGContainer_C(), flags, 1, index);
            }
            else if (type == ObjectType.AzeriteEmpoweredItem)
            {
                ReadMainStructure(packet, new UFs.CGObject_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGItem_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGAzeriteEmpoweredItem_C(), flags, 1, index);
            }
            else if (type == ObjectType.AzeriteItem)
            {
                ReadMainStructure(packet, new UFs.CGObject_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGItem_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGAzeriteItem_C(), flags, 1, index);
            }
            else if (type == ObjectType.Unit)
            {
                ReadMainStructure(packet, new UFs.CGObject_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGUnit_C(), flags, 1, index);
            }
            else if (type == ObjectType.Player)
            {
                ReadMainStructure(packet, new UFs.CGObject_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGUnit_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGPlayer_C(), flags, 1, index);
            }
            else if (type == ObjectType.ActivePlayer)
            {
                ReadMainStructure(packet, new UFs.CGObject_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGUnit_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGPlayer_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGActivePlayer_C(), flags, 1, index);
            }
            else if (type == ObjectType.GameObject)
            {
                ReadMainStructure(packet, new UFs.CGObject_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGGameObject_C(), flags, 1, index);
            }
            else if (type == ObjectType.DynamicObject)
            {
                ReadMainStructure(packet, new UFs.CGObject_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGDynamicObject_C(), flags, 1, index);
            }
            else if (type == ObjectType.Corpse)
            {
                ReadMainStructure(packet, new UFs.CGObject_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGCorpse_C(), flags, 1, index);
            }
            else if (type == ObjectType.AreaTrigger)
            {
                ReadMainStructure(packet, new UFs.CGObject_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGAreaTrigger_C(), flags, 1, index);
            }
            else if (type == ObjectType.SceneObject)
            {
                ReadMainStructure(packet, new UFs.CGObject_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGSceneObject_C(), flags, 1, index);
            }
            else if (type == ObjectType.Conversation)
            {
                ReadMainStructure(packet, new UFs.CGObject_C(), flags, 1, index);
                ReadMainStructure(packet, new UFs.CGConversation_C(), flags, 1, index);
            }
            else
            {
                throw new NotImplementedException("ReadValuesCreateBlock: Not implemented ObjectType: " + type.ToString());
            }
        }

        private static void ReadCreateObjectBlock(Packet packet, WowGuid guid, uint map, object index)
        {
            ObjectType objType = ObjectTypeConverter.Convert(packet.ReadByteE<ObjectType801>("Object Type", index));
            if (ClientVersion.RemovedInVersion(ClientVersionBuild.V8_1_0_28724))
                packet.ReadInt32("HeirFlags", index);
            WoWObject obj;
            switch (objType)
            {
                case ObjectType.Unit:
                    obj = new Unit();
                    break;
                case ObjectType.GameObject:
                    obj = new GameObject();
                    break;
                case ObjectType.Player:
                    obj = new Player();
                    break;
                case ObjectType.AreaTrigger:
                    obj = new SpellAreaTrigger();
                    break;
                case ObjectType.Conversation:
                    obj = new ConversationTemplate();
                    break;
                default:
                    obj = new WoWObject();
                    break;
            }

            var moves = ReadMovementUpdateBlock(packet, guid, obj, index);
            if (ClientVersion.AddedInVersion(ClientVersionBuild.V8_1_0_28724))
            {
                var dict = new Dictionary<int, UpdateField>();
                var dynDict = new Dictionary<int, List<UpdateField>>();

                ReadValuesCreateBlock(dict, dynDict, packet, objType, index);

                obj.UpdateFields = dict;
                obj.DynamicUpdateFields = dynDict;
            }
            else
            {
                var updates = CoreParsers.UpdateHandler.ReadValuesUpdateBlockOnCreate(packet, objType, index);
                var dynamicUpdates = CoreParsers.UpdateHandler.ReadDynamicValuesUpdateBlockOnCreate(packet, objType, index);

                obj.UpdateFields = updates;
                obj.DynamicUpdateFields = dynamicUpdates;
            }

            obj.Type = objType;
            obj.Movement = moves;
            obj.Map = map;
            obj.Area = CoreParsers.WorldStateHandler.CurrentAreaId;
            obj.Zone = CoreParsers.WorldStateHandler.CurrentZoneId;
            obj.PhaseMask = (uint)CoreParsers.MovementHandler.CurrentPhaseMask;
            obj.Phases = new HashSet<ushort>(MovementHandler.ActivePhases.Keys);
            obj.DifficultyID = CoreParsers.MovementHandler.CurrentDifficultyID;

            // If this is the second time we see the same object (same guid,
            // same position) update its phasemask
            if (Storage.Objects.ContainsKey(guid))
            {
                var existObj = Storage.Objects[guid].Item1;
                CoreParsers.UpdateHandler.ProcessExistingObject(ref existObj, obj, guid); // can't do "ref Storage.Objects[guid].Item1 directly
            }
            else
                Storage.Objects.Add(guid, obj, packet.TimeSpan);

            if (guid.HasEntry() && (objType == ObjectType.Unit || objType == ObjectType.GameObject))
                packet.AddSniffData(Utilities.ObjectTypeToStore(objType), (int)guid.GetEntry(), "SPAWN");
        }

        public static void ReadTransportData(MovementInfo moveInfo, WowGuid guid, Packet packet, object index)
        {
            packet.ResetBitReader();
            moveInfo.TransportGuid = packet.ReadPackedGuid128("TransportGUID", index);
            moveInfo.TransportOffset = packet.ReadVector4("TransportPosition", index);
            var seat = packet.ReadByte("VehicleSeatIndex", index);
            packet.ReadUInt32("MoveTime", index);

            var hasPrevMoveTime = packet.ReadBit("HasPrevMoveTime", index);
            var hasVehicleRecID = packet.ReadBit("HasVehicleRecID", index);

            if (hasPrevMoveTime)
                packet.ReadUInt32("PrevMoveTime", index);

            if (hasVehicleRecID)
                packet.ReadInt32("VehicleRecID", index);

            if (moveInfo.TransportGuid.HasEntry() && moveInfo.TransportGuid.GetHighType() == HighGuidType.Vehicle &&
                guid.HasEntry() && guid.GetHighType() == HighGuidType.Creature)
            {
                VehicleTemplateAccessory vehicleAccessory = new VehicleTemplateAccessory
                {
                    Entry = moveInfo.TransportGuid.GetEntry(),
                    AccessoryEntry = guid.GetEntry(),
                    SeatId = seat
                };
                Storage.VehicleTemplateAccessories.Add(vehicleAccessory, packet.TimeSpan);
            }
        }

        private static MovementInfo ReadMovementUpdateBlock(Packet packet, WowGuid guid, WoWObject obj, object index)
        {
            var moveInfo = new MovementInfo();

            packet.ResetBitReader();

            packet.ReadBit("NoBirthAnim", index);
            packet.ReadBit("EnablePortals", index);
            packet.ReadBit("PlayHoverAnim", index);

            var hasMovementUpdate = packet.ReadBit("HasMovementUpdate", index);
            var hasMovementTransport = packet.ReadBit("HasMovementTransport", index);
            var hasStationaryPosition = packet.ReadBit("Stationary", index);
            var hasCombatVictim = packet.ReadBit("HasCombatVictim", index);
            var hasServerTime = packet.ReadBit("HasServerTime", index);
            var hasVehicleCreate = packet.ReadBit("HasVehicleCreate", index);
            var hasAnimKitCreate = packet.ReadBit("HasAnimKitCreate", index);
            var hasRotation = packet.ReadBit("HasRotation", index);
            var hasAreaTrigger = packet.ReadBit("HasAreaTrigger", index);
            var hasGameObject = packet.ReadBit("HasGameObject", index);
            var hasSmoothPhasing = packet.ReadBit("HasSmoothPhasing", index);

            packet.ReadBit("ThisIsYou", index);

            var sceneObjCreate = packet.ReadBit("SceneObjCreate", index);
            var playerCreateData = packet.ReadBit("HasPlayerCreateData", index);
            var hasConversation = packet.ReadBit("HasConversation", index);

            if (hasMovementUpdate)
            {
                packet.ResetBitReader();
                packet.ReadPackedGuid128("MoverGUID", index);

                packet.ReadUInt32("MoveTime", index);
                moveInfo.Position = packet.ReadVector3("Position", index);
                moveInfo.Orientation = packet.ReadSingle("Orientation", index);

                packet.ReadSingle("Pitch", index);
                packet.ReadSingle("StepUpStartElevation", index);

                var removeForcesIDsCount = packet.ReadUInt32();
                packet.ReadUInt32("MoveIndex", index);

                for (var i = 0; i < removeForcesIDsCount; i++)
                    packet.ReadPackedGuid128("RemoveForcesIDs", index, i);

                moveInfo.Flags = (MovementFlag)packet.ReadBitsE<V6_0_2_19033.Enums.MovementFlag>("Movement Flags", 30, index);
                moveInfo.FlagsExtra = (MovementFlagExtra)packet.ReadBitsE<Enums.MovementFlags2>("Extra Movement Flags", 18, index);

                var hasTransport = packet.ReadBit("Has Transport Data", index);
                var hasFall = packet.ReadBit("Has Fall Data", index);
                packet.ReadBit("HasSpline", index);
                packet.ReadBit("HeightChangeFailed", index);
                packet.ReadBit("RemoteTimeValid", index);

                if (hasTransport)
                    ReadTransportData(moveInfo, guid, packet, index);

                if (hasFall)
                {
                    packet.ResetBitReader();
                    packet.ReadUInt32("Fall Time", index);
                    packet.ReadSingle("JumpVelocity", index);

                    var hasFallDirection = packet.ReadBit("Has Fall Direction", index);
                    if (hasFallDirection)
                    {
                        packet.ReadVector2("Fall", index);
                        packet.ReadSingle("Horizontal Speed", index);
                    }
                }

                moveInfo.WalkSpeed = packet.ReadSingle("WalkSpeed", index) / 2.5f;
                moveInfo.RunSpeed = packet.ReadSingle("RunSpeed", index) / 7.0f;
                packet.ReadSingle("RunBackSpeed", index);
                packet.ReadSingle("SwimSpeed", index);
                packet.ReadSingle("SwimBackSpeed", index);
                packet.ReadSingle("FlightSpeed", index);
                packet.ReadSingle("FlightBackSpeed", index);
                packet.ReadSingle("TurnRate", index);
                packet.ReadSingle("PitchRate", index);

                var movementForceCount = packet.ReadUInt32("MovementForceCount", index);

                if (ClientVersion.AddedInVersion(ClientVersionBuild.V8_1_0_28724))
                    packet.ReadSingle("UnkFloat", index);

                packet.ResetBitReader();

                moveInfo.HasSplineData = packet.ReadBit("HasMovementSpline", index);

                for (var i = 0; i < movementForceCount; ++i)
                {
                    packet.ResetBitReader();
                    packet.ReadPackedGuid128("Id", index);
                    packet.ReadVector3("Origin", index);
                    packet.ReadVector3("Direction", index);
                    packet.ReadUInt32("TransportID", index);
                    packet.ReadSingle("Magnitude", index);
                    packet.ReadBits("Type", 2, index);
                }

                if (moveInfo.HasSplineData)
                {
                    packet.ResetBitReader();
                    packet.ReadUInt32("ID", index);
                    packet.ReadVector3("Destination", index);

                    var hasMovementSplineMove = packet.ReadBit("MovementSplineMove", index);
                    if (hasMovementSplineMove)
                    {
                        packet.ResetBitReader();

                        packet.ReadUInt32E<SplineFlag>("SplineFlags", index);
                        packet.ReadInt32("Elapsed", index);
                        packet.ReadUInt32("Duration", index);
                        packet.ReadSingle("DurationModifier", index);
                        packet.ReadSingle("NextDurationModifier", index);

                        var face = packet.ReadBits("Face", 2, index);
                        var hasSpecialTime = packet.ReadBit("HasSpecialTime", index);

                        var pointsCount = packet.ReadBits("PointsCount", 16, index);

                        packet.ReadBitsE<SplineMode>("Mode", 2, index);

                        var hasSplineFilterKey = packet.ReadBit("HasSplineFilterKey", index);
                        var hasSpellEffectExtraData = packet.ReadBit("HasSpellEffectExtraData", index);
                        var hasJumpExtraData = packet.ReadBit("HasJumpExtraData", index);

                        if (hasSplineFilterKey)
                        {
                            packet.ResetBitReader();
                            var filterKeysCount = packet.ReadUInt32("FilterKeysCount", index);
                            for (var i = 0; i < filterKeysCount; ++i)
                            {
                                packet.ReadSingle("In", index, i);
                                packet.ReadSingle("Out", index, i);
                            }

                            packet.ReadBits("FilterFlags", 2, index);
                        }

                        switch (face)
                        {
                            case 1:
                                packet.ReadVector3("FaceSpot", index);
                                break;
                            case 2:
                                packet.ReadPackedGuid128("FaceGUID", index);
                                break;
                            case 3:
                                packet.ReadSingle("FaceDirection", index);
                                break;
                            default:
                                break;
                        }

                        if (hasSpecialTime)
                            packet.ReadUInt32("SpecialTime", index);

                        for (var i = 0; i < pointsCount; ++i)
                            packet.ReadVector3("Points", index, i);

                        if (hasSpellEffectExtraData)
                            MovementHandler.ReadMonsterSplineSpellEffectExtraData(packet, index);

                        if (hasJumpExtraData)
                            MovementHandler.ReadMonsterSplineJumpExtraData(packet, index);
                    }
                }
            }

            var pauseTimesCount = packet.ReadUInt32("PauseTimesCount", index);

            if (hasStationaryPosition)
            {
                moveInfo.Position = packet.ReadVector3();
                moveInfo.Orientation = packet.ReadSingle();

                packet.AddValue("Stationary Position", moveInfo.Position, index);
                packet.AddValue("Stationary Orientation", moveInfo.Orientation, index);
            }

            if (hasCombatVictim)
                packet.ReadPackedGuid128("CombatVictim Guid", index);

            if (hasServerTime)
                packet.ReadUInt32("ServerTime", index);

            if (hasVehicleCreate)
            {
                moveInfo.VehicleId = (uint)packet.ReadInt32("RecID", index);
                packet.ReadSingle("InitialRawFacing", index);
            }

            if (hasAnimKitCreate)
            {
                packet.ReadUInt16("AiID", index);
                packet.ReadUInt16("MovementID", index);
                packet.ReadUInt16("MeleeID", index);
            }

            if (hasRotation)
                moveInfo.Rotation = packet.ReadPackedQuaternion("GameObject Rotation", index);

            for (var i = 0; i < pauseTimesCount; ++i)
                packet.ReadUInt32("PauseTimes", index, i);

            if (hasMovementTransport)
                ReadTransportData(moveInfo, guid, packet, index);

            if (hasAreaTrigger && obj is SpellAreaTrigger)
            {
                AreaTriggerTemplate areaTriggerTemplate = new AreaTriggerTemplate
                {
                    Id = guid.GetEntry()
                };

                SpellAreaTrigger spellAreaTrigger = (SpellAreaTrigger)obj;
                spellAreaTrigger.AreaTriggerId = guid.GetEntry();

                packet.ResetBitReader();

                // CliAreaTrigger
                packet.ReadUInt32("ElapsedMs", index);

                packet.ReadVector3("RollPitchYaw1", index);

                areaTriggerTemplate.Flags   = 0;

                if (packet.ReadBit("HasAbsoluteOrientation", index))
                    areaTriggerTemplate.Flags |= (uint)AreaTriggerFlags.HasAbsoluteOrientation;

                if (packet.ReadBit("HasDynamicShape", index))
                    areaTriggerTemplate.Flags |= (uint)AreaTriggerFlags.HasDynamicShape;

                if (packet.ReadBit("HasAttached", index))
                    areaTriggerTemplate.Flags |= (uint)AreaTriggerFlags.HasAttached;

                if (packet.ReadBit("HasFaceMovementDir", index))
                    areaTriggerTemplate.Flags |= (uint)AreaTriggerFlags.FaceMovementDirection;

                if (packet.ReadBit("HasFollowsTerrain", index))
                    areaTriggerTemplate.Flags |= (uint)AreaTriggerFlags.FollowsTerrain;

                if (packet.ReadBit("Unk bit WoD62x", index))
                    areaTriggerTemplate.Flags |= (uint)AreaTriggerFlags.Unk1;

                if (packet.ReadBit("HasTargetRollPitchYaw", index))
                    areaTriggerTemplate.Flags |= (uint)AreaTriggerFlags.HasTargetRollPitchYaw;

                bool hasScaleCurveID = packet.ReadBit("HasScaleCurveID", index);
                bool hasMorphCurveID = packet.ReadBit("HasMorphCurveID", index);
                bool hasFacingCurveID = packet.ReadBit("HasFacingCurveID", index);
                bool hasMoveCurveID = packet.ReadBit("HasMoveCurveID", index);

                if (packet.ReadBit("HasAnimID", index))
                    areaTriggerTemplate.Flags |= (uint)AreaTriggerFlags.HasAnimId;

                if (packet.ReadBit("HasAnimKitID", index))
                    areaTriggerTemplate.Flags |= (uint)AreaTriggerFlags.HasAnimKitId;

                if (packet.ReadBit("unkbit50", index))
                    areaTriggerTemplate.Flags |= (uint)AreaTriggerFlags.Unk3;

                bool hasUnk801 = packet.ReadBit("HasAnimProgress", index);

                if (packet.ReadBit("HasAreaTriggerSphere", index))
                    areaTriggerTemplate.Type = (byte)AreaTriggerType.Sphere;

                if (packet.ReadBit("HasAreaTriggerBox", index))
                    areaTriggerTemplate.Type = (byte)AreaTriggerType.Box;

                if (packet.ReadBit("HasAreaTriggerPolygon", index))
                    areaTriggerTemplate.Type = (byte)AreaTriggerType.Polygon;

                if (packet.ReadBit("HasAreaTriggerCylinder", index))
                    areaTriggerTemplate.Type = (byte)AreaTriggerType.Cylinder;

                bool hasAreaTriggerSpline = packet.ReadBit("HasAreaTriggerSpline", index);

                if (packet.ReadBit("HasAreaTriggerCircularMovement", index))
                    areaTriggerTemplate.Flags |= (uint)AreaTriggerFlags.HasCircularMovement;

                if ((areaTriggerTemplate.Flags & (uint)AreaTriggerFlags.Unk3) != 0)
                    packet.ReadBit();

                if (hasAreaTriggerSpline)
                    AreaTriggerHandler.ReadAreaTriggerSpline(packet, index);

                if ((areaTriggerTemplate.Flags & (uint)AreaTriggerFlags.HasTargetRollPitchYaw) != 0)
                    packet.ReadVector3("TargetRollPitchYaw", index);

                if (hasScaleCurveID)
                    spellAreaTrigger.ScaleCurveId = (int)packet.ReadUInt32("ScaleCurveID", index);

                if (hasMorphCurveID)
                    spellAreaTrigger.MorphCurveId = (int)packet.ReadUInt32("MorphCurveID", index);

                if (hasFacingCurveID)
                    spellAreaTrigger.FacingCurveId = (int)packet.ReadUInt32("FacingCurveID", index);

                if (hasMoveCurveID)
                    spellAreaTrigger.MoveCurveId = (int)packet.ReadUInt32("MoveCurveID", index);

                if ((areaTriggerTemplate.Flags & (int)AreaTriggerFlags.HasAnimId) != 0)
                    spellAreaTrigger.AnimId = packet.ReadInt32("AnimId", index);

                if ((areaTriggerTemplate.Flags & (int)AreaTriggerFlags.HasAnimKitId) != 0)
                    spellAreaTrigger.AnimKitId = packet.ReadInt32("AnimKitId", index);

                if (hasUnk801)
                    packet.ReadUInt32("Unk801", index);

                if (areaTriggerTemplate.Type == (byte)AreaTriggerType.Sphere)
                {
                    areaTriggerTemplate.Data[0] = packet.ReadSingle("Radius", index);
                    areaTriggerTemplate.Data[1] = packet.ReadSingle("RadiusTarget", index);
                }

                if (areaTriggerTemplate.Type == (byte)AreaTriggerType.Box)
                {
                    Vector3 Extents = packet.ReadVector3("Extents", index);
                    Vector3 ExtentsTarget = packet.ReadVector3("ExtentsTarget", index);

                    areaTriggerTemplate.Data[0] = Extents.X;
                    areaTriggerTemplate.Data[1] = Extents.Y;
                    areaTriggerTemplate.Data[2] = Extents.Z;

                    areaTriggerTemplate.Data[3] = ExtentsTarget.X;
                    areaTriggerTemplate.Data[4] = ExtentsTarget.Y;
                    areaTriggerTemplate.Data[5] = ExtentsTarget.Z;
                }

                if (areaTriggerTemplate.Type == (byte)AreaTriggerType.Polygon)
                {
                    var verticesCount = packet.ReadUInt32("VerticesCount", index);
                    var verticesTargetCount = packet.ReadUInt32("VerticesTargetCount", index);

                    List<AreaTriggerTemplateVertices> verticesList = new List<AreaTriggerTemplateVertices>();

                    areaTriggerTemplate.Data[0] = packet.ReadSingle("Height", index);
                    areaTriggerTemplate.Data[1] = packet.ReadSingle("HeightTarget", index);

                    for (uint i = 0; i < verticesCount; ++i)
                    {
                        AreaTriggerTemplateVertices areaTriggerTemplateVertices = new AreaTriggerTemplateVertices
                        {
                            AreaTriggerId = guid.GetEntry(),
                            Idx = i
                        };

                        Vector2 vertices = packet.ReadVector2("Vertices", index, i);

                        areaTriggerTemplateVertices.VerticeX = vertices.X;
                        areaTriggerTemplateVertices.VerticeY = vertices.Y;

                        verticesList.Add(areaTriggerTemplateVertices);
                    }

                    for (var i = 0; i < verticesTargetCount; ++i)
                    {
                        Vector2 verticesTarget = packet.ReadVector2("VerticesTarget", index, i);

                        verticesList[i].VerticeTargetX = verticesTarget.X;
                        verticesList[i].VerticeTargetY = verticesTarget.Y;
                    }

                    foreach (AreaTriggerTemplateVertices vertice in verticesList)
                        Storage.AreaTriggerTemplatesVertices.Add(vertice);
                }

                if (areaTriggerTemplate.Type == (byte)AreaTriggerType.Cylinder)
                {
                    areaTriggerTemplate.Data[0] = packet.ReadSingle("Radius", index);
                    areaTriggerTemplate.Data[1] = packet.ReadSingle("RadiusTarget", index);
                    areaTriggerTemplate.Data[2] = packet.ReadSingle("Height", index);
                    areaTriggerTemplate.Data[3] = packet.ReadSingle("HeightTarget", index);
                    areaTriggerTemplate.Data[4] = packet.ReadSingle("LocationZOffset", index);
                    areaTriggerTemplate.Data[5] = packet.ReadSingle("LocationZOffsetTarget", index);
                }

                if ((areaTriggerTemplate.Flags & (uint)AreaTriggerFlags.HasCircularMovement) != 0)
                {
                    packet.ResetBitReader();
                    var hasPathTarget = packet.ReadBit("HasPathTarget");
                    var hasCenter = packet.ReadBit("HasCenter", index);
                    packet.ReadBit("CounterClockwise", index);
                    packet.ReadBit("CanLoop", index);

                    packet.ReadUInt32("TimeToTarget", index);
                    packet.ReadInt32("ElapsedTimeForMovement", index);
                    packet.ReadUInt32("StartDelay", index);
                    packet.ReadSingle("Radius", index);
                    packet.ReadSingle("BlendFromRadius", index);
                    packet.ReadSingle("InitialAngel", index);
                    packet.ReadSingle("ZOffset", index);

                    if (hasPathTarget)
                        packet.ReadPackedGuid128("PathTarget", index);

                    if (hasCenter)
                        packet.ReadVector3("Center", index);
                }

                Storage.AreaTriggerTemplates.Add(areaTriggerTemplate);
            }

            if (hasGameObject)
            {
                packet.ResetBitReader();
                packet.ReadUInt32("WorldEffectID", index);

                var bit8 = packet.ReadBit("bit8", index);
                if (bit8)
                    packet.ReadUInt32("Int1", index);
            }

            if (hasSmoothPhasing)
            {
                packet.ResetBitReader();
                packet.ReadBit("ReplaceActive", index);
                var replaceObject = packet.ReadBit();
                if (replaceObject)
                    packet.ReadPackedGuid128("ReplaceObject", index);
            }

            if (sceneObjCreate)
            {
                packet.ResetBitReader();

                var hasSceneLocalScriptData = packet.ReadBit("HasSceneLocalScriptData", index);
                var petBattleFullUpdate = packet.ReadBit("HasPetBattleFullUpdate", index);

                if (hasSceneLocalScriptData)
                {
                    packet.ResetBitReader();
                    var dataLength = packet.ReadBits(7);
                    packet.ReadWoWString("Data", dataLength, index);
                }

                if (petBattleFullUpdate)
                    V6_0_2_19033.Parsers.BattlePetHandler.ReadPetBattleFullUpdate(packet, index);
            }

            if (playerCreateData)
            {
                packet.ResetBitReader();
                var hasSceneInstanceIDs = packet.ReadBit("ScenePendingInstances", index);
                var hasRuneState = packet.ReadBit("Runes", index);

                if (hasSceneInstanceIDs)
                {
                    var sceneInstanceIDs = packet.ReadUInt32("SceneInstanceIDsCount");
                    for (var i = 0; i < sceneInstanceIDs; ++i)
                        packet.ReadInt32("SceneInstanceIDs", index, i);
                }

                if (hasRuneState)
                {
                    packet.ReadByte("RechargingRuneMask", index);
                    packet.ReadByte("UsableRuneMask", index);
                    var runeCount = packet.ReadUInt32();
                    for (var i = 0; i < runeCount; ++i)
                        packet.ReadByte("RuneCooldown", index, i);
                }
            }

            if (hasConversation)
            {
                packet.ResetBitReader();
                if (packet.ReadBit("HasTextureKitID", index))
                    (obj as ConversationTemplate).TextureKitId = packet.ReadUInt32("TextureKitID", index);
            }

            return moveInfo;
        }
    }
}
