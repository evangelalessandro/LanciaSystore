
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanciaSystore.Manager;

[AddINotifyPropertyChangedInterface]
internal class UIManager {
	TestConnessione _testConn;
	public ObservableCollection<string> ListDataSource { get; set; } = new();

	public ObservableCollection<string> ListMaster { get; set; } = new();
	public ObservableCollection<string> ListDatabase { get; set; } = new();
	public ObservableCollection<string> ListCommonFolder { get; set; } = new();



	// Evento ProgressUpdate
	public event EventHandler<ProgressUpdateEventArgs> ProgressUpdate;

	// Metodo per sollevare l'evento
	protected virtual void OnProgressUpdate(int percentage, string message = "") {
		ProgressUpdate?.Invoke(this, new ProgressUpdateEventArgs(percentage, message));
	}


	public string SelectedDb {
		get;
		set;
	}
	public string SelectedDataSource { get; set; }

	public string SelectedMaster {
		get;
		set;
	}

	public bool DbUpdateEnable { get; set; }
	public string SelectedCommon { get; set; }

	public event EventHandler RealoadBind;

	public UIManager() {

		var settingManager = new SettingManager();
		var settPrivate = settingManager.ReadSetting();


		DirectoryProgettoCorrente = settPrivate.Directory;
		if (string.IsNullOrEmpty(DirectoryProgettoCorrente))
			DirectoryProgettoCorrente = Path.Combine(Path.GetDirectoryName(
			 GetExecutingDirectoryName()), "DATABASE");

		SelectedDataSource = settPrivate.InstanzaSql;

		var settPubl = settingManager.ReadPublicSetting();
		foreach (var item in settPubl.InstanzeSql) {
			ListDataSource.Add(item);

		}

		foreach (var item in settPubl.DirectoryList) {
			DirectoryListItems.Add(item);

		}

		LoadCommonFolder();

		if (string.IsNullOrEmpty(SelectedDataSource)) {
			if (ListDataSource.Count > 0) {
				SelectedDataSource = ListDataSource.FirstOrDefault();
			}
		}
		if (SelectedDataSource.Length > 0) {
			ReadDataInstanzaSql(SelectedDataSource);

			if (ListDatabase.Count >= 0 && SelectedDb == "") {
				SelectedDb = settPrivate.Database;
			}

			if (ListMaster.Count >= 0) {
				SelectedMaster = settPrivate.Master;
			}
			if (ListCommonFolder.Count >= 0) {
				SelectedCommon = settPrivate.CommonFolder;
			}
		}
		var notify = this as INotifyPropertyChanged;
		if (notify != null) {
			notify.PropertyChanged += (a, b) => {
				if (b.PropertyName.Contains("DirectoryRoot", StringComparison.InvariantCultureIgnoreCase)) {
					LoadCommonFolder();
					RefreshDbList();
					DiscoverySubFolder();
				}
				if (b.PropertyName.Contains("DirectoryProgettoCorrente", StringComparison.InvariantCultureIgnoreCase)) {
					LoadCommonFolder();
					RefreshDbList();
				}


				if (this.RealoadBind != null)
					RealoadBind(this, new EventArgs());

			};
		}
	}
	private static string GetExecutingDirectoryName() {
		var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
		return new FileInfo(location.AbsolutePath).Directory.FullName;
	}
	public string DirectoryProgettoCorrente {
		get;
		set;
	}
	/// <summary>
	/// Cartella da verificare tutte le sottocartelle
	/// </summary>
	public string DirectoryRoot {
		get;
		set;
	}
	public void ReadDataInstanzaSql(string dataSourceName) {
		ListDatabase.Clear();
		ListMaster.Clear();
		_testConn = new TestConnessione(dataSourceName);
		if (_testConn.InstanceData == null) {
			MessageBox.Show("Connessione non riuscita");
			return;
		}

		RefreshDbList();
		var settingManager = new SettingManager();
		var publicSett = settingManager.ReadPublicSetting();
		if (!publicSett.InstanzeSql.Contains(dataSourceName)) {
			publicSett.InstanzeSql.Add(dataSourceName);
			settingManager.SaveSetting(publicSett);
		}

		SelectedDataSource = dataSourceName;

	}
	public void LoadCommonFolder() {
		var listItem = new List<string>();

		if (System.IO.Directory.Exists(DirectoryProgettoCorrente))
			foreach (var item in
			  System.IO.Directory.GetDirectories(DirectoryProgettoCorrente, "*"
			  , SearchOption.TopDirectoryOnly)

			  .Select(a => new DirectoryInfo(a)).Where(a => a.Attributes != FileAttributes.Hidden
			  && a.Attributes != FileAttributes.Encrypted).ToList()
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
			  && !a.Name.Contains("debug", StringComparison.InvariantCultureIgnoreCase)


			  )
			  .ToList()

			  ) {
				listItem.Add(item.Name);
			}

