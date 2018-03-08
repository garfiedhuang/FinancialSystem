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
using Com.Garfield.CashFlow.business;
using Com.Garfield.Utility;
using Com.Garfield.Utility.model;

namespace Com.Garfield.CashFlow
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //var aaa =  SecurityHelper.DesEncrypt("2018/03/10", SystemSetting.EncryptKey);
            var  _appKey = System.Configuration.ConfigurationManager.AppSettings["AppKey"];
            if (string.IsNullOrEmpty(_appKey))
            {
                MessageBox.Show("AppKey不存在，请联系系统管理员！QQ: 516156003", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                try
                {
                    _appKey = SecurityHelper.DesDecrypt(_appKey, SystemSetting.EncryptKey);
                    if (string.IsNullOrEmpty(_appKey)) throw new Exception("非法的AppKey");
                }
                catch
                {
                    MessageBox.Show("非法的AppKey，请联系系统管理员！QQ: 516156003", "提示", MessageBoxButtons.OK);
                    return;
                }

                var _expireDate = DateTime.Now;
                if (DateTime.TryParse(_appKey, out _expireDate))
                {
                    if (_expireDate < DateTime.Now)
                    {
                        MessageBox.Show("AppKey已过期，请联系系统管理员！QQ: 516156003", "提示", MessageBoxButtons.OK);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("AppKey加密格式不对，请联系系统管理员！QQ: 516156003", "提示", MessageBoxButtons.OK);
                    return;
                }
            }

            var _userName = this.txtUserName.Text.Trim();
            var _password = this.txtPassword.Text.Trim();
            var _system = this.cmbSystem.SelectedText;

            if (string.IsNullOrEmpty(_userName))
            {
                MessageBox.Show("账号不能为空！", "提示", MessageBoxButtons.OK);
                this.txtUserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(_password))
            {
                MessageBox.Show("密码不能为空！", "提示", MessageBoxButtons.OK);
                this.txtPassword.Focus();
                return;
            }

            try
            {
                LoginBLL.Login(_userName, _password);

                this.Hide();
                if (this.cmbSystem.Text == "Cash Flow System")
                {
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
                else
                {
                    Payment.MainForm mainForm = new Payment.MainForm();
                    mainForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("登录失败！"+ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
    }
}