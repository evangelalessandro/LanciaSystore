using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanciaSystore
{
    internal class TestConnessione
    {
        SqlConnection _connection;
        string _dataSource;
        InstanceSqlData _InstanceData = null;
        public string DataSource { get { return _dataSource; } }

        public InstanceSqlData InstanceData { get { return _InstanceData; } }

        public TestConnessione(string dataSource)
        {
            _dataSource = dataSource;
            _connection = ProvaConnessione(dataSource, "SYSTEM_ITALI");

            if (_connection == null)
                _connection = ProvaConnessione(dataSource, "SYSTEM_us_en");


            if (_connection != null)
                ReadData();
        }
      
        private void ReadData()
        {
            var sqlDatabases = "SELECT name " +
                     " FROM sys.databases d " +
                     " WHERE d.database_id > 4  AND name NOT LIKE '%_HISTORY' " +
                     " AND name NOT LIKE '%_IMPEXP'";



            InstanceSqlData instanceSqlData = new InstanceSqlData();

            instanceSqlData.InstanceSql = _dataSource;

            instanceSqlData.DbList = new List<DataBaseInstanceSql>();
            foreach (var dbName in GetListString(sqlDatabases))
            {
                var itemDb = (new DataBaseInstanceSql() { Database = dbName });


                instanceSqlData.DbList.Add(itemDb);
                RefreshMaster(dbName, itemDb);

            }
            _InstanceData = instanceSqlData;

        }
        public void RefreshMaster(string dbName)
        {
            RefreshMaster(dbName, InstanceData.DbList.Where(a => a.Database == dbName).First());

        }

        private void RefreshMaster(string dbName, DataBaseInstanceSql itemDb)
        {
            var sqlMasterList = "SELECT MAS_MASTER FROM {1}.dbo.GESTORI_MASTER WHERE MAS_IP='localHost' OR MAS_WORKSTATION ='{0}'";
            sqlMasterList = sqlMasterList.Replace("{0}", Environment.MachineName);
            var sqlmaster = sqlMasterList.Replace("{1}", dbName);
            try
            {
                foreach (var masterName in GetListString(sqlmaster))
                {
                    itemDb.MasterName.Add(masterName);
                }
            }
            catch (SqlException ex)
            {


            }
        }

        private List<string> GetListString(string query)
        {
            var list = new List<string>();

            foreach (var item in GetData(query))
            {
                list.Add(item[0].ToString());
            }
            return list;
        }

        private List<DataRow> GetData(string query)
        {

            List<DataRow> dataList = new List<DataRow>();
            using (SqlDataAdapter da = new SqlDataAdapter(query, _connection))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    dataList.Add(item);
                }
            }
            return dataList;

        }


        public SqlConnection Connessione { get { return _connection; } }

        private SqlConnection ProvaConnessione(string dataSource, string utente)
        {

            var sqlConnString = new System.Data.SqlClient.SqlConnectionStringBuilder();
            sqlConnString.DataSource = dataSource;
            sqlConnString.InitialCatalog = "Master";
            sqlConnString.ConnectTimeout = 2;
            sqlConnString.UserID = utente;
            sqlConnString.Password = "SYS123";

            var sqlConn = new System.Data.SqlClient.SqlConnection(sqlConnString.ConnectionString);
            try
            {
                sqlConn.Open();
                return sqlConn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
