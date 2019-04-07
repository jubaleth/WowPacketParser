using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    public class CGObject_C
    {
        public UpdateField OBJECT_FIELD_ENTRY   = new UpdateField(UpdateFieldType.Int,      0x0,     1);
        public UpdateField OBJECT_DYNAMIC_FLAGS = new UpdateField(UpdateFieldType.Uint,     0x0,     2);
        public UpdateField OBJECT_FIELD_SCALE_X = new UpdateField(UpdateFieldType.Float,    0x0,     3);

        public static int UPDATE_MASK_BLOCK_NUM = 2;
    }
}
