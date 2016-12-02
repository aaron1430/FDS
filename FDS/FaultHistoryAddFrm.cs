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
    public partial class FaultHistoryAddFrm : Form
    {
        private List<int> plnTypIdLst;
        private List<int> tmPntIdLst;
        private List<int> flSysIdLst;
        private FaultHistoryForm father;
        public FaultHistoryAddFrm(FaultHistoryForm father)
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
            Model.fault_history addFhModel = new Model.fault_history();
            addFhModel.fh_addtime = DateTime.Now;
            addFhModel.fh_adduser = constants.currentUser.user_id;
            addFhModel.fh_caseid = fhBll.createCaseID(fhBll.getMaxCaseID());
            addFhModel.fh_cause = rchCause.Text;
            addFhModel.fh_description = rchtxtDescription.Text;
            addFhModel.fh_experience = rchTxtExperiance.Text;
            addFhModel.fh_explain = rchTxtExplain.Text;
            addFhModel.fh_keywd = txtKeyWds.Text.Trim();
            addFhModel.fh_phenomenon = rchTxtPhnmn.Text;
            addFhModel.fh_reference = rchTxtReferance.Text;
            addFhModel.fh_suggest = rchTxtSuggest.Text;
            addFhModel.fh_title = txtTtl.Text;
            addFhModel.ptype_id = plnTypIdLst[cmbPlaneType.SelectedIndex];
            addFhModel.system_id = flSysIdLst[cmbFailSystem.SelectedIndex];
            addFhModel.tpoint_id = tmPntIdLst[cmbTimePoint.SelectedIndex];
            fhBll.Add(addFhModel);
            MessageBox.Show("添加成功！");
            BLL.v_fail_history vfhBll = new BLL.v_fail_history();
            father.vfhList = vfhBll.GetModelList("fh_phenomenon='" + addFhModel.fh_phenomenon + "' and fh_caseid='" + addFhModel.fh_caseid + "'");
            father.ListViewLoadData();
            this.Close();
        }



    }
}
