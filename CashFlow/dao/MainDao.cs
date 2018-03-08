using Com.Garfield.CashFlow.common;
using Com.Garfield.CashFlow.model;
using Com.Garfield.Utility.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Garfield.CashFlow.dao
{
    public class MainDao
    {
        public static DataTable GetCashFlowData()
        {
            var _sql = @"SELECT * FROM TB_CASHFLOW WHERE 1=1 AND CREATETIME>=DateAdd('m',-1,Date()) AND CREATETIME<=NOW()  ORDER BY CREATETIME DESC,LASTUPDATETIME DESC";
            var _result = AccessDbHelper.Query(_sql).Tables[0];

            return _result;
        }

        public static DataTable GetCashFlowData(QueryParameter paras)
        {
            var _parasSql = string.Empty;
            if (paras != null)
            {
                if (!string.IsNullOrEmpty(paras.VoucherNo)) _parasSql += $" AND A.VoucherNo LIKE '%{paras.VoucherNo}%'";
                if (paras.VoucherDateFrom!=null) _parasSql += $" AND A.VoucherDate>#{Convert.ToDateTime(paras.VoucherDateFrom).AddDays(-1).ToShortDateString()}#";
                if (paras.VoucherDateTo != null) _parasSql += $" AND A.VoucherDate<#{Convert.ToDateTime(paras.VoucherDateTo).AddDays(1).ToShortDateString()}#";
                if (!string.IsNullOrEmpty(paras.GeneralLedger)) _parasSql += $" AND B.GeneralLedger LIKE '%{paras.GeneralLedger}%'";
                if (!string.IsNullOrEmpty(paras.ClassificationItem)) _parasSql += $" AND B.ClassificationItem LIKE '%{paras.ClassificationItem}%'";
                if (!string.IsNullOrEmpty(paras.Summary)) _parasSql += $" AND B.Summary LIKE '%{paras.Summary}%'";
            }
            //            var _sql = $@"SELECT A.BillNo,A.VoucherNo,A.VoucherDate,B.Summary,B.GeneralLedger,B.ClassificationItem,B.DebitAmount,B.CreditAmount,
            //A.Attachment,A.AccountingSupervisor,A.Accounting,A.Cashier,A.Auditing,A.Accreditation,A.Creator,A.LastUpdateTime FROM TB_CASHFLOW A INNER JOIN TB_CASHFLOW_DETAIL B ON A.BillNo=B.BillNo
            //WHERE 1=1{_parasSql} ORDER BY A.CREATETIME DESC,A.LASTUPDATETIME DESC";
            var _sql = $@"SELECT A.BillNo,A.VoucherNo,A.VoucherDate,B.Summary,B.GeneralLedger,B.ClassificationItem,B.DebitAmount,B.CreditAmount,
A.Attachment,A.Creator,A.LastUpdateTime FROM TB_CASHFLOW A INNER JOIN TB_CASHFLOW_DETAIL B ON A.BillNo=B.BillNo
WHERE 1=1{_parasSql} ORDER BY A.CREATETIME DESC,A.LASTUPDATETIME DESC";
            var _result = AccessDbHelper.Query(_sql).Tables[0];

            return _result;
        }
    }
}
