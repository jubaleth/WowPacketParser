using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    public class CGAreaTrigger_C
    {
        public class OverrideScaleCurve : UpdateFieldStructure
        {
            public UpdateField AREATRIGGER_OVERRIDE_SCALE_CURVE_UINT_1             = new UpdateField(UpdateFieldType.Uint,     0x0,     2);
        
            public class OverrideScaleCurveFloat : UpdateFieldStructure
            {
                public UpdateField AREATRIGGER_OVERRIDE_SCALE_CURVE_FLOAT_1 = new UpdateField(UpdateFieldType.Float,      0x0, 0);
                public UpdateField AREATRIGGER_OVERRIDE_SCALE_CURVE_FLOAT_2 = new UpdateField(UpdateFieldType.Float,      0x0, 0);

                public OverrideScaleCurveFloat(int requiredCreationFlag, int updateBit) : base(requiredCreationFlag, updateBit) { }
            }
            [UFArray(2)]
            public OverrideScaleCurveFloat AREATRIGGER_OVERRIDE_SCALE_CURVE_FLOATS = new OverrideScaleCurveFloat(0x0, 4);
            
            public UpdateField AREATRIGGER_OVERRIDE_SCALE_CURVE_UINT_2             = new UpdateField(UpdateFieldType.Uint,     0x0,     3);
            public UpdateField AREATRIGGER_OVERRIDE_SCALE_CURVE_BIT                = new UpdateField(UpdateFieldType.Byte,     0x0,     1);

            public OverrideScaleCurve(int requiredCreationFlag, int updateBit) : base(requiredCreationFlag, updateBit) { }
        }
        public OverrideScaleCurve AREATRIGGER_OVERRIDE_SCALE_CURVE = new OverrideScaleCurve(0x0, 1);

        public UpdateField AREATRIGGER_CASTER                                  = new UpdateField(UpdateFieldType.Guid,     0x0,     3);
        public UpdateField AREATRIGGER_DURATION                                = new UpdateField(UpdateFieldType.Uint,     0x0,     4);
        public UpdateField AREATRIGGER_TIME_TO_TARGET                          = new UpdateField(UpdateFieldType.Uint,     0x0,     5);
        public UpdateField AREATRIGGER_TIME_TO_TARGET_SCALE                    = new UpdateField(UpdateFieldType.Uint,     0x0,     6);
        public UpdateField AREATRIGGER_TIME_TO_TARGET_EXTRA_SCALE              = new UpdateField(UpdateFieldType.Uint,     0x0,     7);
        public UpdateField AREATRIGGER_SPELLID                                 = new UpdateField(UpdateFieldType.Int,      0x0,     8);
        public UpdateField AREATRIGGER_SPELL_FOR_VISUALS                       = new UpdateField(UpdateFieldType.Int,      0x0,     9);
        public UpdateField AREATRIGGER_SPELL_X_SPELL_VISUAL_ID                 = new UpdateField(UpdateFieldType.Int,      0x0,     10);
        public UpdateField AREATRIGGER_BOUNDS_RADIUS_2D                        = new UpdateField(UpdateFieldType.Float,    0x0,     11);
        public UpdateField AREATRIGGER_DECAL_PROPERTIES_ID                     = new UpdateField(UpdateFieldType.Uint,     0x0,     12);
        public UpdateField AREATRIGGER_CREATING_EFFECT_GUID                    = new UpdateField(UpdateFieldType.Guid,     0x0,     13);
        
        
        public class ExtraScaleCurve : UpdateFieldStructure
        {
            public UpdateField AREATRIGGER_EXTRA_SCALE_CURVE_UINT_1             = new UpdateField(UpdateFieldType.Uint,     0x0,     2);
        
            public class ExtraScaleCurveFloat : UpdateFieldStructure
            {
                public UpdateField AREATRIGGER_EXTRA_SCALE_CURVE_FLOAT_1 = new UpdateField(UpdateFieldType.Float,      0x0, 0);
                public UpdateField AREATRIGGER_EXTRA_SCALE_CURVE_FLOAT_2 = new UpdateField(UpdateFieldType.Float,      0x0, 0);

                public ExtraScaleCurveFloat(int requiredCreationFlag, int updateBit) : base(requiredCreationFlag, updateBit) { }
            }
            [UFArray(2)]
            public ExtraScaleCurveFloat AREATRIGGER_EXTRA_SCALE_CURVE_FLOATS = new ExtraScaleCurveFloat(0x0, 4);
            
            public UpdateField AREATRIGGER_EXTRA_SCALE_CURVE_UINT_2                = new UpdateField(UpdateFieldType.Uint,      0x0,     3);
            public UpdateField AREATRIGGER_EXTRA_SCALE_CURVE_BIT                   = new UpdateField(UpdateFieldType.Byte,      0x0,     1);

            public ExtraScaleCurve(int requiredCreationFlag, int updateBit) : base(requiredCreationFlag, updateBit) { }
        }
        public ExtraScaleCurve AREATRIGGER_EXTRA_SCALE_CURVE = new ExtraScaleCurve(0x0, 2);
    }
}
