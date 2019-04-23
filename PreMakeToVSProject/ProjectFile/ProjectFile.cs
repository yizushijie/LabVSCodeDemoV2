using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabPreMakeToVSProject
{
	public class ProjectFile
	{
		#region 变量定义
		/// <summary>
		/// 名称
		/// </summary>
		private string name=null;

		/// <summary>
		/// 不包含
		/// </summary>
		private List<string> exclude= null;

		#endregion

		#region 属性定义

		/// <summary>
		/// 
		/// </summary>
		public string m_Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public List<string> m_Exclude
		{
			get
			{
				return this.exclude;
			}
			set
			{
				this.exclude = value;
			}
		}

		#endregion

		#region 构造函数
		public ProjectFile()
		{
			this.name = string.Empty;
			this.exclude = new List<string>();
		}
		#endregion

	}
}
