/**  版本信息模板在安装目录下，可自行修改。
* fault_history.cs
*
* 功 能： N/A
* 类 名： fault_history
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/24 星期四 14:10:58   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace fds.DAL
{
    /// <summary>
    /// 数据访问类:fault_history
    /// </summary>
    public partial class fault_history
    {
        public fault_history()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("fh_id", "fault_history");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int fh_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from fault_history");
            strSql.Append(" where fh_id=@fh_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@fh_id", MySqlDbType.Int32)
			};
            parameters[0].Value = fh_id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(fds.Model.fault_history model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into fault_history(");
            strSql.Append("fh_adduser,ptype_id,tpoint_id,system_id,fh_phenomenon,fh_caseid,fh_title,fh_description,fh_cause,fh_suggest,fh_explain,fh_reference,fh_experience,fh_keywd,fh_addtime)");
            strSql.Append(" values (");
            strSql.Append("@fh_adduser,@ptype_id,@tpoint_id,@system_id,@fh_phenomenon,@fh_caseid,@fh_title,@fh_description,@fh_cause,@fh_suggest,@fh_explain,@fh_reference,@fh_experience,@fh_keywd,@fh_addtime)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@fh_adduser", MySqlDbType.Int32,11),
					new MySqlParameter("@ptype_id", MySqlDbType.Int32,11),
					new MySqlParameter("@tpoint_id", MySqlDbType.Int32,11),
					new MySqlParameter("@system_id", MySqlDbType.Int32,11),
					new MySqlParameter("@fh_phenomenon", MySqlDbType.VarChar,2048),
					new MySqlParameter("@fh_caseid", MySqlDbType.VarChar,128),
					new MySqlParameter("@fh_title", MySqlDbType.VarChar,512),
					new MySqlParameter("@fh_description", MySqlDbType.VarChar,2048),
					new MySqlParameter("@fh_cause", MySqlDbType.VarChar,2048),
					new MySqlParameter("@fh_suggest", MySqlDbType.VarChar,2048),
					new MySqlParameter("@fh_explain", MySqlDbType.VarChar,2048),
					new MySqlParameter("@fh_reference", MySqlDbType.VarChar,2048),
					new MySqlParameter("@fh_experience", MySqlDbType.VarChar,2048),
					new MySqlParameter("@fh_keywd", MySqlDbType.VarChar,512),
					new MySqlParameter("@fh_addtime", MySqlDbType.DateTime)};
            parameters[0].Value = model.fh_adduser;
            parameters[1].Value = model.ptype_id;
            parameters[2].Value = model.tpoint_id;
            parameters[3].Value = model.system_id;
            parameters[4].Value = model.fh_phenomenon;
            parameters[5].Value = model.fh_caseid;
            parameters[6].Value = model.fh_title;
            parameters[7].Value = model.fh_description;
            parameters[8].Value = model.fh_cause;
            parameters[9].Value = model.fh_suggest;
            parameters[10].Value = model.fh_explain;
            parameters[11].Value = model.fh_reference;
            parameters[12].Value = model.fh_experience;
            parameters[13].Value = model.fh_keywd;
            parameters[14].Value = model.fh_addtime;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(fds.Model.fault_history model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update fault_history set ");
            strSql.Append("fh_adduser=@fh_adduser,");
            strSql.Append("ptype_id=@ptype_id,");
            strSql.Append("tpoint_id=@tpoint_id,");
            strSql.Append("system_id=@system_id,");
            strSql.Append("fh_phenomenon=@fh_phenomenon,");
            strSql.Append("fh_caseid=@fh_caseid,");
            strSql.Append("fh_title=@fh_title,");
            strSql.Append("fh_description=@fh_description,");
            strSql.Append("fh_cause=@fh_cause,");
            strSql.Append("fh_suggest=@fh_suggest,");
            strSql.Append("fh_explain=@fh_explain,");
            strSql.Append("fh_reference=@fh_reference,");
            strSql.Append("fh_experience=@fh_experience,");
            strSql.Append("fh_keywd=@fh_keywd,");
            strSql.Append("fh_addtime=@fh_addtime");
            strSql.Append(" where fh_id=@fh_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@fh_adduser", MySqlDbType.Int32,11),
					new MySqlParameter("@ptype_id", MySqlDbType.Int32,11),
					new MySqlParameter("@tpoint_id", MySqlDbType.Int32,11),
					new MySqlParameter("@system_id", MySqlDbType.Int32,11),
					new MySqlParameter("@fh_phenomenon", MySqlDbType.VarChar,2048),
					new MySqlParameter("@fh_caseid", MySqlDbType.VarChar,128),
					new MySqlParameter("@fh_title", MySqlDbType.VarChar,512),
					new MySqlParameter("@fh_description", MySqlDbType.VarChar,2048),
					new MySqlParameter("@fh_cause", MySqlDbType.VarChar,2048),
					new MySqlParameter("@fh_suggest", MySqlDbType.VarChar,2048),
					new MySqlParameter("@fh_explain", MySqlDbType.VarChar,2048),
					new MySqlParameter("@fh_reference", MySqlDbType.VarChar,2048),
					new MySqlParameter("@fh_experience", MySqlDbType.VarChar,2048),
					new MySqlParameter("@fh_keywd", MySqlDbType.VarChar,512),
					new MySqlParameter("@fh_addtime", MySqlDbType.DateTime),
					new MySqlParameter("@fh_id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.fh_adduser;
            parameters[1].Value = model.ptype_id;
            parameters[2].Value = model.tpoint_id;
            parameters[3].Value = model.system_id;
            parameters[4].Value = model.fh_phenomenon;
            parameters[5].Value = model.fh_caseid;
            parameters[6].Value = model.fh_title;
            parameters[7].Value = model.fh_description;
            parameters[8].Value = model.fh_cause;
            parameters[9].Value = model.fh_suggest;
            parameters[10].Value = model.fh_explain;
            parameters[11].Value = model.fh_reference;
            parameters[12].Value = model.fh_experience;
            parameters[13].Value = model.fh_keywd;
            parameters[14].Value = model.fh_addtime;
            parameters[15].Value = model.fh_id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int fh_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from fault_history ");
            strSql.Append(" where fh_id=@fh_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@fh_id", MySqlDbType.Int32)
			};
            parameters[0].Value = fh_id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string fh_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from fault_history ");
            strSql.Append(" where fh_id in (" + fh_idlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public fds.Model.fault_history GetModel(int fh_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select fh_id,fh_adduser,ptype_id,tpoint_id,system_id,fh_phenomenon,fh_caseid,fh_title,fh_description,fh_cause,fh_suggest,fh_explain,fh_reference,fh_experience,fh_keywd,fh_addtime from fault_history ");
            strSql.Append(" where fh_id=@fh_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@fh_id", MySqlDbType.Int32)
			};
            parameters[0].Value = fh_id;

            fds.Model.fault_history model = new fds.Model.fault_history();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public fds.Model.fault_history DataRowToModel(DataRow row)
        {
            fds.Model.fault_history model = new fds.Model.fault_history();
            if (row != null)
            {
                if (row["fh_id"] != null && row["fh_id"].ToString() != "")
                {
                    model.fh_id = int.Parse(row["fh_id"].ToString());
                }
                if (row["fh_adduser"] != null && row["fh_adduser"].ToString() != "")
                {
                    model.fh_adduser = int.Parse(row["fh_adduser"].ToString());
                }
                if (row["ptype_id"] != null && row["ptype_id"].ToString() != "")
                {
                    model.ptype_id = int.Parse(row["ptype_id"].ToString());
                }
                if (row["tpoint_id"] != null && row["tpoint_id"].ToString() != "")
                {
                    model.tpoint_id = int.Parse(row["tpoint_id"].ToString());
                }
                if (row["system_id"] != null && row["system_id"].ToString() != "")
                {
                    model.system_id = int.Parse(row["system_id"].ToString());
                }
                if (row["fh_phenomenon"] != null)
                {
                    model.fh_phenomenon = row["fh_phenomenon"].ToString();
                }
                if (row["fh_caseid"] != null)
                {
                    model.fh_caseid = row["fh_caseid"].ToString();
                }
                if (row["fh_title"] != null)
                {
                    model.fh_title = row["fh_title"].ToString();
                }
                if (row["fh_description"] != null)
                {
                    model.fh_description = row["fh_description"].ToString();
                }
                if (row["fh_cause"] != null)
                {
                    model.fh_cause = row["fh_cause"].ToString();
                }
                if (row["fh_suggest"] != null)
                {
                    model.fh_suggest = row["fh_suggest"].ToString();
                }
                if (row["fh_explain"] != null)
                {
                    model.fh_explain = row["fh_explain"].ToString();
                }
                if (row["fh_reference"] != null)
                {
                    model.fh_reference = row["fh_reference"].ToString();
                }
                if (row["fh_experience"] != null)
                {
                    model.fh_experience = row["fh_experience"].ToString();
                }
                if (row["fh_keywd"] != null)
                {
                    model.fh_keywd = row["fh_keywd"].ToString();
                }
                if (row["fh_addtime"] != null && row["fh_addtime"].ToString() != "")
                {
                    model.fh_addtime = DateTime.Parse(row["fh_addtime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select fh_id,fh_adduser,ptype_id,tpoint_id,system_id,fh_phenomenon,fh_caseid,fh_title,fh_description,fh_cause,fh_suggest,fh_explain,fh_reference,fh_experience,fh_keywd,fh_addtime ");
            strSql.Append(" FROM fault_history ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM fault_history ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.fh_id desc");
            }
            strSql.Append(")AS Row, T.*  from fault_history T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@PageSize", MySqlDbType.Int32),
                    new MySqlParameter("@PageIndex", MySqlDbType.Int32),
                    new MySqlParameter("@IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("@OrderType", MySqlDbType.Bit),
                    new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "fault_history";
            parameters[1].Value = "fh_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 删除所有数据
        /// </summary>
        public bool DeleteAll()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from fault_history ");
            strSql.Append(" where 1=1");

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getMaxCaseID()
        {
            string strsql = "select max(fh_caseid) from fault_history";
            object obj = DbHelperMySQL.GetSingle(strsql);
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }
        #endregion  ExtensionMethod


    }
}

