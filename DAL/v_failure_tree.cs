/**  版本信息模板在安装目录下，可自行修改。
* v_failure_tree.cs
*
* 功 能： N/A
* 类 名： v_failure_tree
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
using Maticsoft.DBUtility;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;//Please add references
namespace fds.DAL
{
    /// <summary>
    /// 数据访问类:v_failure_tree
    /// </summary>
    public partial class v_failure_tree
    {
        public v_failure_tree()
        { }
        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(fds.Model.v_failure_tree model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into v_failure_tree(");
            strSql.Append("ft_id,ft_adduser,ptype_id,tpoint_id,system_id,ft_addtime,ft_pic,ft_grid,ft_keywd,ptype_name,tpoint_value,system_name,user_name,experience,ft_caseid)");
            strSql.Append(" values (");
            strSql.Append("@ft_id,@ft_adduser,@ptype_id,@tpoint_id,@system_id,@ft_addtime,@ft_pic,@ft_grid,@ft_keywd,@ptype_name,@tpoint_value,@system_name,@user_name,@experience,@ft_caseid)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ft_id", MySqlDbType.Int32,11),
					new MySqlParameter("@ft_adduser", MySqlDbType.Int32,11),
					new MySqlParameter("@ptype_id", MySqlDbType.Int32,11),
					new MySqlParameter("@tpoint_id", MySqlDbType.Int32,11),
					new MySqlParameter("@system_id", MySqlDbType.Int32,11),
					new MySqlParameter("@ft_addtime", MySqlDbType.DateTime),
					new MySqlParameter("@ft_pic", MySqlDbType.LongBlob),
					new MySqlParameter("@ft_grid", MySqlDbType.LongBlob),
					new MySqlParameter("@ft_keywd", MySqlDbType.VarChar,512),
					new MySqlParameter("@ptype_name", MySqlDbType.VarChar,128),
					new MySqlParameter("@tpoint_value", MySqlDbType.VarChar,128),
					new MySqlParameter("@system_name", MySqlDbType.VarChar,128),
					new MySqlParameter("@user_name", MySqlDbType.VarChar,32),
					new MySqlParameter("@experience", MySqlDbType.Text),
					new MySqlParameter("@ft_caseid", MySqlDbType.VarChar,128)};
            parameters[0].Value = model.ft_id;
            parameters[1].Value = model.ft_adduser;
            parameters[2].Value = model.ptype_id;
            parameters[3].Value = model.tpoint_id;
            parameters[4].Value = model.system_id;
            parameters[5].Value = model.ft_addtime;
            parameters[6].Value = model.ft_pic;
            parameters[7].Value = model.ft_grid;
            parameters[8].Value = model.ft_keywd;
            parameters[9].Value = model.ptype_name;
            parameters[10].Value = model.tpoint_value;
            parameters[11].Value = model.system_name;
            parameters[12].Value = model.user_name;
            parameters[13].Value = model.experience;
            parameters[14].Value = model.ft_caseid;

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
        public bool Update(fds.Model.v_failure_tree model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update v_failure_tree set ");
            strSql.Append("ft_id=@ft_id,");
            strSql.Append("ft_adduser=@ft_adduser,");
            strSql.Append("ptype_id=@ptype_id,");
            strSql.Append("tpoint_id=@tpoint_id,");
            strSql.Append("system_id=@system_id,");
            strSql.Append("ft_addtime=@ft_addtime,");
            strSql.Append("ft_pic=@ft_pic,");
            strSql.Append("ft_grid=@ft_grid,");
            strSql.Append("ft_keywd=@ft_keywd,");
            strSql.Append("ptype_name=@ptype_name,");
            strSql.Append("tpoint_value=@tpoint_value,");
            strSql.Append("system_name=@system_name,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("experience=@experience,");
            strSql.Append("ft_caseid=@ft_caseid");
            strSql.Append(" where ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ft_id", MySqlDbType.Int32,11),
					new MySqlParameter("@ft_adduser", MySqlDbType.Int32,11),
					new MySqlParameter("@ptype_id", MySqlDbType.Int32,11),
					new MySqlParameter("@tpoint_id", MySqlDbType.Int32,11),
					new MySqlParameter("@system_id", MySqlDbType.Int32,11),
					new MySqlParameter("@ft_addtime", MySqlDbType.DateTime),
					new MySqlParameter("@ft_pic", MySqlDbType.LongBlob),
					new MySqlParameter("@ft_grid", MySqlDbType.LongBlob),
					new MySqlParameter("@ft_keywd", MySqlDbType.VarChar,512),
					new MySqlParameter("@ptype_name", MySqlDbType.VarChar,128),
					new MySqlParameter("@tpoint_value", MySqlDbType.VarChar,128),
					new MySqlParameter("@system_name", MySqlDbType.VarChar,128),
					new MySqlParameter("@user_name", MySqlDbType.VarChar,32),
					new MySqlParameter("@experience", MySqlDbType.Text),
					new MySqlParameter("@ft_caseid", MySqlDbType.VarChar,128)};
            parameters[0].Value = model.ft_id;
            parameters[1].Value = model.ft_adduser;
            parameters[2].Value = model.ptype_id;
            parameters[3].Value = model.tpoint_id;
            parameters[4].Value = model.system_id;
            parameters[5].Value = model.ft_addtime;
            parameters[6].Value = model.ft_pic;
            parameters[7].Value = model.ft_grid;
            parameters[8].Value = model.ft_keywd;
            parameters[9].Value = model.ptype_name;
            parameters[10].Value = model.tpoint_value;
            parameters[11].Value = model.system_name;
            parameters[12].Value = model.user_name;
            parameters[13].Value = model.experience;
            parameters[14].Value = model.ft_caseid;

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
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from v_failure_tree ");
            strSql.Append(" where ");
            MySqlParameter[] parameters = {
			};

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
        /// 得到一个对象实体
        /// </summary>
        public fds.Model.v_failure_tree GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ft_id,ft_adduser,ptype_id,tpoint_id,system_id,ft_addtime,ft_pic,ft_grid,ft_keywd,ptype_name,tpoint_value,system_name,user_name,experience,ft_caseid from v_failure_tree ");
            strSql.Append(" where ");
            MySqlParameter[] parameters = {
			};

            fds.Model.v_failure_tree model = new fds.Model.v_failure_tree();
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
        public fds.Model.v_failure_tree DataRowToModel(DataRow row)
        {
            fds.Model.v_failure_tree model = new fds.Model.v_failure_tree();
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
                if (row["ft_addtime"] != null && row["ft_addtime"].ToString() != "")
                {
                    model.ft_addtime = DateTime.Parse(row["ft_addtime"].ToString());
                }
                if (row["ft_pic"] != null)
                {
                    model.ft_pic = GetBinaryFormatData(row["ft_pic"]);
                }
                if (row["ft_grid"] != null)
                {
                    model.ft_grid = GetBinaryFormatData(row["ft_grid"]);
                }
                if (row["ft_keywd"] != null)
                {
                    model.ft_keywd = row["ft_keywd"].ToString();
                }
                if (row["ptype_name"] != null)
                {
                    model.ptype_name = row["ptype_name"].ToString();
                }
                if (row["tpoint_value"] != null)
                {
                    model.tpoint_value = row["tpoint_value"].ToString();
                }
                if (row["system_name"] != null)
                {
                    model.system_name = row["system_name"].ToString();
                }
                if (row["user_name"] != null)
                {
                    model.user_name = row["user_name"].ToString();
                }
                if (row["experience"] != null)
                { 
                model.experience=row["experience"].ToString();
                }
                if (row["ft_caseid"] != null)
                {
                    model.ft_caseid = row["ft_caseid"].ToString();
                }
            }
            return model;
        }

        private byte[] GetBinaryFormatData(object picObj)
        {
            byte[] binaryDataResult = null;
            binaryDataResult = (byte[])picObj;
            return binaryDataResult;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ft_id,ft_adduser,ptype_id,tpoint_id,system_id,ft_addtime,ft_pic,ft_grid,ft_keywd,ptype_name,tpoint_value,system_name,user_name,experience,ft_caseid ");
            strSql.Append(" FROM v_failure_tree ");
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
            strSql.Append("select count(1) FROM v_failure_tree ");
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
            strSql.Append(")AS Row, T.*  from v_failure_tree T ");
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
            parameters[0].Value = "v_failure_tree";
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

        #endregion  ExtensionMethod
    }
}

