
using Harry.LabEmbeddedProcess;
using Harry.LabUserControlPlus;
using Harry.LabUserGenFunc;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Harry.LabMainForm
{
    public partial class LabMdiForm : Form
    {

		#region 属性定义

		//private string 

		#endregion

		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public LabMdiForm()
        {
			InitializeComponent();
			//---窗体初始化
			this.StartUpInit();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="argForm"></param>
        public LabMdiForm(Form argForm)
        {
            InitializeComponent();
			//---窗体初始化
			this.StartUpInit();
		}

        #endregion

        #region 初始化

        /// <summary>
        /// 船体初始化函数
        /// </summary>
        private void StartUpInit()
        {
            //---事件注册
            this.FormClosing += new FormClosingEventHandler(this.MdiForm_FormClosing);

            //---退出操作
            this.ToolStripMenuItem_Exit.Click += new EventHandler(this.ToolStripMenuItem_Click);

			//---滴答定时
			this.timer_MdiFormSysTime.Tick += new EventHandler(this.Timer_Tick);

			//---调用计算器
			this.ToolStripMenuItem_Calc.Click += new EventHandler(this.ToolStripMenuItem_Click);
			//---调用并嵌套记事本应用
			this.ToolStripMenuItem_TXT.Click += new EventHandler(this.ToolStripMenuItem_Click);

		}

        #endregion

        #region 事件处理
		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MdiForm_FormClosing(object sender, FormClosingEventArgs e)
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
                            this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.MdiForm_FormClosing);
                        }

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

        
        /// <summary>
        /// 菜单单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsm = (ToolStripMenuItem)sender;
            tsm.Enabled = false;
			int i = 0;
			string exePatch = null;
			EmbeddedProcessForm txtForm = null;

			switch (tsm.Name)
            {
                //---退出操作
                case "ToolStripMenuItem_Exit":
                    if (DialogResult.OK == MessageBoxPlus.Show(this, "你确定要关闭应用程序吗？", "关闭提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                        if (this.IsMdiContainer)
                        {
                            //----为保证Application.Exit();时不再弹出提示，所以将FormClosing事件取消
                            this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.MdiForm_FormClosing);
                        }
                        
                        //---退出当前窗体
                        this.Dispose();
                    }
                    break;
                //---调用计算器，只能调用，不能嵌套
                case "ToolStripMenuItem_Calc":
					//System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
					//Info.FileName = "calc.exe ";//"calc.exe"为计算器，"notepad.exe"为记事本
					//System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
					for (i = 0; i < this.MdiChildren.Length; i++)
					{
						if (this.MdiChildren[i].Text == "计算器")
						{
							//---判断当前窗体是否处于最小化状态，
							if (this.MdiChildren[i].WindowState == FormWindowState.Minimized)
							{
								this.MdiChildren[i].WindowState = FormWindowState.Normal;
							}
							this.MdiChildren[i].Activate();
							return;
						}
					}
					exePatch = ExeFunc.GetExeNamePatch("calc.exe");
					//---检查应用是否存在
					if (exePatch == null)
					{
						exePatch = @"C:\Windows\system32\calc.exe";
					}
					//---将外部应用嵌套当前窗体
					if (txtForm == null)
					{
						txtForm = new EmbeddedProcessForm(exePatch, "计算器");
					}
					//EmbeddedProcessForm txtForm = new EmbeddedProcessForm(exePatch,"记事本");
					txtForm.MdiParent = this;
					txtForm.StartPosition = FormStartPosition.CenterScreen;
					txtForm.Show();
					txtForm.Focus();
					break;
                //---调用文本编辑器
                case "ToolStripMenuItem_TXT":

					for (i = 0; i < this.MdiChildren.Length; i++)
					{
						if (this.MdiChildren[i].Text == "记事本")
						{
							//---判断当前窗体是否处于最小化状态，
							if (this.MdiChildren[i].WindowState == FormWindowState.Minimized)
							{
								this.MdiChildren[i].WindowState = FormWindowState.Normal;
							}
							this.MdiChildren[i].Activate();
							return;
						}
					}
					exePatch = ExeFunc.GetExeNamePatch("notepad.exe");
					//---检查应用是否存在
					if (exePatch==null)
					{
						exePatch = @"C:\Windows\system32\notepad.exe";
					}
					//---将外部应用嵌套当前窗体
					if (txtForm == null)
					{
						txtForm = new EmbeddedProcessForm(exePatch, "记事本");
					}
					//EmbeddedProcessForm txtForm = new EmbeddedProcessForm(exePatch,"记事本");
					txtForm.MdiParent = this;
					txtForm.StartPosition = FormStartPosition.CenterScreen;
					txtForm.Show();
					txtForm.Focus();
					//txtForm.StartProcess(@"C:\Windows\system32\notepad.exe");
					break;
				default:
                    break;
            }
            tsm.Enabled = true;
        }

		/// <summary>
		/// 定时器事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Timer_Tick(object sender, System.EventArgs e)
		{
			Timer tt = (Timer)sender;
			string[] str = new string[] { };
			switch (tt.Tag.ToString())
			{
				case "timer_MdiFormSysTime":
					//str = this.ToolStripStatusLabel_SysTime.Text.Split('：');
					this.ToolStripStatusLabel_SysTime.Text = "系统时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")+"  "+System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
					break;
				default:
					break;
			}
		}

		#endregion

		#region 公共函数

		/// <summary>
		/// 加载语言
		/// </summary>
		/// <param name="language"></param>
		public void LoadLanguage(string language)
		{
			//---获取系统当前的语言格式
			string defaultLanguage = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
			if (defaultLanguage!= language)
			{
				System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
				this.Controls.Clear();
				InitializeComponent();
				this.StartUpInit();
			}
		}

		/// <summary>
		/// 加载语言
		/// </summary>
		public void LoadLanguage()
		{
			//---获取系统当前的语言格式
			string language = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
			System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
			this.Controls.Clear();
			InitializeComponent();
			this.StartUpInit();
		}

		#endregion


	}
}
