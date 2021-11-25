
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LanciaSystore.Settings
{
    public class PublicSetting
    {
        public List<string> InstanzeSql { get; set; }=new List<string>(){ };    

        public List<DatiLancio> Lanci { get; set; }=new List<DatiLancio>(){ };  
    }
    public class DatiLancio
    {
        public string ExeFilePath { get; set; }
        public string Argument { get; set; }
    }



}