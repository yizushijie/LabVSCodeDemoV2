using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Harry.LabCOMMPort;
using Harry.LabUserControlPlus;

namespace Harry.LabDigitalPower
{
	public partial class GPD3303Plus : COMMSerialPortPlus
	{
		#region 变量定义

		private GPD3303 defaultGPD3303 = null;

		#endregion

		#region 属性定义

		/// <summary>
		/// 通讯端口，使用的串口
		/// </summary>
		public override COMMBasePort m_COMM
		{
			get
			{
				return base.m_COMM;
			}
			set
			{
				if (base.m_COMM==null)
				{
					base.m_COMM = new COMMSerialPort();
				}
				base.m_COMM =value;
			}
		}

		/// <summary>
		/// GPD3303的属性为只读
		/// </summary>
		public virtual GPD3303 m_GPD3303
		{
			get
			{
				return this.defaultGPD3303;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual float m_CH1Voltage
		{
			get
			{
				return (float)this.numericUpDownPlus_CH1Voltage.Value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual float m_CH2Voltage
		{
			get
			{
				return (float)this.numericUpDownPlus_CH2Voltage.Value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override COMMPortParam m_COMMParam
		{
			get
			{
				return base.m_COMMParam;
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

		#endregion

		#region 构造函数

		/// <summary>
		/// 无参构造函数
		/// </summary>
		public GPD3303Plus():base()
		{
			InitializeComponent();
			this.StartUpInit();
		}

		/// <summary>
		/// 
		/// </summary>
		public GPD3303Plus(COMMBasePort commSerialPort  )
		{
			InitializeComponent();
			this.StartUpInit();

			this.m_COMM = (COMMSerialPort)commSerialPort;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="commSerialPort"></param>
		public GPD3303Plus(GPD3303 gpd3303, COMMBasePort commSerialPort)
		{
			InitializeComponent();
			this.StartUpInit();

			this.m_COMM = (COMMSerialPort)commSerialPort;
			if (this.defaultGPD3303==null)
			{
				this.defaultGPD3303 = new GPD3303();
			}
			this.defaultGPD3303 = gpd3303;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		/// <param name="argCOMM"></param>
		/// <param name="argRichTextBox"></param>
		/// <param name="isRefreshDevice"></param>
		/// <param name="isAddWatcherPort"></param>
		public GPD3303Plus(Form argForm, COMMBasePort argCOMM, RichTextBox argRichTextBox, bool isRefreshDevice, bool isAddWatcherPort)
		{
			InitializeComponent();
			this.StartUpInit();

			this.Init(argForm, argCOMM, argRichTextBox, isRefreshDevice, isAddWatcherPort);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="gpd3303"></param>
		/// <param name="argForm"></param>
		/// <param name="argCOMM"></param>
		/// <param name="argRichTextBox"></param>
		/// <param name="isRefreshDevice"></param>
		/// <param name="isAddWatcherPort"></param>
		public GPD3303Plus(GPD3303 gpd3303, Form argForm, COMMBasePort argCOMM, RichTextBox argRichTextBox, bool isRefreshDevice, bool isAddWatcherPort)
		{
			InitializeComponent();
			this.StartUpInit();

			if (this.defaultGPD3303 == null)
			{
				this.defaultGPD3303 = new GPD3303();
			}
			this.defaultGPD3303 = gpd3303;

			this.Init(argForm, argCOMM, argRichTextBox, isRefreshDevice, isAddWatcherPort);
		}

		#endregion

		#region 初始化

		/// <summary>
		/// 启动初始化
		/// </summary>
		private void StartUpInit()
		{
			//this.m_COMMShowParamMenu = false;

			this.button_ReadCH1.Enabled = false;
			this.button_ReadCH2.Enabled = false;
			this.button_WriteCH1.Enabled = false;
			this.button_WriteCH2.Enabled = false;

			this.comboBoxEx_CH1Mode.SelectedIndex = 0;
			this.comboBoxEx_CH2Mode.SelectedIndex = 0;

			this.button_ReadCH1.Click += new EventHandler(this.Button_Click);
			this.button_WriteCH1.Click += new EventHandler(this.Button_Click);

			this.button_ReadCH2.Click += new EventHandler(this.Button_Click);
			this.button_WriteCH2.Click += new EventHandler(this.Button_Click);


			this.comboBoxEx_CH1Mode.SelectedIndexChanged += new System.EventHandler(this.ComboBoxEx_SelectedIndexChanged);
			this.comboBoxEx_CH2Mode.SelectedIndexChanged += new System.EventHandler(this.ComboBoxEx_SelectedIndexChanged);

		}

		#endregion

		#region 事件定义

		/// <summary>
		/// 按钮处理事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void Button_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.Enabled = false;
			float uiVal = 0;
			switch (btn.Name)
			{
				//---端口初始化
				case "button_COMM":
					if (btn.Text == "打开设备")
					{
						this.OpenDevice();
					}
					else if (btn.Text == "关闭设备")
					{
						this.CloseDevice();
					}
					else
					{
						this.ErrMsgDevice();
					}
					break;
				//---读取通道1的数据
				case "button_ReadCH1":

					this.defaultGPD3303.GetChannelUI(this.comboBoxEx_CH1Mode.SelectedIndex,1,ref uiVal);

					if ((this.comboBoxEx_CH1Mode.SelectedIndex==0)||(this.comboBoxEx_CH1Mode.SelectedIndex==2))
					{
						this.numericUpDownPlus_CH1Voltage.Value = (decimal)uiVal;
					}
					else if ((this.comboBoxEx_CH1Mode.SelectedIndex == 1) || (this.comboBoxEx_CH1Mode.SelectedIndex == 3))
					{
						this.numericUpDownPlus_CH1Current.Value = (decimal)uiVal;
					}
					this.defaultGPD3303.GetFlagOutPutVoltage();
					break;
				//---写入通道1的数据
				case "button_WriteCH1":
					if (this.comboBoxEx_CH1Mode.SelectedIndex == 0 )
					{
						uiVal = (float)this.numericUpDownPlus_CH1Voltage.Value;
					}
					else if (this.comboBoxEx_CH1Mode.SelectedIndex == 1)
					{
						uiVal = (float)this.numericUpDownPlus_CH1Current.Value;
					}
					this.defaultGPD3303.SetChannelUI(this.comboBoxEx_CH1Mode.SelectedIndex, 1, uiVal);
					break;
				//---读取通道2的数据
				case "button_ReadCH2":
					this.defaultGPD3303.GetChannelUI(this.comboBoxEx_CH2Mode.SelectedIndex, 2, ref uiVal);

					if ((this.comboBoxEx_CH2Mode.SelectedIndex == 0) || (this.comboBoxEx_CH2Mode.SelectedIndex == 2))
					{
						this.numericUpDownPlus_CH2Voltage.Value = (decimal)uiVal;
					}
					else if ((this.comboBoxEx_CH2Mode.SelectedIndex == 1) || (this.comboBoxEx_CH2Mode.SelectedIndex == 3))
					{
						this.numericUpDownPlus_CH2Current.Value = (decimal)uiVal;
					}
					break;
				//---写入通道2的数据
				case "button_WriteCH2":
					if (this.comboBoxEx_CH2Mode.SelectedIndex == 0)
					{
						uiVal = (float)this.numericUpDownPlus_CH2Voltage.Value;
					}
					else if (this.comboBoxEx_CH2Mode.SelectedIndex == 1)
					{
						uiVal = (float)this.numericUpDownPlus_CH2Current.Value;
					}
					this.defaultGPD3303.SetChannelUI(this.comboBoxEx_CH2Mode.SelectedIndex, 2, uiVal);
					break;
				default:
					break;
			}
			btn.Enabled = true;
		}

		private void ComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cbb = (ComboBox)sender;
			cbb.Enabled = false;
			switch (cbb.Name)
			{
				case "comboBoxEx_CH1Mode":
					if ((cbb.Items[cbb.SelectedIndex].ToString() == "打开输出") || (cbb.Items[cbb.SelectedIndex].ToString() == "关闭输出"))
					{
						this.button_ReadCH1.Visible = false;
					}
					else
					{
						this.button_ReadCH1.Visible = true;
					}
					break;
				case "comboBoxEx_CH2Mode":
					if ((cbb.Items[cbb.SelectedIndex].ToString() == "打开输出") || (cbb.Items[cbb.SelectedIndex].ToString() == "关闭输出"))
					{
						this.button_ReadCH2.Visible = false;
					}
					else
					{
						this.button_ReadCH2.Visible = true;
					}
					break;
				default:
					break;
			}
			cbb.Enabled = true;
		}
		#endregion

		#region 私有函数

		#endregion

		#region 公共函数

		/// <summary>
		/// 
		/// </summary>
		/// <param name="isEnable"></param>
		public override void COMMControl(bool isEnable)
		{
			base.COMMControl(isEnable);

			//---状态和基类控件是相反
			this.button_ReadCH1.Enabled = !isEnable;
			this.button_ReadCH2.Enabled = !isEnable;
			this.button_WriteCH1.Enabled = !isEnable;
			this.button_WriteCH2.Enabled = !isEnable;

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
			base.Init(argForm, argCOMM, argRichTextBox, isRefreshDevice, isAddWatcherPort);
		}

		/// <summary>
		/// 打开设备
		/// </summary>
		public override void OpenDevice()
		{
			base.OpenDevice();
			if ((this.m_COMM!=null)&&(this.m_COMM.IsAttached()==true)&&(this.m_COMM.m_COMMIndex!=0))
			{
				if (this.defaultGPD3303==null)
				{
					this.defaultGPD3303 = new GPD3303((COMMSerialPort)this.m_COMM);
				}
				//---检验是否和数字电源通讯成功
				if(this.defaultGPD3303.Init()==false)
				{
					this.CloseDevice();
				}
			}
		}

		#endregion

		
	}
}
