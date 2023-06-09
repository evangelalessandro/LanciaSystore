using LanciaSystore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace LanciaSystore
{
	public partial class frmMain : Form
	{
		internal Manager Manager { get; set; } = new Manager();


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
			settingManager.SaveSetting(sett);

		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			Manager.ReadDataInstanzaSql(
			txtDataSource.Text);

		}



		private void lstDatabase_SelectedIndexChanged(object sender, EventArgs e)
		{
			Manager.SelectedDb = lstDatabase.Text;
			Manager.RefreshListMaster();
		}


		private void btnAvvia_Click(object sender, EventArgs e)
		{
			var exe = new Exe_SystemLogisticsApp4();
			exe.StrartProc(txtDataSource.Text, lstMaster.Text, lstCommonFolder.Text, lstDatabase.Text, lstDatabase.Text);


		}

		private void frmMain_Load(object sender, EventArgs e)
		{

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
			exe.StrartProc(txtDataSource.Text, lstDatabase.Text);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Manager.ReadDataInstanzaSql(
			cbodataSource.Text);

		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			ManageNewSp.CreateNewFileSp(txtDataSource.Text, lstDatabase.Text, System.Reflection.Assembly.GetExecutingAssembly().Location);
		}
	}
}

