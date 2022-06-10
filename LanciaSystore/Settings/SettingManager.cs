using LanciaSystore.Settings;
using Newtonsoft.Json;
using System;
using System.IO;
using static System.Environment;

namespace LanciaSystore
{
	internal class SettingManager
	{
		private readonly string _PathSetting = Environment.CurrentDirectory + @"\Setting.xml";
		private readonly string _PathPublic = Path.Combine(
					Environment.GetFolderPath(SpecialFolder.CommonApplicationData),
					"SystemStarter");
		public UserSettings ReadSetting()
		{
			UserSettings setting;
			if (File.Exists(_PathSetting))
			{
				var json = File.ReadAllText(_PathSetting);
				setting = JsonConvert.DeserializeObject<UserSettings>(json);
			}
			else
			{
				setting = new UserSettings();
			}
			return setting;
		}

		public void SaveSetting(UserSettings settings)
		{

			File.WriteAllText(_PathSetting,
				JsonConvert.SerializeObject(settings));
		}

		public PublicSetting ReadPublicSetting()
		{
			PublicSetting setting;
			if (File.Exists(_PathPublic))
			{
				var json = File.ReadAllText(_PathPublic);
				setting = JsonConvert.DeserializeObject<PublicSetting>(json);
			}
			else
			{
				setting = new PublicSetting();
			}
			return setting;
		}

		public void SaveSetting(PublicSetting settings)
		{

			File.WriteAllText(_PathPublic,
				JsonConvert.SerializeObject(settings));
		}
	}
}
