
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

		/// <summary>
		/// 
		/// </summary>
		public COMMUSBPortParam() : base()
		{
			this.Init();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="vid"></param>
		/// <param name="pid"></param>
		public COMMUSBPortParam(int vid, int pid)
		{
			this.Init(vid, pid);
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
