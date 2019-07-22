using Harry.LabCOMMPort;
using Harry.LabExcelFile;
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
using System.Windows.Forms;

namespace Harry.LabMcuForm
{
	public partial class LabMcuOSCBaseForm : Form
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
		/// 使用的Excel
		/// </summary>
		private ExcelFile defaultExcel = null;

		/// <summary>
		/// Excel的状态
		/// </summary>
		private bool defaultExcelFlag = false;

		/// <summary>
		/// 
		/// </summary>
		private bool defaultSTOP = false;

		/// <summary>
		/// 
		/// </summary>
		private ControlAutoSize defaultSutoSize = null;

		#endregion

		#region 属性定义

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public LabMcuOSCBaseForm()
		{
			InitializeComponent();
			StartUpInit();
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
			switch (btn.Name)
			{
				case "button_DoOSCFunc":
					//---功能执行操作
					if ((int)(this.numericUpDownPlus_DigitalPowerChannel.Value) == 0)
					{
						this.defaultLabMcuDevice.OSC_ReadOSCResult(this.richTextBoxEx_Msg);
					}
					else if ((int)(this.numericUpDownPlus_DigitalPowerChannel.Value) == 3)
					{
						this.DoOSCDefaultFunc();
					}
					else
					{
						this.DoOSCScanFunc();
					}
					break;
				case "button_STOPFunc":
					this.defaultSTOP = true;
					break;
				case "button_OpenExcel":
					if (this.defaultExcel == null)
					{
						this.defaultExcel = new ExcelFile();
					}
					this.defaultExcel.OpenExcel();
					break;
				case "button_SelectExcel":
					if (this.defaultExcel != null)
					{
						this.textBox_ExcelPath.Text = this.defaultExcel.SelectWorkBook();
						this.defaultExcelFlag = true;
					}
					else
					{
						this.defaultExcelFlag = false;
					}
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
					if ((int)(this.numericUpDownPlus_DigitalPowerChannel.Value) == 0)
					{
						this.button_DoOSCFunc.Text = "读取OSC";
						this.button_STOPFunc.Visible = false;
					}
					else if((int)(this.numericUpDownPlus_DigitalPowerChannel.Value) == 3)
					{
						this.button_DoOSCFunc.Text = "固定扫描";
						this.button_STOPFunc.Visible = true;
						this.richTextBoxEx_Msg.Clear();
						this.richTextBoxEx_Msg.Text = "固定电压点是\t" + 1.8.ToString("F2") + "V\t" + 3.0.ToString("F2") + "V\t" + 3.3.ToString("F2") + "V\t" + 5.0.ToString("F2") + "V\r\n";
						this.richTextBoxEx_Msg.Text += "数字电源选择通道" + 2.ToString()+"\r\n";
					}
					else
					{
						this.button_DoOSCFunc.Text = "开始扫描";
						this.button_STOPFunc.Visible = true;
					}
					break;
				default:
					break;
			}
		}

		public virtual void Init()
		{

		}

