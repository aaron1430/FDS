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
    public partial class FailSystemEditFrm : Form
    {
        private Model.fail_system EditModel;
        public FailSystemEditFrm(Model.fail_system EditModel)
        {
            InitializeComponent();
            this.EditModel = EditModel;
            txtName.Text = EditModel.system_name;
            rchTxtRemark.Text = EditModel.system_remark;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("故障系统不能为空！");
                return;
            }
            BLL.fail_system Bll = new BLL.fail_system();
            Model.fail_system Model = Bll.GetModel(txtName.Text.Trim());
            if (Model != null && Model.system_id != this.EditModel.system_id)
            {
                MessageBox.Show("故障系统已存在！");
                return;
            }
            EditModel.system_name = txtName.Text.Trim();
            EditModel.system_remark = rchTxtRemark.Text;
            Bll.Update(EditModel);
            MessageBox.Show("修改成功！");
            this.Close();
        }
    }
}
