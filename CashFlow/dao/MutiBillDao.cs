using System;
using System.Data;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Garfield.CashFlow.model;
using Com.Garfield.CashFlow.common;
using System.Collections;
using Com.Garfield.Utility.model;
using Com.Garfield.Utility.common;

namespace Com.Garfield.CashFlow.dao
{
    public class MutiBillDao
    {
        public static bool CheckVoucherNo(string voucherNo)
        {
            var _sql = @"SELECT COUNT(1) FROM TB_CASHFLOW WHERE VoucherNo=:VoucherNo";
            var _paras = new OleDbParameter[] {
                new OleDbParameter()
                {
                    ParameterName =":VoucherNo",
                     OleDbType =OleDbType.VarChar,
                     Size=50,
                    Value =voucherNo,
                    Direction =System.Data.ParameterDirection.Input
                }
            };
            return AccessDbHelper.Exists(_sql, _paras);
        }

        public static void SaveCashFlowData(TD_CASHFLOW data, List<TD_CASHFLOW_DETAIL> dataDetails)
        {
            var _sql1 = @"INSERT INTO tb_CashFlow(BillNo,VoucherNo,VoucherDate,TotalDebitAmount,TotalCreditAmount,AccountingSupervisor,
Accounting,Cashier,Auditing,Accreditation,Attachment,Creator,CreateTime,Modifier,LastUpdateTime)
VALUES(:BillNo,:VoucherNo,:VoucherDate,:TotalDebitAmount,:TotalCreditAmount,:AccountingSupervisor,
:Accounting,:Cashier,:Auditing,:Accreditation,:Attachment,:Creator,NOW(),:Modifier,NOW())";

            var _sql2 = @"INSERT INTO tb_CashFlow_Detail(BillNo,GeneralLedger,ClassificationItem,DebitAmount,CreditAmount,Summary)
VALUES(:BillNo,:GeneralLedger,:ClassificationItem,:DebitAmount,:CreditAmount,:Summary)";

