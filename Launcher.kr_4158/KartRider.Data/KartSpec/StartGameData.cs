using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KartRider.IO;
using ExcData;
using Set_Data;

namespace KartRider
{
    public class StartGameData
    {
        public static byte StartTimeAttack_SpeedType = 0;
        public static short Kart_id = 0;
        public static short FlyingPet_id = 0;
        public static uint StartTimeAttack_Track = 0;
        public static byte StartTimeAttack_StartType = 0;

        public static void Start_KartSpac()
        {
            Console.WriteLine("SpeedType: {0}, Kart_id: {1}, FlyingPet_id: {2}", StartGameData.StartTimeAttack_SpeedType, StartGameData.Kart_id, StartGameData.FlyingPet_id);
            if (GameType.StartType == 1)
            {
                Console.WriteLine("시나리오");
                StartGameData.PrKartSpec();
            }
            else if (GameType.StartType == 2)
            {
                Console.WriteLine("도전자");
                StartGameData.PrchallengerKartSpec();
            }
            else if (GameType.StartType == 3)
            {
                Console.WriteLine("타임어택");
                if (StartGameData.StartTimeAttack_StartType == 0)
                {
                    StartGameData.PrStartTimeAttack();
                }
                else
                {
                    StartGameData.PrStartTimeAttack_QuestType();
                }
            }
            else
            {
                GameSupport.OnDisconnect();
            }
        }

