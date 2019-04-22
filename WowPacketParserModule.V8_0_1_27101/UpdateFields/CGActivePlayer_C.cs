using WowPacketParser.Parsing;

namespace WowPacketParserModule.V8_0_1_27101.UpdateFields
{
    public class CGActivePlayer_C
    {
        // @TODO: implement me

        [UFArray(195)]
        public UpdateField ACTIVE_PLAYER_FIELD_INV_SLOT_HEAD = new UpdateField(UpdateFieldType.Guid, 0x0, 101);

        public UpdateField ACTIVE_PLAYER_FIELD_194 = new UpdateField(UpdateFieldType.Guid, 0x0, 22);
        public UpdateField ACTIVE_PLAYER_FIELD_195 = new UpdateField(UpdateFieldType.Guid, 0x0, 23);

        [UFDynamicCounter]
        public UpdateField ACTIVE_PLAYER_DYNAMIC_COUNT_1 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        public UpdateField ACTIVE_PLAYER_FIELD_197 = new UpdateField(UpdateFieldType.Ulong, 0x0, 24);
        public UpdateField ACTIVE_PLAYER_FIELD_198 = new UpdateField(UpdateFieldType.Int, 0x0, 25);
        public UpdateField ACTIVE_PLAYER_FIELD_199 = new UpdateField(UpdateFieldType.Int, 0x0, 26);
        public UpdateField ACTIVE_PLAYER_FIELD_200 = new UpdateField(UpdateFieldType.Int, 0x0, 27);

