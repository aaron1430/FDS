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
    public partial class UserEditPwdFrm : Form
    {
        private Model.user_info editUser;
        public UserEditPwdFrm()
        {
            InitializeComponent();
        }
        public UserEditPwdFrm(Model.user_info editUser)
        {
            InitializeComponent();
            this.editUser = editUser;
            this.label2.Text = editUser.user_name;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtPwd.Text == "")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            if (txtPwd.Text != txtCfmPwd.Text)
            {
                MessageBox.Show("两次输入的密码不相同！");
                return;
            }
            editUser.user_pwd = Maticsoft.Common.PasswordEncrypt.EncryptDES(txtPwd.Text);
            BLL.user_info userBll = new BLL.user_info();
            userBll.Update(editUser);
            MessageBox.Show("修改成功！");
            this.Close();
        }

    }
}
