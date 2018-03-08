using Com.Garfield.CashFlow.business;
using Com.Garfield.CashFlow.common;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Com.Garfield.CashFlow
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// New
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MutiBillForm _billForm = new MutiBillForm();
            _billForm.ID = -1;
            _billForm.BillNo = string.Empty;
            var _dialogResult = _billForm.ShowDialog();

            //绑定数据源
            BindGridViewData();
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var _lstTempHandle = this.gridView1.GetSelectedRows();
            if (_lstTempHandle == null || _lstTempHandle.Length == 0)
            {
                MessageBox.Show("请选择要编辑的凭证！", "提示", MessageBoxButtons.OK);
                return;
            }
            else if (_lstTempHandle.Length > 1)
            {
                MessageBox.Show("只能选择一条凭证进行编辑！", "提示", MessageBoxButtons.OK);
                return;
            }

            MutiBillForm _billForm = new MutiBillForm();
            _billForm.ID = Convert.ToInt32(this.gridView1.GetRowCellValue(_lstTempHandle[0], "ID"));
            _billForm.BillNo = this.gridView1.GetRowCellValue(_lstTempHandle[0], "BillNo").ToString();
            var _dialogResult = _billForm.ShowDialog();

            //绑定数据源
            BindGridViewData();

            //设置选中行
            gridView1.FocusedRowHandle = _lstTempHandle[0];
            gridView1.SelectRow(_lstTempHandle[0]);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var _lstID = new List<int>();
            var _lstTempHandle=this.gridView1.GetSelectedRows();
            foreach (var handle in _lstTempHandle)
            {
                _lstID.Add(Convert.ToInt32(this.gridView1.GetRowCellValue(handle, "ID")));
            }
            if (_lstID == null || _lstID.Count == 0)
            {
                MessageBox.Show("请选择要删除的凭证！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("确定删除选中数据吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MutiBillBLL.DeleteCashFlowData(_lstID);
                //绑定数据源
                BindGridViewData();
            }
        }

        /// <summary>
        /// Print
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var _lstID = new List<int>();
            var _lstTempHandle = this.gridView1.GetSelectedRows();
            foreach (var handle in _lstTempHandle)
            {
                _lstID.Add(Convert.ToInt32(this.gridView1.GetRowCellValue(handle, "ID")));
            }
            if (_lstID == null || _lstID.Count == 0)
            {
                MessageBox.Show("请选择要打印的凭证！", "提示", MessageBoxButtons.OK);
                return;
            }

            PrintForm _printForm = new PrintForm();
            _printForm.LstIDs = _lstID;
            _printForm.ShowDialog();
        }

        /// <summary>
        /// Export
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpressGridControlExport(this.gridControl1);
        }

        /// <summary>
        /// Detail Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bBtnDetailReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DetailReportForm _detailReportForm = new DetailReportForm();
            _detailReportForm.ShowDialog();
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.gridControl1.MainView = this.gridView1;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.IndicatorWidth=30;//网格行号宽度
            this.gridView1.OptionsView.ColumnAutoWidth = true;
            this.gridView1.OptionsBehavior.Editable = false;//设置网格是否可编辑
            this.gridView1.OptionsSelection.MultiSelect = true;//设置网格可以行多选
            this.gridView1.OptionsSelection.MultiSelectMode= DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;

            //绑定数据源
            BindGridViewData();
        }

        /// <summary>
        /// 设置网格行号
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
        /// 窗口关闭中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose(true);
            Application.Exit();
        }

        /// <summary>
        /// 绑定网格数据
        /// </summary>
        private void BindGridViewData()
        {
            var _dt = MainBLL.GetCashFlowData();
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
    }
}
