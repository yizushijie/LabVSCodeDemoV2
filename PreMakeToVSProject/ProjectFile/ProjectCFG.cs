using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabPreMakeToVSProject
{
	public class ProjectCFG
	{
		#region 变量定义
		/// <summary>
		/// 名称
		/// </summary>
		private string name = null;

		/// <summary>
		/// 宏定义
		/// </summary>
		///
		private List<string> define = null;

		/// <summary>
		/// 包含路劲
		/// </summary>
		private List<string> includePath = null;

		/// <summary>
		/// 预包含路劲
		/// </summary>
		private List<string> preInclude = null;

		// ReSharper disable once NotAccessedField.Local
		private bool cmsis = false;

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
		public List<string> m_Define
		{
			get
			{
				return this.define;
			}
			set
			{
				this.define = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public List<string> m_IncludePath
		{
			get
			{
				return this.includePath;
			}
			set
			{
				this.includePath = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public List<string> m_PreInclude
		{
			get
			{
				return this.preInclude;
			}
			set
			{
				this.preInclude = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool m_CMSIS
		{
			get
			{
				return this.cmsis;
			}
			set
			{
				this.cmsis = value;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public ProjectCFG()
		{
			this.name = string.Empty;
			this.define = new List<string>();
			this.includePath = new List<string>();
			this.preInclude = new List<string>();
			this.cmsis = false;
		}
		#endregion
	}
}