        public class ActivePlayerUnknown : UpdateFieldStructure
        {
            public UpdateField ACTIVE_PLAYER_FIELD_201 = new UpdateField(UpdateFieldType.Ushort, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_FIELD_202 = new UpdateField(UpdateFieldType.Ushort, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_FIELD_203 = new UpdateField(UpdateFieldType.Ushort, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_FIELD_204 = new UpdateField(UpdateFieldType.Ushort, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_FIELD_205 = new UpdateField(UpdateFieldType.Ushort, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_FIELD_206 = new UpdateField(UpdateFieldType.Short, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_FIELD_207 = new UpdateField(UpdateFieldType.Ushort, 0x0, 0);

            public ActivePlayerUnknown(int requiredCreationFlag, int updateBit, int fieldNum) : base(requiredCreationFlag, updateBit, fieldNum) { }
        }
        [UFArray(256)]
        public ActivePlayerUnknown ACTIVE_PLAYER_FIELD_201_1992 = new ActivePlayerUnknown(0x0, 28, 0); // read right after ACTIVE_PLAYER_FIELD_200

        public UpdateField ACTIVE_PLAYER_FIELD_1993 = new UpdateField(UpdateFieldType.Int, 0x0, 29);
        public UpdateField ACTIVE_PLAYER_FIELD_1994 = new UpdateField(UpdateFieldType.Int, 0x0, 30);
        public UpdateField ACTIVE_PLAYER_FIELD_1995 = new UpdateField(UpdateFieldType.Uint, 0x0, 31);

        [UFArray(2)]
        public UpdateField ACTIVE_PLAYER_FIELD_1996 = new UpdateField(UpdateFieldType.Uint, 0x0, 297);

        public UpdateField ACTIVE_PLAYER_FIELD_1998 = new UpdateField(UpdateFieldType.Float, 0x0, 32); 
        public UpdateField ACTIVE_PLAYER_FIELD_1999 = new UpdateField(UpdateFieldType.Float, 0x0, 33);
        public UpdateField ACTIVE_PLAYER_FIELD_2000 = new UpdateField(UpdateFieldType.Float, 0x0, 35); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2001 = new UpdateField(UpdateFieldType.Float, 0x0, 36); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2002 = new UpdateField(UpdateFieldType.Float, 0x0, 37); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2003 = new UpdateField(UpdateFieldType.Float, 0x0, 38); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2004 = new UpdateField(UpdateFieldType.Float, 0x0, 39); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2005 = new UpdateField(UpdateFieldType.Float, 0x0, 40); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2006 = new UpdateField(UpdateFieldType.Float, 0x0, 41); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2007 = new UpdateField(UpdateFieldType.Float, 0x0, 42); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2008 = new UpdateField(UpdateFieldType.Float, 0x0, 43); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2009 = new UpdateField(UpdateFieldType.Float, 0x0, 44); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2010 = new UpdateField(UpdateFieldType.Float, 0x0, 45); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2011 = new UpdateField(UpdateFieldType.Int, 0x0, 46);   // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2012 = new UpdateField(UpdateFieldType.Float, 0x0, 47); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2013 = new UpdateField(UpdateFieldType.Float, 0x0, 48); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2014 = new UpdateField(UpdateFieldType.Float, 0x0, 49); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2015 = new UpdateField(UpdateFieldType.Float, 0x0, 50); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2016 = new UpdateField(UpdateFieldType.Float, 0x0, 51); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2017 = new UpdateField(UpdateFieldType.Int, 0x0, 52);   // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2018 = new UpdateField(UpdateFieldType.Float, 0x0, 53); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2019 = new UpdateField(UpdateFieldType.Float, 0x0, 54); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2020 = new UpdateField(UpdateFieldType.Float, 0x0, 55); // also requires bit 34

        [UFArray(160)]
        public UpdateField ACTIVE_PLAYER_FIELD_2021 = new UpdateField(UpdateFieldType.Ulong, 0x0, 300);

        public class ActivPlayerUnknown2 : UpdateFieldStructure
        {
            public UpdateField ACTIVE_PLAYER_FIELD_2179 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_FIELD_2180 = new UpdateField(UpdateFieldType.Byte, 0x0, 0);

            public ActivPlayerUnknown2(int requiredCreationFlag, int updateBit, int fieldNum) : base(requiredCreationFlag, updateBit, fieldNum) { }
        }
        [UFArray(2)]
        public ActivPlayerUnknown2 ACTIVE_PLAYER_FIELD_2179_2182 = new ActivPlayerUnknown2(0x0, 461, 0);

        public class ActivPlayerUnknown3 : UpdateFieldStructure
        {
            public UpdateField ACTIVE_PLAYER_FIELD_2183 = new UpdateField(UpdateFieldType.Int, 0x0, 465);
            public UpdateField ACTIVE_PLAYER_FIELD_2184 = new UpdateField(UpdateFieldType.Int, 0x0, 472);
            public UpdateField ACTIVE_PLAYER_FIELD_2185 = new UpdateField(UpdateFieldType.Float, 0x0, 479);

            public ActivPlayerUnknown3(int requiredCreationFlag, int updateBit, int fieldNum) : base(requiredCreationFlag, updateBit, fieldNum) { }
        }
        [UFArray(7)]
        public ActivPlayerUnknown3 ACTIVE_PLAYER_FIELD_2183_2203 = new ActivPlayerUnknown3(0x0, 464, 0);

        public UpdateField ACTIVE_PLAYER_FIELD_2204 = new UpdateField(UpdateFieldType.Int, 0x0, 56); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2205 = new UpdateField(UpdateFieldType.Float, 0x0, 57); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2206 = new UpdateField(UpdateFieldType.Float, 0x0, 58); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2207 = new UpdateField(UpdateFieldType.Float, 0x0, 59); // also requires bit 34

        public class ActivPlayerUnknown4 : UpdateFieldStructure
        {
            public UpdateField ACTIVE_PLAYER_FIELD_2208 = new UpdateField(UpdateFieldType.Float, 0x0, 487);
            public UpdateField ACTIVE_PLAYER_FIELD_2209 = new UpdateField(UpdateFieldType.Float, 0x0, 490);

            public ActivPlayerUnknown4(int requiredCreationFlag, int updateBit, int fieldNum) : base(requiredCreationFlag, updateBit, fieldNum) { }
        }
        [UFArray(3)]
        public ActivPlayerUnknown4 ACTIVE_PLAYER_FIELD_2208_2213 = new ActivPlayerUnknown4(0x0, 486, 0);

        public UpdateField ACTIVE_PLAYER_FIELD_2214 = new UpdateField(UpdateFieldType.Float, 0x0, 60); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2215 = new UpdateField(UpdateFieldType.Float, 0x0, 61); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2216 = new UpdateField(UpdateFieldType.Float, 0x0, 62); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2217 = new UpdateField(UpdateFieldType.Float, 0x0, 63); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2218 = new UpdateField(UpdateFieldType.Int, 0x0, 64); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2219 = new UpdateField(UpdateFieldType.Int, 0x0, 65); // also requires bit 34
        public UpdateField ACTIVE_PLAYER_FIELD_2220 = new UpdateField(UpdateFieldType.Uint, 0x0, 67); // requires bit 66
        public UpdateField ACTIVE_PLAYER_FIELD_2221 = new UpdateField(UpdateFieldType.Byte, 0x0, 68);
        public UpdateField ACTIVE_PLAYER_FIELD_2222 = new UpdateField(UpdateFieldType.Byte, 0x0, 69);
        public UpdateField ACTIVE_PLAYER_FIELD_2223 = new UpdateField(UpdateFieldType.Byte, 0x0, 70);
        public UpdateField ACTIVE_PLAYER_FIELD_2224 = new UpdateField(UpdateFieldType.Byte, 0x0, 71);
        public UpdateField ACTIVE_PLAYER_FIELD_2225 = new UpdateField(UpdateFieldType.Uint, 0x0, 72);

        public class ActivPlayerUnknown5 : UpdateFieldStructure
        {
            public UpdateField ACTIVE_PLAYER_FIELD_2226 = new UpdateField(UpdateFieldType.Uint, 0x0, 494);
            public UpdateField ACTIVE_PLAYER_FIELD_2227 = new UpdateField(UpdateFieldType.Uint, 0x0, 506);

            public ActivPlayerUnknown5(int requiredCreationFlag, int updateBit, int fieldNum) : base(requiredCreationFlag, updateBit, fieldNum) { }
        }
        [UFArray(12)]
        public ActivPlayerUnknown5 ACTIVE_PLAYER_FIELD_2226_2249 = new ActivPlayerUnknown5(0x0, 493, 0);

        public UpdateField ACTIVE_PLAYER_FIELD_2250 = new UpdateField(UpdateFieldType.Ushort, 0x0, 73);
        public UpdateField ACTIVE_PLAYER_FIELD_2251 = new UpdateField(UpdateFieldType.Ushort, 0x0, 74);
        public UpdateField ACTIVE_PLAYER_FIELD_2252 = new UpdateField(UpdateFieldType.Uint, 0x0, 75);
        public UpdateField ACTIVE_PLAYER_FIELD_2253 = new UpdateField(UpdateFieldType.Int, 0x0, 76);

        [UFArray(32)]
        public UpdateField ACTIVE_PLAYER_FIELD_2254 = new UpdateField(UpdateFieldType.Int, 0x0, 518);

        public UpdateField ACTIVE_PLAYER_FIELD_2285 = new UpdateField(UpdateFieldType.Int, 0x0, 77);
        public UpdateField ACTIVE_PLAYER_FIELD_2286 = new UpdateField(UpdateFieldType.Int, 0x0, 78);
        public UpdateField ACTIVE_PLAYER_FIELD_2287 = new UpdateField(UpdateFieldType.Int, 0x0, 79);

        [UFArray(4)]
        public UpdateField ACTIVE_PLAYER_FIELD_2288 = new UpdateField(UpdateFieldType.Uint, 0x0, 558);

        public UpdateField ACTIVE_PLAYER_FIELD_2291 = new UpdateField(UpdateFieldType.Int, 0x0, 80);

        [UFArray(2)]
        public UpdateField ACTIVE_PLAYER_FIELD_2292 = new UpdateField(UpdateFieldType.Int, 0x0, 563);

        public UpdateField ACTIVE_PLAYER_FIELD_2294 = new UpdateField(UpdateFieldType.Float, 0x0, 81);
        public UpdateField ACTIVE_PLAYER_FIELD_2295 = new UpdateField(UpdateFieldType.Float, 0x0, 82);
        public UpdateField ACTIVE_PLAYER_FIELD_2296 = new UpdateField(UpdateFieldType.Int, 0x0, 83);
        public UpdateField ACTIVE_PLAYER_FIELD_2297 = new UpdateField(UpdateFieldType.Float, 0x0, 84);
        public UpdateField ACTIVE_PLAYER_FIELD_2298 = new UpdateField(UpdateFieldType.Byte, 0x0, 85);
        public UpdateField ACTIVE_PLAYER_FIELD_2299 = new UpdateField(UpdateFieldType.Byte, 0x0, 86);
        public UpdateField ACTIVE_PLAYER_FIELD_2300 = new UpdateField(UpdateFieldType.Byte, 0x0, 87);
        public UpdateField ACTIVE_PLAYER_FIELD_2301 = new UpdateField(UpdateFieldType.Int, 0x0, 88);
        public UpdateField ACTIVE_PLAYER_FIELD_2302 = new UpdateField(UpdateFieldType.Int, 0x0, 89);
        public UpdateField ACTIVE_PLAYER_FIELD_2303 = new UpdateField(UpdateFieldType.Ushort, 0x0, 90);
        public UpdateField ACTIVE_PLAYER_FIELD_2304 = new UpdateField(UpdateFieldType.Uint, 0x0, 91);

        [UFArray(4)]
        public UpdateField ACTIVE_PLAYER_FIELD_2305 = new UpdateField(UpdateFieldType.Uint, 0x0, 566);

        [UFArray(7)]
        public UpdateField ACTIVE_PLAYER_FIELD_2309 = new UpdateField(UpdateFieldType.Uint, 0x0, 571);

        [UFArray(875)]
        public UpdateField ACTIVE_PLAYER_FIELD_2316 = new UpdateField(UpdateFieldType.Ulong, 0x0, 579);

        public UpdateField ACTIVE_PLAYER_FIELD_3191 = new UpdateField(UpdateFieldType.Int, 0x0, 92);
        public UpdateField ACTIVE_PLAYER_FIELD_3192 = new UpdateField(UpdateFieldType.Int, 0x0, 93);
        public UpdateField ACTIVE_PLAYER_FIELD_3193 = new UpdateField(UpdateFieldType.Int, 0x0, 94);
        public UpdateField ACTIVE_PLAYER_FIELD_3194 = new UpdateField(UpdateFieldType.Int, 0x0, 95);
        public UpdateField ACTIVE_PLAYER_FIELD_3195 = new UpdateField(UpdateFieldType.Int, 0x0, 96);
        public UpdateField ACTIVE_PLAYER_FIELD_3196 = new UpdateField(UpdateFieldType.Int, 0x0, 97);
        public UpdateField ACTIVE_PLAYER_FIELD_3197 = new UpdateField(UpdateFieldType.Int, 0x0, 99); // also required bit 98
        public UpdateField ACTIVE_PLAYER_FIELD_3198 = new UpdateField(UpdateFieldType.Byte, 0x0, 100);

        [UFDynamicCounter]
        public UpdateField ACTIVE_PLAYER_DYNAMIC_COUNT_2 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        [UFDynamicCounter]
        public UpdateField ACTIVE_PLAYER_DYNAMIC_COUNT_3 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        [UFDynamicCounter]
        public UpdateField ACTIVE_PLAYER_DYNAMIC_COUNT_4 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        [UFDynamicCounter]
        public UpdateField ACTIVE_PLAYER_DYNAMIC_COUNT_5 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        [UFDynamicCounter]
        public UpdateField ACTIVE_PLAYER_DYNAMIC_COUNT_6 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        [UFDynamicCounter]
        public UpdateField ACTIVE_PLAYER_DYNAMIC_COUNT_7 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        [UFDynamicCounter]
        public UpdateField ACTIVE_PLAYER_DYNAMIC_COUNT_8 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        [UFDynamicCounter]
        public UpdateField ACTIVE_PLAYER_DYNAMIC_COUNT_9 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        [UFDynamicCounter]
        public UpdateField ACTIVE_PLAYER_DYNAMIC_COUNT_10 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        [UFDynamicCounter]
        public UpdateField ACTIVE_PLAYER_DYNAMIC_COUNT_11 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        [UFDynamicCounter]
        public UpdateField ACTIVE_PLAYER_DYNAMIC_COUNT_12 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        [UFDynamicCounter]
        public UpdateField ACTIVE_PLAYER_DYNAMIC_COUNT_13 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        [UFDynamicCounter]
        public UpdateField ACTIVE_PLAYER_DYNAMIC_COUNT_14 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        [UFDynamicCounter]
        public UpdateField ACTIVE_PLAYER_DYNAMIC_COUNT_15 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        [UFDynamicCounter]
        public UpdateField ACTIVE_PLAYER_DYNAMIC_COUNT_16 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);

        [UFDynamicField] // ACTIVE_PLAYER_DYNAMIC_COUNT_16
        public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_1 = new UpdateField(UpdateFieldType.Ushort, 0x0, 20);

        [UFDynamicField] // ACTIVE_PLAYER_DYNAMIC_COUNT_1
        public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_2 = new UpdateField(UpdateFieldType.Ulong, 0x0, 5);

        [UFDynamicField] // ACTIVE_PLAYER_DYNAMIC_COUNT_2
        public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_3 = new UpdateField(UpdateFieldType.Ushort, 0x0, 6);

        [UFDynamicField] // ACTIVE_PLAYER_DYNAMIC_COUNT_3
        public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_4 = new UpdateField(UpdateFieldType.Uint, 0x0, 7);

        [UFDynamicField] // ACTIVE_PLAYER_DYNAMIC_COUNT_4
        public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_5 = new UpdateField(UpdateFieldType.Int, 0x0, 8);

        [UFDynamicField] // ACTIVE_PLAYER_DYNAMIC_COUNT_5
        public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_6 = new UpdateField(UpdateFieldType.Int, 0x0, 9);

        [UFDynamicField] // ACTIVE_PLAYER_DYNAMIC_COUNT_6
        public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_7 = new UpdateField(UpdateFieldType.Int, 0x0, 10);

        [UFDynamicField] // ACTIVE_PLAYER_DYNAMIC_COUNT_7
        public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_8 = new UpdateField(UpdateFieldType.Int, 0x0, 11);

        [UFDynamicField] // ACTIVE_PLAYER_DYNAMIC_COUNT_8
        public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_9 = new UpdateField(UpdateFieldType.Int, 0x0, 12);

        [UFDynamicField] // ACTIVE_PLAYER_DYNAMIC_COUNT_9
        public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_10 = new UpdateField(UpdateFieldType.Uint, 0x0, 13);

        [UFDynamicField] // ACTIVE_PLAYER_DYNAMIC_COUNT_10
        public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_11 = new UpdateField(UpdateFieldType.Uint, 0x0, 14);

        [UFDynamicField] // ACTIVE_PLAYER_DYNAMIC_COUNT_11
        public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_12 = new UpdateField(UpdateFieldType.Int, 0x0, 15);

        [UFDynamicField] // ACTIVE_PLAYER_DYNAMIC_COUNT_12
        public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_13 = new UpdateField(UpdateFieldType.Int, 0x0, 16);

        public class ActivPlayerDynamicUnknown14 : UpdateFieldStructure
        {
            public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_14_INT_1 = new UpdateField(UpdateFieldType.Int, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_14_FLOAT = new UpdateField(UpdateFieldType.Float, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_14_INT_2 = new UpdateField(UpdateFieldType.Int, 0x0, 0);

            public ActivPlayerDynamicUnknown14(int requiredCreationFlag, int updateBit, int fieldNum) : base(requiredCreationFlag, updateBit, fieldNum) { }
        }
        [UFDynamicField] // ACTIVE_PLAYER_DYNAMIC_COUNT_14
        public ActivPlayerDynamicUnknown14 ACTIVE_PLAYER_DYNAMIC_UNKNOWN_14 = new ActivPlayerDynamicUnknown14(0x0, 18, 0);

        public class ActivPlayerDynamicUnknown15 : UpdateFieldStructure
        {
            public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_14_INT_1 = new UpdateField(UpdateFieldType.Int, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_14_INT_2 = new UpdateField(UpdateFieldType.Int, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_14_INT_3 = new UpdateField(UpdateFieldType.Int, 0x0, 0);

            public ActivPlayerDynamicUnknown15(int requiredCreationFlag, int updateBit, int fieldNum) : base(requiredCreationFlag, updateBit, fieldNum) { }
        }
        [UFDynamicField] // ACTIVE_PLAYER_DYNAMIC_COUNT_15
        public ActivPlayerDynamicUnknown15 ACTIVE_PLAYER_DYNAMIC_UNKNOWN_15 = new ActivPlayerDynamicUnknown15(0x0, 19, 0);

        public class ActivePlayerUnknown6 : UpdateFieldStructure
        {
            public UpdateField ACTIVE_PLAYER_UNKNOWN_6_UINT_1 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_UNKNOWN_6_UINT_2 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_UNKNOWN_6_UINT_3 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_UNKNOWN_6_UINT_4 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_UNKNOWN_6_UINT_5 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_UNKNOWN_6_UINT_6 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_UNKNOWN_6_UINT_7 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_UNKNOWN_6_UINT_8 = new UpdateField(UpdateFieldType.Uint, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_UNKNOWN_6_BYTE_1 = new UpdateField(UpdateFieldType.Byte, 0x0, 0);

            public ActivePlayerUnknown6(int requiredCreationFlag, int updateBit, int fieldNum) : base(requiredCreationFlag, updateBit, fieldNum) { }
        }
        [UFArray(6)]
        public ActivePlayerUnknown6 ACTIVE_PLAYER_UNKNOWN_6 = new ActivePlayerUnknown6(0x0, 0, 551);

        [UFBits(1)]
        public UpdateField ACTIVE_PLAYER_FIELD_3199 = new UpdateField(UpdateFieldType.Bits, 0x0, 1);
        [UFBits(1)]
        public UpdateField ACTIVE_PLAYER_FIELD_3200 = new UpdateField(UpdateFieldType.Bits, 0x0, 2);
        [UFBits(1)]
        public UpdateField ACTIVE_PLAYER_FIELD_3201 = new UpdateField(UpdateFieldType.Bits, 0x0, 3);
        [UFBits(1)]
        public UpdateField ACTIVE_PLAYER_FIELD_3202 = new UpdateField(UpdateFieldType.Bits, 0x0, 4);

        public class ActivePlayerDynamicUnknown16 : UpdateFieldStructure
        {
            public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_14_UINT_1 = new UpdateField(UpdateFieldType.Int, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_14_UINT_2 = new UpdateField(UpdateFieldType.Int, 0x0, 0);
            public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_14_UINT_3 = new UpdateField(UpdateFieldType.Int, 0x0, 0);
            [UFBits(5)]
            public UpdateField ACTIVE_PLAYER_DYNAMIC_UNKNOWN_14_BYTE_1 = new UpdateField(UpdateFieldType.Bits, 0x0, 0);

            public ActivePlayerDynamicUnknown16(int requiredCreationFlag, int updateBit, int fieldNum) : base(requiredCreationFlag, updateBit, fieldNum) { }
        }
        [UFDynamicField] // ACTIVE_PLAYER_DYNAMIC_COUNT_13
        public ActivePlayerDynamicUnknown16 ACTIVE_PLAYER_DYNAMIC_UNKNOWN_16 = new ActivePlayerDynamicUnknown16(0x0, 17, 0); 
    }
}
