using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace fds
{
    public partial class FailureTreeDetailFrm : Form
    {
        private Model.v_failure_tree detail;
        public FailureTreeDetailFrm(Model.v_failure_tree detail)
        {
            InitializeComponent();
            KeyPreview = true;
            this.detail = detail;
            picBxTree.SizeMode = PictureBoxSizeMode.StretchImage;
            picBxGrid.SizeMode = PictureBoxSizeMode.StretchImage;
            displayDetail(detail);
        }
        private void displayDetail(Model.v_failure_tree detail)
        {
            lblUser.Text = detail.user_name;
            lblAddTime.Text = detail.ft_addtime.ToString("yyyy-MM-dd HH:mm");
            lblCsID.Text = detail.ft_caseid;
            lblPlnTyp.Text = detail.ptype_name;
            lblTPnt.Text = detail.tpoint_value;
            lblFlSys.Text = detail.system_name;
            lblKeyWds.Text = detail.ft_keywd;
            picBxTree.Image = getPicFromByteArr(detail.ft_pic);
            picBxGrid.Image = getPicFromByteArr(detail.ft_grid);

            if (detail.experience != null && detail.experience != "")
            {
                string[] expArr = detail.experience.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string str in expArr)
                {
                    rchTxtExperience.Text += "●  " + str + "\r\n";
                }
            }
        }

        private Image getPicFromByteArr(byte[] picByteArr)
        {
            MemoryStream ms = new MemoryStream(); //新建内存流
            ms.Write(picByteArr, 0, picByteArr.Length); //附值
            Image img = Image.FromStream(ms); //读取流中内容
            ms.Dispose();
            return img;
        }

        private void ViewImageFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {

            if (splitContainer1.Visible)
            {
                splitContainer1.Visible = false;
                btnSwitch.Text = "普通模式";
                this.Text = "经验模式";
            }
            else
            {
                splitContainer1.Visible = true;
                btnSwitch.Text = "经验模式";
                this.Text = "普通模式";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            PrintPreviewForm previewFrm = new PrintPreviewForm();
            previewFrm.Del();
            previewFrm.Add();

            previewFrm.Document = printDocument;
            previewFrm.PrintPreviewControl.StartPage = 0;//起使页面
            previewFrm.PrintPreviewControl.Zoom = 0.5;//显示比例

            printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);

            previewFrm.ShowDialog();
        }
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //双击printDocument控件，在这里面写你想要打印信息 
            Font font = new Font("新宋体", 14);//设置画笔 
            Font fontx = new Font("新宋体", 12);//设置另一种字体
            Brush bru = Brushes.Black;
            Pen pen = new Pen(bru);
            pen.Width = 5;
            //设置打印机尺寸为毫米
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            if (splitContainer1.Visible)
            {
                e.Graphics.DrawImage(new Bitmap(fds.Properties.Resources.故障树打印, fds.Properties.Resources.故障树打印.Width / 2, fds.Properties.Resources.故障树打印.Height / 2), 0, 0);
                e.Graphics.DrawImage(GetThumbnail(new Bitmap(picBxTree.Image), 400, 613), 25, 54);
                e.Graphics.DrawImage(GetThumbnail(new Bitmap(picBxGrid.Image), 400, 613), 25, 175);
            }
            else
            {
                e.Graphics.DrawImage(new Bitmap(fds.Properties.Resources.经验模式打印, fds.Properties.Resources.经验模式打印.Width / 2, fds.Properties.Resources.经验模式打印.Height / 2), 0, 0);
                e.Graphics.DrawString(rchTxtExperience.Text, font, bru, 25, 57);
            }

            e.Graphics.DrawString(lblPlnTyp.Text, font, bru, 45, 43);
            e.Graphics.DrawString(lblTPnt.Text, font, bru, 110, 43);
            e.Graphics.DrawString(lblFlSys.Text, font, bru, 175, 43);
            e.Graphics.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm"), font, bru, 45, 31);
            e.Graphics.DrawString(lblCsID.Text, font, bru, 45, 37);
            e.Graphics.DrawString(lblKeyWds.Text, font, bru, 110, 37);
        }

        private Bitmap GetThumbnail(Bitmap b, int destHeight, int destWidth)
        {
            System.Drawing.Image imgSource = b;
            System.Drawing.Imaging.ImageFormat thisFormat = imgSource.RawFormat;
            int sW = 0, sH = 0;
            // 按比例缩放           
            int sWidth = imgSource.Width;
            int sHeight = imgSource.Height;
            if (sHeight > destHeight || sWidth > destWidth)
            {
                if ((sWidth * destHeight) > (sHeight * destWidth))
                {
                    sW = destWidth;
                    sH = (destWidth * sHeight) / sWidth;
                }
                else
                {
                    sH = destHeight;
                    sW = (sWidth * destHeight) / sHeight;
                }
            }
            else
            {
                sW = sWidth;
                sH = sHeight;
            }
            Bitmap outBmp = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(outBmp);
            g.Clear(Color.Transparent);
            // 设置画布的描绘质量         
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgSource, new Rectangle((destWidth - sW) / 2, (destHeight - sH) / 2, sW, sH), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
            g.Dispose();
            // 以下代码为保存图片时，设置压缩质量     
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 100;
            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;
            imgSource.Dispose();
            return outBmp;
        }
    }
}
