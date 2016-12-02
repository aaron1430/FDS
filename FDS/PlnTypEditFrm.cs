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
    public partial class PlnTypEditFrm : Form
    {
        private Model.plane_type EditModel;
        public PlnTypEditFrm(Model.plane_type EditModel)
        {
            InitializeComponent();
            this.EditModel = EditModel;
            txtName.Text = EditModel.ptype_name;
            rchTxtRemark.Text = EditModel.plane_remark;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("型号名称不能为空！");
                return;
            }
            BLL.plane_type Bll = new BLL.plane_type();
            Model.plane_type Model = Bll.GetModel(txtName.Text.Trim());
            if (Model != null && Model.ptype_id != this.EditModel.ptype_id)
            {
                MessageBox.Show("型号已存在！");
                return;
            }
            EditModel.ptype_name = txtName.Text.Trim();
            EditModel.plane_remark = rchTxtRemark.Text;
            Bll.Update(EditModel);
            MessageBox.Show("修改成功！");
            this.Close();
        }
    }
}
