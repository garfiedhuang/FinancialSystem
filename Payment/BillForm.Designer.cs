namespace Com.Garfield.Payment
{
    partial class BillForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.txtExportAmount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtBillNo = new DevExpress.XtraEditors.TextEdit();
            this.txtDepartment = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.dtApplyDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotalMonthCost = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtAmountPaid = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.txtAmountToPay = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.chkCash = new DevExpress.XtraEditors.CheckEdit();
            this.chkRemit = new DevExpress.XtraEditors.CheckEdit();
            this.chkCashCheck = new DevExpress.XtraEditors.CheckEdit();
            this.chkTransferCheck = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.chkICBC7578 = new DevExpress.XtraEditors.CheckEdit();
            this.chkABC2673 = new DevExpress.XtraEditors.CheckEdit();
            this.chkGYWechat = new DevExpress.XtraEditors.CheckEdit();
            this.txtPayee = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtPayeePhone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.txtPayeeAccount = new DevExpress.XtraEditors.TextEdit();
            this.txtPayeeBank = new DevExpress.XtraEditors.TextEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPoundage = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dtExportDate = new DevExpress.XtraEditors.DateEdit();
            this.chkCMBC0361 = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtAmountToPayUpper = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExportAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtApplyDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtApplyDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMonthCost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountPaid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountToPay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCash.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCashCheck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTransferCheck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkICBC7578.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkABC2673.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGYWechat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayeePhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayeeAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayeeBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPoundage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtExportDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtExportDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCMBC0361.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountToPayUpper.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(768, 518);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 31);
            this.btnClear.TabIndex = 56;
            this.btnClear.Text = "Clear(重置)";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(653, 518);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 31);
            this.btnSave.TabIndex = 55;
            this.btnSave.Text = "Save(保存)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(191, 105);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(682, 22);
            this.txtSummary.TabIndex = 72;
            // 
            // txtExportAmount
            // 
            this.txtExportAmount.EditValue = "";
            this.txtExportAmount.Location = new System.Drawing.Point(190, 376);
            this.txtExportAmount.Name = "txtExportAmount";
            this.txtExportAmount.Properties.Mask.EditMask = "c";
            this.txtExportAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtExportAmount.Size = new System.Drawing.Size(157, 20);
            this.txtExportAmount.TabIndex = 68;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.Location = new System.Drawing.Point(63, 369);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(110, 28);
            this.labelControl6.TabIndex = 64;
            this.labelControl6.Text = "Export Amount\r\n(出纳确认汇出金额):";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.Location = new System.Drawing.Point(664, 58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 28);
            this.labelControl1.TabIndex = 67;
            this.labelControl1.Text = "Bill No.\r\n(单号):";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.Location = new System.Drawing.Point(126, 98);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 28);
            this.labelControl2.TabIndex = 69;
            this.labelControl2.Text = "Summary\r\n(摘要):";
            // 
            // txtBillNo
            // 
            this.txtBillNo.EditValue = "";
            this.txtBillNo.Location = new System.Drawing.Point(717, 65);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(156, 20);
            this.txtBillNo.TabIndex = 57;
            // 
            // txtDepartment
            // 
            this.txtDepartment.EditValue = "";
            this.txtDepartment.Location = new System.Drawing.Point(191, 66);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(156, 20);
            this.txtDepartment.TabIndex = 57;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl9.Location = new System.Drawing.Point(110, 59);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(66, 28);
            this.labelControl9.TabIndex = 67;
            this.labelControl9.Text = "Department\r\n(申请部门):";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl10.Location = new System.Drawing.Point(390, 57);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(62, 28);
            this.labelControl10.TabIndex = 67;
            this.labelControl10.Text = "Apply Date\r\n(申请日期):";
            // 
            // dtApplyDate
            // 
            this.dtApplyDate.EditValue = null;
            this.dtApplyDate.Location = new System.Drawing.Point(465, 66);
            this.dtApplyDate.Name = "dtApplyDate";
            this.dtApplyDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtApplyDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtApplyDate.Size = new System.Drawing.Size(156, 20);
            this.dtApplyDate.TabIndex = 58;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl11.Location = new System.Drawing.Point(80, 138);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(95, 28);
            this.labelControl11.TabIndex = 64;
            this.labelControl11.Text = "Total Month Cost\r\n(本月总费用):";
            // 
            // txtTotalMonthCost
            // 
            this.txtTotalMonthCost.EditValue = "";
            this.txtTotalMonthCost.Location = new System.Drawing.Point(191, 148);
            this.txtTotalMonthCost.Name = "txtTotalMonthCost";
            this.txtTotalMonthCost.Properties.Mask.EditMask = "c";
            this.txtTotalMonthCost.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalMonthCost.Size = new System.Drawing.Size(274, 20);
            this.txtTotalMonthCost.TabIndex = 68;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl12.Location = new System.Drawing.Point(514, 137);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(70, 28);
            this.labelControl12.TabIndex = 64;
            this.labelControl12.Text = "Amount Paid\r\n(已付金额):";
            // 
            // txtAmountPaid
            // 
            this.txtAmountPaid.EditValue = "";
            this.txtAmountPaid.Location = new System.Drawing.Point(599, 148);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.Properties.Mask.EditMask = "c";
            this.txtAmountPaid.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAmountPaid.Size = new System.Drawing.Size(274, 20);
            this.txtAmountPaid.TabIndex = 68;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl13.Location = new System.Drawing.Point(88, 177);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(86, 28);
            this.labelControl13.TabIndex = 64;
            this.labelControl13.Text = "Amount To Pay\r\n(付款金额):";
            // 
            // txtAmountToPay
            // 
            this.txtAmountToPay.EditValue = "";
            this.txtAmountToPay.Location = new System.Drawing.Point(191, 187);
            this.txtAmountToPay.Name = "txtAmountToPay";
            this.txtAmountToPay.Properties.Mask.EditMask = "c";
            this.txtAmountToPay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAmountToPay.Size = new System.Drawing.Size(274, 20);
            this.txtAmountToPay.TabIndex = 68;
            this.txtAmountToPay.EditValueChanged += new System.EventHandler(this.txtAmountToPay_EditValueChanged);
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl14.Location = new System.Drawing.Point(112, 219);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(62, 28);
            this.labelControl14.TabIndex = 64;
            this.labelControl14.Text = "Pay Type\r\n(付款方式):";
            // 
            // chkCash
            // 
            this.chkCash.Location = new System.Drawing.Point(191, 227);
            this.chkCash.Name = "chkCash";
            this.chkCash.Properties.Caption = "现金";
            this.chkCash.Size = new System.Drawing.Size(75, 19);
            this.chkCash.TabIndex = 73;
            // 
            // chkRemit
            // 
            this.chkRemit.Location = new System.Drawing.Point(291, 228);
            this.chkRemit.Name = "chkRemit";
            this.chkRemit.Properties.Caption = "汇款";
            this.chkRemit.Size = new System.Drawing.Size(75, 19);
            this.chkRemit.TabIndex = 73;
            // 
            // chkCashCheck
            // 
            this.chkCashCheck.Location = new System.Drawing.Point(377, 228);
            this.chkCashCheck.Name = "chkCashCheck";
            this.chkCashCheck.Properties.Caption = "现金支票";
            this.chkCashCheck.Size = new System.Drawing.Size(75, 19);
            this.chkCashCheck.TabIndex = 73;
            // 
            // chkTransferCheck
            // 
            this.chkTransferCheck.Location = new System.Drawing.Point(488, 228);
            this.chkTransferCheck.Name = "chkTransferCheck";
            this.chkTransferCheck.Properties.Caption = "转账支票";
            this.chkTransferCheck.Size = new System.Drawing.Size(75, 19);
            this.chkTransferCheck.TabIndex = 73;
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl15.Location = new System.Drawing.Point(66, 255);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(108, 28);
            this.labelControl15.TabIndex = 64;
            this.labelControl15.Text = "Pay Account\r\n(付款人/银行/账号):";
            // 
            // chkICBC7578
            // 
            this.chkICBC7578.Location = new System.Drawing.Point(190, 263);
            this.chkICBC7578.Name = "chkICBC7578";
            this.chkICBC7578.Properties.Caption = "工行7578#";
            this.chkICBC7578.Size = new System.Drawing.Size(95, 19);
            this.chkICBC7578.TabIndex = 73;
            // 
            // chkABC2673
            // 
            this.chkABC2673.Location = new System.Drawing.Point(291, 264);
            this.chkABC2673.Name = "chkABC2673";
            this.chkABC2673.Properties.Caption = "农行2673#";
            this.chkABC2673.Size = new System.Drawing.Size(90, 19);
            this.chkABC2673.TabIndex = 73;
            // 
            // chkGYWechat
            // 
            this.chkGYWechat.Location = new System.Drawing.Point(488, 264);
            this.chkGYWechat.Name = "chkGYWechat";
            this.chkGYWechat.Properties.Caption = "GY微信";
            this.chkGYWechat.Size = new System.Drawing.Size(75, 19);
            this.chkGYWechat.TabIndex = 73;
            // 
            // txtPayee
            // 
            this.txtPayee.EditValue = "";
            this.txtPayee.Location = new System.Drawing.Point(190, 303);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(275, 20);
            this.txtPayee.TabIndex = 57;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.Location = new System.Drawing.Point(70, 296);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(103, 28);
            this.labelControl4.TabIndex = 67;
            this.labelControl4.Text = "Payee\r\n(收款单位/收款人):";
            // 
            // txtPayeePhone
            // 
            this.txtPayeePhone.EditValue = "";
            this.txtPayeePhone.Location = new System.Drawing.Point(599, 303);
            this.txtPayeePhone.Name = "txtPayeePhone";
            this.txtPayeePhone.Size = new System.Drawing.Size(274, 20);
            this.txtPayeePhone.TabIndex = 57;
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl16.Location = new System.Drawing.Point(513, 296);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(74, 28);
            this.labelControl16.TabIndex = 67;
            this.labelControl16.Text = "Payee Phone\r\n(收款人电话):";
            // 
            // txtPayeeAccount
            // 
            this.txtPayeeAccount.EditValue = "";
            this.txtPayeeAccount.Location = new System.Drawing.Point(190, 338);
            this.txtPayeeAccount.Name = "txtPayeeAccount";
            this.txtPayeeAccount.Size = new System.Drawing.Size(275, 20);
            this.txtPayeeAccount.TabIndex = 57;
            // 
            // txtPayeeBank
            // 
            this.txtPayeeBank.EditValue = "";
            this.txtPayeeBank.Location = new System.Drawing.Point(599, 338);
            this.txtPayeeBank.Name = "txtPayeeBank";
            this.txtPayeeBank.Size = new System.Drawing.Size(274, 20);
            this.txtPayeeBank.TabIndex = 57;
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl17.Location = new System.Drawing.Point(87, 331);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(86, 28);
            this.labelControl17.TabIndex = 67;
            this.labelControl17.Text = "Payee Account\r\n(收款单位账号):";
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl18.Location = new System.Drawing.Point(502, 331);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(86, 28);
            this.labelControl18.TabIndex = 67;
            this.labelControl18.Text = "Payee Bank\r\n(收款单位银行):";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.Location = new System.Drawing.Point(399, 369);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 28);
            this.labelControl3.TabIndex = 64;
            this.labelControl3.Text = "Poundage\r\n(手续费):";
            // 
            // txtPoundage
            // 
            this.txtPoundage.EditValue = "";
            this.txtPoundage.Location = new System.Drawing.Point(465, 376);
            this.txtPoundage.Name = "txtPoundage";
            this.txtPoundage.Properties.Mask.EditMask = "c";
            this.txtPoundage.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPoundage.Size = new System.Drawing.Size(157, 20);
            this.txtPoundage.TabIndex = 68;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.Location = new System.Drawing.Point(639, 368);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(66, 28);
            this.labelControl5.TabIndex = 67;
            this.labelControl5.Text = "Export Date\r\n(汇出日期):";
            // 
            // dtExportDate
            // 
            this.dtExportDate.EditValue = null;
            this.dtExportDate.Location = new System.Drawing.Point(717, 376);
            this.dtExportDate.Name = "dtExportDate";
            this.dtExportDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtExportDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtExportDate.Size = new System.Drawing.Size(156, 20);
            this.dtExportDate.TabIndex = 58;
            // 
            // chkCMBC0361
            // 
            this.chkCMBC0361.Location = new System.Drawing.Point(377, 264);
            this.chkCMBC0361.Name = "chkCMBC0361";
            this.chkCMBC0361.Properties.Caption = "中生0361#";
            this.chkCMBC0361.Size = new System.Drawing.Size(90, 19);
            this.chkCMBC0361.TabIndex = 73;
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl19.Location = new System.Drawing.Point(133, 413);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(40, 28);
            this.labelControl19.TabIndex = 69;
            this.labelControl19.Text = "Remark\r\n(备注):";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(190, 413);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(682, 69);
            this.txtRemark.TabIndex = 72;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl7.Location = new System.Drawing.Point(495, 177);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(86, 28);
            this.labelControl7.TabIndex = 64;
            this.labelControl7.Text = "Amount To Pay\r\n(付款金额大写):";
            // 
            // txtAmountToPayUpper
            // 
            this.txtAmountToPayUpper.EditValue = "";
            this.txtAmountToPayUpper.Enabled = false;
            this.txtAmountToPayUpper.Location = new System.Drawing.Point(598, 187);
            this.txtAmountToPayUpper.Name = "txtAmountToPayUpper";
            this.txtAmountToPayUpper.Size = new System.Drawing.Size(274, 20);
            this.txtAmountToPayUpper.TabIndex = 68;
            // 
            // BillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 626);
            this.Controls.Add(this.chkTransferCheck);
            this.Controls.Add(this.chkGYWechat);
            this.Controls.Add(this.chkCashCheck);
            this.Controls.Add(this.chkCMBC0361);
            this.Controls.Add(this.chkABC2673);
            this.Controls.Add(this.chkRemit);
            this.Controls.Add(this.chkICBC7578);
            this.Controls.Add(this.chkCash);
            this.Controls.Add(this.dtExportDate);
            this.Controls.Add(this.dtApplyDate);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.txtAmountPaid);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.txtAmountToPayUpper);
            this.Controls.Add(this.txtAmountToPay);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.txtTotalMonthCost);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.txtPoundage);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtExportAmount);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl18);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl19);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtPayeeBank);
            this.Controls.Add(this.txtPayeeAccount);
            this.Controls.Add(this.txtPayeePhone);
            this.Controls.Add(this.txtPayee);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.txtBillNo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Name = "BillForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New";
            this.Load += new System.EventHandler(this.BillForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtExportAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtApplyDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtApplyDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMonthCost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountPaid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountToPay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCash.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCashCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTransferCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkICBC7578.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkABC2673.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGYWechat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayeePhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayeeAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayeeBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPoundage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtExportDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtExportDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCMBC0361.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountToPayUpper.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.TextBox txtSummary;
        private DevExpress.XtraEditors.TextEdit txtExportAmount;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtBillNo;
        private DevExpress.XtraEditors.TextEdit txtDepartment;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.DateEdit dtApplyDate;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtTotalMonthCost;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtAmountPaid;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TextEdit txtAmountToPay;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.CheckEdit chkCash;
        private DevExpress.XtraEditors.CheckEdit chkRemit;
        private DevExpress.XtraEditors.CheckEdit chkCashCheck;
        private DevExpress.XtraEditors.CheckEdit chkTransferCheck;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.CheckEdit chkICBC7578;
        private DevExpress.XtraEditors.CheckEdit chkABC2673;
        private DevExpress.XtraEditors.CheckEdit chkGYWechat;
        private DevExpress.XtraEditors.TextEdit txtPayee;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtPayeePhone;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.TextEdit txtPayeeAccount;
        private DevExpress.XtraEditors.TextEdit txtPayeeBank;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPoundage;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DateEdit dtExportDate;
        private DevExpress.XtraEditors.CheckEdit chkCMBC0361;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private System.Windows.Forms.TextBox txtRemark;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtAmountToPayUpper;
    }
}