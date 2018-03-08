using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Garfield.Payment.model;
using Com.Garfield.Payment.dao;

namespace Com.Garfield.Payment.business
{
    public class BillBLL
    {
        public static string GetMaxBillNo()
        {
            try
            {
                return BillDao.GetMaxBillNo();
            }
            finally { }
        }
        public static bool CheckBillNo(string BillNo)
        {
            try
            {
                return BillDao.CheckBillNo(BillNo);
            }
            finally { }
        }
        public static void SavePaymentData(Tb_PaymentApply data)
        {
            try
            {
                BillDao.SavePaymentData(data);
            }
            finally { }
        }
        public static void EditPaymentData(Tb_PaymentApply data)
        {
            try
            {
                BillDao.EditPaymentData(data);
            }
            finally { }
        }
        public static void DeletePaymentData(List<int> lstID)
        {
            try
            {
                BillDao.DeletePaymentData(lstID);
            }
            finally { }
        }
        public static Tb_PaymentApply GetPaymentData(int id)
        {
            try
            {
                return BillDao.GetPaymentData(id);
            }
            finally { }
        }
    }
}
