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
    public partial class UserMngFrom : Form
    {
        private List<Model.user_info> userList = new List<Model.user_info>();
        public UserMngFrom()
        {
            InitializeComponent();
        }
        public UserMngFrom(Form main)
        {
            InitializeComponent();
            this.MdiParent = main;
            this.WindowState = FormWindowState.Maximized;
            getAllUser();
        }
        private void getAllUser()
        {
            BLL.user_info userBll = new BLL.user_info();
            userList = userBll.GetModelList("1=1 order by user_id desc");
            loadUserList();
        }
        private void loadUserList()
        {
            this.listView1.Items.Clear();
            listView1.BeginUpdate();
            for (int i = 0; i < userList.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = 1 + i + "";
                lvi.Tag = userList[i].user_id;
                lvi.SubItems.Add(userList[i].user_name);
                if (userList[i].user_isadmin)
                {
                    lvi.SubItems.Add("是");
                }
                else
                {
                    lvi.SubItems.Add("否");
                }
                lvi.SubItems.Add(userList[i].user_tel);
                lvi.SubItems.Add(userList[i].user_email);
                lvi.SubItems.Add(userList[i].user_remark);

                this.listView1.Items.Add(lvi);
            }
            listView1.EndUpdate();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserAddFrm userAddFrm = new UserAddFrm();
            userAddFrm.ShowDialog();
            getAllUser();
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            getAllUser();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要删除的项！");
            }
            else
            {
                if (MessageBox.Show("是否删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int delID = (int)listView1.SelectedItems[0].Tag;
                    if (delID == 1)
                    {
                        MessageBox.Show("不能删除默认管理员！");
                        return;
                    }
                    BLL.user_info userBll = new BLL.user_info();
                    bool succ = false;
                    try { succ = userBll.Delete(delID); }
                    catch
                    {
                        MessageBox.Show("该项正在使用中！");
                        return;
                    }
                    if (succ)
                    {
                        MessageBox.Show("删除成功！");
                        getAllUser();
                    }
                    else
                    {
                        MessageBox.Show("操作失败！");
                    }
                }
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要修改的项！");
            }
            else
            {
                Model.user_info editUser = new Model.user_info();
                editUser = userList[listView1.SelectedIndices[0]];
                bool editMyInfo = false;
                UserEditFrm userEditFrm = new UserEditFrm(editUser, editMyInfo);
                userEditFrm.ShowDialog();
                getAllUser();
            }
        }

        private void btnEditPwd_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要设置的项！");
            }
            else
            {
                if (MessageBox.Show("该用户密码将被修改，请及时通知该用户最新密码，是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Model.user_info editUser = new Model.user_info();
                    editUser = userList[listView1.SelectedIndices[0]];
                    UserEditPwdFrm userEditPwdFrm = new UserEditPwdFrm(editUser);
                    userEditPwdFrm.ShowDialog();
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                contextMenuStrip1.Items[1].Enabled = false;
                contextMenuStrip1.Items[2].Enabled = false;
                contextMenuStrip1.Items[3].Enabled = false;
            }
            else
            {
                contextMenuStrip1.Items[1].Enabled = true;
                contextMenuStrip1.Items[2].Enabled = true;
                contextMenuStrip1.Items[3].Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BLL.user_info userBll = new BLL.user_info();
            userList = userBll.GetModelList("user_name like '%" + txtUserName.Text.Trim() + "%' order by user_id desc");
            loadUserList();
        }
    }
}
