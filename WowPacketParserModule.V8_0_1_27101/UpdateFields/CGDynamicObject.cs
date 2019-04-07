using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    public class CGDynamicObject_C
    {
        public UpdateField DYNAMICOBJECT_CASTER                     = new UpdateField(UpdateFieldType.Guid,  0x0, 1);
        public UpdateField DYNAMICOBJECT_SPELL_X_SPELL_VISUAL_ID    = new UpdateField(UpdateFieldType.Int,   0x0, 2);
        public UpdateField DYNAMICOBJECT_SPELLID                    = new UpdateField(UpdateFieldType.Int,   0x0, 3);
        public UpdateField DYNAMICOBJECT_RADIUS                     = new UpdateField(UpdateFieldType.Float, 0x0, 4);
        public UpdateField CORPSE_DYNAMICOBJECT_CASTTIMEFIELD_FLAGS = new UpdateField(UpdateFieldType.Uint,  0x0, 5);
        public UpdateField DYNAMICOBJECT_TYPE                       = new UpdateField(UpdateFieldType.Byte,  0x0, 6);
    }
}