        public static void PrStartTimeAttack()
        {
            using (OutPacket oPacket = new OutPacket("PrStartTimeAttack"))
            {
                oPacket.WriteByte(1);
                //------------------------------------------------------------------------KartSpac Start
                oPacket.WriteEncFloat(Kart.draftMulAccelFactor);
                oPacket.WriteEncInt(Kart.draftTick);
                oPacket.WriteEncFloat(Kart.driftBoostMulAccelFactor);
                oPacket.WriteEncInt(Kart.driftBoostTick);
                oPacket.WriteEncFloat(Kart.chargeBoostBySpeed);
                oPacket.WriteEncByte(Kart.SpeedSlotCapacity);
                oPacket.WriteEncByte(Kart.ItemSlotCapacity);
                oPacket.WriteEncByte(Kart.SpecialSlotCapacity);
                oPacket.WriteEncByte((byte)((Kart.UseTransformBooster ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.motorcycleType ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.BikeRearWheel ? 1 : 0)));
                oPacket.WriteEncFloat(Kart.Mass);
                oPacket.WriteEncFloat(Kart.AirFriction);
                oPacket.WriteEncFloat(SpeedType.DragFactor + Kart.DragFactor + FlyingPet.DragFactor + SpeedPatch.DragFactor);
                oPacket.WriteEncFloat(SpeedType.ForwardAccelForce + Kart.ForwardAccelForce + FlyingPet.ForwardAccelForce + TuneSpec.Plant_ForwardAccelForce + TuneSpec.KartLevel_ForwardAccelForce + SpeedPatch.ForwardAccelForce);
                oPacket.WriteEncFloat(SpeedType.BackwardAccelForce + Kart.BackwardAccelForce);
                oPacket.WriteEncFloat(SpeedType.GripBrakeForce + Kart.GripBrakeForce + TuneSpec.Plant_GripBrakeForce);
                oPacket.WriteEncFloat(SpeedType.SlipBrakeForce + Kart.SlipBrakeForce);
                oPacket.WriteEncFloat(Kart.MaxSteerAngle);
                oPacket.WriteEncFloat(SpeedType.SteerConstraint + Kart.SteerConstraint);
                oPacket.WriteEncFloat(Kart.FrontGripFactor + TuneSpec.Plant_FrontGripFactor);
                oPacket.WriteEncFloat(Kart.RearGripFactor + TuneSpec.Plant_RearGripFactor);
                oPacket.WriteEncFloat(Kart.DriftTriggerFactor);
                oPacket.WriteEncFloat(Kart.DriftTriggerTime);
                oPacket.WriteEncFloat(Kart.DriftSlipFactor);
                oPacket.WriteEncFloat(SpeedType.DriftEscapeForce + Kart.DriftEscapeForce + FlyingPet.DriftEscapeForce + TuneSpec.Tune_DriftEscapeForce + TuneSpec.Plant_DriftEscapeForce + TuneSpec.KartLevel_DriftEscapeForce + SpeedPatch.DriftEscapeForce);
                oPacket.WriteEncFloat(SpeedType.CornerDrawFactor + Kart.CornerDrawFactor + FlyingPet.CornerDrawFactor + TuneSpec.Plant_CornerDrawFactor + TuneSpec.KartLevel_CornerDrawFactor + SpeedPatch.CornerDrawFactor);
                oPacket.WriteEncFloat(Kart.DriftLeanFactor);
                oPacket.WriteEncFloat(Kart.SteerLeanFactor);
                if (StartGameData.StartTimeAttack_SpeedType == 4 || StartGameData.StartTimeAttack_SpeedType == 6)
                {
                    oPacket.WriteEncFloat(GameType.S4_DriftMaxGauge);
                }
                else
                {
                    oPacket.WriteEncFloat(SpeedType.DriftMaxGauge + Kart.DriftMaxGauge + TuneSpec.Plant_DriftMaxGauge + SpeedPatch.DriftMaxGauge);
                }
                if (StartGameData.StartTimeAttack_SpeedType == 6)
                {
                    oPacket.WriteEncFloat(GameType.S6_BoosterTime);
                }
                else
                {
                    oPacket.WriteEncFloat(Kart.NormalBoosterTime + FlyingPet.NormalBoosterTime + TuneSpec.Plant_NormalBoosterTime);
                }
                oPacket.WriteEncFloat(Kart.ItemBoosterTime + FlyingPet.ItemBoosterTime);
                if (StartGameData.StartTimeAttack_SpeedType == 6)
                {
                    oPacket.WriteEncFloat(GameType.S6_BoosterTime);
                }
                else
                {
                    oPacket.WriteEncFloat(Kart.TeamBoosterTime + FlyingPet.TeamBoosterTime);
                }
                oPacket.WriteEncFloat(Kart.AnimalBoosterTime);
                oPacket.WriteEncFloat(Kart.SuperBoosterTime);
                oPacket.WriteEncFloat(SpeedType.TransAccelFactor + Kart.TransAccelFactor + TuneSpec.Tune_TransAccelFactor + TuneSpec.Plant_TransAccelFactor + TuneSpec.KartLevel_TransAccelFactor + SpeedPatch.TransAccelFactor);
                oPacket.WriteEncFloat(SpeedType.BoostAccelFactor + Kart.BoostAccelFactor + SpeedPatch.BoostAccelFactor);
                oPacket.WriteEncFloat(Kart.StartBoosterTimeItem + TuneSpec.KartLevel_StartBoosterTimeItem);
                oPacket.WriteEncFloat(Kart.StartBoosterTimeSpeed + TuneSpec.Tune_StartBoosterTimeSpeed + TuneSpec.Plant_StartBoosterTimeSpeed + TuneSpec.KartLevel_StartBoosterTimeSpeed);
                oPacket.WriteEncFloat(SpeedType.StartForwardAccelForceItem + Kart.StartForwardAccelForceItem + FlyingPet.StartForwardAccelForceItem + SpeedPatch.StartForwardAccelForceItem);
                oPacket.WriteEncFloat(SpeedType.StartForwardAccelForceSpeed + Kart.StartForwardAccelForceSpeed + FlyingPet.StartForwardAccelForceSpeed + SpeedPatch.StartForwardAccelForceSpeed);
                oPacket.WriteEncFloat(Kart.DriftGaguePreservePercent);
                oPacket.WriteEncByte((byte)((Kart.UseExtendedAfterBooster ? 1 : 0)));
                oPacket.WriteEncFloat(Kart.BoostAccelFactorOnlyItem);
                oPacket.WriteEncFloat(Kart.antiCollideBalance);
                oPacket.WriteEncByte((byte)((Kart.dualBoosterSetAuto ? 1 : 0)));
                oPacket.WriteEncInt(Kart.dualBoosterTickMin);
                oPacket.WriteEncInt(Kart.dualBoosterTickMax);
                oPacket.WriteEncFloat(Kart.dualMulAccelFactor);
                oPacket.WriteEncFloat(Kart.dualTransLowSpeed);
                oPacket.WriteEncByte((byte)((Kart.PartsEngineLock ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.PartsWheelLock ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.PartsSteeringLock ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.PartsBoosterLock ? 1 : 0)));
                //------------------------------------------------------------------------KartSpac End
                oPacket.WriteByte(0);
                oPacket.WriteInt(0);
                oPacket.WriteInt(0);
                RouterListener.MySession.Client.Send(oPacket);
            }
            StartGameData.KartSpecLog();
        }

