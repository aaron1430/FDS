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
    public partial class TimePointMngFrm : Form
    {
        public List<Model.time_point> modelList = new List<Model.time_point>();
        BLL.time_point Bll;
        public TimePointMngFrm(MainForm main)
        {
            InitializeComponent();
            this.MdiParent = main;
            this.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Maximized;
            Bll = new BLL.time_point();
            getAllList();
        }
        private void getAllList()
        {
            modelList = Bll.GetModelList("1=1 order by tpoint_id desc");
            loadList();
        }
        public void loadList()
        {
            this.listView1.Items.Clear();
            listView1.BeginUpdate();
            for (int i = 0; i < modelList.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = 1 + i + "";
                lvi.Tag = modelList[i].tpoint_id;
                lvi.SubItems.Add(modelList[i].tpoint_value);
                lvi.SubItems.Add(modelList[i].tpoint_remark);

                this.listView1.Items.Add(lvi);
            }
            listView1.EndUpdate();
        }

        private void btnDeletePlnTyp_Click(object sender, EventArgs e)
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
                    bool succ = false;
                    try { succ = Bll.Delete(delID); }
                    catch
                    {
                        MessageBox.Show("该项正在使用中！");
                        return;
                    }
                    if (succ)
                    {
                        MessageBox.Show("删除成功！");
                        getAllList();
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
            if (MessageBox.Show("该操作将清空所有故障时机，是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("真的要继续吗？该操作将清空所有故障时机！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool succ = false;
                    try { succ = Bll.DeleteAll(); }
                    catch
                    {
                        MessageBox.Show("有部分项正在使用中！");
                        return;
                    }
                    if (succ)
                    {
                        MessageBox.Show("删除成功！");
                        btnDisplayAll_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("操作失败！");
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            modelList = Bll.GetModelList("tpoint_value like '%" + txtName.Text.Trim() + "%' order by tpoint_id desc");
            loadList();
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            getAllList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TimePointAddFrm AddFrm = new TimePointAddFrm();
            AddFrm.ShowDialog();
            getAllList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要修改的项！");
            }
            else
            {
                Model.time_point editModel = new Model.time_point();
                editModel = modelList[listView1.SelectedIndices[0]];
                TimePointEditFrm EditFrm = new TimePointEditFrm(editModel);
                EditFrm.ShowDialog();
                getAllList();
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                contextMenuStrip1.Items[1].Enabled = false;
                contextMenuStrip1.Items[2].Enabled = false;
            }
            else
            {
                contextMenuStrip1.Items[1].Enabled = true;
                contextMenuStrip1.Items[2].Enabled = true;
            }
        }
    }
}
