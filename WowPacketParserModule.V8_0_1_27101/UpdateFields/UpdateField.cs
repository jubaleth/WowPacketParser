using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    // Dynamic Values are always first, first dynamic value is always read completely (mask + data after)
    //      after that all masks of all dynamic values are read and data is read after all masks have been read
    // then normal values
    // then array values: first bit is used to enable any changes in array, one bit after is first field
    //      e.g. array size 5: 1 bit = enable 2-6 fields
    // ^^^^^^^^^^^^^^^^^^^^^^ that order is also used within substructures
    public class UpdateField
    {
        private UpdateFieldType Type;
        private int RequiredCreationFlag;
        private int UpdateBit;

        public UpdateField(UpdateFieldType type, int reqCreationFlag, int updateBit)
        {
            this.Type = type;
            this.RequiredCreationFlag = reqCreationFlag;
            this.UpdateBit = updateBit;
        }

        public UpdateField(int reqCreationFlag, int updateBit)
        {
            this.Type = UpdateFieldType.Default;
            this.RequiredCreationFlag = reqCreationFlag;
            this.UpdateBit = updateBit;
        }

        public UpdateFieldType GetUpdateFieldType() { return this.Type; }
        public int GetRequiredCreationFlag() { return this.RequiredCreationFlag; }
        public int GetUpdateBit() { return this.UpdateBit; }
    }

    public class UpdateFieldStructure : UpdateField
    {
        private int FieldNum;

        public UpdateFieldStructure(int reqCreationFlag, int updateBit, int fieldNum) : base(reqCreationFlag, updateBit)
        {
            this.FieldNum = fieldNum;
        }

        public int GetFieldNum() { return this.FieldNum; }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public sealed class UFArrayAttribute : Attribute
    {
        public uint Length;

        public UFArrayAttribute(uint length)
        {
            this.Length = length;
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public sealed class UFDynamicCounterAttribute : Attribute
    {
        public UFDynamicCounterAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public sealed class UFDynamicFieldAttribute : Attribute
    {
        public bool SetSpecificEnabled; // with this option enabled additional bitreads are done

        public UFDynamicFieldAttribute()
        {
            this.SetSpecificEnabled = false;
        }

        public UFDynamicFieldAttribute(bool setSpecificEnabled)
        {
            this.SetSpecificEnabled = setSpecificEnabled;
        }
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
