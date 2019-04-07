using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    public class CGAzeriteItem_C
    {
        public UpdateField AZERITE_ITEM_FIELD_XP                   = new UpdateField(UpdateFieldType.Ulong,    0x0,     1);
        public UpdateField AZERITE_ITEM_FIELD_LEVEL                = new UpdateField(UpdateFieldType.Uint,     0x0,     2);
        public UpdateField AZERITE_ITEM_FIELD_AURA_LEVEL           = new UpdateField(UpdateFieldType.Uint,     0x0,     3);
        public UpdateField AZERITE_ITEM_FIELD_KNOWLEDGE_LEVEL      = new UpdateField(UpdateFieldType.Uint,     0x1,     4);
        public UpdateField AZERITE_ITEM_FIELD_DEBUG_KNOWLEDGE_WEEK = new UpdateField(UpdateFieldType.Uint,     0x1,     5);
    }
}
