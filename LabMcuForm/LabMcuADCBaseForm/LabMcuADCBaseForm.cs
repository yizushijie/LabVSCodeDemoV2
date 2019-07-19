using Harry.LabCOMMPort;
using Harry.LabMcuProject;
using Harry.LabUserControlPlus;
using Harry.LabUserGenFunc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

		/// <summary>
		/// 
		/// </summary>
		private bool defaultSTOP = false;

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
					this.defaultLabMcuDevice = new LabMcuBase( defaultDeviceCOMMPort);
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
					if (this.comboBoxEx_SelectADCVREFMode.SelectedIndex == 0)
					{
						if ((this.numericUpDownPlus_DigitalPowerChannel.Value == 0) || (this.numericUpDownPlus_DigitalPowerChannel.Value == 2))
						{
							this.defaultLabMcuDevice.m_ADCVREF = this.GPD3303Plus_DigitalPower.m_CH1Voltage;
						}
						else
						{
							this.defaultLabMcuDevice.m_ADCVREF = this.GPD3303Plus_DigitalPower.m_CH2Voltage;
						}
					}
					break;
				//---写入ADC的电压参考电压
				case "button_WriteADCVREFMode":
					this.defaultLabMcuDevice.ADC_WriteADCVREFMode(this.comboBoxEx_SelectADCVREFMode.SelectedIndex, this.richTextBoxEx_Msg);
					if (this.comboBoxEx_SelectADCVREFMode.SelectedIndex==0)
					{
						if ((this.numericUpDownPlus_DigitalPowerChannel.Value == 0) ||(this.numericUpDownPlus_DigitalPowerChannel.Value==2))
						{
							this.defaultLabMcuDevice.m_ADCVREF = this.GPD3303Plus_DigitalPower.m_CH1Voltage;
						}
						else
						{
							this.defaultLabMcuDevice.m_ADCVREF = this.GPD3303Plus_DigitalPower.m_CH2Voltage;
						}
					}
					break;
				case "button_ReadADCChannel":
					this.comboBoxEx_SelectADCChannel.SelectedIndex = this.defaultLabMcuDevice.ADC_ReadADCChannel(this.comboBoxEx_SelectADCVREFMode.Items.Count+ this.comboBoxEx_SelectADCChannel.SelectedIndex, this.richTextBoxEx_Msg);
					break;
				case "button_WriteADCChannel":
					this.defaultLabMcuDevice.ADC_WriteADCChannel(this.comboBoxEx_SelectADCVREFMode.Items.Count + this.comboBoxEx_SelectADCChannel.SelectedIndex, this.richTextBoxEx_Msg);
					break;
				case "button_ReadADCSampleNum":
					this.numericUpDownPlus_SampleNum.Value = (decimal)(this.defaultLabMcuDevice.ADC_ReadADCSampleNum((this.comboBoxEx_SelectADCVREFMode.Items.Count+this.m_ComboBoxSelectADCChannel.Items.Count),this.richTextBoxEx_Msg));
					break;
				case "button_WriteADCSampleNum":
					this.defaultLabMcuDevice.ADC_WriteADCSampleNum((this.comboBoxEx_SelectADCVREFMode.Items.Count + this.m_ComboBoxSelectADCChannel.Items.Count), (int)this.numericUpDownPlus_SampleNum.Value, this.richTextBoxEx_Msg);
					break;
				case "button_DoADCFunc":
					//---配置VREF
					if (this.comboBoxEx_SelectADCVREFMode.SelectedIndex == 0)
					{
						if ((this.numericUpDownPlus_DigitalPowerChannel.Value == 0) || (this.numericUpDownPlus_DigitalPowerChannel.Value == 2))
						{
							this.defaultLabMcuDevice.m_ADCVREF = this.GPD3303Plus_DigitalPower.m_CH1Voltage;
						}
						else
						{
							this.defaultLabMcuDevice.m_ADCVREF = this.GPD3303Plus_DigitalPower.m_CH2Voltage;
						}
					}
					//---功能执行操作
					if ((int)(this.numericUpDownPlus_DigitalPowerChannel.Value) == 0)
					{
						this.defaultLabMcuDevice.ADC_ReadADCResult(this.richTextBoxEx_Msg);
					}
					else
					{
						this.DoADCScanFunc();
					}
					break;
				case "button_STOPFunc":
					this.defaultSTOP = true;
					break;
				default:
					break;
			}
			btn.Enabled = true;
		}
		

		/// <summary>
		/// NumericUpDown控件的值发生变化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void NumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown nun = (NumericUpDown)sender;
			switch (nun.Name)
			{
				case "numericUpDownPlus_DigitalPowerChannel":
					if ((int)(this.numericUpDownPlus_DigitalPowerChannel.Value)==0)
					{
						this.button_DoADCFunc.Text = "读取ADC";
						this.button_STOPFunc.Visible = false;
					}
					else
					{
						this.button_DoADCFunc.Text = "开始扫描";
						this.button_STOPFunc.Visible = true;
					}
					break;
				default:
					break;
			}
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


		/// <summary>
		/// 执行电压扫描选项
		/// </summary>
		public virtual void DoADCScanFunc()
		{
			//---起始电压
			int startMV =(int) this.numericUpDownPlus_StartPower.Value;
			//---步进电压电压
			int stepMV = (int)this.numericUpDownPlus_StepPower.Value;
			//---终止电压
			int stopMV = (int)this.numericUpDownPlus_StopPower.Value;
			int i;//= 0;
			this.defaultSTOP = false;
			float setVoltage;
			//---通道电压归零
			this.GPD3303Plus_DigitalPower.m_GPD3303.SetChannelDefaultVoltage((int)this.numericUpDownPlus_DigitalPowerChannel.Value, 0);
			for ( i = startMV; i <=stopMV; i+=stepMV)
			{
				//---设置通道电压
				this.GPD3303Plus_DigitalPower.m_GPD3303.SetChannelDefaultVoltage((int)this.numericUpDownPlus_DigitalPowerChannel.Value, i,"MV");
				if (i==startMV)
				{
					DelayFunc.DelayFuncDelayms(700);
				}
				else
				{
					DelayFunc.DelayFuncDelayms(200);
				}
				setVoltage = i * 1.0F;
				setVoltage /= (float)1000.0;
				//---读取ADC的结果
				this.defaultLabMcuDevice.ADC_ReadADCResult(null);
				if (i==startMV)
				{
					RichTextBoxPlus.AppendTextInfoWithDataTime(this.richTextBoxEx_Msg, "ADC通道选择：" + this.defaultLabMcuDevice.m_ADCChannel[this.defaultLabMcuDevice.m_ADCChannelIndex] +
																						";采样次数是" + this.defaultLabMcuDevice.m_ADCSampleNum.ToString() + "\r\n", Color.Black, false);
					RichTextBoxPlus.AppendTextInfoWithDataTime(this.richTextBoxEx_Msg, "\r\n采样电压值: V" +
																						";数字量是：" +
																						";模拟量是：" + "V\r\n", Color.Black, false);
				}
				RichTextBoxPlus.AppendTextInfoWithoutDataTime(this.richTextBoxEx_Msg,	setVoltage.ToString("f4")+
																					";" + this.defaultLabMcuDevice.m_ADCResult.defaultADCResult[0].ToString() +
																					";" + this.defaultLabMcuDevice.m_ADCResult.defaultPowerResult[0].ToString("f4") + "\r\n", Color.Black, false);
				//---检查退出操作指令
				if (this.defaultSTOP==true)
				{
					break;
				}
			}
			//---通道电压归零
			this.GPD3303Plus_DigitalPower.m_GPD3303.SetChannelDefaultVoltage((int)this.numericUpDownPlus_DigitalPowerChannel.Value, 0);
		}



		#endregion

		#region 私有函数

		/// <summary>
		/// 
		/// </summary>
		private void StartUpInit()
		{

			this.commSerialPortPlus_Device.m_COMMBaudRate = 9600;

			//---注册端口同步事件
			this.defaultDeviceCOMMPort.m_OnCOMMSYNCEvent = new COMMBasePort.COMMSYNCEventHandler(this.SYNCCOMMPortEvent);

			this.commSerialPortPlus_Device.Init(this, this.defaultDeviceCOMMPort, this.richTextBoxEx_Msg, true, true);
			this.GPD3303Plus_DigitalPower.Init(this, this.defaultDigitalPowerCOMMPort, this.richTextBoxEx_Msg, true, true);

			if (this.defaultLabMcuDevice==null)
			{
				this.defaultLabMcuDevice = new LabMcuBase( this.defaultDeviceCOMMPort);
			}
			else
			{
				this.defaultLabMcuDevice.m_COMMPort = this.defaultDeviceCOMMPort;
			}

			if ((int)(this.numericUpDownPlus_DigitalPowerChannel.Value) == 0)
			{
				this.button_DoADCFunc.Text = "读取ADC";
				this.button_STOPFunc.Visible = false;
			}
			else
			{
				this.button_DoADCFunc.Text = "开始扫描";
				this.button_STOPFunc.Visible = true;
			}

			this.button_ReadADCVREFMode.Click += new EventHandler(this.Button_Click);
			this.button_WriteADCVREFMode.Click += new EventHandler(this.Button_Click);
			this.button_ReadADCChannel.Click += new EventHandler(this.Button_Click);
			this.button_WriteADCChannel.Click += new EventHandler(this.Button_Click);
			this.button_ReadADCSampleNum.Click += new EventHandler(this.Button_Click);
			this.button_WriteADCSampleNum.Click += new EventHandler(this.Button_Click);
			this.button_DoADCFunc.Click += new EventHandler(this.Button_Click);
			this.button_STOPFunc.Click += new EventHandler(this.Button_Click);

			this.numericUpDownPlus_DigitalPowerChannel.ValueChanged += new EventHandler(this.NumericUpDown_ValueChanged);

			//---注册窗体关闭事件
			this.FormClosing += new FormClosingEventHandler(this.Form_FormClosing);


			this.ControlInit();

			this.SizeChanged += new EventHandler(this.Form_SizeChanged);

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
			if (this.InvokeRequired)
			{
				this.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 this.FormControl(this.defaultDeviceCOMMPort.IsAttached());
								 }));
			}
			else
			{

				this.FormControl(this.defaultDeviceCOMMPort.IsAttached());
			}
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


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form_FormClosing(object sender, FormClosingEventArgs e)
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
							this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
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



		#endregion

		#region 窗体自适应大小

		private float defaultWidth=0.0F;
		private float defaultHeight=0.0F;
		private bool defaultSize = false;

		/// <summary>
		/// 
		/// </summary>
		private void ControlInit()
		{
			this.defaultWidth = this.Width;
			this.defaultHeight = this.Height;
			this.defaultSize = false;
			this.ControlTag(this);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cons"></param>
		private void ControlTag(Control cons)
		{
			foreach (Control con in cons.Controls)
			{
				con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
				if (con.Controls.Count > 0)
				{
					ControlTag(con);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="newWidth"></param>
		/// <param name="newHeight"></param>
		/// <param name="cons"></param>
		private void ControlResize(float newWidth, float newHeight, Control cons)
		{
			foreach (Control con in cons.Controls)
			{
				string[] myControlTag = con.Tag.ToString().Split(new char[] { ':' });
				float a = Convert.ToSingle(myControlTag[0]) * newWidth;
				con.Width = (int)a;
				a = Convert.ToSingle(myControlTag[1]) * newHeight;
				con.Height = (int)a;
				a = Convert.ToSingle(myControlTag[2]) * newWidth;
				con.Left = (int)a;
				a = Convert.ToSingle(myControlTag[3]) * newHeight;
				con.Top = (int)a;
				Single currentsize = Convert.ToSingle(myControlTag[4]) * Math.Min(newWidth, newHeight);
				con.Font = new Font(con.Font.Name, currentsize, con.Font.Style, con.Font.Unit);
				if (con.Controls.Count > 0)
				{
					this.ControlResize(newWidth, newHeight, con);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form_SizeChanged(object sender, EventArgs e)
		{
			if (this.defaultSize==false)
			{
				this.defaultSize = true;
				return;
			}
			float newWidth = (this.Width) / this.defaultWidth;
			float newHeight = (this.Height) / this.defaultHeight;
			this.ControlResize(newWidth, newHeight, this);
			//this.Text = this.Width.ToString() + "" + this.Height.ToString();
		}

		#endregion

	}
}
