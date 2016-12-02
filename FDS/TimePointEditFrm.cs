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
    public partial class TimePointEditFrm : Form
    {
        private Model.time_point EditModel;
        public TimePointEditFrm(Model.time_point EditModel)
        {
            InitializeComponent();
            this.EditModel = EditModel;
            txtName.Text = EditModel.tpoint_value;
            rchTxtRemark.Text = EditModel.tpoint_remark;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("故障时机不能为空！");
                return;
            }
            BLL.time_point Bll = new BLL.time_point();
            Model.time_point Model = Bll.GetModel(txtName.Text.Trim());
            if (Model != null && Model.tpoint_id != this.EditModel.tpoint_id)
            {
                MessageBox.Show("型号已存在！");
                return;
            }
            EditModel.tpoint_value = txtName.Text.Trim();
            EditModel.tpoint_remark = rchTxtRemark.Text;
            Bll.Update(EditModel);
            MessageBox.Show("修改成功！");
            this.Close();
        }
    }
}
