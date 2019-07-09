using Harry.LabUserControlPlus;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabMcuProject
{
	public partial  class LabMcuBase
	{
		#region 变量定义

		/// <summary>
		/// ADC参考电压的类型
		/// </summary>
		private string[] defaultADCVREFMode =
		{
			"VREF_AREF",
			"VREF_AVCC",
			"VREF_BG1 ",
			"VREF_BG2 "
		};

		/// <summary>
		/// ADC通道选择
		/// </summary>
		private string[] defaultADCChannel =
		{
			"ADC0",
			"ADC1",
			"ADC2",
			"ADC3",
			"ADC4",
			"ADC5",
			"ADC6",
			"ADC7",
			"BG1" ,
			"GND"
		};

		/// <summary>
		/// ADC的采样次数
		/// </summary>
		private int defaultADCSampleNum = 1;

		/// <summary>
		/// 参考电压的值
		/// </summary>
		private int defaultADCVREF = 0;

		/// <summary>
		/// ADC的增益配置
		/// </summary>
		private int defaultADCGain = 0;

		/// <summary>
		/// 内部参考电压1
		/// </summary>
		private float defaultADCBandGap1 = 0.00F;

		/// <summary>
		/// 内部参考电压2
		/// </summary>
		private float defaultADCBandGap2 = 2.56F;

		/// <summary>
		/// 通讯主命令
		/// </summary>
		private byte DEFAULT_ADC_CMD_PARENT = 0xA3;
		
		#endregion

		#region 属性定义

		/// <summary>
		/// 参考电压的选择模式
		/// </summary>
		public virtual string[] m_ADCVREFMode
		{
			get
			{
				return this.defaultADCVREFMode;
			}
			set
			{
				if (this.defaultADCVREFMode==null)
				{
					this.defaultADCVREFMode = new string[] { };
				}
				this.defaultADCVREFMode = value;
			}
		}

		/// <summary>
		/// ADC通道选择
		/// </summary>
		public virtual string[] m_ADCChannel
		{
			get
			{
				return this.defaultADCChannel;
			}
			set
			{
				if (this.defaultADCChannel==null)
				{
					this.defaultADCChannel = new string[] { };
				}
				this.defaultADCChannel = value;
			}
		}

		/// <summary>
		/// ADC采样次数
		/// </summary>
		public virtual int m_ADCSampleNum
		{
			get
			{
				return this.defaultADCSampleNum;
			}
			set
			{
				this.defaultADCSampleNum = value;
			}
		}

		/// <summary>
		/// ADC参考电压
		/// </summary>
		public virtual int m_ADCVREF
		{
			get
			{
				return this.defaultADCVREF;
			}
			set
			{
				this.defaultADCVREF = value;
			}
		}

		/// <summary>
		/// ADC增益配置
		/// </summary>
		public virtual int m_ADCGain
		{
			get
			{
				return this.defaultADCGain;
			}
			set
			{
				this.defaultADCGain = value;
			}
		}

		/// <summary>
		/// 内部参考电压1
		/// </summary>
		public virtual float m_ADCBandGap1
		{
			get
			{
				return this.defaultADCBandGap1;
			}
			set
			{
				this.defaultADCBandGap1 = value;
			}
		}

		/// <summary>
		/// 内部从参考电压2
		/// </summary>
		public virtual float m_ADCBandGap2
		{
			get
			{
				return this.defaultADCBandGap2;
			}
			set
			{
				this.defaultADCBandGap2 = value;
			}
		}

		#endregion

		#region 构造函数

		#endregion

		#region 公共函数

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual int ADC_ReadADCSelectVREFMode(int childCMD, RichTextBox msg = null)
		{
			int _return = -1;
			if ((this.defaultCOMMPort!=null)&&(this.defaultCOMMPort.IsAttached())&&(this.defaultCOMMPort.m_COMMIndex!=0))
			{
				byte[] cmd = new byte[] { 0x55, 0x00, DEFAULT_ADC_CMD_PARENT, (byte)childCMD,0x01};
				cmd[1] = (byte)(cmd.Length - 2);
				byte[] res = null;
				_return = this.defaultCOMMPort.SendCmdAndReadResponse(cmd, ref res);
				if ((res != null) && (this.defaultCOMMPort.m_COMMReadData.defaultParentCMD == cmd[2]) && (this.defaultCOMMPort.m_COMMReadData.defaultChildCMD == cmd[3]) && (this.defaultCOMMPort.m_COMMReadData.defaultResultFlag == 0))
				{
					_return = res[res.Length - 1];
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "读取参考电压是" + this.defaultADCVREFMode[childCMD] + "\r\n", Color.Black, false);
					}
				}
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual int ADC_WriteADCSelectVREFMode(int childCMD, RichTextBox msg = null)
		{
			int _return = -1;
			if ((this.defaultCOMMPort != null) && (this.defaultCOMMPort.IsAttached()) && (this.defaultCOMMPort.m_COMMIndex != 0))
			{
				byte[] cmd = new byte[] { 0x55, 0x00, DEFAULT_ADC_CMD_PARENT, (byte)childCMD, 0x00 };
				cmd[1] = (byte)(cmd.Length - 2);
				byte[] res = null;
				_return = this.defaultCOMMPort.SendCmdAndReadResponse(cmd, ref res);
				if ((res != null) && (this.defaultCOMMPort.m_COMMReadData.defaultParentCMD == cmd[2]) && (this.defaultCOMMPort.m_COMMReadData.defaultChildCMD == cmd[3]) && (this.defaultCOMMPort.m_COMMReadData.defaultResultFlag == 0))
				{
					_return = res[res.Length - 1];
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "写入参考电压是" + this.defaultADCVREFMode[childCMD] + "\r\n", Color.Black, false);
					}
				}
			}
			return _return;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual int ADC_ReadADCSelectChannel(int childCMD, RichTextBox msg = null)
		{
			int _return = -1;
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual int ADC_WriteADCSelectChannel(int childCMD, RichTextBox msg = null)
		{
			int _return = -1;
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual int ADC_ReadADCSampleNum(int childCMD,RichTextBox msg=null)
		{
			int _return = 0;
			if ((this.defaultCOMMPort != null) && (this.defaultCOMMPort.IsAttached()) && (this.defaultCOMMPort.m_COMMIndex != 0))
			{
				byte[] cmd = new byte[] { 0x55, 0x00, DEFAULT_ADC_CMD_PARENT, (byte)childCMD,0x01 };
				cmd[1] = (byte)(cmd.Length - 2);
				byte[] res = null;
				_return=this.defaultCOMMPort.SendCmdAndReadResponse(cmd, ref res);
				if ((res!=null)&&(this.defaultCOMMPort.m_COMMReadData.defaultParentCMD==cmd[2])&&(this.defaultCOMMPort.m_COMMReadData.defaultChildCMD==cmd[3])&&(this.defaultCOMMPort.m_COMMReadData.defaultResultFlag==0))
				{
					_return = res[res.Length - 1];
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "ADC采样次数读取成功，采样次数是："+_return.ToString()+"\r\n", Color.Black, false);
					}
				}
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual int ADC_WriteADCSampleNum(int childCMD, int num,RichTextBox msg= null)
		{
			int _return = -1;
			if ((this.defaultCOMMPort != null) && (this.defaultCOMMPort.IsAttached()) && (this.defaultCOMMPort.m_COMMIndex != 0))
			{
				byte[] cmd = new byte[] { 0x55, 0x00, DEFAULT_ADC_CMD_PARENT, (byte)childCMD, 0x00,(byte)num };
				cmd[1] = (byte)(cmd.Length - 2);
				byte[] res = null;
				this.defaultCOMMPort.SendCmdAndReadResponse(cmd, ref res);
				if ((res != null) && (this.defaultCOMMPort.m_COMMReadData.defaultParentCMD == cmd[2]) && (this.defaultCOMMPort.m_COMMReadData.defaultChildCMD == cmd[3]) && (this.defaultCOMMPort.m_COMMReadData.defaultResultFlag == 0))
				{
					_return = res[res.Length - 1];
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "ADC采样次数设置成功，采样次数是：" + ((byte)num).ToString() + "\r\n", Color.Black, false);
					}
				}
			}
			return _return;
		}

		#endregion

		#region 私有函数

		#endregion
	}
}
