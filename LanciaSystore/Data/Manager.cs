using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanciaSystore.Data;

[AddINotifyPropertyChangedInterface]
internal class Manager
{
	TestConnessione _testConn;
	public ObservableCollection<string> ListDataSource { get; set; } = new();

	public ObservableCollection<string> ListMaster { get; set; } = new();
	public ObservableCollection<string> ListDatabase { get; set; } = new();
	public ObservableCollection<string> ListCommonFolder { get; set; } = new();

	public string SelectedDb
	{
		get;
		set;
	}
	public string SelectedDataSource { get; set; }

	public string SelectedMaster
	{
		get;
		set;
	}

	public bool DbUpdateEnable { get; set; }
	public string SelectedCommon { get; set; }

	public Manager()
	{

		var settingManager = new SettingManager();
		var settPrivate = settingManager.ReadSetting();


		Directory = settPrivate.Directory;
		if (string.IsNullOrEmpty(Directory))
			Directory = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(
			 GetExecutingDirectoryName()), "DATABASE");

		SelectedDataSource = settPrivate.InstanzaSql;

		var settPubl = settingManager.ReadPublicSetting();
		foreach (var item in settPubl.InstanzeSql)
		{
			ListDataSource.Add(item);

		}


		LoadCommonFolder();

		if (string.IsNullOrEmpty(SelectedDataSource))
		{
			if (ListDataSource.Count > 0)
			{
				SelectedDataSource = ListDataSource.FirstOrDefault();
			}
		}
		if (SelectedDataSource.Length > 0)
		{
			ReadDataInstanzaSql(SelectedDataSource);

			if (ListDatabase.Count >= 0 && SelectedDb == "")
			{
				SelectedDb = settPrivate.Database;
			}

			if (ListMaster.Count >= 0)
			{
				SelectedMaster = settPrivate.Master;
			}
			if (ListCommonFolder.Count >= 0)
			{
				SelectedCommon = settPrivate.CommonFolder;
			}
		}
	}
	private static string GetExecutingDirectoryName()
	{
		var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
		return new FileInfo(location.AbsolutePath).Directory.FullName;
	}
	public string Directory { get; set; }
	public void ReadDataInstanzaSql(string dataSourceName)
	{
		ListDatabase.Clear();
		ListMaster.Clear();
		_testConn = new TestConnessione(dataSourceName);
		if (_testConn.InstanceData == null)
		{
			MessageBox.Show("Connessione non riuscita");
			return;
		}

		RefreshDbList();
		var settingManager = new SettingManager();
		var publicSett = settingManager.ReadPublicSetting();
		if (!publicSett.InstanzeSql.Contains(dataSourceName))
		{
			publicSett.InstanzeSql.Add(dataSourceName);
			settingManager.SaveSetting(publicSett);
		}

	}
	public void LoadCommonFolder()
	{
		foreach (var item in
		  System.IO.Directory.GetDirectories(Directory, "*"
		  , System.IO.SearchOption.TopDirectoryOnly)

		  .Select(a => new System.IO.DirectoryInfo(a)).Where(a => a.Attributes != System.IO.FileAttributes.Hidden
		  && a.Attributes != System.IO.FileAttributes.Encrypted).ToList()
		  .Where(a => !a.Name.Contains("DevExpress_") && !a.Name.Contains("SLBin")
		  && !a.Name.Contains("Multimedia")
		  && !a.Name.StartsWith("SL", StringComparison.InvariantCultureIgnoreCase)
		  && !a.Name.Contains(".svn")
		  && !a.Name.Contains("Database")
		  && !a.Name.Contains(".vs")
		  && !a.Name.Contains("Device")
		  && !a.Name.Contains("Documenti")
		  && !a.Name.Contains("Layout")
		  && !a.Name.EndsWith("APP4", StringComparison.InvariantCultureIgnoreCase)
		  && !a.Name.Equals("_Developers", StringComparison.InvariantCultureIgnoreCase)
		  && !a.Name.Equals("_Patches", StringComparison.InvariantCultureIgnoreCase)
		  && !a.Name.Equals("Setup", StringComparison.InvariantCultureIgnoreCase)
		  && !a.Name.Contains("Simula")
		  && !a.Name.Contains("CefSharp")
		  && !a.Name.Contains("Directx", StringComparison.InvariantCultureIgnoreCase)
		  && !a.Name.Contains("Common_mops", StringComparison.InvariantCultureIgnoreCase)
		  && !a.Name.Contains("runtimes", StringComparison.InvariantCultureIgnoreCase)


		  )
		  .ToList()

		  )
		{
			ListCommonFolder.Add(item.Name);
		}

	}
	public void ApplyDebug()
	{

		_testConn.ApplyDebug(SelectedDb);
	}
	public void AddMaster()
	{
		if (string.IsNullOrEmpty(SelectedMaster))
		{
			try
			{
				_testConn.AddMaster(SelectedDb);
				_testConn.RefreshMaster(SelectedDb);
			}
			catch (SqlException ex)
			{

				MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			RefreshListMaster();
		}
	}
	public void RefreshListMaster()
	{
		var list = new List<string>();
		try
		{

			if (string.IsNullOrEmpty(this.SelectedDb))
				return;

			var selectedDb = SelectedDb;

			foreach (var item in _testConn.InstanceData.DbList.Where(a => a.Database == selectedDb).First()
			  .MasterName)
			{
				list.Add(item);
			}

		}
		finally
		{
			ListMaster = new ObservableCollection<string>(list);

		}

	}


	/// <summary>
	/// filtra i database se quello della sottocartella database è presente sulla lista
	/// </summary>
	public void RefreshDbList()
	{
		var listDb = new List<string>();
		try
		{

			List<string> listDbFolder = new List<string>();
			var path = System.IO.Path.Combine(
			  Directory, "Database");
			if (System.IO.Directory.Exists(path))
			{
				listDbFolder = System.IO.Directory.EnumerateDirectories(path, "WS*", System.IO.SearchOption.TopDirectoryOnly)

				  .Select(a => new System.IO.DirectoryInfo(a).Name).ToList();

				listDbFolder.RemoveAll(a => a.EndsWith("_HISTORY", StringComparison.InvariantCultureIgnoreCase)
				  ||
				  a.EndsWith("_IMPEXP", StringComparison.InvariantCultureIgnoreCase)
					||
				  a.EndsWith("_HELP", StringComparison.InvariantCultureIgnoreCase)
				);
				if (listDbFolder.Any() && listDbFolder.Count() > 1)
				{
					listDbFolder.RemoveAll(a => !a.Equals(listDbFolder[0]));
				}
			}
			var list = _testConn.InstanceData.DbList.Select(a => a.Database).ToList();
			foreach (var item in list.Where(a =>
			!listDbFolder.Any() || (listDbFolder.Any() && a.Contains(listDbFolder.FirstOrDefault()))).OrderBy(a => a))
			{
				listDb.Add(item);
			}

			DbUpdateEnable = ListDatabase.Count > 0;

		}
		finally
		{
			this.ListDatabase = new ObservableCollection<string>(listDb);
		}
	}
}
