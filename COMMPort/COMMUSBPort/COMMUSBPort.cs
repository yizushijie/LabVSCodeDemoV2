using System;
using System.Management;
using System.Windows.Forms;

namespace Harry.LabCOMMPort
{
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
}
