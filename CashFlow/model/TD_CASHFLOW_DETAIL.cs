using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Garfield.CashFlow.model
{
    public class TD_CASHFLOW_DETAIL
    {
        public int ID { get; set; }
        public string BillNo { get; set; }
        public string GeneralLedger { get; set; }
        public string ClassificationItem { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public string Summary { get; set; }
    }
}
