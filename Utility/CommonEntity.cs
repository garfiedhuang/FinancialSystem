using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Garfield.Utility.model
{
    public class SystemSetting
    {
        public static string EncryptKey = "GarfieldHuangSoftwareV1.0";
    }
    public class SQLStringList
    {
        public string SQL { get; set; }
        public OleDbParameter[] Parameters { get; set; }
    }

    public class TD_USER
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
