/**  版本信息模板在安装目录下，可自行修改。
* plane_type.cs
*
* 功 能： N/A
* 类 名： plane_type
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/24 星期四 10:19:39   N/A    初版
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
    /// 数据访问类:plane_type
    /// </summary>
    public partial class plane_type
    {
        public plane_type()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ptype_id", "plane_type");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ptype_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from plane_type");
            strSql.Append(" where ptype_id=@ptype_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ptype_id", MySqlDbType.Int32)
			};
            parameters[0].Value = ptype_id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(fds.Model.plane_type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into plane_type(");
            strSql.Append("ptype_name,plane_remark)");
            strSql.Append(" values (");
            strSql.Append("@ptype_name,@plane_remark)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ptype_name", MySqlDbType.VarChar,128),
					new MySqlParameter("@plane_remark", MySqlDbType.VarChar,256)};
            parameters[0].Value = model.ptype_name;
            parameters[1].Value = model.plane_remark;

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
        public bool Update(fds.Model.plane_type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update plane_type set ");
            strSql.Append("ptype_name=@ptype_name,");
            strSql.Append("plane_remark=@plane_remark");
            strSql.Append(" where ptype_id=@ptype_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ptype_name", MySqlDbType.VarChar,128),
					new MySqlParameter("@plane_remark", MySqlDbType.VarChar,256),
					new MySqlParameter("@ptype_id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.ptype_name;
            parameters[1].Value = model.plane_remark;
            parameters[2].Value = model.ptype_id;

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
        public bool Delete(int ptype_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from plane_type ");
            strSql.Append(" where ptype_id=@ptype_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ptype_id", MySqlDbType.Int32)
			};
            parameters[0].Value = ptype_id;

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
        public bool DeleteList(string ptype_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from plane_type ");
            strSql.Append(" where ptype_id in (" + ptype_idlist + ")  ");
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
        public fds.Model.plane_type GetModel(int ptype_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ptype_id,ptype_name,plane_remark from plane_type ");
            strSql.Append(" where ptype_id=@ptype_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ptype_id", MySqlDbType.Int32)
			};
            parameters[0].Value = ptype_id;

            fds.Model.plane_type model = new fds.Model.plane_type();
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
        public fds.Model.plane_type DataRowToModel(DataRow row)
        {
            fds.Model.plane_type model = new fds.Model.plane_type();
            if (row != null)
            {
                if (row["ptype_id"] != null && row["ptype_id"].ToString() != "")
                {
                    model.ptype_id = int.Parse(row["ptype_id"].ToString());
                }
                if (row["ptype_name"] != null)
                {
                    model.ptype_name = row["ptype_name"].ToString();
                }
                if (row["plane_remark"] != null)
                {
                    model.plane_remark = row["plane_remark"].ToString();
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
            strSql.Append("select ptype_id,ptype_name,plane_remark ");
            strSql.Append(" FROM plane_type ");
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
            strSql.Append("select count(1) FROM plane_type ");
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
                strSql.Append("order by T.ptype_id desc");
            }
            strSql.Append(")AS Row, T.*  from plane_type T ");
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
            parameters[0].Value = "plane_type";
            parameters[1].Value = "ptype_id";
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
            strSql.Append("delete from plane_type ");
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

        public Model.plane_type GetModel(string plnTypeName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ptype_id,ptype_name,plane_remark from plane_type ");
            strSql.Append(" where ptype_name=@ptype_name");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ptype_name", MySqlDbType.VarChar,256)
			};
            parameters[0].Value = plnTypeName;

            fds.Model.plane_type model = new fds.Model.plane_type();
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
        #endregion  ExtensionMethod



    }
}

