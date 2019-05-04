using System;
using System.Management;
using System.Windows.Forms;

namespace Harry.LabCOMMPort
{

	#region USB端口参数

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

		#endregion

	}

	#endregion

	#region USB通信

	public class COMMUSBPort:COMMBasePort
    {
		
		#region 事件定义

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		public override void WatcherPortEventHandler(Object sender, EventArrivedEventArgs e)
		{
			/*
			if (e.NewEvent.ClassPath.ClassName == "__InstanceCreationEvent")
			{
			}
			else if (e.NewEvent.ClassPath.ClassName == "__InstanceDeletionEvent")
			{
			}
			*/
		}
		#endregion
	}
	#endregion
}
