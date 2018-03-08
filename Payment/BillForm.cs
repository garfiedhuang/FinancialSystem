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
using Com.Garfield.Payment.model;
using Com.Garfield.Payment.business;
using Com.Garfield.Payment.common;
using Com.Garfield.Utility;

namespace Com.Garfield.Payment
{
    public partial class BillForm : DevExpress.XtraEditors.XtraForm
    {
        public int ID { get; set; }
        public string BillNo { get; set; }

        public BillForm()
        {
            InitializeComponent();
        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (ID > -1)//Edit DataRow
                {
                    #region edit
                    this.Text = "Edit";
                    this.txtDepartment.Enabled = false;
                    this.txtBillNo.Enabled = false;
                    this.dtApplyDate.Enabled = false;
                    this.btnClear.Enabled = false;
                    var _paymentData = BillBLL.GetPaymentData(ID);
                    if (_paymentData != null)
                    {
                        this.txtDepartment.EditValue = _paymentData.DepartMent;
                        this.dtApplyDate.EditValue = _paymentData.ApplyDate;
                        this.txtBillNo.EditValue = _paymentData.BillNo;
                        this.txtSummary.Text = _paymentData.Summary;
                        this.txtTotalMonthCost.EditValue = _paymentData.TotalMonthCost;
                        this.txtAmountPaid.EditValue = _paymentData.PaidAmount;
                        this.txtAmountToPay.EditValue = _paymentData.AmountToPay;
                        this.txtAmountToPayUpper.EditValue = _paymentData.AmountToPayUpper;
                        var _lstPayType = _paymentData.PayType.Split(';');
                        foreach (var payType in _lstPayType)
                        {
                            switch (payType)
                            {
                                case "现金":
                                    this.chkCash.Checked = true;
                                    break;
                                case "汇款":
                                    this.chkRemit.Checked = true;
                                    break;
                                case "现金支票":
                                    this.chkCashCheck.Checked = true;
                                    break;
                                case "转账支票":
                                    this.chkTransferCheck.Checked = true;
                                    break;
                            }
                        }
                        var _lstPayAccount = _paymentData.PayAccount.Split(';');
                        foreach (var payAccount in _lstPayAccount)
                        {
                            switch (payAccount)
                            {
                                case "工行7578#":
                                    this.chkICBC7578.Checked = true;
                                    break;
                                case "农行2673#":
                                    this.chkABC2673.Checked = true;
                                    break;
                                case "中生0361#":
                                    this.chkCMBC0361.Checked = true;
                                    break;
                                case "GY微信":
                                    this.chkGYWechat.Checked = true;
                                    break;
                            }
                        }

                        this.txtPayee.EditValue = _paymentData.Payee;
                        this.txtPayeePhone.EditValue = _paymentData.PayeePhone;
                        this.txtPayeeAccount.EditValue = _paymentData.PayeeAccount;
                        this.txtPayeeBank.EditValue = _paymentData.PayeeBank;
                        this.txtExportAmount.EditValue = _paymentData.ExportAmount;
                        this.txtPoundage.EditValue = _paymentData.Poundage;
                        this.dtExportDate.EditValue = _paymentData.ExportDate;
                        this.txtRemark.Text = _paymentData.Remark;
                    }
                    #endregion
                }
                else
                {//New Payment Apply 
                    GetBillNo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }

        private void GetBillNo()
        {
            var _result = BillBLL.GetMaxBillNo();
            var _maxID = string.Empty;
            if (string.IsNullOrEmpty(_result)) _maxID = "1";
            else _maxID = (Convert.ToInt32(_result.ToString().Substring(3)) + 1).ToString();
            var _billNo = UtilityHelper.GenerateBillNo(_maxID);

            this.txtBillNo.EditValue = _billNo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var _data = new Tb_PaymentApply();

                CheckFirstArea(_data);

                var _tips = "您确定要保存付款申请单吗？";
                if (ID < 0)//新增
                {
                    var _isExistBillNo = BillBLL.CheckBillNo(_data.BillNo);
                    if (_isExistBillNo) _tips = $"申请单号[{_data.BillNo}]已经存在！是否继续保存付款申请单吗？";
                }

                if (MessageBox.Show(_tips, "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (ID < 0)
                    {
                        BillBLL.SavePaymentData(_data);
                    }
                    else
                    {
                        _data.ID = ID;
                        _data.BillNo = BillNo;
                        BillBLL.EditPaymentData(_data);
                    }
                    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败，" + ex.Message, "提示", MessageBoxButtons.OK);
            }
        }

        private void CheckFirstArea(Tb_PaymentApply _data)
        {
            try
            {
                #region 1
                var _department = this.txtDepartment.Text.Trim();
                var _applyDate = this.dtApplyDate.Text.Trim();
                var _billNo = this.txtBillNo.Text.Trim();
                var _summary = this.txtSummary.Text.Trim();
                var _totalMonthCost = this.txtTotalMonthCost.Text.Trim();
                var _amountPaid = this.txtAmountPaid.Text.Trim();
                var _amountToPay = this.txtAmountToPay.Text.Trim();
                var _amountToPayUpper = this.txtAmountToPayUpper.Text.Trim();
                #endregion

                #region 2
                var _payType = string.Empty;
                if (this.chkCash.Checked)
                {
                    _payType += "现金;";
                }
                if (this.chkRemit.Checked)
                {
                    _payType += "汇款;";
                }
                if (this.chkCashCheck.Checked)
                {
                    _payType += "现金支票;";
                }
                if (this.chkTransferCheck.Checked)
                {
                    _payType += "转账支票;";
                }
                _payType = _payType.TrimEnd(new char[] { ';'});

                var _payAccount = string.Empty;
                if (this.chkICBC7578.Checked)
                {
                    _payAccount += "工行7578#;";
                }
                if (this.chkABC2673.Checked)
                {
                    _payAccount += "农行2673#;";
                }
                if (this.chkCMBC0361.Checked)
                {
                    _payAccount += "中生0361#;";
                }
                if (this.chkGYWechat.Checked)
                {
                    _payAccount += "GY微信;";
                }
                _payAccount = _payAccount.TrimEnd(new char[] { ';' });
                #endregion

                #region 3
                var _payee = this.txtPayee.Text.Trim();
                var _payeePhone = this.txtPayeePhone.Text.Trim();
                var _payeeAccount = this.txtPayeeAccount.Text.Trim();
                var _payeeBank = this.txtPayeeBank.Text.Trim();
                var _exportAmount = this.txtExportAmount.Text.Trim();
                var _poundage = this.txtPoundage.Text.Trim();
                var _exportDate = this.dtExportDate.Text.Trim();
                var _remark = this.txtRemark.Text.Trim();
                #endregion

                #region 4
                if (string.IsNullOrEmpty(_applyDate))
                {
                    this.dtApplyDate.Focus();
                    throw new Exception("申请日期不能为空！");
                }
                if (string.IsNullOrEmpty(_billNo))
                {
                    this.txtBillNo.Focus();
                    throw new Exception("申请单号不能为空！");
                }
                if (string.IsNullOrEmpty(_summary))
                {
                    this.txtSummary.Focus();
                    throw new Exception("摘要不能为空！");
                }
                if (string.IsNullOrEmpty(_amountToPay))
                {
                    this.txtAmountToPay.Focus();
                    throw new Exception("付款金额不能为空！");
                }
                if (string.IsNullOrEmpty(_payType))
                {
                    this.chkCash.Focus();
                    throw new Exception("请选择付款方式！");
                }
                if (string.IsNullOrEmpty(_payAccount))
                {
                    this.chkICBC7578.Focus();
                    throw new Exception("请选择付款人/银行/账号！");
                }
                if (string.IsNullOrEmpty(_payee))
                {
                    this.txtPayee.Focus();
                    throw new Exception("收款单位/收款人不能为空！");
                }
                if (string.IsNullOrEmpty(_payeeAccount))
                {
                    this.txtPayeeAccount.Focus();
                    throw new Exception("收款单位账号不能为空！");
                }
                if (string.IsNullOrEmpty(_payeeBank))
                {
                    this.txtPayeeBank.Focus();
                    throw new Exception("收款单位银行不能为空！");
                }
                #endregion

                _data.DepartMent = _department;
                _data.ApplyDate = Convert.ToDateTime(_applyDate);
                _data.BillNo = _billNo;
                _data.Summary = _summary;
                _data.TotalMonthCost =Convert.ToDecimal(_totalMonthCost==""?"0": _totalMonthCost);
                _data.PaidAmount =Convert.ToDecimal(_amountPaid==""?"0": _amountPaid);
                _data.AmountToPay= Convert.ToDecimal(_amountToPay == "" ? "0" : _amountToPay);
                _data.AmountToPayUpper = _amountToPayUpper;
                _data.PayType = _payType;
                _data.PayAccount = _payAccount;
                _data.Payee = _payee;
                _data.PayeePhone = _payeePhone;
                _data.PayeeAccount = _payeeAccount;
                _data.PayeeBank = _payeeBank;
                _data.ExportAmount = Convert.ToDecimal(_exportAmount=="" ? "0": _exportAmount);
                _data.Poundage = Convert.ToDecimal(_poundage ==""? "0": _poundage);
                if (_exportDate != "")
                {
                    _data.ExportDate = Convert.ToDateTime(_exportDate);
                }
                else
                {
                    _data.ExportDate = null;
                }
                _data.Remark = _remark;
            }
            finally { }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtDepartment.EditValue = string.Empty;
            this.dtApplyDate.EditValue = DateTime.Now;
            //this.txtBillNo.EditValue = BillNo;
            GetBillNo();
            this.txtSummary.Text = string.Empty;
            this.txtTotalMonthCost.EditValue = string.Empty;
            this.txtAmountPaid.EditValue = string.Empty;
            this.txtAmountToPay.EditValue = string.Empty;
            this.txtAmountToPayUpper.EditValue = string.Empty;

            this.chkCash.Checked = false;
            this.chkRemit.Checked = false;
            this.chkCashCheck.Checked = false;
            this.chkTransferCheck.Checked = false;

            this.chkICBC7578.Checked = false;
            this.chkABC2673.Checked = false;
            this.chkCMBC0361.Checked = false;
            this.chkGYWechat.Checked = false;

            this.txtPayee.EditValue = string.Empty;
            this.txtPayeePhone.EditValue = string.Empty;
            this.txtPayeeAccount.EditValue = string.Empty;
            this.txtPayeeBank.EditValue = string.Empty;
            this.txtExportAmount.EditValue = string.Empty;
            this.txtPoundage.EditValue = string.Empty;
            this.dtExportDate.EditValue = string.Empty;
            this.txtRemark.Text = string.Empty;
        }

        private void txtAmountToPay_EditValueChanged(object sender, EventArgs e)
        {
            var _amountToPay = this.txtAmountToPay.EditValue;
            if (string.IsNullOrEmpty(_amountToPay.ToString()))
            {
                this.txtAmountToPayUpper.EditValue = string.Empty;
            }
            else
            {
                this.txtAmountToPayUpper.EditValue = CommonHelper.CmycurD(Convert.ToDecimal(_amountToPay));
            }
        }
    }
}