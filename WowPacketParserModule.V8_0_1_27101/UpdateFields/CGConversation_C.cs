using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    public class CGConversation_C
    {
        [UFDynamicCounter]
        public UpdateField CONVERSATION_FIELD_DYNAMIC_COUNT_1 = new UpdateField(UpdateFieldType.Uint, 0x0, 1);

        public UpdateField CONVERSATION_LAST_LINE_END_TIME = new UpdateField(UpdateFieldType.Int, 0x0, 3);

        public class DynamicUnknown1 : UpdateFieldStructure
        {
            public UpdateField CONVERSATION_DYNAMIC_FIELD_1 = new UpdateField(UpdateFieldType.Int, 0, 0);
            public UpdateField CONVERSATION_DYNAMIC_FIELD_2 = new UpdateField(UpdateFieldType.Uint, 0, 0);
            public UpdateField CONVERSATION_DYNAMIC_FIELD_3 = new UpdateField(UpdateFieldType.Int, 0, 0);
            public UpdateField CONVERSATION_DYNAMIC_FIELD_4 = new UpdateField(UpdateFieldType.Byte, 0, 0);
            public UpdateField CONVERSATION_DYNAMIC_FIELD_5 = new UpdateField(UpdateFieldType.Byte, 0, 0);

            public DynamicUnknown1(int requiredCreationFlag, int updateBit) : base(requiredCreationFlag, updateBit) { }
        }
        [UFDynamicField]
        public DynamicUnknown1 CONVERSATION_FIELD_DYNAMIC_UNKNOWN_1 = new DynamicUnknown1(0x0, 1);

        [UFDynamicCounter]
        public UpdateField CONVERSATION_FIELD_DYNAMIC_COUNT_2 = new UpdateField(UpdateFieldType.Uint, 0x0, 2);

        public class DynamicUnknown2 : UpdateFieldStructure
        {
            public UpdateField CONVERSATION_DYNAMIC_FIELD_6 = new UpdateField(UpdateFieldType.Uint, 0, 0);
            public UpdateField CONVERSATION_DYNAMIC_FIELD_7 = new UpdateField(UpdateFieldType.Uint, 0, 0);
            public UpdateField CONVERSATION_DYNAMIC_FIELD_8 = new UpdateField(UpdateFieldType.Guid, 0, 0);
            public UpdateField CONVERSATION_DYNAMIC_FIELD_9 = new UpdateField(UpdateFieldType.Int, 0, 0);
            public UpdateField CONVERSATION_DYNAMIC_FIELD_10 = new UpdateField(UpdateFieldType.Byte, 0, 0); // Bit

            public DynamicUnknown2(int requiredCreationFlag, int updateBit) : base(requiredCreationFlag, updateBit) { }
        }
        [UFDynamicField]
        public DynamicUnknown2 CONVERSATION_FIELD_DYNAMIC_UNKNOWN_2 = new DynamicUnknown2(0x0, 2);
    }
}