		public virtual void DoOSCDefaultFunc()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void DoOSCScanFunc()
		{
			//---起始电压
			int startMV = (int)this.numericUpDownPlus_StartPower.Value;
			//---步进电压电压
			int stepMV = (int)this.numericUpDownPlus_StepPower.Value;
			//---终止电压
			int stopMV = (int)this.numericUpDownPlus_StopPower.Value;
			int i;//= 0;
			this.defaultSTOP = false;
			int excelIndex = 0;
			float setVoltage;
			//---通道电压归零
			this.GPD3303Plus_DigitalPower.m_GPD3303.DisableOutPutVoltage();
			for (i = startMV; i <= stopMV; i += stepMV)
			{
				this.GPD3303Plus_DigitalPower.m_GPD3303.DisableOutPutVoltage();
				//---设置通道电压
				this.GPD3303Plus_DigitalPower.m_GPD3303.SetChannelDefaultVoltage((int)this.numericUpDownPlus_DigitalPowerChannel.Value, i, "MV");
				if (i == startMV)
				{
					DelayFunc.DelayFuncDelayms(700);
				}
				else
				{
					DelayFunc.DelayFuncDelayms(200);
				}

				//---使能输出
				this.GPD3303Plus_DigitalPower.m_GPD3303.EnableOutPutVoltage();
				//---等待稳定
				DelayFunc.DelayFuncDelayms(500);

				setVoltage = i * 1.0F;
				setVoltage /= (float)1000.0;
				//---读取OSC的结果
				this.defaultLabMcuDevice.OSC_ReadOSCResult(null);
				if (i == startMV)
				{
					RichTextBoxPlus.AppendTextInfoWithDataTime(this.richTextBoxEx_Msg,  "电源输出: V" +
																						";OSC频率是：" + "KHz\r\n", Color.Black, false);
				}
				RichTextBoxPlus.AppendTextInfoWithoutDataTime(this.richTextBoxEx_Msg, setVoltage.ToString("f4") +
																					";" + this.defaultLabMcuDevice.m_OSCKHz.ToString("F2") + "\r\n", Color.Black, false);

				if ((this.defaultExcel != null) && (this.defaultExcelFlag == true))
				{
					this.defaultExcel.SaveResult(excelIndex, 0, setVoltage);
					this.defaultExcel.SaveResult(excelIndex, 1, this.defaultLabMcuDevice.m_OSCKHz);
				}
				excelIndex++;
				//---检查退出操作指令
				if (this.defaultSTOP == true)
				{
					break;
				}
			}
			//---通道电压归零
			this.GPD3303Plus_DigitalPower.m_GPD3303.DisableOutPutVoltage() ;
		}

		#endregion

		#region 私有函数
		/// <summary>
		/// 
		/// </summary>
		private void StartUpInit()
		{

			//this.commSerialPortPlus_Device.m_COMMBaudRate = 115200;

			//---注册端口同步事件
			this.defaultDeviceCOMMPort.m_OnEventCOMMYNC = new COMMBasePort.EventCOMMSYNC(this.SYNCCOMMPortEvent);

			this.commSerialPortPlus_Device.Init(this, this.defaultDeviceCOMMPort, this.richTextBoxEx_Msg, true, true);
			this.GPD3303Plus_DigitalPower.Init(this, this.defaultDigitalPowerCOMMPort, this.richTextBoxEx_Msg, true, true);

			if (this.defaultLabMcuDevice == null)
			{
				this.defaultLabMcuDevice = new LabMcuBase(this.defaultDeviceCOMMPort);
			}
			else
			{
				this.defaultLabMcuDevice.m_COMMPort = this.defaultDeviceCOMMPort;
			}

			if ((int)(this.numericUpDownPlus_DigitalPowerChannel.Value) == 0)
			{
				this.button_DoOSCFunc.Text = "读取ADC";
				this.button_STOPFunc.Visible = false;
			}
			else
			{
				this.button_DoOSCFunc.Text = "开始扫描";
				this.button_STOPFunc.Visible = true;
			}
			
			this.button_DoOSCFunc.Click += new EventHandler(this.Button_Click);
			this.button_STOPFunc.Click += new EventHandler(this.Button_Click);

			this.button_OpenExcel.Click += new EventHandler(this.Button_Click);
			this.button_SelectExcel.Click += new EventHandler(this.Button_Click);

			this.numericUpDownPlus_DigitalPowerChannel.ValueChanged += new EventHandler(this.NumericUpDown_ValueChanged);

			//---注册窗体关闭事件
			this.FormClosing += new FormClosingEventHandler(this.Form_FormClosing);

			if (this.defaultSutoSize == null)
			{
				this.defaultSutoSize = new ControlAutoSize(this);
			}
			else
			{
				this.defaultSutoSize.ControlInit(this);
			}
			//this.ControlInit();

			this.SizeChanged += new EventHandler(this.Form_SizeChanged);

			
			//this.Init();

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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form_SizeChanged(object sender, EventArgs e)
		{
			if (this.defaultSutoSize != null)
			{
				this.defaultSutoSize.AutoResize(this);
			}
		}

		#endregion
	}
}
