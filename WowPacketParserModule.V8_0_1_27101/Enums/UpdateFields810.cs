using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_1_0_28724.Enums
{
    public enum ObjectDynamicField
    {
        OBJECT_DYNAMIC_END                                     = 0x000,
    }

    public enum ItemDynamicField
    {
        ITEM_DYNAMIC_FIELD_MODIFIERS                           = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x000, // Flags: OWNER
        ITEM_DYNAMIC_FIELD_BONUSLIST_IDS                       = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x001, // Flags: OWNER, 0x100
        ITEM_DYNAMIC_FIELD_ARTIFACT_POWERS                     = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x002, // Flags: OWNER
        ITEM_DYNAMIC_FIELD_GEMS                                = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x003, // Flags: OWNER
        ITEM_DYNAMIC_END                                       = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x004,
    }

    public enum ContainerDynamicField
    {
        CONTAINER_DYNAMIC_END                                  = ItemDynamicField.ITEM_DYNAMIC_END + 0x000,
    }

    public enum AzeriteEmpoweredItemDynamicField
    {
        AZERITE_EMPOWERED_ITEM_DYNAMIC_END                     = ItemDynamicField.ITEM_DYNAMIC_END + 0x000,
    }

    public enum AzeriteItemDynamicField
    {
        AZERITE_ITEM_DYNAMIC_END                               = ItemDynamicField.ITEM_DYNAMIC_END + 0x000,
    }

    public enum UnitDynamicField
    {
        UNIT_DYNAMIC_FIELD_PASSIVE_SPELLS                      = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x000, // Flags: PUBLIC, URGENT
        UNIT_DYNAMIC_FIELD_WORLD_EFFECTS                       = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x001, // Flags: PUBLIC, URGENT
        UNIT_DYNAMIC_FIELD_CHANNEL_OBJECTS                     = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x002, // Flags: PUBLIC, URGENT
        UNIT_DYNAMIC_END                                       = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x003,
    }

    public enum PlayerDynamicField
    {
        PLAYER_DYNAMIC_FIELD_ARENA_COOLDOWNS                   = UnitDynamicField.UNIT_DYNAMIC_END + 0x000, // Flags: PUBLIC
        PLAYER_DYNAMIC_END                                     = UnitDynamicField.UNIT_DYNAMIC_END + 0x001,
    }

    /*public enum ActivePlayerField
    {
        ACTIVE_PLAYER_FIELD_INV_SLOT_HEAD                      = PlayerField.PLAYER_END + 0x000, // Size: 780, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_FARSIGHT                           = PlayerField.PLAYER_END + 0x30C, // Size: 4, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_SUMMONED_BATTLE_PET_ID             = PlayerField.PLAYER_END + 0x310, // Size: 4, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_KNOWN_TITLES                       = PlayerField.PLAYER_END + 0x314, // Size: 12, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_COINAGE                            = PlayerField.PLAYER_END + 0x320, // Size: 2, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_XP                                 = PlayerField.PLAYER_END + 0x322, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_NEXT_LEVEL_XP                      = PlayerField.PLAYER_END + 0x323, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_TRIAL_XP                           = PlayerField.PLAYER_END + 0x324, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_SKILL_LINEID                       = PlayerField.PLAYER_END + 0x325, // Size: 896, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_CHARACTER_POINTS                   = PlayerField.PLAYER_END + 0x6A5, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_MAX_TALENT_TIERS                   = PlayerField.PLAYER_END + 0x6A6, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_TRACK_CREATURES                    = PlayerField.PLAYER_END + 0x6A7, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_TRACK_RESOURCES                    = PlayerField.PLAYER_END + 0x6A8, // Size: 2, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_EXPERTISE                          = PlayerField.PLAYER_END + 0x6AA, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_OFFHAND_EXPERTISE                  = PlayerField.PLAYER_END + 0x6AB, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_RANGED_EXPERTISE                   = PlayerField.PLAYER_END + 0x6AC, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_COMBAT_RATING_EXPERTISE            = PlayerField.PLAYER_END + 0x6AD, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_BLOCK_PERCENTAGE                   = PlayerField.PLAYER_END + 0x6AE, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_DODGE_PERCENTAGE                   = PlayerField.PLAYER_END + 0x6AF, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_DODGE_PERCENTAGE_FROM_ATTRIBUTE    = PlayerField.PLAYER_END + 0x6B0, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_PARRY_PERCENTAGE                   = PlayerField.PLAYER_END + 0x6B1, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_PARRY_PERCENTAGE_FROM_ATTRIBUTE    = PlayerField.PLAYER_END + 0x6B2, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_CRIT_PERCENTAGE                    = PlayerField.PLAYER_END + 0x6B3, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_RANGED_CRIT_PERCENTAGE             = PlayerField.PLAYER_END + 0x6B4, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_OFFHAND_CRIT_PERCENTAGE            = PlayerField.PLAYER_END + 0x6B5, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_SPELL_CRIT_PERCENTAGE1             = PlayerField.PLAYER_END + 0x6B6, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_SHIELD_BLOCK                       = PlayerField.PLAYER_END + 0x6B7, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_SHIELD_BLOCK_CRIT_PERCENTAGE       = PlayerField.PLAYER_END + 0x6B8, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_MASTERY                            = PlayerField.PLAYER_END + 0x6B9, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_SPEED                              = PlayerField.PLAYER_END + 0x6BA, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_AVOIDANCE                          = PlayerField.PLAYER_END + 0x6BB, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_STURDINESS                         = PlayerField.PLAYER_END + 0x6BC, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_VERSATILITY                        = PlayerField.PLAYER_END + 0x6BD, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_VERSATILITY_BONUS                  = PlayerField.PLAYER_END + 0x6BE, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_PVP_POWER_DAMAGE                   = PlayerField.PLAYER_END + 0x6BF, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_PVP_POWER_HEALING                  = PlayerField.PLAYER_END + 0x6C0, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_EXPLORED_ZONES                     = PlayerField.PLAYER_END + 0x6C1, // Size: 320, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_REST_INFO                          = PlayerField.PLAYER_END + 0x801, // Size: 4, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_MOD_DAMAGE_DONE_POS                = PlayerField.PLAYER_END + 0x805, // Size: 7, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_MOD_DAMAGE_DONE_NEG                = PlayerField.PLAYER_END + 0x80C, // Size: 7, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_MOD_DAMAGE_DONE_PCT                = PlayerField.PLAYER_END + 0x813, // Size: 7, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_MOD_HEALING_DONE_POS               = PlayerField.PLAYER_END + 0x81A, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_MOD_HEALING_PCT                    = PlayerField.PLAYER_END + 0x81B, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_MOD_HEALING_DONE_PCT               = PlayerField.PLAYER_END + 0x81C, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_MOD_PERIODIC_HEALING_DONE_PERCENT  = PlayerField.PLAYER_END + 0x81D, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_WEAPON_DMG_MULTIPLIERS             = PlayerField.PLAYER_END + 0x81E, // Size: 3, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_WEAPON_ATK_SPEED_MULTIPLIERS       = PlayerField.PLAYER_END + 0x821, // Size: 3, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_MOD_SPELL_POWER_PCT                = PlayerField.PLAYER_END + 0x824, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_MOD_RESILIENCE_PERCENT             = PlayerField.PLAYER_END + 0x825, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_OVERRIDE_SPELL_POWER_BY_AP_PCT     = PlayerField.PLAYER_END + 0x826, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_OVERRIDE_AP_BY_SPELL_POWER_PERCENT = PlayerField.PLAYER_END + 0x827, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_MOD_TARGET_RESISTANCE              = PlayerField.PLAYER_END + 0x828, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_MOD_TARGET_PHYSICAL_RESISTANCE     = PlayerField.PLAYER_END + 0x829, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_LOCAL_FLAGS                        = PlayerField.PLAYER_END + 0x82A, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_BYTES                              = PlayerField.PLAYER_END + 0x82B, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_PVP_MEDALS                         = PlayerField.PLAYER_END + 0x82C, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_BUYBACK_PRICE                      = PlayerField.PLAYER_END + 0x82D, // Size: 12, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_BUYBACK_TIMESTAMP                  = PlayerField.PLAYER_END + 0x839, // Size: 12, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_KILLS                              = PlayerField.PLAYER_END + 0x845, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_LIFETIME_HONORABLE_KILLS           = PlayerField.PLAYER_END + 0x846, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_WATCHED_FACTION_INDEX              = PlayerField.PLAYER_END + 0x847, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_COMBAT_RATING                      = PlayerField.PLAYER_END + 0x848, // Size: 32, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_ARENA_TEAM_INFO                    = PlayerField.PLAYER_END + 0x868, // Size: 54, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_MAX_LEVEL                          = PlayerField.PLAYER_END + 0x89E, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_SCALING_PLAYER_LEVEL_DELTA         = PlayerField.PLAYER_END + 0x89F, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_MAX_CREATURE_SCALING_LEVEL         = PlayerField.PLAYER_END + 0x8A0, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_NO_REAGENT_COST                    = PlayerField.PLAYER_END + 0x8A1, // Size: 4, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_PET_SPELL_POWER                    = PlayerField.PLAYER_END + 0x8A5, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_PROFESSION_SKILL_LINE              = PlayerField.PLAYER_END + 0x8A6, // Size: 2, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_UI_HIT_MODIFIER                    = PlayerField.PLAYER_END + 0x8A8, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_UI_SPELL_HIT_MODIFIER              = PlayerField.PLAYER_END + 0x8A9, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_HOME_REALM_TIME_OFFSET             = PlayerField.PLAYER_END + 0x8AA, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_MOD_PET_HASTE                      = PlayerField.PLAYER_END + 0x8AB, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_BYTES2                             = PlayerField.PLAYER_END + 0x8AC, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_BYTES3                             = PlayerField.PLAYER_END + 0x8AD, // Size: 1, Flags: PUBLIC, URGENT_SELF_ONLY
        ACTIVE_PLAYER_FIELD_LFG_BONUS_FACTION_ID               = PlayerField.PLAYER_END + 0x8AE, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_LOOT_SPEC_ID                       = PlayerField.PLAYER_END + 0x8AF, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_OVERRIDE_ZONE_PVP_TYPE             = PlayerField.PLAYER_END + 0x8B0, // Size: 1, Flags: PUBLIC, URGENT_SELF_ONLY
        ACTIVE_PLAYER_FIELD_BAG_SLOT_FLAGS                     = PlayerField.PLAYER_END + 0x8B1, // Size: 4, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_BANK_BAG_SLOT_FLAGS                = PlayerField.PLAYER_END + 0x8B5, // Size: 7, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_INSERT_ITEMS_LEFT_TO_RIGHT         = PlayerField.PLAYER_END + 0x8BC, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_QUEST_COMPLETED                    = PlayerField.PLAYER_END + 0x8BD, // Size: 1750, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_HONOR                              = PlayerField.PLAYER_END + 0xF93, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_HONOR_NEXT_LEVEL                   = PlayerField.PLAYER_END + 0xF94, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_PVP_TIER_MAX_FROM_WINS             = PlayerField.PLAYER_END + 0xF95, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_FIELD_PVP_LAST_WEEKS_TIER_MAX_FROM_WINS  = PlayerField.PLAYER_END + 0xF96, // Size: 1, Flags: PUBLIC
        ACTIVE_PLAYER_END                                      = PlayerField.PLAYER_END + 0xF97,
    }*/

    public enum ActivePlayerDynamicField
    {
        ACTIVE_PLAYER_DYNAMIC_FIELD_RESERACH_SITE              = PlayerDynamicField.PLAYER_DYNAMIC_END + 0x000, // Flags: PUBLIC
        ACTIVE_PLAYER_DYNAMIC_FIELD_RESEARCH_SITE_PROGRESS     = PlayerDynamicField.PLAYER_DYNAMIC_END + 0x001, // Flags: PUBLIC
        ACTIVE_PLAYER_DYNAMIC_FIELD_DAILY_QUESTS               = PlayerDynamicField.PLAYER_DYNAMIC_END + 0x002, // Flags: PUBLIC
        ACTIVE_PLAYER_DYNAMIC_FIELD_AVAILABLE_QUEST_LINE_X_QUEST_ID = PlayerDynamicField.PLAYER_DYNAMIC_END + 0x003, // Flags: PUBLIC
        ACTIVE_PLAYER_DYNAMIC_FIELD_HEIRLOOMS                  = PlayerDynamicField.PLAYER_DYNAMIC_END + 0x005, // Flags: PUBLIC
        ACTIVE_PLAYER_DYNAMIC_FIELD_HEIRLOOM_FLAGS             = PlayerDynamicField.PLAYER_DYNAMIC_END + 0x006, // Flags: PUBLIC
        ACTIVE_PLAYER_DYNAMIC_FIELD_TOYS                       = PlayerDynamicField.PLAYER_DYNAMIC_END + 0x007, // Flags: PUBLIC
        ACTIVE_PLAYER_DYNAMIC_FIELD_TRANSMOG                   = PlayerDynamicField.PLAYER_DYNAMIC_END + 0x008, // Flags: PUBLIC
        ACTIVE_PLAYER_DYNAMIC_FIELD_CONDITIONAL_TRANSMOG       = PlayerDynamicField.PLAYER_DYNAMIC_END + 0x009, // Flags: PUBLIC
        ACTIVE_PLAYER_DYNAMIC_FIELD_SELF_RES_SPELLS            = PlayerDynamicField.PLAYER_DYNAMIC_END + 0x00A, // Flags: PUBLIC
        ACTIVE_PLAYER_DYNAMIC_FIELD_CHARACTER_RESTRICTIONS     = PlayerDynamicField.PLAYER_DYNAMIC_END + 0x00B, // Flags: PUBLIC
        ACTIVE_PLAYER_DYNAMIC_FIELD_SPELL_PCT_MOD_BY_LABEL     = PlayerDynamicField.PLAYER_DYNAMIC_END + 0x00C, // Flags: PUBLIC
        ACTIVE_PLAYER_DYNAMIC_FIELD_SPELL_FLAT_MOD_BY_LABEL    = PlayerDynamicField.PLAYER_DYNAMIC_END + 0x00D, // Flags: PUBLIC
        ACTIVE_PLAYER_DYNAMIC_FIELD_RESERACH                   = PlayerDynamicField.PLAYER_DYNAMIC_END + 0x00E, // Flags: PUBLIC
        ACTIVE_PLAYER_DYNAMIC_END                              = PlayerDynamicField.PLAYER_DYNAMIC_END + 0x00F,
    }

    public enum GameObjectDynamicField
    {
        GAMEOBJECT_DYNAMIC_ENABLE_DOODAD_SETS                  = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x000,
        GAMEOBJECT_DYNAMIC_END                                 = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x001,
    }

    public enum DynamicObjectField
    {
        DYNAMICOBJECT_CASTER                                   = ObjectField.OBJECT_END + 0x000, // Size: 4, Flags: PUBLIC
        DYNAMICOBJECT_TYPE                                     = ObjectField.OBJECT_END + 0x004, // Size: 1, Flags: PUBLIC
        DYNAMICOBJECT_SPELL_X_SPELL_VISUAL_ID                  = ObjectField.OBJECT_END + 0x005, // Size: 1, Flags: PUBLIC
        DYNAMICOBJECT_SPELLID                                  = ObjectField.OBJECT_END + 0x006, // Size: 1, Flags: PUBLIC
        DYNAMICOBJECT_RADIUS                                   = ObjectField.OBJECT_END + 0x007, // Size: 1, Flags: PUBLIC
        DYNAMICOBJECT_CASTTIME                                 = ObjectField.OBJECT_END + 0x008, // Size: 1, Flags: PUBLIC
        DYNAMICOBJECT_END                                      = ObjectField.OBJECT_END + 0x009,
    }

    public enum DynamicObjectDynamicField
    {
        DYNAMICOBJECT_DYNAMIC_END                              = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x000,
    }

    public enum CorpseDynamicField
    {
        CORPSE_DYNAMIC_END                                     = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x000,
    }

    public enum AreaTriggerDynamicField
    {
        AREATRIGGER_DYNAMIC_END                                = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x000,
    }

    public enum SceneObjectDynamicField
    {
        SCENEOBJECT_DYNAMIC_END                                = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x000,
    }

    public enum ConversationDynamicField
    {
        CONVERSATION_DYNAMIC_FIELD_ACTORS                      = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x000, // Flags: PUBLIC
        CONVERSATION_DYNAMIC_FIELD_LINES                       = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x001, // Flags: 0x100
        CONVERSATION_DYNAMIC_END                               = ObjectDynamicField.OBJECT_DYNAMIC_END + 0x002,
    }

    // ReSharper restore InconsistentNaming
}
