using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Garfield.CashFlow.model;
using Com.Garfield.CashFlow.dao;

namespace Com.Garfield.CashFlow.business
{
    public class MutiBillBLL
    {

        public static bool CheckVoucherNo(string voucherNo)
        {
            try
            {
                return MutiBillDao.CheckVoucherNo(voucherNo);
            }
            finally { }
        }
        public static void SaveCashFlowData(TD_CASHFLOW data, List<TD_CASHFLOW_DETAIL> dataDetails)
        {
            try
            {
                MutiBillDao.SaveCashFlowData(data, dataDetails);
            }
            finally { }
        }
        public static void EditCashFlowData(TD_CASHFLOW data, List<TD_CASHFLOW_DETAIL> dataDetails)
        {
            try
            {
                MutiBillDao.EditCashFlowData(data, dataDetails);
            }
            finally { }
        }
        public static void DeleteCashFlowData(List<int> lstID)
        {
            try
            {
                MutiBillDao.DeleteCashFlowData(lstID);
            }
            finally { }
        }
        public static CashFlowData GetCashFlowData(int id)
        {
            try
            {
                return MutiBillDao.GetCashFlowData(id);
            }
            finally { }
        }
    }
}
