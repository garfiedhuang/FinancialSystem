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
using Com.Garfield.CashFlow.model;
using Com.Garfield.CashFlow.business;

namespace Com.Garfield.CashFlow
{
    public partial class MutiBillForm : DevExpress.XtraEditors.XtraForm
    {
        public int ID { get; set; }
        public string BillNo { get; set; }

        public MutiBillForm()
        {
            InitializeComponent();
        }

        private void MutiBillForm_Load(object sender, EventArgs e)
        {
            //this.dtVoucherDate.DateTime = DateTime.Now;
            if (ID > -1)//Edit DataRow
            {
                this.Text = "Edit";
                this.txtVoucherNo.Enabled = false;
                this.dtVoucherDate.Enabled = false;
                this.btnClear.Enabled = false;
                var _cashFlowData = MutiBillBLL.GetCashFlowData(ID);
                if (_cashFlowData != null && _cashFlowData.CashFlow != null)
                {
                    this.txtVoucherNo.EditValue = _cashFlowData.CashFlow.VoucherNo;
                    this.dtVoucherDate.EditValue = _cashFlowData.CashFlow.VoucherDate;
                    this.txtAttachment.EditValue = _cashFlowData.CashFlow.Attachment;

                    this.txtTotalDebitAmount.EditValue = _cashFlowData.CashFlow.TotalDebitAmount;
                    this.txtTotalCreditAmount.EditValue = _cashFlowData.CashFlow.TotalCreditAmount;

                    this.txtAccountingSupervisor.EditValue = _cashFlowData.CashFlow.AccountingSupervisor;
                    this.txtAccounting.EditValue = _cashFlowData.CashFlow.Accounting;
                    this.txtCashier.EditValue = _cashFlowData.CashFlow.Cashier;
                    this.txtAuditing.EditValue = _cashFlowData.CashFlow.Auditing;
                    this.txtAccreditation.EditValue = _cashFlowData.CashFlow.Accreditation;
                }
                if (_cashFlowData != null && _cashFlowData.CashFlowDetails != null && _cashFlowData.CashFlowDetails.Count > 0)
                {
                    for (int i = 0; i < _cashFlowData.CashFlowDetails.Count; i++)
                    {
                        var _item = _cashFlowData.CashFlowDetails[i];

                        #region 1
                        if (i == 0)
                        {
                            this.txtGeneralLedger1.EditValue = _item.GeneralLedger;
                            this.txtClassificationItem1.EditValue = _item.ClassificationItem;
                            this.txtDebitAmount1.EditValue = _item.DebitAmount;
                            this.txtCreditAmount1.EditValue = _item.CreditAmount;
                            this.txtSummary1.Text = _item.Summary;
                        }
                        #endregion
                        #region 2
                        if (i == 1)
                        {
                            this.txtGeneralLedger2.EditValue = _item.GeneralLedger;
                            this.txtClassificationItem2.EditValue = _item.ClassificationItem;
                            this.txtDebitAmount2.EditValue = _item.DebitAmount;
                            this.txtCreditAmount2.EditValue = _item.CreditAmount;
                            this.txtSummary2.Text = _item.Summary;
                        }
                        #endregion
                        #region 3
                        if (i == 2)
                        {
                            this.txtGeneralLedger3.EditValue = _item.GeneralLedger;
                            this.txtClassificationItem3.EditValue = _item.ClassificationItem;
                            this.txtDebitAmount3.EditValue = _item.DebitAmount;
                            this.txtCreditAmount3.EditValue = _item.CreditAmount;
                            this.txtSummary3.Text = _item.Summary;
                        }
                        #endregion
                        #region 4
                        if (i == 3)
                        {
                            this.txtGeneralLedger4.EditValue = _item.GeneralLedger;
                            this.txtClassificationItem4.EditValue = _item.ClassificationItem;
                            this.txtDebitAmount4.EditValue = _item.DebitAmount;
                            this.txtCreditAmount4.EditValue = _item.CreditAmount;
                            this.txtSummary4.Text = _item.Summary;
                        }
                        #endregion
                        #region 5
                        if (i == 4)
                        {
                            this.txtGeneralLedger5.EditValue = _item.GeneralLedger;
                            this.txtClassificationItem5.EditValue = _item.ClassificationItem;
                            this.txtDebitAmount5.EditValue = _item.DebitAmount;
                            this.txtCreditAmount5.EditValue = _item.CreditAmount;
                            this.txtSummary5.Text = _item.Summary;
                        }
                        #endregion
                        #region 6
                        if (i == 5)
                        {
                            this.txtGeneralLedger6.EditValue = _item.GeneralLedger;
                            this.txtClassificationItem6.EditValue = _item.ClassificationItem;
                            this.txtDebitAmount6.EditValue = _item.DebitAmount;
                            this.txtCreditAmount6.EditValue = _item.CreditAmount;
                            this.txtSummary6.Text = _item.Summary;
                        }
                        #endregion
                        #region 7
                        if (i == 6)
                        {
                            this.txtGeneralLedger7.EditValue = _item.GeneralLedger;
                            this.txtClassificationItem7.EditValue = _item.ClassificationItem;
                            this.txtDebitAmount7.EditValue = _item.DebitAmount;
                            this.txtCreditAmount7.EditValue = _item.CreditAmount;
                            this.txtSummary7.Text = _item.Summary;
                        }
                        #endregion
                        #region 8
                        if (i == 7)
                        {
                            this.txtGeneralLedger8.EditValue = _item.GeneralLedger;
                            this.txtClassificationItem8.EditValue = _item.ClassificationItem;
                            this.txtDebitAmount8.EditValue = _item.DebitAmount;
                            this.txtCreditAmount8.EditValue = _item.CreditAmount;
                            this.txtSummary8.Text = _item.Summary;
                        }
                        #endregion
                        #region 9
                        if (i == 8)
                        {
                            this.txtGeneralLedger9.EditValue = _item.GeneralLedger;
                            this.txtClassificationItem9.EditValue = _item.ClassificationItem;
                            this.txtDebitAmount9.EditValue = _item.DebitAmount;
                            this.txtCreditAmount9.EditValue = _item.CreditAmount;
                            this.txtSummary9.Text = _item.Summary;
                        }
                        #endregion
                    }
                }
                this.txtAttachment.Focus();
            }
            else
            {
                this.txtVoucherNo.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var _data = new TD_CASHFLOW();
                var _dataDetails = new List<TD_CASHFLOW_DETAIL>();

                CheckFirstArea(_data);
                CheckSecondArea(_dataDetails);
                CheckThirdArea(_data);

                var _tips = "您确定要保存凭证数据吗？";
                if (ID < 0)//新增
                {
                    var _isExistVoucherNo = MutiBillBLL.CheckVoucherNo(_data.VoucherNo);
                    if (_isExistVoucherNo) _tips = $"凭证编号[{_data.VoucherNo}]已经存在！是否继续保存凭证数据吗？";
                }

                if (MessageBox.Show(_tips, "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (ID < 0)
                    {
                        MutiBillBLL.SaveCashFlowData(_data, _dataDetails);
                    }
                    else
                    {
                        _data.ID = ID;
                        _data.BillNo = BillNo;
                        _dataDetails.ForEach((item) => { item.BillNo = _data.BillNo; });
                        MutiBillBLL.EditCashFlowData(_data, _dataDetails);
                    }
                    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败，" + ex.Message, "提示", MessageBoxButtons.OK);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtVoucherNo.Text = string.Empty;
            this.dtVoucherDate.Text = string.Empty;
            this.txtAttachment.Text = "0";

            #region 1
            this.txtGeneralLedger1.Text = string.Empty;
            this.txtClassificationItem1.Text = string.Empty;
            this.txtDebitAmount1.Text = string.Empty;
            this.txtCreditAmount1.Text = string.Empty;
            this.txtSummary1.Text = string.Empty;
            #endregion
            #region 2
            this.txtGeneralLedger2.Text = string.Empty;
            this.txtClassificationItem2.Text = string.Empty;
            this.txtDebitAmount2.Text = string.Empty;
            this.txtCreditAmount2.Text = string.Empty;
            this.txtSummary2.Text = string.Empty;
            #endregion
            #region 3
            this.txtGeneralLedger3.Text = string.Empty;
            this.txtClassificationItem3.Text = string.Empty;
            this.txtDebitAmount3.Text = string.Empty;
            this.txtCreditAmount3.Text = string.Empty;
            this.txtSummary3.Text = string.Empty;
            #endregion
            #region 4
            this.txtGeneralLedger4.Text = string.Empty;
            this.txtClassificationItem4.Text = string.Empty;
            this.txtDebitAmount4.Text = string.Empty;
            this.txtCreditAmount4.Text = string.Empty;
            this.txtSummary4.Text = string.Empty;
            #endregion
            #region 5
            this.txtGeneralLedger5.Text = string.Empty;
            this.txtClassificationItem5.Text = string.Empty;
            this.txtDebitAmount5.Text = string.Empty;
            this.txtCreditAmount5.Text = string.Empty;
            this.txtSummary5.Text = string.Empty;
            #endregion
            #region 6
            this.txtGeneralLedger6.Text = string.Empty;
            this.txtClassificationItem6.Text = string.Empty;
            this.txtDebitAmount6.Text = string.Empty;
            this.txtCreditAmount6.Text = string.Empty;
            this.txtSummary6.Text = string.Empty;
            #endregion
            #region 7
            this.txtGeneralLedger7.Text = string.Empty;
            this.txtClassificationItem7.Text = string.Empty;
            this.txtDebitAmount7.Text = string.Empty;
            this.txtCreditAmount7.Text = string.Empty;
            this.txtSummary7.Text = string.Empty;
            #endregion
            #region 8
            this.txtGeneralLedger8.Text = string.Empty;
            this.txtClassificationItem8.Text = string.Empty;
            this.txtDebitAmount8.Text = string.Empty;
            this.txtCreditAmount8.Text = string.Empty;
            this.txtSummary8.Text = string.Empty;
            #endregion
            #region 9
            this.txtGeneralLedger9.Text = string.Empty;
            this.txtClassificationItem9.Text = string.Empty;
            this.txtDebitAmount9.Text = string.Empty;
            this.txtCreditAmount9.Text = string.Empty;
            this.txtSummary9.Text = string.Empty;
            #endregion

            this.txtTotalDebitAmount.Text = string.Empty;
            this.txtTotalCreditAmount.Text = string.Empty;

            this.txtAccountingSupervisor.Text = string.Empty;
            this.txtAccounting.Text = string.Empty;
            this.txtCashier.Text = string.Empty;
            this.txtAuditing.Text = string.Empty;
            this.txtAccreditation.Text = string.Empty;
        }

        #region 前端输入验证
        private void CheckFirstArea(TD_CASHFLOW tdCashFlow)
        {
            var _voucherNo = this.txtVoucherNo.Text.Trim();
            var _voucherDate = this.dtVoucherDate.Text;
            var _attachment = this.txtAttachment.Text.Trim();

            if (string.IsNullOrEmpty(_voucherNo))
            {
                this.txtVoucherNo.Focus();
                throw new Exception("凭证编号不能为空！");
            }
            if (string.IsNullOrEmpty(_voucherDate))
            {
                this.dtVoucherDate.Focus();
                throw new Exception("凭证日期不能为空！");
            }
            else
            {
                var _selectedDate = this.dtVoucherDate.DateTime;
                if (_selectedDate > DateTime.Now.AddDays(1))
                {
                    this.dtVoucherDate.Focus();
                    throw new Exception("凭证日期必须是今天以前的！");
                }
            }
            if (string.IsNullOrEmpty(_attachment))
            {
                this.txtAttachment.Focus();
                throw new Exception("附件/张不能为空！");
            }

            tdCashFlow.VoucherNo = _voucherNo;
            tdCashFlow.VoucherDate = this.dtVoucherDate.DateTime;
            tdCashFlow.Attachment = Convert.ToInt32(_attachment);
            tdCashFlow.CreateTime = DateTime.Now;
            tdCashFlow.LastUpdateTime = DateTime.Now;
        }

        private void CheckSecondArea(List<TD_CASHFLOW_DETAIL> tdCashFlowDetails)
        {
            var _result = true;
            var _generalLedger = string.Empty;
            var _classificationItem = string.Empty;
            var _debitAmount = string.Empty;
            var _creditAmount = string.Empty;
            var _summary = string.Empty;

            #region 1
            var _tdCashFlowDetail1 = new TD_CASHFLOW_DETAIL();
            _result = CheckDetail(1, ref _tdCashFlowDetail1);
            if (_result && _tdCashFlowDetail1 != null)
            {
                tdCashFlowDetails.Add(_tdCashFlowDetail1);
            }
            else if (!_result && _tdCashFlowDetail1 != null)
            {
                _generalLedger = this.txtGeneralLedger1.Text.Trim();
                _classificationItem = this.txtClassificationItem1.Text.Trim();
                _debitAmount = this.txtDebitAmount1.Text.Trim();
                _creditAmount = this.txtCreditAmount1.Text.Trim();
                _summary = this.txtSummary1.Text.Trim();
                if (string.IsNullOrEmpty(_summary))
                {
                    this.txtSummary1.Focus();
                    throw new Exception("摘要不能为空！");
                }
                if (string.IsNullOrEmpty(_generalLedger))
                {
                    this.txtGeneralLedger1.Focus();
                    throw new Exception("总账科目不能为空！");
                }
                if (string.IsNullOrEmpty(_classificationItem))
                {
                    this.txtClassificationItem1.Focus();
                    throw new Exception("明细科目不能为空！");
                }
                if (string.IsNullOrEmpty(_debitAmount))
                {
                    this.txtDebitAmount1.Focus();
                    throw new Exception("借方金额不能为空！");
                }
                if (string.IsNullOrEmpty(_creditAmount))
                {
                    this.txtCreditAmount1.Focus();
                    throw new Exception("贷方金额不能为空！");
                }
            }
            #endregion
            #region 2
            var _tdCashFlowDetail2 = new TD_CASHFLOW_DETAIL();
            _result = CheckDetail(2, ref _tdCashFlowDetail2);
            if (_result && _tdCashFlowDetail2 != null)
            {
                tdCashFlowDetails.Add(_tdCashFlowDetail2);
            }
            else if (!_result && _tdCashFlowDetail2 != null)
            {
                _generalLedger = this.txtGeneralLedger2.Text.Trim();
                _classificationItem = this.txtClassificationItem2.Text.Trim();
                _debitAmount = this.txtDebitAmount2.Text.Trim();
                _creditAmount = this.txtCreditAmount2.Text.Trim();
                _summary = this.txtSummary2.Text.Trim();
                if (string.IsNullOrEmpty(_summary))
                {
                    this.txtSummary2.Focus();
                    throw new Exception("摘要不能为空！");
                }
                if (string.IsNullOrEmpty(_generalLedger))
                {
                    this.txtGeneralLedger2.Focus();
                    throw new Exception("总账科目不能为空！");
                }
                if (string.IsNullOrEmpty(_classificationItem))
                {
                    this.txtClassificationItem2.Focus();
                    throw new Exception("明细科目不能为空！");
                }
                if (string.IsNullOrEmpty(_debitAmount))
                {
                    this.txtDebitAmount2.Focus();
                    throw new Exception("借方金额不能为空！");
                }
                if (string.IsNullOrEmpty(_creditAmount))
                {
                    this.txtCreditAmount2.Focus();
                    throw new Exception("贷方金额不能为空！");
                }
            }
            #endregion
            #region 3
            var _tdCashFlowDetail3 = new TD_CASHFLOW_DETAIL();
            _result = CheckDetail(3, ref _tdCashFlowDetail3);
            if (_result && _tdCashFlowDetail3 != null)
            {
                tdCashFlowDetails.Add(_tdCashFlowDetail3);
            }
            else if (!_result && _tdCashFlowDetail3 != null)
            {
                _generalLedger = this.txtGeneralLedger3.Text.Trim();
                _classificationItem = this.txtClassificationItem3.Text.Trim();
                _debitAmount = this.txtDebitAmount3.Text.Trim();
                _creditAmount = this.txtCreditAmount3.Text.Trim();
                _summary = this.txtSummary3.Text.Trim();
                if (string.IsNullOrEmpty(_summary))
                {
                    this.txtSummary3.Focus();
                    throw new Exception("摘要不能为空！");
                }
                if (string.IsNullOrEmpty(_generalLedger))
                {
                    this.txtGeneralLedger3.Focus();
                    throw new Exception("总账科目不能为空！");
                }
                if (string.IsNullOrEmpty(_classificationItem))
                {
                    this.txtClassificationItem3.Focus();
                    throw new Exception("明细科目不能为空！");
                }
                if (string.IsNullOrEmpty(_debitAmount))
                {
                    this.txtDebitAmount3.Focus();
                    throw new Exception("借方金额不能为空！");
                }
                if (string.IsNullOrEmpty(_creditAmount))
                {
                    this.txtCreditAmount3.Focus();
                    throw new Exception("贷方金额不能为空！");
                }
            }
            #endregion
            #region 4
            var _tdCashFlowDetail4 = new TD_CASHFLOW_DETAIL();
            _result = CheckDetail(4, ref _tdCashFlowDetail4);
            if (_result && _tdCashFlowDetail4 != null)
            {
                tdCashFlowDetails.Add(_tdCashFlowDetail4);
            }
            else if (!_result && _tdCashFlowDetail4 != null)
            {
                _generalLedger = this.txtGeneralLedger4.Text.Trim();
                _classificationItem = this.txtClassificationItem4.Text.Trim();
                _debitAmount = this.txtDebitAmount4.Text.Trim();
                _creditAmount = this.txtCreditAmount4.Text.Trim();
                _summary = this.txtSummary4.Text.Trim();
                if (string.IsNullOrEmpty(_summary))
                {
                    this.txtSummary4.Focus();
                    throw new Exception("摘要不能为空！");
                }
                if (string.IsNullOrEmpty(_generalLedger))
                {
                    this.txtGeneralLedger4.Focus();
                    throw new Exception("总账科目不能为空！");
                }
                if (string.IsNullOrEmpty(_classificationItem))
                {
                    this.txtClassificationItem4.Focus();
                    throw new Exception("明细科目不能为空！");
                }
                if (string.IsNullOrEmpty(_debitAmount))
                {
                    this.txtDebitAmount4.Focus();
                    throw new Exception("借方金额不能为空！");
                }
                if (string.IsNullOrEmpty(_creditAmount))
                {
                    this.txtCreditAmount4.Focus();
                    throw new Exception("贷方金额不能为空！");
                }
            }
            #endregion
            #region 5
            var _tdCashFlowDetail5 = new TD_CASHFLOW_DETAIL();
            _result = CheckDetail(5, ref _tdCashFlowDetail5);
            if (_result && _tdCashFlowDetail5 != null)
            {
                tdCashFlowDetails.Add(_tdCashFlowDetail5);
            }
            else if (!_result && _tdCashFlowDetail5 != null)
            {
                _generalLedger = this.txtGeneralLedger5.Text.Trim();
                _classificationItem = this.txtClassificationItem5.Text.Trim();
                _debitAmount = this.txtDebitAmount5.Text.Trim();
                _creditAmount = this.txtCreditAmount5.Text.Trim();
                _summary = this.txtSummary5.Text.Trim();
                if (string.IsNullOrEmpty(_summary))
                {
                    this.txtSummary5.Focus();
                    throw new Exception("摘要不能为空！");
                }
                if (string.IsNullOrEmpty(_generalLedger))
                {
                    this.txtGeneralLedger5.Focus();
                    throw new Exception("总账科目不能为空！");
                }
                if (string.IsNullOrEmpty(_classificationItem))
                {
                    this.txtClassificationItem5.Focus();
                    throw new Exception("明细科目不能为空！");
                }
                if (string.IsNullOrEmpty(_debitAmount))
                {
                    this.txtDebitAmount5.Focus();
                    throw new Exception("借方金额不能为空！");
                }
                if (string.IsNullOrEmpty(_creditAmount))
                {
                    this.txtCreditAmount5.Focus();
                    throw new Exception("贷方金额不能为空！");
                }
            }
            #endregion
            #region 6
            var _tdCashFlowDetail6 = new TD_CASHFLOW_DETAIL();
            _result = CheckDetail(6, ref _tdCashFlowDetail6);
            if (_result && _tdCashFlowDetail6 != null)
            {
                tdCashFlowDetails.Add(_tdCashFlowDetail6);
            }
            else if (!_result && _tdCashFlowDetail6 != null)
            {
                _generalLedger = this.txtGeneralLedger6.Text.Trim();
                _classificationItem = this.txtClassificationItem6.Text.Trim();
                _debitAmount = this.txtDebitAmount6.Text.Trim();
                _creditAmount = this.txtCreditAmount6.Text.Trim();
                _summary = this.txtSummary6.Text.Trim();
                if (string.IsNullOrEmpty(_summary))
                {
                    this.txtSummary6.Focus();
                    throw new Exception("摘要不能为空！");
                }
                if (string.IsNullOrEmpty(_generalLedger))
                {
                    this.txtGeneralLedger6.Focus();
                    throw new Exception("总账科目不能为空！");
                }
                if (string.IsNullOrEmpty(_classificationItem))
                {
                    this.txtClassificationItem6.Focus();
                    throw new Exception("明细科目不能为空！");
                }
                if (string.IsNullOrEmpty(_debitAmount))
                {
                    this.txtDebitAmount6.Focus();
                    throw new Exception("借方金额不能为空！");
                }
                if (string.IsNullOrEmpty(_creditAmount))
                {
                    this.txtCreditAmount6.Focus();
                    throw new Exception("贷方金额不能为空！");
                }
            }
            #endregion
            #region 7
            var _tdCashFlowDetail7 = new TD_CASHFLOW_DETAIL();
            _result = CheckDetail(7, ref _tdCashFlowDetail7);
            if (_result && _tdCashFlowDetail7 != null)
            {
                tdCashFlowDetails.Add(_tdCashFlowDetail7);
            }
            else if (!_result && _tdCashFlowDetail7 != null)
            {
                _generalLedger = this.txtGeneralLedger7.Text.Trim();
                _classificationItem = this.txtClassificationItem7.Text.Trim();
                _debitAmount = this.txtDebitAmount7.Text.Trim();
                _creditAmount = this.txtCreditAmount7.Text.Trim();
                _summary = this.txtSummary7.Text.Trim();
                if (string.IsNullOrEmpty(_summary))
                {
                    this.txtSummary7.Focus();
                    throw new Exception("摘要不能为空！");
                }
                if (string.IsNullOrEmpty(_generalLedger))
                {
                    this.txtGeneralLedger7.Focus();
                    throw new Exception("总账科目不能为空！");
                }
                if (string.IsNullOrEmpty(_classificationItem))
                {
                    this.txtClassificationItem7.Focus();
                    throw new Exception("明细科目不能为空！");
                }
                if (string.IsNullOrEmpty(_debitAmount))
                {
                    this.txtDebitAmount7.Focus();
                    throw new Exception("借方金额不能为空！");
                }
                if (string.IsNullOrEmpty(_creditAmount))
                {
                    this.txtCreditAmount7.Focus();
                    throw new Exception("贷方金额不能为空！");
                }
            }
            #endregion
            #region 8
            var _tdCashFlowDetail8 = new TD_CASHFLOW_DETAIL();
            _result = CheckDetail(8, ref _tdCashFlowDetail8);
            if (_result && _tdCashFlowDetail8 != null)
            {
                tdCashFlowDetails.Add(_tdCashFlowDetail8);
            }
            else if (!_result && _tdCashFlowDetail8 != null)
            {
                _generalLedger = this.txtGeneralLedger8.Text.Trim();
                _classificationItem = this.txtClassificationItem8.Text.Trim();
                _debitAmount = this.txtDebitAmount8.Text.Trim();
                _creditAmount = this.txtCreditAmount8.Text.Trim();
                _summary = this.txtSummary8.Text.Trim();
                if (string.IsNullOrEmpty(_summary))
                {
                    this.txtSummary8.Focus();
                    throw new Exception("摘要不能为空！");
                }
                if (string.IsNullOrEmpty(_generalLedger))
                {
                    this.txtGeneralLedger8.Focus();
                    throw new Exception("总账科目不能为空！");
                }
                if (string.IsNullOrEmpty(_classificationItem))
                {
                    this.txtClassificationItem8.Focus();
                    throw new Exception("明细科目不能为空！");
                }
                if (string.IsNullOrEmpty(_debitAmount))
                {
                    this.txtDebitAmount8.Focus();
                    throw new Exception("借方金额不能为空！");
                }
                if (string.IsNullOrEmpty(_creditAmount))
                {
                    this.txtCreditAmount8.Focus();
                    throw new Exception("贷方金额不能为空！");
                }
            }
            #endregion
            #region 9
            var _tdCashFlowDetail9 = new TD_CASHFLOW_DETAIL();
            _result = CheckDetail(9, ref _tdCashFlowDetail9);
            if (_result && _tdCashFlowDetail9 != null)
            {
                tdCashFlowDetails.Add(_tdCashFlowDetail9);
            }
            else if (!_result && _tdCashFlowDetail9 != null)
            {
                _generalLedger = this.txtGeneralLedger9.Text.Trim();
                _classificationItem = this.txtClassificationItem9.Text.Trim();
                _debitAmount = this.txtDebitAmount9.Text.Trim();
                _creditAmount = this.txtCreditAmount9.Text.Trim();
                _summary = this.txtSummary9.Text.Trim();
                if (string.IsNullOrEmpty(_summary))
                {
                    this.txtSummary9.Focus();
                    throw new Exception("摘要不能为空！");
                }
                if (string.IsNullOrEmpty(_generalLedger))
                {
                    this.txtGeneralLedger9.Focus();
                    throw new Exception("总账科目不能为空！");
                }
                if (string.IsNullOrEmpty(_classificationItem))
                {
                    this.txtClassificationItem9.Focus();
                    throw new Exception("明细科目不能为空！");
                }
                if (string.IsNullOrEmpty(_debitAmount))
                {
                    this.txtDebitAmount9.Focus();
                    throw new Exception("借方金额不能为空！");
                }
                if (string.IsNullOrEmpty(_creditAmount))
                {
                    this.txtCreditAmount9.Focus();
                    throw new Exception("贷方金额不能为空！");
                }
            }
            #endregion

            if (tdCashFlowDetails != null && tdCashFlowDetails.Count == 0)
            {
                throw new Exception("至少需要录入一条科目明细！");
            }
        }

        private void CheckThirdArea(TD_CASHFLOW tdCashFlow)
        {
            var _accountingSupervisor = this.txtAccountingSupervisor.Text.Trim();
            var _accounting = this.txtAccounting.Text.Trim();
            var _cashier = this.txtCashier.Text.Trim();
            var _auditing = this.txtAuditing.Text.Trim();
            var _accreditation = this.txtAccreditation.Text.Trim();

            tdCashFlow.AccountingSupervisor = _accountingSupervisor;
            tdCashFlow.Accounting = _accounting;
            tdCashFlow.Cashier = _cashier;
            tdCashFlow.Auditing = _auditing;
            tdCashFlow.Accreditation = _accreditation;
        }

        private bool CheckDetail(int detailItem, ref TD_CASHFLOW_DETAIL tdCashFlowDetail)
        {
            var _generalLedger = string.Empty;
            var _classificationItem = string.Empty;
            var _debitAmount = string.Empty;
            var _creditAmount = string.Empty;
            var _summary = string.Empty;

            #region
            if (detailItem == 1)
            {
                _generalLedger = this.txtGeneralLedger1.Text.Trim();
                _classificationItem = this.txtClassificationItem1.Text.Trim();
                _debitAmount = this.txtDebitAmount1.Text.Trim();
                _creditAmount = this.txtCreditAmount1.Text.Trim();
                _summary = this.txtSummary1.Text.Trim();
            }
            else if (detailItem == 2)
            {
                _generalLedger = this.txtGeneralLedger2.Text.Trim();
                _classificationItem = this.txtClassificationItem2.Text.Trim();
                _debitAmount = this.txtDebitAmount2.Text.Trim();
                _creditAmount = this.txtCreditAmount2.Text.Trim();
                _summary = this.txtSummary2.Text.Trim();
            }
            else if (detailItem == 3)
            {
                _generalLedger = this.txtGeneralLedger3.Text.Trim();
                _classificationItem = this.txtClassificationItem3.Text.Trim();
                _debitAmount = this.txtDebitAmount3.Text.Trim();
                _creditAmount = this.txtCreditAmount3.Text.Trim();
                _summary = this.txtSummary3.Text.Trim();
            }
            else if (detailItem == 4)
            {
                _generalLedger = this.txtGeneralLedger4.Text.Trim();
                _classificationItem = this.txtClassificationItem4.Text.Trim();
                _debitAmount = this.txtDebitAmount4.Text.Trim();
                _creditAmount = this.txtCreditAmount4.Text.Trim();
                _summary = this.txtSummary4.Text.Trim();
            }
            else if (detailItem == 5)
            {
                _generalLedger = this.txtGeneralLedger5.Text.Trim();
                _classificationItem = this.txtClassificationItem5.Text.Trim();
                _debitAmount = this.txtDebitAmount5.Text.Trim();
                _creditAmount = this.txtCreditAmount5.Text.Trim();
                _summary = this.txtSummary5.Text.Trim();
            }
            else if (detailItem == 6)
            {
                _generalLedger = this.txtGeneralLedger6.Text.Trim();
                _classificationItem = this.txtClassificationItem6.Text.Trim();
                _debitAmount = this.txtDebitAmount6.Text.Trim();
                _creditAmount = this.txtCreditAmount6.Text.Trim();
                _summary = this.txtSummary6.Text.Trim();
            }
            else if (detailItem == 7)
            {
                _generalLedger = this.txtGeneralLedger7.Text.Trim();
                _classificationItem = this.txtClassificationItem7.Text.Trim();
                _debitAmount = this.txtDebitAmount7.Text.Trim();
                _creditAmount = this.txtCreditAmount7.Text.Trim();
                _summary = this.txtSummary7.Text.Trim();
            }
            else if (detailItem == 8)
            {
                _generalLedger = this.txtGeneralLedger8.Text.Trim();
                _classificationItem = this.txtClassificationItem8.Text.Trim();
                _debitAmount = this.txtDebitAmount8.Text.Trim();
                _creditAmount = this.txtCreditAmount8.Text.Trim();
                _summary = this.txtSummary8.Text.Trim();
            }
            else if (detailItem == 9)
            {
                _generalLedger = this.txtGeneralLedger9.Text.Trim();
                _classificationItem = this.txtClassificationItem9.Text.Trim();
                _debitAmount = this.txtDebitAmount9.Text.Trim();
                _creditAmount = this.txtCreditAmount9.Text.Trim();
                _summary = this.txtSummary9.Text.Trim();
            }
            #endregion

            #region
            var _flag = false;
            if (!string.IsNullOrEmpty(_generalLedger) ||
                !string.IsNullOrEmpty(_classificationItem) ||
                !string.IsNullOrEmpty(_debitAmount) ||
                !string.IsNullOrEmpty(_creditAmount) ||
                !string.IsNullOrEmpty(_summary))
            {
                _flag = true;//至少一个为不空的
            }
            if (_flag && (string.IsNullOrEmpty(_generalLedger) ||
                string.IsNullOrEmpty(_classificationItem) ||
                string.IsNullOrEmpty(_debitAmount) ||
                string.IsNullOrEmpty(_creditAmount) ||
                string.IsNullOrEmpty(_summary)))
            {
                _flag = false;//至少一个为空的
            }
            if (_flag && (!string.IsNullOrEmpty(_generalLedger) &&
                !string.IsNullOrEmpty(_classificationItem) &&
                !string.IsNullOrEmpty(_debitAmount) &&
                !string.IsNullOrEmpty(_creditAmount) &&
                !string.IsNullOrEmpty(_summary)))
            {
                tdCashFlowDetail.GeneralLedger = _generalLedger;
                tdCashFlowDetail.ClassificationItem = _classificationItem;
                tdCashFlowDetail.DebitAmount = Convert.ToDecimal(_debitAmount);
                tdCashFlowDetail.CreditAmount = Convert.ToDecimal(_creditAmount);
                tdCashFlowDetail.Summary = _summary;
                _flag = true;
            }

            if (string.IsNullOrEmpty(_generalLedger) &&
                string.IsNullOrEmpty(_classificationItem) &&
                string.IsNullOrEmpty(_debitAmount) &&
                string.IsNullOrEmpty(_creditAmount) &&
                string.IsNullOrEmpty(_summary))
            {
                tdCashFlowDetail = null;
                _flag = true;//全部为空的
            }
            #endregion
            return _flag;
        }

        #endregion

        #region Caculate Amount
        private void CaculateDebitAmount()
        {
            var _debitAmount1 = this.txtDebitAmount1.EditValue;
            var _debitAmount2 = this.txtDebitAmount2.EditValue;
            var _debitAmount3 = this.txtDebitAmount3.EditValue;
            var _debitAmount4 = this.txtDebitAmount4.EditValue;
            var _debitAmount5 = this.txtDebitAmount5.EditValue;
            var _debitAmount6 = this.txtDebitAmount6.EditValue;
            var _debitAmount7 = this.txtDebitAmount7.EditValue;
            var _debitAmount8 = this.txtDebitAmount8.EditValue;
            var _debitAmount9 = this.txtDebitAmount9.EditValue;

            var _lstDebits = new List<decimal>();
            if (!string.IsNullOrEmpty(_debitAmount1.ToString())) _lstDebits.Add(Convert.ToDecimal(_debitAmount1));
            if (!string.IsNullOrEmpty(_debitAmount2.ToString())) _lstDebits.Add(Convert.ToDecimal(_debitAmount2));
            if (!string.IsNullOrEmpty(_debitAmount3.ToString())) _lstDebits.Add(Convert.ToDecimal(_debitAmount3));
            if (!string.IsNullOrEmpty(_debitAmount4.ToString())) _lstDebits.Add(Convert.ToDecimal(_debitAmount4));
            if (!string.IsNullOrEmpty(_debitAmount5.ToString())) _lstDebits.Add(Convert.ToDecimal(_debitAmount5));
            if (!string.IsNullOrEmpty(_debitAmount6.ToString())) _lstDebits.Add(Convert.ToDecimal(_debitAmount6));
            if (!string.IsNullOrEmpty(_debitAmount7.ToString())) _lstDebits.Add(Convert.ToDecimal(_debitAmount7));
            if (!string.IsNullOrEmpty(_debitAmount8.ToString())) _lstDebits.Add(Convert.ToDecimal(_debitAmount8));
            if (!string.IsNullOrEmpty(_debitAmount9.ToString())) _lstDebits.Add(Convert.ToDecimal(_debitAmount9));

            this.txtTotalDebitAmount.EditValue = _lstDebits.Sum();

            /*校验是否有相同的金额存在？*/
            foreach (var money in _lstDebits)
            {
                if (_lstDebits.Where(m => m == money).Count() > 1) throw new Exception("已存在相同的借方金额，请确认是否重复录入？");
            }
        }
        private void CaculateCreditAmount()
        {
            var _creditAmount1 = this.txtCreditAmount1.EditValue;
            var _creditAmount2 = this.txtCreditAmount2.EditValue;
            var _creditAmount3 = this.txtCreditAmount3.EditValue;
            var _creditAmount4 = this.txtCreditAmount4.EditValue;
            var _creditAmount5 = this.txtCreditAmount5.EditValue;
            var _creditAmount6 = this.txtCreditAmount6.EditValue;
            var _creditAmount7 = this.txtCreditAmount7.EditValue;
            var _creditAmount8 = this.txtCreditAmount8.EditValue;
            var _creditAmount9 = this.txtCreditAmount9.EditValue;

            var _lstCredits = new List<decimal>();
            if (!string.IsNullOrEmpty(_creditAmount1.ToString())) _lstCredits.Add(Convert.ToDecimal(_creditAmount1));
            if (!string.IsNullOrEmpty(_creditAmount2.ToString())) _lstCredits.Add(Convert.ToDecimal(_creditAmount2));
            if (!string.IsNullOrEmpty(_creditAmount3.ToString())) _lstCredits.Add(Convert.ToDecimal(_creditAmount3));
            if (!string.IsNullOrEmpty(_creditAmount4.ToString())) _lstCredits.Add(Convert.ToDecimal(_creditAmount4));
            if (!string.IsNullOrEmpty(_creditAmount5.ToString())) _lstCredits.Add(Convert.ToDecimal(_creditAmount5));
            if (!string.IsNullOrEmpty(_creditAmount6.ToString())) _lstCredits.Add(Convert.ToDecimal(_creditAmount6));
            if (!string.IsNullOrEmpty(_creditAmount7.ToString())) _lstCredits.Add(Convert.ToDecimal(_creditAmount7));
            if (!string.IsNullOrEmpty(_creditAmount8.ToString())) _lstCredits.Add(Convert.ToDecimal(_creditAmount8));
            if (!string.IsNullOrEmpty(_creditAmount9.ToString())) _lstCredits.Add(Convert.ToDecimal(_creditAmount9));

            this.txtTotalCreditAmount.EditValue = _lstCredits.Sum();

            /*校验是否有相同的金额存在？*/
            foreach (var money in _lstCredits)
            {
                if (_lstCredits.Where(m => m == money).Count() > 1) throw new Exception("已存在相同的贷方金额，请确认是否重复录入？");
            }
        }

        private void txtDebitAmount1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateDebitAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        private void txtDebitAmount2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateDebitAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        private void txtDebitAmount3_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateDebitAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        private void txtDebitAmount4_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateDebitAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        private void txtDebitAmount5_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateDebitAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        private void txtDebitAmount6_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateDebitAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        private void txtDebitAmount7_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateDebitAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        private void txtDebitAmount8_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateDebitAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        private void txtDebitAmount9_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateDebitAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }

        private void txtCreditAmount1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateCreditAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        private void txtCreditAmount2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateCreditAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        private void txtCreditAmount3_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateCreditAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        private void txtCreditAmount4_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateCreditAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        private void txtCreditAmount5_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateCreditAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        private void txtCreditAmount6_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateCreditAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        private void txtCreditAmount7_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateCreditAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        private void txtCreditAmount8_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateCreditAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        private void txtCreditAmount9_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CaculateCreditAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }

        #endregion
    }
}