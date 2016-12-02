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
using System.Collections.Generic;
using Maticsoft.Common;
using fds.Model;
namespace fds.BLL
{
    /// <summary>
    /// time_point
    /// </summary>
    public partial class time_point
    {
        private readonly fds.DAL.time_point dal = new fds.DAL.time_point();
        public time_point()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int tpoint_id)
        {
            return dal.Exists(tpoint_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(fds.Model.time_point model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(fds.Model.time_point model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int tpoint_id)
        {

            return dal.Delete(tpoint_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string tpoint_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(tpoint_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public fds.Model.time_point GetModel(int tpoint_id)
        {

            return dal.GetModel(tpoint_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public fds.Model.time_point GetModelByCache(int tpoint_id)
        {

            string CacheKey = "time_pointModel-" + tpoint_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(tpoint_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (fds.Model.time_point)objModel;
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
        public List<fds.Model.time_point> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<fds.Model.time_point> DataTableToList(DataTable dt)
        {
            List<fds.Model.time_point> modelList = new List<fds.Model.time_point>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                fds.Model.time_point model;
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

        public bool DeleteAll()
        {
            return dal.DeleteAll();
        }

        public Model.time_point GetModel(string name)
        {
            return dal.GetModel(name);
        }
        #endregion  ExtensionMethod


    }
}

