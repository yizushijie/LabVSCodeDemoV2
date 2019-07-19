
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabCOMMPort
{
	/// <summary>
	/// 通讯串口的参数
	/// </summary>
	public class COMMSerialPortParam : COMMPortParam
	{
		#region 变量定义

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public COMMSerialPortParam() : base()
		{
			this.Init();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		public COMMSerialPortParam(string name)
		{
			this.defaultName = name;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="baudRate"></param>
		public COMMSerialPortParam(string name, string baudRate)
		{
			this.defaultName = name;
			this.defaultBaudRate = baudRate;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="baudRate"></param>
		/// <param name="parity"></param>
		public COMMSerialPortParam(string name, string baudRate, string parity)
		{
			this.defaultName = name;
			this.defaultBaudRate = baudRate;
			this.defaultParity = parity;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="baudRate"></param>
		/// <param name="parity"></param>
		/// <param name="dataBits"></param>
		public COMMSerialPortParam(string name, string baudRate, string parity, string dataBits)
		{
			this.defaultName = name;
			this.defaultBaudRate = baudRate;
			this.defaultParity = parity;
			this.defaultDataBits = dataBits;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="baudRate"></param>
		/// <param name="parity"></param>
		/// <param name="dataBits"></param>
		/// <param name="stopBits"></param>
		public COMMSerialPortParam(string name, string baudRate, string parity, string dataBits, string stopBits)
		{
			this.defaultName = name;
			this.defaultBaudRate = baudRate;
			this.defaultParity = parity;
			this.defaultDataBits = dataBits;
			this.defaultStopBits = stopBits;
		}

		#endregion

		#region 函数定义

		/// <summary>
		/// 
		/// </summary>
		public override void Init()
		{
			this.defaultName = null;
			this.defaultBaudRate = "115200";
			this.defaultParity = "NONE";
			this.defaultDataBits = "8";
			this.defaultStopBits = "1";
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		public override void Init(string name)
		{
			this.defaultName = name;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="baudRate"></param>
		public override void Init(string name, string baudRate)
		{
			this.defaultName = name;
			this.defaultBaudRate = baudRate;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="baudRate"></param>
		/// <param name="parity"></param>
		public override void Init(string name, string baudRate, string parity)
		{
			this.defaultName = name;
			this.defaultBaudRate = baudRate;
			this.defaultParity = parity;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="baudRate"></param>
		/// <param name="parity"></param>
		/// <param name="dataBits"></param>
		public override void Init(string name, string baudRate, string parity, string dataBits)
		{
			this.defaultName = name;
			this.defaultBaudRate = baudRate;
			this.defaultParity = parity;
			this.defaultDataBits = dataBits;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="baudRate"></param>
		/// <param name="parity"></param>
		/// <param name="dataBits"></param>
		/// <param name="stopBits"></param>
		public override void Init(string name, string baudRate, string parity, string dataBits, string stopBits)
		{
			this.defaultName = name;
			this.defaultBaudRate = baudRate;
			this.defaultParity = parity;
			this.defaultDataBits = dataBits;
			this.defaultStopBits = stopBits;
		}
		#endregion

	}
}
