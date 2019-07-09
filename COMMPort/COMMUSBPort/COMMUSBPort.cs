using System;
using System.Management;
using System.Windows.Forms;

namespace Harry.LabCOMMPort
{

	#region USB端口参数

	public class COMMUSBPortParam : COMMPortParam
	{
		#region 变量定义

		/// <summary>
		/// 设备的VIP
		/// </summary>
		private int defaultVIP = 0;

		/// <summary>
		/// 设备的PID
		/// </summary>
		private int defaultPID = 0;

		/// <summary>
		/// 设备在当前设备集合中的索引号
		/// </summary>
		private int defaultIndex = -1;

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
		public void Init()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="vid"></param>
		/// <param name="pid"></param>
		public void Init(int vid,int pid)
		{

		}

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
