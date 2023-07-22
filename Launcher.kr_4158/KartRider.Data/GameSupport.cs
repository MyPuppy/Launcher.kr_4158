using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KartRider.IO;
using System.Net;
using Set_Data;

namespace KartRider
{
    public static class GameSupport
    {
        public static void PcFirstMessage()
        {
            uint first_val = 2919676295;
            uint second_val = 263300380;
            using (OutPacket outPacket = new OutPacket("PcFirstMessage"))
            {
                outPacket.WriteUShort(SessionGroup.usLocale);
                outPacket.WriteUShort(1);
                outPacket.WriteUShort(Program.Version);
                outPacket.WriteString("http://kart.dn.nexoncdn.co.kr/patch");
                outPacket.WriteUInt(first_val);
                outPacket.WriteUInt(second_val);
                outPacket.WriteByte(SessionGroup.nClientLoc);
                outPacket.WriteString("QyvKvO60jogWDupzJ7gm0kRQdooFjWRjSjlq0gu/x2k=");
                outPacket.WriteHexString("00 00 00 00 00 00 00 00 0F 00 00 00 00 00 00 00 00 2E 31 2E 31 37 2E 36 00 00 00 00 00 00 00");
                outPacket.WriteString("GXQstj1A95XiHvjrOGuPkzdyL+7qxETl/cPlUZk2KA4=");
                RouterListener.MySession.Client.Send(outPacket);
            }
            RouterListener.MySession.Client._RIV = first_val ^ second_val;
            RouterListener.MySession.Client._SIV = first_val ^ second_val;
        }

        public static void OnDisconnect()
        {
            RouterListener.MySession.Client.Disconnect();
        }