		ListCommonFolder = new ObservableCollection<string>(listItem);



	}
	public void ApplyDebug() {

		_testConn.ApplyDebug(SelectedDb);
	}
	public void AddMaster() {
		if (string.IsNullOrEmpty(SelectedMaster)) {
			try {
				_testConn.AddMaster(SelectedDb);
				_testConn.RefreshMaster(SelectedDb);
			} catch (SqlException ex) {

				MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			RefreshListMaster();
		}
	}
	public void RefreshListMaster() {
		var list = new List<string>();
		try {

			if (string.IsNullOrEmpty(SelectedDb))
				return;

			var selectedDb = SelectedDb;

			foreach (var item in _testConn.InstanceData.DbList.Where(a => a.Database == selectedDb).First()
			  .MasterName) {
				list.Add(item);
			}

		} finally {
			ListMaster = new ObservableCollection<string>(list);
			if (ListMaster.Count > 0)
				SelectedMaster = list[0];

		}

	}


	/// <summary>
	/// filtra i database se quello della sottocartella database è presente sulla lista
	/// </summary>
	private void RefreshDbList() {
		Cursor.Current = Cursors.WaitCursor;

		var listDb = new List<string>();
		try {

			List<string> listDbFolder = new List<string>();
			var path = Path.Combine(
			  DirectoryProgettoCorrente, "Database");
			if (System.IO.Directory.Exists(path)) {
				listDbFolder = System.IO.Directory.EnumerateDirectories(path, "WS*", SearchOption.TopDirectoryOnly)

				  .Select(a => new DirectoryInfo(a).Name).ToList();

				listDbFolder.RemoveAll(a => a.EndsWith("_HISTORY", StringComparison.InvariantCultureIgnoreCase)
				  ||
				  a.EndsWith("_IMPEXP", StringComparison.InvariantCultureIgnoreCase)
					||
				  a.EndsWith("_HELP", StringComparison.InvariantCultureIgnoreCase)
				);
				if (listDbFolder.Any() && listDbFolder.Count() > 1) {
					listDbFolder.RemoveAll(a => !a.Equals(listDbFolder[0]));
				}
			}
			var list = _testConn.InstanceData.DbList.Select(a => a.Database).ToList();
			foreach (var item in list.Where(a =>
			!listDbFolder.Any() || listDbFolder.Any() && a.Contains(listDbFolder.FirstOrDefault())).OrderBy(a => a)) {
				listDb.Add(item);
			}

			DbUpdateEnable = ListDatabase.Count > 0;

		} finally {
			ListDatabase = new ObservableCollection<string>(listDb);
		}


		Cursor.Current = Cursors.Default;
	}
	public ObservableCollection<string> DirectoryListItems { get; set; } = new ObservableCollection<string>();

	private void DiscoverySubFolder() {
		DiscoverProjectFolder v = new DiscoverProjectFolder();
		v.ProgressUpdate += (a, e) => {
			this.OnProgressUpdate(e.Percentage, e.Message);
		};
		var val = DirectoryListItems;

		v.DiscoverySubFolder(ref val, DirectoryRoot); // Added 'ref' keyword to fix CS1620
		v.ProgressUpdate -= (a, e) => {
			this.OnProgressUpdate(e.Percentage, e.Message);
		};
		v = null;
		DirectoryListItems = val;
	}


	internal void RemoveDatasource(string text) {
		var settingManager = new SettingManager();

		var publicSett = settingManager.ReadPublicSetting();
		if (publicSett.InstanzeSql.Contains(text)) {
			publicSett.InstanzeSql.Remove(text);
			publicSett.InstanzeSql = publicSett.InstanzeSql.Distinct().ToList();
			settingManager.SaveSetting(publicSett);
			settingManager.ReadPublicSetting();

		}
		ListDataSource.Clear();
		foreach (var item in publicSett.InstanzeSql) {
			ListDataSource.Add(item);

		}

	}

	internal void SaveSetting() {
		var settingManager = new SettingManager();
		var sett = settingManager.ReadSetting();
		sett.InstanzaSql = SelectedDataSource;

		sett.Database = SelectedDb;
		sett.Master = SelectedMaster;
		sett.CommonFolder = SelectedCommon;
		sett.Directory = DirectoryProgettoCorrente;
		settingManager.SaveSetting(sett);
	}
}
