using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    public class CGSceneObject_C
    {
        public UpdateField SCENEOBJECT_FIELD_SCRIPT_PACKAGE_ID = new UpdateField(UpdateFieldType.Int,      0x0,     1);
        public UpdateField SCENEOBJECT_FIELD_RND_SEED_VAL      = new UpdateField(UpdateFieldType.Uint,     0x0,     2);
        public UpdateField SCENEOBJECT_FIELD_CREATEDBY         = new UpdateField(UpdateFieldType.Guid,     0x0,     3);
        public UpdateField SCENEOBJECT_FIELD_SCENE_TYPE        = new UpdateField(UpdateFieldType.Uint,     0x0,     4);
    }
}
