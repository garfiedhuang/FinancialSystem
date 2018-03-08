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
using System.Diagnostics;
using DevExpress.XtraGrid;
using Com.Garfield.CashFlow.business;
using Com.Garfield.CashFlow.model;

namespace Com.Garfield.CashFlow
{
    public partial class DetailReportForm : DevExpress.XtraEditors.XtraForm
    {
        public DetailReportForm()
        {
            InitializeComponent();
        }

        private void DetailReportForm_Load(object sender, EventArgs e)
        {
            this.gridControl1.MainView = this.gridView1;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsFind.AlwaysVisible = false;
            this.gridView1.IndicatorWidth = 30;//网格行号宽度
            this.gridView1.OptionsView.ColumnAutoWidth = true;
            this.gridView1.OptionsBehavior.Editable = false;//设置网格是否可编辑

            this.dtVoucherDateFrom.EditValue = DateTime.Now.AddMonths(-1);
            this.dtVoucherDateTo.EditValue = DateTime.Now;

            //绑定数据源
            BindGridViewData(new QueryParameter() {
                VoucherDateFrom = DateTime.Now.AddMonths(-1),
                VoucherDateTo=DateTime.Now
            });
        }

        /// <summary>
        /// 设置行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        /// <summary>
        /// 设置行数据格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.ColumnHandle == 10)
            {
                e.DisplayText = Convert.ToDateTime(e.Value).ToString("yyyy/MM/dd HH:mm:ss");
            }
        }

        /// <summary>
        /// 绑定网格数据
        /// </summary>
        private void BindGridViewData(QueryParameter paras)
        {
            var _dt = MainBLL.GetCashFlowData(paras);
            gridControl1.DataSource = _dt.AsDataView();
        }

        /// <summary>
        ///     导出表格
        /// </summary>
        /// <param name="gridControl1"></param>
        private void DevExpressGridControlExport(GridControl gridControl1)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel文件(*.xls)|*.xls";
                if (saveDialog.ShowDialog() == DialogResult.Cancel) return;
                var exportFilePath = saveDialog.FileName;
                var fileExtenstion = new FileInfo(exportFilePath).Extension;
                switch (fileExtenstion)
                {
                    case ".xls":
                        gridControl1.ExportToXls(exportFilePath);
                        break;
                    case ".xlsx":
                        gridControl1.ExportToXlsx(exportFilePath);
                        break;
                    case ".rtf":
                        gridControl1.ExportToRtf(exportFilePath);
                        break;
                    case ".pdf":
                        gridControl1.ExportToPdf(exportFilePath);
                        break;
                    case ".html":
                        gridControl1.ExportToHtml(exportFilePath);
                        break;
                    case ".mht":
                        gridControl1.ExportToMht(exportFilePath);
                        break;
                }

                if (File.Exists(exportFilePath))
                {
                    try
                    {
                        if (DialogResult.Yes == MessageBox.Show("保存成功，是否打开文件？", "提示", MessageBoxButtons.YesNo))
                        {
                            Process.Start(exportFilePath);
                        }
                    }
                    catch
                    {
                        var msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                    }
                }
                else
                {
                    var msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                }
            }
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            var _voucherNo = this.txtVoucherNo.Text;
            var _voucherDateFrom = this.dtVoucherDateFrom.Text;
            var _voucherDateTo = this.dtVoucherDateTo.Text;
            var _generalLedger = this.txtGeneralLedger.Text;
            var _classificationItem = this.txtClassificationItem.Text;
            var _summary = this.txtSummary.Text;

            var _queryParameter = new QueryParameter();
            if (!string.IsNullOrEmpty(_voucherNo))  _queryParameter.VoucherNo = _voucherNo;
            if (!string.IsNullOrEmpty(_voucherDateFrom)) _queryParameter.VoucherDateFrom = Convert.ToDateTime(_voucherDateFrom);
            if (!string.IsNullOrEmpty(_voucherDateTo)) _queryParameter.VoucherDateTo = Convert.ToDateTime(_voucherDateTo);
            if (!string.IsNullOrEmpty(_generalLedger)) _queryParameter.GeneralLedger = _generalLedger;
            if (!string.IsNullOrEmpty(_classificationItem)) _queryParameter.ClassificationItem = _classificationItem;
            if (!string.IsNullOrEmpty(_summary)) _queryParameter.Summary = _summary;

            BindGridViewData(_queryParameter);
        }

        /// <summary>
        /// Clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtVoucherNo.EditValue = string.Empty;
            this.dtVoucherDateFrom.EditValue = string.Empty;
            this.dtVoucherDateTo.EditValue = string.Empty;
            this.txtGeneralLedger.EditValue = string.Empty;
            this.txtClassificationItem.EditValue = string.Empty;
            this.txtSummary.EditValue = string.Empty;
        }

        /// <summary>
        /// Export to excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            DevExpressGridControlExport(this.gridControl1);
        }
    }
}