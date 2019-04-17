using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    public class CGItem_C
    {
        [UFDynamicCounter]
        public UpdateField ITEM_FIELD_DYNAMIC_COUNT_1       = new UpdateField(UpdateFieldType.Uint,     0x0,     1);
        [UFDynamicField]
        public UpdateField dynamicField1                    = new UpdateField(UpdateFieldType.Int,      0x0,     1);
        public UpdateField ITEM_FIELD_OWNER                 = new UpdateField(UpdateFieldType.Guid,     0x0,     5);
        public UpdateField ITEM_FIELD_CONTAINED             = new UpdateField(UpdateFieldType.Guid,     0x0,     6);
        public UpdateField ITEM_FIELD_CREATOR               = new UpdateField(UpdateFieldType.Guid,     0x0,     7);
        public UpdateField ITEM_FIELD_GIFTCREATOR           = new UpdateField(UpdateFieldType.Guid,     0x0,     8);
        public UpdateField ITEM_FIELD_STACK_COUNT           = new UpdateField(UpdateFieldType.Uint,     0x1,     9);
        public UpdateField ITEM_FIELD_DURATION              = new UpdateField(UpdateFieldType.Uint,     0x1,    10);
        [UFArray(5)]
        public UpdateField ITEM_FIELD_SPELL_CHARGES         = new UpdateField(UpdateFieldType.Int,      0x0,    20); 
        public UpdateField ITEM_FIELD_DYNAMIC_FLAGS         = new UpdateField(UpdateFieldType.Uint,     0x0,    11);
        public class Enchantments : UpdateFieldStructure
        {
            public UpdateField ENCHANTMENT1 = new UpdateField(UpdateFieldType.Int,      0, 1);
            public UpdateField ENCHANTMENT2 = new UpdateField(UpdateFieldType.Uint,     0, 2);
            public UpdateField ENCHANTMENT3 = new UpdateField(UpdateFieldType.Short,    0, 3);
            public UpdateField ENCHANTMENT4 = new UpdateField(UpdateFieldType.Ushort,   0, 4);

            public Enchantments(int requiredCreationFlag, int updateBit, int fieldNum) : base(requiredCreationFlag, updateBit, fieldNum) { }
        }
        [UFArray(13)]
        public Enchantments ITEM_FIELD_ENCHANTMENT          = new Enchantments(0x0, 21, 5);

        public UpdateField ITEM_FIELD_DURABILITY            = new UpdateField(UpdateFieldType.Uint,     0x1,    12);
        public UpdateField ITEM_FIELD_MAXDURABILITY         = new UpdateField(UpdateFieldType.Uint,     0x1,    13);
        public UpdateField ITEM_FIELD_CREATE_PLAYED_TIME    = new UpdateField(UpdateFieldType.Uint,     0x0,    14);
        public UpdateField ITEM_FIELD_MODIFIERS_MASK        = new UpdateField(UpdateFieldType.Uint,     0x1,    15);
        public UpdateField ITEM_FIELD_CONTEXT               = new UpdateField(UpdateFieldType.Uint,     0x0,    16);
        public UpdateField ITEM_FIELD_ARTIFACT_XP           = new UpdateField(UpdateFieldType.Ulong,    0x1,    17);
        public UpdateField ITEM_FIELD_APPEARANCE_MOD_ID     = new UpdateField(UpdateFieldType.Byte,     0x1,    18);

        [UFDynamicCounter]
        public UpdateField ITEM_DYNAMIC_COUNTER_FIELD_21    = new UpdateField(UpdateFieldType.Uint,     0x0,     2);
        [UFDynamicCounter]
        public UpdateField ITEM_DYNAMIC_COUNTER_FIELD_22    = new UpdateField(UpdateFieldType.Uint,     0x0,     3);
        [UFDynamicCounter]
        public UpdateField ITEM_DYNAMIC_COUNTER_FIELD_23    = new UpdateField(UpdateFieldType.Uint,     0x0,     4);
        public UpdateField ITEM_FIELD_24                    = new UpdateField(UpdateFieldType.Uint,     0x0,    19);

        // dynamic fields
        [UFDynamicField(true)]
        public UpdateField ITEM_DYNAMIC_FIELD_21            = new UpdateField(UpdateFieldType.Uint,     0x0,     2);

        public class UnkDynamicField1 : UpdateFieldStructure
        {
            public UpdateField ITEM_DYNAMIC_FIELD_22_1 = new UpdateField(UpdateFieldType.Short,    0, 1);
            public UpdateField ITEM_DYNAMIC_FIELD_22_2 = new UpdateField(UpdateFieldType.Byte,     0, 2);
            public UpdateField ITEM_DYNAMIC_FIELD_22_3 = new UpdateField(UpdateFieldType.Byte,     0, 3);

            public UnkDynamicField1(int requiredCreationFlag, int updateBit, int fieldNum) : base(requiredCreationFlag, updateBit, fieldNum) { }
        }
        [UFDynamicField(true)]
        public UnkDynamicField1 ITEM_DYNAMIC_FIELD_22       = new UnkDynamicField1(0x0, 3, 0);
        
        public class UnkDynamicField2 : UpdateFieldStructure
        {
            public UpdateField ITEM_DYNAMIC_FIELD_23_1      = new UpdateField(UpdateFieldType.Int,      0, 1);
            [UFArray(16)]
            public UpdateField ITEM_DYNAMIC_FIELD_23_2      = new UpdateField(UpdateFieldType.Ushort,   0, 3);
            public UpdateField ITEM_DYNAMIC_FIELD_23_3      = new UpdateField(UpdateFieldType.Byte,     0, 2);

            public UnkDynamicField2(int requiredCreationFlag, int updateBit, int fieldNum) : base(requiredCreationFlag, updateBit, fieldNum) { }
        }
        [UFDynamicField(true)]
        public UnkDynamicField2 ITEM_DYNAMIC_FIELD_23       = new UnkDynamicField2(0x0, 4, 32);
    }
}
