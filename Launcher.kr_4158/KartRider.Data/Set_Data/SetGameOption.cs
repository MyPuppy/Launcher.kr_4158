using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Set_Data
{
    public static class SetGameOption
    {
        public static float Set_BGM = 1f;
        public static float Set_Sound = 1f;
        public static byte Old_BGM = 0;
        public static byte Sound_effect = 1;
        public static byte Full_screen = 1;
        public static byte Unk1 = 1;
        public static byte Unk2 = 1;
        public static byte Unk3 = 1;
        public static byte Unk4 = 1;
        public static byte Unk5 = 0;
        public static byte Unk6 = 0;
        public static byte Unk7 = 0;
        public static byte Unk8 = 0;
        public static byte Unk9 = 1;
        public static byte Unk10 = 1;
        public static byte Unk11 = 14; //녹화 품질
        public static byte BGM_Check = 1;
        public static byte Sound_Check = 1;
        public static byte Unk12 = 1;
        public static byte Unk13 = 1;

        public static void Save_SetGameOption()
        {
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Set_BGM + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Set_BGM);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Set_Sound + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Set_Sound);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Old_BGM + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Old_BGM);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Sound_effect + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Sound_effect);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Full_screen + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Full_screen);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk1 + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Unk1);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk2 + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Unk2);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk3 + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Unk3);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk4 + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Unk4);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk5 + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Unk5);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk6 + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Unk6);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk7 + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Unk7);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk8 + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Unk8);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk9 + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Unk9);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk10 + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Unk10);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk11 + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Unk11);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_BGM_Check + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.BGM_Check);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Sound_Check + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Sound_Check);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk12 + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Unk12);
            }
            using (StreamWriter streamWriter = new StreamWriter(FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk13 + FileName.Extension, false))
            {
                streamWriter.Write(SetGameOption.Unk13);
            }
        }

        public static void Load_SetGameOption()
        {
            string Load_Set_BGM = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Set_BGM + FileName.Extension;
            if (File.Exists(Load_Set_BGM))
            {
                string textValue = System.IO.File.ReadAllText(Load_Set_BGM);
                SetGameOption.Set_BGM = float.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Set_BGM, false))
                {
                    streamWriter.Write(SetGameOption.Set_BGM);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Set_Sound = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Set_Sound + FileName.Extension;
            if (File.Exists(Load_Set_Sound))
            {
                string textValue = System.IO.File.ReadAllText(Load_Set_Sound);
                SetGameOption.Set_Sound = float.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Set_Sound, false))
                {
                    streamWriter.Write(SetGameOption.Set_Sound);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Old_BGM = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Old_BGM + FileName.Extension;
            if (File.Exists(Load_Old_BGM))
            {
                string textValue = System.IO.File.ReadAllText(Load_Old_BGM);
                SetGameOption.Old_BGM = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Old_BGM, false))
                {
                    streamWriter.Write(SetGameOption.Old_BGM);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Sound_effect = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Sound_effect + FileName.Extension;
            if (File.Exists(Load_Sound_effect))
            {
                string textValue = System.IO.File.ReadAllText(Load_Sound_effect);
                SetGameOption.Sound_effect = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Sound_effect, false))
                {
                    streamWriter.Write(SetGameOption.Sound_effect);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Full_screen = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Full_screen + FileName.Extension;
            if (File.Exists(Load_Full_screen))
            {
                string textValue = System.IO.File.ReadAllText(Load_Full_screen);
                SetGameOption.Full_screen = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Full_screen, false))
                {
                    streamWriter.Write(SetGameOption.Full_screen);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk1 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk1 + FileName.Extension;
            if (File.Exists(Load_Unk1))
            {
                string textValue = System.IO.File.ReadAllText(Load_Unk1);
                SetGameOption.Unk1 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk1, false))
                {
                    streamWriter.Write(SetGameOption.Unk1);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk2 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk2 + FileName.Extension;
            if (File.Exists(Load_Unk2))
            {
                string textValue = System.IO.File.ReadAllText(Load_Unk2);
                SetGameOption.Unk2 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk2, false))
                {
                    streamWriter.Write(SetGameOption.Unk2);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk3 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk3 + FileName.Extension;
            if (File.Exists(Load_Unk3))
            {
                string textValue = System.IO.File.ReadAllText(Load_Unk3);
                SetGameOption.Unk3 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk3, false))
                {
                    streamWriter.Write(SetGameOption.Unk3);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk4 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk4 + FileName.Extension;
            if (File.Exists(Load_Unk4))
            {
                string textValue = System.IO.File.ReadAllText(Load_Unk4);
                SetGameOption.Unk4 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk4, false))
                {
                    streamWriter.Write(SetGameOption.Unk4);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk5 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk5 + FileName.Extension;
            if (File.Exists(Load_Unk5))
            {
                string textValue = System.IO.File.ReadAllText(Load_Unk5);
                SetGameOption.Unk5 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk5, false))
                {
                    streamWriter.Write(SetGameOption.Unk5);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk6 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk6 + FileName.Extension;
            if (File.Exists(Load_Unk6))
            {
                string textValue = System.IO.File.ReadAllText(Load_Unk6);
                SetGameOption.Unk6 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk6, false))
                {
                    streamWriter.Write(SetGameOption.Unk6);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk7 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk7 + FileName.Extension;
            if (File.Exists(Load_Unk7))
            {
                string textValue = System.IO.File.ReadAllText(Load_Unk7);
                SetGameOption.Unk7 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk7, false))
                {
                    streamWriter.Write(SetGameOption.Unk7);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk8 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk8 + FileName.Extension;
            if (File.Exists(Load_Unk8))
            {
                string textValue = System.IO.File.ReadAllText(Load_Unk8);
                SetGameOption.Unk8 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk8, false))
                {
                    streamWriter.Write(SetGameOption.Unk8);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk9 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk9 + FileName.Extension;
            if (File.Exists(Load_Unk9))
            {
                string textValue = System.IO.File.ReadAllText(Load_Unk9);
                SetGameOption.Unk9 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk9, false))
                {
                    streamWriter.Write(SetGameOption.Unk9);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk10 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk10 + FileName.Extension;
            if (File.Exists(Load_Unk10))
            {
                string textValue = System.IO.File.ReadAllText(Load_Unk10);
                SetGameOption.Unk10 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk10, false))
                {
                    streamWriter.Write(SetGameOption.Unk10);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk11 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk11 + FileName.Extension;
            if (File.Exists(Load_Unk11))
            {
                string textValue = System.IO.File.ReadAllText(Load_Unk11);
                SetGameOption.Unk11 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk11, false))
                {
                    streamWriter.Write(SetGameOption.Unk11);
                }
            }
            //-------------------------------------------------------------------------
            string Load_BGM_Check = FileName.SetGameOption_LoadFile + FileName.SetGameOption_BGM_Check + FileName.Extension;
            if (File.Exists(Load_BGM_Check))
            {
                string textValue = System.IO.File.ReadAllText(Load_BGM_Check);
                SetGameOption.BGM_Check = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_BGM_Check, false))
                {
                    streamWriter.Write(SetGameOption.BGM_Check);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Sound_Check = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Sound_Check + FileName.Extension;
            if (File.Exists(Load_Sound_Check))
            {
                string textValue = System.IO.File.ReadAllText(Load_Sound_Check);
                SetGameOption.Sound_Check = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Sound_Check, false))
                {
                    streamWriter.Write(SetGameOption.Sound_Check);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk12 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk12 + FileName.Extension;
            if (File.Exists(Load_Unk12))
            {
                string textValue = System.IO.File.ReadAllText(Load_Unk12);
                SetGameOption.Unk12 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk12, false))
                {
                    streamWriter.Write(SetGameOption.Unk12);
                }
            }
            //-------------------------------------------------------------------------
            string Load_Unk13 = FileName.SetGameOption_LoadFile + FileName.SetGameOption_Unk13 + FileName.Extension;
            if (File.Exists(Load_Unk13))
            {
                string textValue = System.IO.File.ReadAllText(Load_Unk13);
                SetGameOption.Unk13 = byte.Parse(textValue);
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Load_Unk13, false))
                {
                    streamWriter.Write(SetGameOption.Unk13);
                }
            }
        }
    }
}