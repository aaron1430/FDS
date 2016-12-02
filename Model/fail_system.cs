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
namespace fds.Model
{
	/// <summary>
	/// fail_system:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class fail_system
	{
		public fail_system()
		{}
		#region Model
		private int _system_id;
		private string _system_name;
		private string _system_remark;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int system_id
		{
			set{ _system_id=value;}
			get{return _system_id;}
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
		public string system_remark
		{
			set{ _system_remark=value;}
			get{return _system_remark;}
		}
		#endregion Model

	}
}

