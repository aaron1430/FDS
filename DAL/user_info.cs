using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace fds.DAL
{
	/// <summary>
	/// 数据访问类:user_info
	/// </summary>
	public partial class user_info
	{
		public user_info()
		{}
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int user_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from user_info");
            strSql.Append(" where user_id=@user_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@user_id", MySqlDbType.Int32)
			};
            parameters[0].Value = user_id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(fds.Model.user_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into user_info(");
            strSql.Append("user_name,user_pwd,user_tel,user_email,user_remark,user_isadmin)");
            strSql.Append(" values (");
            strSql.Append("@user_name,@user_pwd,@user_tel,@user_email,@user_remark,@user_isadmin)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@user_name", MySqlDbType.VarChar,32),
					new MySqlParameter("@user_pwd", MySqlDbType.VarChar,32),
					new MySqlParameter("@user_tel", MySqlDbType.VarChar,32),
					new MySqlParameter("@user_email", MySqlDbType.VarChar,32),
					new MySqlParameter("@user_remark", MySqlDbType.VarChar,256),
					new MySqlParameter("@user_isadmin", MySqlDbType.Bit)};
            parameters[0].Value = model.user_name;
            parameters[1].Value = model.user_pwd;
            parameters[2].Value = model.user_tel;
            parameters[3].Value = model.user_email;
            parameters[4].Value = model.user_remark;
            parameters[5].Value = model.user_isadmin;

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
        public bool Update(fds.Model.user_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update user_info set ");
            strSql.Append("user_name=@user_name,");
            strSql.Append("user_pwd=@user_pwd,");
            strSql.Append("user_tel=@user_tel,");
            strSql.Append("user_email=@user_email,");
            strSql.Append("user_remark=@user_remark,");
            strSql.Append("user_isadmin=@user_isadmin");
            strSql.Append(" where user_id=@user_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@user_name", MySqlDbType.VarChar,32),
					new MySqlParameter("@user_pwd", MySqlDbType.VarChar,32),
					new MySqlParameter("@user_tel", MySqlDbType.VarChar,32),
					new MySqlParameter("@user_email", MySqlDbType.VarChar,32),
					new MySqlParameter("@user_remark", MySqlDbType.VarChar,256),
					new MySqlParameter("@user_isadmin", MySqlDbType.Bit),
					new MySqlParameter("@user_id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.user_name;
            parameters[1].Value = model.user_pwd;
            parameters[2].Value = model.user_tel;
            parameters[3].Value = model.user_email;
            parameters[4].Value = model.user_remark;
            parameters[5].Value = model.user_isadmin;
            parameters[6].Value = model.user_id;

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
        public bool Delete(int user_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from user_info ");
            strSql.Append(" where user_id=@user_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@user_id", MySqlDbType.Int32)
			};
            parameters[0].Value = user_id;

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
        public bool DeleteList(string user_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from user_info ");
            strSql.Append(" where user_id in (" + user_idlist + ")  ");
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
        public fds.Model.user_info GetModel(int user_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select user_id,user_name,user_pwd,user_tel,user_email,user_remark,user_isadmin from user_info ");
            strSql.Append(" where user_id=@user_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@user_id", MySqlDbType.Int32)
			};
            parameters[0].Value = user_id;

            fds.Model.user_info model = new fds.Model.user_info();
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
        public fds.Model.user_info DataRowToModel(DataRow row)
        {
            fds.Model.user_info model = new fds.Model.user_info();
            if (row != null)
            {
                if (row["user_id"] != null && row["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(row["user_id"].ToString());
                }
                if (row["user_name"] != null)
                {
                    model.user_name = row["user_name"].ToString();
                }
                if (row["user_pwd"] != null)
                {
                    model.user_pwd = row["user_pwd"].ToString();
                }
                if (row["user_tel"] != null)
                {
                    model.user_tel = row["user_tel"].ToString();
                }
                if (row["user_email"] != null)
                {
                    model.user_email = row["user_email"].ToString();
                }
                if (row["user_remark"] != null)
                {
                    model.user_remark = row["user_remark"].ToString();
                }
                if (row["user_isadmin"] != null && row["user_isadmin"].ToString() != "")
                {
                    if ((row["user_isadmin"].ToString() == "1") || (row["user_isadmin"].ToString().ToLower() == "true"))
                    {
                        model.user_isadmin = true;
                    }
                    else
                    {
                        model.user_isadmin = false;
                    }
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
            strSql.Append("select user_id,user_name,user_pwd,user_tel,user_email,user_remark,user_isadmin ");
            strSql.Append(" FROM user_info ");
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
            strSql.Append("select count(1) FROM user_info ");
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
                strSql.Append("order by T.user_id desc");
            }
            strSql.Append(")AS Row, T.*  from user_info T ");
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
            parameters[0].Value = "user_info";
            parameters[1].Value = "user_id";
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
        /// 根据用户名得到一个对象实体
        /// </summary>
        public fds.Model.user_info GetModel(string userName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select user_id,user_name,user_pwd,user_tel,user_email,user_remark,user_isadmin from user_info ");
            strSql.Append(" where user_name=@user_name");
            MySqlParameter[] parameters = {
					new MySqlParameter("@user_name", MySqlDbType.String)
			};
            parameters[0].Value = userName;

            fds.Model.user_info model = new fds.Model.user_info();
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

