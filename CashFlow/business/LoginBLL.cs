using Com.Garfield.CashFlow.common;
using Com.Garfield.CashFlow.dao;
using Com.Garfield.CashFlow.model;
using Com.Garfield.Utility.common;
using Com.Garfield.Utility.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Garfield.CashFlow.business
{
   public  class LoginBLL
    {
        public static void Login(string userName, string password)
        {
            try
            {
                LoginDao.Login(userName, password);
                MemoryCacheHelper.GetCacheItem<TD_USER>("FS_USER_INFO", () => { return new TD_USER() {  UserName=userName,Password=password};},new TimeSpan(7,0,0,0));
            }
            finally { }
        }
    }
}
