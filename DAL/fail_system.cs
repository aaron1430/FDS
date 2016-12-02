/**  版本信息模板在安装目录下，可自行修改。
* fail_system.cs
*
* 功 能： N/A
* 类 名： fail_system
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/24 星期四 10:19:38   N/A    初版
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
	/// 数据访问类:fail_system
	/// </summary>
	public partial class fail_system
	{
		public fail_system()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("system_id", "fail_system"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int system_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from fail_system");
			strSql.Append(" where system_id=@system_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@system_id", MySqlDbType.Int32)
			};
			parameters[0].Value = system_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(fds.Model.fail_system model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into fail_system(");
			strSql.Append("system_name,system_remark)");
			strSql.Append(" values (");
			strSql.Append("@system_name,@system_remark)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@system_name", MySqlDbType.VarChar,128),
					new MySqlParameter("@system_remark", MySqlDbType.VarChar,256)};
			parameters[0].Value = model.system_name;
			parameters[1].Value = model.system_remark;

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
		public bool Update(fds.Model.fail_system model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update fail_system set ");
			strSql.Append("system_name=@system_name,");
			strSql.Append("system_remark=@system_remark");
			strSql.Append(" where system_id=@system_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@system_name", MySqlDbType.VarChar,128),
					new MySqlParameter("@system_remark", MySqlDbType.VarChar,256),
					new MySqlParameter("@system_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.system_name;
			parameters[1].Value = model.system_remark;
			parameters[2].Value = model.system_id;

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
		public bool Delete(int system_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from fail_system ");
			strSql.Append(" where system_id=@system_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@system_id", MySqlDbType.Int32)
			};
			parameters[0].Value = system_id;

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
		public bool DeleteList(string system_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from fail_system ");
			strSql.Append(" where system_id in ("+system_idlist + ")  ");
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
		public fds.Model.fail_system GetModel(int system_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select system_id,system_name,system_remark from fail_system ");
			strSql.Append(" where system_id=@system_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@system_id", MySqlDbType.Int32)
			};
			parameters[0].Value = system_id;

			fds.Model.fail_system model=new fds.Model.fail_system();
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
		public fds.Model.fail_system DataRowToModel(DataRow row)
		{
			fds.Model.fail_system model=new fds.Model.fail_system();
			if (row != null)
			{
				if(row["system_id"]!=null && row["system_id"].ToString()!="")
				{
					model.system_id=int.Parse(row["system_id"].ToString());
				}
				if(row["system_name"]!=null)
				{
					model.system_name=row["system_name"].ToString();
				}
				if(row["system_remark"]!=null)
				{
					model.system_remark=row["system_remark"].ToString();
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
			strSql.Append("select system_id,system_name,system_remark ");
			strSql.Append(" FROM fail_system ");
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
			strSql.Append("select count(1) FROM fail_system ");
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
				strSql.Append("order by T.system_id desc");
			}
			strSql.Append(")AS Row, T.*  from fail_system T ");
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
			parameters[0].Value = "fail_system";
			parameters[1].Value = "system_id";
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
            strSql.Append("delete from fail_system ");
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

        public Model.fail_system GetModel(string plnTypeName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select system_id,system_name,system_remark from fail_system ");
            strSql.Append(" where system_name=@system_name");
            MySqlParameter[] parameters = {
					new MySqlParameter("@system_name", MySqlDbType.VarChar,256)
			};
            parameters[0].Value = plnTypeName;

            fds.Model.fail_system model = new fds.Model.fail_system();
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

