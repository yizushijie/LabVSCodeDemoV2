using Harry.LabUserControlPlus;
using System;
using System.Windows.Forms;

namespace Harry.LabEmbeddedProcessForm
{
	public partial class EmbeddedProcessForm : Form
	{
		#region 属性定义

		/// <summary>
		/// 获取当前进程的名称
		/// </summary>
		public string m_ProcessName
		{
			get
			{
				return this.Text;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private string _processPatch = null;
		
		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public EmbeddedProcessForm()
		{
			InitializeComponent();

			this.Load += new EventHandler(this.EmbeddedForm_FormLoad);

		}

		/// <summary>
		/// 
		/// </summary>
		public EmbeddedProcessForm(string exePatch,string exeName)
		{
			InitializeComponent();

			this.Load += new EventHandler(this.EmbeddedForm_FormLoad);

			this.Text = exeName;
			this.StartProcess(exePatch);

		}

		/// <summary>
		/// 
		/// </summary>
		public EmbeddedProcessForm(string exeName)
		{
			InitializeComponent();

			this.Load += new EventHandler(this.EmbeddedForm_FormLoad);

			this.Text = exeName;

		}

		#endregion

		#region 初始化

		/// <summary>
		/// 船体初始化函数
		/// </summary>
		private void MdiForm_Init()
		{
			//---事件注册
			this.FormClosing += new FormClosingEventHandler(this.EmbeddedForm_FormClosing);

		}
		
		#endregion

		#region 事件处理

		/// <summary>
		/// 窗体加载事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void EmbeddedForm_FormLoad(object sender, System.EventArgs e)
		{
			this.MdiForm_Init();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EmbeddedForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			switch (e.CloseReason)
			{
				case CloseReason.None:
					break;
				case CloseReason.WindowsShutDown:
					break;
				case CloseReason.MdiFormClosing:
				case CloseReason.UserClosing:
					if (DialogResult.OK == MessageBoxPlus.Show(this, "你确定要关闭应用程序吗？", "关闭提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
					{
						if (this.IsMdiContainer)
						{
							//----为保证Application.Exit();时不再弹出提示，所以将FormClosing事件取消
							this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.EmbeddedForm_FormClosing);
						}

						//---结束进程
						this.panelPlus_EmbeddedProcess.Stop();

						//---确认关闭事件
						e.Cancel = false;

						//---退出当前窗体
						this.Dispose();
					}
					else
					{
						//---取消关闭事件
						e.Cancel = true;
					}
					break;
				case CloseReason.TaskManagerClosing:
					break;
				case CloseReason.FormOwnerClosing:
					break;
				case CloseReason.ApplicationExitCall:
					break;
				default:
					break;
			}
		}

		#region 公有函数

		/// <summary>
		/// 
		/// </summary>
		/// <param name="exePath"></param>
		public void StartProcess(string exePath)
		{
			this._processPatch = exePath;
			this.panelPlus_EmbeddedProcess.EmbeddedProcess(exePath);
		}

		#endregion

		#endregion

	}
}
