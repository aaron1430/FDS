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
    public partial class FaultHistoryEditFrm : Form
    {
        private List<int> plnTypIdLst;
        private List<int> tmPntIdLst;
        private List<int> flSysIdLst;
        private FaultHistoryForm father;
        private Model.v_fail_history editModel;
        public FaultHistoryEditFrm()
        {
            InitializeComponent();
        }
        public FaultHistoryEditFrm(FaultHistoryForm father, Model.v_fail_history editModel)
        {
            InitializeComponent();
            this.father = father;
            initCntls();
            this.editModel = editModel;
            loadEditInfo(editModel);
        }

        private void loadEditInfo(Model.v_fail_history editModel)
        {
            txtTtl.Text = editModel.fh_title;
            lblCsID.Text = editModel.fh_caseid;
            lblUser.Text = editModel.user_name;
            lblAddTime.Text = editModel.fh_addtime.ToString("yyyy-MM-dd HH:mm");
            cmbPlaneType.SelectedIndex = plnTypIdLst.IndexOf(editModel.ptype_id);
            cmbFailSystem.SelectedIndex = flSysIdLst.IndexOf(editModel.system_id);
            cmbTimePoint.SelectedIndex = tmPntIdLst.IndexOf(editModel.tpoint_id);
            txtKeyWds.Text = editModel.fh_keywd;
            rchTxtPhnmn.Text = editModel.fh_phenomenon;
            rchtxtDescription.Text = editModel.fh_description;
            rchCause.Text = editModel.fh_cause;
            rchTxtSuggest.Text = editModel.fh_suggest;
            rchTxtExplain.Text = editModel.fh_explain;
            rchTxtExperiance.Text = editModel.fh_experience;
            rchTxtReferance.Text = editModel.fh_reference;
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
            BLL.fault_history fhBll = new BLL.fault_history();
            Model.fault_history editFhModel = new Model.fault_history();
            editFhModel.fh_id = editModel.fh_id;
            editFhModel.fh_adduser = editModel.fh_adduser;
            editFhModel.fh_addtime = editModel.fh_addtime;
            editFhModel.fh_caseid = editModel.fh_caseid;
            editFhModel.fh_cause = rchCause.Text;
            editFhModel.fh_description = rchtxtDescription.Text;
            editFhModel.fh_experience = rchTxtExperiance.Text;
            editFhModel.fh_explain = rchTxtExplain.Text;
            editFhModel.fh_keywd = txtKeyWds.Text.Trim();
            editFhModel.fh_phenomenon = rchTxtPhnmn.Text;
            editFhModel.fh_reference = rchTxtReferance.Text;
            editFhModel.fh_suggest = rchTxtSuggest.Text;
            editFhModel.fh_title = txtTtl.Text;
            editFhModel.ptype_id = plnTypIdLst[cmbPlaneType.SelectedIndex];
            editFhModel.system_id = flSysIdLst[cmbFailSystem.SelectedIndex];
            editFhModel.tpoint_id = tmPntIdLst[cmbTimePoint.SelectedIndex];
            fhBll.Update(editFhModel);
            MessageBox.Show("修改成功！");
            BLL.v_fail_history vfhBll = new BLL.v_fail_history();
            father.vfhList = vfhBll.GetModelList("fh_id=" + editFhModel.fh_id);
            father.ListViewLoadData();
            this.Close();
        }



    }
}
