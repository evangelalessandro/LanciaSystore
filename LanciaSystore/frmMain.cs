using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            var settPubl= settingManager.ReadPublicSetting();
            foreach (var item in settPubl.InstanzeSql)
            {
                cbodataSource.Items.Add(item);

            }
            if (cbodataSource.Items.Count>0)
            {
                cbodataSource.SelectedIndex = 0;
            }

            lstCommonFolder.Items.Clear();

            LoadCommonFolder();

            if (txtDataSource.Text.Length== 0)
            {
                if (cbodataSource.Text.Length>0)
                {
                    txtDataSource.Text=cbodataSource.Text;
                }
            }
            if (txtDataSource.Text.Length> 0)
            {
                ReadDataInstanzaSql();
                var path=System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Database");
                var listDbFolder= System.IO.Directory.EnumerateDirectories(path,"WS*",System.IO.SearchOption.TopDirectoryOnly)
                    .Select(a=>new System.IO.DirectoryInfo(a).Name).ToList();

                if (lstDatabase.Items.Count>=0)
                {
                    lstDatabase.SelectedItem = settPrivate.Database;
                    if (lstDatabase.SelectedIndex<=0)
                    {
                        foreach (var item in listDbFolder)
                        {
                            if (lstDatabase.Items.Contains(item))
                            {
                                lstDatabase.SelectedItem = item;
                            }
                        }
                    }
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
                sett.Database=lstDatabase.SelectedItem.ToString();
            if (lstMaster.SelectedIndex >= 0)
                sett.Master= lstMaster.SelectedItem.ToString();
            if (lstCommonFolder.SelectedIndex >= 0)
                sett.CommonFolder= lstCommonFolder.SelectedItem.ToString();
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
            var publicSett= settingManager.ReadPublicSetting();
            if (!publicSett.InstanzeSql.Contains(txtDataSource.Text))
            {
                publicSett.InstanzeSql.Add(txtDataSource.Text);
                settingManager.SaveSetting(publicSett);
            }

        }

        private void RefreshDbList()
        {
            lstDatabase.Items.Clear();
            foreach (var item in _testConn.InstanceData.DbList.Select(a=>a.Database).OrderBy(a=>a))
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
            exe.StrartProc(txtDataSource.Text, lstMaster.Text, lstCommonFolder.Text, "ILGA",lstDatabase.Text);

            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           
        }

        private void LoadCommonFolder()
        {
            foreach (var item in 
                System.IO.Directory.GetDirectories(Environment.CurrentDirectory,"*"
                ,System.IO.SearchOption.TopDirectoryOnly)
                
                .Select (a=> new System.IO.DirectoryInfo(a)).Where(a=>a.Attributes !=System.IO.FileAttributes.Hidden
                && a.Attributes!=System.IO.FileAttributes.Encrypted).ToList()
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
    }
}

