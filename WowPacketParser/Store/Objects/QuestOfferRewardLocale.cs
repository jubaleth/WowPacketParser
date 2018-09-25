﻿using WowPacketParser.Loading;
using WowPacketParser.Misc;
using WowPacketParser.SQL;

namespace WowPacketParser.Store.Objects
{
    [DBTableName("quest_offer_reward_locale")]
    public sealed class QuestOfferRewardLocale : IDataModel
    {
        [DBFieldName("ID", true)]
        public uint? ID;

        [DBFieldName("locale", true)]
        public string Locale = BinaryPacketReader.GetClientLocale();

        [DBFieldName("RewardText")]
        public string RewardText;

        [DBFieldName("VerifiedBuild")]
        public int? VerifiedBuild = ClientVersion.BuildInt;
    }
}