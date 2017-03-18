namespace WowPacketParser.Messages.UserClient
{
    public unsafe struct UserClientBattlePetSetBattleSlot
    {
        public ulong BattlePetGUID;
        public byte SlotIndex;

        [Parser(Opcode.CMSG_BATTLE_PET_SET_BATTLE_SLOT)]
        public static void HandleBattlePetSetBattleSlot(Packet packet)
        {
            packet.ReadPackedGuid128("BattlePetGUID");
            packet.ReadByte("SlotIndex");
        }
    }
}
