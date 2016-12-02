/**  版本信息模板在安装目录下，可自行修改。
* time_point.cs
*
* 功 能： N/A
* 类 名： time_point
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
	/// 数据访问类:time_point
	/// </summary>
	public partial class time_point
	{
		public time_point()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("tpoint_id", "time_point"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int tpoint_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from time_point");
			strSql.Append(" where tpoint_id=@tpoint_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@tpoint_id", MySqlDbType.Int32)
			};
			parameters[0].Value = tpoint_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(fds.Model.time_point model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into time_point(");
			strSql.Append("tpoint_value,tpoint_remark)");
			strSql.Append(" values (");
			strSql.Append("@tpoint_value,@tpoint_remark)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@tpoint_value", MySqlDbType.VarChar,128),
					new MySqlParameter("@tpoint_remark", MySqlDbType.VarChar,256)};
			parameters[0].Value = model.tpoint_value;
			parameters[1].Value = model.tpoint_remark;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(fds.Model.time_point model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update time_point set ");
			strSql.Append("tpoint_value=@tpoint_value,");
			strSql.Append("tpoint_remark=@tpoint_remark");
			strSql.Append(" where tpoint_id=@tpoint_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@tpoint_value", MySqlDbType.VarChar,128),
					new MySqlParameter("@tpoint_remark", MySqlDbType.VarChar,256),
					new MySqlParameter("@tpoint_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.tpoint_value;
			parameters[1].Value = model.tpoint_remark;
			parameters[2].Value = model.tpoint_id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int tpoint_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from time_point ");
			strSql.Append(" where tpoint_id=@tpoint_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@tpoint_id", MySqlDbType.Int32)
			};
			parameters[0].Value = tpoint_id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string tpoint_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from time_point ");
			strSql.Append(" where tpoint_id in ("+tpoint_idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public fds.Model.time_point GetModel(int tpoint_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select tpoint_id,tpoint_value,tpoint_remark from time_point ");
			strSql.Append(" where tpoint_id=@tpoint_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@tpoint_id", MySqlDbType.Int32)
			};
			parameters[0].Value = tpoint_id;

			fds.Model.time_point model=new fds.Model.time_point();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public fds.Model.time_point DataRowToModel(DataRow row)
		{
			fds.Model.time_point model=new fds.Model.time_point();
			if (row != null)
			{
				if(row["tpoint_id"]!=null && row["tpoint_id"].ToString()!="")
				{
					model.tpoint_id=int.Parse(row["tpoint_id"].ToString());
				}
				if(row["tpoint_value"]!=null)
				{
					model.tpoint_value=row["tpoint_value"].ToString();
				}
				if(row["tpoint_remark"]!=null)
				{
					model.tpoint_remark=row["tpoint_remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select tpoint_id,tpoint_value,tpoint_remark ");
			strSql.Append(" FROM time_point ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM time_point ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.tpoint_id desc");
			}
			strSql.Append(")AS Row, T.*  from time_point T ");
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
			parameters[0].Value = "time_point";
			parameters[1].Value = "tpoint_id";
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
            strSql.Append("delete from time_point ");
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

        public Model.time_point GetModel(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tpoint_id,tpoint_value,tpoint_remark from time_point ");
            strSql.Append(" where tpoint_value=@tpoint_value");
            MySqlParameter[] parameters = {
					new MySqlParameter("@tpoint_value", MySqlDbType.VarChar,256)
			};
            parameters[0].Value = name;

            fds.Model.time_point model = new fds.Model.time_point();
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

