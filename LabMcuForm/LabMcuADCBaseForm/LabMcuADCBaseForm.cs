using Harry.LabCOMMPort;
using Harry.LabMcuProject;
using Harry.LabUserControlPlus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabMcuForm
{
	public partial class LabMcuADCBaseForm : Form
	{
		#region 变量定义

		/// <summary>
		/// 测试设备使用的通讯端口
		/// </summary>
		private COMMBasePort defaultDeviceCOMMPort = new COMMSerialPort();

		/// <summary>
		/// 数字电源使用的通讯端口
		/// </summary>
		private COMMBasePort defaultDigitalPowerCOMMPort = new COMMSerialPort();

		/// <summary>
		/// MCU设备
		/// </summary>
		private LabMcuBase defaultLabMcuDevice = null;

		#endregion

		#region 属性定义

		/// <summary>
		/// 
		/// </summary>
		public virtual COMMBasePort m_DeviceCOMMPort
		{
			get
			{
				return this.defaultDeviceCOMMPort;
			}
			set
			{
				if (this.defaultDeviceCOMMPort==null)
				{
					this.defaultDeviceCOMMPort = new COMMBasePort();
				}
				this.defaultDeviceCOMMPort = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual COMMBasePort m_DigitalPowerCOMMPort
		{
			get
			{
				return this.defaultDigitalPowerCOMMPort;
			}
			set
			{
				if (this.defaultDigitalPowerCOMMPort==null)
				{
					this.defaultDigitalPowerCOMMPort = new COMMBasePort();
				}
				this.defaultDigitalPowerCOMMPort = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual LabMcuBase m_LabMcuDevice
		{
			get
			{
				return this.defaultLabMcuDevice;
			}
			set
			{
				if (this.defaultLabMcuDevice==null)
				{
					this.defaultLabMcuDevice = new LabMcuBase(ref defaultDeviceCOMMPort);
				}
				this.defaultLabMcuDevice = value;
			}
		}

		/// <summary>
		/// 起始电压值
		/// </summary>
		[Description("电压扫描起始电压值"), Category("自定义属性")]
		public virtual float m_StartPower
		{
			get
			{
				return (float) this.numericUpDownPlus_StartPower.Value;
			}
			set
			{
				this.numericUpDownPlus_StartPower.Value = (decimal)value;
			}
		}

		/// <summary>
		/// 步进电压值
		/// </summary>
		[Description("电压扫描步进电压值"), Category("自定义属性")]
		public virtual float m_StepPower
		{
			get
			{
				return (float)this.numericUpDownPlus_StepPower.Value;
			}
			set
			{
				this.numericUpDownPlus_StepPower.Value = (decimal)value;
			}
		}

		/// <summary>
		/// 步进电压值
		/// </summary>
		[Description("电压扫描终止电压值"), Category("自定义属性")]
		public virtual float m_StopPower
		{
			get
			{
				return (float)this.numericUpDownPlus_StopPower.Value;
			}
			set
			{
				this.numericUpDownPlus_StopPower.Value = (decimal)value;
			}
		}

		/// <summary>
		/// 数字电源的控制通道
		/// </summary>
		[Description("数字电源的控制通道"), Category("自定义属性")]
		public virtual int m_DigitalPowerChannel
		{
			get
			{
				return (int)this.numericUpDownPlus_DigitalPowerChannel.Value;
			}
			set
			{
				this.numericUpDownPlus_DigitalPowerChannel.Value = (decimal)value;
			}
		}

		/// <summary>
		/// 显示消息的船体
		/// </summary>
		[Description("消息显示的窗体控件"), Category("自定义属性")]
		public virtual RichTextBox m_RichTextBoxMsg
		{
			get
			{
				return this.richTextBoxEx_Msg;
			}
			set
			{
				this.richTextBoxEx_Msg = (RichTextBoxEx)value;
			}
		}

		/// <summary>
		/// 选择ADC的参考电压的模式
		/// </summary>
		[Description("选择ADC的参考"), Category("自定义属性")]
		public virtual ComboBox m_ComboBoxSelectADCVREFMode
		{
			get
			{
				return this.comboBoxEx_SelectADCVREFMode;
			}
			set
			{
				this.comboBoxEx_SelectADCVREFMode =(ComboBoxEx)value;
			}
		}

		/// <summary>
		/// 选择ADC的参考电压的模式
		/// </summary>
		[Description("选择ADC的通道"), Category("自定义属性")]
		public virtual ComboBox m_ComboBoxSelectADCChannel
		{
			get
			{
				return this.comboBoxEx_SelectADCChannel;
			}
			set
			{
				this.comboBoxEx_SelectADCChannel = (ComboBoxEx)value;
			}
		}

		#endregion

		#region 构造函数
		public LabMcuADCBaseForm()
		{
			InitializeComponent();

			this.StartUpInit();
		}

		#endregion

		#region 公共函数

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void Button_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.Enabled = false;
			//if (this.defaultLabMcuDevice.m_COMMPort != this.defaultDeviceCOMMPort)
			//{
			//	this.defaultLabMcuDevice.m_COMMPort = this.defaultDeviceCOMMPort;
			//}
			switch (btn.Name)
			{
				//---读取ADC的电压参考电压
				case "button_ReadADCVREFMode":
					this.comboBoxEx_SelectADCVREFMode.SelectedIndex = this.defaultLabMcuDevice.ADC_ReadADCVREFMode(this.comboBoxEx_SelectADCVREFMode.SelectedIndex, this.richTextBoxEx_Msg);
					break;
				//---写入ADC的电压参考电压
				case "button_WriteADCVREFMode":
					this.defaultLabMcuDevice.ADC_WriteADCVREFMode(this.comboBoxEx_SelectADCVREFMode.SelectedIndex, this.richTextBoxEx_Msg);
					break;
				case "button_ReadADCChannel":
					this.comboBoxEx_SelectADCChannel.SelectedIndex = this.defaultLabMcuDevice.ADC_ReadADCChannel(0, this.richTextBoxEx_Msg);
					break;
				case "button_WriteADCChannel":
					this.defaultLabMcuDevice.ADC_WriteADCChannel(this.comboBoxEx_SelectADCChannel.SelectedIndex, this.richTextBoxEx_Msg);
					break;
				case "button_ReadADCSampleNum":
					this.numericUpDownPlus_SampleNum.Value = (decimal)(this.defaultLabMcuDevice.ADC_ReadADCSampleNum((this.comboBoxEx_SelectADCVREFMode.Items.Count+this.m_ComboBoxSelectADCChannel.Items.Count),this.richTextBoxEx_Msg));
					break;
				case "button_WriteADCSampleNum":
					this.defaultLabMcuDevice.ADC_WriteADCSampleNum((this.comboBoxEx_SelectADCVREFMode.Items.Count + this.m_ComboBoxSelectADCChannel.Items.Count), (int)this.numericUpDownPlus_SampleNum.Value, this.richTextBoxEx_Msg);
					break;
				case "button_DoADCFunc":
					this.Button_DoADCFunc((float)this.numericUpDownPlus_StartPower.Value, (float)this.numericUpDownPlus_StepPower.Value, (float)this.numericUpDownPlus_StopPower.Value);
					break;
				default:
					break;
			}
			btn.Enabled = true;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual int Button_DoADCFunc(float startMV,float stepMV,float stopMV)
		{
			int _return = -1;
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void Init()
		{

			this.comboBoxEx_SelectADCChannel.Items.Clear();
			this.comboBoxEx_SelectADCVREFMode.Items.Clear();

			if ((this.defaultLabMcuDevice!=null)&&(this.defaultLabMcuDevice.m_ADCVREFMode.Length>1))
			{
				this.comboBoxEx_SelectADCVREFMode.Items.AddRange(this.defaultLabMcuDevice.m_ADCVREFMode);
				this.comboBoxEx_SelectADCVREFMode.SelectedIndex = 0;
			}

			if ((this.defaultLabMcuDevice != null) && (this.defaultLabMcuDevice.m_ADCChannel.Length > 1))
			{
				this.comboBoxEx_SelectADCChannel.Items.AddRange(this.defaultLabMcuDevice.m_ADCChannel);
				this.comboBoxEx_SelectADCChannel.SelectedIndex = 0;
			}
		}

		#endregion

		#region 私有函数

		/// <summary>
		/// 
		/// </summary>
		private void StartUpInit()
		{

			this.commSerialPortPlus_Device.m_COMMPortBaudRate = 9600;

			//---注册端口同步事件
			this.defaultDeviceCOMMPort.m_OnCOMMSYNCEvent = new COMMBasePort.COMMSYNCEventHandler(this.SYNCCOMMPortEvent);

			this.commSerialPortPlus_Device.Init(this, this.defaultDeviceCOMMPort, this.richTextBoxEx_Msg, true, true);
			this.GPD3303Plus_DigitalPower.Init(this, this.defaultDigitalPowerCOMMPort, this.richTextBoxEx_Msg, true, true);

			if (this.defaultLabMcuDevice==null)
			{
				this.defaultLabMcuDevice = new LabMcuBase(ref this.defaultDeviceCOMMPort);
			}
			else
			{
				this.defaultLabMcuDevice.m_COMMPort = this.defaultDeviceCOMMPort;
			}

			this.button_ReadADCVREFMode.Click += new EventHandler(this.Button_Click);
			this.button_WriteADCVREFMode.Click += new EventHandler(this.Button_Click);
			this.button_ReadADCChannel.Click += new EventHandler(this.Button_Click);
			this.button_WriteADCChannel.Click += new EventHandler(this.Button_Click);
			this.button_ReadADCSampleNum.Click += new EventHandler(this.Button_Click);
			this.button_WriteADCSampleNum.Click += new EventHandler(this.Button_Click);
			this.button_DoADCFunc.Click += new EventHandler(this.Button_Click);

			this.Init();

			this.FormControl(false);
		}

		/// <summary>
		/// 端口同步事件
		/// </summary>
		private void SYNCCOMMPortEvent()
		{
			if (this.defaultLabMcuDevice.m_COMMPort != this.defaultDeviceCOMMPort)
			{
				this.defaultLabMcuDevice.m_COMMPort = this.defaultDeviceCOMMPort;
			}

			this.FormControl(this.defaultDeviceCOMMPort.IsAttached());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="isEnable"></param>
		/// <returns></returns>
		private void FormControl(bool isEnable)
		{
			this.button_DoADCFunc.Enabled = isEnable;
			this.button_ReadADCChannel.Enabled = isEnable;
			this.button_ReadADCSampleNum.Enabled = isEnable;
			this.button_ReadADCVREFMode.Enabled = isEnable;
			this.button_WriteADCChannel.Enabled = isEnable;
			this.button_WriteADCSampleNum.Enabled = isEnable;
			this.button_WriteADCVREFMode.Enabled = isEnable;
		}

		#endregion

	}
}
