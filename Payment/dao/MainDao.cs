using Com.Garfield.Payment.model;
using Com.Garfield.Payment.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Garfield.Utility.common;

namespace Com.Garfield.Payment.dao
{
    public class MainDao
    {
        public static DataTable GetPaymentData()
        {
            var _sql = @"SELECT * FROM TB_PAYMENTAPPLY WHERE 1=1 AND CREATETIME>=DateAdd('m',-6,Date()) AND CREATETIME<=NOW() ORDER BY CREATETIME DESC,LASTUPDATETIME DESC";
            var _result = AccessDbHelper.Query(_sql).Tables[0];

            return _result;
        }

//        public static DataTable GetPaymentData(QueryParameter paras)
//        {
//            var _parasSql = string.Empty;
//            if (paras != null)
//            {
//                if (!string.IsNullOrEmpty(paras.BillNo)) _parasSql += $" AND A.BillNo LIKE '%{paras.BillNo}%'";
//                if (paras.VoucherDateFrom!=null) _parasSql += $" AND A.VoucherDate>=cdate('{paras.VoucherDateFrom}')";
//                if (paras.VoucherDateTo != null) _parasSql += $" AND A.VoucherDate<=cdate('{paras.VoucherDateTo}')";
//                if (!string.IsNullOrEmpty(paras.GeneralLedger)) _parasSql += $" AND B.GeneralLedger LIKE '%{paras.GeneralLedger}%'";
//                if (!string.IsNullOrEmpty(paras.ClassificationItem)) _parasSql += $" AND B.ClassificationItem LIKE '%{paras.ClassificationItem}%'";
//                if (!string.IsNullOrEmpty(paras.Summary)) _parasSql += $" AND B.Summary LIKE '%{paras.Summary}%'";
//            }

//            var _sql = $@"SELECT A.BillNo,A.BillNo,A.VoucherDate,B.Summary,B.GeneralLedger,B.ClassificationItem,B.DebitAmount,B.CreditAmount,
//A.Attachment,A.Creator,A.LastUpdateTime FROM TB_Payment A INNER JOIN TB_Payment_DETAIL B ON A.BillNo=B.BillNo
//WHERE 1=1{_parasSql} ORDER BY A.CREATETIME DESC,A.LASTUPDATETIME DESC";
//            var _result = AccessDbHelper.Query(_sql).Tables[0];

//            return _result;
//        }
    }
}