        public static void PrchallengerKartSpec()
        {
            using (OutPacket oPacket = new OutPacket("PrchallengerKartSpec"))
            {
                oPacket.WriteByte(1);
                //------------------------------------------------------------------------KartSpac Start
                oPacket.WriteEncFloat(Kart.draftMulAccelFactor);
                oPacket.WriteEncInt(Kart.draftTick);
                oPacket.WriteEncFloat(Kart.driftBoostMulAccelFactor);
                oPacket.WriteEncInt(Kart.driftBoostTick);
                oPacket.WriteEncFloat(Kart.chargeBoostBySpeed);
                oPacket.WriteEncByte(Kart.SpeedSlotCapacity);
                oPacket.WriteEncByte(Kart.ItemSlotCapacity);
                oPacket.WriteEncByte(Kart.SpecialSlotCapacity);
                oPacket.WriteEncByte((byte)((Kart.UseTransformBooster ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.motorcycleType ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.BikeRearWheel ? 1 : 0)));
                oPacket.WriteEncFloat(Kart.Mass);
                oPacket.WriteEncFloat(Kart.AirFriction);
                oPacket.WriteEncFloat(SpeedType.DragFactor + Kart.DragFactor + FlyingPet.DragFactor + SpeedPatch.DragFactor);
                oPacket.WriteEncFloat(SpeedType.ForwardAccelForce + Kart.ForwardAccelForce + FlyingPet.ForwardAccelForce + TuneSpec.Plant_ForwardAccelForce + TuneSpec.KartLevel_ForwardAccelForce + SpeedPatch.ForwardAccelForce);
                oPacket.WriteEncFloat(SpeedType.BackwardAccelForce + Kart.BackwardAccelForce);
                oPacket.WriteEncFloat(SpeedType.GripBrakeForce + Kart.GripBrakeForce + TuneSpec.Plant_GripBrakeForce);
                oPacket.WriteEncFloat(SpeedType.SlipBrakeForce + Kart.SlipBrakeForce);
                oPacket.WriteEncFloat(Kart.MaxSteerAngle);
                oPacket.WriteEncFloat(SpeedType.SteerConstraint + Kart.SteerConstraint);
                oPacket.WriteEncFloat(Kart.FrontGripFactor + TuneSpec.Plant_FrontGripFactor);
                oPacket.WriteEncFloat(Kart.RearGripFactor + TuneSpec.Plant_RearGripFactor);
                oPacket.WriteEncFloat(Kart.DriftTriggerFactor);
                oPacket.WriteEncFloat(Kart.DriftTriggerTime);
                oPacket.WriteEncFloat(Kart.DriftSlipFactor);
                oPacket.WriteEncFloat(SpeedType.DriftEscapeForce + Kart.DriftEscapeForce + FlyingPet.DriftEscapeForce + TuneSpec.Tune_DriftEscapeForce + TuneSpec.Plant_DriftEscapeForce + TuneSpec.KartLevel_DriftEscapeForce + SpeedPatch.DriftEscapeForce);
                oPacket.WriteEncFloat(SpeedType.CornerDrawFactor + Kart.CornerDrawFactor + FlyingPet.CornerDrawFactor + TuneSpec.Plant_CornerDrawFactor + TuneSpec.KartLevel_CornerDrawFactor + SpeedPatch.CornerDrawFactor);
                oPacket.WriteEncFloat(Kart.DriftLeanFactor);
                oPacket.WriteEncFloat(Kart.SteerLeanFactor);
                if (StartGameData.StartTimeAttack_SpeedType == 4 || StartGameData.StartTimeAttack_SpeedType == 6)
                {
                    oPacket.WriteEncFloat(GameType.S4_DriftMaxGauge);
                }
                else
                {
                    oPacket.WriteEncFloat(SpeedType.DriftMaxGauge + Kart.DriftMaxGauge + TuneSpec.Plant_DriftMaxGauge + SpeedPatch.DriftMaxGauge);
                }
                if (StartGameData.StartTimeAttack_SpeedType == 6)
                {
                    oPacket.WriteEncFloat(GameType.S6_BoosterTime);
                }
                else
                {
                    oPacket.WriteEncFloat(Kart.NormalBoosterTime + FlyingPet.NormalBoosterTime + TuneSpec.Plant_NormalBoosterTime);
                }
                oPacket.WriteEncFloat(Kart.ItemBoosterTime + FlyingPet.ItemBoosterTime);
                if (StartGameData.StartTimeAttack_SpeedType == 6)
                {
                    oPacket.WriteEncFloat(GameType.S6_BoosterTime);
                }
                else
                {
                    oPacket.WriteEncFloat(Kart.TeamBoosterTime + FlyingPet.TeamBoosterTime);
                }
                oPacket.WriteEncFloat(Kart.AnimalBoosterTime);
                oPacket.WriteEncFloat(Kart.SuperBoosterTime);
                oPacket.WriteEncFloat(SpeedType.TransAccelFactor + Kart.TransAccelFactor + TuneSpec.Tune_TransAccelFactor + TuneSpec.Plant_TransAccelFactor + TuneSpec.KartLevel_TransAccelFactor + SpeedPatch.TransAccelFactor);
                oPacket.WriteEncFloat(SpeedType.BoostAccelFactor + Kart.BoostAccelFactor + SpeedPatch.BoostAccelFactor);
                oPacket.WriteEncFloat(Kart.StartBoosterTimeItem + TuneSpec.KartLevel_StartBoosterTimeItem);
                oPacket.WriteEncFloat(Kart.StartBoosterTimeSpeed + TuneSpec.Tune_StartBoosterTimeSpeed + TuneSpec.Plant_StartBoosterTimeSpeed + TuneSpec.KartLevel_StartBoosterTimeSpeed);
                oPacket.WriteEncFloat(SpeedType.StartForwardAccelForceItem + Kart.StartForwardAccelForceItem + FlyingPet.StartForwardAccelForceItem + SpeedPatch.StartForwardAccelForceItem);
                oPacket.WriteEncFloat(SpeedType.StartForwardAccelForceSpeed + Kart.StartForwardAccelForceSpeed + FlyingPet.StartForwardAccelForceSpeed + SpeedPatch.StartForwardAccelForceSpeed);
                oPacket.WriteEncFloat(Kart.DriftGaguePreservePercent);
                oPacket.WriteEncByte((byte)((Kart.UseExtendedAfterBooster ? 1 : 0)));
                oPacket.WriteEncFloat(Kart.BoostAccelFactorOnlyItem);
                oPacket.WriteEncFloat(Kart.antiCollideBalance);
                oPacket.WriteEncByte((byte)((Kart.dualBoosterSetAuto ? 1 : 0)));
                oPacket.WriteEncInt(Kart.dualBoosterTickMin);
                oPacket.WriteEncInt(Kart.dualBoosterTickMax);
                oPacket.WriteEncFloat(Kart.dualMulAccelFactor);
                oPacket.WriteEncFloat(Kart.dualTransLowSpeed);
                oPacket.WriteEncByte((byte)((Kart.PartsEngineLock ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.PartsWheelLock ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.PartsSteeringLock ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.PartsBoosterLock ? 1 : 0)));
                //------------------------------------------------------------------------KartSpac End
                oPacket.WriteInt(0);
                oPacket.WriteByte(0);
                RouterListener.MySession.Client.Send(oPacket);
            }
            StartGameData.KartSpecLog();
        }

