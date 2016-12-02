using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace fds
{
    public partial class FailureTreeAddFrm : Form
    {
        private List<int> plnTypIdLst;
        private List<int> tmPntIdLst;
        private List<int> flSysIdLst;

        private FailureTreeFrm father;
        public FailureTreeAddFrm(FailureTreeFrm father)
        {
            InitializeComponent();
            this.father = father;
            initCntls();
        }
        private void initCntls()
        {
            initCmbPlaneType();
            initCmbTimePoint();
            initCmbFailSystem();
            initDefaultInfo();
        }
        private void initDefaultInfo()
        {
            lblUser.Text = constants.currentUser.user_name;
            lblAddTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
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

        private void picBxTree_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image   Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All   files   (*.*)|*.* ";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picBxTree.Image = Image.FromFile(openFileDialog1.FileName);
            }

        }

        private void picBxGrid_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image   Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All   files   (*.*)|*.* ";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picBxGrid.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbPlaneType.SelectedIndex == -1)
            {
                MessageBox.Show("请选择飞机型号！");
                return;
            }
            if (cmbFailSystem.SelectedIndex == -1)
            {
                MessageBox.Show("请选择故障系统！");
                return;
            }
            if (cmbTimePoint.SelectedIndex == -1)
            {
                MessageBox.Show("请选择故障时机！");
                return;
            }
            if (picBxTree.Image == null)
            {
                MessageBox.Show("事件序列图不能为空！");
                return;
            }
            if (picBxGrid.Image == null)
            {
                MessageBox.Show("事件代号不能为空！");
                return;
            }
            DateTime now = DateTime.Now;
            BLL.failure_tree ftBll = new BLL.failure_tree();
            Model.failure_tree addFhModel = new Model.failure_tree();
            addFhModel.ft_addtime = now;
            addFhModel.ft_adduser = constants.currentUser.user_id;
            addFhModel.ft_caseid = ftBll.createCaseID(ftBll.getMaxCaseID());
            addFhModel.ft_keywd = txtKeyWds.Text.Trim();
            addFhModel.ft_pic = getImgToByte(picBxTree.Image);
            addFhModel.ft_grid = getImgToByte(picBxGrid.Image);
            addFhModel.ptype_id = plnTypIdLst[cmbPlaneType.SelectedIndex];
            addFhModel.system_id = flSysIdLst[cmbFailSystem.SelectedIndex];
            addFhModel.tpoint_id = tmPntIdLst[cmbTimePoint.SelectedIndex];

            if (rchTxtExperience.Text == "添加时删除此说明：请用换行符分隔多个经验内容。")
            {
                addFhModel.experience = "";
            }
            else
            {
                addFhModel.experience = rchTxtExperience.Text.Trim();
            }


            ftBll.Add(addFhModel);
            MessageBox.Show("添加成功！");
            BLL.v_failure_tree vftBll = new BLL.v_failure_tree();
            father.vftList = vftBll.GetModelList("ft_addtime='" + now.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            father.ListViewLoadData();
            this.Close();
        }

        private byte[] getImgToByte(Image image)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                else if (format.Equals(ImageFormat.Png))
                {
                    image.Save(ms, ImageFormat.Png);
                }
                else if (format.Equals(ImageFormat.Bmp))
                {
                    image.Save(ms, ImageFormat.Bmp);
                }
                else if (format.Equals(ImageFormat.Gif))
                {
                    image.Save(ms, ImageFormat.Gif);
                }
                else if (format.Equals(ImageFormat.Icon))
                {
                    image.Save(ms, ImageFormat.Icon);
                }
                byte[] buffer = new byte[ms.Length];
                //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

    }
}
