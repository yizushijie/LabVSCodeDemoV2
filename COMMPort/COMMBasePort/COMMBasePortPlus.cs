using Harry.LabUserControlPlus;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Harry.LabCOMMPort
{
	public partial class COMMBasePortPlus : UserControl,IDisposable
    {
		#region 变量定义

		/// <summary>
		/// 窗体
		/// </summary>
		private Form defaultForm = null;

		/// <summary>
		/// 消息
		/// </summary>
		private RichTextBox defaultRichTextBox = null;

		/// <summary>
		/// 端口
		/// </summary>
		private COMMBasePort defaultCOMM = null;

		/// <summary>
		/// 端口的配置参数
		/// </summary>
		private COMMPortParam defaultCOMMParam = new COMMPortParam();


		#endregion

		#region 属性定义

		/// <summary>
		/// 
		/// </summary>
		public virtual Form m_COMMForm
		{
			get
			{
				return this.defaultForm;
			}
			set
			{
				if (this.defaultForm==null)
				{
					this.defaultForm = new Form();
				}
				this.defaultForm = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual RichTextBox m_COMMRichTextBox
		{
			get
			{
				return this.defaultRichTextBox;
			}
			set
			{
				if (this.defaultRichTextBox == null)
				{
					this.defaultRichTextBox = new RichTextBox();
				}
				this.defaultRichTextBox = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual ComboBox m_COMMComboBox
		{
			get
			{
				return this.comboBox_COMM;
			}
			set
			{
				if (value != null)
				{
					this.comboBox_COMM = value;
				}
			}
		}

		/// <summary>
		/// 端口
		/// </summary>
		public virtual COMMBasePort m_COMM
		{
			get
			{
				return this.defaultCOMM;
			}
			set
			{
				if (this.defaultCOMM == null)
				{
					this.defaultCOMM = new COMMBasePort();
				}
				this.defaultCOMM = value;
			}
		}

		/// <summary>
		/// 状态图片
		/// </summary>
		public virtual PictureBox m_COMMPictureBox
		{
			get
			{
				return this.pictureBox_COMM;
			}
			set
			{
				this.pictureBox_COMM=value;
			}
		}

		/// <summary>
		/// 设备初始化按钮
		/// </summary>
		public virtual Button m_COMMButton
		{
			get
			{
				return this.button_COMM;
			}
			set
			{
				this.button_COMM = value;
			}
		}

		public virtual GroupBox m_COMMGroupBox
		{
			get
			{
				return this.groupBox_COMM;
			}
			set
			{
				this.groupBox_COMM = value;

			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual COMMPortParam m_COMMParam
		{
			get
			{
				return this.defaultCOMMParam;
			}
			set
			{
				if (this.defaultCOMMParam == null)
				{
					this.defaultCOMMParam = new COMMPortParam();
				}
				this.defaultCOMMParam = value;
			}
		}

		#endregion

		#region 构造函数
		/// <summary>
		/// 
		/// </summary>
		public COMMBasePortPlus()
		{
			InitializeComponent();
			this.Init();
			this.AddEventHandler();
		}
		/// <summary>
		/// 
		/// </summary>
		public COMMBasePortPlus(Form argForm)
		{
			InitializeComponent();
			this.Init(argForm);
			this.AddEventHandler();
		}
		/// <summary>
		/// 
		/// </summary>
		public COMMBasePortPlus(RichTextBox argRichTextBox)
		{
			InitializeComponent();
			this.Init(argRichTextBox);
			this.AddEventHandler();
		}

		public COMMBasePortPlus(Form argForm, RichTextBox argRichTextBox)
		{
			InitializeComponent();
			this.Init(argForm, argRichTextBox);
			this.AddEventHandler();
		}

		/// <summary>
		/// 
		/// </summary>
		public COMMBasePortPlus(Form argForm, COMMBasePort argCOMM, RichTextBox argRichTextBox)
		{
			InitializeComponent();
			this.Init(argForm, argCOMM, argRichTextBox);
			this.AddEventHandler();
		}

		#endregion

		#region 函数定义

		/// <summary>
		/// 
		/// </summary>
		public virtual void Init()
		{
			this.defaultForm = null;
			this.defaultRichTextBox = null;
			this.defaultCOMM = null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		public virtual void Init(Form argForm)
		{
			this.defaultForm = argForm;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="argComboBox"></param>
		/// <param name="argRichTextBox"></param>
		public virtual void Init(RichTextBox argRichTextBox)
		{
			this.defaultRichTextBox = argRichTextBox;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		/// <param name="argComboBox"></param>
		/// <param name="argRichTextBox"></param>
		public virtual void Init(Form argForm,RichTextBox argRichTextBox)
		{
			this.defaultForm = argForm;
			this.defaultRichTextBox = argRichTextBox;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		/// <param name="argCOMM"></param>
		/// <param name="argComboBox"></param>
		/// <param name="argRichTextBox"></param>
		public virtual void Init(Form argForm, COMMBasePort argCOMM,RichTextBox argRichTextBox)
		{
			this.defaultForm = argForm;
			this.defaultCOMM = argCOMM;
			this.defaultRichTextBox = argRichTextBox;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		/// <param name="argCOMM"></param>
		/// <param name="argRichTextBox"></param>
		public virtual void Init(Form argForm, COMMBasePort argCOMM, RichTextBox argRichTextBox, bool isRefreshDevice)
		{
			this.defaultForm = argForm;
			this.defaultCOMM = argCOMM;
			this.defaultRichTextBox = argRichTextBox;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		/// <param name="argCOMM"></param>
		/// <param name="argRichTextBox"></param>
		/// <param name="isRefreshDevice"></param>
		/// <param name="isAddWatcherPort"></param>
		public virtual void Init(Form argForm, COMMBasePort argCOMM, RichTextBox argRichTextBox, bool isRefreshDevice=true,bool isAddWatcherPort=true)
		{
			this.m_COMMForm = argForm;
			this.defaultCOMM = argCOMM;
			this.m_COMMRichTextBox = argRichTextBox;
		}

		/// <summary>
		/// 添加端口监控
		/// </summary>
		public virtual void AddWatcherPort()
		{
			if (this.defaultCOMM != null)
			{
				if (this.defaultForm!=null)
				{
					this.defaultCOMM.AddWatcherPort(this.comboBox_COMM, this.defaultRichTextBox);
				}
				else
				{
					this.defaultCOMM.AddWatcherPort(this.defaultForm,this.comboBox_COMM, this.defaultRichTextBox);
				}
			}
		}


		/// <summary>
		/// 监控端口的移除处理函数
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void AddWatcherPortRemove(object sender, System.EventArgs e)
		{
			if ((this.defaultCOMM.IsAttached() == false) && (this.button_COMM.Text == "关闭设备"))
			{
				if (this.button_COMM.InvokeRequired)
				{
					this.button_COMM.BeginInvoke((EventHandler)
						//this.m_Button_COMMInit.Invoke((EventHandler)
						(delegate
						{
							this.button_COMM.Text = "打开设备";
						}));
				}
				else
				{
					this.button_COMM.Text = "打开设备";
				}
				//---执行端口关闭
				this.defaultCOMM.CloseDevice();
				//---刷新端口的只是ICO图标
				if (this.pictureBox_COMM.InvokeRequired)
				{
					this.pictureBox_COMM.BeginInvoke((EventHandler)
						//this.m_PictureBox_COMMState.Invoke((EventHandler)
						(delegate
						{
							this.pictureBox_COMM.Image = Properties.Resources.lost;
						}));
				}
				else
				{
					this.pictureBox_COMM.Image = Properties.Resources.lost;
				}

				//---执行端口同步函数
				this.defaultCOMM.m_OnEventCOMMYNC?.Invoke();

				this.RefreshComboBox(this.comboBox_COMM);
			}
		}

		/// <summary>
		/// 添加端口移除事件函数
		/// </summary>
		public virtual void AddWatcherPortRemoveEvent()
		{
			if (this.defaultCOMM != null)
			{
				this.defaultCOMM.m_OnEventDeviceRemoved = AddWatcherPortRemove;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void Button_Click(object sender, System.EventArgs e)
		{
			Button btn = (Button)sender;
			btn.Enabled = false;
			switch (btn.Name)
			{
				case "button_COMM":
					if (btn.Text == "打开设备")
					{
						this.OpenDevice();
					}
					else if (btn.Text == "关闭设备")
					{
						this.CloseDevice();
					}
					else if (btn.Text == "配置设备")
					{
						this.ConfigDevice();
					}
					else
					{
						this.ErrMsgDevice();
					}
					break;

				default:
					break;
			}
			btn.Enabled = true;
		}

		/// <summary>
		/// 图片单击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void PictureBox_Click(object sender, System.EventArgs e)
		{
			PictureBox ptb = (PictureBox)sender;
			ptb.Enabled = false;
			switch (ptb.Name)
			{
				case "pictureBox_COMM":
					if (this.button_COMM.Text == "打开设备")
					{
						if (this.defaultCOMM!=null)
						{
							//---刷新设备
							this.defaultCOMM.RefreshDevice(this.comboBox_COMM, this.defaultRichTextBox);
						}
					}
					break;
				default:
					break;
			}
			ptb.Enabled = true;
		}

		/// <summary>
		/// 刷新控件
		/// </summary>
		/// <param name="isEnable"></param>
		public virtual void COMMControl(bool isEnable)
		{
			this.comboBox_COMM.Enabled = isEnable;
		}

		/// <summary>
		/// 刷新控件
		/// </summary>
		/// <param name="cbb"></param>
		public virtual void RefreshComboBox(ComboBox cbb)
		{
			//---控件使能
			if (cbb.InvokeRequired)
			{
				cbb.BeginInvoke((EventHandler)
					//this.m_Button_COMMInit.Invoke((EventHandler)
					(delegate
					{
						if (cbb.Enabled == false)
						{
							cbb.Enabled = true;
						}
					}));
			}
			else
			{
				if (cbb.Enabled == false)
				{
					cbb.Enabled = true;
				}
			}
		}

		/// <summary>
		/// 刷新控件
		/// </summary>
		/// <param name="cbb"></param>
		public virtual void RefreshComboBox(ComboBox cbb,bool isEnable)
		{
			//---控件使能
			if (cbb.InvokeRequired)
			{
				cbb.BeginInvoke((EventHandler)
					//this.m_Button_COMMInit.Invoke((EventHandler)
					(delegate
					{
						cbb.Enabled = isEnable;
					}));
			}
			else
			{
				cbb.Enabled = isEnable;
			}
		}

		/// <summary>
		/// 打开端口
		/// </summary>
		public virtual void OpenDevice()
		{

		}


		/// <summary>
		/// 关闭端口
		/// </summary>
		public virtual void CloseDevice()
		{

		}

		/// <summary>
		/// 配置设备
		/// </summary>
		public virtual void ConfigDevice()
		{

		}

		/// <summary>
		/// 错误信息
		/// </summary>
		public virtual void ErrMsgDevice()
		{
			MessageBoxPlus.Show(this.m_COMMForm, "设备操作异常！错误操作：" + this.m_COMMButton.Text, "错误提示");
		}

		#endregion

		#region 私有函数

		private void AddEventHandler()
		{
			//---button 点击事件
			this.button_COMM.Click += new System.EventHandler(this.Button_Click);
			//---端口状态刷新事件
			this.pictureBox_COMM.Click += new EventHandler(this.PictureBox_Click);
			//---端口移除事件
			this.AddWatcherPortRemoveEvent();
		}

		#endregion
	}
}
