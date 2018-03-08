using Com.Garfield.Payment.dao;
using Com.Garfield.Payment.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Garfield.Payment.business
{
   public class MainBLL
    {
        public static DataTable GetPaymentData()
        {
            try
            {
                return MainDao.GetPaymentData();
            }
            finally { }
        }
        //public static DataTable GetPaymentData(QueryParameter paras)
        //{
        //    try
        //    {
        //        return MainDao.GetPaymentData(paras);
        //    }
        //    finally { }
        //}
    }
}
