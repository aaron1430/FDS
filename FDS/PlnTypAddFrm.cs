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
    public partial class PlnTypAddFrm : Form
    {
        public PlnTypAddFrm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("飞机型号不能为空！");
                return;
            }
            BLL.plane_type Bll = new BLL.plane_type();
            if (Bll.GetModel(txtName.Text.Trim()) != null)
            {
                MessageBox.Show("飞机型号已存在！");
                return;
            }
            Model.plane_type addModel = new Model.plane_type();
            addModel.ptype_name = txtName.Text.Trim();
            addModel.plane_remark = rchTxtRemark.Text;
            Bll.Add(addModel);
            this.Close();
        }
    }
}
