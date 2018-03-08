using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Garfield.Payment.common
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
                //Z02015
                var _id = maxID.PadLeft(3, '0');
                var _month = DateTime.Now.Month.ToString().PadLeft(2, '0');
                return $"Z{_month}{_id}";
            }

            return DateTime.Now.ToString("yyyyMMddHH24:mi:ss");
        }
    }
}
