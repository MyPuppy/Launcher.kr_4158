using KartRider.Common.Utilities;
using KartRider.IO;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KartRider
{
	internal static class Program
	{
		public static Launcher LauncherDlg;
		public static GetKart GetKartDlg;
		public static Options OptionsDlg;
		public static int MAX_EQP_P;
		public static bool UseKartTune;
		public static bool UseKartPlant;
		public static bool UseKartLevel;
		public static bool SpeedPatch;
		public static bool FavoriteItem;
		public static bool PreventItem;
		public static bool Developer_Name;
		public static ushort Version;
		public static string DataTime;

		static Program()
		{
			Program.MAX_EQP_P = 29;
			Program.Developer_Name = true;
			Program.Version = 4158;
			Program.DataTime = "30 A9 00 00"; //2018-08-02
		}

		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Launcher StartLauncher = new Launcher();
			Program.LauncherDlg = StartLauncher;
			Application.Run(StartLauncher);
		}
	}
}