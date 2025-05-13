using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanciaSystore.Manager {
	internal class DiscoverProjectFolder {
		// Evento ProgressUpdate
		public event EventHandler<ProgressUpdateEventArgs> ProgressUpdate;

		private bool CheckExistsFolder(string folder) {

			return System.IO.Directory.Exists(folder);

		}
		// Metodo per sollevare l'evento
		protected virtual void OnProgressUpdate(int percentage, string message = "") {
			ProgressUpdate?.Invoke(this, new ProgressUpdateEventArgs(percentage, message));
		}
		internal void DiscoverySubFolder(ref ObservableCollection<string> directoryListItems, string currentFolder) {
			Cursor.Current = Cursors.WaitCursor;
			var listItem = directoryListItems.ToList().Where(a => CheckExistsFolder(a)).ToList();



			if (string.IsNullOrEmpty(currentFolder))
				return;
			int i = 0;
			int count = 0;
			this.OnProgressUpdate(i, "Aggiorno la lista delle cartelle");
			try {

				if (!CheckExistsFolder(currentFolder.Trim()) && listItem.Count > 0)
					currentFolder = listItem.First();
				var list = System.IO.Directory.GetDirectories(currentFolder.Trim(), "Database", System.IO.SearchOption.AllDirectories).OrderBy(a => a).ToList();
				count = list.Count();
				foreach (var file in list.ToList()) {
					//TaskbarManager.Instance.SetProgressValue(i, list.Count());

					if (i > 0) {
						var perc = 100.0 / count * (i);
						if (perc > 100)
							perc = 100;
						this.OnProgressUpdate((int)perc, file);
					} else
						this.OnProgressUpdate(0, file);
					var dir = new System.IO.DirectoryInfo(file);
					var lst = dir.FullName.LastIndexOf(dir.Name);
					var root = dir.FullName.Remove(lst);
					list.Remove(file);
					list.Add(root);

					try {
						if (System.IO.Directory.GetFiles(root, "SystemLogisticsApp4.exe", System.IO.SearchOption.TopDirectoryOnly).Length == 0)
							list.Remove(root);
					} catch (Exception) {

						list.Remove(root);
					}
					i++;

					//file
				}

				foreach (var file in list.ToList()) {
					foreach (var item in listItem) {
						if (new System.IO.FileInfo(file).Directory == new System.IO.FileInfo(item.ToString()).Directory) {
							list.Remove(file);
							break;
						}
					}

				}
				foreach (var file in list.ToList()) {
					listItem.Add(new System.IO.FileInfo(file).Directory.ToString());
				}
				listItem = listItem.OrderBy(dir => dir.Count(c => c == '\\')).ThenBy(dir => dir).Distinct().ToList();


				foreach (var dir in listItem) {
					Debug.WriteLine(dir);
				}
			} catch (Exception ex) {

			} finally {

				if (listItem.Count() != directoryListItems.Count()
					|| listItem.Except(directoryListItems.ToList()).Count() > 0
					|| directoryListItems.Except(listItem.ToList()).Count() > 0) {
					directoryListItems = new ObservableCollection<string>(listItem);
				}

				var settingManager = new SettingManager();

				var publicSett = settingManager.ReadPublicSetting();

				if (publicSett.DirectoryList.Except(directoryListItems.ToList()).Count() > 0
					|| publicSett.DirectoryList.Count() != directoryListItems.Count()
					) {
					publicSett.DirectoryList = directoryListItems.ToList();
					settingManager.SaveSetting(publicSett);
				}
				this.OnProgressUpdate(100);


			}

		}
	}
}
