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
    public partial class UserEditFrm : Form
    {
        private Model.user_info editUser;
        public UserEditFrm()
        {
            InitializeComponent();
        }

        public UserEditFrm(Model.user_info editUser, bool editMyInfo)
        {
            InitializeComponent();
            this.editUser = editUser;
            txtUserName.Text = editUser.user_name;
            txtUserTel.Text = editUser.user_tel;
            rdBtnYes.Checked = editUser.user_isadmin;
            txtUserEmail.Text = editUser.user_email;
            rchTxtUserRemark.Text = editUser.user_remark;
            if (editMyInfo)
            {
                rdBtnYes.Enabled = false;
                rdBtnNo.Enabled = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            BLL.user_info userBll = new BLL.user_info();
            Model.user_info userModel = userBll.GetModel(txtUserName.Text.Trim());
            if (userModel != null && userModel.user_id != this.editUser.user_id)
            {
                MessageBox.Show("用户名已存在！");
                return;
            }
            editUser.user_name = txtUserName.Text.Trim();
            editUser.user_tel = txtUserTel.Text.Trim();
            editUser.user_isadmin = rdBtnYes.Checked;
            editUser.user_email = txtUserEmail.Text.Trim();
            editUser.user_remark = rchTxtUserRemark.Text.Trim();
            userBll.Update(editUser);
            MessageBox.Show("修改成功！");
            this.Close();
        }
    }
}
