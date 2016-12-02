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
namespace fds.Model
{
    /// <summary>
    /// v_failure_tree:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_failure_tree
    {
        public v_failure_tree()
        { }
        #region Model
        private int _ft_id = 0;
        private int _ft_adduser;
        private int _ptype_id;
        private int _tpoint_id;
        private int _system_id;
        private DateTime _ft_addtime;
        private byte[] _ft_pic;
        private byte[] _ft_grid;
        private string _ft_keywd;
        private string _ptype_name;
        private string _tpoint_value;
        private string _system_name;
        private string _user_name;
        private string _experience;
        private string _ft_caseid;
        /// <summary>
        /// 
        /// </summary>
        public int ft_id
        {
            set { _ft_id = value; }
            get { return _ft_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ft_adduser
        {
            set { _ft_adduser = value; }
            get { return _ft_adduser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ptype_id
        {
            set { _ptype_id = value; }
            get { return _ptype_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tpoint_id
        {
            set { _tpoint_id = value; }
            get { return _tpoint_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int system_id
        {
            set { _system_id = value; }
            get { return _system_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ft_addtime
        {
            set { _ft_addtime = value; }
            get { return _ft_addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] ft_pic
        {
            set { _ft_pic = value; }
            get { return _ft_pic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] ft_grid
        {
            set { _ft_grid = value; }
            get { return _ft_grid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ft_keywd
        {
            set { _ft_keywd = value; }
            get { return _ft_keywd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ptype_name
        {
            set { _ptype_name = value; }
            get { return _ptype_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tpoint_value
        {
            set { _tpoint_value = value; }
            get { return _tpoint_value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string system_name
        {
            set { _system_name = value; }
            get { return _system_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string experience
        {
            set { _experience = value; }
            get { return _experience; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ft_caseid
        {
            set { _ft_caseid = value; }
            get { return _ft_caseid; }
        }
        #endregion Model

    }
}

