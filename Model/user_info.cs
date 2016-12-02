using System;
namespace fds.Model
{
    /// <summary>
    /// user_info:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class user_info
    {
        public user_info()
        { }
        #region Model
        private int _user_id;
        private string _user_name;
        private string _user_pwd;
        private string _user_tel;
        private string _user_email;
        private string _user_remark;
        private bool _user_isadmin = false;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int user_id
        {
            set { _user_id = value; }
            get { return _user_id; }
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
        public string user_pwd
        {
            set { _user_pwd = value; }
            get { return _user_pwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_tel
        {
            set { _user_tel = value; }
            get { return _user_tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_email
        {
            set { _user_email = value; }
            get { return _user_email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_remark
        {
            set { _user_remark = value; }
            get { return _user_remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool user_isadmin
        {
            set { _user_isadmin = value; }
            get { return _user_isadmin; }
        }
        #endregion Model

    }
}

