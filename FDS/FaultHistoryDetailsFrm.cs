using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Words;

namespace fds
{
    public partial class FaultHistoryDetailsFrm : Form
    {
        public FaultHistoryDetailsFrm()
        {
            InitializeComponent();
        }
        public FaultHistoryDetailsFrm(Model.v_fail_history detail)
        {
            InitializeComponent();
            displayDetail(detail);
        }

        private void displayDetail(Model.v_fail_history detail)
        {
            lblUser.Text = detail.user_name;
            lblAddTime.Text = detail.fh_addtime.ToString("yyyy-MM-dd HH:mm");
            lblPlnTyp.Text = detail.ptype_name;
            lblTPnt.Text = detail.tpoint_value;
            lblFlSys.Text = detail.system_name;
            lblFhCsId.Text = detail.fh_caseid;
            lblFhTtl.Text = detail.fh_title;
            lblKeyWds.Text = detail.fh_keywd;
            rchTxtPhnmn.Text = detail.fh_phenomenon;
            rchtxtDescription.Text = detail.fh_description;
            rchCause.Text = detail.fh_cause;
            rchTxtSuggest.Text = detail.fh_suggest;
            rchTxtExplain.Text = detail.fh_explain;
            rchTxtExperiance.Text = detail.fh_experience;
            rchTxtReferance.Text = detail.fh_reference;
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            string filepath = System.Environment.CurrentDirectory + "\\" + "案例推理诊断模板.doc";// 
            Document doc = new Document(filepath);
            Bookmark mark = null;

            if (doc.Range.Bookmarks["fh_phenomenon"] != null)
            {
                mark = doc.Range.Bookmarks["fh_phenomenon"];
                mark.Text = this.rchTxtPhnmn.Text;
            }
            if (doc.Range.Bookmarks["tpoint_name"] != null)
            {
                mark = doc.Range.Bookmarks["tpoint_name"];
                mark.Text = this.lblTPnt.Text;
            }
            if (doc.Range.Bookmarks["system_name"] != null)
            {
                mark = doc.Range.Bookmarks["system_name"];
                mark.Text = this.lblFlSys.Text;
            }
            if (doc.Range.Bookmarks["fh_caseid"] != null)
            {
                mark = doc.Range.Bookmarks["fh_caseid"];
                mark.Text = this.lblFhCsId.Text;
            }
            if (doc.Range.Bookmarks["fh_title"] != null)
            {
                mark = doc.Range.Bookmarks["fh_title"];
                mark.Text = this.lblFhTtl.Text;
            }
            if (doc.Range.Bookmarks["fh_description"] != null)
            {
                mark = doc.Range.Bookmarks["fh_description"];
                mark.Text = this.rchtxtDescription.Text;
            }
            if (doc.Range.Bookmarks["fh_cause"] != null)
            {
                mark = doc.Range.Bookmarks["fh_cause"];
                mark.Text = this.rchCause.Text;
            }
            if (doc.Range.Bookmarks["fh_suggest"] != null)
            {
                mark = doc.Range.Bookmarks["fh_suggest"];
                mark.Text = this.rchTxtSuggest.Text;
            }
            if (doc.Range.Bookmarks["fh_explain"] != null)
            {
                mark = doc.Range.Bookmarks["fh_explain"];
                mark.Text = this.rchTxtExplain.Text;
            }
            if (doc.Range.Bookmarks["fh_reference"] != null)
            {
                mark = doc.Range.Bookmarks["fh_reference"];
                mark.Text = this.rchTxtReferance.Text;
            }
            if (doc.Range.Bookmarks["fh_experience"] != null)
            {
                mark = doc.Range.Bookmarks["fh_experience"];
                mark.Text = this.rchTxtExperiance.Text;
            }
            if (doc.Range.Bookmarks["fh_keywd"] != null)
            {
                mark = doc.Range.Bookmarks["fh_keywd"];
                mark.Text = this.lblKeyWds.Text;
            }
            string temFilepath = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "office文档（*.doc）|*.doc";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                temFilepath = sfd.FileName.ToString();
            }
            else
            {
                return;
            }

            doc.Save(temFilepath);
            MessageBox.Show("已保存为" + temFilepath);
        }
    }
}
