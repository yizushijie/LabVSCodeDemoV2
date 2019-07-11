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

		/// <summary>
		/// 默认波特率集合的最大个数
		/// </summary>
		private int defaultSerialPortBaudRateMaxNum = 0;

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
		public override COMMBasePort m_COMM
		{
			get
			{
				return base.m_COMM;
			}

			set
			{
				base.m_COMM = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override PictureBox m_COMMPictureBox
		{
			get
			{
				return base.m_COMMPictureBox;
			}
			set
			{
				base.m_COMMPictureBox = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override Button m_COMMButton
		{
			get
			{
				return base.m_COMMButton;
			}
			set
			{
				base.m_COMMButton = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override GroupBox m_COMMGroupBox
		{
			get
			{
				return base.m_COMMGroupBox;
			}
			set
			{
				base.m_COMMGroupBox = value;
			}
		}

		/// <summary>
		/// 配置端口参数
		/// </summary>
		public virtual new COMMSerialPortParam m_COMMParam
		{
			get
			{
				COMMSerialPortParam _return = base.m_COMMParam as COMMSerialPortParam;
				if (_return == null)
				{
					_return = new COMMSerialPortParam(this.m_COMMComboBox.Text, this.comboBox_COMMBaudRate.Text, this.comboBox_COMMParity.Text, this.comboBox_COMMDataBits.Text, this.comboBox_COMMStopBits.Text);
				}
				else
				{
					_return.defaultName = this.m_COMMComboBox.Text;
					_return.defaultBaudRate = this.comboBox_COMMBaudRate.Text;
					_return.defaultParity = this.comboBox_COMMParity.Text;
					_return.defaultDataBits = this.comboBox_COMMDataBits.Text;
					_return.defaultStopBits = this.comboBox_COMMStopBits.Text;
				}
				return _return;
			}
			set
			{
				if (base.m_COMMParam == null)
				{
					base.m_COMMParam = new COMMSerialPortParam();
				}
				base.m_COMMParam = value;
			}
		}
		
		/// <summary>
		/// 配置波特率
		/// </summary>
		public virtual ComboBox m_COMMBaudRateComboBox
		{
			get
			{
				return this.comboBox_COMMBaudRate;
			}
			set
			{
				this.comboBox_COMMBaudRate = value;
			}
		}

		/// <summary>
		/// 配置数据位
		/// </summary>
		public virtual ComboBox m_COMMDataBitsComboBox
		{
			get
			{
				return this.comboBox_COMMDataBits;
			}
			set
			{
				this.comboBox_COMMDataBits = value;
			}
		}

		/// <summary>
		/// 配置停止位
		/// </summary>
		public virtual ComboBox m_COMMStopBitsComboBox
		{
			get
			{
				return this.comboBox_COMMStopBits;
			}
			set
			{
				this.comboBox_COMMStopBits = value;
			}
		}

		/// <summary>
		/// 配置校验
		/// </summary>
		public virtual ComboBox m_COMMParityComboBox
		{
			get
			{
				return this.comboBox_COMMParity;
			}
			set
			{
				this.comboBox_COMMParity = value;
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
			this.m_COMM = (COMMSerialPort)argCOMM;
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
			this.m_COMM = (COMMSerialPort)argCOMM;
			base.m_COMMRichTextBox = argRichTextBox;
			//---判断是否属性设备
			if (isRefreshDevice)
			{
				this.m_COMM.GetPortNames(this.m_COMMComboBox, argRichTextBox);
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
		public override void Init(Form argForm, COMMBasePort argCOMM, RichTextBox argRichTextBox, bool isRefreshDevice=true, bool isAddWatcherPort=true)
		{
			base.m_COMMForm = argForm;
			this.m_COMM = (COMMSerialPort)argCOMM;
			base.m_COMMRichTextBox = argRichTextBox;
			//---判断是否属性设备
			if (isRefreshDevice == true)
			{
				if (this.m_COMM != null)
				{
					this.m_COMM.GetPortNames(this.m_COMMComboBox, argRichTextBox);
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
			int index = this.comboBox_COMMBaudRate.Items.IndexOf(commSerialPortParam.defaultBaudRate);
			if (index<0)
			{
				this.comboBox_COMMBaudRate.SelectedIndex = 0;
				if (comboBox_COMMBaudRate.DropDownStyle != System.Windows.Forms.ComboBoxStyle.DropDown)
				{
					comboBox_COMMBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
				}
			}
			this.comboBox_COMMBaudRate.Text = commSerialPortParam.defaultBaudRate;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		public override void AddWatcherPortRemove(object sender, System.EventArgs e)
		{
			base.AddWatcherPortRemove(sender, e);

			base.RefreshComboBox(this.comboBox_COMMBaudRate);
			base.RefreshComboBox(this.comboBox_COMMDataBits);
			base.RefreshComboBox(this.comboBox_COMMStopBits);
			base.RefreshComboBox(this.comboBox_COMMParity);
		}

		/*

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
		*/

		/// <summary>
		/// 通信控件的状态
		/// </summary>
		/// <param name="isEnable"></param>
		public override void COMMControl(bool isEnable)
		{
			base.COMMControl(isEnable);
			this.comboBox_COMMBaudRate.Enabled = isEnable;
			this.comboBox_COMMDataBits.Enabled = isEnable;
			this.comboBox_COMMStopBits.Enabled = isEnable;
			this.comboBox_COMMParity.Enabled = isEnable;
		}

		/// <summary>
		/// 打开端口
		/// </summary>
		public override void OpenDevice()
		{
			//---更新端口参数
			this.m_COMMParam.Init(this.m_COMMComboBox.Text,
				this.comboBox_COMMBaudRate.Text, this.comboBox_COMMParity.Text,
				this.comboBox_COMMDataBits.Text, this.comboBox_COMMStopBits.Text);
			//---准备操作端口
			if ((this.m_COMM != null) &&
				(this.m_COMM.OpenDevice(this.m_COMMParam, this.m_COMMRichTextBox) == 0))
			{
				this.button_COMM.Text = "关闭设备";
				this.m_COMMPictureBox.Image = Properties.Resources.open;

				//---消息显示
				if (this.m_COMMRichTextBox != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.m_COMMRichTextBox, "设备打开成功!\r\n",
						Color.Black, false);
				}

				this.COMMControl(false);
				//---加载设备移除处理
				if (this.m_COMM.m_OnRemoveDeviceEvent == null)
				{
					this.m_COMM.m_OnRemoveDeviceEvent = this.AddWatcherPortRemove;
				}
			}
			else
			{
				this.m_COMMPictureBox.Image = Properties.Resources.error;
				if (this.m_COMMComboBox != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.m_COMMRichTextBox, "设备打开失败!\r\n",
						Color.Red, false);
				}
			}
		}

		/// <summary>
		/// 关闭端口
		/// </summary>
		public override void CloseDevice()
		{
			if (this.m_COMM != null)
			{
				this.m_COMM.CloseDevice();
				this.button_COMM.Text = "打开设备";
				this.m_COMMPictureBox.Image = Properties.Resources.lost;
				this.COMMControl(true);
				//---消息显示
				if (this.m_COMMRichTextBox != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.m_COMMRichTextBox, "设备关闭成功!\r\n",
						Color.Black, false);
				}
			}
		}

		/// <summary>
		/// 配置端口
		/// </summary>
		public override void ConfigDevice()
		{
			//---更新端口参数
			this.m_COMMParam.Init(this.m_COMMComboBox.Text,
				this.comboBox_COMMBaudRate.Text, this.comboBox_COMMParity.Text,
				this.comboBox_COMMDataBits.Text, this.comboBox_COMMStopBits.Text);
		}

		#endregion

		#region 私有函数

		/// <summary>
		/// 
		/// </summary>
		private void InitControl()
		{
			this.comboBox_COMMBaudRate.SelectedIndex = 7;
			this.comboBox_COMMDataBits.SelectedIndex = 0;
			this.comboBox_COMMStopBits.SelectedIndex = 0;
			this.comboBox_COMMParity.SelectedIndex = 0;

			if (this.m_COMMParam==null)
			{
				this.m_COMMParam = new COMMSerialPortParam(this.m_COMMComboBox.Text, this.comboBox_COMMBaudRate.Text, this.comboBox_COMMParity.Text, this.comboBox_COMMDataBits.Text, this.comboBox_COMMStopBits.Text);
			}
			else
			{
				this.m_COMMParam.Init(this.m_COMMComboBox.Text, this.comboBox_COMMBaudRate.Text, this.comboBox_COMMParity.Text, this.comboBox_COMMDataBits.Text, this.comboBox_COMMStopBits.Text);
			}

			this.comboBox_COMMBaudRate.SelectedIndexChanged += new EventHandler(this.ComboBox_SelectedIndexChanged);

			this.defaultSerialPortBaudRateMaxNum = this.comboBox_COMMBaudRate.Items.Count;

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
						if (this.m_COMMBaudRateComboBox.DropDownStyle != System.Windows.Forms.ComboBoxStyle.DropDown)
						{
							this.m_COMMBaudRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
						}
						cbb.SelectedValue = "";
						cbb.SelectedText = "";
						cbb.Text = "";

						//---判断是否添加了新数据，如果添加，去除新添加的数据
						if (cbb.Items.Count > this.defaultSerialPortBaudRateMaxNum)
						{
							cbb.Items.Remove(cbb.Items[cbb.Items.Count - 1]);
						}

					}
					else
					{
						if (this.m_COMMBaudRateComboBox.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
						{
							this.m_COMMBaudRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
						}
						if (this.m_COMMBaudRateComboBox.Items.IndexOf(cbb.Text)<0)
						{
							//---判断是否添加了新数据，如果添加，去除新添加的数据
							if (cbb.Items.Count > this.defaultSerialPortBaudRateMaxNum)
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
