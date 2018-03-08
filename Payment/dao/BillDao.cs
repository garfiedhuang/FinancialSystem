using System;
using System.Data;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Garfield.Payment.model;
using Com.Garfield.Payment.common;
using System.Collections;
using Com.Garfield.Utility.model;
using Com.Garfield.Utility.common;

namespace Com.Garfield.Payment.dao
{
    public class BillDao
    {
        public static string GetMaxBillNo()
        {
            var _maxSql = "SELECT top 1 BillNo FROM Tb_PaymentApply ORDER BY ID DESC";
            var _maxResult = AccessDbHelper.GetSingle(_maxSql);
            if (_maxResult == null) return "";
            return _maxResult.ToString();
        }

        public static bool CheckBillNo(string billNo)
        {
            var _sql = @"SELECT COUNT(1) FROM TB_PaymentApply WHERE BillNo=:BillNo";
            var _paras = new OleDbParameter[] {
                new OleDbParameter()
                {
                    ParameterName =":BillNo",
                     OleDbType =OleDbType.VarChar,
                     Size=50,
                    Value =billNo,
                    Direction =System.Data.ParameterDirection.Input
                }
            };
            return AccessDbHelper.Exists(_sql, _paras);
        }

        public static void SavePaymentData(Tb_PaymentApply data)
        {
            var _sql1 = @"INSERT INTO Tb_PaymentApply(BillNo,ApplyDate,DepartMent,Summary,TotalMonthCost,PaidAmount,AmountToPay,
AmountToPayUpper,PayType,PayAccount,Payee,PayeePhone,PayeeAccount,PayeeBank,ExportAmount,
Poundage,ExportDate,Remark,
Creator,CreateTime,Modifier,LastUpdateTime)
VALUES(:BillNo,:ApplyDate,:DepartMent,:Summary,:TotalMonthCost,:PaidAmount,:AmountToPay,
:AmountToPayUpper,:PayType,:PayAccount,:Payee,:PayeePhone,:PayeeAccount,:PayeeBank,:ExportAmount,
:Poundage,:ExportDate,:Remark,
:Creator,NOW(),:Modifier,NOW())";

            var _user = MemoryCacheHelper.GetLoginUser();
            var _sqlList = new List<SQLStringList>();
            var _paras1 = new OleDbParameter[] {
                new OleDbParameter(){ParameterName =":BillNo",OleDbType =OleDbType.VarChar,Value =data.BillNo,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":ApplyDate",OleDbType =OleDbType.Date,Value =data.ApplyDate,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":DepartMent",OleDbType =OleDbType.VarChar,Value =data.DepartMent,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Summary",OleDbType =OleDbType.VarChar,Value =data.Summary,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":TotalMonthCost",OleDbType =OleDbType.Currency,Value =data.TotalMonthCost,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":PaidAmount",OleDbType =OleDbType.Currency,Value =data.PaidAmount,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":AmountToPay",OleDbType =OleDbType.Currency,Value =data.AmountToPay,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":AmountToPayUpper",OleDbType =OleDbType.VarChar,Value =data.AmountToPayUpper,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":PayType",OleDbType =OleDbType.VarChar,Value =data.PayType,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":PayAccount",OleDbType =OleDbType.VarChar,Value =data.PayAccount,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Payee",OleDbType =OleDbType.VarChar,Value =data.Payee,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":PayeePhone",OleDbType =OleDbType.VarChar,Value =data.PayeePhone,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":PayeeAccount",OleDbType =OleDbType.VarChar,Value =data.PayeeAccount,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":PayeeBank",OleDbType =OleDbType.VarChar,Value =data.PayeeBank,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":ExportAmount",OleDbType =OleDbType.Currency,Value =data.ExportAmount,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Poundage",OleDbType =OleDbType.Currency,Value =data.Poundage,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":ExportDate",OleDbType =OleDbType.Date,Value =data.ExportDate,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Remark",OleDbType =OleDbType.VarChar,Value =data.Remark,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Creator",OleDbType =OleDbType.VarChar,Value =_user.UserName,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Modifier",OleDbType =OleDbType.VarChar,Value =_user.UserName,Direction =ParameterDirection.Input}
            };
            _sqlList.Add(new SQLStringList() { SQL = _sql1, Parameters = _paras1 });
            AccessDbHelper.ExecuteSqlTran(_sqlList);
        }

