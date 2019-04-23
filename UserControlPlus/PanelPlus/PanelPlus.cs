using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using Harry.LabWinAPI;
using System.Runtime.InteropServices;

namespace Harry.LabUserControlPlus
{

	/// <summary>
	/// 使用本控件是嵌套外部exe应用，不支持计算器
	/// </summary>
	public partial class PanelPlus : Panel
	{

		#region 属性定义

		/// <summary>
		/// 
		/// </summary>
		private ManualResetEvent _eventDone = new ManualResetEvent(false);

		/// <summary>
		/// 
		/// </summary>
		private Process _process = null;

		/// <summary>
		/// 
		/// </summary>
		private IntPtr _embededWindowHandle = (IntPtr)0;

		#endregion

		#region 构造函数
		public PanelPlus()
		{
			InitializeComponent();
		}


		#endregion

		#region 重载函数

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnHandleDestroyed(EventArgs e)
		{
			this.Stop();
			base.OnHandleDestroyed(e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			if (_process != null)
			{
				Win32API.MoveWindow(this._process.MainWindowHandle, 0, 0, this.Width, this.Height, true);
			}

			base.OnResize(e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnSizeChanged(EventArgs e)
		{
			this.Invalidate();
			base.OnSizeChanged(e);
		}

		#endregion

		#region 私有函数定义

		/// <summary>
		/// 启动外进程
		/// </summary>
		/// <param name="appPath"></param>
		/// <returns></returns>
		private Process Start(string appPath)
		{
			if (!File.Exists(appPath))
			{
				return null;
			}
			ProcessStartInfo info = new ProcessStartInfo(appPath)
			{
				UseShellExecute = true,
				WindowStyle = ProcessWindowStyle.Minimized
			};
			Process process = Process.Start(info);

			return process;
		}

		/// <summary>
		/// 关闭外进程
		/// </summary>
		/// <param name="process"></param>
		private void Kill(Process process)
		{
			if ((process != null) && (!process.HasExited))
			{
				process.Kill();
			}
		}


		/// <summary>
		/// 将外进程嵌入到当前程序
		/// </summary>
		/// <param name="process"></param>
		private bool EmbeddedProcess(Process process)
		{
			//---是否嵌入成功标志，用作返回值
			bool isEmbedSuccess = false;
			//---外进程句柄
			IntPtr processHwnd = process.MainWindowHandle;
			//---容器句柄
			IntPtr panelHwnd = this.Handle;

			if (processHwnd != (IntPtr)0 && panelHwnd != (IntPtr)0)
			{
				//---把本窗口句柄与目标窗口句柄关联起来
				int setTime = 0;
				while (!isEmbedSuccess && setTime < 10)
				{
					isEmbedSuccess = (Win32API.SetParent(processHwnd, panelHwnd) != 0);
					Thread.Sleep(100);
					setTime++;
				}
				//---设置初始尺寸和位置
				Win32API.MoveWindow(this._process.MainWindowHandle, 0, 0, this.Width, this.Height, true);
				// Remove border and whatnot               
				//---移除边框和右上角的最大，最小和关闭功能
				Win32API.SetWindowLong(new HandleRef(this, this._process.MainWindowHandle), Win32API.GWL_STYLE, Win32API.WS_VISIBLE);
			}

			if (isEmbedSuccess)
			{
				this._embededWindowHandle = this._process.MainWindowHandle;
			}

			return isEmbedSuccess;
		}

		#endregion

		#region 公有函数定义

		/// <summary>
		/// 
		/// </summary>
		/// <param name="processPath"></param>
		/// <returns></returns>
		public bool EmbeddedProcess(string processPath)
		{
			bool isStartAndEmbedSuccess = false;
			this._eventDone.Reset();

			//---启动进程
			this._process = this.Start(processPath);

			//---等待新进程完成它的初始化并等待用户输入
			this._process.WaitForInputIdle();

			if (this._process == null)
			{
				return false;
			}

			//---确保可获取到句柄
			Thread thread = new Thread(new ThreadStart(() =>
			{
				while (true)
				{
					if (this._process.MainWindowHandle != (IntPtr)0)
					{
						this._eventDone.Set();
						break;
					}
					Thread.Sleep(10);
				}
			}));
			thread.Start();

			//---嵌入进程
			if (this._eventDone.WaitOne(10000))
			{
				isStartAndEmbedSuccess = this.EmbeddedProcess(_process);
				if (!isStartAndEmbedSuccess)
				{
					this.Kill(this._process);
				}
			}
			return isStartAndEmbedSuccess;
		}

		
		/// <summary>
		/// 关闭进程
		/// </summary>
		public void Stop()
		{
			this.Kill(this._process);
		}


		/// <summary>
		/// 嵌入已经存在的进程
		/// </summary>
		/// <param name="process"></param>
		/// <returns></returns>
		public bool EmbeddedExistedProcess(Process process)
		{
			this._process = process;

			return this.EmbeddedProcess(process);
		}

		#endregion

	}
}
