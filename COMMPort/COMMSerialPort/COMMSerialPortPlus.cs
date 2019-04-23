using Harry.LabUserControlPlus;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Harry.LabCOMMPort
{
	public partial class COMMSerialPortPlus : COMMBasePortPlus
	{
		#region 变量定义
		
		#endregion

		#region 属性定义


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
		public override COMMSerialPortParam m_COMMSerialPortParam
		{
			get
			{
				return base.m_COMMSerialPortParam;
			} 
			set
			{
				base.m_COMMSerialPortParam = value;
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
				}
			}
			if (isAddWatcherPort == true)
			{
				//---注册端口监控
				base.AddWatcherPort();
			}
		}

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

				this.m_COMMSerialPortParam = ((COMMSerialPortParamForm) p).m_COMMSerialPortParam;

				if (this.m_COMMRichTextBox!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.m_COMMRichTextBox, "通信端口参数配置成功。\r\n", Color.Black, false);
				}

				p.CloseForm();
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ComboBoxMouseDown_Click(object sender, MouseEventArgs e)
		{
			ComboBox cbb = (ComboBox)sender;
			switch (cbb.Name)
			{
				case "comboBox_COMMName":
					//---判断鼠标按下的按键
					if (e.Button==MouseButtons.Right)
					{
						//---鼠标右键配置通信端口的参数
						this.SetCOMMSerialPortParam();
					}
					break;
				default:
					break;
			}
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
		/// 设置通信端口的参数
		/// </summary>
		private void SetCOMMSerialPortParam()
		{
			if ((this.m_COMMComboBox.Text != null) && (this.m_COMMComboBox.Items.Count > 0))
			{
				COMMSerialPortParamForm p = new COMMSerialPortParamForm(this.m_COMMComboBox.Text,this.m_COMMSerialPortParam);

				if (p.ShowDialog(this.m_COMMComboBox) != System.Windows.Forms.DialogResult.OK)
				{
					if (this.m_COMMRichTextBox != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.m_COMMRichTextBox, "通信端口参数配置失败。\r\n", Color.Red, false);
					}
				}
				else
				{
					this.m_COMMSerialPortParam = ((COMMSerialPortParamForm)p).m_COMMSerialPortParam;

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
