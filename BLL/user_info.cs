using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using fds.Model;
namespace fds.BLL
{
	/// <summary>
	/// user_info
	/// </summary>
	public partial class user_info
	{
		private readonly fds.DAL.user_info dal=new fds.DAL.user_info();
		public user_info()
		{}
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int user_id)
        {
            return dal.Exists(user_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(fds.Model.user_info model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(fds.Model.user_info model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int user_id)
        {

            return dal.Delete(user_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string user_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(user_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public fds.Model.user_info GetModel(int user_id)
        {

            return dal.GetModel(user_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public fds.Model.user_info GetModelByCache(int user_id)
        {

            string CacheKey = "user_infoModel-" + user_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(user_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (fds.Model.user_info)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<fds.Model.user_info> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<fds.Model.user_info> DataTableToList(DataTable dt)
        {
            List<fds.Model.user_info> modelList = new List<fds.Model.user_info>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                fds.Model.user_info model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 根据用户名获取用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Model.user_info GetModel(string userName)
        {
            return dal.GetModel(userName);
        }
		#endregion  ExtensionMethod

    }
}

