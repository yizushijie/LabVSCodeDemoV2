using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Harry.LabUserControlPlus;
using System.Text.RegularExpressions;

namespace Harry.LabCOMMPort
{
	public partial class COMMSerialPortPlusFull : COMMBasePortPlus
	{
		#region 变量定义

		private int commSerialPortDefaultBaudRateMaxNum = 0;

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
				base.m_GroupBoxCOMMName = value;
			}
		}

		/// <summary>
		/// 配置端口参数
		/// </summary>
		public override COMMSerialPortParam m_COMMSerialPortParam
		{
			get
			{
				base.m_COMMSerialPortParam=new COMMSerialPortParam(this.m_COMMComboBox.Text, this.comboBox_COMMPortBaudRate.Text, this.comboBox_COMMPortParity.Text, this.comboBox_COMMPortDataBits.Text, this.comboBox_COMMPortStopBits.Text);
				return base.m_COMMSerialPortParam;
			}
			set
			{
				base.m_COMMSerialPortParam = value;
			}
		}

		/// <summary>
		/// 配置波特率
		/// </summary>
		public virtual ComboBox m_ComboBoxCOMMPortBaudRate
		{
			get
			{
				return this.comboBox_COMMPortBaudRate;
			}
			set
			{
				this.comboBox_COMMPortBaudRate = value;
			}
		}

		/// <summary>
		/// 配置数据位
		/// </summary>
		public virtual ComboBox m_ComboBoxCOMMPortDataBits
		{
			get
			{
				return this.comboBox_COMMPortDataBits;
			}
			set
			{
				this.comboBox_COMMPortDataBits = value;
			}
		}

		/// <summary>
		/// 配置停止位
		/// </summary>
		public virtual ComboBox m_ComboBoxCOMMPortStopBits
		{
			get
			{
				return this.comboBox_COMMPortStopBits;
			}
			set
			{
				this.comboBox_COMMPortStopBits = value;
			}
		}

		/// <summary>
		/// 配置校验
		/// </summary>
		public virtual ComboBox m_ComboBoxCOMMPortParity
		{
			get
			{
				return this.comboBox_COMMPortParity;
			}
			set
			{
				this.comboBox_COMMPortParity = value;
			}
		}

		#endregion

		#endregion

		#region 构造函数
		/// <summary>
		/// 
		/// </summary>
		public COMMSerialPortPlusFull():base()
		{
			InitializeComponent();
			this.InitControl();
			base.Init();
		}

		/// <summary>
		/// 
		/// </summary>
		public COMMSerialPortPlusFull(Form argForm)
		{
			InitializeComponent();
			this.InitControl();
			base.Init(argForm);
		}
		/// <summary>
		/// 
		/// </summary>
		public COMMSerialPortPlusFull(RichTextBox argRichTextBox)
		{
			InitializeComponent();
			this.InitControl();
			base.Init(argRichTextBox);
		}

		/// <summary>
		/// 
		/// </summary>
		public COMMSerialPortPlusFull(Form argForm, RichTextBox argRichTextBox)
		{
			InitializeComponent();
			this.InitControl();
			base.Init(argForm, argRichTextBox);
		}

		/// <summary>
		/// 
		/// </summary>
		public COMMSerialPortPlusFull(Form argForm, COMMBasePort argCOMM,  RichTextBox argRichTextBox)
		{
			InitializeComponent();
			this.InitControl();
			this.Init(argForm, argCOMM, argRichTextBox);
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
		/// 
		/// </summary>
		/// <param name="commSerialPortParam"></param>
		public void Init(COMMSerialPortParam commSerialPortParam)
		{
			if (commSerialPortParam==null)
			{
				return;
			}
			int index = this.comboBox_COMMPortBaudRate.Items.IndexOf(commSerialPortParam.baudRate);
			if (index<0)
			{
				this.comboBox_COMMPortBaudRate.SelectedIndex = 0;
				if (comboBox_COMMPortBaudRate.DropDownStyle != System.Windows.Forms.ComboBoxStyle.DropDown)
				{
					comboBox_COMMPortBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
				}
			}
			this.comboBox_COMMPortBaudRate.Text = commSerialPortParam.baudRate;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		public override void AddWatcherPortRemove(object sender, System.EventArgs e)
		{
			base.AddWatcherPortRemove(sender, e);

			base.RefreshComboBox(this.comboBox_COMMPortBaudRate);
			base.RefreshComboBox(this.comboBox_COMMPortDataBits);
			base.RefreshComboBox(this.comboBox_COMMPortStopBits);
			base.RefreshComboBox(this.comboBox_COMMPortParity);
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
						//---更新端口参数
						this.m_COMMSerialPortParam.Init(this.m_COMMComboBox.Text,
							this.comboBox_COMMPortBaudRate.Text, this.comboBox_COMMPortParity.Text,
							this.comboBox_COMMPortDataBits.Text, this.comboBox_COMMPortStopBits.Text);
						//---准备操作端口
						if ((this.m_COMMPort != null) &&
						    (this.m_COMMPort.OpenDevice(this.m_COMMSerialPortParam, this.m_COMMRichTextBox) == 0))
						{
							btn.Text = "关闭设备";
							this.m_PictureBoxCOMMState.Image = Properties.Resources.open;

							//---消息显示
							if (this.m_COMMRichTextBox != null)
							{
								RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.m_COMMRichTextBox, "设备打开成功!\r\n",
									Color.Black, false);
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
							if (this.m_COMMComboBox != null)
							{
								RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.m_COMMRichTextBox, "设备打开失败!\r\n",
									Color.Red, false);
							}
						}
					}
					else if (btn.Text == "关闭设备")
					{
						if (this.m_COMMPort != null)
						{
							this.m_COMMPort.CloseDevice();
							btn.Text = "打开设备";
							this.m_PictureBoxCOMMState.Image = Properties.Resources.lost;
							this.COMMControl(true);
							//---消息显示
							if (this.m_COMMRichTextBox != null)
							{
								RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.m_COMMRichTextBox, "设备关闭成功!\r\n",
									Color.Black, false);
							}
						}
					}
					else if (btn.Text == "配置设备")
					{
						//---更新端口参数
						this.m_COMMSerialPortParam.Init(this.m_COMMComboBox.Text,
							this.comboBox_COMMPortBaudRate.Text, this.comboBox_COMMPortParity.Text,
							this.comboBox_COMMPortDataBits.Text, this.comboBox_COMMPortStopBits.Text);
					}
					else
					{
						MessageBoxPlus.Show(this.m_COMMForm, "设备操作异常！错误操作：" + btn.Text, "错误提示");
					}
					
					break;

				default:
					break;
			}
			btn.Enabled = true;
		}
		
		/// <summary>
		/// 通信控件的状态
		/// </summary>
		/// <param name="isEnable"></param>
		public override void COMMControl(bool isEnable)
		{
			base.COMMControl(isEnable);
			this.comboBox_COMMPortBaudRate.Enabled = isEnable;
			this.comboBox_COMMPortDataBits.Enabled = isEnable;
			this.comboBox_COMMPortStopBits.Enabled = isEnable;
			this.comboBox_COMMPortParity.Enabled = isEnable;
		}

		#endregion

		#region 私有函数

		/// <summary>
		/// 
		/// </summary>
		private void InitControl()
		{
			this.comboBox_COMMPortBaudRate.SelectedIndex = 7;
			this.comboBox_COMMPortDataBits.SelectedIndex = 0;
			this.comboBox_COMMPortStopBits.SelectedIndex = 0;
			this.comboBox_COMMPortParity.SelectedIndex = 0;

			if (this.m_COMMSerialPortParam==null)
			{
				this.m_COMMSerialPortParam = new COMMSerialPortParam(this.m_COMMComboBox.Text, this.comboBox_COMMPortBaudRate.Text, this.comboBox_COMMPortParity.Text, this.comboBox_COMMPortDataBits.Text, this.comboBox_COMMPortStopBits.Text);
			}
			else
			{
				this.m_COMMSerialPortParam.Init(this.m_COMMComboBox.Text, this.comboBox_COMMPortBaudRate.Text, this.comboBox_COMMPortParity.Text, this.comboBox_COMMPortDataBits.Text, this.comboBox_COMMPortStopBits.Text);
			}

			this.comboBox_COMMPortBaudRate.SelectedIndexChanged += new EventHandler(this.ComboBox_SelectedIndexChanged);

			this.commSerialPortDefaultBaudRateMaxNum = this.comboBox_COMMPortBaudRate.Items.Count;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private  void ComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ComboBox cbb = (ComboBox)sender;
			switch (cbb.Name)
			{
				case "comboBox_COMMPortBaudRate":
					if (cbb.Text=="自定义")
					{
						if (this.m_ComboBoxCOMMPortBaudRate.DropDownStyle != System.Windows.Forms.ComboBoxStyle.DropDown)
						{
							this.m_ComboBoxCOMMPortBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
						}
						cbb.SelectedValue = "";
						cbb.SelectedText = "";
						cbb.Text = "";

						//---判断是否添加了新数据，如果添加，去除新添加的数据
						if (cbb.Items.Count > this.commSerialPortDefaultBaudRateMaxNum)
						{
							cbb.Items.Remove(cbb.Items[cbb.Items.Count - 1]);
						}

					}
					else
					{
						if (this.m_ComboBoxCOMMPortBaudRate.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
						{
							this.m_ComboBoxCOMMPortBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
						}
						if (this.m_ComboBoxCOMMPortBaudRate.Items.IndexOf(cbb.Text)<0)
						{
							//---判断是否添加了新数据，如果添加，去除新添加的数据
							if (cbb.Items.Count > this.commSerialPortDefaultBaudRateMaxNum)
							{
								cbb.Items.Remove(cbb.Items[cbb.Items.Count - 1]);
							}
						}
					}
					
					break;
				default:
					break;
			}
		}

		#endregion

		#endregion
	}
}
