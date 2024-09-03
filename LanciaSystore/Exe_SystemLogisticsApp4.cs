using LanciaSystore.Manager;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LanciaSystore
{
	internal class Exe_SystemLogisticsApp4
	{
		public static string NameFile = "SystemLogisticsApp4.exe";
		private System.IO.FileInfo _fileExe;
		private string _directory;
		public Exe_SystemLogisticsApp4(string directory)
		{
			_directory = directory;
			ExistsExe();
		}

		public bool ExistsExe()
		{
			_fileExe = new System.IO.DirectoryInfo(_directory).EnumerateFiles(NameFile).FirstOrDefault();
			if (_fileExe == null)
				return false;
			return true;

		}
		public void StrartProc(UIManager manager)
		{
			StrartProc(manager.SelectedDataSource, manager.SelectedMaster, manager.SelectedCommon, manager.SelectedDb, manager.SelectedDb);
		}
		private void StrartProc(string sqlserverInstance, string MasterName, string commonFolder, string plantName, string database)
		{
			if (!ExistsExe())
			{
				MessageBox.Show("Manca l'eseguibile");
				return;
			}
			string parameter = "";
			parameter = "PathFilesCommon={Common};DataSource={ServerSql};" +
				"InitialCatalog={DB};Name={MASTER};PlantName={PLANTNAME};USER=SYSTEM;";

			parameter = parameter.Replace("{Common}", commonFolder);
			parameter = parameter.Replace("{ServerSql}", sqlserverInstance);
			parameter = parameter.Replace("{MASTER}", MasterName);
			parameter = parameter.Replace("{PLANTNAME}", plantName);
			parameter = parameter.Replace("{DB}", database);

			Environment.CurrentDirectory = _directory;

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
