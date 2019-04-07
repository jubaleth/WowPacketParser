using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    public class CGAzeriteEmpoweredItem_C
    {
        [UFArray(5)]
        public UpdateField AZERITE_EMPOWERED_ITEM_FIELD_SELECTIONS = new UpdateField(UpdateFieldType.Int, 0x0, 1);
    }
}
