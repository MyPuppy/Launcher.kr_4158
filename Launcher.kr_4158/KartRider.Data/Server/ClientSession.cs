using KartRider.Common.Network;
using KartRider.Common.Utilities;
using KartRider.IO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;
using KartRider_PacketName;
using KartRider_TrackName;
using ExcData;
using Set_Data;
using RiderData;

namespace KartRider
{
	public class ClientSession : Session
	{
		public SessionGroup Parent
		{
			get;
			set;
		}

		public ClientSession(SessionGroup parent, System.Net.Sockets.Socket socket) : base(socket)
		{
			this.Parent = parent;
		}

		public override void OnDisconnect()
		{
            this.Parent.Client.Disconnect();
        }

		public override void OnPacket(InPacket iPacket)
        {
            int ALLnum;
            lock (this.Parent.m_lock)
			{
				iPacket.Position = 0;
				uint hash = iPacket.ReadUInt();
                if ((hash == Adler32Helper.GenerateAdler32(Encoding.ASCII.GetBytes("PcReportRaidOccur"), 0) ? false : hash != 1340475309))
				{
                    if (hash == Adler32Helper.GenerateAdler32_ASCII("GrRiderTalkPacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqEnterMagicHatPacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("LoPingRequestPacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqGetRiderQuestUX2ndData", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqAddTimeEventInitPacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqCountdownBoxPeriodPacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqServerSideUdpBindCheck", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqVipGradeCheck", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("SpRqGetMaxGiftIdPacket", 0))
                    {
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("LoRqUpdateRiderSchoolDataPacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("RmRiderTalkPacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqNeedTimerGiftEvent", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PcReportStateInGame", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("GameBoosterAddPacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("LoRqCheckReplayItemPacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqGetRecommandChatServerInfo", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("LoCheckLoginEvent", 0))
                    {
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqBlockWordLogPacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqWriteActionLogPacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqMissionAttendPacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqEnterShopPacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqAddTimeEventTimerPacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqTimeShopOpenTimePacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqItemPresetSlotDataList", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("VipPlaytimeCheck", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("LoRqEventRewardPacket", 0))
                    {
                        //PqGetRecommandChatServerInfo = 라이더 챗
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("LoRqAddRacingTimePacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("LoRpAddRacingTimePacket"))
                        {
                            outPacket.WriteHexString("FF FF FF FF 00 00 00 00 00 00 00 00 00 00");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("LoRqUploadFilePacket", 0))
                    {
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("LoRqStartSinglePacket", 0))
                    {
                        int TimeAttackStartTicks = iPacket.ReadInt();
                        this.Parent.TimeAttackStartTicks = TimeAttackStartTicks;
                        this.Parent.PlaneCheck1 = (byte)this.Parent.TimeAttackStartTicks;
                        uint key = CryptoConstants.GetKey(CryptoConstants.GetKey((uint)this.Parent.TimeAttackStartTicks)) % 5 + 6;
                        ALLnum = (int)key;
                        this.Parent.SendPlaneCount = (int)key;
                        this.Parent.TotalSendPlaneCount = 0;
                        Console.WriteLine("PlaneCheckMax: {0}", this.Parent.SendPlaneCount);
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("GameSlotPacket", 0))
                    {
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("GameReportPacket", 0))
                    {
                        int GetItem = iPacket.ReadInt();
                        int UseItem = iPacket.ReadInt();
                        int UseBooster = iPacket.ReadEncodedInt();
                        int[][] hashArray1 = new int[20][];
                        for (int k = 0; k < 20; k++)
                        {
                            hashArray1[k] = new int[3];
                            hashArray1[k][0] = iPacket.ReadEncodedInt();
                            hashArray1[k][1] = iPacket.ReadEncodedInt();
                            hashArray1[k][2] = iPacket.ReadEncodedInt();
                        }
                        int hash1 = iPacket.ReadEncodedInt();
                        int hash2 = iPacket.ReadEncodedInt();
                        int hash3 = iPacket.ReadEncodedInt();
                        float single1 = iPacket.ReadEncodedFloat();
                        float single2 = iPacket.ReadEncodedFloat();
                        float single3 = iPacket.ReadEncodedFloat();
                        int PlaneCheck = iPacket.ReadInt();
                        this.Parent.TotalSendPlaneCount += PlaneCheck;
                        Console.WriteLine("PlaneCheck: {0}, Total: {1}, Max: {2}, Dist: {3}", PlaneCheck, this.Parent.TotalSendPlaneCount, this.Parent.SendPlaneCount, single3);
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("SpRqRenameRidPacket", 0))
                    {
                        SetRider.Nickname = iPacket.ReadString(false);
                        using (OutPacket outPacket = new OutPacket("SpRpRenameRidPacket"))
                        {
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        SetGameData.Save_Nickname();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGetRider", 0))
                    {
                        NewRider.LoadItemData();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("LoRqGetRiderItemPacket", 0))
                    {
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("LoRqSetRiderItemOnPacket", 0))
                    {
                        SetRiderItem.Set_Character = iPacket.ReadShort();
                        SetRiderItem.Set_Paint = iPacket.ReadShort();
                        SetRiderItem.Set_Kart = iPacket.ReadShort();
                        SetRiderItem.Set_Plate = iPacket.ReadShort();
                        SetRiderItem.Set_Goggle = iPacket.ReadShort();
                        SetRiderItem.Set_Balloon = iPacket.ReadShort();
                        iPacket.ReadShort();
                        SetRiderItem.Set_HeadBand = iPacket.ReadShort();
                        iPacket.ReadShort();
                        SetRiderItem.Set_HandGearL = iPacket.ReadShort();
                        iPacket.ReadShort();
                        SetRiderItem.Set_Uniform = iPacket.ReadShort();
                        iPacket.ReadShort();
                        SetRiderItem.Set_Pet = iPacket.ReadShort();
                        SetRiderItem.Set_FlyingPet = iPacket.ReadShort();
                        SetRiderItem.Set_Aura = iPacket.ReadShort();
                        SetRiderItem.Set_SkidMark = iPacket.ReadShort();
                        iPacket.ReadShort();
                        SetRiderItem.Set_RidColor = iPacket.ReadShort();
                        SetRiderItem.Set_BonusCard = iPacket.ReadShort();
                        iPacket.ReadShort();
                        short Set_KartPlant1 = iPacket.ReadShort();
                        short Set_KartPlant2 = iPacket.ReadShort();
                        short Set_KartPlant3 = iPacket.ReadShort();
                        short Set_KartPlant4 = iPacket.ReadShort();
                        iPacket.ReadShort();
                        iPacket.ReadShort();
                        SetRiderItem.Set_Tachometer = iPacket.ReadShort();
                        SetRiderItem.Set_KartSN = iPacket.ReadShort();
                        byte Set_KartEffect = iPacket.ReadByte();
                        SetRiderItem.Save_SetRiderItem();
                        TuneSpec.Use_TuneSpec();
                        TuneSpec.Use_PlantSpec();
                        TuneSpec.Use_KartLevelSpec();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGetRiderInfo", 0))
                    {
                        iPacket.ReadInt();
                        iPacket.ReadInt();
                        string Nickname = iPacket.ReadString(false);
                        if (Nickname == SetRider.Nickname)
                        {
                            GameSupport.PrGetRiderInfo();
                        }
                        else
                        {
                            using (OutPacket outPacket = new OutPacket("PrGetRiderInfo"))
                            {
                                outPacket.WriteByte(0);
                                this.Parent.Client.Send(outPacket);
                            }
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqUpdateRiderIntro", 0))
                    {
                        SetRider.RiderIntro = iPacket.ReadString(false);
                        SetGameData.Save_RiderIntro();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqUpdateRiderSchoolLevelPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrUpdateRiderSchoolLevelPacket"))
                        {
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqSetPlaytimeEventTick", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrSetPlaytimeEventTick"))
                        {
                            outPacket.WriteByte(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqUpdateGameOption", 0))
                    {
                        SetGameOption.Set_BGM = iPacket.ReadFloat();
                        SetGameOption.Set_Sound = iPacket.ReadFloat();
                        SetGameOption.Old_BGM = iPacket.ReadByte();
                        SetGameOption.Sound_effect = iPacket.ReadByte();
                        SetGameOption.Full_screen = iPacket.ReadByte();
                        SetGameOption.Unk1 = iPacket.ReadByte();
                        SetGameOption.Unk2 = iPacket.ReadByte();
                        SetGameOption.Unk3 = iPacket.ReadByte();
                        SetGameOption.Unk4 = iPacket.ReadByte();
                        SetGameOption.Unk5 = iPacket.ReadByte();
                        SetGameOption.Unk6 = iPacket.ReadByte();
                        SetGameOption.Unk7 = iPacket.ReadByte();
                        SetGameOption.Unk8 = iPacket.ReadByte();//오토 레디
                        SetGameOption.Unk9 = iPacket.ReadByte();//아이템 설명
                        SetGameOption.Unk10 = iPacket.ReadByte();//녹화 품질
                        SetGameOption.Unk11 = iPacket.ReadByte();
                        SetGameOption.BGM_Check = iPacket.ReadByte();//배경음
                        SetGameOption.Sound_Check = iPacket.ReadByte();//효과음
                        SetGameOption.Unk12 = iPacket.ReadByte();
                        SetGameOption.Unk13 = iPacket.ReadByte();
                        SetGameOption.Save_SetGameOption();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGetGameOption", 0))
                    {
                        GameSupport.PrGetGameOption();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqVipInfo", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrVipInfo"))
                        {
                            outPacket.WriteInt(1);
                            for (int i = 0; i < 10; i++)
                            {
                                outPacket.WriteInt(0);
                            }
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqLoginVipInfo", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrLoginVipInfo"))
                        {
                            outPacket.WriteInt(SetRider.Premium);
                            outPacket.WriteByte(1);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        using (OutPacket outPacket = new OutPacket("LoRpEventRewardPacket"))
                        {
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("ChReRqEnterMyRoomPacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("ChRqEnterRandomMyRoomPacket", 0))
                    {
                        if (hash == 1733888222)//ChReRqEnterMyRoomPacket
                        {
                            GameType.EnterMyRoomType = 0;
                        }
                        else if (hash == 2423851656)//ChRqEnterRandomMyRoomPacket
                        {
                            GameType.EnterMyRoomType = 5;
                        }
                        GameSupport.ChRpEnterMyRoomPacket();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("ChRqEnterMyRoomPacket", 0))
                    {
                        string Nickname = iPacket.ReadString(false);
                        if (Nickname == SetRider.Nickname)
                        {
                            GameType.EnterMyRoomType = 0;
                        }
                        else
                        {
                            GameType.EnterMyRoomType = 3;
                        }
                        GameSupport.ChRpEnterMyRoomPacket();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("RmFirstRequestPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("RmSlotDataPacket"))
                        {
                            outPacket.WriteUInt(SetRider.UserNO);
                            outPacket.WriteBytes(new byte[12]);
                            outPacket.WriteString(SetRider.Nickname);
                            outPacket.WriteBytes(new byte[63]);
                            outPacket.WriteInt(SetRider.RP);
                            outPacket.WriteBytes(new byte[910]);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("RmNotiMyRoomInfoPacket", 0))
                    {
                        SetMyRoom.MyRoom = iPacket.ReadShort();
                        SetMyRoom.UseRoomPwd = iPacket.ReadByte();
                        iPacket.ReadByte();
                        SetMyRoom.UseItemPwd = iPacket.ReadByte();
                        SetMyRoom.RoomPwd = iPacket.ReadString(false);
                        iPacket.ReadString(false);
                        SetMyRoom.ItemPwd = iPacket.ReadString(false);
                        SetMyRoom.MyRoomKart1 = iPacket.ReadShort();
                        SetMyRoom.MyRoomKart2 = iPacket.ReadShort();
                        SetMyRoom.Save_SetMyRoom();
                        GameSupport.RmNotiMyRoomInfoPacket();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("ChRqSecedeMyRoomPacket", 0))
                    {
                        //마이룸 나갈때
                        using (OutPacket outPacket = new OutPacket("ChRpSecedeMyRoomPacket"))
                        {
                            outPacket.WriteByte(1);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqStartScenario", 0))
                    {
                        GameType.ScenarioType = iPacket.ReadInt();
                        using (OutPacket outPacket = new OutPacket("PrStartScenario"))
                        {
                            outPacket.WriteInt(GameType.ScenarioType);
                            outPacket.WriteByte(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqCompleteScenarioSingle", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrCompleteScenarioSingle"))
                        {
                            outPacket.WriteInt(GameType.ScenarioType);
                            outPacket.WriteByte(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqKartSpec", 0))
                    {
                        StartGameData.StartTimeAttack_SpeedType = iPacket.ReadByte();
                        StartGameData.Kart_id = iPacket.ReadShort();
                        StartGameData.FlyingPet_id = iPacket.ReadShort();
                        GameType.StartType = 1;
                        SpeedType.SpeedTypeData();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqChapterInfoPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrChapterInfoPacket"))
                        {
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqChallengerInfoPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrChallengerInfoPacket"))
                        {
                            int stage = 40;
                            outPacket.WriteInt(stage);
                            for (int i = 0; i < stage; i++)
                            {
                                outPacket.WriteShort(55);
                            }
                            outPacket.WriteInt(0);
                            outPacket.WriteByte(1);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqStartChallenger", 0))
                    {
                        int stage_id = iPacket.ReadInt();
                        int GameType = iPacket.ReadInt();
                        short Kart = iPacket.ReadShort();
                        byte Unk1 = iPacket.ReadByte();
                        byte Unk2 = iPacket.ReadByte();
                        byte Unk3 = iPacket.ReadByte();
                        using (OutPacket outPacket = new OutPacket("PrStartChallenger"))
                        {
                            outPacket.WriteInt(stage_id);
                            outPacket.WriteInt(GameType);
                            outPacket.WriteByte(0);
                            outPacket.WriteByte(1);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqchallengerKartSpec", 0))
                    {
                        StartGameData.StartTimeAttack_SpeedType = iPacket.ReadByte();
                        StartGameData.Kart_id = iPacket.ReadShort();
                        StartGameData.FlyingPet_id = iPacket.ReadShort();
                        GameType.StartType = 2;
                        SpeedType.SpeedTypeData();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqCompleteChallenger", 0))
                    {
                        int stage = 40;
                        byte StageType = iPacket.ReadByte();
                        iPacket.ReadInt();
                        int EndType = iPacket.ReadInt();
                        using (OutPacket outPacket = new OutPacket("PrCompleteChallenger"))
                        {
                            outPacket.WriteByte(StageType);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(EndType);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(stage);
                            for (int i = 0; i < stage; i++)
                            {
                                outPacket.WriteShort(55);
                            }
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteByte(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqDisassembleXPartsItem", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqExChangePacket", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqKartLevelUpProbText", 0) || hash == Adler32Helper.GenerateAdler32_ASCII("PqKartLevelPointClear", 0))
                    {
                        GameSupport.OnDisconnect();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqKartLevelSpecialSlotUpdate", 0))
                    {
                        short Kart = iPacket.ReadShort();
                        short SN = iPacket.ReadShort();
                        short Effect = iPacket.ReadShort();
                        using (OutPacket outPacket = new OutPacket("PrKartLevelSpecialSlotUpdate"))
                        {
                            outPacket.WriteInt(1);
                            outPacket.WriteShort(Kart);
                            outPacket.WriteShort(SN);
                            outPacket.WriteShort(5);
                            outPacket.WriteShort(0);
                            outPacket.WriteShort(10);
                            outPacket.WriteShort(5);
                            outPacket.WriteShort(10);
                            outPacket.WriteShort(10);
                            outPacket.WriteShort(Effect);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqUseSocketItem", 0))
                    {
                        short Item = iPacket.ReadShort();
                        short Item_Id = iPacket.ReadShort();
                        short Kart = iPacket.ReadShort();
                        iPacket.ReadShort();
                        short KartSN = iPacket.ReadShort();
                        using (OutPacket outPacket = new OutPacket("PrUseSocketItem"))
                        {
                            outPacket.WriteInt(1);
                            outPacket.WriteShort(Item);
                            outPacket.WriteShort(Item_Id);
                            outPacket.WriteShort(Kart);
                            outPacket.WriteShort(1);
                            outPacket.WriteShort(KartSN);
                            outPacket.WriteShort(KartSN);
                            outPacket.WriteHexString("00 00 00 00 FF FF 00 00 00 00 00 00 00 00");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGetTrainingMission", 0))
                    {
                        int type = iPacket.ReadInt();
                        uint track = iPacket.ReadUInt();
                        //PrGetTrainingMission 00 08 B7 51 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
                        using (OutPacket outPacket = new OutPacket("PrGetTrainingMission"))
                        {
                            outPacket.WriteInt(type);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGetDuelMissionBulk", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrGetDuelMissionBulk"))
                        {
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteHexString(Program.DataTime);
                            outPacket.WriteHexString("0F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqAdjustDuelMissionDifficulty", 0))
                    {
                        Console.WriteLine("PqAdjustDuelMissionDifficulty: {0}", iPacket);
                        int type = iPacket.ReadInt();
                        int unk = iPacket.ReadInt();
                        using (OutPacket outPacket = new OutPacket("PrAdjustDuelMissionDifficulty"))
                        {
                            outPacket.WriteInt(type);
                            outPacket.WriteInt(unk);
                            outPacket.WriteInt(0);
                            outPacket.WriteShort(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqBlueMarble", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrBlueMarble"))
                        {
                            outPacket.WriteHexString("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("LoRqGetTrackRankPacket", 0))
                    {
                        uint track = iPacket.ReadUInt();
                        byte SpeedType = iPacket.ReadByte();
                        using (OutPacket outPacket = new OutPacket("LoRpGetTrackRankPacket"))
                        {
                            outPacket.WriteUInt(track);
                            outPacket.WriteByte(SpeedType);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqFavoriteTrackUpdate", 0))
                    {
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("LoRqDecLucciPacket", 0))
                    {
                        iPacket.ReadByte();
                        uint Lucci = iPacket.ReadUInt();
                        SetRider.Lucci -= Lucci;
                        SetGameData.Save_TimeAttackDecLucci();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqStartTimeAttack", 0))
                    {
                        StartGameData.StartTimeAttack_SpeedType = iPacket.ReadByte();
                        StartGameData.Kart_id = iPacket.ReadShort();
                        StartGameData.FlyingPet_id = iPacket.ReadShort();
                        StartGameData.StartTimeAttack_Track = iPacket.ReadUInt();
                        StartGameData.StartTimeAttack_StartType = iPacket.ReadByte();
                        TrackName trackName = (TrackName)StartGameData.StartTimeAttack_Track;
                        Console.WriteLine("StartTimeAttack: {0} / {1} / {2} / {3} / {4}", StartGameData.StartTimeAttack_SpeedType, StartGameData.Kart_id, StartGameData.FlyingPet_id, trackName, StartGameData.StartTimeAttack_StartType);
                        GameType.StartType = 3;
                        SpeedType.SpeedTypeData();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqRewardTimeAttack", 0))
                    {
                        byte RewardType = iPacket.ReadByte();
                        int RP = iPacket.ReadInt();
                        int Lucci = iPacket.ReadInt();
                        int TimeAttack_StartTicks = iPacket.ReadInt();
                        uint Track = iPacket.ReadUInt();
                        TrackName trackName = (TrackName)Track;
                        Console.WriteLine("RewardTimeAttack : ResultType: {0}, RP: {1}, Lucci: {2}, Track: {3}", RewardType, RP, Lucci, trackName);
                        if (RewardType == 0)
                        {
                            SetRider.RP += 10;
                            SetRider.Lucci += 20;
                        }
                        else if (RewardType == 1)
                        {
                            SetRider.RP += 20;
                            SetRider.Lucci += 50;
                        }
                        SetGameData.Save_RewardTimeAttack();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("LoRqUseItemPacket", 0))
                    {
                        short ItemType = iPacket.ReadShort();
                        short Type = iPacket.ReadShort();
                        SetRider.SlotChanger = iPacket.ReadShort();
                        if (Type == 1)
                        {
                            SetGameData.Save_SlotChanger();
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqQuestUX2ndPacket", 0))
                    {
                        GameSupport.PrQuestUX2ndPacket();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGameOutRunUX2ndClearPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrGameOutRunUX2ndClearPacket"))
                        {
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGetTrainingMissionReward", 0))
                    {
                        Console.WriteLine("PqGetTrainingMissionReward: {0}", iPacket);
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("SpRqBingoGachaPacket", 0))
                    {
                        int BingoType = iPacket.ReadInt();
                        if (BingoType == 0)
                        {
                            using (OutPacket outPacket = new OutPacket("SpRpBingoGachaPacket"))
                            {
                                outPacket.WriteInt(BingoType);
                                for (int i = 0; i < 5; i++)
                                {
                                    outPacket.WriteInt(0);
                                }
                                outPacket.WriteByte(0);
                                outPacket.WriteByte(0);
                                outPacket.WriteByte(0);
                                this.Parent.Client.Send(outPacket);
                            }
                        }
                        else if (BingoType == 4)
                        {
                            using (OutPacket outPacket = new OutPacket("SpRpBingoGachaPacket"))
                            {
                                outPacket.WriteInt(BingoType);
                                for (int i = 0; i < 5; i++)
                                {
                                    outPacket.WriteInt(0);
                                }
                                outPacket.WriteByte(0);
                                outPacket.WriteByte(0);
                                outPacket.WriteByte(0);
                                this.Parent.Client.Send(outPacket);
                            }
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("SpRqLotteryPacket", 0))
                    {
                        short Lottery_Item = iPacket.ReadShort();
                        byte Unk = iPacket.ReadByte();
                        int Type = iPacket.ReadInt();
                        GameSupport.SpRpLotteryPacket();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGetRiderTaskContext", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrGetRiderTaskContext"))
                        {
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqVersusModeRankOnePacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrVersusModeRankOnePacket"))
                        {
                            outPacket.WriteHexString("00 FF FF FF FF FF FF FF FF");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqPcCafeShowcaseCoupon", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrPcCafeShowcaseCoupon"))
                        {
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGetRiderCareerSummary", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrGetRiderCareerSummary"))
                        {
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqRsbPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrRsbPacket"))
                        {
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqStartRiderSchool", 0))
                    {
                        GameType.RiderSchoolType = iPacket.ReadByte();
                        RiderSchool.PrStartRiderSchool();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("LoRqUpdateRsbPacket", 0))
                    {
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqRequestExtradata", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrRequestExtradata"))
                        {
                            outPacket.WriteShort(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("ChRequestChStaticRequestPacket", 0))
                    {
                        GameSupport.ChRequestChStaticReplyPacket();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqDynamicCommand", 0))
                    {
                        GameSupport.PrDynamicCommand();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqPubCommandPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrPubCommandPacket"))
                        {
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqWebEventCompleteCheckPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrWebEventCompleteCheckPacket"))
                        {
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("SpRqKoinBalance", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("SpRpKoinBalance"))
                        {
                            outPacket.WriteUInt(SetRider.Koin);
                            outPacket.WriteUInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqFavoriteTrackMapGet", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrFavoriteTrackMapGet"))
                        {
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGetFavoriteChannel", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrGetFavoriteChannel"))
                        {
                            outPacket.WriteHexString("02 00 00 00 00 00 00 00 00 00 01 00");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqKartPassInitPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrKartPassInitPacket"))
                        {
                            outPacket.WriteInt(3);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("SpRqGetCashInventoryPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("SpRpGetCashInventoryPacket"))
                        {
                            outPacket.WriteInt(0);
                            outPacket.WriteByte(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("SpRqRemainCashPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("SpRpRemainCashPacket"))
                        {
                            outPacket.WriteUInt(0);
                            outPacket.WriteUInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("SpRqRemainTcCashPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("SpRpRemainTcCashPacket"))
                        {
                            outPacket.WriteUInt(99);
                            outPacket.WriteUInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("SpReqNormalShopBuyItemPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("SpRepBuyItemPacket"))
                        {
                            outPacket.WriteHexString("01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGetCurrentRid", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrGetCurrentRid"))
                        {
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGetMyCouponList", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrGetMyCouponList"))
                        {
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqDisassembleFeeInfo", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrDisassembleFeeInfo"))
                        {
                            outPacket.WriteHexString("00 00 00 00 06 00 00 00 00 00 E8 03 01 00 F4 01 00 00 E8 03 01 00 F4 01 00 00 E8 03 01 00 F4 01");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqRequestExchangeInitPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrRequestExchangeInitPacket"))
                        {
                            outPacket.WriteHexString("01 03 00 00 00 F4 01 00 00 01 00 00 00 02 00 00 00 03 00 00 00");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqRequestPeriodExchangeInitPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrRequestPeriodExchangeInitPacket"))
                        {
                            outPacket.WriteBytes(new byte[22]);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("SpRqEnterRewardBoxStage", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("SpRpEnterRewardBoxStage"))
                        {
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteByte(1);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("SpRqExitRewardBoxStage", 0))
                    {
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("SpRqGetGiftListIncomingPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("SpRpGetGiftListIncomingPacket"))
                        {
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("SpRqGetGiftListReceivedPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("SpRpGetGiftListReceivedPacket"))
                        {
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGetCompetitiveRankInfo", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrGetCompetitiveRankInfo"))
                        {
                            outPacket.WriteHexString("01 00 00 00 00 FF 00 00 00 00 00 00 00 00 00 00 00 00");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGetCompetitiveSlotInfo", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrGetCompetitiveSlotInfo"))
                        {
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGetCompetitiveCount", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrGetCompetitiveCount"))
                        {
                            outPacket.WriteHexString("B3 02 52 1B 00 00 B4 02 54 1B 00 00 B9 02 82 1B 00 00");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqSearchCompetitiveRankPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrSearchCompetitiveRankPacket"))
                        {
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGetCompetitivePreRankPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrGetCompetitivePreRankPacket"))
                        {
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("RmRequestEmblemsPacket", 0))
                    {
                        Emblem.RmOwnerEmblemPacket();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("RmRqUpdateMainEmblemPacket", 0))
                    {
                        SetRider.Emblem1 = iPacket.ReadShort();
                        SetRider.Emblem2 = iPacket.ReadShort();
                        using (OutPacket outPacket = new OutPacket("RmRpUpdateMainEmblemPacket"))
                        {
                            outPacket.WriteByte(1);
                            outPacket.WriteByte(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        SetGameData.Save_Emblem();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqSyncDictionaryInfoPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrSyncDictionaryInfoPacket"))
                        {
                            outPacket.WriteInt(1);
                            outPacket.WriteInt(1);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqGetDictionaryRewardInfoPacket", 0))
                    {
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqNewCareerListPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrNewCareerListPacket"))
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                outPacket.WriteInt(0);
                            }
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("LoRqDeleteItemPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("LoRpDeleteItemPacket"))
                        {
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("SpRqQueryCoupon", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("SpRpQueryCoupon"))
                        {
                            outPacket.WriteInt(1);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqShopCashPage", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrShopCashPage"))
                        {
                            outPacket.WriteString("https://ripay.nexon.com/Payment/Index");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqBingoSync", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrBingoSync"))
                        {
                            outPacket.WriteByte(0);
                            outPacket.WriteUShort(0);
                            outPacket.WriteUShort(0);
                            for (int i = 0; i < 15; i++)
                            {
                                outPacket.WriteByte(0);
                            }
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqEnterKartPassPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrEnterKartPassPacket"))
                        {
                            outPacket.WriteHexString("00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqKartPassPlayTimePacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrKartPassPlayTimePacket"))
                        {
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqKartPassRewardPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrKartPassRewardPacket"))
                        {
                            outPacket.WriteHexString("00 00 00 00 00 00 00 00 01 00 00 00 01 00 00 00");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqEnterSeasonPassPacket", 0))
                    {
                        byte SeasonPassType = iPacket.ReadByte();
                        using (OutPacket outPacket = new OutPacket("PrEnterSeasonPassPacket"))
                        {
                            outPacket.WriteInt(0);
                            outPacket.WriteByte(SeasonPassType);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqSeasonPassRewardPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrSeasonPassRewardPacket"))
                        {
                            outPacket.WriteHexString("00 00 00 00 00 00 00 00 01 00 00 00 01 00 00 00");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqCheckPassword", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrCheckPassword"))
                        {
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqUnLockedItem", 0))
                    {
                        int useType = iPacket.ReadInt();
                        int stringType = iPacket.ReadInt();
                        for (int i = 0; i < useType; i++)
                        {
                            iPacket.ReadString(false);
                        }
                        byte Type = iPacket.ReadByte();
                        using (OutPacket outPacket = new OutPacket("PrUnLockedItem"))
                        {
                            outPacket.WriteByte(Type);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqFavoriteItemGet", 0)) //즐겨 찾기 목록
                    {
                        FavoriteItem.Favorite_Item();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqFavoriteItemUpdate", 0))
                    {
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqLockedItemGet", 0))//아이템 보호
                    {
                        using (OutPacket outPacket = new OutPacket("PrLockedItemGet"))
                        {
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqLockedItemUpdate", 0))
                    {
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqSimGameSimpleInfoAndRankPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrSimGameSimpleInfoAndRankPacket"))
                        {
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqSimGameEnterPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrSimGameEnterPacket"))
                        {
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqChannelSwitch", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("ChGetCurrentGpReplyPacket"))
                        {
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteByte(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("ChCreateRoomRequestPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("ChCreateRoomReplyPacket"))
                        {
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("SpRqTimeShopPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("SpRpTimeShopPacket"))
                        {
                            outPacket.WriteHexString("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF FF FF FF FF FF FF FF FF FF 47 00 00 00 00 00 47 00 00 00 00 00 00 00 01 00 00 00");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqSecretShopEnterPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrSecretShopEnterPacket"))
                        {
                            outPacket.WriteHexString("00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqEnterUpgradeGearPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrEnterUpgradeGearPacket"))
                        {
                            outPacket.WriteHexString("05 00 00 00 03 00 00 00 05 00 00 00 00 00 00 00 00 00 00 00");
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqBlockCatchEnterPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrBlockCatchEnterPacket"))
                        {
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(3);
                            outPacket.WriteInt(3);
                            outPacket.WriteInt(0);
                            outPacket.WriteInt(5);
                            outPacket.WriteInt(1);
                            outPacket.WriteInt(7);
                            outPacket.WriteInt(2);
                            outPacket.WriteInt(600);
                            outPacket.WriteInt(300);
                            outPacket.WriteInt(200);
                            outPacket.WriteInt(100);
                            outPacket.WriteInt(-100);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("RqEnterFishingStagePacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("RpEnterFishingStagePacket"))
                        {
                            outPacket.WriteByte(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("checkSecondAuthenPacket", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("checkSecondAuthenPacket"))
                        {
                            outPacket.WriteInt(2);
                            outPacket.WriteInt(0);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqTestServerAddItemPacket", 0))
                    {
                        TestServer.Type = iPacket.ReadShort();
                        TestServer.ItemID = iPacket.ReadShort();
                        TestServer.Amount = iPacket.ReadShort();
                        TestServer.TestServerAddItem();
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqServerTime", 0))
                    {
                        using (OutPacket outPacket = new OutPacket("PrServerTime"))
                        {
                            outPacket.WriteHexString(Program.DataTime);
                            this.Parent.Client.Send(outPacket);
                        }
                        return;
                    }
                    else if (hash == Adler32Helper.GenerateAdler32_ASCII("PqLogin", 0))
                    {
                        GameDataReset.DataReset();
                        return;
                    }
                }
            }
        }
    }
}