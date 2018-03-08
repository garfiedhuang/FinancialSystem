using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Garfield.CashFlow.model
{
    public class TD_CASHFLOW
    {
        public int ID { get; set; }
        public string BillNo { get; set; }
        public string VoucherNo { get; set; }
        public DateTime VoucherDate { get; set; }
        public decimal TotalDebitAmount { get; set; }
        public decimal TotalCreditAmount { get; set; }
        public string AccountingSupervisor { get; set; }
        public string Accounting { get; set; }
        public string Cashier { get; set; }
        public string Auditing { get; set; }
        public string Accreditation { get; set; }
        public int Attachment { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Modifier { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
