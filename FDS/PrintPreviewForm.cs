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
    public partial class PrintPreviewForm : PrintPreviewDialog
    {
        public PrintPreviewForm()
        {
            InitializeComponent();
        }

        //作为正式打印标志
        private bool is_Print;
        public bool isPrint
        {
            get { return is_Print; }
            set { is_Print = value; }
        }

        public void Del()
        {
            int bnt = 0;
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(ToolStrip))
                {
                    ToolStrip ts = c as ToolStrip;
                    ts.Items.RemoveAt(bnt);
                }
            }
        }
        public void Add()
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(ToolStrip))
                {
                    ToolStrip ts = c as ToolStrip;
                    ToolStripButton my_setup = new ToolStripButton("打印");
                    my_setup.Size = new Size(23, 22);
                    my_setup.ImageTransparentColor = System.Drawing.Color.Magenta;
                    ts.Items.Insert(2, my_setup);
                    ts.Items[2].Click += new System.EventHandler(my_setup_Click);//添加对应按钮的单击是事件 
                }
            }
        }
        private void my_setup_Click(object sender, EventArgs e)
        {
            is_Print = true;//说明是正式打印，用于通知printDocument1_PrintPage哪些打印，哪些只是预览

            using (PrintDialog diag = new PrintDialog())
            {
                diag.Document = base.Document;//base 关键字用于从派生类中访问基类的成员：调用基类上已被其他方法重写的方法。

                if (diag.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.Document.Print();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("打印未完成：" + ex.Message);
                    }
                }
            }

        }

    }
}
