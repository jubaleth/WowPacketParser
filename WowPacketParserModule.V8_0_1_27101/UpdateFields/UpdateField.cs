using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    // Dynamic Values are always first, first dynamic value is always read completely (bits + data after)
    //      after that all bits of all dynamic values are read and data is read after
    // then normal values
    // then array values: first bit is used to enable any changes in array, one bit after is first field
    //      e.g. array size 5: 1 bit = enable 2-6 fields
    // ^^^^^^^^^^^^^^^^^^^^^^ that order is also used within substructures
    public class UpdateField
    {
        private UpdateFieldType Type;
        private uint RequiredCreationFlag;
        private uint UpdateBit;

        public UpdateField(UpdateFieldType type, uint reqCreationFlag, uint updateBit)
        {
            this.Type = type;
            this.RequiredCreationFlag = reqCreationFlag;
            this.UpdateBit = updateBit;
        }

        public UpdateField(uint reqCreationFlag, uint updateBit)
        {
            this.Type = UpdateFieldType.Default;
            this.RequiredCreationFlag = reqCreationFlag;
            this.UpdateBit = updateBit;
        }

        public UpdateFieldType GetUpdateFieldType() { return this.Type; }
        public uint GetRequiredCreationFlag() { return this.RequiredCreationFlag; }
        public uint GetUpdateBit() { return this.UpdateBit; }
    }

    public class UpdateFieldStructure : UpdateField
    {
        public UpdateFieldStructure(uint reqCreationFlag, uint updateBit) : base(reqCreationFlag, updateBit) { }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public sealed class UFArrayAttribute : Attribute
    {
        public UFArrayAttribute(uint length)
        {
            this.Length = length;
        }

        public uint Length;
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public sealed class UFDynamicCounterAttribute : Attribute
    {
        public UFDynamicCounterAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public sealed class UFDynamicFieldAttribute : Attribute
    {
        public UFDynamicFieldAttribute() { }
    }

    public class randomclass
    {
        public void coolinit()
        {
            /*List<UpdateField> item = new List<UpdateField>();
            UpdateField dynamicCounter1 = new UpdateField("ITEM_FIELD_DYNAMIC_COUNT_1", UpdateFieldType.Uint, 0x0, 0, 0x02);
            item.Add(dynamicCounter1);
            UpdateFieldDynamicLoop dynamicField1 = new UpdateFieldDynamicLoop(dynamicCounter1);
            item.Add(dynamicField1);
            item.Add(new UpdateField("ITEM_FIELD_OWNER",                    UpdateFieldType.Guid,   0x0,  2,  0x20));
            item.Add(new UpdateField("ITEM_FIELD_CONTAINED",                UpdateFieldType.Guid,   0x0,  3,  0x40));
            item.Add(new UpdateField("ITEM_FIELD_CREATOR",                  UpdateFieldType.Guid,   0x0,  4,  0x80));
            item.Add(new UpdateField("ITEM_FIELD_GIFTCREATOR",              UpdateFieldType.Guid,   0x0,  5,  0x100));
            item.Add(new UpdateField("ITEM_FIELD_STACK_COUNT",              UpdateFieldType.Uint,   0x1,  6,  0x200));
            item.Add(new UpdateField("ITEM_FIELD_DURATION",                 UpdateFieldType.Uint,   0x1,  7,  0x400));
            item.Add(new UpdateField("ITEM_FIELD_SPELL_CHARGES",            UpdateFieldType.Uint,   0x0,  8,  0x100000)); // 5er loop
            item.Add(new UpdateField("ITEM_FIELD_DYNAMIC_FLAGS",            UpdateFieldType.Uint,   0x0,  9,  0x800));

            UpdateFieldStaticLoop enchantment = new UpdateFieldStaticLoop(13); // 0x200000
            enchantment.Add(new UpdateField("ITEM_FIELD_ENCHANTMENT1", UpdateFieldType.Int,     0,  0,  0x2));
            enchantment.Add(new UpdateField("ITEM_FIELD_ENCHANTMENT2", UpdateFieldType.Uint,    0,  1,  0x4));
            enchantment.Add(new UpdateField("ITEM_FIELD_ENCHANTMENT3", UpdateFieldType.Short,   0,  2,  0x8));
            enchantment.Add(new UpdateField("ITEM_FIELD_ENCHANTMENT4", UpdateFieldType.Ushort,  0,  3,  0x10));
            item.Add(enchantment);
            
            item.Add(new UpdateField("ITEM_FIELD_DURABILITY",               UpdateFieldType.Uint,   0x1, 10,  0x1000));
            item.Add(new UpdateField("ITEM_FIELD_MAXDURABILITY",            UpdateFieldType.Uint,   0x1, 11,  0x2000));
            item.Add(new UpdateField("ITEM_FIELD_CREATE_PLAYED_TIME",       UpdateFieldType.Uint,   0x0, 12,  0x4000));
            item.Add(new UpdateField("ITEM_FIELD_MODIFIERS_MASK",           UpdateFieldType.Uint,   0x1, 13,  0x8000));
            item.Add(new UpdateField("ITEM_FIELD_CONTEXT",                  UpdateFieldType.Uint,   0x0, 14,  0x10000));
            item.Add(new UpdateField("ITEM_FIELD_ARTIFACT_XP",              UpdateFieldType.Ulong,  0x1, 15,  0x20000));
            item.Add(new UpdateField("ITEM_FIELD_APPEARANCE_MOD_ID",        UpdateFieldType.Byte,   0x1, 16,  0x40000));

            UpdateField dynamicCounter2 = new UpdateField("ITEM_DYNAMIC_FIELD_21", UpdateFieldType.Uint, 0x0, 17, 0x04);
            UpdateField dynamicCounter3 = new UpdateField("ITEM_DYNAMIC_FIELD_22", UpdateFieldType.Uint, 0x0, 18, 0x08);
            UpdateField dynamicCounter4 = new UpdateField("ITEM_DYNAMIC_FIELD_23", UpdateFieldType.Uint, 0x0, 19, 0x10);

            item.Add(dynamicCounter2);
            item.Add(dynamicCounter3);
            item.Add(dynamicCounter4);
            item.Add(new UpdateField("ITEM_FIELD_24",                       UpdateFieldType.Uint,   0x0, 20,  0x80000));

            UpdateFieldDynamicLoop dynamicField2 = new UpdateFieldDynamicLoop(dynamicCounter2);
            dynamicField2.Add(new UpdateField("ITEM_DYNAMIC_FIELD_21_1",    UpdateFieldType.Int,    0x0, 21,  0x04));
            item.Add(dynamicField2);

            UpdateFieldDynamicLoop dynamicField3 = new UpdateFieldDynamicLoop(dynamicCounter3);
            dynamicField3.Add(new UpdateField("ITEM_DYNAMIC_FIELD_22_1",   UpdateFieldType.Short,  0x0,  0,  0x08));
            dynamicField3.Add(new UpdateField("ITEM_DYNAMIC_FIELD_22_1",   UpdateFieldType.Byte,   0x0,  1,  0x08));
            dynamicField3.Add(new UpdateField("ITEM_DYNAMIC_FIELD_22_1",   UpdateFieldType.Byte,   0x0,  2,  0x08));
            item.Add(dynamicField3);

            UpdateFieldDynamicLoop dynamicField4 = new UpdateFieldDynamicLoop(dynamicCounter4);
            dynamicField4.Add(new UpdateField("ITEM_DYNAMIC_FIELD_22_1",   UpdateFieldType.Int,    0x0,  0,  0x2));
            UpdateFieldStaticLoop dynamicField4Loop1 = new UpdateFieldStaticLoop(16);
            dynamicField4Loop1.Add(new UpdateField("ITEM_DYNAMIC_FIELD_22_1", UpdateFieldType.Ushort, 0x0,  1,  0x8));
            dynamicField4.Add(dynamicField4Loop1);
            dynamicField4.Add(new UpdateField("ITEM_DYNAMIC_FIELD_22_1",   UpdateFieldType.Byte,   0x0,  2,  0x4));
            item.Add(dynamicField4);*/
        }
    }
}
