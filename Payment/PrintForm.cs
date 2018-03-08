using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using Com.Garfield.Payment.model;
using Com.Garfield.Payment.business;
using Com.Garfield.Payment.common;

namespace Com.Garfield.Payment
{
    public partial class PrintForm : DevExpress.XtraEditors.XtraForm
    {
        public List<int> LstIDs = new List<int>();
        public PrintForm()
        {
            InitializeComponent();
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            try
            {
                #region 测试数据
                this.btnTest.Visible = false;
                //var tempPdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files\\test.pdf");
                //pdfViewer1.LoadDocument(tempPdfPath);
                #endregion

                if (LstIDs != null && LstIDs.Count > 0)
                {
                    var _lstPaymentData = new List<Tb_PaymentApply>();
                    foreach (var id in LstIDs)
                    {
                        _lstPaymentData.Add(BillBLL.GetPaymentData(id));
                    }
                    this.lblBillNo.Text = string.Join(",", _lstPaymentData.Select(s => s.BillNo).ToList());
                    this.lblApplyDate.Text = string.Join(",", _lstPaymentData.Select(s => s.ApplyDate.ToShortDateString()).ToList());
                    new PdfHelper().PdfTest(_lstPaymentData);
                    var tempPdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files\\Payment.pdf");
                    pdfViewer1.LoadDocument(tempPdfPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            pdfViewer1.Print();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
             //var  data = new List<PaymentData>();

             //   #region 测试数据
             //   for (int i = 1; i < 5; i++)
             //   {
             //       var cf = new PaymentData();
             //       cf.Payment = new TD_Payment()
             //       {
             //           ID = i,
             //           BillNo = "1000001" + i.ToString(),
             //           BillNo = "VN0001" + i.ToString(),
             //           VoucherDate = DateTime.Now,
             //           TotalDebitAmount = 8888888.33m,
             //           TotalCreditAmount = 9999999.33m,
             //           Attachment = i,
             //           AccountingSupervisor = "熊大",
             //           Accounting = "熊二",
             //           Cashier = "黄大刚",
             //           Auditing = "光头强",
             //           Accreditation = "周星星",
             //           Creator = "xtadmin",
             //           CreateTime = DateTime.Now,
             //           Modifier = "",
             //           LastUpdateTime = DateTime.Now
             //       };
             //       cf.PaymentDetails = new List<TD_Payment_DETAIL>();
             //       for (int j = 1; j < 10; j++)
             //       {
             //           cf.PaymentDetails.Add(new TD_Payment_DETAIL()
             //           {
             //               ID = j,
             //               BillNo = "1000001" + i.ToString(),
             //               GeneralLedger = "总账科目总账科目",//最大8个汉字
             //               ClassificationItem = "明细科目总账科目",//最大8个汉字
             //               DebitAmount = 88888.99m,
             //               CreditAmount = 888888.33m,//付杨李锋客户李小峰注射用核黄素磷酸钠2000支返款科目
             //               Summary = "付杨李锋客户李小峰注付杨李锋客户李小峰注客户李小峰注"//最小字26个汉字，最大字10个汉字
             //           });
             //       }

             //       data.Add(cf);
             //   }
             //   #endregion

             //   new PdfHelper().PdfTest(data);

             //   var tempPdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files\\Chap0101.pdf");
             //   pdfViewer1.LoadDocument(tempPdfPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF生成失败！" + ex.Message, "提示", MessageBoxButtons.OK);
            }
        }

        private void PrintForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pdfViewer1.Dispose();
        }
    }
}