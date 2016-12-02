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
    public partial class FailSystemAddFrm : Form
    {
        public FailSystemAddFrm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("故障系统不能为空！");
                return;
            }
            BLL.fail_system Bll = new BLL.fail_system();
            if (Bll.GetModel(txtName.Text.Trim()) != null)
            {
                MessageBox.Show("故障系统已存在！");
                return;
            }
            Model.fail_system addModel = new Model.fail_system();
            addModel.system_name = txtName.Text.Trim();
            addModel.system_remark = rchTxtRemark.Text;
            Bll.Add(addModel);
            this.Close();
        }
    }
}
