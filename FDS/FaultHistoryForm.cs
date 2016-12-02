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
    public partial class FaultHistoryForm : Form
    {
        private List<int> plnTypIdLst;
        private List<int> tmPntIdLst;
        private List<int> flSysIdLst;
        public List<Model.v_fail_history> vfhList;
        public FaultHistoryForm()
        {
            InitializeComponent();
        }
        public FaultHistoryForm(Form main)
        {
            InitializeComponent();
            this.MdiParent = main;
            this.WindowState = FormWindowState.Maximized;
            if (!constants.currentUser.user_isadmin)
            {
                btnAdd.Hide();
                btnDelAll.Hide();
                btnDelete.Hide();
                btnEdit.Hide();
                contextMenuStrip1.Items[1].Visible = false;
                contextMenuStrip1.Items[2].Visible = false;
                contextMenuStrip1.Items[3].Visible = false;
            }
            initCntls();
            vfhList = new List<Model.v_fail_history>();
        }

        private void initCntls()
        {
            initCmbPlaneType();
            initCmbTimePoint();
            initCmbFailSystem();
        }

        private void initCmbPlaneType()
        {
            plnTypIdLst = new List<int>();
            BLL.plane_type plnTypBll = new BLL.plane_type();
            List<Model.plane_type> plnTypList = new List<Model.plane_type>();
            plnTypList = plnTypBll.GetModelList("");

            for (int i = 0; i < plnTypList.Count; i++)
            {
                cmbPlaneType.Items.Add(plnTypList[i].ptype_name);
                plnTypIdLst.Add(plnTypList[i].ptype_id);
            }
        }

        private void initCmbTimePoint()
        {
            tmPntIdLst = new List<int>();
            BLL.time_point tmPntBll = new BLL.time_point();
            List<Model.time_point> tmPntList = new List<Model.time_point>();
            tmPntList = tmPntBll.GetModelList("");
            for (int i = 0; i < tmPntList.Count; i++)
            {
                cmbTimePoint.Items.Add(tmPntList[i].tpoint_value);
                tmPntIdLst.Add(tmPntList[i].tpoint_id);
            }
        }

        private void initCmbFailSystem()
        {
            flSysIdLst = new List<int>();
            BLL.fail_system flSysBll = new BLL.fail_system();
            List<Model.fail_system> flSysList = new List<Model.fail_system>();
            flSysList = flSysBll.GetModelList("");
            for (int i = 0; i < flSysList.Count; i++)
            {
                cmbFailSystem.Items.Add(flSysList[i].system_name);
                flSysIdLst.Add(flSysList[i].system_id);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            BLL.v_fail_history vfhBll = new BLL.v_fail_history();
            string sqlWhere = " 1+1 ";
            if (cmbFailSystem.SelectedIndex != -1)
            {
                sqlWhere += "and system_id=" + flSysIdLst[cmbFailSystem.SelectedIndex];
            }
            if (cmbPlaneType.SelectedIndex != -1)
            {
                sqlWhere += " and ptype_id= " + plnTypIdLst[cmbPlaneType.SelectedIndex];
            }
            if (cmbTimePoint.SelectedIndex != -1)
            {
                sqlWhere += " and tpoint_id= " + tmPntIdLst[cmbTimePoint.SelectedIndex];
            }
            if (txtPhenomenon.Text.Trim() != "")
            {
                string[] keyWdsArr = txtPhenomenon.Text.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                sqlWhere += " and ( ";
                for (int i = 0; i < keyWdsArr.Length; i++)
                {
                    sqlWhere += " fh_keywd like '%" + keyWdsArr[i] + "%' or " + " fh_caseid like '%" + keyWdsArr[i] + "%' or ";
                }
                sqlWhere = sqlWhere.Substring(0, sqlWhere.Length - 3) + ")";
            }
            sqlWhere += " order by fh_id desc ";

            vfhList = vfhBll.GetModelList(sqlWhere);
            ListViewLoadData();
        }

        public void ListViewLoadData()
        {
            this.listView1.Items.Clear();
            listView1.BeginUpdate();
            for (int i = 0; i < vfhList.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = 1 + i + "";
                lvi.Tag = vfhList[i].fh_id;
                lvi.SubItems.Add(vfhList[i].fh_title);
                lvi.SubItems.Add(vfhList[i].fh_caseid);
                lvi.SubItems.Add(vfhList[i].ptype_name);
                lvi.SubItems.Add(vfhList[i].tpoint_value);
                lvi.SubItems.Add(vfhList[i].system_name);
                lvi.SubItems.Add(vfhList[i].fh_keywd);
                lvi.SubItems.Add(vfhList[i].fh_phenomenon);
                lvi.SubItems.Add(vfhList[i].fh_description);
                lvi.SubItems.Add(vfhList[i].fh_cause);
                lvi.SubItems.Add(vfhList[i].fh_suggest);
                lvi.SubItems.Add(vfhList[i].fh_explain);
                lvi.SubItems.Add(vfhList[i].fh_reference);
                lvi.SubItems.Add(vfhList[i].fh_experience);
                lvi.SubItems.Add(vfhList[i].user_name);
                lvi.SubItems.Add(vfhList[i].fh_addtime.ToString("yyyy-MM-dd HH:mm"));
                this.listView1.Items.Add(lvi);
            }
            listView1.EndUpdate();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            Model.v_fail_history detail = vfhList[listView1.SelectedIndices[0]];
            FaultHistoryDetailsFrm faultHistoryDetailsFrm = new FaultHistoryDetailsFrm(detail);
            faultHistoryDetailsFrm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[2].Enabled = false;
                contextMenuStrip1.Items[3].Enabled = false;
            }
            else
            {
                contextMenuStrip1.Items[0].Enabled = true;
                contextMenuStrip1.Items[2].Enabled = true;
                contextMenuStrip1.Items[3].Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FaultHistoryAddFrm faultHistoryAddFrm = new FaultHistoryAddFrm(this);
            faultHistoryAddFrm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要修改的项！");
                return;
            }
            Model.v_fail_history editModel = vfhList[listView1.SelectedIndices[0]];
            FaultHistoryEditFrm faultHistoryEditFrm = new FaultHistoryEditFrm(this, editModel);
            faultHistoryEditFrm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
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
                    BLL.fault_history fhBll = new BLL.fault_history();
                    if (fhBll.Delete(delID))
                    {
                        MessageBox.Show("删除成功！");
                        btnSearch_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("操作失败！");
                    }
                }
            }
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("该操作将清空所有故障案例，是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("真的要继续吗？该操作将清空所有故障案例！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BLL.fault_history fhBll = new BLL.fault_history();
                    if (fhBll.DeleteAll())
                    {
                        MessageBox.Show("删除成功！");
                        btnSearch_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("操作失败！");
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("没有数据可导出！");
                return;
            }
            string fileName = "";
            SaveFileDialog SourceFileDialog = new SaveFileDialog();
            SourceFileDialog.Filter = "Excel文件|*.xls|所有文件|*.*";
            if (SourceFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = SourceFileDialog.FileName;
            }
            else
            {
                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("序号");
            dt.Columns.Add("案例标题");
            dt.Columns.Add("案例编号");
            dt.Columns.Add("飞机型号");
            dt.Columns.Add("故障时机");
            dt.Columns.Add("故障系统");
            dt.Columns.Add("故障关键字");
            dt.Columns.Add("故障现象");
            dt.Columns.Add("相关描述");
            dt.Columns.Add("原因");
            dt.Columns.Add("修理措施建议");
            dt.Columns.Add("解释");
            dt.Columns.Add("参考资料");
            dt.Columns.Add("经验教训");
            dt.Columns.Add("添加用户");
            dt.Columns.Add("添加时间");
            for (int i = 0; i < vfhList.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i + 1;
                dr[1] = vfhList[i].fh_title;
                dr[2] = vfhList[i].fh_caseid;
                dr[3] = vfhList[i].ptype_name;
                dr[4] = vfhList[i].tpoint_value;
                dr[5] = vfhList[i].system_name;
                dr[6] = vfhList[i].fh_keywd;
                dr[7] = vfhList[i].fh_phenomenon;
                dr[8] = vfhList[i].fh_description;
                dr[9] = vfhList[i].fh_cause;
                dr[10] = vfhList[i].fh_suggest;
                dr[11] = vfhList[i].fh_explain;
                dr[12] = vfhList[i].fh_reference;
                dr[13] = vfhList[i].fh_experience;
                dr[14] = vfhList[i].user_name;
                dr[15] = vfhList[i].fh_addtime.ToString("yyyy-MM-dd HH:mm");
                dt.Rows.Add(dr);
            }
            if (NPOIHelper.Export(dt, "案例推理诊断", fileName))
            {
                MessageBox.Show("文件已保存至：" + fileName);
            }
        }

    }
}
