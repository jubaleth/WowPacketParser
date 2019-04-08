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

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public sealed class UFBitsAttribute : Attribute
    {
        public UFBitsAttribute(int length)
        {
            this.Length = length;
        }

        public int Length;
    }
}
