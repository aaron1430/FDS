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
    public partial class UserEditMyPwd : Form
    {
        public UserEditMyPwd()
        {
            InitializeComponent();
            this.label2.Text = constants.currentUser.user_name;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Maticsoft.Common.PasswordEncrypt.EncryptDES(txtOldPwd.Text) != constants.currentUser.user_pwd)
            {
                MessageBox.Show("原密码输入错误！");
                return;
            }
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
            constants.currentUser.user_pwd = Maticsoft.Common.PasswordEncrypt.EncryptDES(txtPwd.Text);
            BLL.user_info userBll = new BLL.user_info();
            userBll.Update(constants.currentUser);
            MessageBox.Show("修改成功！");
            this.Close();
        }

    }
}
