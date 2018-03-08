using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Garfield.Payment.model
{
    public class Tb_PaymentApply
    {
        public int ID { get; set; }
        public string BillNo { get; set; }
        public DateTime ApplyDate { get; set; }
        public string DepartMent { get; set; }
        public string Summary { get; set; }
        public decimal TotalMonthCost { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal AmountToPay { get; set; }
        public string AmountToPayUpper { get; set; }
        public string PayType { get; set; }
        public string PayAccount { get; set; }
        public string Payee { get; set; }
        public string PayeePhone { get; set; }
        public string PayeeAccount { get; set; }
        public string PayeeBank { get; set; }
        public decimal ExportAmount { get; set; }
        public decimal Poundage { get; set; }
        public DateTime? ExportDate { get; set; }
        public string Remark { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Modifier { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
