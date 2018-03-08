using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Garfield.CashFlow.common
{
   public class UtilityHelper
    {
        /// <summary>
        /// 产生单据编号
        /// </summary>
        /// <param name="maxID"></param>
        /// <returns></returns>
        public static string GenerateBillNo(string maxID="")
        {
            if (!string.IsNullOrEmpty(maxID))
            {
                //CF00000001
                var _id = maxID.PadLeft(8, '0');
                return $"CF{_id}";
            }

            return DateTime.Now.ToString("yyyyMMddHH24:mi:ss");
        }
    }
}
