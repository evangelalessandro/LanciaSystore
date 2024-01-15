using LanciaSystore.Manager;
using System;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanciaSystore
{
	public partial class frmMain : Form
	{
		internal UIManager Manager { get; set; } = new();

		/// <summary>
		/// Form principale
		/// </summary>
		public frmMain()
		{
			InitializeComponent();
			this.FormClosing += Form1_FormClosing;

			CheckEnableAvvia();
			BindDatasource();

			var obj = ((INotifyPropertyChanged)Manager);
			obj.PropertyChanged += (a, e) =>
			{
				Debug.WriteLine("Changed:" + e.PropertyName);
			};

			txtDirectory.Text = Manager.Directory;

			txtDirectory.TextChanged += TxtDirectory_TextChanged;
			Manager.Directory = txtDirectory.Text;
			btnLeggiFileCommon.Enabled = false;

			this.Text = Assembly.GetExecutingAssembly().GetName().Name + " " + typeof(LanciaSystore.frmMain).Assembly.GetName().Version;
		}
		private void BindDatasource()
		{
			try
			{


				lstMaster.SelectedIndexChanged -= LstMaster_SelectedIndexChanged;
				txtDataSource.DataBindings.Clear();
				cbodataSource.DataBindings.Clear();
				lstDatabase.DataBindings.Clear();
				lstMaster.DataBindings.Clear();
				lstCommonFolder.DataBindings.Clear();

				txtDataSource.DataBindings.Add("Text", Manager, "SelectedDataSource");
				cbodataSource.DataBindings.Add("DataSource", Manager, "ListDataSource");
				//cbodataSource.DataBindings.Add("Text", Manager, "SelectedDataSource");

				lstDatabase.DataBindings.Add("DataSource", Manager, "ListDatabase");

				lstMaster.DataBindings.Add("DataSource", Manager, "ListMaster");

				lstCommonFolder.DataBindings.Add("DataSource", Manager, "ListCommonFolder");
				Debug.WriteLine("manager Items :" + Manager.ListCommonFolder.Count.ToString());
				Debug.WriteLine("listcommon Items :" + lstCommonFolder.Items.Count.ToString());
				lstCommonFolder.Update();
				lstMaster.SelectedIndexChanged += LstMaster_SelectedIndexChanged;
			}
			catch (Exception)
			{


			}
		}
		private void TxtDirectory_TextChanged(object sender, EventArgs e)
		{
			Manager.Directory = txtDirectory.Text;
			Manager.RefreshDbList();

		}

		private void LstMaster_SelectedIndexChanged(object sender, EventArgs e)
		{
			Manager.SelectedMaster = lstMaster.Text;

			CheckEnableAvvia();

		}

		private void CheckEnableAvvia()
		{
			btnAvvia.Enabled = Manager.SelectedMaster != null && (Manager.SelectedMaster.Length > 0);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Manager.SaveSetting();



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
			var exe = new Exe_dbupodate(Manager);
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
			await NewSpManager.CreateNewFileSp(Manager);
			btnControllaFileScompagnati.Enabled = true;

			return true;
		}

		private async void btnLeggiFileCommon_Click(object sender, EventArgs e)
		{
			btnLeggiFileCommon.Enabled = false;
			var fileCom = new FileCommonManager(Manager.SelectedDataSource, Manager.SelectedDb, Manager.Directory + @"\" + lstCommonFolder.Text);
			await fileCom.ManageCommonFile();

			btnLeggiFileCommon.Enabled = true;

		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			Manager.RemoveDatasource(cbodataSource.Text);

			BindDatasource();
			cbodataSource.Refresh();

		}

		private void btnSearchTraslation_Click(object sender, EventArgs e)
		{
			var trad = new SpTranslationGrabberManager(Manager);
			trad.Exec();
		}

		private void btnTraduzioniPkt_Click(object sender, EventArgs e)
		{
			var trad = new FileCommonManagerPKT(Manager);
			trad.Exec();
		}
	}
}

