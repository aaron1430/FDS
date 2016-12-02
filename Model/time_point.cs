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
namespace fds.Model
{
	/// <summary>
	/// time_point:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class time_point
	{
		public time_point()
		{}
		#region Model
		private int _tpoint_id;
		private string _tpoint_value;
		private string _tpoint_remark;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int tpoint_id
		{
			set{ _tpoint_id=value;}
			get{return _tpoint_id;}
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
		public string tpoint_remark
		{
			set{ _tpoint_remark=value;}
			get{return _tpoint_remark;}
		}
		#endregion Model

	}
}

