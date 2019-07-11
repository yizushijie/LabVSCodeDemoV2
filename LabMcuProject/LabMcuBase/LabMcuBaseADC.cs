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
		/// 选择的ADC通道号
		/// </summary>
		private int defaultADCChannelIndex = 0;

		/// <summary>
		/// 参考电压的值
		/// </summary>
		private float defaultADCVREF = 0;

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

		/// <summary>
		/// ADC结果
		/// </summary>

		private IDataADC defaultADCResult = new IDataADC();

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
		public virtual float m_ADCVREF
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

		/// <summary>
		/// 
		/// </summary>
		public virtual IDataADC m_ADCResult
		{
			get
			{
				return this.defaultADCResult;
			}
		}

		#endregion

		#region 构造函数

		#endregion

		#region 公共函数

		/// <summary>
		/// 读取ADC的参考电压的模式
		/// </summary>
		/// <returns></returns>
		public virtual int ADC_ReadADCVREFMode(int childCMD, RichTextBox msg = null)
		{
			int _return = -1;
			if ((this.defaultCOMMPort != null) && (this.defaultCOMMPort.m_COMMIsOpen))
			{
				byte[] cmd = new byte[] { 0x55, 0x00, DEFAULT_ADC_CMD_PARENT, (byte)childCMD,0x01};
				cmd[1] = (byte)(cmd.Length - 2);
				byte[] res = null;
				this.defaultCOMMPort.m_COMMIsChildCMD = true;

				_return = this.defaultCOMMPort.SendCmdAndReadResponse(cmd,ref res);
				if(this.defaultCOMMPort.m_COMMReceVerifyPass)
				{
					_return = res[this.defaultCOMMPort.m_COMMReadData.defaultRealityIndex];
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "读取参考电压是" + this.defaultADCVREFMode[_return] + "\r\n", Color.Black, false);
					}
				}
			}
			return _return;
		}

		/// <summary>
		/// 写入ADC的参考电压选择
		/// </summary>
		/// <returns></returns>
		public virtual int ADC_WriteADCVREFMode(int childCMD, RichTextBox msg = null)
		{
			int _return = -1;
			if ((this.defaultCOMMPort != null) && (this.defaultCOMMPort.m_COMMIsOpen))
			{
				byte[] cmd = new byte[] { 0x55, 0x00, DEFAULT_ADC_CMD_PARENT, (byte)childCMD, 0x00 };
				cmd[1] = (byte)(cmd.Length - 2);
				byte[] res = null;
				this.defaultCOMMPort.m_COMMIsChildCMD = true;

				_return = this.defaultCOMMPort.SendCmdAndReadResponse(cmd, ref res);
				if (this.defaultCOMMPort.m_COMMReceVerifyPass)
				{
					_return = res[this.defaultCOMMPort.m_COMMReadData.defaultRealityIndex];
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "写入参考电压是" + this.defaultADCVREFMode[childCMD] + "\r\n", Color.Black, false);
					}
				}
			}
			return _return;
		}


		/// <summary>
		/// 读取配置的ADC通道
		/// </summary>
		/// <returns></returns>
		public virtual int ADC_ReadADCChannel(int childCMD, RichTextBox msg = null)
		{
			int _return = -1;
			if ((this.defaultCOMMPort != null) && (this.defaultCOMMPort.m_COMMIsOpen))
			{
				byte[] cmd = new byte[] { 0x55, 0x00, DEFAULT_ADC_CMD_PARENT, (byte)childCMD, 0x01 };
				cmd[1] = (byte)(cmd.Length - 2);
				byte[] res = null;
				this.defaultCOMMPort.m_COMMIsChildCMD = true;

				_return = this.defaultCOMMPort.SendCmdAndReadResponse(cmd, ref res);
				if (this.defaultCOMMPort.m_COMMReceVerifyPass)
				{
					_return = res[this.defaultCOMMPort.m_COMMReadData.defaultRealityIndex];
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "读取ADC通道是" + this.defaultADCChannel[_return] + "\r\n", Color.Black, false);
					}
				}
			}
			return _return;
		}

		/// <summary>
		/// 吸入选中ADC的通道
		/// </summary>
		/// <returns></returns>
		public virtual int ADC_WriteADCChannel(int childCMD, RichTextBox msg = null)
		{
			int _return = -1;
			if ((this.defaultCOMMPort != null) && (this.defaultCOMMPort.m_COMMIsOpen))
			{
				byte[] cmd = new byte[] { 0x55, 0x00, DEFAULT_ADC_CMD_PARENT, (byte)childCMD, 0x00 };
				cmd[1] = (byte)(cmd.Length - 2);
				byte[] res = null;
				this.defaultCOMMPort.m_COMMIsChildCMD = true;

				_return = this.defaultCOMMPort.SendCmdAndReadResponse(cmd, ref res);
				if (this.defaultCOMMPort.m_COMMReceVerifyPass)
				{
					_return = this.defaultCOMMPort.m_COMMReadData.defaultResultFlag;
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "写入ADC通道是" + this.defaultADCChannel[childCMD - this.defaultADCVREFMode.Length] + "\r\n", Color.Black, false);
					}
				}
			}
			return _return;
		}

		/// <summary>
		///  读取ADC采样的次数
		/// </summary>
		/// <returns></returns>
		public virtual int ADC_ReadADCSampleNum(int childCMD,RichTextBox msg=null)
		{
			int _return = 0;
			if ((this.defaultCOMMPort != null) && (this.defaultCOMMPort.m_COMMIsOpen))
			{
				byte[] cmd = new byte[] { 0x55, 0x00, DEFAULT_ADC_CMD_PARENT, (byte)childCMD,0x01 };
				cmd[1] = (byte)(cmd.Length - 2);
				byte[] res = null;
				this.defaultCOMMPort.m_COMMIsChildCMD = true;

				_return =this.defaultCOMMPort.SendCmdAndReadResponse(cmd, ref res);
				if (this.defaultCOMMPort.m_COMMReceVerifyPass)
				{
					_return = res[this.defaultCOMMPort.m_COMMReadData.defaultRealityIndex];
					//---ADC采样的次数
					this.defaultADCSampleNum = _return;
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "ADC采样次数读取成功，采样次数是："+_return.ToString()+"\r\n", Color.Black, false);
					}
				}
			}
			return _return;
		}

		/// <summary>
		/// 写入ADC采样的次数
		/// </summary>
		/// <returns></returns>
		public virtual int ADC_WriteADCSampleNum(int childCMD, int num,RichTextBox msg= null)
		{
			int _return = -1;
			if ((this.defaultCOMMPort != null) && (this.defaultCOMMPort.m_COMMIsOpen))
			{
				byte[] cmd = new byte[] { 0x55, 0x00, DEFAULT_ADC_CMD_PARENT, (byte)childCMD, 0x00,(byte)num };
				cmd[1] = (byte)(cmd.Length - 2);
				byte[] res = null;
				this.defaultCOMMPort.m_COMMIsChildCMD = true;

				this.defaultCOMMPort.SendCmdAndReadResponse(cmd, ref res);
				if (this.defaultCOMMPort.m_COMMReceVerifyPass)
				{
					//---ADC采样的次数
					this.defaultADCSampleNum = num;
					_return = this.defaultCOMMPort.m_COMMReadData.defaultResultFlag;
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "ADC采样次数设置成功，采样次数是：" + ((byte)num).ToString() + "\r\n", Color.Black, false);
					}
				}
			}
			return _return;
		}

		/// <summary>
		/// 读取ADC的采样结果
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int ADC_ReadADCResult(RichTextBox msg = null)
		{
			int _return = -1;
			if ((this.defaultCOMMPort != null) && (this.defaultCOMMPort.m_COMMIsOpen))
			{
				byte[] cmd = new byte[] { 0x55, 0x00, DEFAULT_ADC_CMD_PARENT, (byte)(this.defaultADCVREFMode.Length+this.defaultADCChannel.Length+1)};
				cmd[1] = (byte)(cmd.Length - 2);
				byte[] res = null;
				this.defaultCOMMPort.m_COMMIsChildCMD = true;

				this.defaultCOMMPort.SendCmdAndReadResponse(cmd, ref res);
				if (this.defaultCOMMPort.m_COMMReceVerifyPass)
				{
					_return = this.defaultCOMMPort.m_COMMReadData.defaultResultFlag;

					if (this.defaultADCResult==null)
					{
						this.defaultADCResult = new IDataADC();
					}
					//---通道号
					this.defaultADCChannelIndex = this.defaultCOMMPort.m_COMMReadData.defaultDataByte[0];
					//---采样次数
					this.defaultADCSampleNum = this.defaultCOMMPort.m_COMMReadData.defaultDataByte[1];
					//---增益选择
					this.defaultADCGain = this.defaultCOMMPort.m_COMMReadData.defaultDataByte[2];
					//---计算ADC的采样结果
					this.defaultADCResult.Init(this.defaultCOMMPort.m_COMMReadData.defaultDataByte, 3);

					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "ADC采样次数设置成功，采样次数是：" + "\r\n", Color.Black, false);
					}
				}
			}
			return _return;
		}

		/// <summary>
		/// 读取ADC的采样结果
		/// </summary>
		/// <param name="startMV"></param>
		/// <param name="stepMV"></param>
		/// <param name="stopMV"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int ADC_ReadADCScanResult(float startMV, float stepMV, float stopMV,RichTextBox msg = null)
		{
			int _return = -1;
			return _return;
		}

		#endregion

		#region 私有函数

		#endregion

	}
}
