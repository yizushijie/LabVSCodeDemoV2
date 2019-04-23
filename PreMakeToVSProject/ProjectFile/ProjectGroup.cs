using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabPreMakeToVSProject
{
    public class ProjectGroup
	{
		#region 变量定义

		/// <summary>
		/// 名称
		/// </summary>
		private string name = null;

		/// <summary>
		/// 文件
		/// </summary>
		private List<ProjectFile> file = null;

		/// <summary>
		/// 子群
		/// </summary>
		private List<ProjectGroup> subGroup = null;

		/// <summary>
		/// 主群
		/// </summary>
		private ProjectGroup masterGroup = null;

		/// <summary>
		/// 不包含
		/// </summary>
		private List<string> exclude = null;

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
		public List<ProjectFile> m_File
		{
			get
			{
				return this.file;
			}
			set
			{
				this.file = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public List<ProjectGroup> m_SubGroup
		{
			get
			{
				return this.subGroup;
			}
			set
			{
				this.subGroup = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public ProjectGroup m_MasterGroup
		{
			get
			{
				return this.masterGroup;
			}
			set
			{
				this.masterGroup = value;
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
		/// <summary>
		/// 全称呼
		/// </summary>
		public string m_FullName
		{
			get
			{
				if (this.masterGroup == null)
				{
					return this.name;
				}
				else
				{
					return this.masterGroup.m_FullName + "/" + this.name;
				}
			}
		}
		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		/// <param name="masterGroup"></param>
		public ProjectGroup()
		{
			this.masterGroup = null;
			this.exclude = new List<string>();
			this.file = new List<ProjectFile>();
			this.subGroup = new List<ProjectGroup>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="masterGroup"></param>
		public ProjectGroup(ProjectGroup masterGroup )
		{
			this.masterGroup = masterGroup;
			this.exclude = new List<string>();
			this.file = new List<ProjectFile>();
			this.subGroup = new List<ProjectGroup>();
		}

		#endregion

		#region 公共函数

		/// <summary>
		///
		/// </summary>
		/// <param name="prjGroup"></param>
		/// <param name="exclude"></param>
		/// <param name="_return"></param>
		/// <returns></returns>
		public List<string> GetPath(List<ProjectGroup> prjGroup, string exclude, List<string> _return = null)
		{
			if (_return == null)
			{
				_return = new List<string>();
			}
			foreach (ProjectGroup temp in prjGroup)
			{
				if (temp.exclude.Contains(exclude))
				{
					continue;
				}
				_return.Add("[\"" + temp.m_FullName + "\"] = { \"" + string.Join("\" , \"", from file in temp.file where (!file.m_Exclude.Contains(exclude)) select file.m_Name) + "\" }");
				this.GetPath(temp.subGroup, exclude, _return);
			}
			return _return;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="prjGroup"></param>
		/// <param name="exclude"></param>
		/// <returns></returns>
		public List<string> GetFile(List<ProjectGroup> prjGroup, string exclude)
		{
			List<string> _return = new List<string>();
			foreach (var temp in prjGroup)
			{
				if (temp.exclude.Contains(exclude))
				{
					break;
				}
				_return.AddRange(from file in temp.file where (!file.m_Exclude.Contains(exclude)) select file.m_Name);
				_return.AddRange(this.GetFile(temp.subGroup, exclude));
			}
			return _return;
		}

		#endregion

	}
}
