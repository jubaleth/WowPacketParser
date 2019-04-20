using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    public class CGPlayer_C
    {
        public UpdateField PLAYER_FIELD_DUEL_ARBITER = new UpdateField(UpdateFieldType.Guid, 0x0, 2);
        public UpdateField PLAYER_FIELD_WOW_ACCOUNT = new UpdateField(UpdateFieldType.Guid, 0x0, 3);
        public UpdateField PLAYER_FIELD_LOOT_TARGET_GUID = new UpdateField(UpdateFieldType.Guid, 0x0, 4);
        public UpdateField PLAYER_FIELD_FLAGS = new UpdateField(UpdateFieldType.Uint, 0x0, 5);
        public UpdateField PLAYER_FIELD_4 = new UpdateField(UpdateFieldType.Uint, 0x0, 6);
        public UpdateField PLAYER_FIELD_5 = new UpdateField(UpdateFieldType.Uint, 0x0, 7);
        public UpdateField PLAYER_FIELD_6 = new UpdateField(UpdateFieldType.Uint, 0x0, 8);
        public UpdateField PLAYER_FIELD_7 = new UpdateField(UpdateFieldType.Int, 0x0, 9);
        public UpdateField PLAYER_FIELD_8 = new UpdateField(UpdateFieldType.Byte, 0x0, 10);
        public UpdateField PLAYER_FIELD_9 = new UpdateField(UpdateFieldType.Byte, 0x0, 11);
        public UpdateField PLAYER_FIELD_10 = new UpdateField(UpdateFieldType.Byte, 0x0, 12);
        public UpdateField PLAYER_FIELD_11 = new UpdateField(UpdateFieldType.Byte, 0x0, 13);

        [UFArray(3)]
        public UpdateField PLAYER_FIELD_12 = new UpdateField(UpdateFieldType.Byte, 0x0, 31);

        public UpdateField PLAYER_FIELD_15 = new UpdateField(UpdateFieldType.Byte, 0x0, 14);
        public UpdateField PLAYER_FIELD_16 = new UpdateField(UpdateFieldType.Byte, 0x0, 15);
        public UpdateField PLAYER_FIELD_17 = new UpdateField(UpdateFieldType.Byte, 0x0, 16);
        public UpdateField PLAYER_FIELD_18 = new UpdateField(UpdateFieldType.Byte, 0x0, 17);
        public UpdateField PLAYER_FIELD_19 = new UpdateField(UpdateFieldType.Byte, 0x0, 18);
        public UpdateField PLAYER_FIELD_20 = new UpdateField(UpdateFieldType.Byte, 0x0, 19);
        public UpdateField PLAYER_FIELD_21 = new UpdateField(UpdateFieldType.Uint, 0x0, 20);
        public UpdateField PLAYER_FIELD_22 = new UpdateField(UpdateFieldType.Int, 0x0, 21);

        public class QuestLog : UpdateFieldStructure
        {
            public UpdateField PLAYER_FIELD_QUEST_LOG_QUEST_ID = new UpdateField(UpdateFieldType.Int,  0, 1);
            public UpdateField PLAYER_FIELD_QUEST_LOG_UNK_1    = new UpdateField(UpdateFieldType.Uint, 0, 2);
            public UpdateField PLAYER_FIELD_QUEST_LOG_UNK_2    = new UpdateField(UpdateFieldType.Uint, 0, 3);
            public UpdateField PLAYER_FIELD_QUEST_LOG_DATE     = new UpdateField(UpdateFieldType.Time, 0, 4);

            [UFArray(24)]
            public UpdateField PLAYER_FIELD_QUEST_LOG_INFO     = new UpdateField(UpdateFieldType.Ushort, 0, 5);

            public QuestLog(int requiredCreationFlag, int updateBit, int fieldNum) : base(requiredCreationFlag, updateBit, fieldNum) { }
        }
        [UFArray(100)]
        public QuestLog PLAYER_FIELD_QUEST_LOG = new QuestLog(0x2, 35, 32);

        public class PlayerUnknown : UpdateFieldStructure
        {
            public UpdateField PLAYER_FIELD_2823 = new UpdateField(UpdateFieldType.Int, 0, 1);
            public UpdateField PLAYER_FIELD_2824 = new UpdateField(UpdateFieldType.Ushort, 0, 2);
            public UpdateField PLAYER_FIELD_2825 = new UpdateField(UpdateFieldType.Ushort, 0, 3);

            public PlayerUnknown(int requiredCreationFlag, int updateBit, int fieldNum) : base(requiredCreationFlag, updateBit, fieldNum) { }
        }
        [UFArray(19)]
        public PlayerUnknown PLAYER_FIELD_2823_2879 = new PlayerUnknown(0x0, 136, 4);

        public UpdateField PLAYER_FIELD_2880 = new UpdateField(UpdateFieldType.Int, 0x0, 22);
        public UpdateField PLAYER_FIELD_2881 = new UpdateField(UpdateFieldType.Int, 0x0, 23);
        public UpdateField PLAYER_FIELD_VIRTUAL_PLAYER_REALM = new UpdateField(UpdateFieldType.Uint, 0x0, 24);
        public UpdateField PLAYER_FIELD_2883 = new UpdateField(UpdateFieldType.Uint, 0x0, 25);
        public UpdateField PLAYER_FIELD_2884 = new UpdateField(UpdateFieldType.Int, 0x0, 26);

        [UFArray(4)]
        public UpdateField PLAYER_FIELD_AVG_ITEM_LEVEL = new UpdateField(UpdateFieldType.Float, 0x0, 156); 

        public UpdateField PLAYER_FIELD_2886 = new UpdateField(UpdateFieldType.Byte, 0x0, 27);
        public UpdateField PLAYER_FIELD_2887 = new UpdateField(UpdateFieldType.Int, 0x0, 28);

        [UFDynamicCounter]
        public UpdateField PLAYER_FIELD_DYNAMIC_COUNT_1 = new UpdateField(UpdateFieldType.Uint, 0x0, 1);

        public UpdateField PLAYER_FIELD_2889 = new UpdateField(UpdateFieldType.Int, 0x0, 29);
        public UpdateField PLAYER_FIELD_2890 = new UpdateField(UpdateFieldType.Int, 0x0, 30);

        public class PlayerDynamicUnknown : UpdateFieldStructure
        {
            public UpdateField PLAYER_FIELD_DYNAMIC_1 = new UpdateField(UpdateFieldType.Int, 0, 1);
            public UpdateField PLAYER_FIELD_DYNAMIC_2 = new UpdateField(UpdateFieldType.Int, 0, 2);
            public UpdateField PLAYER_FIELD_DYNAMIC_3 = new UpdateField(UpdateFieldType.Uint, 0, 3);
            public UpdateField PLAYER_FIELD_DYNAMIC_4 = new UpdateField(UpdateFieldType.Uint, 0, 4);
            public UpdateField PLAYER_FIELD_DYNAMIC_5 = new UpdateField(UpdateFieldType.Uint, 0, 5);
            public UpdateField PLAYER_FIELD_DYNAMIC_6 = new UpdateField(UpdateFieldType.Uint, 0, 6);
            public UpdateField PLAYER_FIELD_DYNAMIC_7 = new UpdateField(UpdateFieldType.Byte, 0, 7);

            public PlayerDynamicUnknown(int requiredCreationFlag, int updateBit, int fieldNum) : base(requiredCreationFlag, updateBit, fieldNum) { }
        }
        [UFDynamicField(true)]
        public PlayerDynamicUnknown PLAYER_FIELD_DYNAMIC_UNKNOWN_1 = new PlayerDynamicUnknown(0x0, 1, 8);
    }
}