        public static void PrKartSpec()
        {
            using (OutPacket oPacket = new OutPacket("PrKartSpec"))
            {
                oPacket.WriteByte(1);
                //------------------------------------------------------------------------KartSpac Start
                oPacket.WriteEncFloat(Kart.draftMulAccelFactor);
                oPacket.WriteEncInt(Kart.draftTick);
                oPacket.WriteEncFloat(Kart.driftBoostMulAccelFactor);
                oPacket.WriteEncInt(Kart.driftBoostTick);
                oPacket.WriteEncFloat(Kart.chargeBoostBySpeed);
                oPacket.WriteEncByte(Kart.SpeedSlotCapacity);
                oPacket.WriteEncByte(Kart.ItemSlotCapacity);
                oPacket.WriteEncByte(Kart.SpecialSlotCapacity);
                oPacket.WriteEncByte((byte)((Kart.UseTransformBooster ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.motorcycleType ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.BikeRearWheel ? 1 : 0)));
                oPacket.WriteEncFloat(Kart.Mass);
                oPacket.WriteEncFloat(Kart.AirFriction);
                oPacket.WriteEncFloat(SpeedType.DragFactor + Kart.DragFactor + FlyingPet.DragFactor + SpeedPatch.DragFactor);
                oPacket.WriteEncFloat(SpeedType.ForwardAccelForce + Kart.ForwardAccelForce + FlyingPet.ForwardAccelForce + SpeedPatch.ForwardAccelForce);
                oPacket.WriteEncFloat(SpeedType.BackwardAccelForce + Kart.BackwardAccelForce);
                oPacket.WriteEncFloat(SpeedType.GripBrakeForce + Kart.GripBrakeForce);
                oPacket.WriteEncFloat(SpeedType.SlipBrakeForce + Kart.SlipBrakeForce);
                oPacket.WriteEncFloat(Kart.MaxSteerAngle);
                oPacket.WriteEncFloat(SpeedType.SteerConstraint + Kart.SteerConstraint);
                oPacket.WriteEncFloat(Kart.FrontGripFactor);
                oPacket.WriteEncFloat(Kart.RearGripFactor);
                oPacket.WriteEncFloat(Kart.DriftTriggerFactor);
                oPacket.WriteEncFloat(Kart.DriftTriggerTime);
                oPacket.WriteEncFloat(Kart.DriftSlipFactor);
                oPacket.WriteEncFloat(SpeedType.DriftEscapeForce + Kart.DriftEscapeForce + FlyingPet.DriftEscapeForce + SpeedPatch.DriftEscapeForce);
                oPacket.WriteEncFloat(SpeedType.CornerDrawFactor + Kart.CornerDrawFactor + FlyingPet.CornerDrawFactor + SpeedPatch.CornerDrawFactor);
                oPacket.WriteEncFloat(Kart.DriftLeanFactor);
                oPacket.WriteEncFloat(Kart.SteerLeanFactor);
                if (StartGameData.StartTimeAttack_SpeedType == 4 || StartGameData.StartTimeAttack_SpeedType == 6)
                {
                    oPacket.WriteEncFloat(GameType.S4_DriftMaxGauge);
                }
                else
                {
                    oPacket.WriteEncFloat(SpeedType.DriftMaxGauge + Kart.DriftMaxGauge + SpeedPatch.DriftMaxGauge);
                }
                if (StartGameData.StartTimeAttack_SpeedType == 6)
                {
                    oPacket.WriteEncFloat(GameType.S6_BoosterTime);
                }
                else
                {
                    oPacket.WriteEncFloat(Kart.NormalBoosterTime + FlyingPet.NormalBoosterTime);
                }
                oPacket.WriteEncFloat(Kart.ItemBoosterTime + FlyingPet.ItemBoosterTime);
                if (StartGameData.StartTimeAttack_SpeedType == 6)
                {
                    oPacket.WriteEncFloat(GameType.S6_BoosterTime);
                }
                else
                {
                    oPacket.WriteEncFloat(Kart.TeamBoosterTime + FlyingPet.TeamBoosterTime);
                }
                oPacket.WriteEncFloat(Kart.AnimalBoosterTime);
                oPacket.WriteEncFloat(Kart.SuperBoosterTime);
                oPacket.WriteEncFloat(SpeedType.TransAccelFactor + Kart.TransAccelFactor + SpeedPatch.TransAccelFactor);
                oPacket.WriteEncFloat(SpeedType.BoostAccelFactor + Kart.BoostAccelFactor + SpeedPatch.BoostAccelFactor);
                oPacket.WriteEncFloat(Kart.StartBoosterTimeItem);
                oPacket.WriteEncFloat(Kart.StartBoosterTimeSpeed);
                oPacket.WriteEncFloat(SpeedType.StartForwardAccelForceItem + Kart.StartForwardAccelForceItem + FlyingPet.StartForwardAccelForceItem + SpeedPatch.StartForwardAccelForceItem);
                oPacket.WriteEncFloat(SpeedType.StartForwardAccelForceSpeed + Kart.StartForwardAccelForceSpeed + FlyingPet.StartForwardAccelForceSpeed + SpeedPatch.StartForwardAccelForceSpeed);
                oPacket.WriteEncFloat(Kart.DriftGaguePreservePercent);
                oPacket.WriteEncByte((byte)((Kart.UseExtendedAfterBooster ? 1 : 0)));
                oPacket.WriteEncFloat(Kart.BoostAccelFactorOnlyItem);
                oPacket.WriteEncFloat(Kart.antiCollideBalance);
                oPacket.WriteEncByte((byte)((Kart.dualBoosterSetAuto ? 1 : 0)));
                oPacket.WriteEncInt(Kart.dualBoosterTickMin);
                oPacket.WriteEncInt(Kart.dualBoosterTickMax);
                oPacket.WriteEncFloat(Kart.dualMulAccelFactor);
                oPacket.WriteEncFloat(Kart.dualTransLowSpeed);
                oPacket.WriteEncByte((byte)((Kart.PartsEngineLock ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.PartsWheelLock ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.PartsSteeringLock ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.PartsBoosterLock ? 1 : 0)));
                //------------------------------------------------------------------------KartSpac End
                oPacket.WriteByte(0);
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void PrStartTimeAttack_QuestType()
        {
            using (OutPacket oPacket = new OutPacket("PrStartTimeAttack"))
            {
                oPacket.WriteByte(1);
                //------------------------------------------------------------------------KartSpac Start
                oPacket.WriteEncFloat(Kart.draftMulAccelFactor);
                oPacket.WriteEncInt(Kart.draftTick);
                oPacket.WriteEncFloat(Kart.driftBoostMulAccelFactor);
                oPacket.WriteEncInt(Kart.driftBoostTick);
                oPacket.WriteEncFloat(Kart.chargeBoostBySpeed);
                oPacket.WriteEncByte(Kart.SpeedSlotCapacity);
                oPacket.WriteEncByte(Kart.ItemSlotCapacity);
                oPacket.WriteEncByte(Kart.SpecialSlotCapacity);
                oPacket.WriteEncByte((byte)((Kart.UseTransformBooster ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.motorcycleType ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.BikeRearWheel ? 1 : 0)));
                oPacket.WriteEncFloat(Kart.Mass);
                oPacket.WriteEncFloat(Kart.AirFriction);
                oPacket.WriteEncFloat(SpeedType.DragFactor + Kart.DragFactor + FlyingPet.DragFactor + SpeedPatch.DragFactor);
                oPacket.WriteEncFloat(SpeedType.ForwardAccelForce + Kart.ForwardAccelForce + FlyingPet.ForwardAccelForce + SpeedPatch.ForwardAccelForce);
                oPacket.WriteEncFloat(SpeedType.BackwardAccelForce + Kart.BackwardAccelForce);
                oPacket.WriteEncFloat(SpeedType.GripBrakeForce + Kart.GripBrakeForce);
                oPacket.WriteEncFloat(SpeedType.SlipBrakeForce + Kart.SlipBrakeForce);
                oPacket.WriteEncFloat(Kart.MaxSteerAngle);
                oPacket.WriteEncFloat(SpeedType.SteerConstraint + Kart.SteerConstraint);
                oPacket.WriteEncFloat(Kart.FrontGripFactor);
                oPacket.WriteEncFloat(Kart.RearGripFactor);
                oPacket.WriteEncFloat(Kart.DriftTriggerFactor);
                oPacket.WriteEncFloat(Kart.DriftTriggerTime);
                oPacket.WriteEncFloat(Kart.DriftSlipFactor);
                oPacket.WriteEncFloat(SpeedType.DriftEscapeForce + Kart.DriftEscapeForce + FlyingPet.DriftEscapeForce + SpeedPatch.DriftEscapeForce);
                oPacket.WriteEncFloat(SpeedType.CornerDrawFactor + Kart.CornerDrawFactor + FlyingPet.CornerDrawFactor + SpeedPatch.CornerDrawFactor);
                oPacket.WriteEncFloat(Kart.DriftLeanFactor);
                oPacket.WriteEncFloat(Kart.SteerLeanFactor);
                if (StartGameData.StartTimeAttack_SpeedType == 4 || StartGameData.StartTimeAttack_SpeedType == 6)
                {
                    oPacket.WriteEncFloat(GameType.S4_DriftMaxGauge);
                }
                else
                {
                    oPacket.WriteEncFloat(SpeedType.DriftMaxGauge + Kart.DriftMaxGauge + SpeedPatch.DriftMaxGauge);
                }
                if (StartGameData.StartTimeAttack_SpeedType == 6)
                {
                    oPacket.WriteEncFloat(GameType.S6_BoosterTime);
                }
                else
                {
                    oPacket.WriteEncFloat(Kart.NormalBoosterTime + FlyingPet.NormalBoosterTime);
                }
                oPacket.WriteEncFloat(Kart.ItemBoosterTime + FlyingPet.ItemBoosterTime);
                if (StartGameData.StartTimeAttack_SpeedType == 6)
                {
                    oPacket.WriteEncFloat(GameType.S6_BoosterTime);
                }
                else
                {
                    oPacket.WriteEncFloat(Kart.TeamBoosterTime + FlyingPet.TeamBoosterTime);
                }
                oPacket.WriteEncFloat(Kart.AnimalBoosterTime);
                oPacket.WriteEncFloat(Kart.SuperBoosterTime);
                oPacket.WriteEncFloat(SpeedType.TransAccelFactor + Kart.TransAccelFactor + SpeedPatch.TransAccelFactor);
                oPacket.WriteEncFloat(SpeedType.BoostAccelFactor + Kart.BoostAccelFactor + SpeedPatch.BoostAccelFactor);
                oPacket.WriteEncFloat(Kart.StartBoosterTimeItem);
                oPacket.WriteEncFloat(Kart.StartBoosterTimeSpeed);
                oPacket.WriteEncFloat(SpeedType.StartForwardAccelForceItem + Kart.StartForwardAccelForceItem + FlyingPet.StartForwardAccelForceItem + SpeedPatch.StartForwardAccelForceItem);
                oPacket.WriteEncFloat(SpeedType.StartForwardAccelForceSpeed + Kart.StartForwardAccelForceSpeed + FlyingPet.StartForwardAccelForceSpeed + SpeedPatch.StartForwardAccelForceSpeed);
                oPacket.WriteEncFloat(Kart.DriftGaguePreservePercent);
                oPacket.WriteEncByte((byte)((Kart.UseExtendedAfterBooster ? 1 : 0)));
                oPacket.WriteEncFloat(Kart.BoostAccelFactorOnlyItem);
                oPacket.WriteEncFloat(Kart.antiCollideBalance);
                oPacket.WriteEncByte((byte)((Kart.dualBoosterSetAuto ? 1 : 0)));
                oPacket.WriteEncInt(Kart.dualBoosterTickMin);
                oPacket.WriteEncInt(Kart.dualBoosterTickMax);
                oPacket.WriteEncFloat(Kart.dualMulAccelFactor);
                oPacket.WriteEncFloat(Kart.dualTransLowSpeed);
                oPacket.WriteEncByte((byte)((Kart.PartsEngineLock ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.PartsWheelLock ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.PartsSteeringLock ? 1 : 0)));
                oPacket.WriteEncByte((byte)((Kart.PartsBoosterLock ? 1 : 0)));
                //------------------------------------------------------------------------KartSpac End
                oPacket.WriteByte(0);
                oPacket.WriteInt(0);
                oPacket.WriteInt(0);
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void KartSpecLog()
        {
            Console.WriteLine();
            Console.WriteLine("DragFactor: {0}", SpeedType.DragFactor + Kart.DragFactor + FlyingPet.DragFactor + SpeedPatch.DragFactor);
            Console.WriteLine("ForwardAccelForce: {0}", SpeedType.ForwardAccelForce + Kart.ForwardAccelForce + FlyingPet.ForwardAccelForce + TuneSpec.Plant_ForwardAccelForce + TuneSpec.KartLevel_ForwardAccelForce + SpeedPatch.ForwardAccelForce);
            Console.WriteLine("BackwardAccelForce: {0}", SpeedType.BackwardAccelForce + Kart.BackwardAccelForce);
            Console.WriteLine("GripBrakeForce: {0}", SpeedType.GripBrakeForce + Kart.GripBrakeForce + TuneSpec.Plant_GripBrakeForce);
            Console.WriteLine("SlipBrakeForce: {0}", SpeedType.SlipBrakeForce + Kart.SlipBrakeForce);
            Console.WriteLine();
            Console.WriteLine("SteerConstraint: {0}", SpeedType.SteerConstraint + Kart.SteerConstraint);
            Console.WriteLine();
            Console.Write("DriftEscapeForce: {0}", SpeedType.DriftEscapeForce + Kart.DriftEscapeForce + FlyingPet.DriftEscapeForce + TuneSpec.Tune_DriftEscapeForce + TuneSpec.Plant_DriftEscapeForce + TuneSpec.KartLevel_DriftEscapeForce + SpeedPatch.DriftEscapeForce);
            Console.Write(" (T:{0} P:{1} K:{2})", TuneSpec.Tune_DriftEscapeForce, TuneSpec.Plant_DriftEscapeForce, TuneSpec.KartLevel_DriftEscapeForce);
            Console.WriteLine();
            Console.WriteLine("CornerDrawFactor: {0}", SpeedType.CornerDrawFactor + Kart.CornerDrawFactor + FlyingPet.CornerDrawFactor + TuneSpec.Plant_CornerDrawFactor + TuneSpec.KartLevel_CornerDrawFactor + SpeedPatch.CornerDrawFactor);
            Console.WriteLine();
            if (StartGameData.StartTimeAttack_SpeedType == 4 || StartGameData.StartTimeAttack_SpeedType == 6)
            {
                Console.WriteLine("DriftMaxGauge: {0}", GameType.S4_DriftMaxGauge);
            }
            else
            {
                Console.WriteLine("DriftMaxGauge: {0}", SpeedType.DriftMaxGauge + Kart.DriftMaxGauge + TuneSpec.Plant_DriftMaxGauge + SpeedPatch.DriftMaxGauge);
            }
            if (StartGameData.StartTimeAttack_SpeedType == 6)
            {
                Console.WriteLine("NormalBoosterTime: {0}", GameType.S6_BoosterTime);
            }
            else
            {
                Console.Write("NormalBoosterTime: {0}", Kart.NormalBoosterTime + FlyingPet.NormalBoosterTime + TuneSpec.Plant_NormalBoosterTime);
                Console.Write(" (P:{0})", TuneSpec.Plant_NormalBoosterTime);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("TransAccelFactor: {0}", SpeedType.TransAccelFactor + Kart.TransAccelFactor + TuneSpec.Tune_TransAccelFactor + TuneSpec.Plant_TransAccelFactor + TuneSpec.KartLevel_TransAccelFactor + SpeedPatch.TransAccelFactor);
            Console.Write(" (T:{0} P:{1} K:{2})", TuneSpec.Tune_TransAccelFactor, TuneSpec.Plant_TransAccelFactor, TuneSpec.KartLevel_TransAccelFactor);
            Console.WriteLine();
            Console.WriteLine("BoostAccelFactor: {0}", SpeedType.BoostAccelFactor + Kart.BoostAccelFactor + SpeedPatch.BoostAccelFactor);
            Console.WriteLine();
            Console.WriteLine("StartForwardAccelForceItem: {0}", SpeedType.StartForwardAccelForceItem + Kart.StartForwardAccelForceItem + FlyingPet.StartForwardAccelForceItem + SpeedPatch.StartForwardAccelForceItem);
            Console.WriteLine("StartForwardAccelForceSpeed: {0}", SpeedType.StartForwardAccelForceSpeed + Kart.StartForwardAccelForceSpeed + FlyingPet.StartForwardAccelForceSpeed + SpeedPatch.StartForwardAccelForceSpeed);
            Console.WriteLine();
        }
    }
}