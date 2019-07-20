using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Harry.LabCOMMPort
{
	#region CRC校验方式
	/// <summary>
	/// CRC校验方式
	/// </summary>
	public enum USE_CRC:byte
    {
        CRC_NONE = 0,           //---无校验方式
        CRC_CHECKSUM = 1,       //---检验和
        CRC_CRC8 = 2,           //---CRC8校验
        CRC_CRC16 = 3,          //---CRC16校验
        CRC_CRC32 = 4,          //---CRC32校验
    };
	#endregion

	#region 通信状态
	/// <summary>
	/// 通信状态
	/// </summary>
	public enum USE_STATE : byte
    {
        IDLE = 0,               //---空闲状态
        POLL_READ = 1,          //---轮训读取状态
        WRITE=2,                //---写入状态
        EVENT_READ=3,           //---事件读取状态
        ERROR = 4,              //---错误状态
    };
	#endregion
	
	#region 通讯端口的基类

	public partial class COMMBasePort : IDisposable
	{
		#region 变量定义

		/// <summary>
		/// 通讯端口
		/// </summary>
		private string defaultName = null;

		/// <summary>
		/// 通讯端口的索引号
		/// </summary>
		private int defaultIndex = 0;

		/// <summary>
		/// 通讯端口的工作状态
		/// </summary>
		private USE_STATE defaultSTATE = USE_STATE.IDLE;

		/// <summary>
		/// 写数据的缓存区
		/// </summary>
		private int defaultWriteBufferSize = 64;

		/// <summary>
		/// 写数据的校验方式
		/// </summary>
		private USE_CRC defaultWriteCRC = USE_CRC.CRC_NONE;

		/// <summary>
		/// 写数据的信息
		/// </summary>
		private COMMDataType defaultWriteData = new COMMDataType();

		/// <summary>
		/// 读数据的缓存区
		/// </summary>
		private int defaultReadBufferSize = 64;

		/// <summary>
		/// 读数据的校验方式
		/// </summary>
		private USE_CRC defaultReadCRC = USE_CRC.CRC_NONE;

		/// <summary>
		/// 读数据的信息
		/// </summary>
		private COMMDataType defaultReadData = new COMMDataType();

		/// <summary>
		/// 通信耗时
		/// </summary>
		private TimeSpan defaultTime = TimeSpan.MinValue;

		/// <summary>
		/// 通讯错误信息
		/// </summary>
		private string defaultErrMsg = string.Empty;

		/// <summary>
		/// 使用的窗体
		/// </summary>
		private Form defaultForm = null;

		/// <summary>
		/// 通讯写数据报头
		/// </summary>
		private byte defaultWriteID = 0x55;

		/// <summary>
		/// 通讯读数据报头
		/// </summary>
		private byte defaultReadID = 0x5A;

		/// <summary>
		/// 多设备通信是否使能
		/// </summary>
		private bool defaultIsMultiDevice = false;

		/// <summary>
		/// 多设备通讯过程中的设备id号
		/// </summary>
		private byte ddefaultMultiDeviceID = 0;

		/// <summary>
		/// 消息显示窗口
		/// </summary>
		private RichTextBox defaultRichTextBox = null;

		/// <summary>
		/// 端口控件
		/// </summary>
		private ComboBox defaultComboBox = null;

		/// <summary>
		/// 串口使用的参数
		/// </summary>
		private COMMPortParam defaultPortParam = new COMMPortParam();

		/// <summary>
		/// 是否主命令加子命令结构
		/// </summary>
		public bool defaultIsChildCMD = false;

		#endregion

		#region 属性定义
		/// <summary>
		/// 通讯端口
		/// </summary>
		public virtual string m_COMMName
		{
			get
			{
				return this.defaultName;
			}
			set
			{
				this.defaultName = value;
			}
		}

		/// <summary>
		/// 通讯端口的索引号
		/// </summary>
		public virtual int m_COMMIndex
		{
			get
			{
				return this.defaultIndex;
			}
			set
			{
				this.defaultIndex = value;
			}
		}

		/// <summary>
		/// 通讯端口的工作状态
		/// </summary>
		public virtual USE_STATE m_COMMSTATE
		{
			get
			{
				return this.defaultSTATE;
			}
			set
			{
				this.defaultSTATE = value;
			}
		}

		/// <summary>
		/// 写数据的缓存区
		/// </summary>
		public virtual int m_COMMWriteBufferSize
		{
			get
			{
				return this.defaultWriteBufferSize;
			}
			set
			{
				this.defaultWriteBufferSize = value;
			}

		}

		/// <summary>
		/// 写数据的校验方式
		/// </summary>
		public virtual USE_CRC m_COMMWriteCRC
		{
			get
			{
				return this.defaultWriteCRC;
			}
			set
			{
				this.defaultWriteCRC = value;
			}
		}

		/// <summary>
		/// 写数据的信息
		/// </summary>
		public virtual COMMDataType m_COMMWriteData
		{
			get
			{
				return this.defaultWriteData;
			}
			set
			{
				this.defaultWriteData = value;
			}
		}

		/// <summary>
		/// 读数据的缓存区
		/// </summary>
		public virtual int m_COMMReadBufferSize
		{
			get
			{
				return this.defaultReadBufferSize;
			}
			set
			{
				this.defaultReadBufferSize = value;
			}
		}

		/// <summary>
		/// 读数据的校验方式
		/// </summary>
		public virtual USE_CRC m_COMMReadCRC
		{
			get
			{
				return this.defaultReadCRC;
			}
			set
			{
				this.defaultReadCRC = value;
			}
		}

		/// <summary>
		/// 读数据的信息
		/// </summary>
		public virtual COMMDataType m_COMMReadData
		{
			get
			{
				return this.defaultReadData;
			}
			set
			{
				this.defaultReadData = value;
			}
		}

		/// <summary>
		/// 通信耗时
		/// </summary>
		public virtual TimeSpan m_COMMTime
		{
			get
			{
				return this.defaultTime;
			}
			set
			{
				this.defaultTime = value;
			}
		}

		/// <summary>
		/// 通讯错误信息
		/// </summary>
		public virtual string m_COMMErrMsg
		{
			get
			{
				return this.defaultErrMsg;
			}
			set
			{
				this.defaultErrMsg = value;
			}
		}

		/// <summary>
		/// 使用的窗体
		/// </summary>
		public virtual Form m_COMMForm
		{
			get
			{
				return this.defaultForm;
			}
			set
			{
				if (this.defaultForm == null)
				{
					this.defaultForm = new Form();
				}
				this.defaultForm = value;
			}
		}

		/// <summary>
		/// 通讯写数据报头
		/// </summary>
		public virtual byte m_COMMWriteID
		{
			get
			{
				return this.defaultWriteID;
			}
			set
			{
				this.defaultWriteID = value;
			}
		}

		/// <summary>
		/// 通讯读数据报头
		/// </summary>
		public virtual byte m_COMMReadID
		{
			get
			{
				return this.defaultReadID;
			}
			set
			{
				this.defaultReadID = value;
			}
		}

		/// <summary>
		/// 多设备通信是否使能
		/// </summary>
		public virtual bool m_COMMIsMultiDevice
		{
			get
			{
				return this.defaultIsMultiDevice;
			}
			set
			{
				this.defaultIsMultiDevice = value;
			}
		}

		/// <summary>
		/// 多设备通讯过程中的设备id号
		/// </summary>
		public virtual byte m_COMMMultiDeviceID
		{
			get
			{
				return this.ddefaultMultiDeviceID;
			}
			set
			{
				this.ddefaultMultiDeviceID = value;
			}
		}

		/// <summary>
		/// 消息显示窗口
		/// </summary>
		public virtual RichTextBox m_COMMRichTextBox
		{
			get
			{
				return this.defaultRichTextBox;
			}
			set
			{
				if (this.defaultRichTextBox == null)
				{
					this.defaultRichTextBox = new RichTextBox();
				}
				this.defaultRichTextBox = value;
			}
		}

		/// <summary>
		/// 端口控件
		/// </summary>
		public virtual ComboBox m_COMMComboBox
		{
			get
			{
				return this.defaultComboBox;
			}
			set
			{
				if (this.defaultComboBox == null)
				{
					this.defaultComboBox = new ComboBox();
				}
				this.defaultComboBox = value;
			}
		}

		/// <summary>
		/// 通讯端口的参数
		/// </summary>
		public virtual COMMPortParam m_COMMParam
		{
			get
			{
				return this.defaultPortParam;
			}
			set
			{
				if (this.defaultPortParam==null)
				{
					this.defaultPortParam = new COMMPortParam();
				}
				this.defaultPortParam = value;
			}
		}

		/// <summary>
		/// 复合命令的属性为读写
		/// </summary>
		public virtual bool m_COMMIsChildCMD
		{
			get
			{
				return this.defaultIsChildCMD;
			}
			set
			{
				this.defaultIsChildCMD = value;
			}
		}

		/// <summary>
		/// 接收数据校验
		/// </summary>
		public virtual bool m_COMMReceVerifyPass
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// 通讯端口状态是否可用，true---可用，false---不可用
		/// </summary>
		public virtual bool m_COMMIsOpen
		{
			get
			{
				return false;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public COMMBasePort()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		public COMMBasePort(Form argForm)
		{
			this.defaultForm = argForm;
		}
		
		#endregion

		#region 析构函数

		/// <summary>
		/// 析构函数
		/// </summary>
		~COMMBasePort()
		{
			GC.SuppressFinalize(this);
		}
		
		private bool disposedValue = false; // 要检测冗余调用

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disposing"></param>
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: 释放托管状态(托管对象)。
				}

				// TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
				// TODO: 将大型字段设置为 null。

				disposedValue = true;
			}
		}

		// TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
		// ~COMMBasePort() {
		//   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
		//   Dispose(false);
		// }

		// 添加此代码以正确实现可处置模式。

		/// <summary>
		/// 
		/// </summary>
		public virtual void Dispose()
		{
			// 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
			this.Dispose(true);
			// TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
			GC.SuppressFinalize(this);
		}
		
		#endregion

		#region 函数定义

		/// <summary>
		/// 初始化
		/// </summary>
		/// <returns></returns>
		public virtual int Init()
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cbb"></param>
		/// <returns></returns>
		public virtual int Init(ComboBox cbb, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <returns></returns>
		public virtual int Init(string argName, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="bandRate"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int Init(string argName, int bandRate, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="commSerialPortParam"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int Init(COMMPortParam commSerialPortParam, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pid"></param>
		/// <param name="vid"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int Init(int pid, int vid, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		public virtual void GetPortNames(ComboBox cbb, RichTextBox msg = null)
		{

		}
		/// <summary>
		/// 设置多设备通信
		/// </summary>
		/// <param name="isMultiDevice"></param>
		/// <param name="multiDeviceID"></param>
		/// <returns></returns>
		public virtual void SetMultiDevice(bool isMultiDevice, byte multiDeviceID)
		{

		}

		/// <summary>
		/// 设备从设备的ID
		/// </summary>
		/// <param name="multiDeviceID"></param>
		public virtual void SetMultiDeviceID(byte multiDeviceID)
		{

		}

		/// <summary>
		/// 设置多设备通信
		/// </summary>
		/// <param name="isMultiDevice"></param>
		/// <param name="multiDeviceID"></param>
		/// <returns></returns>
		public virtual void ClearMultiDevice()
		{

		}


		/// <summary>
		/// 添加监控设备
		/// </summary>
		/// <returns></returns>
		public virtual bool AddWatcherPort(ComboBox cbb = null, RichTextBox msg = null)
		{
			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual bool AddWatcherPort(Form argForm, ComboBox cbb = null, RichTextBox msg = null)
		{
			return false;
		}

		/// <summary>
		/// 添加设备
		/// </summary>
		/// <returns></returns>
		public virtual int AddDevice()
		{
			return 1;
		}

		/// <summary>
		/// 添加设备
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int AddDevice(ComboBox cbb, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 移除设备
		/// </summary>
		/// <returns></returns>
		public virtual int RemoveDevice()
		{
			return 1;
		}

		/// <summary>
		/// 移除设备
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int RemoveDevice(ComboBox cbb, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 刷新设备
		/// </summary>
		/// <returns></returns>
		public virtual int RefreshDevice()
		{
			return 1;
		}

		/// <summary>
		/// 刷新设备
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int RefreshDevice(ComboBox cbb, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int WriteToDevice(byte cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argIndex"></param>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int WriteToDevice(int argIndex, byte cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int WriteToDevice(string argName, byte cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int WriteToDevice(byte[] cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int WriteToDevice(ref byte[] cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argIndex"></param>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int WriteToDevice(int argIndex, byte[] cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int WriteToDevice(string argName, byte[] cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argIndex"></param>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int WriteToDevice(int argIndex, ref byte[] cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int WriteToDevice(string argName, ref byte[] cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int ReadFromDevice(int timeout = 200, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int ReadFromDevice(ref byte[] cmd, int timeout = 200, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argIndex"></param>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int ReadFromDevice(int argIndex, ref byte[] cmd, int timeout = 200, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int ReadFromDevice(string argName, ref byte[] cmd, int timeout = 200, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int SendCmdAndReadResponse(byte[] cmd, int timeout = 200, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int SendCmdAndReadResponse(byte[] cmd, ref byte[] res, int timeout = 200, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int SendCmdAndReadResponse(ref byte[] cmd, ref byte[] res, int timeout = 200, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int SendCmdAndReadResponse(string argName,byte[] cmd, ref byte[] res, int timeout = 200, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int SendCmdAndReadResponse(string argName, ref byte[] cmd, ref byte[] res, int timeout = 200, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int SendCmdAndReadResponse(int argIndex, byte[] cmd, ref byte[] res, int timeout = 200, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int SendCmdAndReadResponse(int argIndex, ref byte[] cmd, ref byte[] res, int timeout = 200, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual int OpenDevice()
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="portIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int OpenDevice(int argIndex, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int OpenDevice(string argName, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int OpenDevice(string argName, int baudRate, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int OpenDevice(COMMPortParam commSerialPortParam, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual int CloseDevice()
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="portIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int CloseDevice(int argIndex, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int CloseDevice(string argName, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 检测设备
		/// </summary>
		/// <returns></returns>
		public virtual bool IsAttached()
		{
			return false;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portIndex"></param>
		/// <returns></returns>
		public virtual bool IsAttached(int argIndex)
		{
			return false;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portIndex"></param>
		/// <returns></returns>
		public virtual bool IsAttached(string argName)
		{
			return false;
		}

		#endregion

		#region 事件定义


		/// <summary>
		/// 通讯委托事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public delegate void EventCOMM(object sender, EventArgs e);

		/// <summary>
		/// 通讯端口同步委托事件
		/// </summary>
		public delegate void EventCOMMSYNC();

		/// <summary>
		/// 同步事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		[Description("通讯端口同步事件"), Category("自定义事件")]
		private event EventCOMMSYNC OnEventCOMMSync = null;

		/// <summary>
		/// 端口同步事件
		/// </summary>
		public virtual EventCOMMSYNC m_OnEventCOMMSync
		{
			get
			{
				return this.OnEventCOMMSync;
			}
			set
			{
				//---判断事件是否为空，避免多次进入
				if (this.OnEventCOMMSync != null)
				{
					this.OnEventCOMMSync = null;
				}
				this.OnEventCOMMSync = value;
			}
		}

		/// <summary>
		/// 接收事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		[Description("数据接收事件"), Category("自定义事件")]
		private event EventCOMM OnEventDataReceived = null;

		/// <summary>
		/// 事件的属性为读写
		/// </summary>
		public virtual EventCOMM m_OnEventDataReceived
		{
			get
			{
				return this.OnEventDataReceived;
			}
			set
			{
				//---判断事件是否为空，避免多次进入
				if (this.OnEventDataReceived != null)
				{
					this.OnEventDataReceived = null;
				}
				this.OnEventDataReceived = value;
			}
		}

		/// <summary>
		/// 设备一处
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		[Description("设备移除事件"), Category("自定义事件")]
		private event EventCOMM OnEventDeviceRemoved = null;

		/// <summary>
		/// 事件的属性为读写
		/// </summary>
		public virtual EventCOMM m_OnEventDeviceRemoved
		{
			get
			{
				return this.OnEventDeviceRemoved;
			}
			set
			{
				//---判断事件是否为空，避免多次进入
				if (this.OnEventDeviceRemoved != null)
				{
					this.OnEventDeviceRemoved = null;
				}
				this.OnEventDeviceRemoved = value;
			}
		}

		/// <summary>
		/// 通讯数据接收事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void OnEventDataReceivedHandler(object sender, EventArgs e)
		{

		}
		#endregion
	}

	#endregion

}
