using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanciaSystore
{
    internal class DataBaseInstanceSql
    {
        public String Database { get; set; }
        public List<String> MasterName { get; set; }=new List<string>(){ };

    }
}
