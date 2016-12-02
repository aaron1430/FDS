namespace fds
{
    partial class FailureTreeEditFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picBxTree = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.picBxGrid = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rchTxtExperience = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKeyWds = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblAddTime = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFailSystem = new System.Windows.Forms.ComboBox();
            this.cmbTimePoint = new System.Windows.Forms.ComboBox();
            this.cmbPlaneType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCsID = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(396, 549);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.picBxTree);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.picBxGrid);
            this.groupBox4.Location = new System.Drawing.Point(356, 145);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(336, 398);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "普通模式";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "事件序列图：";
            // 
            // picBxTree
            // 
            this.picBxTree.BackgroundImage = global::fds.Properties.Resources.uploadImg;
            this.picBxTree.Location = new System.Drawing.Point(5, 32);
            this.picBxTree.Name = "picBxTree";
            this.picBxTree.Size = new System.Drawing.Size(325, 171);
            this.picBxTree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBxTree.TabIndex = 0;
            this.picBxTree.TabStop = false;
            this.picBxTree.Click += new System.EventHandler(this.picBxTree_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "事件代号：";
            // 
            // picBxGrid
            // 
            this.picBxGrid.BackgroundImage = global::fds.Properties.Resources.uploadImg;
            this.picBxGrid.ErrorImage = null;
            this.picBxGrid.Location = new System.Drawing.Point(5, 221);
            this.picBxGrid.Name = "picBxGrid";
            this.picBxGrid.Size = new System.Drawing.Size(325, 171);
            this.picBxGrid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBxGrid.TabIndex = 1;
            this.picBxGrid.TabStop = false;
            this.picBxGrid.Click += new System.EventHandler(this.picBxGrid_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(233, 549);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.rchTxtExperience);
            this.groupBox3.Location = new System.Drawing.Point(12, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 398);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "经验模式";
            // 
            // rchTxtExperience
            // 
            this.rchTxtExperience.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rchTxtExperience.Location = new System.Drawing.Point(7, 32);
            this.rchTxtExperience.Name = "rchTxtExperience";
            this.rchTxtExperience.Size = new System.Drawing.Size(323, 360);
            this.rchTxtExperience.TabIndex = 0;
            this.rchTxtExperience.Text = "添加时删除此说明：请用换行符分隔多个经验内容。";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblCsID);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtKeyWds);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblAddTime);
            this.groupBox1.Controls.Add(this.lblUser);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbFailSystem);
            this.groupBox1.Controls.Add(this.cmbTimePoint);
            this.groupBox1.Controls.Add(this.cmbPlaneType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 126);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // txtKeyWds
            // 
            this.txtKeyWds.Location = new System.Drawing.Point(103, 99);
            this.txtKeyWds.Name = "txtKeyWds";
            this.txtKeyWds.Size = new System.Drawing.Size(547, 21);
            this.txtKeyWds.TabIndex = 48;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 102);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 47;
            this.label14.Text = "关键字：";
            // 
            // lblAddTime
            // 
            this.lblAddTime.AutoSize = true;
            this.lblAddTime.Location = new System.Drawing.Point(521, 28);
            this.lblAddTime.Name = "lblAddTime";
            this.lblAddTime.Size = new System.Drawing.Size(47, 12);
            this.lblAddTime.TabIndex = 46;
            this.lblAddTime.Text = "label17";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(311, 28);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(47, 12);
            this.lblUser.TabIndex = 45;
            this.lblUser.Text = "label16";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(450, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 44;
            this.label15.Text = "添加时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 43;
            this.label6.Text = "添加用户：";
            // 
            // cmbFailSystem
            // 
            this.cmbFailSystem.FormattingEnabled = true;
            this.cmbFailSystem.Location = new System.Drawing.Point(315, 62);
            this.cmbFailSystem.Name = "cmbFailSystem";
            this.cmbFailSystem.Size = new System.Drawing.Size(121, 20);
            this.cmbFailSystem.TabIndex = 42;
            // 
            // cmbTimePoint
            // 
            this.cmbTimePoint.FormattingEnabled = true;
            this.cmbTimePoint.Location = new System.Drawing.Point(527, 62);
            this.cmbTimePoint.Name = "cmbTimePoint";
            this.cmbTimePoint.Size = new System.Drawing.Size(121, 20);
            this.cmbTimePoint.TabIndex = 41;
            // 
            // cmbPlaneType
            // 
            this.cmbPlaneType.FormattingEnabled = true;
            this.cmbPlaneType.Location = new System.Drawing.Point(103, 62);
            this.cmbPlaneType.Name = "cmbPlaneType";
            this.cmbPlaneType.Size = new System.Drawing.Size(121, 20);
            this.cmbPlaneType.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 39;
            this.label4.Text = "故障系统：*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 38;
            this.label3.Text = "故障时机：*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "飞机型号：*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 49;
            this.label7.Text = "案例编号：";
            // 
            // lblCsID
            // 
            this.lblCsID.AutoSize = true;
            this.lblCsID.Location = new System.Drawing.Point(107, 28);
            this.lblCsID.Name = "lblCsID";
            this.lblCsID.Size = new System.Drawing.Size(41, 12);
            this.lblCsID.TabIndex = 50;
            this.lblCsID.Text = "label8";
            // 
            // FailureTreeEditFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(704, 584);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FailureTreeEditFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改事件序列图";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBxTree;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picBxGrid;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rchTxtExperience;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKeyWds;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblAddTime;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbFailSystem;
        private System.Windows.Forms.ComboBox cmbTimePoint;
        private System.Windows.Forms.ComboBox cmbPlaneType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCsID;
        private System.Windows.Forms.Label label7;
    }
}