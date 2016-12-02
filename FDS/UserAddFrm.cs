using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fds
{
    public partial class UserAddFrm : Form
    {
        public UserAddFrm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            BLL.user_info userBll = new BLL.user_info();
            if (userBll.GetModel(txtUserName.Text.Trim()) != null)
            {
                MessageBox.Show("用户名已存在！");
                return;
            }
            if (txtUserPwd.Text == "")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            if (txtCrmPwd.Text != txtUserPwd.Text)
            {
                MessageBox.Show("两次输入的密码不相同！");
                return;
            }
            Model.user_info userModel = new Model.user_info();
            userModel.user_name = txtUserName.Text.Trim();
            userModel.user_isadmin = rdBtnYes.Checked;
            userModel.user_pwd = Maticsoft.Common.PasswordEncrypt.EncryptDES(txtUserPwd.Text);
            userModel.user_tel = txtUserTel.Text.Trim();
            userModel.user_email = txtUserEmail.Text.Trim();
            userModel.user_remark = rchTxtUserRemark.Text.Trim();
            userBll.Add(userModel);
            this.Close();

        }
    }
}
