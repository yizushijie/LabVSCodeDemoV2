using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Harry.LabCOMMPort 
{
	public partial  class COMMBasePort
	{
		#region 变量定义

		/// <summary>
		/// USB插入事件监视
		/// </summary>
		private ManagementEventWatcher defaultInsertWatcher = null;

		/// <summary>
		/// USB拔出事件监视
		/// </summary>
		private ManagementEventWatcher defaultRemoveWatcher = null;

		#endregion 变量定义

		#region 属性定义

		#endregion

		#region 函数定义

		/// <summary>
		/// 添加USB事件监视器
		/// </summary>
		/// <param name="usbInsertHandler">USB插入事件处理器</param>
		/// <param name="usbRemoveHandler">USB拔出事件处理器</param>
		/// <param name="withinInterval">发送通知允许的滞后时间</param>
		public virtual Boolean AddWatcherPortEvent(EventArrivedEventHandler usbInsertHandler, EventArrivedEventHandler usbRemoveHandler, TimeSpan withinInterval)
		{
			try
			{
				ManagementScope Scope = new ManagementScope("root\\CIMV2");

				Scope.Options.EnablePrivileges = true;

				//---USB插入监视
				if (usbInsertHandler != null)
				{
					WqlEventQuery InsertQuery = new WqlEventQuery("__InstanceCreationEvent", withinInterval, "TargetInstance isa 'Win32_USBControllerDevice'");

					defaultInsertWatcher = new ManagementEventWatcher(Scope, InsertQuery);
					defaultInsertWatcher.EventArrived += usbInsertHandler;
					defaultInsertWatcher.Start();
				}

				//---USB拔出监视
				if (usbRemoveHandler != null)
				{
					WqlEventQuery RemoveQuery = new WqlEventQuery("__InstanceDeletionEvent", withinInterval, "TargetInstance isa 'Win32_USBControllerDevice'");

					defaultRemoveWatcher = new ManagementEventWatcher(Scope, RemoveQuery);
					defaultRemoveWatcher.EventArrived += usbRemoveHandler;
					defaultRemoveWatcher.Start();
				}
				return true;
			}
			catch (Exception)
			{
				this.RemoveWatcherPortEvent();
				return false;
			}
		}

		/// <summary>
		/// 移去USB事件监视器
		/// </summary>
		public virtual void RemoveWatcherPortEvent()
		{
			if (defaultInsertWatcher != null)
			{
				defaultInsertWatcher.Stop();
				defaultInsertWatcher = null;
			}

			if (defaultRemoveWatcher != null)
			{
				defaultRemoveWatcher.Stop();
				defaultRemoveWatcher = null;
			}
		}

		#endregion 

		#region 事件定义

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void WatcherPortEventHandler(Object sender, EventArrivedEventArgs e)
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
