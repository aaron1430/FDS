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
    public partial class WelcomeFrm : Form
    {
        public WelcomeFrm()
        {
            InitializeComponent();
        }
        public WelcomeFrm(Form main)
        {
            InitializeComponent();
            this.MdiParent = main;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
