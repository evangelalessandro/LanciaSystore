using System;
using System.Linq;
using System.Windows.Forms;

namespace LanciaSystore
{
	internal class Exe_SystemLogisticsApp4
	{
		public static string NameFile = "SystemLogisticsApp4.exe";
		private System.IO.FileInfo _fileExe;
		public Exe_SystemLogisticsApp4()
		{
			ExistsExe();
		}

		public bool ExistsExe()
		{
			_fileExe = new System.IO.DirectoryInfo(Environment.CurrentDirectory).EnumerateFiles(NameFile).FirstOrDefault();
			if (_fileExe == null)
				return false;
			return true;

		}

		public void StrartProc(string sqlserverInstance, string MasterName, string CommonFolder, string plantName, string database)
		{
			if (!ExistsExe())
			{
				MessageBox.Show("Manca l'eseguibile");
				return;
			}
			string parameter = "";
			parameter = "PathFilesCommon={Common};DataSource={ServerSql};" +
				"InitialCatalog={DB};Name={MASTER};PlantName={PLANTNAME};USER=SYSTEM";

			parameter = parameter.Replace("{Common}", CommonFolder);
			parameter = parameter.Replace("{ServerSql}", sqlserverInstance);
			parameter = parameter.Replace("{MASTER}", MasterName);
			parameter = parameter.Replace("{PLANTNAME}", plantName);
			parameter = parameter.Replace("{DB}", database);


			var proc = new System.Diagnostics.Process();
			proc.StartInfo.FileName = _fileExe.FullName;
			proc.StartInfo.Arguments = parameter;
			proc.Start();


			var settingManager = new SettingManager();
			var publicSett = settingManager.ReadPublicSetting();
			if (!publicSett.Lanci.Where(a => a.ExeFilePath == _fileExe.FullName &&
			a.Argument == parameter).Any())
			{
				publicSett.Lanci.Add(new Settings.DatiLancio() { ExeFilePath = _fileExe.FullName, Argument = parameter });
				settingManager.SaveSetting(publicSett);
			}
		}
	}
}
