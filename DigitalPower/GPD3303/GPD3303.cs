﻿using Harry.LabCOMMPort;
using Harry.LabUserControlPlus;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Harry.LabDigitalPower
{
	public partial  class GPD3303
	{
		#region 变量定义

		/// <summary>
		/// 最大输出电压30V
		/// </summary>
		private float defaultMaxVoltage =(float) 30.00;

		/// <summary>
		/// 最大输出电流3A
		/// </summary>
		private float defaultMaxCurrent = (float)3.00;

		/// <summary>
		/// 通讯端口
		/// </summary>
		private COMMSerialPort defaultCOMMPort = null;

		/// <summary>
		/// 定义延时等待时间
		/// </summary>
		private int defaultDelayTime = 200;

		#endregion

		#region 属性定义

		/// <summary>
		/// 通讯端口属性为读写
		/// </summary>
		public virtual COMMSerialPort m_COMMPort
		{
			get
			{
				return this.defaultCOMMPort;
			}
			set
			{
				if (this.defaultCOMMPort==null)
				{
					this.defaultCOMMPort = new COMMSerialPort();
				}
				this.defaultCOMMPort = value;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public  GPD3303()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="usePort"></param>
		public GPD3303(COMMSerialPort usePort,int delayTime=200)
		{
			this.m_COMMPort = usePort;
			this.defaultDelayTime = delayTime;
		}

		#endregion

		#region 公共函数

		/// <summary>
		/// 初始化，查找设备的通讯波特率
		/// </summary>
		public virtual bool Init()
		{
			int baud = this.AutoGetCOMMBaudRate();
			if (baud>=0)
			{
				this.SetCOMMBaudRate(0); 
				//---设置波特率为115200
				this.m_COMMPort.m_COMMSerialPort.BaudRate = 115200;
				this.m_COMMPort.m_COMMPortParam.defaultBaudRate =115200.ToString();
			}
			else
			{
				MessageBoxPlus.Show(this.m_COMMPort.m_COMMForm,"GPD3303电源通信控制失败!\r\n","错误提示",MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		/// <summary>
		/// 设置通道输出的电压值
		/// </summary>
		/// <param name="channel"></param>
		/// <param name="voltage"></param>
		/// <returns></returns>
		public virtual bool SetChannelDefaultVoltage(int channel, float voltage,string unite="V")
		{
			if (unite=="mV")
			{
				voltage /= (float)1000.0;
			}
			else if (unite=="uV")
			{
				voltage/= (float)100000.0;
			}
			if (voltage >30.00)
			{
				voltage = this.defaultMaxVoltage;
			}
			string cmd = string.Format("VSET{0}:{1:f3}\r\n", channel, voltage);
			if ((this.m_COMMPort!=null)&&(this.m_COMMPort.IsAttached()==true))
			{
				this.m_COMMPort.m_COMMSerialPort.Write(cmd);
				Thread.Sleep(this.defaultDelayTime);
			}
			else
			{
				MessageBoxPlus.Show(this.m_COMMPort.m_COMMForm, "GPD3303电源通信异常!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		/// <summary>
		/// 读取通道输出的电压值
		/// </summary>
		/// <param name="channel"></param>
		/// <param name="voltage"></param>
		/// <param name="unite"></param>
		/// <returns></returns>
		public virtual bool GetChannelDefaultVoltage(int channel, ref float voltage,  string unite = "V")
		{
			string cmd = string.Format("VSET{0}?\r\n", channel);
			if ((this.m_COMMPort != null) && (this.m_COMMPort.IsAttached() == true))
			{
				this.m_COMMPort.m_COMMSerialPort.Write(cmd);
				Thread.Sleep(this.defaultDelayTime);
				if (this.m_COMMPort.m_COMMSerialPort.BytesToRead >= 2)
				{
					cmd = this.m_COMMPort.m_COMMSerialPort.ReadExisting();
					string[] res = cmd.Split('V');
					if ((res==null)||(res.Length<2))
					{
						MessageBoxPlus.Show(this.m_COMMPort.m_COMMForm, "读取通道"+channel.ToString()+"电压值失败!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return false;
					}
					voltage = Convert.ToSingle(res[0]);
				}
			}
			else
			{
				MessageBoxPlus.Show(this.m_COMMPort.m_COMMForm, "GPD3303电源通信异常!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (unite == "mV")
			{
				voltage *= (float)1000.0;
			}
			else if (unite == "uV")
			{
				voltage *= (float)100000.0;
			}
			if (voltage > 30.00)
			{
				voltage = this.defaultMaxVoltage;
			}
			return true;
		}

		/// <summary>
		/// 读取通道实际输出的电压值
		/// </summary>
		/// <param name="channel"></param>
		/// <param name="voltage"></param>
		/// <param name="unite"></param>
		/// <returns></returns>
		public virtual bool GetChannelActionVoltage(int channel, ref float voltage, string unite = "V")
		{
			//---获取通道实际实际输出的电压值
			string cmd = string.Format("VOUT{0}?\r\n", channel);
			if ((this.m_COMMPort != null) && (this.m_COMMPort.IsAttached() == true))
			{
				this.m_COMMPort.m_COMMSerialPort.Write(cmd);
				Thread.Sleep(this.defaultDelayTime);
				if (this.m_COMMPort.m_COMMSerialPort.BytesToRead >= 2)
				{
					cmd = this.m_COMMPort.m_COMMSerialPort.ReadExisting();
					string[] res = cmd.Split('V');
					if ((res == null) || (res.Length < 2))
					{
						MessageBoxPlus.Show(this.m_COMMPort.m_COMMForm, "读取通道" + channel.ToString() + "电压值失败!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return false;
					}
					voltage = Convert.ToSingle(res[0]);
				}
			}
			else
			{
				MessageBoxPlus.Show(this.m_COMMPort.m_COMMForm, "GPD3303电源通信异常!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (unite == "mV")
			{
				voltage *= (float)1000.0;
			}
			else if (unite == "uV")
			{
				voltage *= (float)100000.0;
			}
			if (voltage > 30.00)
			{
				voltage = this.defaultMaxVoltage;
			}
			return true;
		}

		/// <summary>
		/// 读取通道输出的电压值
		/// </summary>
		/// <param name="channel"></param>
		/// <param name="current"></param>
		/// <param name="unite"></param>
		/// <returns></returns>
		public virtual bool SetChannelDefaultCurrent(int channel, float current, string unite = "A")
		{
			if (unite == "mA")
			{
				current /= (float)1000.0;
			}
			else if (unite == "uA")
			{
				current /= (float)100000.0;
			}
			if (current > 3.00)
			{
				current = this.defaultMaxCurrent;
			}
			string cmd = string.Format("ISET{0}:{1:f3}\r\n", channel, current);
			if ((this.m_COMMPort != null) && (this.m_COMMPort.IsAttached() == true))
			{
				this.m_COMMPort.m_COMMSerialPort.Write(cmd);
				Thread.Sleep(this.defaultDelayTime);
			}
			else
			{
				MessageBoxPlus.Show(this.m_COMMPort.m_COMMForm, "GPD3303电源通信异常!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		/// <summary>
		/// 读取通道输出的电压值
		/// </summary>
		/// <param name="channel"></param>
		/// <param name="current"></param>
		/// <param name="unite"></param>
		/// <returns></returns>
		public virtual bool GetChannelDefaultCurrent(int channel, ref float current, string unite = "A")
		{
			string cmd = string.Format("ISET{0}?\r\n", channel);
			if ((this.m_COMMPort != null) && (this.m_COMMPort.IsAttached() == true))
			{
				this.m_COMMPort.m_COMMSerialPort.Write(cmd);
				Thread.Sleep(this.defaultDelayTime);
				if (this.m_COMMPort.m_COMMSerialPort.BytesToRead >= 2)
				{
					cmd = this.m_COMMPort.m_COMMSerialPort.ReadExisting();
					string[] res = cmd.Split('A');
					if ((res == null) || (res.Length < 2))
					{
						MessageBoxPlus.Show(this.m_COMMPort.m_COMMForm, "读取通道" + channel.ToString() + "电流失败!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return false;
					}
					current = Convert.ToSingle(res[0]);
				}
			}
			else
			{
				MessageBoxPlus.Show(this.m_COMMPort.m_COMMForm, "GPD3303电源通信异常!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (unite == "mA")
			{
				current *= (float)1000.0;
			}
			else if (unite == "uA")
			{
				current *= (float)100000.0;
			}
			if (current > 3.00)
			{
				current = this.defaultMaxCurrent;
			}
			return true;
		}

		/// <summary>
		/// 读取通道实际输出的电流值
		/// </summary>
		/// <param name="channel"></param>
		/// <param name="voltage"></param>
		/// <param name="unite"></param>
		/// <returns></returns>
		public virtual bool GetChannelActionCurrent(int channel, ref float current, string unite = "V")
		{
			string cmd = string.Format("IOUT{0}?\r\n", channel);
			if ((this.m_COMMPort != null) && (this.m_COMMPort.IsAttached() == true))
			{
				this.m_COMMPort.m_COMMSerialPort.Write(cmd);
				Thread.Sleep(this.defaultDelayTime);
				if (this.m_COMMPort.m_COMMSerialPort.BytesToRead >= 2)
				{
					cmd = this.m_COMMPort.m_COMMSerialPort.ReadExisting();
					string[] res = cmd.Split('A');
					if ((res == null) || (res.Length < 2))
					{
						MessageBoxPlus.Show(this.m_COMMPort.m_COMMForm, "读取通道" + channel.ToString() + "电流失败!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return false;
					}
					current = Convert.ToSingle(res[0]);
				}
			}
			else
			{
				MessageBoxPlus.Show(this.m_COMMPort.m_COMMForm, "GPD3303电源通信异常!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (unite == "mA")
			{
				current *= (float)1000.0;
			}
			else if (unite == "uA")
			{
				current *= (float)100000.0;
			}
			if (current > 3.00)
			{
				current = this.defaultMaxCurrent;
			}
			return true;
		}

		/// <summary>
		/// 获取通道当前的电压和电流
		/// </summary>
		/// <param name="isU"></param>
		/// <param name="channel"></param>
		/// <param name="uiVal"></param>
		/// <param name="unite"></param>
		/// <returns></returns>
		public virtual bool GetChannelUI(int isDefault, int channel, ref float uiVal)
		{
			if (isDefault == 0)
			{
				return this.GetChannelDefaultVoltage(channel, ref uiVal, "V");
			}
			else if (isDefault == 1)
			{
				return this.GetChannelDefaultCurrent(channel, ref uiVal, "A");
			}
			else if(isDefault==2)
			{
				return this.GetChannelActionVoltage(channel, ref uiVal, "V");
			}
			else if (isDefault == 3)
			{
				return this.GetChannelActionCurrent(channel, ref uiVal, "A");
			}
			else if((isDefault==4)||(isDefault==5))
			{
				return this.GetFlagOutPutVoltage();
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 设置通道当前的电压和电流
		/// </summary>
		/// <param name="isU"></param>
		/// <param name="channel"></param>
		/// <param name="voltage"></param>
		/// <param name="unite"></param>
		/// <returns></returns>
		public virtual bool SetChannelUI(int isDefault, int channel, float uiVal)
		{
			if (isDefault == 0)
			{
				return this.SetChannelDefaultVoltage(channel,  uiVal, "V");
			}
			else if (isDefault == 1)
			{
				return this.SetChannelDefaultCurrent(channel,  uiVal, "A");
			}
			else if (isDefault == 4)
			{
				return this.EnableOutPutVoltage();
			}
			else if (isDefault == 5)
			{
				return this.DisableOutPutVoltage();
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 使能电压输出
		/// </summary>
		/// <returns></returns>
		public virtual bool EnableOutPutVoltage()
		{
			string cmd = string.Format("OUT{0}\r\n", 1);
			if ((this.m_COMMPort != null) && (this.m_COMMPort.IsAttached() == true))
			{
				this.m_COMMPort.m_COMMSerialPort.Write(cmd);
				Thread.Sleep(this.defaultDelayTime);
			}
			else
			{
				MessageBoxPlus.Show(this.m_COMMPort.m_COMMForm, "GPD3303电源通信异常!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		/// <summary>
		/// 不使能电压输出
		/// </summary>
		/// <returns></returns>
		public virtual bool DisableOutPutVoltage()
		{
			string cmd = string.Format("OUT{0}\r\n", 0);
			if ((this.m_COMMPort != null) && (this.m_COMMPort.IsAttached() == true))
			{
				this.m_COMMPort.m_COMMSerialPort.Write(cmd);
				Thread.Sleep(this.defaultDelayTime);
			}
			else
			{
				MessageBoxPlus.Show(this.m_COMMPort.m_COMMForm, "GPD3303电源通信异常!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		/// <summary>
		/// 获取电压输出的标志位
		/// </summary>
		/// <returns>true---输出使能；false---输出不使能</returns>
		public virtual bool GetFlagOutPutVoltage()
		{
			string cmd = string.Format("STATUS?\r\n");
			if ((this.m_COMMPort != null) && (this.m_COMMPort.IsAttached() == true))
			{
				this.m_COMMPort.m_COMMSerialPort.Write(cmd);
				Thread.Sleep(this.defaultDelayTime);
				if (this.m_COMMPort.m_COMMSerialPort.BytesToRead >= 2)
				{
					cmd = this.m_COMMPort.m_COMMSerialPort.ReadExisting();
				}
				int val = Convert.ToInt32(cmd);
				return ((val&0x04)!=0);
			}
			else
			{
				MessageBoxPlus.Show(this.m_COMMPort.m_COMMForm, "GPD3303电源通信异常!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		#endregion

		#region 私有函数	

		/// <summary>
		/// 自动获取通讯时钟
		/// </summary>
		/// <returns></returns>
		private int AutoGetCOMMBaudRate()
		{
			int[] baudRate = new int[] { 115200, 57600, 9600 };
			int i = 0;
			int _return = -1;
			if ((this.m_COMMPort != null) && (this.m_COMMPort.m_COMMSerialPort.IsOpen) && (this.m_COMMPort.m_COMMIndex != 0))
			{
				for (i = 0; i < baudRate.Length; i++)
				{
					this.m_COMMPort.m_COMMSerialPort.BaudRate = baudRate[i];
					//---获取设备的识别信息，厂家，型号，序列号及软件版本
					this.m_COMMPort.m_COMMSerialPort.Write("*IDN?\r\n");
					Thread.Sleep(this.defaultDelayTime);
					if (this.m_COMMPort.m_COMMSerialPort.BytesToRead >= 6)
					{
						string idn = this.m_COMMPort.m_COMMSerialPort.ReadExisting();
						if (idn.Contains("GW INSTEK"))
						{
							//---保存参数的波特率
							this.m_COMMPort.m_COMMPortParam.defaultBaudRate = baudRate[i].ToString();

							_return = i;
							break;
						}
					}
				}
			}
			else
			{
				MessageBoxPlus.Show(this.m_COMMPort.m_COMMForm, "GPD3303电源通信端口异常!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="baudRate"></param>
		/// <returns></returns>
		private int SetCOMMBaudRate(int baudRate)
		{
			int _return = -1;
			if ((this.m_COMMPort != null) && (this.m_COMMPort.m_COMMSerialPort.IsOpen) && (this.m_COMMPort.m_COMMIndex != 0))
			{
				this.m_COMMPort.m_COMMSerialPort.Write(string.Format("BAUD{0}\r\n", baudRate));
				Thread.Sleep(this.defaultDelayTime);
				_return = 0;
			}
			return _return;
		}

		#endregion

	}
}