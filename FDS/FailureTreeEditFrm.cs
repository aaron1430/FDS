using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace fds
{
    public partial class FailureTreeEditFrm : Form
    {
        private List<int> plnTypIdLst;
        private List<int> tmPntIdLst;
        private List<int> flSysIdLst;
        private FailureTreeFrm father;
        private Model.v_failure_tree editModel;

        private bool picTreeChanged = false;
        private bool picGridChanged = false;
        public FailureTreeEditFrm(Model.v_failure_tree editModel, FailureTreeFrm father)
        {
            InitializeComponent();
            this.father = father;
            this.editModel = editModel;
            initCntls();
            loadEditInfo(editModel);
        }
        private void loadEditInfo(Model.v_failure_tree editModel)
        {
            lblUser.Text = editModel.user_name;
            lblAddTime.Text = editModel.ft_addtime.ToString("yyyy-MM-dd HH:mm");
            lblCsID.Text = editModel.ft_caseid;
            cmbPlaneType.SelectedIndex = plnTypIdLst.IndexOf(editModel.ptype_id);
            cmbFailSystem.SelectedIndex = flSysIdLst.IndexOf(editModel.system_id);
            cmbTimePoint.SelectedIndex = tmPntIdLst.IndexOf(editModel.tpoint_id);
            txtKeyWds.Text = editModel.ft_keywd;
            picBxTree.Image = getPicFromByteArr(editModel.ft_pic);
            picBxGrid.Image = getPicFromByteArr(editModel.ft_grid);
            rchTxtExperience.Text = editModel.experience;
        }

        private Image getPicFromByteArr(byte[] picByteArr)
        {
            MemoryStream ms = new MemoryStream(); //新建内存流
            ms.Write(picByteArr, 0, picByteArr.Length); //附值
            Image img = Image.FromStream(ms); //读取流中内容
            ms.Dispose();
            return img;
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
            BLL.failure_tree ftBll = new BLL.failure_tree();
            Model.failure_tree editFtModel = new Model.failure_tree();
            editFtModel.ft_id = editModel.ft_id;
            editFtModel.ft_adduser = editModel.ft_adduser;
            editFtModel.ft_caseid = ftBll.createCaseID(ftBll.getMaxCaseID());
            editFtModel.ft_addtime = editModel.ft_addtime;
            editFtModel.ft_keywd = txtKeyWds.Text.Trim();
            editFtModel.ptype_id = plnTypIdLst[cmbPlaneType.SelectedIndex];
            editFtModel.system_id = flSysIdLst[cmbFailSystem.SelectedIndex];
            editFtModel.tpoint_id = tmPntIdLst[cmbTimePoint.SelectedIndex];
            editFtModel.experience = rchTxtExperience.Text;
            if (picTreeChanged)
            { editFtModel.ft_pic = getImgToByte(picBxTree.Image); }
            else
            { editFtModel.ft_pic = editModel.ft_pic; }
            if (picGridChanged)
            { editFtModel.ft_grid = getImgToByte(picBxGrid.Image); }
            else
            { editFtModel.ft_grid = editModel.ft_grid; }

            ftBll.Update(editFtModel);
            MessageBox.Show("修改成功！");
            BLL.v_failure_tree vftBll = new BLL.v_failure_tree();
            father.vftList = vftBll.GetModelList("ft_id=" + editFtModel.ft_id);
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

        private void picBxTree_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image   Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All   files   (*.*)|*.* ";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picBxTree.Image = Image.FromFile(openFileDialog1.FileName);
                picTreeChanged = true;
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
                picGridChanged = true;
            }
        }

    }
}
