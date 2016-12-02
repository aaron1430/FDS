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
    public partial class TimePointAddFrm : Form
    {
        public TimePointAddFrm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("故障时机不能为空！");
                return;
            }
            BLL.time_point Bll = new BLL.time_point();
            if (Bll.GetModel(txtName.Text.Trim()) != null)
            {
                MessageBox.Show("故障时机已存在！");
                return;
            }
            Model.time_point addModel = new Model.time_point();
            addModel.tpoint_value = txtName.Text.Trim();
            addModel.tpoint_remark = rchTxtRemark.Text;
            Bll.Add(addModel);
            this.Close();
        }
    }
}
