using Harry.LabUserControlPlus;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabMcuProject
{
	/// <summary>
	/// 内部OSC的测试
	/// </summary>
	public partial class LabMcuBase
	{

		#region 变量定义

		/// <summary>
		/// KHz的频率
		/// </summary>
		private float defaultOSCKHz = 8000.00F;

		/// <summary>
		/// 通讯主命令
		/// </summary>
		private byte DEFAULT_OSC_CMD_PARENT = 0xA4;

		#endregion

		#region 属性定义

		/// <summary>
		/// 
		/// </summary>
		public virtual float m_OSCKHz
		{
			get
			{
				return this.defaultOSCKHz;
			}
			set
			{
				this.defaultOSCKHz = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual float m_OSCMHz
		{
			get
			{
				return (float)(this.defaultOSCKHz / 1000.0);
			}
		}

		#endregion

		#region 构造函数

		#endregion

		#region 公共函数

		/// <summary>
		/// 读取OSC的频率
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int OSC_ReadOSCResult(RichTextBox msg = null)
		{
			int _return = -1;
			if ((this.defaultCOMMPort != null) && (this.defaultCOMMPort.m_COMMIsOpen))
			{
				int readBufferSize = this.defaultCOMMPort.m_COMMReadBufferSize;
				int writeBufferSize = this.defaultCOMMPort.m_COMMWriteBufferSize;
				this.defaultCOMMPort.m_COMMReadBufferSize = 300;
				this.defaultCOMMPort.m_COMMWriteBufferSize = 300;
				byte[] cmd = new byte[] {DEFAULT_OSC_CMD_PARENT };
				byte[] res = null;
				
				_return = this.defaultCOMMPort.SendCmdAndReadResponse(cmd, ref res);
				if (this.defaultCOMMPort.m_COMMReceVerifyPass)
				{
					this.defaultOSCKHz = res[this.defaultCOMMPort.m_COMMReadData.defaultRealityIndex];
					this.defaultOSCKHz = ((int)this.defaultOSCKHz << 8) + res[this.defaultCOMMPort.m_COMMReadData.defaultRealityIndex + 1];
					this.defaultOSCKHz = ((int)this.defaultOSCKHz << 8) + res[this.defaultCOMMPort.m_COMMReadData.defaultRealityIndex + 2];
					this.defaultOSCKHz = ((int)this.defaultOSCKHz << 8) + res[this.defaultCOMMPort.m_COMMReadData.defaultRealityIndex + 3];

					this.defaultOSCKHz /= 100.0F;

					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "读取频率是: " + this.defaultOSCKHz.ToString("F2") + "KHz\r\n", Color.Black, false);
					}
				}
				this.defaultCOMMPort.m_COMMReadBufferSize = readBufferSize;
				this.defaultCOMMPort.m_COMMWriteBufferSize = writeBufferSize ;
			}
			return _return;
		}

		#endregion
	}
}
