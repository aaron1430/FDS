using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace fds
{
    public partial class LoginForm : Form
    {
        private Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public LoginForm()
        {
            //Sunisoft.IrisSkin.SkinEngine se = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            //se.SkinFile = Application.StartupPath + "//Skins//XPBlue.ssk";
            //se.SkinAllForm = true;
            InitializeComponent();
            int runCount = int.Parse(ConfigurationManager.AppSettings.Get("runCount"));
            if (runCount == 0)
            {
                RestoreDataFrm rdf = new RestoreDataFrm();
                rdf.initDB();
                initAdmin();

            }
            if (runCount < 999)
            {
                cfa.AppSettings.Settings["runCount"].Value = (runCount + 1).ToString();
                cfa.Save();
            }

            txtUser.Text = ConfigurationManager.AppSettings.Get("lastUser");
            txtPwd.Text = Maticsoft.Common.PasswordEncrypt.DecryptDES(ConfigurationManager.AppSettings.Get("lastUserPwd"));
            if (txtPwd.Text != "")
            {
                chkbxRmbrPwd.Checked = true;
            }
        }

        private void initAdmin()
        {
            BLL.user_info userBll = new BLL.user_info();
            Model.user_info admin = new Model.user_info();
            admin.user_id = 1;
            admin.user_name = "admin";
            admin.user_remark = "系统管理员";
            admin.user_pwd = Maticsoft.Common.PasswordEncrypt.EncryptDES("admin");
            admin.user_isadmin = true;
            userBll.Add(admin);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            BLL.user_info userBll = new BLL.user_info();
            Model.user_info userModel = new Model.user_info();
            string userName = txtUser.Text;
            string userPwd = txtPwd.Text;
            userModel = userBll.GetModel(userName);
            if (userModel == null)
            {
                MessageBox.Show("用户不存在！");
                return;
            }
            if (Maticsoft.Common.PasswordEncrypt.EncryptDES(userPwd) == userModel.user_pwd)
            {

                cfa.AppSettings.Settings["lastUser"].Value = userName;
                if (chkbxRmbrPwd.Checked)
                {
                    cfa.AppSettings.Settings["lastUserPwd"].Value = Maticsoft.Common.PasswordEncrypt.EncryptDES(userPwd);
                }
                else
                {
                    cfa.AppSettings.Settings["lastUserPwd"].Value = "";
                }
                cfa.Save();
                constants.currentUser = userModel;
                this.Hide();
                MainForm main = new MainForm();
                main.Show();
            }
            else
            {
                MessageBox.Show("密码错误！");
            }
        }
    }
}
