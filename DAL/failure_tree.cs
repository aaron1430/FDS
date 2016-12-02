/**  版本信息模板在安装目录下，可自行修改。
* failure_tree.cs
*
* 功 能： N/A
* 类 名： failure_tree
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/25 星期五 11:01:40   N/A    初版
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
	/// 数据访问类:failure_tree
	/// </summary>
	public partial class failure_tree
	{
		public failure_tree()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ft_id", "failure_tree");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ft_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from failure_tree");
            strSql.Append(" where ft_id=@ft_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ft_id", MySqlDbType.Int32)
			};
            parameters[0].Value = ft_id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(fds.Model.failure_tree model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into failure_tree(");
            strSql.Append("ft_adduser,ptype_id,tpoint_id,system_id,ft_caseid,ft_addtime,ft_pic,ft_grid,ft_keywd,experience)");
            strSql.Append(" values (");
            strSql.Append("@ft_adduser,@ptype_id,@tpoint_id,@system_id,@ft_caseid,@ft_addtime,@ft_pic,@ft_grid,@ft_keywd,@experience)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ft_adduser", MySqlDbType.Int32,11),
					new MySqlParameter("@ptype_id", MySqlDbType.Int32,11),
					new MySqlParameter("@tpoint_id", MySqlDbType.Int32,11),
					new MySqlParameter("@system_id", MySqlDbType.Int32,11),
					new MySqlParameter("@ft_caseid", MySqlDbType.VarChar,128),
					new MySqlParameter("@ft_addtime", MySqlDbType.DateTime),
					new MySqlParameter("@ft_pic", MySqlDbType.LongBlob),
					new MySqlParameter("@ft_grid", MySqlDbType.LongBlob),
					new MySqlParameter("@ft_keywd", MySqlDbType.VarChar,512),
					new MySqlParameter("@experience", MySqlDbType.Text)};
            parameters[0].Value = model.ft_adduser;
            parameters[1].Value = model.ptype_id;
            parameters[2].Value = model.tpoint_id;
            parameters[3].Value = model.system_id;
            parameters[4].Value = model.ft_caseid;
            parameters[5].Value = model.ft_addtime;
            parameters[6].Value = model.ft_pic;
            parameters[7].Value = model.ft_grid;
            parameters[8].Value = model.ft_keywd;
            parameters[9].Value = model.experience;

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
        public bool Update(fds.Model.failure_tree model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update failure_tree set ");
            strSql.Append("ft_adduser=@ft_adduser,");
            strSql.Append("ptype_id=@ptype_id,");
            strSql.Append("tpoint_id=@tpoint_id,");
            strSql.Append("system_id=@system_id,");
            strSql.Append("ft_caseid=@ft_caseid,");
            strSql.Append("ft_addtime=@ft_addtime,");
            strSql.Append("ft_pic=@ft_pic,");
            strSql.Append("ft_grid=@ft_grid,");
            strSql.Append("ft_keywd=@ft_keywd,");
            strSql.Append("experience=@experience");
            strSql.Append(" where ft_id=@ft_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ft_adduser", MySqlDbType.Int32,11),
					new MySqlParameter("@ptype_id", MySqlDbType.Int32,11),
					new MySqlParameter("@tpoint_id", MySqlDbType.Int32,11),
					new MySqlParameter("@system_id", MySqlDbType.Int32,11),
					new MySqlParameter("@ft_caseid", MySqlDbType.VarChar,128),
					new MySqlParameter("@ft_addtime", MySqlDbType.DateTime),
					new MySqlParameter("@ft_pic", MySqlDbType.LongBlob),
					new MySqlParameter("@ft_grid", MySqlDbType.LongBlob),
					new MySqlParameter("@ft_keywd", MySqlDbType.VarChar,512),
					new MySqlParameter("@experience", MySqlDbType.Text),
					new MySqlParameter("@ft_id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.ft_adduser;
            parameters[1].Value = model.ptype_id;
            parameters[2].Value = model.tpoint_id;
            parameters[3].Value = model.system_id;
            parameters[4].Value = model.ft_caseid;
            parameters[5].Value = model.ft_addtime;
            parameters[6].Value = model.ft_pic;
            parameters[7].Value = model.ft_grid;
            parameters[8].Value = model.ft_keywd;
            parameters[9].Value = model.experience;
            parameters[10].Value = model.ft_id;

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
        public bool Delete(int ft_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from failure_tree ");
            strSql.Append(" where ft_id=@ft_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ft_id", MySqlDbType.Int32)
			};
            parameters[0].Value = ft_id;

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
        public bool DeleteList(string ft_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from failure_tree ");
            strSql.Append(" where ft_id in (" + ft_idlist + ")  ");
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
        public fds.Model.failure_tree GetModel(int ft_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ft_id,ft_adduser,ptype_id,tpoint_id,system_id,ft_caseid,ft_addtime,ft_pic,ft_grid,ft_keywd,experience from failure_tree ");
            strSql.Append(" where ft_id=@ft_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ft_id", MySqlDbType.Int32)
			};
            parameters[0].Value = ft_id;

            fds.Model.failure_tree model = new fds.Model.failure_tree();
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
        public fds.Model.failure_tree DataRowToModel(DataRow row)
        {
            fds.Model.failure_tree model = new fds.Model.failure_tree();
            if (row != null)
            {
                if (row["ft_id"] != null && row["ft_id"].ToString() != "")
                {
                    model.ft_id = int.Parse(row["ft_id"].ToString());
                }
                if (row["ft_adduser"] != null && row["ft_adduser"].ToString() != "")
                {
                    model.ft_adduser = int.Parse(row["ft_adduser"].ToString());
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
                if (row["ft_caseid"] != null)
                {
                    model.ft_caseid = row["ft_caseid"].ToString();
                }
                if (row["ft_addtime"] != null && row["ft_addtime"].ToString() != "")
                {
                    model.ft_addtime = DateTime.Parse(row["ft_addtime"].ToString());
                }
                //model.ft_pic=row["ft_pic"].ToString();
                //model.ft_grid=row["ft_grid"].ToString();
                if (row["ft_keywd"] != null)
                {
                    model.ft_keywd = row["ft_keywd"].ToString();
                }
                if (row["experience"] != null)
                {
                    model.experience = row["experience"].ToString();
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
            strSql.Append("select ft_id,ft_adduser,ptype_id,tpoint_id,system_id,ft_caseid,ft_addtime,ft_pic,ft_grid,ft_keywd,experience ");
            strSql.Append(" FROM failure_tree ");
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
            strSql.Append("select count(1) FROM failure_tree ");
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
                strSql.Append("order by T.ft_id desc");
            }
            strSql.Append(")AS Row, T.*  from failure_tree T ");
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
            parameters[0].Value = "failure_tree";
            parameters[1].Value = "ft_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
		#region  ExtensionMethod

        public bool DeleteAll()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from failure_tree ");
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
            string strsql = "select max(ft_caseid) from failure_tree";
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

