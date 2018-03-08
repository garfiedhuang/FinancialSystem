using Com.Garfield.CashFlow.dao;
using Com.Garfield.CashFlow.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Garfield.CashFlow.business
{
   public class MainBLL
    {
        public static DataTable GetCashFlowData()
        {
            try
            {
                return MainDao.GetCashFlowData();
            }
            finally { }
        }
        public static DataTable GetCashFlowData(QueryParameter paras)
        {
            try
            {
                return MainDao.GetCashFlowData(paras);
            }
            finally { }
        }
    }
}
