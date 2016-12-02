using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Maticsoft.DBUtility;
using System.IO;

namespace fds
{
    public partial class RestoreDataFrm : Form
    {
        OpenFileDialog SourceFileDialog;
        string fileName = "";
        public RestoreDataFrm()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            SourceFileDialog = new OpenFileDialog();
            SourceFileDialog.Filter = "Excel文件|*.xls|所有文件|*.*";
            if (SourceFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = SourceFileDialog.FileName;
                fileName = SourceFileDialog.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            initDB();
            initAdmin();
            initPlaneType();
            initFailSystem();
            initTimePoint();
            initFaultHistory();
            progressBar1.Value = 100;
            MessageBox.Show("数据库重置成功。");

            this.Close();
        }

        private void initPlaneType()
        {
            progressBar1.Value = 40;
            try
            {
                DataSet ds = LoadDataFromExcel(fileName, "飞机型号");
                BLL.plane_type bll = new BLL.plane_type();
                Model.plane_type model = new Model.plane_type();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["型号"].ToString() == "")
                        return;
                    model.ptype_name = dr["型号"].ToString(); ;
                    bll.Add(model);
                }

            }

            catch
            {
            }
        }

        private void initFailSystem()
        {
            progressBar1.Value = 50;
            DataSet ds = LoadDataFromExcel(fileName, "涉及的系统");
            BLL.fail_system bll = new BLL.fail_system();
            Model.fail_system model = new Model.fail_system();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["涉及的系统"].ToString() == "")
                    return;
                model.system_name = dr["涉及的系统"].ToString();
                bll.Add(model);
            }
        }

        private void initTimePoint()
        {
            progressBar1.Value = 60;
            DataSet ds = LoadDataFromExcel(fileName, "发生时机");
            BLL.time_point bll = new BLL.time_point();
            Model.time_point model = new Model.time_point();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["发生时机"].ToString() == "")
                    return;
                model.tpoint_value = dr["发生时机"].ToString();
                bll.Add(model);
            }
        }

        private void initFaultHistory()
        {
            progressBar1.Value = 90;
            DataSet ds = LoadDataFromExcel(fileName, "故障案例库信息");
            BLL.fault_history bll = new BLL.fault_history();
            Model.fault_history model = new Model.fault_history();

            BLL.time_point tpBll = new BLL.time_point();
            BLL.fail_system fsBll = new BLL.fail_system();
            BLL.plane_type ptBll = new BLL.plane_type();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["案例编号"].ToString() == "")
                    return;
                model.fh_addtime = DateTime.Now;
                model.fh_adduser = constants.currentUser.user_id;
                model.fh_caseid = dr["案例编号"].ToString();
                model.fh_cause = dr["故障原因"].ToString();
                model.fh_description = dr["相关描述"].ToString();
                model.fh_experience = dr["经验教训"].ToString();
                model.fh_explain = dr["解释"].ToString();
                model.fh_keywd = dr["关键词"].ToString();
                model.fh_phenomenon = dr["故障现象"].ToString();
                model.fh_reference = dr["参考资料"].ToString();
                model.fh_suggest = dr["维修建议"].ToString();
                model.fh_title = dr["案例标题"].ToString();
                model.ptype_id = ptBll.GetModel(dr["飞机型号"].ToString()).ptype_id;
                model.system_id = fsBll.GetModel(dr["故障系统"].ToString()).system_id;
                model.tpoint_id = tpBll.GetModel(dr["发生时机"].ToString()).tpoint_id;
                bll.Add(model);
            }
        }

        public void initDB()
        {
            progressBar1.Value = 20;
            string filepath = System.Environment.CurrentDirectory + "\\" + "fds.sql";
            FileInfo Inifile = new FileInfo(filepath);
            FileStream streamInfo = Inifile.Open(FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(streamInfo, Encoding.UTF8);
            string text = string.Empty;
            text = reader.ReadToEnd();
            string[] sqlArr = text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string sql in sqlArr)
            {
                if (sql != "\r\n")
                    DbHelperMySQL.ExecuteSql(sql);
            }
        }
        private void initAdmin()
        {
            progressBar1.Value = 30;
            BLL.user_info userBll = new BLL.user_info();
            Model.user_info admin = new Model.user_info();
            admin.user_id = 1;
            admin.user_name = "admin";
            admin.user_remark = "系统管理员";
            admin.user_pwd = Maticsoft.Common.PasswordEncrypt.EncryptDES("admin");
            admin.user_isadmin = true;
            userBll.Add(admin);
        }
        public static DataSet LoadDataFromExcel(string filePath, string tableName)
        {
            try
            {
                string strConn;
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=False;IMEX=1'";
                OleDbConnection OleConn = new OleDbConnection(strConn);
                OleConn.Open();
                String sql = "SELECT * FROM  [" + tableName + "$]";//可是更改Sheet名称，比如sheet2，等等   

                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                DataSet OleDsExcle = new DataSet();
                OleDaExcel.Fill(OleDsExcle);
                OleConn.Close();
                return OleDsExcle;
            }
            catch (Exception err)
            {
                MessageBox.Show("数据绑定Excel失败!失败原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        /// <summary>    
        /// 获取Excel工作薄中Sheet页(工作表)名集合   
        /// </summary>    
        /// <param name="excelFile">Excel文件名及路径,EG:C:\Users\JK\Desktop\导入测试.xls</param>    
        /// <returns>Sheet页名称集合</returns>    
        private String[] GetExcelSheetNames(string fileName)
        {
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;
            try
            {
                string connString = string.Empty;
                string FileType = fileName.Substring(fileName.LastIndexOf("."));
                if (FileType == ".xls")
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                       "Data Source=" + fileName + ";Extended Properties=Excel 8.0;";
                else//.xlsx   
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
                // 创建连接对象    
                objConn = new OleDbConnection(connString);
                // 打开数据库连接    
                objConn.Open();
                // 得到包含数据架构的数据表    
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return null;
                }
                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;
                // 添加工作表名称到字符串数组    
                foreach (DataRow row in dt.Rows)
                {
                    string strSheetTableName = row["TABLE_NAME"].ToString();
                    //过滤无效SheetName   
                    if (strSheetTableName.Contains("$") && strSheetTableName.Replace("'", "").EndsWith("$"))
                    {
                        excelSheets[i] = strSheetTableName.Substring(0, strSheetTableName.Length - 1);
                    }
                    i++;
                }
                return excelSheets;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            finally
            {
                // 清理    
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }
    }
}
