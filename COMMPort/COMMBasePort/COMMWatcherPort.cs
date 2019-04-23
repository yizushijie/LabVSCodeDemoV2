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
		private ManagementEventWatcher insertWatcher = null;

		/// <summary>
		/// USB拔出事件监视
		/// </summary>
		private ManagementEventWatcher removeWatcher = null;

		#endregion 变量定义

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

					insertWatcher = new ManagementEventWatcher(Scope, InsertQuery);
					insertWatcher.EventArrived += usbInsertHandler;
					insertWatcher.Start();
				}

				//---USB拔出监视
				if (usbRemoveHandler != null)
				{
					WqlEventQuery RemoveQuery = new WqlEventQuery("__InstanceDeletionEvent", withinInterval, "TargetInstance isa 'Win32_USBControllerDevice'");

					removeWatcher = new ManagementEventWatcher(Scope, RemoveQuery);
					removeWatcher.EventArrived += usbRemoveHandler;
					removeWatcher.Start();
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
			if (insertWatcher != null)
			{
				insertWatcher.Stop();
				insertWatcher = null;
			}

			if (removeWatcher != null)
			{
				removeWatcher.Stop();
				removeWatcher = null;
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
