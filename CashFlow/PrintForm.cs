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
using Com.Garfield.CashFlow.common;
using Com.Garfield.CashFlow.business;
using Com.Garfield.CashFlow.model;

namespace Com.Garfield.CashFlow
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
            #region 测试数据
            this.btnTest.Visible = false;
            //var tempPdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files\\test.pdf");
            //pdfViewer1.LoadDocument(tempPdfPath);
            #endregion

            if (LstIDs != null && LstIDs.Count > 0)
            {
                var _lstCashFlowData = new List<CashFlowData>();
                foreach (var id in LstIDs)
                {
                    _lstCashFlowData.Add(MutiBillBLL.GetCashFlowData(id));
                }
                this.lblVoucherNo.Text = string.Join(",", _lstCashFlowData.Select(s => s.CashFlow.VoucherNo).ToList());
                this.lblVoucherDate.Text= string.Join(",", _lstCashFlowData.Select(s => s.CashFlow.VoucherDate.ToShortDateString()).ToList());
                new PdfHelper().PdfTest(_lstCashFlowData);
                var tempPdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files\\CashFlow.pdf");
                pdfViewer1.LoadDocument(tempPdfPath);
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
             var  data = new List<CashFlowData>();

                #region 测试数据
                for (int i = 1; i < 5; i++)
                {
                    var cf = new CashFlowData();
                    cf.CashFlow = new TD_CASHFLOW()
                    {
                        ID = i,
                        BillNo = "1000001" + i.ToString(),
                        VoucherNo = "VN0001" + i.ToString(),
                        VoucherDate = DateTime.Now,
                        TotalDebitAmount = 8888888.33m,
                        TotalCreditAmount = 9999999.33m,
                        Attachment = i,
                        AccountingSupervisor = "熊大",
                        Accounting = "熊二",
                        Cashier = "黄大刚",
                        Auditing = "光头强",
                        Accreditation = "周星星",
                        Creator = "xtadmin",
                        CreateTime = DateTime.Now,
                        Modifier = "",
                        LastUpdateTime = DateTime.Now
                    };
                    cf.CashFlowDetails = new List<TD_CASHFLOW_DETAIL>();
                    for (int j = 1; j < 10; j++)
                    {
                        cf.CashFlowDetails.Add(new TD_CASHFLOW_DETAIL()
                        {
                            ID = j,
                            BillNo = "1000001" + i.ToString(),
                            GeneralLedger = "总账科目总账科目",//最大8个汉字
                            ClassificationItem = "明细科目总账科目",//最大8个汉字
                            DebitAmount = 88888.99m,
                            CreditAmount = 888888.33m,//付杨李锋客户李小峰注射用核黄素磷酸钠2000支返款科目
                            Summary = "付杨李锋客户李小峰注付杨李锋客户李小峰注客户李小峰注"//最小字26个汉字，最大字10个汉字
                        });
                    }

                    data.Add(cf);
                }
                #endregion

                new PdfHelper().PdfTest(data);

                var tempPdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files\\Chap0101.pdf");
                pdfViewer1.LoadDocument(tempPdfPath);
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