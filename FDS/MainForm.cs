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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            if (!constants.currentUser.user_isadmin)
            {
                用户管理ToolStripMenuItem.Enabled = false;
                事件序列图维护ToolStripMenuItem.Enabled = false;
                案例维护ToolStripMenuItem.Enabled = false;
                数据库维护ToolStripMenuItem.Enabled = false;
            }
            WelcomeFrm welcomeFrm = new WelcomeFrm(this);
            welcomeFrm.Show();
        }

        private void MianForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private UserMngFrom userMngForm;
        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userMngForm == null)
            {
                userMngForm = new UserMngFrom(this);
                userMngForm.Show();
            }
            else
            {
                userMngForm.Activate();
            }
        }

        private void 修改个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool myInfo = true;
            UserEditFrm userEditFrm = new UserEditFrm(constants.currentUser, myInfo);
            userEditFrm.ShowDialog();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserEditMyPwd editMyPwd = new UserEditMyPwd();
            editMyPwd.ShowDialog();
        }
        private FaultHistoryForm faultHistoryFrm;
        private void 案例推理诊断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (faultHistoryFrm == null)
            {
                faultHistoryFrm = new FaultHistoryForm(this);
                faultHistoryFrm.Show();
            }
            else
            {
                faultHistoryFrm.Activate();
            }
        }
        private FailureTreeFrm failureTreeFrm;
        private void 事件序列图查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (failureTreeFrm == null)
            {
                failureTreeFrm = new FailureTreeFrm(this);
                failureTreeFrm.Show();
            }
            else
            {
                failureTreeFrm.Activate();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 案例维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (faultHistoryFrm == null)
            {
                faultHistoryFrm = new FaultHistoryForm(this);
                faultHistoryFrm.Show();
            }
            else
            {
                faultHistoryFrm.Activate();
            }
        }

        private void 事件序列图维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (failureTreeFrm == null)
            {
                failureTreeFrm = new FailureTreeFrm(this);
                failureTreeFrm.Show();
            }
            else
            {
                failureTreeFrm.Activate();
            }
        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutFrm about = new AboutFrm();
            about.ShowDialog();
        }

        private PlaneTypeMngFrm planeTypeMngFrm;
        private void 飞机型号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (planeTypeMngFrm == null)
            {
                planeTypeMngFrm = new PlaneTypeMngFrm(this);
                planeTypeMngFrm.Show();
            }
            else
            {
                planeTypeMngFrm.Activate();
            }
        }

        private TimePointMngFrm timePointMngFrm;
        private void 故障时机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timePointMngFrm == null)
            {
                timePointMngFrm = new TimePointMngFrm(this);
                timePointMngFrm.Show();
            }
            else
            {
                timePointMngFrm.Activate();
            }
        }
        private FailSystemMngFrm failSystemMngFrm;
        private void 故障系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (failSystemMngFrm == null)
            {
                failSystemMngFrm = new FailSystemMngFrm(this);
                failSystemMngFrm.Show();
            }
            else
            {
                failSystemMngFrm.Activate();
            }
        }

        private void 重置数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreDataFrm rdf = new RestoreDataFrm();
            rdf.ShowDialog();
        }

    }
}
