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
using System.Collections.Generic;
using Maticsoft.Common;
using fds.Model;
namespace fds.BLL
{
    /// <summary>
    /// fault_history
    /// </summary>
    public partial class fault_history
    {
        private readonly fds.DAL.fault_history dal = new fds.DAL.fault_history();
        public fault_history()
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
        public bool Exists(int fh_id)
        {
            return dal.Exists(fh_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(fds.Model.fault_history model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(fds.Model.fault_history model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int fh_id)
        {

            return dal.Delete(fh_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string fh_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(fh_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public fds.Model.fault_history GetModel(int fh_id)
        {

            return dal.GetModel(fh_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public fds.Model.fault_history GetModelByCache(int fh_id)
        {

            string CacheKey = "fault_historyModel-" + fh_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(fh_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (fds.Model.fault_history)objModel;
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
        public List<fds.Model.fault_history> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<fds.Model.fault_history> DataTableToList(DataTable dt)
        {
            List<fds.Model.fault_history> modelList = new List<fds.Model.fault_history>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                fds.Model.fault_history model;
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

        public string getMaxCaseID()
        {
            return dal.getMaxCaseID();
        }
        public string createCaseID(string maxCaseID)
        {
            string newCaseID = "ADY00001";
            if (maxCaseID.Length == 0)
                return newCaseID;
            long srl = int.Parse(maxCaseID.Substring(3));
            long newSrl = srl + 1;
            newCaseID = "ADY" + newSrl.ToString().PadLeft(5, '0');
            return newCaseID;
        }
        #endregion  ExtensionMethod

    }
}

