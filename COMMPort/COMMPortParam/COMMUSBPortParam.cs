
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabCOMMPort
{

	public class COMMUSBPortParam : COMMPortParam
	{
		#region 变量定义

		#endregion

		#region 属性定义


		#endregion

		#region 构造函数

		public COMMUSBPortParam() : base()
		{

		}

		#endregion

		#region 函数定义

		/// <summary>
		/// 
		/// </summary>
		public override void Init()
		{
			this.defaultVID = 0;
			this.defaultPID = 0;
			this.defaultIndex = -1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="vid"></param>
		/// <param name="pid"></param>
		public override void Init(int vid, int pid)
		{
			this.defaultVID = vid;
			this.defaultPID = pid;
		}

		#endregion

	}

}
