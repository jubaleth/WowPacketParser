using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    public class CGPlayer_C
    {
        public UpdateField PLAYER_FIELD_0 = new UpdateField(UpdateFieldType.Guid, 0x0, 0);
        public UpdateField PLAYER_FIELD_1 = new UpdateField(UpdateFieldType.Guid, 0x0, 0);
        public UpdateField PLAYER_FIELD_2 = new UpdateField(UpdateFieldType.Guid, 0x0, 0);
        public UpdateField PLAYER_FIELD_3 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);
        public UpdateField PLAYER_FIELD_4 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);
        public UpdateField PLAYER_FIELD_5 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);
        public UpdateField PLAYER_FIELD_6 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);
        public UpdateField PLAYER_FIELD_7 = new UpdateField(UpdateFieldType.Int, 0x0, 0);
        public UpdateField PLAYER_FIELD_8 = new UpdateField(UpdateFieldType.Byte, 0x0, 0);
        public UpdateField PLAYER_FIELD_9 = new UpdateField(UpdateFieldType.Byte, 0x0, 0);
        public UpdateField PLAYER_FIELD_10 = new UpdateField(UpdateFieldType.Byte, 0x0, 0);
        public UpdateField PLAYER_FIELD_11 = new UpdateField(UpdateFieldType.Byte, 0x0, 0);

        [UFArray(3)]
        public UpdateField PLAYER_FIELD_12 = new UpdateField(UpdateFieldType.Byte, 0x0, 0);

        public UpdateField PLAYER_FIELD_15 = new UpdateField(UpdateFieldType.Byte, 0x0, 0);
        public UpdateField PLAYER_FIELD_16 = new UpdateField(UpdateFieldType.Byte, 0x0, 0);
        public UpdateField PLAYER_FIELD_17 = new UpdateField(UpdateFieldType.Byte, 0x0, 0);
        public UpdateField PLAYER_FIELD_18 = new UpdateField(UpdateFieldType.Byte, 0x0, 0);
        public UpdateField PLAYER_FIELD_19 = new UpdateField(UpdateFieldType.Byte, 0x0, 0);
        public UpdateField PLAYER_FIELD_20 = new UpdateField(UpdateFieldType.Byte, 0x0, 0);
        public UpdateField PLAYER_FIELD_21 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);
        public UpdateField PLAYER_FIELD_22 = new UpdateField(UpdateFieldType.Int, 0x0, 0);

        public class QuestLog : UpdateFieldStructure
        {
            public UpdateField PLAYER_QUEST_LOG_QUEST_ID = new UpdateField(UpdateFieldType.Int,  0, 0);
            public UpdateField PLAYER_QUEST_LOG_UNK_1    = new UpdateField(UpdateFieldType.Uint, 0, 0);
            public UpdateField PLAYER_QUEST_LOG_UNK_2    = new UpdateField(UpdateFieldType.Uint, 0, 0);
            public UpdateField PLAYER_QUEST_LOG_DATE     = new UpdateField(UpdateFieldType.Time, 0, 0);

            public class QuestLogInfo : UpdateFieldStructure
            {
                public UpdateField PLAYER_QUEST_LOG_UNK_3 = new UpdateField(UpdateFieldType.Ushort, 0, 0);

                public QuestLogInfo(uint requiredCreationFlag, uint updateBit) : base(requiredCreationFlag, updateBit) { }
            }
            [UFArray(24)]
            public QuestLogInfo PLAYER_QUEST_LOG_INFO = new QuestLogInfo(0x0, 0);

            public QuestLog(uint requiredCreationFlag, uint updateBit) : base(requiredCreationFlag, updateBit) { }
        }
        [UFArray(100)]
        public QuestLog PLAYER_QUEST_LOG = new QuestLog(0x2, 0);

        public class PlayerUnknown : UpdateFieldStructure
        {
            public UpdateField PLAYER_FIELD_2823 = new UpdateField(UpdateFieldType.Int, 0, 0);
            public UpdateField PLAYER_FIELD_2824 = new UpdateField(UpdateFieldType.Ushort, 0, 0);
            public UpdateField PLAYER_FIELD_2825 = new UpdateField(UpdateFieldType.Ushort, 0, 0);

            public PlayerUnknown(uint requiredCreationFlag, uint updateBit) : base(requiredCreationFlag, updateBit) { }
        }
        [UFArray(19)]
        public PlayerUnknown PLAYER_FIELD_2823_2879 = new PlayerUnknown(0x0, 0);

        public UpdateField PLAYER_FIELD_2880 = new UpdateField(UpdateFieldType.Int, 0x0, 0);
        public UpdateField PLAYER_FIELD_2881 = new UpdateField(UpdateFieldType.Int, 0x0, 0);
        public UpdateField PLAYER_FIELD_2882 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);
        public UpdateField PLAYER_FIELD_2883 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);
        public UpdateField PLAYER_FIELD_2884 = new UpdateField(UpdateFieldType.Int, 0x0, 0);

        [UFArray(4)]
        public UpdateField PLAYER_FIELD_2885 = new UpdateField(UpdateFieldType.Float, 0x0, 0);

        public UpdateField PLAYER_FIELD_2886 = new UpdateField(UpdateFieldType.Byte, 0x0, 0);
        public UpdateField PLAYER_FIELD_2887 = new UpdateField(UpdateFieldType.Int, 0x0, 0);

        [UFDynamicCounter]
        public UpdateField PLAYER_FIELD_DYNAMIC_COUNT_1 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        public UpdateField PLAYER_FIELD_2889 = new UpdateField(UpdateFieldType.Int, 0x0, 0);
        public UpdateField PLAYER_FIELD_2890 = new UpdateField(UpdateFieldType.Int, 0x0, 0);

        public class PlayerDynamicUnknown : UpdateFieldStructure
        {
            public UpdateField PLAYER_FIELD_DYNAMIC_1 = new UpdateField(UpdateFieldType.Int, 0, 0);
            public UpdateField PLAYER_FIELD_DYNAMIC_2 = new UpdateField(UpdateFieldType.Int, 0, 0);
            public UpdateField PLAYER_FIELD_DYNAMIC_3 = new UpdateField(UpdateFieldType.Uint, 0, 0);
            public UpdateField PLAYER_FIELD_DYNAMIC_4 = new UpdateField(UpdateFieldType.Uint, 0, 0);
            public UpdateField PLAYER_FIELD_DYNAMIC_5 = new UpdateField(UpdateFieldType.Uint, 0, 0);
            public UpdateField PLAYER_FIELD_DYNAMIC_6 = new UpdateField(UpdateFieldType.Uint, 0, 0);
            public UpdateField PLAYER_FIELD_DYNAMIC_7 = new UpdateField(UpdateFieldType.Byte, 0, 0);

            public PlayerDynamicUnknown(uint requiredCreationFlag, uint updateBit) : base(requiredCreationFlag, updateBit) { }
        }
        [UFDynamicField]
        public PlayerDynamicUnknown PLAYER_FIELD_DYNAMIC_UNKNOWN_1 = new PlayerDynamicUnknown(0x0, 0);
    }
}
