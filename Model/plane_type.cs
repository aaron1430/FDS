/**  版本信息模板在安装目录下，可自行修改。
* plane_type.cs
*
* 功 能： N/A
* 类 名： plane_type
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
namespace fds.Model
{
	/// <summary>
	/// plane_type:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class plane_type
	{
		public plane_type()
		{}
		#region Model
		private int _ptype_id;
		private string _ptype_name;
		private string _plane_remark;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int ptype_id
		{
			set{ _ptype_id=value;}
			get{return _ptype_id;}
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
		public string plane_remark
		{
			set{ _plane_remark=value;}
			get{return _plane_remark;}
		}
		#endregion Model

	}
}