            var _user = MemoryCacheHelper.GetLoginUser();
            var _maxID = AccessDbHelper.GetMaxID("ID", "tb_CashFlow").ToString();
            var _billNo = UtilityHelper.GenerateBillNo(_maxID);
            data.BillNo = _billNo;
            dataDetails.ForEach((item) =>
            {
                item.BillNo = _billNo;
            });
            var _sqlList = new List<SQLStringList>();
            var _paras1 = new OleDbParameter[] {
                new OleDbParameter(){ParameterName =":BillNo",OleDbType =OleDbType.VarChar,Value =data.BillNo,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":VoucherNo",OleDbType =OleDbType.VarChar,Value =data.VoucherNo,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":VoucherDate",OleDbType =OleDbType.Date,Value =data.VoucherDate,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":TotalDebitAmount",OleDbType =OleDbType.Currency,Value =dataDetails.Sum(s=>s.DebitAmount),Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":TotalCreditAmount",OleDbType =OleDbType.Currency,Value =dataDetails.Sum(s=>s.CreditAmount),Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":AccountingSupervisor",OleDbType =OleDbType.VarChar,Value =data.AccountingSupervisor,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Accounting",OleDbType =OleDbType.VarChar,Value =data.Accounting,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Cashier",OleDbType =OleDbType.VarChar,Value =data.Cashier,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Auditing",OleDbType =OleDbType.VarChar,Value =data.Auditing,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Accreditation",OleDbType =OleDbType.VarChar,Value =data.Accreditation,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Attachment",OleDbType =OleDbType.VarChar,Value =data.Attachment,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Creator",OleDbType =OleDbType.VarChar,Value =_user.UserName,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Modifier",OleDbType =OleDbType.VarChar,Value =_user.UserName,Direction =ParameterDirection.Input}
            };
            _sqlList.Add(new SQLStringList() { SQL = _sql1, Parameters = _paras1 });

            foreach (var item in dataDetails)
            {
                var _paras2 = new OleDbParameter[] {
                new OleDbParameter(){ParameterName =":BillNo",OleDbType =OleDbType.VarChar,Value =item.BillNo,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":GeneralLedger",OleDbType =OleDbType.VarChar,Value =item.GeneralLedger,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":ClassificationItem",OleDbType =OleDbType.VarChar,Value =item.ClassificationItem,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":DebitAmount",OleDbType =OleDbType.Currency,Value =item.DebitAmount,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":CreditAmount",OleDbType =OleDbType.Currency,Value =item.CreditAmount,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Summary",OleDbType =OleDbType.VarChar,Value =item.Summary,Direction =ParameterDirection.Input}
            };
                _sqlList.Add(new SQLStringList() { SQL = _sql2, Parameters = _paras2 });
            }

            AccessDbHelper.ExecuteSqlTran(_sqlList);
        }

        public static void EditCashFlowData(TD_CASHFLOW data, List<TD_CASHFLOW_DETAIL> dataDetails)
        {
            var _sql1 = @"UPDATE tb_CashFlow SET VoucherNo=:VoucherNo,
VoucherDate=:VoucherDate,
TotalDebitAmount=:TotalDebitAmount,
TotalCreditAmount=:TotalCreditAmount,
AccountingSupervisor=:AccountingSupervisor,
Accounting=:Accounting,
Cashier=:Cashier,
Auditing=:Auditing,
Accreditation=:Accreditation,
Attachment=:Attachment,
Modifier=:Modifier,
LastUpdateTime=NOW() WHERE ID=:ID";

            var _sql2 = @"DELETE FROM tb_CashFlow_Detail WHERE BILLNO=:BillNo";

            var _sql3 = @"INSERT INTO tb_CashFlow_Detail(BillNo,GeneralLedger,ClassificationItem,DebitAmount,CreditAmount,Summary)
VALUES(:BillNo,:GeneralLedger,:ClassificationItem,:DebitAmount,:CreditAmount,:Summary)";

            var _user = MemoryCacheHelper.GetLoginUser();
            var _sqlList = new List<SQLStringList>();
            var _paras1 = new OleDbParameter[] {
                new OleDbParameter(){ParameterName =":VoucherNo",OleDbType =OleDbType.VarChar,Value =data.VoucherNo,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":VoucherDate",OleDbType =OleDbType.Date,Value =data.VoucherDate,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":TotalDebitAmount",OleDbType =OleDbType.Currency,Value =dataDetails.Sum(s=>s.DebitAmount),Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":TotalCreditAmount",OleDbType =OleDbType.Currency,Value =dataDetails.Sum(s=>s.CreditAmount),Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":AccountingSupervisor",OleDbType =OleDbType.VarChar,Value =data.AccountingSupervisor,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Accounting",OleDbType =OleDbType.VarChar,Value =data.Accounting,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Cashier",OleDbType =OleDbType.VarChar,Value =data.Cashier,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Auditing",OleDbType =OleDbType.VarChar,Value =data.Auditing,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Accreditation",OleDbType =OleDbType.VarChar,Value =data.Accreditation,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Attachment",OleDbType =OleDbType.VarChar,Value =data.Attachment,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":Modifier",OleDbType =OleDbType.VarChar,Value =_user.UserName,Direction =ParameterDirection.Input},
                new OleDbParameter(){ParameterName =":ID",OleDbType =OleDbType.BigInt,Value =data.ID,Direction =ParameterDirection.Input},
            };
            _sqlList.Add(new SQLStringList() { SQL = _sql1, Parameters = _paras1 });

            var _paras2 = new OleDbParameter[] {
                new OleDbParameter(){ParameterName =":BillNo",OleDbType =OleDbType.VarChar,Value =data.BillNo,Direction =ParameterDirection.Input}
            };
            _sqlList.Add(new SQLStringList() { SQL = _sql2, Parameters = _paras2 });

            foreach (var item in dataDetails)
            {
                var _paras3 = new OleDbParameter[] {
                    new OleDbParameter(){ParameterName =":BillNo",OleDbType =OleDbType.VarChar,Value =item.BillNo,Direction =ParameterDirection.Input},
                    new OleDbParameter(){ParameterName =":GeneralLedger",OleDbType =OleDbType.VarChar,Value =item.GeneralLedger,Direction =ParameterDirection.Input},
                    new OleDbParameter(){ParameterName =":ClassificationItem",OleDbType =OleDbType.VarChar,Value =item.ClassificationItem,Direction =ParameterDirection.Input},
                    new OleDbParameter(){ParameterName =":DebitAmount",OleDbType =OleDbType.Currency,Value =item.DebitAmount,Direction =ParameterDirection.Input},
                    new OleDbParameter(){ParameterName =":CreditAmount",OleDbType =OleDbType.Currency,Value =item.CreditAmount,Direction =ParameterDirection.Input},
                    new OleDbParameter(){ParameterName =":Summary",OleDbType =OleDbType.VarChar,Value =item.Summary,Direction =ParameterDirection.Input}
                };
                _sqlList.Add(new SQLStringList() { SQL = _sql3, Parameters = _paras3 });
            }

            AccessDbHelper.ExecuteSqlTran(_sqlList);
        }

        public static void DeleteCashFlowData(List<int> lstID)
        {
            var _sql1 = @"DELETE FROM tb_CashFlow_Detail WHERE BillNo IN(SELECT BillNo FROM tb_CashFlow WHERE ID=:ID)";
            var _sql2 = @"DELETE FROM tb_CashFlow WHERE ID=:ID";

            var _sqlList = new List<SQLStringList>();

            foreach (var id in lstID)
            {
                var _paras1 = new OleDbParameter[] {
                      new OleDbParameter(){ParameterName =":ID",OleDbType =OleDbType.BigInt,Value =id,Direction =ParameterDirection.Input}
                };
                _sqlList.Add(new SQLStringList() { SQL = _sql1, Parameters = _paras1 });
                _sqlList.Add(new SQLStringList() { SQL = _sql2, Parameters = _paras1 });
            }
            AccessDbHelper.ExecuteSqlTran(_sqlList);
        }

        public static CashFlowData GetCashFlowData(int id)
        {
            var _sql1 = @"SELECT ID,BillNo,VoucherNo,VoucherDate,TotalDebitAmount,TotalCreditAmount,AccountingSupervisor,
Accounting,Cashier,Auditing,Accreditation,Attachment,Creator,CreateTime,Modifier,LastUpdateTime FROM tb_CashFlow WHERE ID=:ID";
            var _sql2 = @"SELECT ID,BillNo,GeneralLedger,ClassificationItem,DebitAmount,CreditAmount,Summary
FROM tb_CashFlow_Detail WHERE BILLNO=:BILLNO";
            var _paras1 = new OleDbParameter[] {
                new OleDbParameter(){ParameterName =":ID",OleDbType =OleDbType.BigInt,Value =id,Direction =ParameterDirection.Input}
            };

            var _cashFlowData = new CashFlowData();
            _cashFlowData.CashFlow = new TD_CASHFLOW();
            _cashFlowData.CashFlowDetails = new List<TD_CASHFLOW_DETAIL>();

            using (DataTable dt = AccessDbHelper.Query(_sql1, _paras1).Tables[0])
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    _cashFlowData.CashFlow.ID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                    _cashFlowData.CashFlow.BillNo = dt.Rows[0]["BillNo"].ToString();
                    _cashFlowData.CashFlow.VoucherNo = dt.Rows[0]["VoucherNo"].ToString();
                    _cashFlowData.CashFlow.VoucherDate = Convert.ToDateTime(dt.Rows[0]["VoucherDate"].ToString());
                    _cashFlowData.CashFlow.TotalDebitAmount = Convert.ToDecimal(dt.Rows[0]["TotalDebitAmount"].ToString());
                    _cashFlowData.CashFlow.TotalCreditAmount = Convert.ToDecimal(dt.Rows[0]["TotalCreditAmount"].ToString());
                    _cashFlowData.CashFlow.AccountingSupervisor = dt.Rows[0]["AccountingSupervisor"].ToString();
                    _cashFlowData.CashFlow.Accounting = dt.Rows[0]["Accounting"].ToString();
                    _cashFlowData.CashFlow.Cashier = dt.Rows[0]["Cashier"].ToString();
                    _cashFlowData.CashFlow.Auditing = dt.Rows[0]["Auditing"].ToString();
                    _cashFlowData.CashFlow.Accreditation = dt.Rows[0]["Accreditation"].ToString();
                    _cashFlowData.CashFlow.Attachment = Convert.ToInt32(dt.Rows[0]["Attachment"].ToString());
                    _cashFlowData.CashFlow.Creator = dt.Rows[0]["Creator"].ToString();
                    _cashFlowData.CashFlow.CreateTime = Convert.ToDateTime(dt.Rows[0]["CreateTime"].ToString());
                    _cashFlowData.CashFlow.Modifier = dt.Rows[0]["Modifier"].ToString();
                    _cashFlowData.CashFlow.LastUpdateTime = Convert.ToDateTime(dt.Rows[0]["LastUpdateTime"].ToString());

                    var _paras2 = new OleDbParameter[] {
                        new OleDbParameter(){ParameterName =":BILLNO",OleDbType =OleDbType.VarChar,Value =_cashFlowData.CashFlow.BillNo,Direction =ParameterDirection.Input}
                    };
                    using (DataTable dt1 = AccessDbHelper.Query(_sql2, _paras2).Tables[0])
                    {
                        if (dt1 != null && dt1.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt1.Rows)
                            {
                                _cashFlowData.CashFlowDetails.Add(new TD_CASHFLOW_DETAIL()
                                {
                                    ID = Convert.ToInt32(dr["ID"].ToString()),
                                    BillNo = dr["BillNo"].ToString(),
                                    GeneralLedger = dr["GeneralLedger"].ToString(),
                                    ClassificationItem = dr["ClassificationItem"].ToString(),
                                    DebitAmount = Convert.ToDecimal(dr["DebitAmount"].ToString()),
                                    CreditAmount = Convert.ToDecimal(dr["CreditAmount"].ToString()),
                                    Summary = dr["Summary"].ToString(),
                                });
                            }
                        }
                    }
                }
            }

            return _cashFlowData;
        }
    }
}
