using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    public class CGGameObject_C
    {
        public UpdateField GAMEOBJECT_DISPLAYID                  = new UpdateField(UpdateFieldType.Int,      0x0,     3);
        public UpdateField GAMEOBJECT_SPELL_VISUAL_ID            = new UpdateField(UpdateFieldType.Uint,     0x0,     4);
        public UpdateField GAMEOBJECT_STATE_SPELL_VISUAL_ID      = new UpdateField(UpdateFieldType.Uint,     0x0,     5);
        public UpdateField GAMEOBJECT_STATE_ANIM_ID              = new UpdateField(UpdateFieldType.Uint,     0x0,     6);
        public UpdateField GAMEOBJECT_STATE_ANIM_KIT_ID          = new UpdateField(UpdateFieldType.Uint,     0x0,     7);
        [UFDynamicCounter]
        public UpdateField GAMEOBJECT_DYNAMIC_COUNT_1            = new UpdateField(UpdateFieldType.Uint,     0x0,     1);
        public UpdateField GAMEOBJECT_STATE_WORLD_EFFECT_ID      = new UpdateField(UpdateFieldType.Uint,     0x0,     8);
        [UFDynamicField]
        public UpdateField GAMEOBJECT_DYNAMIC_ENABLE_DOODAD_SETS = new UpdateField(UpdateFieldType.Uint,     0x0,     1);
        public UpdateField GAMEOBJECT_FIELD_CREATED_BY           = new UpdateField(UpdateFieldType.Guid,     0x0,     9);
        public UpdateField GAMEOBJECT_FIELD_GUILD_GUID           = new UpdateField(UpdateFieldType.Guid,     0x0,     10);
        public UpdateField GAMEOBJECT_FLAGS                      = new UpdateField(UpdateFieldType.Uint,     0x0,     11);
        public UpdateField GAMEOBJECT_PARENTROTATION_0           = new UpdateField(UpdateFieldType.Float,    0x0,     12);
        public UpdateField GAMEOBJECT_PARENTROTATION_1           = new UpdateField(UpdateFieldType.Float,    0x0,     12);
        public UpdateField GAMEOBJECT_PARENTROTATION_2           = new UpdateField(UpdateFieldType.Float,    0x0,     12);
        public UpdateField GAMEOBJECT_PARENTROTATION_3           = new UpdateField(UpdateFieldType.Float,    0x0,     12);
        public UpdateField GAMEOBJECT_FACTION                    = new UpdateField(UpdateFieldType.Int,      0x0,     13);
        public UpdateField GAMEOBJECT_LEVEL                      = new UpdateField(UpdateFieldType.Int,      0x0,     14);
        public UpdateField GAMEOBJECT_BYTES_1_STATE              = new UpdateField(UpdateFieldType.Sbyte,    0x0,     15);
        public UpdateField GAMEOBJECT_BYTES_1_TYPE               = new UpdateField(UpdateFieldType.Sbyte,    0x0,     16);
        public UpdateField GAMEOBJECT_BYTES_1_ARTKIT             = new UpdateField(UpdateFieldType.Byte,     0x0,     17);
        public UpdateField GAMEOBJECT_BYTES_1_ANIMPROGRESS       = new UpdateField(UpdateFieldType.Byte,     0x0,     18);
        [UFDynamicCounter]
        public UpdateField GAMEOBJECT_DYNAMIC_COUNT_2            = new UpdateField(UpdateFieldType.Uint,     0x0,     2);
        public UpdateField GAMEOBJECT_FIELD_CUSTOM_PARAM         = new UpdateField(UpdateFieldType.Uint,     0x0,     19);
        [UFDynamicField]
        public UpdateField GAMEOBJECT_DYNAMIC_UNKNOWN            = new UpdateField(UpdateFieldType.Uint,     0x0,     2);
    }
}
