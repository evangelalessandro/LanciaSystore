using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanciaSystore
{
    public partial class frmMain : Form
    {

        TestConnessione _testConn;
        public frmMain()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;

            var settingManager = new SettingManager();
            var settPrivate = settingManager.ReadSetting();
            txtDataSource.Text = settPrivate.InstanzaSql;

            var settPubl = settingManager.ReadPublicSetting();
            foreach (var item in settPubl.InstanzeSql)
            {
                cbodataSource.Items.Add(item);

            }
            if (cbodataSource.Items.Count > 0)
            {
                cbodataSource.SelectedIndex = 0;
            }

            lstCommonFolder.Items.Clear();

            LoadCommonFolder();

            if (txtDataSource.Text.Length == 0)
            {
                if (cbodataSource.Text.Length > 0)
                {
                    txtDataSource.Text = cbodataSource.Text;
                }
            }
            if (txtDataSource.Text.Length > 0)
            {
                ReadDataInstanzaSql();

                if (lstDatabase.Items.Count >= 0 && lstDatabase.Text == "")
                {
                    lstDatabase.SelectedItem = settPrivate.Database;
                }

                if (lstMaster.Items.Count >= 0)
                {
                    lstMaster.SelectedItem = settPrivate.Master;
                }
                if (lstCommonFolder.Items.Count >= 0)
                {
                    lstCommonFolder.SelectedItem = settPrivate.CommonFolder;
                }
            }
            lstMaster.SelectedIndexChanged += LstMaster_SelectedIndexChanged;

            CheckAnableAvvia();
        }

        private void LstMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckAnableAvvia();

        }

        private void CheckAnableAvvia()
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
            ReadDataInstanzaSql();

        }

        private void ReadDataInstanzaSql()
        {
            lstDatabase.Items.Clear();
            lstMaster.Items.Clear();
            _testConn = new TestConnessione(txtDataSource.Text);
            if (_testConn.InstanceData == null)
            {
                MessageBox.Show("Connessione non riuscita");
                return;
            }

            RefreshDbList();
            var settingManager = new SettingManager();
            var publicSett = settingManager.ReadPublicSetting();
            if (!publicSett.InstanzeSql.Contains(txtDataSource.Text))
            {
                publicSett.InstanzeSql.Add(txtDataSource.Text);
                settingManager.SaveSetting(publicSett);
            }

        }
        /// <summary>
        /// filtra i database se quello della sottocartella database è presente sulla lista
        /// </summary>
        private void RefreshDbList()
        {
            lstDatabase.Items.Clear();
            List<string> listDbFolder = new List<string>();
            var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location), "Database");
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
                lstDatabase.Items.Add(item);
            }
        }

        private void lstDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshListMaster();
        }

        private void RefreshListMaster()
        {
            lstMaster.Items.Clear();
            if (lstDatabase.SelectedIndex <= -1)
                return;

            var selectedDb = lstDatabase.SelectedItem.ToString();

            foreach (var item in _testConn.InstanceData.DbList.Where(a => a.Database == selectedDb).First()
                .MasterName)
            {
                lstMaster.Items.Add(item);
            }
        }

        private void btnAvvia_Click(object sender, EventArgs e)
        {
            var exe = new Exe_SystemLogisticsApp4();
            exe.StrartProc(txtDataSource.Text, lstMaster.Text, lstCommonFolder.Text, "ILGA", lstDatabase.Text);


        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void LoadCommonFolder()
        {
            foreach (var item in
                System.IO.Directory.GetDirectories(Environment.CurrentDirectory, "*"
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
                )
                .ToList()

                )
            {
                lstCommonFolder.Items.Add(item.Name);
            }

        }

        private void addMaster_Click(object sender, EventArgs e)
        {
            if (lstMaster.SelectedIndex == -1)
            {

                try
                {

                    var txtcomm = LanciaSystore.Properties.Resources.QueryAddMaster.Replace("#MACHINE_NAME#", Environment.MachineName);
                    txtcomm = txtcomm.Replace("#DBNAME#", lstDatabase.Text);


                    System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(
                    txtcomm
                    , _testConn.Connessione);
                    command.ExecuteNonQuery();
                    
                    _testConn.RefreshMaster(lstDatabase.Text);
                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RefreshListMaster();
            }

        }
    }
}

