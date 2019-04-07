using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    public class CGCorpse_C
    {
        public UpdateField CORPSE_FIELD_DISPLAY_ID              = new UpdateField(UpdateFieldType.Uint,     0x0,     1);
        public UpdateField CORPSE_FIELD_OWNER                   = new UpdateField(UpdateFieldType.Guid,     0x0,     2);
        public UpdateField CORPSE_FIELD_PARTY                   = new UpdateField(UpdateFieldType.Guid,     0x0,     3);
        public UpdateField CORPSE_FIELD_GUILD_GUID              = new UpdateField(UpdateFieldType.Guid,     0x0,     4);
        public UpdateField CORPSE_FIELD_FLAGS                   = new UpdateField(UpdateFieldType.Uint,     0x0,     5);
        [UFArray(19)]
        public UpdateField CORPSE_FIELD_ITEM                    = new UpdateField(UpdateFieldType.Uint,     0x0,    16);
        public UpdateField CORPSE_FIELD_BYTES_1_0               = new UpdateField(UpdateFieldType.Byte,     0x0,     6);
        public UpdateField CORPSE_FIELD_BYTES_1_RACE            = new UpdateField(UpdateFieldType.Byte,     0x0,     7);
        public UpdateField CORPSE_FIELD_BYTES_1_GENDER          = new UpdateField(UpdateFieldType.Byte,     0x0,     8);
        public UpdateField CORPSE_FIELD_BYTES_1_SKIN            = new UpdateField(UpdateFieldType.Byte,     0x0,     9);
        public UpdateField CORPSE_FIELD_BYTES_2_FACE            = new UpdateField(UpdateFieldType.Byte,     0x0,    10);
        public UpdateField CORPSE_FIELD_BYTES_2_HAIR_STYLE      = new UpdateField(UpdateFieldType.Byte,     0x0,    11);
        public UpdateField CORPSE_FIELD_BYTES_2_HAIR_COLOR      = new UpdateField(UpdateFieldType.Byte,     0x0,    12);
        public UpdateField CORPSE_FIELD_BYTES_2_FACIAL_HAIR     = new UpdateField(UpdateFieldType.Byte,     0x0,    13);
        public UpdateField CORPSE_FIELD_DYNAMIC_FLAGS           = new UpdateField(UpdateFieldType.Uint,     0x0,    14);
        public UpdateField CORPSE_FIELD_FACTIONTEMPLATE         = new UpdateField(UpdateFieldType.Int,      0x0,    15);
        [UFArray(3)]
        public UpdateField CORPSE_FIELD_CUSTOM_DISPLAY_OPTION   = new UpdateField(UpdateFieldType.Byte,     0x0,    36);
    }
}
