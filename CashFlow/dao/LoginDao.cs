using Com.Garfield.CashFlow.common;
using Com.Garfield.Utility.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Garfield.CashFlow.dao
{
    public class LoginDao
    {
        public static void Login(string userName, string password)
        {
            var _sql = @"SELECT COUNT(1) FROM TB_USER WHERE USERNAME=:USERNAME AND PASSWORD=:PASSWORD";
            var _paras = new System.Data.OleDb.OleDbParameter[] {
                new System.Data.OleDb.OleDbParameter()
                {
                    ParameterName =":USERNAME",
                     OleDbType =System.Data.OleDb.OleDbType.VarChar,
                     Size=50,
                    Value =userName,
                    Direction =System.Data.ParameterDirection.Input
                },
                new System.Data.OleDb.OleDbParameter()
                {
                    ParameterName =":PASSWORD",
                    OleDbType =System.Data.OleDb.OleDbType.VarChar,
                     Size=50,
                    Value =password,
                    Direction =System.Data.ParameterDirection.Input
                }
            };
            var _result = AccessDbHelper.Exists(_sql, _paras);

            if (!_result) throw new Exception("账号或密码不对~");
        }
    }
}