        public static void SpRpLotteryPacket()
        {
            using (OutPacket outPacket = new OutPacket("SpRpLotteryPacket"))
            {
                outPacket.WriteHexString("05 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00");
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrGetGameOption()
        {
            using (OutPacket outPacket = new OutPacket("PrGetGameOption"))
            {
                outPacket.WriteFloat(SetGameOption.Set_BGM);
                outPacket.WriteFloat(SetGameOption.Set_Sound);
                outPacket.WriteByte(SetGameOption.Old_BGM);
                outPacket.WriteByte(SetGameOption.Sound_effect);
                outPacket.WriteByte(SetGameOption.Full_screen);
                outPacket.WriteByte(SetGameOption.Unk1);
                outPacket.WriteByte(SetGameOption.Unk2);
                outPacket.WriteByte(SetGameOption.Unk3);
                outPacket.WriteByte(SetGameOption.Unk4);
                outPacket.WriteByte(SetGameOption.Unk5);
                outPacket.WriteByte(SetGameOption.Unk6);
                outPacket.WriteByte(SetGameOption.Unk7);
                outPacket.WriteByte(SetGameOption.Unk8);
                outPacket.WriteByte(SetGameOption.Unk9);
                outPacket.WriteByte(SetGameOption.Unk10);
                outPacket.WriteByte(SetGameOption.Unk11);
                outPacket.WriteByte(SetGameOption.BGM_Check);
                outPacket.WriteByte(SetGameOption.Sound_Check);
                outPacket.WriteByte(SetGameOption.Unk12);
                outPacket.WriteByte(SetGameOption.Unk13);
                outPacket.WriteBytes(new byte[40]);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void ChRpEnterMyRoomPacket()
        {
            if (GameType.EnterMyRoomType == 0)
            {
                using (OutPacket outPacket = new OutPacket("ChRpEnterMyRoomPacket"))
                {
                    outPacket.WriteString(SetRider.Nickname);
                    outPacket.WriteByte(0);
                    outPacket.WriteShort(SetMyRoom.MyRoom);
                    outPacket.WriteByte(SetMyRoom.UseRoomPwd);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(SetMyRoom.UseItemPwd);
                    outPacket.WriteString(SetMyRoom.RoomPwd);
                    outPacket.WriteString("");
                    outPacket.WriteString(SetMyRoom.ItemPwd);
                    outPacket.WriteShort(SetMyRoom.MyRoomKart1);
                    outPacket.WriteShort(SetMyRoom.MyRoomKart2);
                    RouterListener.MySession.Client.Send(outPacket);
                }
            }
            else
            {
                using (OutPacket outPacket = new OutPacket("ChRpEnterMyRoomPacket"))
                {
                    outPacket.WriteString("");
                    outPacket.WriteByte(GameType.EnterMyRoomType);
                    outPacket.WriteShort(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(1);
                    outPacket.WriteString("");//RoomPwd
                    outPacket.WriteString("");
                    outPacket.WriteString("");//ItemPwd 
                    outPacket.WriteShort(0);
                    outPacket.WriteShort(0);
                    RouterListener.MySession.Client.Send(outPacket);
                }
            }
        }

        public static void RmNotiMyRoomInfoPacket()
        {
            using (OutPacket outPacket = new OutPacket("RmNotiMyRoomInfoPacket"))
            {
                outPacket.WriteShort(SetMyRoom.MyRoom);
                outPacket.WriteByte(SetMyRoom.UseRoomPwd);
                outPacket.WriteByte(0);
                outPacket.WriteByte(SetMyRoom.UseItemPwd);
                outPacket.WriteString(SetMyRoom.RoomPwd);
                outPacket.WriteString("");
                outPacket.WriteString(SetMyRoom.ItemPwd);
                outPacket.WriteShort(SetMyRoom.MyRoomKart1);
                outPacket.WriteShort(SetMyRoom.MyRoomKart2);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrGetRiderInfo()
        {
            using (OutPacket outPacket = new OutPacket("PrGetRiderInfo"))
            {
                outPacket.WriteByte(1);
                outPacket.WriteUInt(SetRider.UserNO);
                outPacket.WriteString(SetRider.UserID);
                outPacket.WriteString(SetRider.Nickname);
                outPacket.WriteHexString("3C 9A 17 43");//2008.02.08
                for (int i = 1; i <= Program.MAX_EQP_P; i++)
                {
                    outPacket.WriteShort(0);
                }
                outPacket.WriteByte(0);
                outPacket.WriteString("");
                outPacket.WriteInt(SetRider.RP);
                outPacket.WriteBytes(new byte[33]);
                outPacket.WriteShort(SetRider.Emblem1);
                outPacket.WriteShort(SetRider.Emblem2);
                outPacket.WriteShort(0);
                outPacket.WriteString(SetRider.RiderIntro);
                outPacket.WriteInt(SetRider.Premium);
                outPacket.WriteByte(1);
                if (SetRider.Premium == 0)
                    outPacket.WriteInt(0);
                else if (SetRider.Premium == 1)
                    outPacket.WriteInt(10000);
                else if (SetRider.Premium == 2)
                    outPacket.WriteInt(30000);
                else if (SetRider.Premium == 3)
                    outPacket.WriteInt(60000);
                else if (SetRider.Premium == 4)
                    outPacket.WriteInt(120000);
                else if (SetRider.Premium == 5)
                    outPacket.WriteInt(200000);
                else
                    outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void ChRequestChStaticReplyPacket()
        {
            using (OutPacket outPacket = new OutPacket("ChRequestChStaticReplyPacket"))
            {
                outPacket.WriteHexString("01 04 02 00 00 53 01 6A AD 5E 0B D6 09 00 00 78 DA A5 55 D9 52 C2 40 10 6C E5 14 C4 80 08 12 D1 28 E2 17 F8 0F 5A C5 83 3E 88 EF 94 4A 3C 4A 40 2B 88 D7 D7 DB 93 90 22 C1 4D 36 81 4A B9 B8 BB DD 73 65 D2 D3 05 B0 55 E1 32 C5 3B 6C 3E 43 DC 72 BD C3 18 97 5C A7 F8 C0 66 9E D7 63 FC E0 06 6F 7C C6 C8 18 3C 78 E1 8D CD CD 35 D7 2F F4 E6 3B 9F 9B 8D 86 F4 30 A1 93 17 E4 2C AD 15 3F 02 DB 5D CF 71 41 EA 03 9E 79 3A E1 3E 6F 69 7D C4 1B 28 34 B4 11 78 A7 F7 44 D9 28 36 B4 FE 82 F0 52 B8 AA CB 21 95 AB B1 45 F7 22 DE AE C6 DA F0 40 15 43 69 29 18 CB 8E A1 B4 13 84 18 FB 84 3C 61 C6 CD C8 BD F4 32 0B 57 2C 9C 75 B5 16 A2 2C EC 87 E3 AB 49 FF DC F3 E8 83 CF 88 87 BB EA AC E4 F7 91 BF 13 D7 79 5D 5D 9F 30 68 6F 3B F0 4A AE E6 C7 BE BD 86 EA D2 B7 D3 6C B9 41 BD E1 95 EB 8C 61 79 FF F7 62 5F EF 7E 1A 92 EF A9 B5 AB 24 F5 FF E5 6F EA 80 BE C5 03 33 A1 C5 70 B1 DA 66 42 FB 61 DA A1 15 9B F4 80 ED E1 90 F6 4B 81 50 17 E0 C8 70 DB C4 71 7B 68 48 6F 0E ED 7E 93 B8 78 BB 56 53 D9 11 7D B7 F1 86 F4 F7 B5 14 D4 71 53 D9 1D D1 84 93 66 44 10 51 B5 EB D4 B5 51 FB D0 53 33 02 1A 2F 16 DD 74 34 3F C7 33 09 EC 93 1B 87 A1 CC F8 77 C5 0C 86 DC 0F DC 64 83 FA 20 82 B5 01 BD 5A 67 20 53 00 E9 E4 B0 20 A4 4D E8 85 3E 2B C0 0C D6 95 FB 9C 98 C9 62 5D D1 17 31 A2 AD F8 91 B7 25 A0 3C E2 15 BC 24 A0 02 92 E8 78 59 A0 45 24 51 73 11 2D 9A 4E 37 6B 8A 42 2A 43 3F 08 24 23 BA D0 8F 83 1D 01 56 90 7E 28 88 69 B2 93 8D 06 29 08 19 CB 03 42 C8 BC 4B 32 26 44 33 89 4F 32 2C E4 BB 21 3E F9 77 DD 11 42 1D AB 7D A6 5D 21 EF 61 95 89 21 45 67 03 AC 26 D7 6D 21 FF 01 15 34 AD 6B");
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrDynamicCommand()
        {
            using (OutPacket outPacket = new OutPacket("PrDynamicCommand"))
            {
                outPacket.WriteByte(0);
                outPacket.WriteInt(0);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrQuestUX2ndPacket()
        {
            int NormalQuest = 15;
            using (OutPacket outPacket = new OutPacket("PrQuestUX2ndPacket"))
            {
                outPacket.WriteInt(NormalQuest);
                for (int i = 231; i <= 245; i++)
                {
                    outPacket.WriteInt(i);
                    outPacket.WriteInt(i);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                }
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrLogin()
        {
            using (OutPacket outPacket = new OutPacket("PrLogin"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteHexString(Program.DataTime);
                outPacket.WriteUInt(SetRider.UserNO);
                outPacket.WriteString(SetRider.UserID);
                outPacket.WriteByte(255);
                outPacket.WriteByte(0);
                outPacket.WriteByte(0);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                outPacket.WriteInt(1415577599);
                outPacket.WriteUInt(SetRider.pmap);
                for (int i = 0; i < 9; i++)
                {
                    outPacket.WriteInt(0);
                }
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteEndPoint(IPAddress.Parse(RouterListener.forceConnect), 39311);
                outPacket.WriteEndPoint(IPAddress.Parse(RouterListener.forceConnect), 39312);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                outPacket.WriteString("content");
                outPacket.WriteInt(0);
                outPacket.WriteInt(1);
                outPacket.WriteString("cc");
                outPacket.WriteString(SessionGroup.Service);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }
    }
}
