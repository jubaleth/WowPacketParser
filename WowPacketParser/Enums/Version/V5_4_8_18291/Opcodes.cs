using WowPacketParser.Misc;

namespace WowPacketParser.Enums.Version.V5_4_8_18291
{
    public static class Opcodes_5_4_8
    {
        public static BiDictionary<Opcode, int> Opcodes()
        {
            return Opcs;
        }

        private static readonly BiDictionary<Opcode, int> Opcs = new BiDictionary<Opcode, int>
        {
            {Opcode.CMSG_AREATRIGGER, 0x1C44},
            {Opcode.CMSG_ATTACKSTOP, 0x0345},
            {Opcode.CMSG_ATTACKSWING, 0x02E7},
            {Opcode.CMSG_AUCTION_HELLO, 0x0379},
            {Opcode.CMSG_AUTH_SESSION, 0x00B2},
            {Opcode.CMSG_BANKER_ACTIVATE, 0x02E9},
            {Opcode.CMSG_DB_QUERY_BULK, 0x158D},
            {Opcode.CMSG_CANCEL_AURA, 0x1861 | 0x10000},
            {Opcode.CMSG_CANCEL_CAST, 0x18C0},
            {Opcode.CMSG_CANCEL_CHANNELLING, 0x08C0},
            {Opcode.CMSG_CANCEL_MOUNT_AURA, 0x1552},
            {Opcode.CMSG_CAST_SPELL, 0x0206},
            {Opcode.CMSG_CHAR_CREATE, 0x0F1D},
            {Opcode.CMSG_CHAR_DELETE, 0x04E2},
            {Opcode.CMSG_CHAR_ENUM, 0x00E0},
            {Opcode.CMSG_CREATURE_QUERY, 0x0842},
            {Opcode.CMSG_GAMEOBJECT_QUERY, 0x1461},
            {Opcode.CMSG_GAMEOBJ_REPORT_USE,  0x06D8},
            {Opcode.CMSG_GAMEOBJ_USE, 0x06D9},
            {Opcode.CMSG_GET_MAIL_LIST, 0x077A},
            {Opcode.CMSG_GOSSIP_HELLO, 0x12F3},
            {Opcode.CMSG_GOSSIP_SELECT_OPTION, 0x0748},
            {Opcode.CMSG_GROUP_INVITE, 0x072D},
            {Opcode.CMSG_GROUP_INVITE_RESPONSE, 0x0D61},
            {Opcode.CMSG_GROUP_SET_LEADER, 0x15BB},
            {Opcode.CMSG_GUILD_QUERY, 0x1AB6},
            {Opcode.CMSG_LIST_INVENTORY, 0x02D8},
            {Opcode.CMSG_LOAD_SCREEN, 0x1DBD},
            {Opcode.CMSG_LOGOUT_CANCEL, 0x06C1},
            {Opcode.CMSG_LOGOUT_REQUEST, 0x1349},
            {Opcode.CMSG_LOG_DISCONNECT, 0x10B3},
            {Opcode.CMSG_MAIL_MARK_AS_READ, 0x0241},
            {Opcode.CMSG_MAIL_RETURN_TO_SENDER, 0x1FA8},
            {Opcode.CMSG_MESSAGECHAT_AFK, 0x0EAB | 0x10000},
            {Opcode.CMSG_MESSAGECHAT_CHANNEL, 0x00BB},
            {Opcode.CMSG_MESSAGECHAT_DND, 0x002E | 0x10000},
            {Opcode.CMSG_MESSAGECHAT_EMOTE, 0x103E},
            {Opcode.CMSG_MESSAGECHAT_GUILD, 0x0CAE},
            {Opcode.CMSG_MESSAGECHAT_SAY, 0x0A9A | 0x10000},
            {Opcode.CMSG_MESSAGECHAT_WHISPER, 0x123E},
            {Opcode.CMSG_MESSAGECHAT_YELL, 0x04AA},
            {Opcode.CMSG_NAME_QUERY, 0x0328},
            {Opcode.CMSG_NPC_TEXT_QUERY, 0x0287},
            {Opcode.CMSG_PAGE_TEXT_QUERY, 0x1022},
            {Opcode.CMSG_PET_NAME_QUERY, 0x1C62},
            {Opcode.CMSG_PING, 0x0012},
            {Opcode.CMSG_PLAYER_LOGIN, 0x158F},
            {Opcode.CMSG_QUESTGIVER_ACCEPT_QUEST, 0x06D1},
            {Opcode.CMSG_QUESTGIVER_CHOOSE_REWARD, 0x07CB},
            {Opcode.CMSG_QUESTGIVER_COMPLETE_QUEST, 0x0659},
            {Opcode.CMSG_QUESTGIVER_HELLO, 0x02DB},
            {Opcode.CMSG_QUESTGIVER_QUERY_QUEST, 0x12F0},
            {Opcode.CMSG_QUESTGIVER_REQUEST_REWARD, 0x0378},
            {Opcode.CMSG_QUESTGIVER_STATUS_MULTIPLE_QUERY, 0x02F1 | 0x10000},
            {Opcode.CMSG_QUESTGIVER_STATUS_QUERY, 0x036A | 0x10000},
            {Opcode.CMSG_QUESTLOG_REMOVE_QUEST, 0x0779},
            {Opcode.CMSG_QUEST_QUERY, 0x02D5},
            {Opcode.CMSG_RANDOMIZE_CHAR_NAME, 0x0B1C},
            {Opcode.CMSG_READ_ITEM, 0x0D00},
            {Opcode.CMSG_READY_FOR_ACCOUNT_DATA_TIMES, 0x031C},
            {Opcode.CMSG_REALM_NAME_QUERY, 0x1A16},
            {Opcode.CMSG_REDIRECT_AUTH_PROOF, 0x0F49},
            {Opcode.CMSG_REQUEST_PARTY_MEMBER_STATS, 0x0806},
            {Opcode.CMSG_RESET_FACTION_CHEAT, 0x10B6},
            {Opcode.CMSG_SEND_MAIL, 0x1DBA},
            {Opcode.CMSG_SET_RAID_DIFFICULTY, 0x1093},
            {Opcode.CMSG_SET_SELECTION, 0x0740},
            {Opcode.CMSG_TEXT_EMOTE, 0x07E9},
            {Opcode.CMSG_TRAINER_LIST, 0x034B},
            {Opcode.CMSG_TIME_SYNC_RESP, 0x01DB | 0x10000},
            {Opcode.CMSG_VIOLENCE_LEVEL, 0x0040},
            {Opcode.CMSG_UPDATE_ACCOUNT_DATA, 0x0068},
            {Opcode.CMSG_WARDEN_DATA, 0x1816},
            {Opcode.CMSG_WHO, 0x18A3},
            {Opcode.CMSG_WORLD_STATE_UI_TIMER_UPDATE, 0x15AB},

            {Opcode.MSG_MOVE_FALL_LAND, 0x08FA},
            {Opcode.MSG_MOVE_HEARTBEAT, 0x01F2},
            {Opcode.MSG_MOVE_JUMP, 0x1153},
            {Opcode.MSG_MOVE_SET_FACING, 0x1050},
            {Opcode.MSG_MOVE_SET_PITCH, 0x017A},
            {Opcode.MSG_MOVE_SET_RUN_MODE, 0x0979},
            {Opcode.MSG_MOVE_SET_WALK_MODE, 0x08D1},
            {Opcode.MSG_MOVE_START_ASCEND, 0x11FA},
            {Opcode.MSG_MOVE_START_BACKWARD, 0x09D8 | 0x10000},
            {Opcode.MSG_MOVE_START_DESCEND, 0x01D1},
            {Opcode.MSG_MOVE_START_FORWARD, 0x095A},
            {Opcode.MSG_MOVE_START_PITCH_DOWN, 0x08D8},
            {Opcode.MSG_MOVE_START_PITCH_UP, 0x00D8 | 0x10000},
            {Opcode.MSG_MOVE_START_STRAFE_LEFT, 0x01F8},
            {Opcode.MSG_MOVE_START_STRAFE_RIGHT, 0x1058},
            {Opcode.MSG_MOVE_START_SWIM, 0x1858},
            {Opcode.MSG_MOVE_START_TURN_LEFT,0x01D0},
            {Opcode.MSG_MOVE_START_TURN_RIGHT, 0x107B},
            {Opcode.MSG_MOVE_STOP, 0x08F1},
            {Opcode.MSG_MOVE_STOP_ASCEND, 0x115A},
            {Opcode.MSG_MOVE_STOP_PITCH, 0x007A},
            {Opcode.MSG_MOVE_STOP_STRAFE, 0x0171},
            {Opcode.MSG_MOVE_STOP_SWIM, 0x0950},
            {Opcode.MSG_MOVE_STOP_TURN, 0x1170},
            {Opcode.MSG_MOVE_WORLDPORT_ACK, 0x1FAD},

            {Opcode.SMSG_ACCOUNT_DATA_TIMES, 0x162B},
            {Opcode.SMSG_ACTION_BUTTONS, 0x081A},
            {Opcode.SMSG_ADDON_INFO, 0x160A},
            {Opcode.SMSG_ALL_ACHIEVEMENT_DATA_ACCOUNT, 0x0A9E},
            {Opcode.SMSG_ALL_ACHIEVEMENT_DATA_PLAYER, 0x180A},
            {Opcode.SMSG_ARENA_SEASON_WORLD_STATE, 0x069B},
            {Opcode.SMSG_ATTACKERSTATEUPDATE, 0x06AA},
            {Opcode.SMSG_ATTACKSTART, 0x1A9E},
            {Opcode.SMSG_ATTACKSTOP, 0x12AF},
            {Opcode.SMSG_AUCTION_HELLO, 0x10A7},
            {Opcode.SMSG_AURA_UPDATE, 0x0072},
            {Opcode.SMSG_AUTH_CHALLENGE, 0x0949},
            {Opcode.SMSG_AUTH_RESPONSE, 0x0ABA},
            {Opcode.SMSG_BATTLE_PET_JOURNAL_LOCK_ACQUIRED, 0x1A0F},
            {Opcode.SMSG_BINDPOINTUPDATE, 0x0E3B},
            {Opcode.SMSG_CAST_FAILED, 0x143A}, 
            {Opcode.SMSG_CHANNEL_START, 0x10F9},
            {Opcode.SMSG_CHANNEL_UPDATE, 0x11D9 | 0x20000},
            {Opcode.SMSG_CHAR_CREATE, 0x1CAA},
            {Opcode.SMSG_CHAR_DELETE, 0x0C9F},
            {Opcode.SMSG_CHAR_ENUM, 0x11C3},
            {Opcode.SMSG_CHAT_PLAYER_NOT_FOUND, 0x1082},
            {Opcode.SMSG_CLIENTCACHE_VERSION, 0x002A},
            {Opcode.SMSG_CONTACT_LIST, 0x1F22},
            {Opcode.SMSG_CORPSE_RECLAIM_DELAY, 0x022A},
            {Opcode.SMSG_CREATURE_QUERY_RESPONSE, 0x048B},
            {Opcode.SMSG_CRITERIA_UPDATE_ACCOUNT, 0x189E},
            {Opcode.SMSG_CRITERIA_UPDATE_PLAYER, 0x0E9B},
            {Opcode.SMSG_DB_REPLY, 0x103B},
            {Opcode.SMSG_DESTROY_OBJECT, 0x14C2},
            {Opcode.SMSG_EMOTE, 0x0987},
            {Opcode.SMSG_EQUIPMENT_SET_LIST, 0x18E2},
            {Opcode.SMSG_FEATURE_SYSTEM_STATUS, 0x16BB},
            {Opcode.SMSG_FORCE_SEND_QUEUED_PACKETS, 0x0969},
            {Opcode.SMSG_GAME_STORE_INGAME_BUY_FAILED, 0x023A},
            {Opcode.SMSG_GAMEOBJECT_QUERY_RESPONSE, 0x06BF},
            {Opcode.SMSG_GOSSIP_MESSAGE, 0x0244},
            {Opcode.SMSG_GOSSIP_POI, 0x0785},
            {Opcode.SMSG_GROUP_DECLINE, 0x17A3},
            {Opcode.SMSG_GROUP_INVITE, 0x0A8F},
            {Opcode.SMSG_GROUP_LIST, 0x0CBB},
            {Opcode.SMSG_GROUP_SET_LEADER, 0x18BF},
            {Opcode.SMSG_GUILD_RANK, 0x0A79},
            {Opcode.SMSG_GUILD_NEWS_TEXT, 0x0B68},
            {Opcode.SMSG_GUILD_QUERY_RESPONSE, 0x1B79},
            {Opcode.SMSG_HIGHEST_THREAT_UPDATE, 0x14AE},
            {Opcode.SMSG_HOTFIX_INFO, 0x1EBA},
            {Opcode.SMSG_ITEM_ENCHANT_TIME_UPDATE, 0x10A2},
            {Opcode.SMSG_ITEM_TIME_UPDATE, 0x18C1},
            {Opcode.SMSG_INIT_CURRENCY, 0x1A8B},
            {Opcode.SMSG_INIT_WORLD_STATES, 0x1560},
            {Opcode.SMSG_INITIAL_SPELLS, 0x045A},
            {Opcode.SMSG_LEARNED_SPELL, 0x129A},
            {Opcode.SMSG_LIST_INVENTORY, 0x1AAE},
            {Opcode.SMSG_LOGIN_SETTIMESPEED, 0x082B},
            {Opcode.SMSG_LOGIN_VERIFY_WORLD, 0x1C0F},
            {Opcode.SMSG_LOGOUT_CANCEL_ACK, 0x0AAF},
            {Opcode.SMSG_LOGOUT_COMPLETE, 0x142F},
            {Opcode.SMSG_LOGOUT_RESPONSE, 0x008F},
            {Opcode.SMSG_MAIL_LIST_RESULT, 0x1C0B},
            {Opcode.SMSG_MESSAGECHAT, 0x1A9A},
            {Opcode.SMSG_MONSTER_MOVE, 0x1A07},
            {Opcode.SMSG_MOTD, 0x183B},
            {Opcode.SMSG_MOVE_ROOT, 0x15AE},
            {Opcode.SMSG_MOVE_UNROOT, 0x1FAE},
            {Opcode.SMSG_MOVE_SET_ACTIVE_MOVER, 0x0C6D},
            {Opcode.SMSG_MOVE_SET_FLIGHT_BACK_SPEED, 0x0319},
            {Opcode.SMSG_MOVE_SET_RUN_BACK_SPEED, 0x0A83},
            {Opcode.SMSG_MOVE_SET_SWIM_BACK_SPEED, 0x0962},
            {Opcode.SMSG_MOVE_SET_SWIM_SPEED, 0x0817},
            {Opcode.SMSG_NAME_QUERY_RESPONSE, 0x169B},
            {Opcode.SMSG_NEW_WORLD, 0x1C3B},
            {Opcode.SMSG_NPC_TEXT_UPDATE, 0x140A},
            {Opcode.SMSG_REDIRECT_CLIENT, 0x1149},
            {Opcode.SMSG_PAGE_TEXT_QUERY_RESPONSE, 0x081E},
            {Opcode.SMSG_PARTY_COMMAND_RESULT, 0x0F86},
            {Opcode.SMSG_PARTY_MEMBER_STATS, 0x0A9A},
            {Opcode.SMSG_PERIODICAURALOG, 0x0CF2},
            {Opcode.SMSG_PET_NAME_QUERY_RESPONSE, 0x0ABE},
            {Opcode.SMSG_PET_SPELLS, 0x095A | 0x20000},
            {Opcode.SMSG_PLAYER_MOVE, 0x1A32},
            {Opcode.SMSG_PLAYERBOUND, 0x1B60},
            {Opcode.SMSG_PONG, 0x1969},
            {Opcode.SMSG_POWER_UPDATE, 0x109F},
            {Opcode.SMSG_QUERY_TIME_RESPONSE, 0x100F},
            {Opcode.SMSG_QUEST_POI_QUERY_RESPONSE, 0x067F},
            {Opcode.SMSG_QUESTGIVER_OFFER_REWARD, 0x074F},
            {Opcode.SMSG_QUESTGIVER_QUEST_COMPLETE, 0x0346},
            {Opcode.SMSG_QUESTGIVER_QUEST_DETAILS, 0x134C},
            {Opcode.SMSG_QUESTGIVER_QUEST_LIST, 0x02D4},
            {Opcode.SMSG_QUESTGIVER_REQUEST_ITEMS, 0x0277},
            {Opcode.SMSG_QUESTGIVER_STATUS, 0x1275},
            {Opcode.SMSG_QUESTGIVER_STATUS_MULTIPLE, 0x06CE},
            {Opcode.SMSG_QUESTUPDATE_ADD_KILL, 0x1645},
            {Opcode.SMSG_QUEST_QUERY_RESPONSE, 0x0276},
            {Opcode.SMSG_RANDOMIZE_CHAR_NAME, 0x169F},
            {Opcode.SMSG_READ_ITEM_OK, 0x0305},
            {Opcode.SMSG_REALM_QUERY_RESPONSE, 0x063E},
            {Opcode.SMSG_REMOVED_SPELL, 0x14C3},
            {Opcode.SMSG_SEND_MAIL_RESULT, 0x1A9B},
            {Opcode.SMSG_SEND_SERVER_LOCATION, 0x19C1},
            {Opcode.SMSG_SEND_UNLEARN_SPELLS, 0x10F1},
            {Opcode.SMSG_SET_FLAT_SPELL_MODIFIER, 0x10F2},
            {Opcode.SMSG_SET_FORCED_REACTIONS, 0x068F},
            {Opcode.SMSG_SET_PCT_SPELL_MODIFIER, 0x09D3},
            {Opcode.SMSG_SET_PHASE_SHIFT, 0x02A2},
            {Opcode.SMSG_SET_VIGNETTE, 0x0CBE},
            {Opcode.SMSG_SPELLDISPELLOG, 0x0DF9},
            {Opcode.SMSG_SPELLENERGIZELOG, 0x0D79},
            {Opcode.SMSG_SPELLLOGEXECUTE, 0x00D8},
            {Opcode.SMSG_SPELLHEALLOG, 0x09FB | 0x20000},
            {Opcode.SMSG_SPELLNONMELEEDAMAGELOG, 0x1450 | 0x20000},
            {Opcode.SMSG_SPELL_FAILED_OTHER, 0x040B},
            {Opcode.SMSG_SPELL_FAILURE, 0x04AF},
            {Opcode.SMSG_SPELL_GO, 0x09D8},
            {Opcode.SMSG_SPELL_START, 0x107A | 0x20000},
            {Opcode.SMSG_STANDSTATE_UPDATE, 0x1C12},
            {Opcode.SMSG_SUSPEND_COMMS, 0x1D48},
            {Opcode.SMSG_TALENTS_INFO, 0x0A9B},
            {Opcode.SMSG_TEXT_EMOTE, 0x02E | 0x20000},
            {Opcode.SMSG_THREAT_CLEAR, 0x180B},
            {Opcode.SMSG_THREAT_REMOVE, 0x1960},
            {Opcode.SMSG_THREAT_UPDATE, 0x0632},
            {Opcode.SMSG_TIME_SYNC_REQ, 0x1A8F},
            {Opcode.SMSG_TRANSFER_PENDING, 0x061B},
            {Opcode.SMSG_TRAINER_LIST, 0x189F},
            {Opcode.SMSG_TUTORIAL_FLAGS, 0x1B90},
            {Opcode.SMSG_UPDATE_ACCOUNT_DATA, 0x0AAE},
            {Opcode.SMSG_UPDATE_OBJECT, 0x1792},
            {Opcode.SMSG_WARDEN_DATA, 0x14EB},
            {Opcode.SMSG_WEATHER, 0x06AB},
            {Opcode.SMSG_WHO, 0x161B},
            {Opcode.SMSG_WORLD_SERVER_INFO, 0x0082},
            {Opcode.SMSG_WORLD_STATE_UI_TIMER_UPDATE, 0x0027},
            {Opcode.CMSG_REQUEST_ACCOUNT_DATA, 0x1D8A},
            {Opcode.CMSG_SET_ACTION_BUTTON, 0x1F8C},
            {Opcode.SMSG_LOG_XPGAIN, 0x1E9A}
        };
    }
}
