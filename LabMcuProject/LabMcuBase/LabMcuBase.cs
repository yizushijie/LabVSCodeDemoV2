using Harry.LabCOMMPort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabMcuProject
{
	public partial class LabMcuBase
	{
		#region 变量定义

		/// <summary>
		/// 使用的通讯设备端口
		/// </summary>
		private COMMBasePort defaultCOMMPort = new COMMBasePort();

		#endregion

		#region 属性定义

		/// <summary>
		/// 通讯端口属性为读写
		/// </summary>
		public virtual COMMBasePort m_COMMPort
		{
			get
			{
				return this.defaultCOMMPort;
			}
			set
			{
				if (this.defaultCOMMPort==null)
				{
					this.defaultCOMMPort = new COMMBasePort();
				}
				this.defaultCOMMPort = value;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public LabMcuBase()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="usedCOMMPort"></param>
		public LabMcuBase( COMMBasePort usedCOMMPort)
		{
			if (this.defaultCOMMPort==null)
			{
				this.defaultCOMMPort = new COMMBasePort();
			}
			this.defaultCOMMPort = usedCOMMPort;
		}

		#endregion

		#region 公共函数

		#endregion

		#region 私有函数

		#endregion
	}
}
