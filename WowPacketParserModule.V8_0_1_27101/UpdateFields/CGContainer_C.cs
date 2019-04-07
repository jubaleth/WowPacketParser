using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    public class CGContainer_C
    {
        [UFArray(36)]
        public UpdateField CONTAINER_FIELD_SLOT_1       = new UpdateField(UpdateFieldType.Guid, 0x0, 1);
        public UpdateField CONTAINER_FIELD_NUM_SLOTS    = new UpdateField(UpdateFieldType.Uint, 0x0, 2);
    }
}
