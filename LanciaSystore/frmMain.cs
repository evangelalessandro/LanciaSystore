using LanciaSystore.Manager;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanciaSystore
{
	public partial class frmMain : Form
	{
		internal UIManager Manager { get; set; } = new();


		public frmMain()
		{
			InitializeComponent();
			this.FormClosing += Form1_FormClosing;

			lstMaster.SelectedIndexChanged += LstMaster_SelectedIndexChanged;

			CheckEnableAvvia();
			txtDataSource.DataBindings.Add("Text", Manager, "SelectedDataSource");
			cbodataSource.DataBindings.Add("DataSource", Manager, "ListDataSource");
			//cbodataSource.DataBindings.Add("Text", Manager, "SelectedDataSource");

			lstDatabase.DataBindings.Add("DataSource", Manager, "ListDatabase");

			lstMaster.DataBindings.Add("DataSource", Manager, "ListMaster");

			lstCommonFolder.DataBindings.Add("DataSource", Manager, "ListCommonFolder");

			//lstDatabase.DataBindings.Add("Text", Manager, "SelectedDb");
			var obj = ((INotifyPropertyChanged)Manager);
			obj.PropertyChanged += (a, e) =>
			{
				Debug.WriteLine("Changed:" + e.PropertyName);
			};
			//lstCommonFolder.DataBindings.Add("SelectedValue", Manager, "SelectedCommon");
			//lstMaster.DataBindings.Add("SelectedValue", Manager, "SelectedMaster");

			txtDirectory.Text = Manager.Directory;

			txtDirectory.TextChanged += TxtDirectory_TextChanged;
			Manager.Directory = txtDirectory.Text;
			btnLeggiFileCommon.Enabled = false;
		}

		private void TxtDirectory_TextChanged(object sender, EventArgs e)
		{
			Manager.Directory = txtDirectory.Text;
		}

		private void LstMaster_SelectedIndexChanged(object sender, EventArgs e)
		{
			CheckEnableAvvia();

		}

		private void CheckEnableAvvia()
		{
			btnAvvia.Enabled = (lstMaster.Text.Length > 0);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			var settingManager = new SettingManager();
			var sett = settingManager.ReadSetting();
			sett.InstanzaSql = txtDataSource.Text;
			if (lstDatabase.SelectedIndex >= 0)
				sett.Database = lstDatabase.SelectedItem.ToString();
			if (lstMaster.SelectedIndex >= 0)
				sett.Master = lstMaster.SelectedItem.ToString();
			if (lstCommonFolder.SelectedIndex >= 0)
				sett.CommonFolder = lstCommonFolder.SelectedItem.ToString();

			sett.Directory = Manager.Directory;
			settingManager.SaveSetting(sett);

		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			Manager.ReadDataInstanzaSql(txtDataSource.Text);

		}



		private void lstDatabase_SelectedIndexChanged(object sender, EventArgs e)
		{
			Manager.SelectedDb = lstDatabase.Text;
			Manager.RefreshListMaster();
		}


		private void btnAvvia_Click(object sender, EventArgs e)
		{
			var exe = new Exe_SystemLogisticsApp4(Manager.Directory);
			exe.StrartProc(Manager);

		}


		private void addMaster_Click(object sender, EventArgs e)
		{
			Manager.AddMaster();

		}


		private void btnDebug_Click(object sender, EventArgs e)
		{
			Manager.ApplyDebug();
		}

		private void btnDbUpdate_Click(object sender, EventArgs e)
		{
			var exe = new Exe_dbupodate();
			exe.StartProcecure(Manager);
		}

		private void btnLeggiDbCombo_Click(object sender, EventArgs e)
		{
			Manager.ReadDataInstanzaSql(
			cbodataSource.Text);

		}

		private async void btnControllaFileScompagnati_Click(object sender, EventArgs e)
		{
			btnControllaFileScompagnati.Enabled = false;
			await CheckUpdateAsync();
		}
		private async Task<bool> CheckUpdateAsync()
		{
			await NewSpManager.CreateNewFileSp(Manager.SelectedDataSource, lstDatabase.Text, Manager.Directory);
			btnControllaFileScompagnati.Enabled = true;

			return true;
		}

		private async void btnLeggiFileCommon_Click(object sender, EventArgs e)
		{
			btnLeggiFileCommon.Enabled = false;
			var fileCom = new FileCommonManager(Manager.SelectedDataSource, lstDatabase.Text, Manager.Directory + @"\" + lstCommonFolder.Text);
			await fileCom.ManageCommonFile();

			btnLeggiFileCommon.Enabled = true;

		}
	}
}

