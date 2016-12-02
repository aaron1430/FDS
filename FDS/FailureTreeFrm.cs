using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace fds
{
    public partial class FailureTreeFrm : Form
    {
        private List<int> plnTypIdLst;
        private List<int> tmPntIdLst;
        private List<int> flSysIdLst;
        public List<Model.v_failure_tree> vftList;
        public FailureTreeFrm()
        {
            InitializeComponent();
        }
        public FailureTreeFrm(Form main)
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
            vftList = new List<Model.v_failure_tree>();
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
            BLL.v_failure_tree vftBll = new BLL.v_failure_tree();
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
                    sqlWhere += " ft_keywd like '%" + keyWdsArr[i] + "%' or " + " ft_caseid like '%" + keyWdsArr[i] + "%' or ";
                }
                sqlWhere = sqlWhere.Substring(0, sqlWhere.Length - 3) + ")";
            }
            sqlWhere += " order by ft_id desc ";
            vftList = vftBll.GetModelList(sqlWhere);
            ListViewLoadData();
        }
        public void ListViewLoadData()
        {
            this.listView1.Items.Clear();
            listView1.BeginUpdate();
            for (int i = 0; i < vftList.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = 1 + i + "";
                lvi.Tag = vftList[i].ft_id;
                lvi.SubItems.Add(vftList[i].ft_caseid);
                lvi.SubItems.Add(vftList[i].ptype_name);
                lvi.SubItems.Add(vftList[i].tpoint_value);
                lvi.SubItems.Add(vftList[i].system_name);
                lvi.SubItems.Add(vftList[i].ft_keywd);
                lvi.SubItems.Add(vftList[i].user_name);
                lvi.SubItems.Add(vftList[i].ft_addtime.ToString("yyyy-MM-dd HH:mm"));

                this.listView1.Items.Add(lvi);
            }
            listView1.EndUpdate();
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

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            Model.v_failure_tree detail = vftList[listView1.SelectedIndices[0]];
            FailureTreeDetailFrm viewImageFrm = new FailureTreeDetailFrm(detail);
            viewImageFrm.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FailureTreeAddFrm failureTreeAddFrm = new FailureTreeAddFrm(this);
            failureTreeAddFrm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要修改的项！");
                return;
            }
            Model.v_failure_tree editModel = vftList[listView1.SelectedIndices[0]];
            FailureTreeEditFrm failureTreeDetailFrm = new FailureTreeEditFrm(editModel, this);
            failureTreeDetailFrm.ShowDialog();
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
                    BLL.failure_tree ftBll = new BLL.failure_tree();
                    if (ftBll.Delete(delID))
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
            if (MessageBox.Show("该操作将清空所有事件序列图数据，是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("真的要继续吗？该操作将清空所有事件序列图数据！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BLL.failure_tree ftBll = new BLL.failure_tree();
                    if (ftBll.DeleteAll())
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
            string filePath = "";
            SaveFileDialog SourceFileDialog = new SaveFileDialog();
            SourceFileDialog.Filter = "Excel文件|*.xls|所有文件|*.*";
            if (SourceFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = SourceFileDialog.FileName;
                filePath = SourceFileDialog.FileName.Substring(0, fileName.LastIndexOf('\\') + 1);
                if (!Directory.Exists(filePath + "事件序列图\\"))
                {
                    Directory.CreateDirectory(filePath + "事件序列图\\");
                }
                SourceFileDialog.Dispose();
            }
            else
            {
                SourceFileDialog.Dispose();
                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("序号");
            dt.Columns.Add("案例编号");
            dt.Columns.Add("飞机型号");
            dt.Columns.Add("故障时机");
            dt.Columns.Add("故障系统");
            dt.Columns.Add("故障关键字");
            dt.Columns.Add("事件序列图");
            dt.Columns.Add("事件代号");
            dt.Columns.Add("添加用户");
            dt.Columns.Add("添加时间");
            for (int i = 0; i < vftList.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i + 1;
                dr[1] = vftList[i].ft_caseid;
                dr[2] = vftList[i].ptype_name;
                dr[3] = vftList[i].tpoint_value;
                dr[4] = vftList[i].system_name;
                dr[5] = vftList[i].ft_keywd;
                dr[6] = vftList[i].ft_caseid + "-1";
                dr[7] = vftList[i].ft_caseid + "-2";
                dr[8] = vftList[i].user_name;
                dr[9] = vftList[i].ft_addtime.ToString("yyyy-MM-dd HH:mm");
                dt.Rows.Add(dr);
                File.WriteAllBytes(filePath + "事件序列图\\" + vftList[i].ft_caseid + "-1.jpg", vftList[i].ft_pic);
                File.WriteAllBytes(filePath + "事件序列图\\" + vftList[i].ft_caseid + "-2.jpg", vftList[i].ft_grid); //没有区分图片保存格式
            }
            if (NPOIHelper.Export(dt, "事件序列图", fileName))
            {
                MessageBox.Show("文件已保存至：\r\n" + fileName + "\r\n" + filePath + "事件序列图\\");
            }
        }

    }
}
