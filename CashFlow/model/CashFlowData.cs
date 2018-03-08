using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Garfield.CashFlow.model
{
    public class QueryParameter
    {
        public string VoucherNo { get; set; }
        public DateTime? VoucherDateFrom { get; set; }
        public DateTime? VoucherDateTo { get; set; }
        public string GeneralLedger { get; set; }
        public string ClassificationItem { get; set; }
        public string Summary { get; set; }
    }
    public class CashFlowData
    {
        public TD_CASHFLOW CashFlow { get; set; }
        public List<TD_CASHFLOW_DETAIL> CashFlowDetails { get; set; }
    }
}
