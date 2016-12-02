/**  版本信息模板在安装目录下，可自行修改。
* v_fail_history.cs
*
* 功 能： N/A
* 类 名： v_fail_history
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/24 星期四 14:10:57   N/A    初版
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
	/// 数据访问类:v_fail_history
	/// </summary>
	public partial class v_fail_history
	{
		public v_fail_history()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(fds.Model.v_fail_history model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into v_fail_history(");
			strSql.Append("fh_id,fh_adduser,ptype_id,tpoint_id,system_id,fh_phenomenon,fh_caseid,fh_title,fh_description,fh_cause,fh_suggest,fh_explain,fh_reference,fh_experience,fh_keywd,fh_addtime,system_name,ptype_name,tpoint_value,user_name)");
			strSql.Append(" values (");
			strSql.Append("@fh_id,@fh_adduser,@ptype_id,@tpoint_id,@system_id,@fh_phenomenon,@fh_caseid,@fh_title,@fh_description,@fh_cause,@fh_suggest,@fh_explain,@fh_reference,@fh_experience,@fh_keywd,@fh_addtime,@system_name,@ptype_name,@tpoint_value,@user_name)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@fh_id", MySqlDbType.Int32,11),
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
					new MySqlParameter("@system_name", MySqlDbType.VarChar,128),
					new MySqlParameter("@ptype_name", MySqlDbType.VarChar,128),
					new MySqlParameter("@tpoint_value", MySqlDbType.VarChar,128),
					new MySqlParameter("@user_name", MySqlDbType.VarChar,32)};
			parameters[0].Value = model.fh_id;
			parameters[1].Value = model.fh_adduser;
			parameters[2].Value = model.ptype_id;
			parameters[3].Value = model.tpoint_id;
			parameters[4].Value = model.system_id;
			parameters[5].Value = model.fh_phenomenon;
			parameters[6].Value = model.fh_caseid;
			parameters[7].Value = model.fh_title;
			parameters[8].Value = model.fh_description;
			parameters[9].Value = model.fh_cause;
			parameters[10].Value = model.fh_suggest;
			parameters[11].Value = model.fh_explain;
			parameters[12].Value = model.fh_reference;
			parameters[13].Value = model.fh_experience;
			parameters[14].Value = model.fh_keywd;
			parameters[15].Value = model.fh_addtime;
			parameters[16].Value = model.system_name;
			parameters[17].Value = model.ptype_name;
			parameters[18].Value = model.tpoint_value;
			parameters[19].Value = model.user_name;

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
		public bool Update(fds.Model.v_fail_history model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update v_fail_history set ");
			strSql.Append("fh_id=@fh_id,");
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
			strSql.Append("fh_addtime=@fh_addtime,");
			strSql.Append("system_name=@system_name,");
			strSql.Append("ptype_name=@ptype_name,");
			strSql.Append("tpoint_value=@tpoint_value,");
			strSql.Append("user_name=@user_name");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@fh_id", MySqlDbType.Int32,11),
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
					new MySqlParameter("@system_name", MySqlDbType.VarChar,128),
					new MySqlParameter("@ptype_name", MySqlDbType.VarChar,128),
					new MySqlParameter("@tpoint_value", MySqlDbType.VarChar,128),
					new MySqlParameter("@user_name", MySqlDbType.VarChar,32)};
			parameters[0].Value = model.fh_id;
			parameters[1].Value = model.fh_adduser;
			parameters[2].Value = model.ptype_id;
			parameters[3].Value = model.tpoint_id;
			parameters[4].Value = model.system_id;
			parameters[5].Value = model.fh_phenomenon;
			parameters[6].Value = model.fh_caseid;
			parameters[7].Value = model.fh_title;
			parameters[8].Value = model.fh_description;
			parameters[9].Value = model.fh_cause;
			parameters[10].Value = model.fh_suggest;
			parameters[11].Value = model.fh_explain;
			parameters[12].Value = model.fh_reference;
			parameters[13].Value = model.fh_experience;
			parameters[14].Value = model.fh_keywd;
			parameters[15].Value = model.fh_addtime;
			parameters[16].Value = model.system_name;
			parameters[17].Value = model.ptype_name;
			parameters[18].Value = model.tpoint_value;
			parameters[19].Value = model.user_name;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from v_fail_history ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public fds.Model.v_fail_history GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select fh_id,fh_adduser,ptype_id,tpoint_id,system_id,fh_phenomenon,fh_caseid,fh_title,fh_description,fh_cause,fh_suggest,fh_explain,fh_reference,fh_experience,fh_keywd,fh_addtime,system_name,ptype_name,tpoint_value,user_name from v_fail_history ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

			fds.Model.v_fail_history model=new fds.Model.v_fail_history();
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
		public fds.Model.v_fail_history DataRowToModel(DataRow row)
		{
			fds.Model.v_fail_history model=new fds.Model.v_fail_history();
			if (row != null)
			{
				if(row["fh_id"]!=null && row["fh_id"].ToString()!="")
				{
					model.fh_id=int.Parse(row["fh_id"].ToString());
				}
				if(row["fh_adduser"]!=null && row["fh_adduser"].ToString()!="")
				{
					model.fh_adduser=int.Parse(row["fh_adduser"].ToString());
				}
				if(row["ptype_id"]!=null && row["ptype_id"].ToString()!="")
				{
					model.ptype_id=int.Parse(row["ptype_id"].ToString());
				}
				if(row["tpoint_id"]!=null && row["tpoint_id"].ToString()!="")
				{
					model.tpoint_id=int.Parse(row["tpoint_id"].ToString());
				}
				if(row["system_id"]!=null && row["system_id"].ToString()!="")
				{
					model.system_id=int.Parse(row["system_id"].ToString());
				}
				if(row["fh_phenomenon"]!=null)
				{
					model.fh_phenomenon=row["fh_phenomenon"].ToString();
				}
				if(row["fh_caseid"]!=null)
				{
					model.fh_caseid=row["fh_caseid"].ToString();
				}
				if(row["fh_title"]!=null)
				{
					model.fh_title=row["fh_title"].ToString();
				}
				if(row["fh_description"]!=null)
				{
					model.fh_description=row["fh_description"].ToString();
				}
				if(row["fh_cause"]!=null)
				{
					model.fh_cause=row["fh_cause"].ToString();
				}
				if(row["fh_suggest"]!=null)
				{
					model.fh_suggest=row["fh_suggest"].ToString();
				}
				if(row["fh_explain"]!=null)
				{
					model.fh_explain=row["fh_explain"].ToString();
				}
				if(row["fh_reference"]!=null)
				{
					model.fh_reference=row["fh_reference"].ToString();
				}
				if(row["fh_experience"]!=null)
				{
					model.fh_experience=row["fh_experience"].ToString();
				}
				if(row["fh_keywd"]!=null)
				{
					model.fh_keywd=row["fh_keywd"].ToString();
				}
				if(row["fh_addtime"]!=null && row["fh_addtime"].ToString()!="")
				{
					model.fh_addtime=DateTime.Parse(row["fh_addtime"].ToString());
				}
				if(row["system_name"]!=null)
				{
					model.system_name=row["system_name"].ToString();
				}
				if(row["ptype_name"]!=null)
				{
					model.ptype_name=row["ptype_name"].ToString();
				}
				if(row["tpoint_value"]!=null)
				{
					model.tpoint_value=row["tpoint_value"].ToString();
				}
				if(row["user_name"]!=null)
				{
					model.user_name=row["user_name"].ToString();
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
			strSql.Append("select fh_id,fh_adduser,ptype_id,tpoint_id,system_id,fh_phenomenon,fh_caseid,fh_title,fh_description,fh_cause,fh_suggest,fh_explain,fh_reference,fh_experience,fh_keywd,fh_addtime,system_name,ptype_name,tpoint_value,user_name ");
			strSql.Append(" FROM v_fail_history ");
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
			strSql.Append("select count(1) FROM v_fail_history ");
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
				strSql.Append("order by T.fh_id desc");
			}
			strSql.Append(")AS Row, T.*  from v_fail_history T ");
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
			parameters[0].Value = "v_fail_history";
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

		#endregion  ExtensionMethod
	}
}

