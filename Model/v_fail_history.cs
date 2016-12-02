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
namespace fds.Model
{
	/// <summary>
	/// v_fail_history:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_fail_history
	{
		public v_fail_history()
		{}
		#region Model
		private int _fh_id=0;
		private int _fh_adduser;
		private int _ptype_id;
		private int _tpoint_id;
		private int _system_id;
		private string _fh_phenomenon;
		private string _fh_caseid;
		private string _fh_title;
		private string _fh_description;
		private string _fh_cause;
		private string _fh_suggest;
		private string _fh_explain;
		private string _fh_reference;
		private string _fh_experience;
		private string _fh_keywd;
		private DateTime _fh_addtime;
		private string _system_name;
		private string _ptype_name;
		private string _tpoint_value;
		private string _user_name;
		/// <summary>
		/// 
		/// </summary>
		public int fh_id
		{
			set{ _fh_id=value;}
			get{return _fh_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int fh_adduser
		{
			set{ _fh_adduser=value;}
			get{return _fh_adduser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ptype_id
		{
			set{ _ptype_id=value;}
			get{return _ptype_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int tpoint_id
		{
			set{ _tpoint_id=value;}
			get{return _tpoint_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int system_id
		{
			set{ _system_id=value;}
			get{return _system_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fh_phenomenon
		{
			set{ _fh_phenomenon=value;}
			get{return _fh_phenomenon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fh_caseid
		{
			set{ _fh_caseid=value;}
			get{return _fh_caseid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fh_title
		{
			set{ _fh_title=value;}
			get{return _fh_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fh_description
		{
			set{ _fh_description=value;}
			get{return _fh_description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fh_cause
		{
			set{ _fh_cause=value;}
			get{return _fh_cause;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fh_suggest
		{
			set{ _fh_suggest=value;}
			get{return _fh_suggest;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fh_explain
		{
			set{ _fh_explain=value;}
			get{return _fh_explain;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fh_reference
		{
			set{ _fh_reference=value;}
			get{return _fh_reference;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fh_experience
		{
			set{ _fh_experience=value;}
			get{return _fh_experience;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fh_keywd
		{
			set{ _fh_keywd=value;}
			get{return _fh_keywd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime fh_addtime
		{
			set{ _fh_addtime=value;}
			get{return _fh_addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string system_name
		{
			set{ _system_name=value;}
			get{return _system_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ptype_name
		{
			set{ _ptype_name=value;}
			get{return _ptype_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tpoint_value
		{
			set{ _tpoint_value=value;}
			get{return _tpoint_value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_name
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		#endregion Model

	}
}

