using Harry.LabUserControlPlus;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Harry.LabCOMMPort
{
	public partial class COMMSerialPortPlus : COMMBasePortPlus
	{
		#region 变量定义

		private bool defaultShowParamMenu=true;

		#endregion

		#region 属性定义

		/// <summary>
		/// 是否显示右键配置参数界面
		/// </summary>
		public virtual bool m_COMMShowParamMenu
		{
			get
			{
				return this.defaultShowParamMenu;
			}
			set
			{
				this.defaultShowParamMenu = value;
			}
		}


		#region 重载属性
		/// <summary>
		/// 窗体
		/// </summary>
		public override Form m_COMMForm
		{
			get
			{
				return base.m_COMMForm;
			}
			set
			{
				base.m_COMMForm = value;
			}
		}

		/// <summary>
		/// 消息
		/// </summary>
		public override RichTextBox m_COMMRichTextBox
		{
			get
			{
				return base.m_COMMRichTextBox;
			}
			set
			{
				base.m_COMMRichTextBox = value;
			}
		}

		/// <summary>
		/// 端口
		/// </summary>
		public override ComboBox m_COMMComboBox
		{
			get
			{
				return base.m_COMMComboBox;
			}
			set
			{
				base.m_COMMComboBox = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override COMMBasePort m_COMMPort
		{
			get
			{
				return base.m_COMMPort;
			}

			set
			{
				base.m_COMMPort = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override PictureBox m_PictureBoxCOMMState
		{
			get
			{
				return base.m_PictureBoxCOMMState;
			}
			set
			{
				base.m_PictureBoxCOMMState = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override Button m_ButtonCOMMInit
		{
			get
			{
				return base.m_ButtonCOMMInit;
			}
			set
			{
				base.m_ButtonCOMMInit = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override GroupBox m_GroupBoxCOMMName
		{
			get
			{
				return base.m_GroupBoxCOMMName;
			}
			set
			{ 
				base. m_GroupBoxCOMMName = value;
			}
		}

		/// <summary>
		/// 配置端口参数
		/// </summary>
		public virtual new COMMSerialPortParam m_COMMPortParam
		{
			get
			{
				COMMSerialPortParam _return = base.m_COMMPortParam as COMMSerialPortParam;
				if (_return == null)
				{
					_return = new COMMSerialPortParam(this.m_COMMComboBox.Text);
				}
				else
				{
					_return.defaultName = this.m_COMMComboBox.Text;
			
				}
				return _return;
			} 
			set
			{
				if (base.m_COMMPortParam == null)
				{
					base.m_COMMPortParam = new COMMSerialPortParam();
				}
				base.m_COMMPortParam = value;
			} 
		}

		/// <summary>
		/// 通讯端口的波特率
		/// </summary>
		public virtual int m_COMMPortBaudRate
		{
			get
			{
				return Convert.ToInt32(this.m_COMMPortParam.defaultBaudRate);
			}
			set
			{
				this.m_COMMPortParam.defaultBaudRate = value.ToString();
				//---检查端口是否打开
				if ((this.m_COMMPort!=null)&&(this.m_COMMPort.IsAttached())&&(this.m_COMMPort.m_COMMIndex!=0))
				{
					this.m_COMMPort.OpenDevice();
				}
			}
		}

		#endregion


		#endregion

		#region 构造函数
		/// <summary>
		/// 
		/// </summary>
		public COMMSerialPortPlus():base()
		{
			InitializeComponent();
			base.Init();
			this.AddEventHandler();

			//this.AddWatcherPortRemoveEvent();
		}
		/// <summary>
		/// 
		/// </summary>
		public COMMSerialPortPlus(Form argForm)
		{
			InitializeComponent();
			base.Init(argForm);
			this.AddEventHandler();

			//this.AddWatcherPortRemoveEvent();
		}
		/// <summary>
		/// 
		/// </summary>
		public COMMSerialPortPlus(RichTextBox argRichTextBox)
		{
			InitializeComponent();
			base.Init(argRichTextBox);
			this.AddEventHandler();

			//this.AddWatcherPortRemoveEvent();
		}

		/// <summary>
		/// 
		/// </summary>
		public COMMSerialPortPlus(Form argForm, RichTextBox argRichTextBox)
		{
			InitializeComponent();
			base.Init(argForm,argRichTextBox);
			this.AddEventHandler();

			//this.AddWatcherPortRemoveEvent();
		}

		/// <summary>
		/// 
		/// </summary>
		public COMMSerialPortPlus(Form argForm, COMMBasePort argCOMM, RichTextBox argRichTextBox)
		{ 
			InitializeComponent();
			this.Init(argForm, argCOMM,argRichTextBox);
			this.AddEventHandler();

			//this.AddWatcherPortRemoveEvent();
		}

		#endregion

		#region 函数定义

		#region 公共函数

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		/// <param name="argCOMM"></param>
		/// <param name="argComboBox"></param>
		/// <param name="argRichTextBox"></param>
		public override void Init(Form argForm, COMMBasePort argCOMM, RichTextBox argRichTextBox)
		{
			base.m_COMMForm = argForm;
			this.m_COMMPort = (COMMSerialPort)argCOMM;
			base.m_COMMRichTextBox = argRichTextBox;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		/// <param name="argCOMM"></param>
		/// <param name="argComboBox"></param>
		/// <param name="argRichTextBox"></param>
		public override void Init(Form argForm, COMMBasePort argCOMM, RichTextBox argRichTextBox, bool isRefreshDevice)
		{
			base.m_COMMForm = argForm;
			this.m_COMMPort = (COMMSerialPort)argCOMM;
			base.m_COMMRichTextBox = argRichTextBox;
			//---判断是否属性设备
			if (isRefreshDevice)
			{
				this.m_COMMPort.GetPortNames(this.m_COMMComboBox, argRichTextBox);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		/// <param name="argCOMM"></param>
		/// <param name="argRichTextBox"></param>
		/// <param name="isRefreshDevice"></param>
		/// <param name="isAddWatcherPort"></param>
		public override void Init(Form argForm, COMMBasePort argCOMM, RichTextBox argRichTextBox, bool isRefreshDevice, bool isAddWatcherPort)
		{
			base.m_COMMForm = argForm;
			this.m_COMMPort = (COMMSerialPort)argCOMM;
			base.m_COMMRichTextBox = argRichTextBox;
			//---判断是否属性设备
			if (isRefreshDevice == true)
			{
				if (this.m_COMMPort != null)
				{
					this.m_COMMPort.GetPortNames(this.m_COMMComboBox, argRichTextBox);
					this.m_COMMPort.m_COMMPortParam = new COMMSerialPortParam(this.m_COMMComboBox.Text);
				}
			}
			if (isAddWatcherPort == true)
			{
				//---注册端口监控
				base.AddWatcherPort();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void Button_Click(object sender, System.EventArgs e)
		{
			Button btn = (Button)sender;
			btn.Enabled = false;
			switch (btn.Name)
			{
				case "button_COMMInit":
					if (btn.Text == "打开设备")
					{
						this.OpenDevice();
					}
					else if (btn.Text == "关闭设备")
					{
						this.CloseDevice();
					}
					//else if (btn.Text == "配置设备")
					//{
					//	//---更新设备配置参数
					//}
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

		/*
		/// <summary>
		/// 设置参数
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void COMMSerialPortParam_Click(object sender, EventArgs e)
		{
			if ((this.m_COMMComboBox.Text!=null)&&(this.m_COMMComboBox.Items.Count>0))
			{
				COMMSerialPortParamForm p = new COMMSerialPortParamForm(this.m_COMMComboBox.Text);

				if (p.ShowDialog(this.m_COMMComboBox) != System.Windows.Forms.DialogResult.OK)
				{
					if (this.m_COMMRichTextBox != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.m_COMMRichTextBox, "通信端口参数配置失败。\r\n", Color.Red, false);
					}
					return;
				}

				this.m_COMMPortParam = ((COMMSerialPortParamForm) p).m_COMMPortParam;

				if (this.m_COMMRichTextBox!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.m_COMMRichTextBox, "通信端口参数配置成功。\r\n", Color.Black, false);
				}

				p.CloseForm();
			}
		}
		*/

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ComboBoxMouseDown_Click(object sender, MouseEventArgs e)
		{
			ComboBox cbb = (ComboBox)sender;
			int index = 0;
			switch (cbb.Name)
			{
				case "comboBox_COMMName":
					//---判断鼠标按下的按键
					if ((e.Button==MouseButtons.Right)&&(this.defaultShowParamMenu==true))
					{
						//---鼠标右键配置通信端口的参数
						this.ConfigCOMMSerialPortParam();
						//---判断是否端口发生了变化
						if (((this.comboBox_COMMName.Text!=string.Empty)||this.comboBox_COMMName.Text!="")&&((this.m_COMMPortParam.defaultName != string.Empty)||(this.m_COMMPortParam.defaultName!=""))&&(this.m_COMMPortParam.defaultName!=this.comboBox_COMMName.Text))
						{
							//---数据位
							index = this.comboBox_COMMName.Items.IndexOf(this.m_COMMPortParam.defaultName);
							if (index < 0)
							{
								this.comboBox_COMMName.SelectedIndex = 0;
							}
							else
							{
								this.comboBox_COMMName.SelectedIndex = index;
							}
						}
					}
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// 打开设备
		/// </summary>
		public virtual void OpenDevice()
		{
			//if ((this.commPort != null) &&(this.commPort.OpenDevice(this.comboBox_COMMName.Text, this.commRichTextBox) == 0))
			if ((this.m_COMMPort != null) && (this.m_COMMPort.OpenDevice(this.m_COMMPortParam, this.m_COMMRichTextBox) == 0))
			{
				this.m_ButtonCOMMInit.Text = "关闭设备";
				this.m_PictureBoxCOMMState.Image = Properties.Resources.open;

				//---消息显示
				if (this.m_COMMRichTextBox != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.m_COMMRichTextBox, "设备打开成功!\r\n",
						Color.Black, false);
				}
				if (this.m_COMMPort.m_OnCOMMSYNCEvent != null)
				{
					this.m_COMMPort.m_OnCOMMSYNCEvent();
				}

				this.COMMControl(false);

				//---加载设备移除处理
				if (this.m_COMMPort.m_OnRemoveDeviceEvent == null)
				{
					this.m_COMMPort.m_OnRemoveDeviceEvent = this.AddWatcherPortRemove;
				}
			}
			else
			{
				this.m_PictureBoxCOMMState.Image = Properties.Resources.error;
				if (this.m_COMMRichTextBox != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.m_COMMRichTextBox, "设备打开失败!\r\n",
						Color.Red, false);
				}
			}
		}

		/// <summary>
		/// 关闭设备
		/// </summary>
		public virtual void CloseDevice()
		{
			if (this.m_COMMPort != null)
			{
				this.m_COMMPort.CloseDevice();
				this.m_ButtonCOMMInit.Text = "打开设备";
				this.m_PictureBoxCOMMState.Image = Properties.Resources.lost;

				//---消息显示
				if (this.m_COMMRichTextBox != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.m_COMMRichTextBox, "设备关闭成功!\r\n",
						Color.Black, false);
				}
				if (this.m_COMMPort.m_OnCOMMSYNCEvent != null)
				{
					this.m_COMMPort.m_OnCOMMSYNCEvent();
				}
				this.COMMControl(true);
			}
		}

		/// <summary>
		/// 操作设备时发生的异常提示
		/// </summary>
		public virtual void ErrMsgDevice()
		{
			MessageBoxPlus.Show(this.m_COMMForm, "设备操作异常！错误操作：" + this.m_ButtonCOMMInit.Text, "错误提示");
		}

		#endregion

		#region 私有函数


		/// <summary>
		/// 添加时间处理函数
		/// </summary>
		private void AddEventHandler()
		{
			//---增加鼠标移动时间
			this.m_COMMComboBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComboBoxMouseDown_Click);
		}

		/// <summary>
		/// 配置通信端口的参数
		/// </summary>
		private void ConfigCOMMSerialPortParam()
		{
			if ((this.m_COMMComboBox.Text != null) && (this.m_COMMComboBox.Items.Count > 0))
			{
				COMMSerialPortParamForm p =new COMMSerialPortParamForm(this.m_COMMComboBox,this.m_COMMPortParam);// new COMMSerialPortParamForm(this.m_COMMComboBox.Text,this.m_COMMPortParam);

				if (p.ShowDialog(this.m_COMMComboBox) != System.Windows.Forms.DialogResult.OK)
				{
					if (this.m_COMMRichTextBox != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.m_COMMRichTextBox, "通信端口参数配置失败。\r\n", Color.Red, false);
					}
				}
				else
				{
					this.m_COMMPortParam = ((COMMSerialPortParamForm)p).m_COMMPortParam;

					if (this.m_COMMRichTextBox != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.m_COMMRichTextBox, "通信端口参数配置成功。\r\n", Color.Black, false);
					}

					p.CloseForm();
				}

			}
		}

		#endregion

		#endregion

	}
}