        public static void EditPaymentData(Tb_PaymentApply data)
        {
            var _sql1 = @"UPDATE Tb_PaymentApply SET Summary=:Summary,TotalMonthCost=:TotalMonthCost,
PaidAmount=:PaidAmount,
AmountToPay=:AmountToPay,
AmountToPayUpper=:AmountToPayUpper,
PayType=:PayType,
PayAccount=:PayAccount,
Payee=:Payee,
PayeePhone=:PayeePhone,
PayeeAccount=:PayeeAccount,
PayeeBank=:PayeeBank,
ExportAmount=:ExportAmount,
Poundage=:Poundage,
ExportDate=:ExportDate,
Remark=:Remark,
Modifier=:Modifier,
LastUpdateTime=NOW() WHERE ID=:ID";

            var _user = MemoryCacheHelper.GetLoginUser();
            var _sqlList = new List<SQLStringList>();
            var _paras1 = new OleDbParameter[] {
                new OleDbParameter(){ParameterName =":Summary",OleDbType =OleDbType.VarChar,Value =data.Summary,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":TotalMonthCost",OleDbType =OleDbType.Currency,Value =data.TotalMonthCost,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":PaidAmount",OleDbType =OleDbType.Currency,Value =data.PaidAmount,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":AmountToPay",OleDbType =OleDbType.Currency,Value =data.AmountToPay,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":AmountToPayUpper",OleDbType =OleDbType.VarChar,Value =data.AmountToPayUpper,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":PayType",OleDbType =OleDbType.VarChar,Value =data.PayType,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":PayAccount",OleDbType =OleDbType.VarChar,Value =data.PayAccount,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Payee",OleDbType =OleDbType.VarChar,Value =data.Payee,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":PayeePhone",OleDbType =OleDbType.VarChar,Value =data.PayeePhone,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":PayeeAccount",OleDbType =OleDbType.VarChar,Value =data.PayeeAccount,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":PayeeBank",OleDbType =OleDbType.VarChar,Value =data.PayeeBank,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":ExportAmount",OleDbType =OleDbType.Currency,Value =data.ExportAmount,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Poundage",OleDbType =OleDbType.Currency,Value =data.Poundage,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":ExportDate",OleDbType =OleDbType.Date,Value =data.ExportDate,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Remark",OleDbType =OleDbType.VarChar,Value =data.Remark,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Modifier",OleDbType =OleDbType.VarChar,Value =_user.UserName,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":ID",OleDbType =OleDbType.BigInt,Value =data.ID,Direction =ParameterDirection.Input},
            };
            _sqlList.Add(new SQLStringList() { SQL = _sql1, Parameters = _paras1 });

            AccessDbHelper.ExecuteSqlTran(_sqlList);
        }

        public static void DeletePaymentData(List<int> lstID)
        {
            var _sql = @"DELETE FROM Tb_PaymentApply WHERE ID=:ID";
            var _sqlList = new List<SQLStringList>();

            foreach (var id in lstID)
            {
                var _paras1 = new OleDbParameter[] {
                      new OleDbParameter(){ParameterName =":ID",OleDbType =OleDbType.BigInt,Value =id,Direction =ParameterDirection.Input}
                };
                _sqlList.Add(new SQLStringList() { SQL = _sql, Parameters = _paras1 });
            }
            AccessDbHelper.ExecuteSqlTran(_sqlList);
        }

        public static Tb_PaymentApply GetPaymentData(int id)
        {
            var _sql1 = @"SELECT ID,BillNo,ApplyDate,DepartMent,Summary,TotalMonthCost,PaidAmount,AmountToPay,
AmountToPayUpper,PayType,PayAccount,Payee,PayeePhone,PayeeAccount,PayeeBank,ExportAmount,
Poundage,ExportDate,Remark,Creator,CreateTime,Modifier,LastUpdateTime FROM Tb_PaymentApply WHERE ID=:ID";
            var _paras1 = new OleDbParameter[] {
                new OleDbParameter(){ParameterName =":ID",OleDbType =OleDbType.BigInt,Value =id,Direction =ParameterDirection.Input}
            };

            var _PaymentData = new Tb_PaymentApply();
            using (DataTable dt = AccessDbHelper.Query(_sql1, _paras1).Tables[0])
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    _PaymentData.ID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                    _PaymentData.BillNo = dt.Rows[0]["BillNo"].ToString();
                    _PaymentData.ApplyDate = Convert.ToDateTime(dt.Rows[0]["ApplyDate"].ToString());
                    _PaymentData.DepartMent = dt.Rows[0]["DepartMent"].ToString();
                    _PaymentData.Summary = dt.Rows[0]["Summary"].ToString();
                    _PaymentData.TotalMonthCost = Convert.ToDecimal(dt.Rows[0]["TotalMonthCost"].ToString());
                    _PaymentData.PaidAmount = Convert.ToDecimal(dt.Rows[0]["PaidAmount"].ToString());
                    _PaymentData.AmountToPay = Convert.ToDecimal(dt.Rows[0]["AmountToPay"].ToString());
                    _PaymentData.AmountToPayUpper = dt.Rows[0]["AmountToPayUpper"].ToString();
                    _PaymentData.PayType = dt.Rows[0]["PayType"].ToString();
                    _PaymentData.PayAccount = dt.Rows[0]["PayAccount"].ToString();
                    _PaymentData.Payee = dt.Rows[0]["Payee"].ToString();
                    _PaymentData.PayeePhone = dt.Rows[0]["PayeePhone"].ToString();
                    _PaymentData.PayeeAccount = dt.Rows[0]["PayeeAccount"].ToString();
                    _PaymentData.PayeeBank = dt.Rows[0]["PayeeBank"].ToString();
                    _PaymentData.ExportAmount = Convert.ToDecimal(dt.Rows[0]["ExportAmount"].ToString());
                    _PaymentData.Poundage = Convert.ToDecimal(dt.Rows[0]["Poundage"].ToString());
                    _PaymentData.ExportDate =Convert.ToDateTime(dt.Rows[0]["ExportDate"].ToString());
                    _PaymentData.Remark = dt.Rows[0]["Remark"].ToString();
                    _PaymentData.Creator = dt.Rows[0]["Creator"].ToString();
                    _PaymentData.CreateTime = Convert.ToDateTime(dt.Rows[0]["CreateTime"].ToString());
                    _PaymentData.Modifier = dt.Rows[0]["Modifier"].ToString();
                    _PaymentData.LastUpdateTime = Convert.ToDateTime(dt.Rows[0]["LastUpdateTime"].ToString());
                }
            }

            return _PaymentData;
        }
    }
}
