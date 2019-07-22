using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabCOMMPort
{
	/// <summary>
	/// 通讯端口的配置
	/// </summary>
	public class COMMPortParam
	{
		#region 变量定义

		#region 串口参数定义

		/// <summary>
		/// 端口名称
		/// </summary>
		public string defaultName = null;

		/// <summary>
		/// 通讯波特率
		/// </summary>
		public string defaultBaudRate = "115200";

		/// <summary>
		/// 校验位
		/// </summary>
		public string defaultParity = "NONE";

		/// <summary>
		/// 数据位
		/// </summary>
		public string defaultDataBits = "8";

		/// <summary>
		/// 停止位
		/// </summary>
		public string defaultStopBits = "1";

		#endregion

		#region USB参数定义

		/// <summary>
		/// 设备的VIP
		/// </summary>
		public int defaultVID = 0;

		/// <summary>
		/// 设备的PID
		/// </summary>
		public int defaultPID = 0;

		#endregion

		#region 公共参数定义

		/// <summary>
		/// 超时时间
		/// </summary>
		public int defaultTimeOut = 0;

		#endregion

		#endregion

		#region 属性定义

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public COMMPortParam()
		{
			
		}

		#endregion

		#region 函数定义

		public virtual void Init()
		{

		}

		#region 串口通讯
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		public virtual void Init(string name)
		{
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="baudRate"></param>
		public virtual void Init(string name, string baudRate)
		{
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="baudRate"></param>
		/// <param name="parity"></param>
		public virtual void Init(string name, string baudRate, string parity)
		{
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="baudRate"></param>
		/// <param name="parity"></param>
		/// <param name="dataBits"></param>
		public virtual void Init(string name, string baudRate, string parity, string dataBits)
		{
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="baudRate"></param>
		/// <param name="parity"></param>
		/// <param name="dataBits"></param>
		/// <param name="stopBits"></param>
		public virtual void Init(string name, string baudRate, string parity, string dataBits, string stopBits)
		{

		}
		#endregion

		#region USB通讯
		/// <summary>
		/// 
		/// </summary>
		/// <param name="vid"></param>
		/// <param name="pid"></param>
		public virtual void Init(int vid, int pid)
		{
			
		}
		#endregion

		#endregion

	}
}
