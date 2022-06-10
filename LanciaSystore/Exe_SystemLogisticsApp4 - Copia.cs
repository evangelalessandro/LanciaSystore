using System;
using System.Linq;
using System.Windows.Forms;

namespace LanciaSystore
{
	internal class Exe_dbupodate
	{
		public static string NameFile = "DBUpdate.exe";
		private System.IO.FileInfo _fileExe;
		private string FolderDatabase
		{
			get
			{
				return System.IO.Path.Combine(System.IO.Path.GetDirectoryName(
			  System.Reflection.Assembly.GetExecutingAssembly().Location), @"Database");
			}
		}
		public Exe_dbupodate()
		{
			 
		}

		public bool ExistsExe()
		{
			var path = System.IO.Path.Combine(FolderDatabase,@"DBScripting" , NameFile);
			_fileExe = new System.IO.FileInfo(path);
			
			if (_fileExe == null && _fileExe.Exists)
				return false;
			return true;

		}

		public void StrartProc(string sqlserverInstance, string database)
		{
			if (!ExistsExe())
			{
				MessageBox.Show("Manca l'eseguibile");
				return;
			}
			/*"C:\SystemLogistics.net\old\OMSI_VI19IM012\Database\DBScripting\DBUPDATE.EXE" 
			 * - s omsi - sys1\zmagma - u system_itali - p SYS123 - d WSOMSI - f 
			 * "C:\SystemLogistics.net\old\OMSI_VI19IM012\Database\WSOMSI"
			 * */
			string parameter = "";
			parameter = @" - s {ServerSql} - u system_itali - p SYS123 - d {DB} - f {FOLDER}";

			parameter = parameter.Replace("{ServerSql}", sqlserverInstance);
			parameter = parameter.Replace("{FOLDER}", System.IO.Path.Combine(FolderDatabase , database));

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
