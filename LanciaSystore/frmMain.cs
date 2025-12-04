using LanciaSystore.Manager;
using System;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanciaSystore
{
	public partial class frmMain : Form
	{
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		internal UIManager Manager { get; set; }
		private frmProgress _frm;
		/// <summary>
		/// Form principale
		/// </summary>
		public frmMain()
		{
			InitializeComponent();


			this.Load += FrmMain_Load;
			txtDirectory.SelectedIndexChanged += (a, e) =>
			{
				Manager.DirectoryProgettoCorrente = txtDirectory.Text;
			};
		}

		private void Manager_ProgressUpdate(object sender, ProgressUpdateEventArgs e)
		{

			if (_frm == null || _frm.IsDisposed)
			{
				_frm = new frmProgress();
				_frm.Show(this);
			}


			_frm.UpdateProgress(e.Percentage, e.Message);

			if (e.Percentage == 100)
			{
				_frm.Close();
				_frm = null;
			}

		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			this.FormClosing += Form1_FormClosing;

			Manager = new();
			Manager.ProgressUpdate += Manager_ProgressUpdate;



			CheckEnableAvvia();
			BindDatasource();

			var obj = ((INotifyPropertyChanged)Manager);
			obj.PropertyChanged += (a, e) =>
			{
				Debug.WriteLine("Changed:" + e.PropertyName);
			};

			txtDirectory.Text = Manager.DirectoryProgettoCorrente;


			Manager.DirectoryProgettoCorrente = txtDirectory.Text;
			btnLeggiFileCommon.Enabled = false;

			this.Text = Assembly.GetExecutingAssembly().GetName().Name + " " + typeof(LanciaSystore.frmMain).Assembly.GetName().Version;

			btnPacchettoSvn.Click += BtnPacchettoSvn_Click;

		}

		private void BtnPacchettoSvn_Click(object sender, EventArgs e)
		{
			ManagePacchettoSvn.CreaPacchetto(Manager.DirectoryProgettoCorrente);
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
				txtDirectory.DataBindings.Clear();
				cbodataSource.DataSource = null;

				var settingManager = new SettingManager();
				var settPrivate = settingManager.ReadSetting();



				txtDataSource.DataBindings.Add("Text", Manager, "SelectedDataSource");
				cbodataSource.DataBindings.Add("DataSource", Manager, "ListDataSource");
				//cbodataSource.DataBindings.Add("Text", Manager, "SelectedDataSource");

				lstDatabase.DataBindings.Add("DataSource", Manager, "ListDatabase");

				txtDirectory.DataBindings.Add("DataSource", Manager, "DirectoryListItems");

				Manager.DirectoryProgettoCorrente = settPrivate.Directory;

				lstMaster.DataBindings.Add("DataSource", Manager, "ListMaster");

				lstCommonFolder.DataBindings.Add("DataSource", Manager, "ListCommonFolder");
				Debug.WriteLine("manager Items :" + Manager.ListCommonFolder.Count.ToString());
				Debug.WriteLine("listcommon Items :" + lstCommonFolder.Items.Count.ToString());
				lstCommonFolder.Update();
				lstMaster.SelectedIndexChanged += LstMaster_SelectedIndexChanged;
			}
			catch (Exception ex)
			{


			}
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
			var exe = new Exe_SystemLogisticsApp4(Manager.DirectoryProgettoCorrente);
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
			var fileCom = new FileCommonManager(Manager.SelectedDataSource, Manager.SelectedDb, Manager.DirectoryProgettoCorrente + @"\" + lstCommonFolder.Text);
			await fileCom.ManageCommonFile();

			btnLeggiFileCommon.Enabled = true;

		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			Manager.RemoveDatasource(cbodataSource.Text);

			BindDatasource();
			cbodataSource.SelectedIndex = 0;

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

		private void btnCartella_Click(object sender, EventArgs e)
		{

			using (var dialog = new FolderBrowserDialog())
			{
				dialog.Description = "Seleziona la cartella di lavoro dove cercare progetti";
				dialog.SelectedPath = txtDirectory.Text;

				if (dialog.ShowDialog() == DialogResult.OK)
				{
					Manager.DirectoryRoot = dialog.SelectedPath;

				}
			}

		}
	}
}

