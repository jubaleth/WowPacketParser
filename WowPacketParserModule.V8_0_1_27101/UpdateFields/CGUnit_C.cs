using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    public class CGUnit_C
    {
        public UpdateField UNIT_FIELD_DISPLAYID                          = new UpdateField(UpdateFieldType.Int,      0x0,     5);
        
        [UFArray(2)]                                                    
        public UpdateField UNIT_FIELD_1                                  = new UpdateField(UpdateFieldType.Uint,     0x0,     114);
        
        public UpdateField UNIT_FIELD_3                                  = new UpdateField(UpdateFieldType.Uint,     0x0,     6);
        public UpdateField UNIT_FIELD_4                                  = new UpdateField(UpdateFieldType.Uint,     0x0,     7);
        public UpdateField UNIT_FIELD_5                                  = new UpdateField(UpdateFieldType.Uint,     0x0,     8);
        
        [UFDynamicCounter]                                               
        public UpdateField UNIT_FIELD_DYNAMIC_COUNT_1                    = new UpdateField(UpdateFieldType.Uint,     0x0,     1);
        
        public UpdateField UNIT_FIELD_7                                  = new UpdateField(UpdateFieldType.Uint,     0x0,     9);
        
        [UFDynamicField]                                                 
        public UpdateField UNIT_FIELD_DYNAMIC_UNKNOWN_1                  = new UpdateField(UpdateFieldType.Uint,     0x0,     1);
        
        public UpdateField UNIT_FIELD_CHARM                              = new UpdateField(UpdateFieldType.Guid,     0x0,     10);
        public UpdateField UNIT_FIELD_SUMMON                             = new UpdateField(UpdateFieldType.Guid,     0x0,     11);
        public UpdateField UNIT_FIELD_CRITTER                            = new UpdateField(UpdateFieldType.Guid,     0x1,     12);
        public UpdateField UNIT_FIELD_CHARMEDBY                          = new UpdateField(UpdateFieldType.Guid,     0x0,     13);
        public UpdateField UNIT_FIELD_SUMMONEDBY                         = new UpdateField(UpdateFieldType.Guid,     0x0,     14);
        public UpdateField UNIT_FIELD_CREATEDBY                          = new UpdateField(UpdateFieldType.Guid,     0x0,     15);
        public UpdateField UNIT_FIELD_DEMON_CREATOR                      = new UpdateField(UpdateFieldType.Guid,     0x0,     16);
        public UpdateField UNIT_FIELD_LOOK_AT_CONTROLLER_TARGET          = new UpdateField(UpdateFieldType.Guid,     0x0,     17);
        public UpdateField UNIT_FIELD_TARGET                             = new UpdateField(UpdateFieldType.Guid,     0x0,     18);
        public UpdateField UNIT_FIELD_BATTLE_PET_COMPANION_GUID          = new UpdateField(UpdateFieldType.Guid,     0x0,     19);
        public UpdateField UNIT_FIELD_NPC_FLAGS                          = new UpdateField(UpdateFieldType.Ulong,    0x0,     20);
        public UpdateField UNIT_FIELD_20                                 = new UpdateField(UpdateFieldType.Int,      0x0,     21);// WOOT?
        public UpdateField UNIT_FIELD_21                                 = new UpdateField(UpdateFieldType.Int,      0x0,     21);// WOOT?
        public UpdateField UNIT_FIELD_22                                 = new UpdateField(UpdateFieldType.Uint,     0x0,     22);
        public UpdateField UNIT_FIELD_BYTES_0_RACE                       = new UpdateField(UpdateFieldType.Byte,     0x0,     23);
        public UpdateField UNIT_FIELD_BYTES_0_CLASS                      = new UpdateField(UpdateFieldType.Byte,     0x0,     24);
        public UpdateField UNIT_FIELD_BYTES_0_PLAYER_CLASS               = new UpdateField(UpdateFieldType.Byte,     0x0,     25);
        public UpdateField UNIT_FIELD_BYTES_0_GENDER                     = new UpdateField(UpdateFieldType.Byte,     0x0,     26);
        public UpdateField UNIT_FIELD_DISPLAY_POWER                      = new UpdateField(UpdateFieldType.Byte,     0x0,     27);
        public UpdateField UNIT_FIELD_25                                 = new UpdateField(UpdateFieldType.Uint,     0x0,     28);
        public UpdateField UNIT_FIELD_HEALTH                             = new UpdateField(UpdateFieldType.Long,     0x0,     29);
        
        public class UnitPowerInfo : UpdateFieldStructure
        {
            public UpdateField UNIT_FIELD_POWER                          = new UpdateField(UpdateFieldType.Int,      0x0, 0);
            public UpdateField UNIT_FIELD_MAXPOWER                       = new UpdateField(UpdateFieldType.Int,      0x0, 0);

            public UnitPowerInfo(int requiredCreationFlag, int updateBit) : base(requiredCreationFlag, updateBit) { }
        }
        [UFArray(6)]
        public UnitPowerInfo UNIT_FIELD_POWER_INFO                       = new UnitPowerInfo(0x0, 117); // Shared with UNIT_FIELD_POWER_REGEN_INFO

        public class UnitPowerRegenInfo : UpdateFieldStructure
        {
            public UpdateField UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER             = new UpdateField(UpdateFieldType.Float,    0x0, 0);
            public UpdateField UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER = new UpdateField(UpdateFieldType.Float,    0x0, 0);

            public UnitPowerRegenInfo(int requiredCreationFlag, int updateBit) : base(requiredCreationFlag, updateBit) { }
        }
        [UFArray(6)]
        public UnitPowerRegenInfo UNIT_FIELD_POWER_REGEN_INFO            = new UnitPowerRegenInfo(0x5, 117);  // Shared with UNIT_FIELD_POWER_INFO           

        public UpdateField UNIT_FIELD_MAXHEALTH                          = new UpdateField(UpdateFieldType.Long,    0x0,     30);
        public UpdateField UNIT_FIELD_LEVEL                              = new UpdateField(UpdateFieldType.Int,     0x0,     31);
        public UpdateField UNIT_FIELD_EFFECTIVE_LEVEL                    = new UpdateField(UpdateFieldType.Int,     0x0,     33);
        public UpdateField UNIT_FIELD_CONTENT_TUNING_ID                  = new UpdateField(UpdateFieldType.Int,     0x0,     34);
        public UpdateField UNIT_FIELD_SCALING_LEVEL_MIN                  = new UpdateField(UpdateFieldType.Int,     0x0,     35);
        public UpdateField UNIT_FIELD_SCALING_LEVEL_MAX                  = new UpdateField(UpdateFieldType.Int,     0x0,     36);
        public UpdateField UNIT_FIELD_SCALING_LEVEL_DELTA                = new UpdateField(UpdateFieldType.Int,     0x0,     37);
        public UpdateField UNIT_FIELD_SCALING_FACTION_GROUP              = new UpdateField(UpdateFieldType.Int,     0x0,     38);
        public UpdateField UNIT_FIELD_SCALING_HEALTH_ITEM_LEVEL_CURVE_ID = new UpdateField(UpdateFieldType.Int,     0x0,     39);
        public UpdateField UNIT_FIELD_SCALING_DAMAGE_ITEM_LEVEL_CURVE_ID = new UpdateField(UpdateFieldType.Int,     0x0,     40);
        public UpdateField UNIT_FIELD_FACTIONTEMPLATE                    = new UpdateField(UpdateFieldType.Int,     0x0,     41);
        
        public class UnitUnkInfo : UpdateFieldStructure
        {
            public UpdateField UNIT_FIELD_62                             = new UpdateField(UpdateFieldType.Int,         0x0, 1);
            public UpdateField UNIT_FIELD_63                             = new UpdateField(UpdateFieldType.Ushort,      0x0, 2);
            public UpdateField UNIT_FIELD_64                             = new UpdateField(UpdateFieldType.Ushort,      0x0, 3);

            public UnitUnkInfo(int requiredCreationFlag, int updateBit) : base(requiredCreationFlag, updateBit) { }
        }
        [UFArray(3)]
        public UnitUnkInfo UNIT_FIELD_UNKNOWN_INFO                       = new UnitUnkInfo(0x0, 142);    
        
        public UpdateField UNIT_FIELD_FLAGS                              = new UpdateField(UpdateFieldType.Uint,     0x0,     42);
        public UpdateField UNIT_FIELD_FLAGS_2                            = new UpdateField(UpdateFieldType.Uint,     0x0,     43);
        public UpdateField UNIT_FIELD_FLAGS_3                            = new UpdateField(UpdateFieldType.Uint,     0x0,     44);
        public UpdateField UNIT_FIELD_AURASTATE                          = new UpdateField(UpdateFieldType.Uint,     0x0,     45);
        
        [UFArray(2)]
        public UpdateField UNIT_FIELD_BASEATTACKTIME                     = new UpdateField(UpdateFieldType.Uint,     0x0,     146);
        
        public UpdateField UNIT_FIELD_RANGEDATTACKTIME                   = new UpdateField(UpdateFieldType.Uint,     0x1,     46);
        public UpdateField UNIT_FIELD_BOUNDINGRADIUS                     = new UpdateField(UpdateFieldType.Float,    0x0,     47);
        public UpdateField UNIT_FIELD_COMBATREACH                        = new UpdateField(UpdateFieldType.Float,    0x0,     48);
        public UpdateField UNIT_FIELD_DISPLAY_SCALE                      = new UpdateField(UpdateFieldType.Float,    0x0,     49);
        public UpdateField UNIT_FIELD_NATIVEDISPLAYID                    = new UpdateField(UpdateFieldType.Int,      0x0,     50);
        public UpdateField UNIT_FIELD_NATIVE_X_DISPLAY_SCALE             = new UpdateField(UpdateFieldType.Float,    0x0,     51);
        public UpdateField UNIT_FIELD_MOUNTDISPLAYID                     = new UpdateField(UpdateFieldType.Int,      0x0,     52);
        public UpdateField UNIT_FIELD_84                                 = new UpdateField(UpdateFieldType.Int,      0x0,     53);        
        public UpdateField UNIT_FIELD_MINDAMAGE                          = new UpdateField(UpdateFieldType.Float,    0x9,     54);
        public UpdateField UNIT_FIELD_MAXDAMAGE                          = new UpdateField(UpdateFieldType.Float,    0x9,     55);
        public UpdateField UNIT_FIELD_MINOFFHANDDAMGE                    = new UpdateField(UpdateFieldType.Float,    0x9,     56);
        public UpdateField UNIT_FIELD_MAXOFFHANDDAMAGE                   = new UpdateField(UpdateFieldType.Float,    0x9,     57);
        public UpdateField UNIT_FIELD_BYTES_1_STAND_STATE                = new UpdateField(UpdateFieldType.Byte,     0x0,     58);
        public UpdateField UNIT_FIELD_BYTES_1_PET_TALENTS                = new UpdateField(UpdateFieldType.Byte,     0x0,     59);
        public UpdateField UNIT_FIELD_BYTES_1_VIS_FLAG                   = new UpdateField(UpdateFieldType.Byte,     0x0,     60);
        public UpdateField UNIT_FIELD_BYTES_1_ANIM_TIER                  = new UpdateField(UpdateFieldType.Byte,     0x0,     61);
        public UpdateField UNIT_FIELD_PETNUMBER                          = new UpdateField(UpdateFieldType.Uint,     0x0,     62);
        public UpdateField UNIT_FIELD_PET_NAME_TIMESTAMP                 = new UpdateField(UpdateFieldType.Uint,     0x0,     63);
        public UpdateField UNIT_FIELD_PETEXPERIENCE                      = new UpdateField(UpdateFieldType.Uint,     0x0,     65);
        public UpdateField UNIT_FIELD_PETNEXTLEVELEXP                    = new UpdateField(UpdateFieldType.Uint,     0x0,     66);
        public UpdateField UNIT_FIELD_MOD_CAST_SPEED                     = new UpdateField(UpdateFieldType.Float,    0x0,     67);
        public UpdateField UNIT_FIELD_MOD_CAST_HASTE                     = new UpdateField(UpdateFieldType.Float,    0x0,     68);
        public UpdateField UNIT_FIELD_MOD_HASTE                          = new UpdateField(UpdateFieldType.Float,    0x0,     69);
        public UpdateField UNIT_FIELD_MOD_RANGED_HASTE                   = new UpdateField(UpdateFieldType.Float,    0x0,     70);
        public UpdateField UNIT_FIELD_MOD_HASTE_REGEN                    = new UpdateField(UpdateFieldType.Float,    0x0,     71);
        public UpdateField UNIT_FIELD_MOD_TIME_RATE                      = new UpdateField(UpdateFieldType.Float,    0x0,     72);
        public UpdateField UNIT_FIELD_CREATED_BY_SPELL                   = new UpdateField(UpdateFieldType.Int,      0x0,     73);
        public UpdateField UNIT_FIELD_NPC_EMOTESTATE                     = new UpdateField(UpdateFieldType.Int,      0x0,     74);
        
        public class UnitStatInfo : UpdateFieldStructure
        {
            public UpdateField UNIT_FIELD_STAT                           = new UpdateField(UpdateFieldType.Int,      0x0, 0); // Check bitsmask
            public UpdateField UNIT_FIELD_POSSTAT                        = new UpdateField(UpdateFieldType.Int,      0x0, 0); // Check bitsmask
            public UpdateField UNIT_FIELD_NEGSTAT                        = new UpdateField(UpdateFieldType.Int,      0x0, 0); // Check bitsmask

            public UnitStatInfo(int requiredCreationFlag, int updateBit) : base(requiredCreationFlag, updateBit) { }
        }
        [UFArray(4)]
        public UnitStatInfo UNIT_FIELD_STAT_INFO                         = new UnitStatInfo(0x1, 149);
        
        [UFArray(7)]
        public UpdateField UNIT_FIELD_RESISTANCES                        = new UpdateField(UpdateFieldType.Int,      0x9,     162); // Shared with UNIT_FIELD_MOD_INFO

        public class UnitModInfo : UpdateFieldStructure
        {
            public UpdateField UNIT_FIELD_BONUS_RESISTANCE_MODS          = new UpdateField(UpdateFieldType.Int,      0x0, 0); // Check bitsmask
            public UpdateField UNIT_FIELD_POWER_COST_MODIFIER            = new UpdateField(UpdateFieldType.Int,      0x0, 0); // Check bitsmask
            public UpdateField UNIT_FIELD_POWER_COST_MULTIPLIER          = new UpdateField(UpdateFieldType.Float,    0x0, 0); // Check bitsmask

            public UnitModInfo(int requiredCreationFlag, int updateBit) : base(requiredCreationFlag, updateBit) { }
        }
        [UFArray(7)]
        public UnitModInfo UNIT_FIELD_MOD_INFO                           = new UnitModInfo(0x1, 162); // Shared with UNIT_FIELD_RESISTANCES

        public UpdateField UNIT_FIELD_BASE_MANA                          = new UpdateField(UpdateFieldType.Int,      0x0,     75);
        public UpdateField UNIT_FIELD_BASE_HEALTH                        = new UpdateField(UpdateFieldType.Int,      0x1,     76);
        public UpdateField UNIT_FIELD_BYTES_2_SHEATH_STATE               = new UpdateField(UpdateFieldType.Byte,     0x0,     77);
        public UpdateField UNIT_FIELD_BYTES_2_PVP_FLAG                   = new UpdateField(UpdateFieldType.Byte,     0x0,     78);
        public UpdateField UNIT_FIELD_BYTES_2_PET_FLAGS                  = new UpdateField(UpdateFieldType.Byte,     0x0,     79);
        public UpdateField UNIT_FIELD_BYTES_2_SHAPESHIFT_FORM            = new UpdateField(UpdateFieldType.Byte,     0x0,     80);
        public UpdateField UNIT_FIELD_ATTACK_POWER                       = new UpdateField(UpdateFieldType.Int,      0x1,     81);
        public UpdateField UNIT_FIELD_ATTACK_POWER_MOD_POS               = new UpdateField(UpdateFieldType.Int,      0x1,     82);
        public UpdateField UNIT_FIELD_ATTACK_POWER_MOD_NEG               = new UpdateField(UpdateFieldType.Int,      0x1,     83);
        public UpdateField UNIT_FIELD_ATTACK_POWER_MULTIPLIER            = new UpdateField(UpdateFieldType.Float,    0x1,     84);
        public UpdateField UNIT_FIELD_RANGED_ATTACK_POWER                = new UpdateField(UpdateFieldType.Int,      0x1,     85);
        public UpdateField UNIT_FIELD_RANGED_ATTACK_POWER_MOD_POS        = new UpdateField(UpdateFieldType.Int,      0x1,     86);
        public UpdateField UNIT_FIELD_RANGED_ATTACK_POWER_MOD_NEG        = new UpdateField(UpdateFieldType.Int,      0x1,     87);
        public UpdateField UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER     = new UpdateField(UpdateFieldType.Float,    0x1,     88);
        public UpdateField UNIT_FIELD_MAIN_HAND_WEAPON_ATTACK_POWER      = new UpdateField(UpdateFieldType.Int,      0x1,     89);
        public UpdateField UNIT_FIELD_OFF_HAND_WEAPON_ATTACK_POWER       = new UpdateField(UpdateFieldType.Int,      0x1,     90);
        public UpdateField UNIT_FIELD_RANGED_HAND_WEAPON_ATTACK_POWER    = new UpdateField(UpdateFieldType.Int,      0x1,     91);
        public UpdateField UNIT_FIELD_ATTACK_SPEED_AURA                  = new UpdateField(UpdateFieldType.Int,      0x1,     92);
        public UpdateField UNIT_FIELD_LIFESTEAL                          = new UpdateField(UpdateFieldType.Float,    0x1,     93);
        public UpdateField UNIT_FIELD_MINRANGEDDAMAGE                    = new UpdateField(UpdateFieldType.Float,    0x1,     94);
        public UpdateField UNIT_FIELD_MAXRANGEDDAMAGE                    = new UpdateField(UpdateFieldType.Float,    0x1,     95);
        public UpdateField UNIT_FIELD_160                                = new UpdateField(UpdateFieldType.Float,    0x1,     97);
        public UpdateField UNIT_FIELD_MAXHEALTHMODIFIER                  = new UpdateField(UpdateFieldType.Float,    0x1,     98);
        public UpdateField UNIT_FIELD_HOVERHEIGHT                        = new UpdateField(UpdateFieldType.Float,    0x0,     99);
        public UpdateField UNIT_FIELD_163                                = new UpdateField(UpdateFieldType.Int,      0x0,     100);
        public UpdateField UNIT_FIELD_164                                = new UpdateField(UpdateFieldType.Int,      0x0,     101);
        public UpdateField UNIT_FIELD_165                                = new UpdateField(UpdateFieldType.Int,      0x0,     102);
        public UpdateField UNIT_FIELD_166                                = new UpdateField(UpdateFieldType.Int,      0x0,     103);
        public UpdateField UNIT_FIELD_167                                = new UpdateField(UpdateFieldType.Int,      0x0,     104);
        public UpdateField UNIT_FIELD_168                                = new UpdateField(UpdateFieldType.Uint,     0x0,     105);
        public UpdateField UNIT_FIELD_169                                = new UpdateField(UpdateFieldType.Int,      0x0,     106);
        public UpdateField UNIT_FIELD_170                                = new UpdateField(UpdateFieldType.Int,      0x0,     107);
        public UpdateField UNIT_FIELD_171                                = new UpdateField(UpdateFieldType.Int,      0x0,     108);
        public UpdateField UNIT_FIELD_172                                = new UpdateField(UpdateFieldType.Int,      0x0,     109);
        public UpdateField UNIT_FIELD_173                                = new UpdateField(UpdateFieldType.Int,      0x0,     110);
        public UpdateField UNIT_FIELD_LOOK_AT_CONTROLLER_ID              = new UpdateField(UpdateFieldType.Int,      0x0,     111);
        public UpdateField UNIT_FIELD_174                                = new UpdateField(UpdateFieldType.Int,      0x0,     112);
        public UpdateField UNIT_FIELD_GUILD_GUID                         = new UpdateField(UpdateFieldType.Guid,     0x0,     113);
        
        [UFDynamicCounter]
        public UpdateField UNIT_FIELD_DYNAMIC_COUNT_2                    = new UpdateField(UpdateFieldType.Uint,      0x0,     2);
        
        [UFDynamicCounter]                                               
        public UpdateField UNIT_FIELD_DYNAMIC_COUNT_3                    = new UpdateField(UpdateFieldType.Uint,      0x0,     3);
        
        [UFDynamicCounter]                                               
        public UpdateField UNIT_FIELD_DYNAMIC_COUNT_4                    = new UpdateField(UpdateFieldType.Uint,      0x0,     4);
        
        public class UnitDynamicUnknown2 : UpdateFieldStructure
        {
            public UpdateField UNIT_DYNAMIC_UNKNOWN_2                    = new UpdateField(UpdateFieldType.Int,      0x0, 0);
            public UpdateField UNIT_DYNAMIC_UNKNOWN_3                    = new UpdateField(UpdateFieldType.Int,      0x0, 0);

            public UnitDynamicUnknown2(int requiredCreationFlag, int updateBit) : base(requiredCreationFlag, updateBit) { }
        }
        [UFDynamicField]
        public UnitDynamicUnknown2 UNIT_DYNAMIC_UNKNOWN                  = new UnitDynamicUnknown2(0x0, 2);
        
        [UFDynamicField]
        public UpdateField UNIT_DYNAMIC_UNKNOWN_4                        = new UpdateField(UpdateFieldType.Int,      0x0,     3);
                                                                         
        [UFDynamicField]                                                 
        public UpdateField UNIT_DYNAMIC_UNKNOWN_5                        = new UpdateField(UpdateFieldType.Guid,     0x0,     4);        
    }
}