
using Harry.LabUserControlPlus;
using Harry.LabUserGenFunc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Harry.LabCOMMPort
{
	/// <summary>
	/// 串口通讯
	/// </summary>
	public class COMMSerialPort:COMMBasePort
    {
        #region 变量定义

        /// <summary>
        /// 使用的串口
        /// </summary>
        private SerialPort defaultSerialPort = null;

		/// <summary>
		/// 设备索引列表，用于监控设备的拔插
		/// </summary>
		private List<byte> defaultIndexMemu = new List<byte>();

		#endregion

		#region 属性定义

		#region 变量属性

		/// <summary>
		/// 串行通信端口的属性为读写
		/// </summary>
		public virtual SerialPort m_COMMSerialPort
		{
			get
			{
				return this.defaultSerialPort;
			}
			set
			{
				if (this.defaultSerialPort==null)
				{
					this.defaultSerialPort = new SerialPort();
				}
				this.defaultSerialPort = value;
			}
		}

		/// <summary>
		/// 通讯串口的波特率
		/// </summary>
		public virtual int m_COMMBaudRate
		{
			get
			{
				if ((this.defaultSerialPort != null) && (this.defaultSerialPort.IsOpen))
				{
					return this.defaultSerialPort.BaudRate;
				}
				else
				{
					return Convert.ToInt32(this.m_COMMParam.defaultBaudRate);
				}
			}
			set
			{
				if (this.defaultSerialPort != null)
				{
					this.defaultSerialPort.BaudRate = value;
				}
				this.m_COMMParam.defaultBaudRate = value.ToString();
			}
		}

		#endregion

		#region 重载属性

		/// <summary>
		/// 通讯端口
		/// </summary>
		public override string m_COMMName
        {
            get
            {
                return base.m_COMMName;
            }
            set
            {
                base.m_COMMName = value;
            }
        }
	    
        /// <summary>
        /// 通讯端口的索引号
        /// </summary>
        public override int m_COMMIndex
        {
            get
            {
                return base.m_COMMIndex;
            }
            set
            {
                base.m_COMMIndex = value;
            }
        }
	    
        /// <summary>
        /// 通讯端口的工作状态
        /// </summary>
        public override USE_STATE m_COMMSTATE
        {
            get
            {
                return base.m_COMMSTATE;
            }
            set
            {
                base.m_COMMSTATE = value;
            }
        }
	    
        /// <summary>
        /// 写数据的缓存区
        /// </summary>
        public override int m_COMMWriteBufferSize
        {
            get
            {
                return base.m_COMMWriteBufferSize;
            }
            set
            {
                base.m_COMMWriteBufferSize = value;
            }
	    
        }
	    
        /// <summary>
        /// 写数据的校验方式
        /// </summary>
        public override USE_CRC m_COMMWriteCRC
        {
            get
            {
                return base.m_COMMWriteCRC;
            }
            set
            {
                base.m_COMMWriteCRC = value;
            }
        }
	    
        /// <summary>
        /// 写数据的信息
        /// </summary>
        public override COMMDataType m_COMMWriteData
        {
            get
            {
                return base.m_COMMWriteData;
            }
            set
            {
                base.m_COMMWriteData = value;
            }
        }
	    
        /// <summary>
        /// 读数据的缓存区
        /// </summary>
        public override int m_COMMReadBufferSize
        {
            get
            {
                return base.m_COMMReadBufferSize;
            }
            set
            {
                base.m_COMMReadBufferSize = value;
            }
        }
	    
        /// <summary>
        /// 读数据的校验方式
        /// </summary>
        public override USE_CRC m_COMMReadCRC
        {
            get
            {
                return base.m_COMMReadCRC;
            }
            set
            {
                base.m_COMMReadCRC = value;
            }
        }
	    
        /// <summary>
        /// 读数据的信息
        /// </summary>
        public override COMMDataType m_COMMReadData
        {
            get
            {
                return base.m_COMMReadData;
            }
            set
            {
                base.m_COMMReadData = value;
            }
        }
	    
        /// <summary>
        /// 通信耗时
        /// </summary>
        public override TimeSpan m_COMMTime
        {
            get
            {
                return base.m_COMMTime;
            }
            set
            {
                base.m_COMMTime = value;
            }
        }
	    
        /// <summary>
        /// 通讯错误信息
        /// </summary>
        public override string m_COMMErrMsg
        {
            get
            {
                return base.m_COMMErrMsg;
            }
            set
            {
                base.m_COMMErrMsg = value;
            }
        }

		/// <summary>
		/// 使用的窗体
		/// </summary>
		public override Form m_COMMForm
		{
			get
			{
				return base.m_COMMForm;
			}
			set
			{
				base.m_COMMForm = value;
			}
		}

		/// <summary>
		/// 通讯写数据报头
		/// </summary>
		public override byte m_COMMWriteID
        {
            get
            {
                return base.m_COMMWriteID;
            }
            set
            {
                base.m_COMMWriteID = value;
            }
        }
	    
        /// <summary>
        /// 通讯读数据报头
        /// </summary>
        public override byte m_COMMReadID
        {
            get
            {
                return base.m_COMMReadID;
            }
            set
            {
                base.m_COMMReadID = value;
            }
        }
	    
        /// <summary>
        /// 多设备通信是否使能
        /// </summary>
        public override bool m_COMMMultiDevice
        {
            get
            {
                return base.m_COMMMultiDevice;
            }
            set
            {
                base.m_COMMMultiDevice = value;
            }
        }
	    
        /// <summary>
        /// 多设备通讯过程中的设备id号
        /// </summary>
        public override byte m_COMMMultiID
        {
            get
            {
                return base.m_COMMMultiID;
            }
            set
            {
                base.m_COMMMultiID = value;
            }
        }

		/// <summary>
		/// 消息显示窗口
		/// </summary>
		public override RichTextBox m_COMMRichTextBox
		{
			get
			{
				return base.m_COMMRichTextBox;
			}
			set
			{
				base.m_COMMRichTextBox = value;
			}
		}

		/// <summary>
		/// 端口控件
		/// </summary>
		public override ComboBox m_COMMComboBox
		{
			get
			{
				return base.m_COMMComboBox;
			}
			set
			{
				base.m_COMMComboBox = value;
			}
		}	

		/// <summary>
		/// 设置串口参数
		/// </summary>
		public override COMMPortParam m_COMMParam
		{
			get
			{
				return base.m_COMMParam;
			}
			set
			{
				if (base.m_COMMParam == null)
				{
					base.m_COMMParam = new COMMSerialPortParam();
				}
				base.m_COMMParam = value;
			}
		}

		/// <summary>
		/// 数据接收校验结果
		/// </summary>
		public override bool m_COMMReceVerifyPass
		{
			get
			{
				int _return= -1;
				if ((this.m_COMMReadData!=null)&&(this.m_COMMReadData.defaultOriginalByte!=null)&&(this.m_COMMReadData.defaultOriginalByte[0]==this.m_COMMReadID)
					&&(this.m_COMMReadData.defaultParentCMD==this.m_COMMWriteData.defaultParentCMD)
					&&(this.m_COMMReadData.defaultResultFlag==0))
				{
					_return = 0;
				}
				return (_return == 0);
			}
		}

		/// <summary>
		/// 端口开启状态
		/// </summary>
		public override bool m_COMMConnected
		{
			get
			{
				return ((this.IsAttached()) && (this.m_COMMIndex != 0));
			}
		}

		#endregion

		#endregion

		#region 构造函数

		/// <summary>
		/// 无参数构造函数
		/// </summary>
		public COMMSerialPort():base()
		{

		}

		/// <summary>
		/// 传递使用的窗体
		/// </summary>
		/// <param name="argForm"></param>
		public COMMSerialPort(Form argForm):base(argForm)
		{
			this.m_COMMForm = argForm;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		public COMMSerialPort(Form argForm, ComboBox cbb, RichTextBox msg,bool isAddWatcherPort= true)
		{
			this.m_COMMForm = argForm;
			this.m_COMMComboBox = cbb;
			this.m_COMMRichTextBox = msg;
			this.GetPortNames(cbb, msg);
			if (isAddWatcherPort==true)
			{
				this.AddWatcherPort(cbb, msg);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		public COMMSerialPort(Form argForm,string argName,RichTextBox msg)
		{
			this.m_COMMForm = argForm;
			this.Init(argName,msg);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="isMultiDevice"></param>
		/// <param name="multiID"></param>
		/// <param name="msg"></param>
		public COMMSerialPort(bool isMultiDevice, byte multiID, RichTextBox msg)
		{
			this.m_COMMMultiDevice = isMultiDevice;
			this.m_COMMMultiID = multiID;
			this.m_COMMRichTextBox = msg;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		/// <param name="isMultiDevice"></param>
		/// <param name="multiID"></param>
		/// <param name="msg"></param>
		public COMMSerialPort(Form argForm, bool isMultiDevice, byte multiID, RichTextBox msg)
		{
			this.m_COMMForm = argForm;
			this.m_COMMMultiDevice = isMultiDevice;
			this.m_COMMMultiID = multiID;
			this.m_COMMRichTextBox = msg;
		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="bandRate"></param>
		/// <param name="msg"></param>
		public COMMSerialPort(COMMPortParam commPortParam, RichTextBox msg)
		{
			this.Init(commPortParam, msg);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="commPortParam"></param>
		/// <param name="msg"></param>
		public COMMSerialPort(Form argForm, COMMPortParam commPortParam, RichTextBox msg)
		{
			this.m_COMMForm = argForm;
			this.Init(commPortParam, msg);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		/// <param name="multiDevice"></param>
		/// <param name="multiID"></param>
		/// <param name="msg"></param>
		public COMMSerialPort(COMMPortParam commPortParam, bool multiDevice, byte multiID, RichTextBox msg)
		{
			this.Init(commPortParam, msg);
			this.m_COMMMultiDevice = multiDevice;
			this.m_COMMMultiID = multiID;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		/// <param name="multiDevice"></param>
		/// <param name="multiID"></param>
		/// <param name="msg"></param>
		public COMMSerialPort(Form argForm, COMMPortParam commPortParam, bool multiDevice, byte multiID, RichTextBox msg)
		{
			this.m_COMMForm = argForm;
			this.Init(commPortParam, msg);
			this.m_COMMMultiDevice = multiDevice;
			this.m_COMMMultiID = multiID;
		}
		
		#endregion

		#region 析构函数

		/// <summary>
		/// 析构函数
		/// </summary>
		~COMMSerialPort()
		{
			GC.SuppressFinalize(this);
		}

		// 添加此代码以正确实现可处置模式。

		/// <summary>
		/// 
		/// </summary>
		public override void Dispose()
		{
			if (this.defaultSerialPort != null)
			{
				//---释放串口对象
				this.defaultSerialPort.Dispose();
			}
			// 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
			base.Dispose(true);
			// TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
			GC.SuppressFinalize(this);
		}
		
		#endregion

		#region 函数定义

		#region 私有函数

		/// <summary>
		/// 获取校验位信息
		/// </summary>
		/// <param name="parity"></param>
		/// <returns></returns>
		private Parity GetParityBits(string parityBits)
		{
			//---获取校验位
			Parity _return;//= new Parity();

			//---奇校验
			if (parityBits.StartsWith("奇") || parityBits.StartsWith("Odd") || parityBits.StartsWith("ODD") || parityBits.StartsWith("odd") || parityBits.StartsWith("oDD"))
			{
				_return = Parity.Odd;
			}

			//---偶校验
			else if (parityBits.StartsWith("偶") || parityBits.StartsWith("Even") || parityBits.StartsWith("EVEN") || parityBits.StartsWith("even") || parityBits.StartsWith("eVEN"))
			{
				_return = Parity.Even;
			}

			//---无校验位
			else
			{
				_return = Parity.None;
			}
			return _return;
		}

		/// <summary>
		/// 获取停止位
		/// </summary>
		/// <param name="stopBits"></param>
		/// <returns></returns>
		private StopBits GetStopBits(string stopBits)
		{
			//---获取校验位
			StopBits _return;// = new StopBits();
			try
			{
				double stopVal = Math.Truncate(Convert.ToDouble(stopBits));

				int temp = (int)(stopVal * 10);

				//---1位停止位
				if (temp == 10)
				{
					_return = StopBits.One;
				}

				//---1.5位停止位
				else if (temp == 15)
				{
					_return = StopBits.OnePointFive;
				}

				//---2位停止位
				else if (temp == 20)
				{
					_return = StopBits.Two;
				}
				else
				{
					_return = StopBits.None;
				}
			}
			catch
			{
				_return = StopBits.None;
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private List<byte> GetPortIndex( string[] argNames )
		{
			if ((argNames.Length==0)||(argNames==null))
			{
				return null;
			}
			List<byte> temp = new List<byte>();
			List<byte> _return = new List<byte>();
			//---遍历端口信息
			for (int index = 0; index < argNames.Length; index++)
			{
				//---判断端口名称是否合法
				if (argNames[index].StartsWith("COM") || argNames[index].StartsWith("com"))
				{
					//---去除字符串中非数字字符
					string str = Regex.Replace(argNames[index], @"[^\d]*", "");
					//---不获取COM1，一般为系统使用，不可被外部调用操作
					//if (str!="1")
					{
						//---将字符串转换成数字
						temp.Add((byte)(int.Parse(str)));
					}
				}
			}
			//---从到大小排列数据
			_return.AddRange((temp.ToArray().OrderBy(x => x).ToArray()));
			//---返回测试结果
			return _return;
		}

		
		/// <summary>
		/// 发送数据处理函数
		/// </summary>
		/// <param name="cmd"></param>
		private int ProcesseSendData(byte[] cmd)
		{
			int _return = 0;
			UInt32 crcVal;
			//---数据的总长度
			int length ;
			//---数据处理过程中的缓存区
			List<byte> tempCMD = new List<byte>();
			if ((cmd == null) || (cmd.Length == 0))
			{
				_return = 1;
			}
			else
			{
				//---判断发送报头
				if ((cmd[0] == this.m_COMMWriteID))
				{
					//报头合法，是完整的发送数据数据（不包含CRC信息）
					tempCMD.AddRange(cmd);
				}
				else
				{
					//报头不合法，不是完整的数据，需要整理发送数据（不包含CRC信息）
					tempCMD.Add(this.m_COMMWriteID);
					tempCMD.Add(0x00);
					if (this.m_COMMWriteBufferSize > 250)
					{
						tempCMD.Add(0x00);
					}
					//---填充数据
					tempCMD.AddRange(cmd);
				}
				//---进行CRC校验前的数据长度整理
				length = tempCMD.Count;
				if (this.m_COMMWriteBufferSize < 250)
				{
					length -= 2;
					tempCMD[1] = (byte)(length);
				}
				else
				{
					length -= 3;
					tempCMD[1] = (byte)(length >> 8);
					tempCMD[2] = (byte)(length);
				}

				//---判断CRC的模式
				if (this.m_COMMWriteCRC == USE_CRC.CRC_CHECKSUM)
				{
					crcVal = CRCFunc.GenFuncCheckSum(tempCMD.ToArray(), tempCMD.Count);
					tempCMD.Add((byte)crcVal);
				}
				else if (this.m_COMMWriteCRC == USE_CRC.CRC_CRC8)
				{
					crcVal = CRCFunc.GenFuncCRC8Table(CRCFunc.USE_CRC8_Type.USE_CRC8_07H, tempCMD.ToArray(), tempCMD.Count);
					tempCMD.Add((byte)crcVal);
				}
				else if (this.m_COMMWriteCRC == USE_CRC.CRC_CRC16)
				{
					crcVal = CRCFunc.GenFuncCRC16Table(tempCMD.ToArray(), tempCMD.Count);
					tempCMD.Add((byte)(crcVal >> 8));
					tempCMD.Add((byte)crcVal);
				}
				else if (this.m_COMMWriteCRC == USE_CRC.CRC_CRC32)
				{
					crcVal = CRCFunc.GenFuncCRC32Table(tempCMD.ToArray(), tempCMD.Count);
					tempCMD.Add((byte)(crcVal >> 24));
					tempCMD.Add((byte)(crcVal >> 16));
					tempCMD.Add((byte)(crcVal >> 8));
					tempCMD.Add((byte)crcVal);
				}

				//---进行CRC校验后的数据长度整理
				if (this.m_COMMWriteCRC != USE_CRC.CRC_NONE)
				{
					length = tempCMD.Count;
					if (this.m_COMMWriteBufferSize < 250)
					{
						length -= 2;
						tempCMD[1] = (byte)(length);
					}
					else
					{
						length -= 3;
						tempCMD[1] = (byte)(length >> 8);
						tempCMD[2] = (byte)(length);
					}
				}
				//---重新构建发送函数
				this.m_COMMWriteData = new COMMDataType(this.m_COMMWriteBufferSize,this.m_COMMWriteCRC, tempCMD);
			}
			return _return;
		}

		/// <summary>
		/// 数据接收处理函数，数据最大缓存区是1字节即255
		/// </summary>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		private int ProcesseReceivedData8BitsLength(int timeout = 200, RichTextBox msg = null)
		{
			int _return = 0;
			//---获取开始时间标签
			DateTime nowTime = DateTime.Now;
			//---接收缓存区
			List<byte> cmd = new List<byte>();
			//---接收数据步序
			byte taskStep = 0;
			//---时间计数器
			DateTime startTime = DateTime.Now;
			//---数据存储的临时变量
			int temp ;
			//---通信端口为接收状态,不响应其他操作(阻塞操作)
			bool isWork = true;
			//---清空错误消息
			this.m_COMMErrMsg = string.Empty;
			//---工作状态是忙碌
			this.m_COMMSTATE = USE_STATE.POLL_READ;
			// CRC的计算结果
			UInt32 crcVal = 0;
			//---数据的读取---阻塞读取
			while (isWork)
			{
				switch (taskStep)
				{
					case 0:         //---获取数据报头
						if (this.defaultSerialPort.BytesToRead > 0)
						{
							temp = this.defaultSerialPort.ReadByte();
							//---读取报头
							if ((byte)temp == this.m_COMMReadID)
							{
								//---保存数据
								cmd.Add((byte)temp);
								//---进入下一任务
								taskStep = 1;
								//---重置时间标签
								startTime = DateTime.Now;
							}
						}
						break;

					case 1:         //---获取数据长度
						if (this.defaultSerialPort.BytesToRead > 0)
						{
							//---读取接收到的数据
							temp = this.defaultSerialPort.ReadByte();
							//---数据长度的合法性验证
							if ((temp > 0) && (temp < (this.m_COMMReadBufferSize - 1)))
							{
								//---数据长度合法，接收数据长度
								cmd.Add((byte)temp);
								//---进入下一任务
								taskStep = 2;
								//---重置时间标签
								startTime = DateTime.Now;
							}
							else
							{
								//---数据长度不合法，重新接收数据
								cmd.Clear();
								taskStep = 0;
							}
						}
						break;

					case 2:         //---获取数据
						if (this.defaultSerialPort.BytesToRead > 0)
						{
							//---读取接收到的数据
							temp = this.defaultSerialPort.ReadByte();
							cmd.Add((byte)temp);
							//---重置时间标签
							startTime = DateTime.Now;
						}
						break;

					case 3:
					default:
						isWork = false;
						this.m_COMMErrMsg = "接收数据的逻辑异常。\r\n";
						_return = 1;
						break;
				}

				//---计算时间
				TimeSpan endTime = DateTime.Now - startTime;
				//---判断是否发生超时错误
				if (endTime.TotalMilliseconds > timeout)
				{
					//---退出while循环
					isWork = false;
					this.m_COMMErrMsg = "接收数据发生超市错误!\r\n";
					_return = 2;
					break;
				}

				//---判断接收到的数据
				if ((_return==0)&&(taskStep == 2) && (cmd != null) && (cmd.Count > 2) && ((cmd.Count - 2) == cmd[1]))
				{
					//---退出当前while循环
					isWork = false;
					break;
				}
				//---响应其他应用
				Application.DoEvents();
			}
			//---判断接收的数据
			if ((_return == 0) && (taskStep == 2) && (isWork == false) && (cmd.Count > 2))
			{
				bool myChildCMD = false;
				//---数据整理
				if (this.m_COMMReadData==null)
				{
					this.m_COMMReadData = new COMMDataType(this.m_COMMReadBufferSize,this.m_COMMReadCRC, cmd, ref myChildCMD);
				}
				else
				{
					this.m_COMMReadData.Init(this.m_COMMReadBufferSize, this.m_COMMReadCRC, cmd,ref myChildCMD);
				}
				this.m_COMMChildCMD = myChildCMD;
				//---计算CRC的值
				if (this.m_COMMReadCRC==USE_CRC.CRC_CHECKSUM)
				{
					crcVal = LabUserGenFunc.CRCFunc.GenFuncCheckSum(this.m_COMMReadData.defaultRealityByte.ToArray(),
						this.m_COMMReadData.defaultRealityByte.Count);
				}
				else if (this.m_COMMReadCRC == USE_CRC.CRC_CRC8)
				{
					crcVal = LabUserGenFunc.CRCFunc.GenFuncCRC8Table(CRCFunc.USE_CRC8_Type.USE_CRC8_07H,this.m_COMMReadData.defaultRealityByte.ToArray(),
						this.m_COMMReadData.defaultRealityByte.Count);
				}
				else if (this.m_COMMReadCRC == USE_CRC.CRC_CRC16)
				{
					crcVal = LabUserGenFunc.CRCFunc.GenFuncCRC16Table(this.m_COMMReadData.defaultRealityByte.ToArray(),
						this.m_COMMReadData.defaultRealityByte.Count);
				}
				else if (this.m_COMMReadCRC == USE_CRC.CRC_CRC32)
				{
					crcVal = LabUserGenFunc.CRCFunc.GenFuncCRC16Table(this.m_COMMReadData.defaultRealityByte.ToArray(),
						this.m_COMMReadData.defaultRealityByte.Count);
				}

				//---校验CRC
				if (this.m_COMMReadCRC!=USE_CRC.CRC_NONE)
				{
					if (this.m_COMMReadData.defaultCRCVal!=crcVal)
					{
						this.m_COMMErrMsg = "接收数据发生CRC校验错误。\r\n";
						_return = 3;
					}
				}
			}
			if ((_return!=0)&&(msg!=null))
			{
				RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Red, false);
			}
			//---工作状态是忙碌
			this.m_COMMSTATE = USE_STATE.IDLE;
			//---清空接收缓存区
			this.defaultSerialPort.DiscardInBuffer();
			//---清空发送缓存区
			this.defaultSerialPort.DiscardOutBuffer();
			//---计算本次读取的耗时时间
			this.m_COMMTime = DateTime.Now - nowTime;
			return _return;
		}

		/// <summary>
		/// 数据接收处理函数，数据最大缓存区是2字节即65535
		/// </summary>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		private int ProcesseReceivedData16BitsLength(int timeout = 200, RichTextBox msg = null)
		{
			int _return = 0;
			//---获取开始时间标签
			DateTime nowTime = DateTime.Now;
			//---接收缓存区
			List<byte> cmd = new List<byte>();
			//---接收数据步序
			byte taskStep = 0;
			//---时间计数器
			DateTime startTime = DateTime.Now;
			//---数据存储的临时变量
			int temp = 0;
			//---通信端口为接收状态,不响应其他操作(阻塞操作)
			bool isWork = true;
			//---清空错误消息
			this.m_COMMErrMsg = string.Empty;
			//---工作状态是忙碌
			this.m_COMMSTATE = USE_STATE.POLL_READ;
			// CRC的计算结果
			UInt32 crcVal = 0;
			//---数据的读取---阻塞读取
			while (isWork)
			{
				switch (taskStep)
				{
					case 0:         //---获取数据报头
						if (this.defaultSerialPort.BytesToRead > 0)
						{
							temp = this.defaultSerialPort.ReadByte();
							//---读取报头
							if ((byte)temp == this.m_COMMReadID)
							{
								//---保存数据
								cmd.Add((byte)temp);
								//---接收数据长度高字节
								taskStep = 1;
								//---重置时间标签
								startTime = DateTime.Now;
							}
						}
						break;
					case 1:             //---获取数据长度高位
						if (this.defaultSerialPort.BytesToRead > 0)
						{
							temp = this.defaultSerialPort.ReadByte();
							//---保存数据
							cmd.Add((byte)temp);
							//---接收数据长度低字节
							taskStep = 2;
							//---重置时间标签
							startTime = DateTime.Now;
						}
						break;
					case 2:				//---获取数据长度低位
						if (this.defaultSerialPort.BytesToRead > 0)
						{
							//---读取接收到的数据
							temp =(temp<<8)+ this.defaultSerialPort.ReadByte();
							//---数据长度的合法性验证
							if ((temp > 0) && (temp < (this.m_COMMReadBufferSize - 1)))
							{
								//---数据长度合法，接收数据长度
								cmd.Add((byte)temp);
								//---接收数据
								taskStep = 3;
								//---重置时间标签
								startTime = DateTime.Now;
							}
							else
							{
								//---数据长度不合法，重新接收数据
								cmd.Clear();
								taskStep = 0;
							}
						}
						break;
					case 3:         //---获取数据
						if (this.defaultSerialPort.BytesToRead > 0)
						{
							//---读取接收到的数据
							temp = this.defaultSerialPort.ReadByte();
							cmd.Add((byte)temp);
							//---重置时间标签
							startTime = DateTime.Now;
						}
						break;

					case 4:
					default:
						isWork = false;
						this.m_COMMErrMsg = "接收数据的逻辑异常。\r\n";
						_return = 1;
						break;
				}

				//---计算时间
				TimeSpan endTime = DateTime.Now - startTime;
				//---判断是否发生超时错误
				if (endTime.TotalMilliseconds > timeout)
				{
					//---退出while循环
					isWork = false;
					this.m_COMMErrMsg = "接收数据发生超市错误!\r\n";
					_return = 2;
					break;
				}

				//---判断接收到的数据
				if ((_return == 0) && (taskStep == 3) && (cmd != null) && (cmd.Count > 2))
				{
					int length = cmd[1];
					length = (length << 8) + cmd[2];
					if (length==(cmd.Count-3))
					{
						//---退出当前while循环
						isWork = false;
						break;
					}
				}
				//---响应其他应用
				Application.DoEvents();
			}
			//---判断接收的数据
			if ((_return == 0) && (taskStep == 3) && (isWork == false) && (cmd.Count > 2))
			{
				bool myChildCMD = false;
				//---数据整理
				if (this.m_COMMReadData == null)
				{
					this.m_COMMReadData = new COMMDataType(this.m_COMMReadBufferSize, this.m_COMMReadCRC, cmd, ref myChildCMD);
				}
				else
				{
					this.m_COMMReadData.Init(this.m_COMMReadBufferSize, this.m_COMMReadCRC, cmd, ref myChildCMD);
				}
				this.m_COMMChildCMD = myChildCMD;
				//---计算CRC的值
				if (this.m_COMMReadCRC == USE_CRC.CRC_CHECKSUM)
				{
					crcVal = LabUserGenFunc.CRCFunc.GenFuncCheckSum(this.m_COMMReadData.defaultRealityByte.ToArray(),
						this.m_COMMReadData.defaultRealityByte.Count);
				}
				else if (this.m_COMMReadCRC == USE_CRC.CRC_CRC8)
				{
					crcVal = LabUserGenFunc.CRCFunc.GenFuncCRC8Table(CRCFunc.USE_CRC8_Type.USE_CRC8_07H, this.m_COMMReadData.defaultRealityByte.ToArray(),
						this.m_COMMReadData.defaultRealityByte.Count);
				}
				else if (this.m_COMMReadCRC == USE_CRC.CRC_CRC16)
				{
					crcVal = LabUserGenFunc.CRCFunc.GenFuncCRC16Table(this.m_COMMReadData.defaultRealityByte.ToArray(),
						this.m_COMMReadData.defaultRealityByte.Count);
				}
				else if (this.m_COMMReadCRC == USE_CRC.CRC_CRC32)
				{
					crcVal = LabUserGenFunc.CRCFunc.GenFuncCRC16Table(this.m_COMMReadData.defaultRealityByte.ToArray(),
						this.m_COMMReadData.defaultRealityByte.Count);
				}

				//---校验CRC
				if (this.m_COMMReadCRC != USE_CRC.CRC_NONE)
				{
					if (this.m_COMMReadData.defaultCRCVal != crcVal)
					{
						this.m_COMMErrMsg = "接收数据发生CRC校验错误。\r\n";
						_return = 3;
					}
				}
			}
			if ((_return != 0) && (msg != null))
			{
				RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Red, false);
			}
			//---工作状态是忙碌
			this.m_COMMSTATE = USE_STATE.IDLE;
			//---清空接收缓存区
			this.defaultSerialPort.DiscardInBuffer();
			//---清空发送缓存区
			this.defaultSerialPort.DiscardOutBuffer();
			//---计算本次读取的耗时时间
			this.m_COMMTime = DateTime.Now - nowTime;
			return _return;
		}

		#endregion

		#region 重载函数

		/// <summary>
		/// 初始化
		/// </summary>
		/// <returns></returns>
		public override int Init()
		{
			base.Init();
			if (this.defaultSerialPort == null)
			{
				this.defaultSerialPort = new SerialPort();
			}
			if (this.defaultSerialPort.IsOpen)
			{
				this.defaultSerialPort.Close();
			}
			this.m_COMMIndex = 0;
			this.m_COMMName = null;
			return -1;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int Init(ComboBox cbb, RichTextBox msg =null)
		{
			this.GetPortNames(cbb, msg);
			return 0;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <returns></returns>
		public override int Init(string argName, RichTextBox msg = null)
		{
			if (this.defaultSerialPort==null)
			{
				this.defaultSerialPort = new SerialPort();
			}
			if (this.defaultSerialPort.IsOpen)
			{
				this.defaultSerialPort.Close();
			}
			this.defaultSerialPort.PortName = argName;
			//---端口名称
			this.m_COMMName = argName;
			this.m_COMMParam.defaultName = this.m_COMMName;
			//---获取端口序号
			this.m_COMMIndex = Convert.ToInt16(this.m_COMMName.Replace("COM", ""), 10);

			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="bandRate"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int Init(string argName, int bandRate, RichTextBox msg = null)
		{
			if (this.defaultSerialPort == null)
			{
				this.defaultSerialPort = new SerialPort();
			}
			if (this.defaultSerialPort.IsOpen)
			{
				this.defaultSerialPort.Close();
			}
			this.defaultSerialPort.PortName = argName;
			this.defaultSerialPort.BaudRate = bandRate;
			this.m_COMMParam.defaultName = this.m_COMMName;
			this.m_COMMParam.defaultBaudRate = bandRate.ToString();
			//---端口名称
			this.m_COMMName = argName;
			//---获取端口序号
			this.m_COMMIndex = Convert.ToInt16(this.m_COMMName.Replace("COM", ""), 10);

			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="commPortParam"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int Init(COMMPortParam commPortParam, RichTextBox msg = null)
		{
			if (this.defaultSerialPort == null)
			{
				this.defaultSerialPort = new SerialPort();
			}
			if (this.defaultSerialPort.IsOpen)
			{
				this.defaultSerialPort.Close();
			}

			//---配置串口参数
			this.defaultSerialPort.PortName = commPortParam.defaultName;
			this.defaultSerialPort.BaudRate = int.Parse(commPortParam.defaultBaudRate);
			this.defaultSerialPort.Parity = this.GetParityBits(commPortParam.defaultParity);
			this.defaultSerialPort.StopBits = this.GetStopBits(commPortParam.defaultStopBits);
			this.defaultSerialPort.DataBits = int.Parse(commPortParam.defaultDataBits);

			if (this.m_COMMParam==null)
			{
				this.m_COMMParam = new COMMSerialPortParam();
			}
			//---保存串口参数
			this.m_COMMParam =commPortParam;

			//---端口名称
			this.m_COMMName = commPortParam.defaultName;
			//---获取端口序号
			this.m_COMMIndex = Convert.ToInt16(this.m_COMMName.Replace("COM", ""), 10);

			return 0;
		}
		/// <summary>
		/// 获取设备的端口
		/// </summary>
		public override void GetPortNames(ComboBox cbb, RichTextBox msg = null)
		{
			//---获取当前设备的端口
			string[] argNames = SerialPort.GetPortNames();
			if ((argNames == null) || (argNames.Length == 0))
			{
				this.defaultIndexMemu = new List<byte>();
				if (cbb != null)
				{
					//---异步调用
					if (cbb.InvokeRequired)
					{
						cbb.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 cbb.Items.Clear();
									 cbb.SelectedIndex = -1;
								 }));
					}
					else
					{
						cbb.Items.Clear();
						cbb.SelectedIndex = -1;
					}
				}
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "获取设备失败，请插入设备！\r\n", Color.Red, false);
				}
			}
			else
			{
				this.defaultIndexMemu = this.GetPortIndex(argNames);
				if (cbb != null)
				{
					//---异步调用
					if (cbb.InvokeRequired)
					{
						cbb.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 cbb.Items.Clear();
									 for (int i = 0; i < this.defaultIndexMemu.Count; i++)
									 {
										 cbb.Items.Add("COM" + this.defaultIndexMemu[i].ToString());
									 }
									 cbb.SelectedIndex = 0;
								 }));
					}
					else
					{
						cbb.Items.Clear();
						for (int i = 0; i < this.defaultIndexMemu.Count; i++)
						{
							cbb.Items.Add("COM" + this.defaultIndexMemu[i].ToString());
						}
						cbb.SelectedIndex = 0;
					}
				}
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "获取设备成功，请选择设备！\r\n", Color.Black, false);
				}
			}

		}

		/// <summary>
		/// 设置多设备通信
		/// </summary>
		/// <param name="multiDevice"></param>
		/// <param name="multiID"></param>
		/// <returns></returns>
		public override void SetMultiDevice(bool multiDevice, byte multiID)
		{
			this.m_COMMMultiDevice = multiDevice;
			this.m_COMMMultiID = multiID;
		}

		/// <summary>
		/// 设备从设备的ID信息
		/// </summary>
		/// <param name="multiID"></param>
		public override void SetMultiID(byte multiID)
		{
			this.m_COMMMultiID = multiID;
		}
		/// <summary>
		/// 清除多设备模式
		/// </summary>
		public override void ClearMultiDevice()
		{
			this.m_COMMMultiDevice = false;
			this.m_COMMMultiID = 0;
		}

		/// <summary>
		/// 添加监控设备
		/// </summary>
		/// <returns></returns>
		public override bool AddWatcherPort(ComboBox cbb=null, RichTextBox msg=null)
		{
			this.m_COMMComboBox = cbb;
			this.m_COMMRichTextBox = msg;
			return base.AddWatcherPortEvent(this.WatcherPortEventHandler, this.WatcherPortEventHandler, new TimeSpan(0, 0, 1));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override bool AddWatcherPort(Form argForm, ComboBox cbb = null, RichTextBox msg = null)
		{
			this.m_COMMForm = argForm;
			this.m_COMMComboBox = cbb;
			this.m_COMMRichTextBox = msg;
			return base.AddWatcherPortEvent(this.WatcherPortEventHandler, this.WatcherPortEventHandler, new TimeSpan(0, 0, 1));
		}

		/// <summary>
		/// 添加设备
		/// </summary>
		/// <returns></returns>
		public override int AddDevice()
		{
			return this.AddDevice(null,null);
		}

		/// <summary>
		/// 添加设备
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int AddDevice(ComboBox cbb, RichTextBox msg = null)
		{
			int _return = 0;
			//---获取当前设备存在的通信端口
			List<byte> addNames = this.GetPortIndex( SerialPort.GetPortNames());
			//---检查
			if ((addNames == null) || (addNames.Count == 0))
			{
				this.defaultIndexMemu = new List<byte>();
				if (cbb != null)
				{
					//---异步调用
					if (cbb.InvokeRequired)
					{
						cbb.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 cbb.Items.Clear();
									 cbb.SelectedIndex = -1;
								 }));
					}
					else
					{
						cbb.Items.Clear();
						cbb.SelectedIndex = -1;
					}
				}
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "获取设备失败，请插入设备！\r\n", Color.Red, false);
				}
			}
			else
			{
				int portIndex = -1;
				int i = 0;
				
				//---遍历是哪个设备插入
				for ( i = 0; i < addNames.Count; i++)
				{
					if ((this.defaultIndexMemu!=null)&&(this.defaultIndexMemu.Count>0))
					{
						//---查询是哪个设备插入
						portIndex = this.defaultIndexMemu.IndexOf(addNames[i]);
					}
					//---UI显示插入的设备
					if (portIndex<0)
					{
						if (msg != null)
						{
							RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "COM" + addNames[i].ToString() + "设备插入！\r\n", Color.Black, false);
						}
					}
				}

				portIndex = -1;

				List<byte> addDevice = new List<byte>();

 				if (cbb!=null)
				{
					//---异步调用
					if (cbb.InvokeRequired)
					{
						cbb.Invoke((EventHandler)
									 (delegate
									 {
										 portIndex = cbb.SelectedIndex;
									 }));
					}
					else
					{
						portIndex = cbb.SelectedIndex;
					}
				}

				if ((this.defaultIndexMemu.Count!=0)&&(portIndex>=0))
				{
					portIndex = this.defaultIndexMemu[portIndex];
				}



				this.defaultIndexMemu = new List<byte>();
				this.defaultIndexMemu.AddRange(addNames.ToArray());

				if (this.defaultIndexMemu.Count != 0)
				{
					if (portIndex<0)
					{
						portIndex = 0;
					}
					else
					{
						portIndex = this.defaultIndexMemu.IndexOf((byte)portIndex);
					}
					
				}
				
				if (cbb != null)
				{
					//---异步调用
					if (cbb.InvokeRequired)
					{
						cbb.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 cbb.Items.Clear();
									 for (i = 0; i < this.defaultIndexMemu.Count; i++)
									 {
										 cbb.Items.Add("COM" + this.defaultIndexMemu[i].ToString());
									 }
									 cbb.SelectedIndex = portIndex;
								 }));
					}
					else
					{
						cbb.Items.Clear();
						for (i = 0; i < this.defaultIndexMemu.Count; i++)
						{
							cbb.Items.Add("COM" + this.defaultIndexMemu[i].ToString());
						}
						cbb.SelectedIndex = portIndex;
					}
				}
			}
			return _return;
		}

		/// <summary>
		/// 移除设备
		/// </summary>
		/// <returns></returns>
		public override int RemoveDevice()
		{
			return this.RemoveDevice(null,null);
		}

		/// <summary>
		/// 移除设备
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int RemoveDevice(ComboBox cbb, RichTextBox msg = null)
		{
			int _return = 0;
			//---获取当前设备存在的通信端口
			List<byte> addNames = this.GetPortIndex(SerialPort.GetPortNames());
			if ((addNames == null) || (addNames.Count == 0))
			{
				this.defaultIndexMemu = new List<byte>();
				if (cbb != null)
				{
					//---异步调用
					if (cbb.InvokeRequired)
					{
						cbb.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 cbb.Items.Clear();
									 cbb.SelectedIndex = -1;
								 }));
					}
					else
					{
						cbb.Items.Clear();
						cbb.SelectedIndex = -1;
					}
				}
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "获取设备失败，请插入设备！\r\n", Color.Red, false);
				}
			}
			else
			{
				int portIndex = -1;
				int i = 0;

				//---遍历是哪个设备插入
				for (i = 0; i < this.defaultIndexMemu.Count; i++)
				{
					//---查询是哪个设备插入
					portIndex = addNames.IndexOf(this.defaultIndexMemu[i]);
					//---UI显示插入的设备
					if (portIndex < 0)
					{
						if (this.defaultIndexMemu[i]==this.m_COMMIndex)
						{
							this.m_COMMIndex = 0;
							this.m_COMMName = "";
						}
						if (msg != null)
						{
							RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "COM" + this.defaultIndexMemu[i].ToString() + "设备移除！\r\n", Color.Red, false);
						}
					}
				}

				portIndex = -1;

				List<byte> addDevice = new List<byte>();

				if (cbb != null)
				{
					//---异步调用
					if (cbb.InvokeRequired)
					{
						cbb.Invoke((EventHandler)
									 (delegate
									 {
										 portIndex = cbb.SelectedIndex;
									 }));
					}
					else
					{
						portIndex = cbb.SelectedIndex;
					}
				}

				if ((this.defaultIndexMemu.Count != 0)&&(portIndex>=0))
				{
					portIndex = this.defaultIndexMemu[portIndex];
				}



				this.defaultIndexMemu = new List<byte>();
				this.defaultIndexMemu.AddRange(addNames.ToArray());

				if (this.defaultIndexMemu.Count != 0)
				{
					if (portIndex < 0)
					{
						portIndex = 0;
					}
					else
					{
						portIndex = this.defaultIndexMemu.IndexOf((byte)portIndex);
						if (portIndex<0)
						{
							portIndex = 0;
						}
					}

				}

				if (cbb != null)
				{
					//---异步调用
					if (cbb.InvokeRequired)
					{
						cbb.BeginInvoke((EventHandler)
						//cbb.Invoke((EventHandler)
								 (delegate
								 {
									 cbb.Items.Clear();
									 for (i = 0; i < this.defaultIndexMemu.Count; i++)
									 {
										 cbb.Items.Add("COM" + this.defaultIndexMemu[i].ToString());
									 }
									 cbb.SelectedIndex = portIndex;
								 }));
					}
					else
					{
						cbb.Items.Clear();
						for (i = 0; i < this.defaultIndexMemu.Count; i++)
						{
							cbb.Items.Add("COM" + this.defaultIndexMemu[i].ToString());
						}
						cbb.SelectedIndex = portIndex;
					}
				}
			}
			//---判断设备是否为空
			if (this.defaultIndexMemu.Count==0)
			{
				//---释放端口
				if ((this.defaultSerialPort != null) && (this.m_COMMIndex != 0))
				{
					//---端口状态，空闲
					this.m_COMMSTATE = USE_STATE.IDLE;
					//---关闭端口
					this.defaultSerialPort.Close();
					this.m_COMMName = null;
					this.m_COMMIndex = 0;
				}
			}
			return _return;
		}

		/// <summary>
		/// 刷新设备
		/// </summary>
		/// <returns></returns>
		public override int RefreshDevice()
		{
			return RefreshDevice(null,null);
		}

		/// <summary>
		/// 刷新设备
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int RefreshDevice(ComboBox cbb, RichTextBox msg = null)
		{
			int _return = 0;
			int i = 0;
			//---获取当前设备存在的通信端口
			List<byte> addNames = this.GetPortIndex(SerialPort.GetPortNames());
			//---判断端口
			if ((addNames == null) || (addNames.Count == 0))
			{
				this.defaultIndexMemu = new List<byte>();
				if (cbb != null)
				{
					//---异步调用
					if (cbb.InvokeRequired)
					{
						cbb.BeginInvoke((EventHandler)
						//cbb.Invoke((EventHandler)
								(delegate
								 {
									 cbb.Items.Clear();
									 cbb.SelectedIndex = -1;
								 }));
					}
					else
					{
						cbb.Items.Clear();
						cbb.SelectedIndex = -1;
					}
				}
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "获取设备失败，请插入设备！\r\n", Color.Red, false);
				}
			}
			else
			{
				int portIndex = -1;
				if (cbb != null)
				{
					//---异步调用
					if (cbb.InvokeRequired)
					{
						cbb.Invoke((EventHandler)
									 (delegate
									 {
										 portIndex = cbb.SelectedIndex;
									 }));
					}
					else
					{
						portIndex = cbb.SelectedIndex;
					}
				}

				if ((this.defaultIndexMemu.Count != 0) && (portIndex >= 0))
				{
					portIndex = this.defaultIndexMemu[portIndex];
				}

				this.defaultIndexMemu = new List<byte>();
				this.defaultIndexMemu.AddRange(addNames.ToArray());

				if (this.defaultIndexMemu.Count != 0)
				{
					if (portIndex < 0)
					{
						portIndex = 0;
					}
					else
					{
						portIndex = this.defaultIndexMemu.IndexOf((byte)portIndex);
						if (portIndex < 0)
						{
							portIndex = 0;
						}
					}

				}

				if (cbb != null)
				{
					//---异步调用
					if (cbb.InvokeRequired)
					{
						cbb.BeginInvoke((EventHandler)
						//cbb.Invoke((EventHandler)
								 (delegate
								 {
									 cbb.Items.Clear();
									 for (i = 0; i < this.defaultIndexMemu.Count; i++)
									 {
										 cbb.Items.Add("COM" + this.defaultIndexMemu[i].ToString());
									 }
									 cbb.SelectedIndex = portIndex;
								 }));
					}
					else
					{
						cbb.Items.Clear();
						for (i = 0; i < this.defaultIndexMemu.Count; i++)
						{
							cbb.Items.Add("COM" + this.defaultIndexMemu[i].ToString());
						}
						cbb.SelectedIndex = portIndex;
					}
				}
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "刷新设备成功，请选择设备！\r\n", Color.Black, false);
				}
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(byte cmd, RichTextBox msg = null)
		{
			int _return = 0;
			if ((this.defaultSerialPort != null) && (this.defaultSerialPort.IsOpen))
			{
				//---等待发送完成
				while (this.defaultSerialPort.BytesToWrite > 0)
				{
					//---响应窗体函数
					Application.DoEvents();
				}
				byte[] tempCmd = new byte[] { cmd };
				//---发送数据
				this.defaultSerialPort.Write(tempCmd, 0, tempCmd.Length);
				//---发送消息
				this.m_COMMErrMsg = "数据发送成功\r\n";
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Black, false);
				}
			}
			else
			{
				_return = 1;
				MessageBoxPlus.Show(this.m_COMMForm, "端口初始化失败或则端口为打开！！！", "错误提示");
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(string cmd, RichTextBox msg = null)
		{
			int _return = 0;
			if ((this.defaultSerialPort != null) && (this.defaultSerialPort.IsOpen))
			{
				//---等待发送完成
				while (this.defaultSerialPort.BytesToWrite > 0)
				{
					//---响应窗体函数
					Application.DoEvents();
				}
				if (this.m_COMMWriteData==null)
				{
					this.m_COMMWriteData = new COMMDataType();
				}
				this.m_COMMWriteData.Init();
				this.m_COMMWriteData.defaultString = cmd;
				//---发送数据
				this.defaultSerialPort.Write(cmd);
				//---发送消息
				this.m_COMMErrMsg = "数据发送成功\r\n";
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Black, false);
				}
			}
			else
			{
				_return = 1;
				MessageBoxPlus.Show(this.m_COMMForm, "端口初始化失败或则端口为打开！！！", "错误提示");
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(string argName, byte cmd, RichTextBox msg = null)
		{
			int _return = 1;
			if (argName != this.m_COMMName)
			{
				//---发送消息
				this.m_COMMErrMsg = "发送：通信端口不匹配！\r\n";
				//---消息提示
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Red, false);
				}
			}
			else
			{
				_return = this.WriteToDevice(cmd, msg);
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(string argName, string cmd, RichTextBox msg = null)
		{
			int _return = 1;
			if (argName != this.m_COMMName)
			{
				//---发送消息
				this.m_COMMErrMsg = "发送：通信端口不匹配！\r\n";
				//---消息提示
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Red, false);
				}
			}
			else
			{
				_return = this.WriteToDevice(cmd, msg);
			}
			return _return;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(byte[] cmd, RichTextBox msg = null)
		{
			int _return;//= 1;
			if ((this.defaultSerialPort != null) && (this.defaultSerialPort.IsOpen))
			{
				//---等待发送完成
				while (this.defaultSerialPort.BytesToWrite > 0)
				{
					//---响应窗体函数
					Application.DoEvents();
				}
				//---处理发送数据
				_return= this.ProcesseSendData(cmd);
				if (_return!=0)
				{
					//---发送消息
					this.m_COMMErrMsg = "发送数据处理错误！\r\n";
					//---消息提示
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Red, false);
					}
				}
				else
				{
					//---发送数据
					this.defaultSerialPort.Write(this.m_COMMWriteData.defaultOriginalByte.ToArray(), 0, this.m_COMMWriteData.defaultOriginalByte.Count);
					//---发送消息
					this.m_COMMErrMsg = "数据发送成功！\r\n";
					//---消息提示
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Black, false);
					}
				}
				
			}
			else
			{
				_return = 1;
				MessageBoxPlus.Show(this.m_COMMForm, "端口初始化失败或则端口为打开！！！", "错误提示");
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(ref byte[] cmd, RichTextBox msg = null)
		{
			int _return;//= 1;
			if ((this.defaultSerialPort != null) && (this.defaultSerialPort.IsOpen))
			{
				//---等待发送完成
				while (this.defaultSerialPort.BytesToWrite > 0)
				{
					//---响应窗体函数
					Application.DoEvents();
				}
				//---处理发送数据
				_return = this.ProcesseSendData(cmd);
				if (_return != 0)
				{
					//---发送消息
					this.m_COMMErrMsg = "发送数据处理错误！\r\n";
					//---消息提示
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Red, false);
					}
				}
				else
				{
					//---整理之后的发送数据
					cmd = new byte[this.m_COMMWriteData.defaultOriginalByte.Count];
					this.m_COMMWriteData.defaultOriginalByte.CopyTo(cmd);
					//---发送数据
					this.defaultSerialPort.Write(this.m_COMMWriteData.defaultOriginalByte.ToArray(), 0, this.m_COMMWriteData.defaultOriginalByte.Count);
					//---发送消息
					this.m_COMMErrMsg = "数据发送成功！\r\n";
					//---消息提示
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Black, false);
					}
				}
			}
			else
			{
				_return = 1;
				MessageBoxPlus.Show(this.m_COMMForm, "端口初始化失败或则端口为打开！！！", "错误提示");
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(string argName, byte[] cmd, RichTextBox msg = null)
		{
			int _return = 1;
			if (argName!=this.m_COMMName)
			{
				//---发送消息
				this.m_COMMErrMsg = "发送：通信端口不匹配！\r\n";
				//---消息提示
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Red, false);
				}
			}
			else
			{
				_return = this.WriteToDevice(cmd, msg);
			}
			return _return;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(string argName, ref byte[] cmd, RichTextBox msg = null)
		{
			int _return = 0;
			if (argName != this.m_COMMName)
			{
				//---发送消息
				this.m_COMMErrMsg = "发送：通信端口不匹配！\r\n";
				//---消息提示
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Red, false);
				}
			}
			else
			{
				_return = this.WriteToDevice( ref cmd, msg);
			}
			return _return;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="argIndex"></param>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(int argIndex, ref byte[] cmd, RichTextBox msg = null)
		{
			int _return = 0;
			if (argIndex != this.m_COMMIndex)
			{
				//---发送消息
				this.m_COMMErrMsg = "发送：通信端口不匹配！\r\n";
				//---消息提示
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Red, false);
				}
			}
			else
			{
				_return = this.WriteToDevice(ref cmd, msg);
			}
			return _return;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int ReadFromDevice(ref byte[] cmd, int timeout = 200, RichTextBox msg = null)
		{
			int _return=1;
			if ((this.defaultSerialPort == null) || (this.defaultSerialPort.PortName != this.m_COMMName) || (this.defaultSerialPort.IsOpen == false))
			{
				//---发送消息
				this.m_COMMErrMsg = "接收：通信端口异常！\r\n";
				//---消息提示
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Red, false);
				}
			}
			else
			{
				if (this.m_COMMReadBufferSize < 250)
				{
					_return = this.ProcesseReceivedData8BitsLength(timeout, msg);
				}
				else
				{
					_return = this.ProcesseReceivedData16BitsLength(timeout, msg);
				}
				if ((this.m_COMMReadData.defaultOriginalByte != null) && (this.m_COMMReadData.defaultOriginalByte.Count > 0))
				{
					cmd = new byte[this.m_COMMReadData.defaultOriginalByte.Count];
					this.m_COMMReadData.defaultOriginalByte.CopyTo(cmd);
				}
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int ReadFromDevice(ref string cmd, int timeout = 200, RichTextBox msg = null)
		{
			int _return = 1;
			//---时间计数器
			DateTime startTime = DateTime.Now;
			//---计算时间
			TimeSpan endTime = DateTime.Now - startTime;
			List<string> res = new List<string>();
			bool isWork = true;

			if ((this.defaultSerialPort == null) || (this.defaultSerialPort.PortName != this.m_COMMName) || (this.defaultSerialPort.IsOpen == false))
			{
				//---发送消息
				this.m_COMMErrMsg = "接收：通信端口异常！\r\n";
				//---消息提示
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Red, false);
				}
			}
			else
			{
				while (isWork)
				{
					//---读取数据流
					if (this.defaultSerialPort.BytesToRead > 0)
					{
						res.Add(this.defaultSerialPort.ReadExisting());
					}
					else
					{
						isWork = false;
						_return = 0;
						break;
					}
					//---判断是否发生超时错误
					if (endTime.TotalMilliseconds > timeout)
					{
						//---退出while循环
						isWork = false;
						this.m_COMMErrMsg = "接收数据发生超市错误!\r\n";
						_return = 2;
						break;
					}
					Application.DoEvents();
				}
				//---判断接收数据的结果
				if (_return == 0)
				{
					cmd = res.ToString();
				}
				else
				{
					cmd = string.Empty;
				}
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int ReadFromDevice(int timeout = 200, RichTextBox msg = null)
		{
			int _return= 1;
			if ((this.defaultSerialPort == null) || (this.defaultSerialPort.PortName != this.m_COMMName) || (this.defaultSerialPort.IsOpen == false))
			{
				//---发送消息
				this.m_COMMErrMsg = "接收：通信端口异常！\r\n";
				//---消息提示
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Red, false);
				}
			}
			else
			{
				if (this.m_COMMReadBufferSize < 250)
				{
					_return = this.ProcesseReceivedData8BitsLength(timeout, msg);
				}
				else
				{
					_return = this.ProcesseReceivedData16BitsLength(timeout, msg);
				}
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argIndex"></param>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int ReadFromDevice(int argIndex, ref byte[] cmd, int timeout = 200, RichTextBox msg = null)
		{
			int _return = 0;
			if (argIndex != this.m_COMMIndex)
			{
				//---发送消息
				this.m_COMMErrMsg = "接收：通信端口不匹配！\r\n";
				//---消息提示
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Red, false);
				}
			}
			else
			{
				_return = this.ReadFromDevice(ref cmd, timeout, msg);
			}
			return _return;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int ReadFromDevice(string argName, ref byte[] cmd, int timeout = 200, RichTextBox msg = null)
		{
			int _return = 0;
			if (argName != this.m_COMMName)
			{
				//---发送消息
				this.m_COMMErrMsg = "接收：通信端口不匹配！\r\n";
				//---消息提示
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Red, false);
				}
			}
			else
			{
				_return = this.ReadFromDevice(ref cmd,timeout, msg);
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int SendCmdAndReadResponse(byte[] cmd, ref byte[] res, int timeout = 200, RichTextBox msg = null)
		{
			int _return=1;
			_return = this.WriteToDevice(cmd, msg);
			if (_return==0)
			{
				_return = this.ReadFromDevice(ref res, timeout, msg);
			}
			return _return;
		}

		/// <summary>
		/// 发送并读取响应函数
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int SendCmdAndReadResponse(byte[] cmd,int timeout = 200, RichTextBox msg = null)
		{
			int _return=1;
			_return = this.WriteToDevice(cmd, msg);
			if (_return == 0)
			{
				_return = this.ReadFromDevice(timeout, msg);
			}
			return _return;
		}

		/// <summary>
		/// 发送并读取响应函数
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int SendCmdAndReadResponse(string cmd, int timeout = 200, RichTextBox msg = null)
		{
			int _return = 1;
			_return = this.WriteToDevice(cmd, msg);
			if (_return == 0)
			{
				_return = this.ReadFromDevice(timeout, msg);
			}
			return _return;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int SendCmdAndReadResponse(ref byte[] cmd, ref byte[] res, int timeout = 200, RichTextBox msg = null)
		{
			int _return = 1;
			_return = this.WriteToDevice(ref cmd, msg);
			if (_return == 0)
			{
				_return = this.ReadFromDevice(ref res, timeout, msg);
			}
			return _return;
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
		public override int SendCmdAndReadResponse(string argName, byte[] cmd, ref byte[] res, int timeout = 200, RichTextBox msg = null)
		{
			int _return = 1;
			_return = this.WriteToDevice(argName,cmd, msg);
			if (_return == 0)
			{
				_return = this.ReadFromDevice(argName, ref res, timeout, msg);
			}
			return _return;
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
		public override int SendCmdAndReadResponse(string argName,ref byte[] cmd, ref byte[] res, int timeout = 200, RichTextBox msg = null)
		{
			int _return = 1;
			_return = this.WriteToDevice(argName,ref cmd, msg);
			if (_return == 0)
			{
				_return = this.ReadFromDevice(argName, ref res, timeout, msg);
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argIndex"></param>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int SendCmdAndReadResponse(int argIndex, byte[] cmd, ref byte[] res, int timeout = 200, RichTextBox msg = null)
		{
			int _return = 1;
			_return = this.WriteToDevice(argIndex, cmd, msg);
			if (_return == 0)
			{
				_return = this.ReadFromDevice(argIndex, ref res, timeout, msg);
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argIndex"></param>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int SendCmdAndReadResponse(int argIndex, ref byte[] cmd, ref byte[] res, int timeout = 200, RichTextBox msg = null)
		{
			int _return = 1;
			_return = this.WriteToDevice(argIndex, ref cmd, msg);
			if (_return == 0)
			{
				_return = this.ReadFromDevice(argIndex, ref res, timeout, msg);
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override int OpenDevice()
		{
			int _return = 0;
			if ((this.m_COMMIndex != 0)&&(this.defaultSerialPort!=null))
			{
				//---判断当前端口是否可用
				if (this.defaultSerialPort.IsOpen)
				{
					//---等待端口事件处理完成
					while (!((this.m_COMMSTATE == USE_STATE.IDLE) || (this.m_COMMSTATE == USE_STATE.ERROR)))
					{
						Application.DoEvents();
					}
					//---端口状态，空闲
					this.m_COMMSTATE = USE_STATE.IDLE;
					//---关闭端口
					this.defaultSerialPort.Close();
				}
				//---判断端口状态
				if (this.defaultSerialPort.IsOpen == false)
				{
					//---获取端口名称
					if (this.defaultSerialPort.PortName != this.m_COMMName)
					{
						this.defaultSerialPort.PortName = this.m_COMMName;
						
					}

					//---查空操作
					if (this.m_COMMParam == null)
					{
						this.m_COMMParam = new COMMSerialPortParam();
					}
					//---更新端口名称
					this.m_COMMParam.defaultName = this.m_COMMName;

					//---获取端口序号
					this.m_COMMIndex = Convert.ToInt16(this.m_COMMName.Replace("COM", ""), 10);

					//---波特率
					if (this.defaultSerialPort.BaudRate != int.Parse(this.m_COMMParam.defaultBaudRate))
					{
						this.defaultSerialPort.BaudRate = int.Parse(this.m_COMMParam.defaultBaudRate);
					}

					//---校验位
					if (this.defaultSerialPort.Parity != this.GetParityBits(this.m_COMMParam.defaultParity))
					{
						this.defaultSerialPort.Parity = this.GetParityBits(this.m_COMMParam.defaultParity);
					}

					//---停止位
					if (this.defaultSerialPort.StopBits != this.GetStopBits(this.m_COMMParam.defaultStopBits))
					{
						this.defaultSerialPort.StopBits = this.GetStopBits(this.m_COMMParam.defaultStopBits);
					}

					//---数据位
					if (this.defaultSerialPort.DataBits != int.Parse(this.m_COMMParam.defaultDataBits))
					{
						this.defaultSerialPort.DataBits = int.Parse(this.m_COMMParam.defaultDataBits);
					}
					
					//---打开端口
					this.defaultSerialPort.Open();
					//---判断端口打开是否成功
					if (this.defaultSerialPort.IsOpen == false)
					{
						//---端口状态，错误
						this.m_COMMSTATE = USE_STATE.ERROR;
						this.m_COMMErrMsg = "端口：" + this.m_COMMName + "打开失败!\r\n";
						_return = 1;
					}
					else
					{
						this.m_COMMErrMsg = "端口：" + this.m_COMMName + "打开成功!\r\n";

						//---注册事件接收函数
						this.defaultSerialPort.DataReceived += new SerialDataReceivedEventHandler(this.OnEventDataReceivedHandler);
					}
				}
				else
				{
					//---端口状态，错误
					this.m_COMMSTATE = USE_STATE.ERROR;
					this.m_COMMErrMsg = "端口：" + this.m_COMMName + "初始化失败!\r\n";
					_return = 2;
				}
				//---消息显示
				if (_return == 0)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.m_COMMRichTextBox, this.m_COMMErrMsg, Color.Black, false);
				}
				//---消息插件弹出
				if (_return != 0)
				{
					MessageBoxPlus.Show(this.m_COMMForm, this.m_COMMErrMsg + "\r\n" + "错误号：" + _return.ToString() + "\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBoxPlus.Show(this.m_COMMForm, "端口名称不合法!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				_return = 3;
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int OpenDevice(string argName, RichTextBox msg = null)
		{
			int _return = 0;
			if (((argName != string.Empty) && (argName != null) && (argName != "") && (argName.StartsWith("COM"))))
			{
				//---判断串口类是否初始化
				if (this.defaultSerialPort == null)
				{
					this.defaultSerialPort = new SerialPort();
				}
				//---判断当前端口是否可用
				if (this.defaultSerialPort.IsOpen)
				{
					//---等待端口事件处理完成
					while (!((this.m_COMMSTATE == USE_STATE.IDLE) || (this.m_COMMSTATE == USE_STATE.ERROR)))
					{
						Application.DoEvents();
					}
					//---端口状态，空闲
					this.m_COMMSTATE = USE_STATE.IDLE;
					//---关闭端口
					this.defaultSerialPort.Close();
				}
				//---判断端口状态
				if (this.defaultSerialPort.IsOpen == false)
				{
					//---获取端口名称
					if (this.defaultSerialPort.PortName != argName)
					{
						this.defaultSerialPort.PortName = argName;
					}

					//---使用的设备端口
					this.m_COMMName = argName;

					//---获取端口序号
					this.m_COMMIndex = Convert.ToInt16(this.m_COMMName.Replace("COM", ""), 10);

					//---查空操作
					if (this.m_COMMParam==null)
					{
						this.m_COMMParam = new COMMSerialPortParam();
					}
					//---端口参数
					this.m_COMMParam.defaultName = this.m_COMMName;

					//---波特率
					if (this.defaultSerialPort.BaudRate != int.Parse(this.m_COMMParam.defaultBaudRate))
					{
						this.defaultSerialPort.BaudRate = int.Parse(this.m_COMMParam.defaultBaudRate);
					}

					//---校验位
					if (this.defaultSerialPort.Parity != this.GetParityBits(this.m_COMMParam.defaultParity))
					{
						this.defaultSerialPort.Parity = this.GetParityBits(this.m_COMMParam.defaultParity);
					}

					//---停止位
					if (this.defaultSerialPort.StopBits != this.GetStopBits(this.m_COMMParam.defaultStopBits))
					{
						this.defaultSerialPort.StopBits = this.GetStopBits(this.m_COMMParam.defaultStopBits);
					}

					//---数据位
					if (this.defaultSerialPort.DataBits != int.Parse(this.m_COMMParam.defaultDataBits))
					{
						this.defaultSerialPort.DataBits = int.Parse(this.m_COMMParam.defaultDataBits);
					}

					//---打开端口
					this.defaultSerialPort.Open();
					//---判断端口打开是否成功
					if (this.defaultSerialPort.IsOpen == false)
					{
						//---端口状态，错误
						this.m_COMMSTATE = USE_STATE.ERROR;
						this.m_COMMErrMsg = "端口：" + this.m_COMMName + "打开失败!\r\n";
						_return = 2;
					}
					else
					{
						this.m_COMMErrMsg = "端口：" + this.m_COMMName + "打开成功!\r\n";

						//---注册事件接收函数
						this.defaultSerialPort.DataReceived += new SerialDataReceivedEventHandler(this.OnEventDataReceivedHandler);
					}
				}
				else
				{
					//---端口状态，错误
					this.m_COMMSTATE = USE_STATE.ERROR;
					this.m_COMMErrMsg = "端口：" + this.m_COMMName + "初始化失败!\r\n";
					_return = 3;
				}
				//---消息显示
				if (_return==0)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Black, false);
				}
				//---消息插件弹出
				if (_return != 0)
				{
					MessageBoxPlus.Show(this.m_COMMForm, this.m_COMMErrMsg+"\r\n"+ "错误号："+_return.ToString()+"\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

			}
			else
			{
				MessageBoxPlus.Show(this.m_COMMForm, "端口名称不合法!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				_return = 4;
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="baudRate"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int OpenDevice(string argName, int baudRate, RichTextBox msg = null)
		{
			int _return = 0;
			if (((argName != string.Empty) && (argName != null) && (argName != "") && (argName.StartsWith("COM"))))
			{
				if (this.defaultSerialPort == null)
				{
					this.defaultSerialPort = new SerialPort();
				}
				//---判断当前端口是否可用
				if (this.defaultSerialPort.IsOpen)
				{
					//---等待端口事件处理完成
					while (!((this.m_COMMSTATE == USE_STATE.IDLE) || (this.m_COMMSTATE == USE_STATE.ERROR)))
					{
						Application.DoEvents();
					}
					//---端口状态，空闲
					this.m_COMMSTATE = USE_STATE.IDLE;
					//---关闭端口
					this.defaultSerialPort.Close();
				}
				//---判断端口状态
				if (this.defaultSerialPort.IsOpen == false)
				{
					//---获取端口名称
					if (this.defaultSerialPort.PortName != argName)
					{
						this.defaultSerialPort.PortName = argName;
						this.m_COMMName = argName;
					}
					//---获取端口序号
					this.m_COMMIndex = Convert.ToInt16(this.m_COMMName.Replace("COM", ""), 10);

					//---查空操作
					if (this.m_COMMParam == null)
					{
						this.m_COMMParam = new COMMSerialPortParam();
					}

					//---端口参数
					this.m_COMMParam.defaultName = this.m_COMMName;

					//---配置波特率
					this.m_COMMParam.defaultBaudRate = baudRate.ToString();

					//---波特率
					if (this.defaultSerialPort.BaudRate != int.Parse(this.m_COMMParam.defaultBaudRate))
					{
						this.defaultSerialPort.BaudRate = int.Parse(this.m_COMMParam.defaultBaudRate);
					}

					//---校验位
					if (this.defaultSerialPort.Parity != this.GetParityBits(this.m_COMMParam.defaultParity))
					{
						this.defaultSerialPort.Parity = this.GetParityBits(this.m_COMMParam.defaultParity);
					}

					//---停止位
					if (this.defaultSerialPort.StopBits != this.GetStopBits(this.m_COMMParam.defaultStopBits))
					{
						this.defaultSerialPort.StopBits = this.GetStopBits(this.m_COMMParam.defaultStopBits);
					}

					//---数据位
					if (this.defaultSerialPort.DataBits != int.Parse(this.m_COMMParam.defaultDataBits))
					{
						this.defaultSerialPort.DataBits = int.Parse(this.m_COMMParam.defaultDataBits);
					}
					
					//---打开端口
					this.defaultSerialPort.Open();
					//---判断端口打开是否成功
					if (this.defaultSerialPort.IsOpen == false)
					{
						//---端口状态，错误
						this.m_COMMSTATE = USE_STATE.ERROR;
						this.m_COMMErrMsg = "端口：" + this.m_COMMName + "打开失败!\r\n";
						_return = 2;
					}
					else
					{
						this.m_COMMErrMsg = "端口：" + this.m_COMMName + "打开成功!\r\n";

						//---注册事件接收函数
						this.defaultSerialPort.DataReceived += new SerialDataReceivedEventHandler(this.OnEventDataReceivedHandler);
					}
				}
				else
				{
					//---端口状态，错误状态
					this.m_COMMSTATE = USE_STATE.ERROR;
					this.m_COMMErrMsg = "端口：" + this.m_COMMName + "初始化失败!\r\n";
					_return = 3;
				}
				//---消息显示
				if (_return == 0)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Black, false);
				}
				//---消息插件弹出
				if (_return != 0)
				{
					MessageBoxPlus.Show(this.m_COMMForm, this.m_COMMErrMsg + "\r\n" + "错误号：" + _return.ToString() + "\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

			}
			else
			{
				MessageBoxPlus.Show(this.m_COMMForm, "端口名称不合法!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				_return = 4;
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="commPortParam"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int OpenDevice(COMMPortParam commPortParam, RichTextBox msg = null)
		{
			int _return = 0;
			if (!Regex.IsMatch(commPortParam.defaultBaudRate, @"^\d+$" )||!Regex.IsMatch(commPortParam.defaultDataBits, @"^\d+$")
				||(commPortParam.defaultName==null)|| (commPortParam.defaultName == ""))
			{
				_return=1;
				this.m_COMMErrMsg = "端口参数错误!\r\n";
			}
			else
			{
				if (this.defaultSerialPort==null)
				{
					this.defaultSerialPort = new SerialPort(); 
				}
				if (this.defaultSerialPort.IsOpen)
				{
					//---等待端口事件处理完成
					while (!((this.m_COMMSTATE == USE_STATE.IDLE) || (this.m_COMMSTATE == USE_STATE.ERROR)))
					{
						Application.DoEvents();
					}
					//---端口状态，空闲
					this.m_COMMSTATE = USE_STATE.IDLE;
					//---关闭端口
					this.defaultSerialPort.Close();
				}
				if (this.defaultSerialPort.IsOpen)
				{
					//---端口状态，错误状态
					this.m_COMMSTATE = USE_STATE.ERROR;
					_return = 2;
					this.m_COMMErrMsg = "端口：" + this.m_COMMName + "初始化失败!\r\n";
				}
				else
				{
					this.defaultSerialPort.PortName = commPortParam.defaultName;
					this.defaultSerialPort.BaudRate = int.Parse(commPortParam.defaultBaudRate);
					this.defaultSerialPort.Parity = this.GetParityBits(commPortParam.defaultParity);
					this.defaultSerialPort.StopBits = this.GetStopBits(commPortParam.defaultStopBits);
					this.defaultSerialPort.DataBits = int.Parse(commPortParam.defaultDataBits);
					//---端口名称
					this.m_COMMName = commPortParam.defaultName;
					//---获取端口序号
					this.m_COMMIndex = Convert.ToInt16(this.m_COMMName.Replace("COM", ""), 10);

					//---查空操作
					if (this.m_COMMParam == null)
					{
						this.m_COMMParam = new COMMSerialPortParam();
					}

					//---更新端口参数
					this.m_COMMParam = commPortParam;

					try
					{
						//---打开端口
						this.defaultSerialPort.Open();

						//---判断端口打开是否成功
						if (this.defaultSerialPort.IsOpen == false)
						{
							//---端口状态，错误状态
							this.m_COMMSTATE = USE_STATE.ERROR;
							this.m_COMMErrMsg = "端口：" + this.m_COMMName + "打开失败!\r\n";
							_return = 3;
						}
						else
						{
							this.m_COMMErrMsg = "端口：" + this.m_COMMName + "打开成功!\r\n";

							//---注册事件接收函数
							this.defaultSerialPort.DataReceived += new SerialDataReceivedEventHandler(this.OnEventDataReceivedHandler);
						}
					}
					catch 
					{
						_return = 4;
						this.m_COMMErrMsg = "端口：" + this.m_COMMName + "初始化异常!\r\n";
					}
				}

			}
			//---消息显示
			if (_return == 0)
			{
				RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMErrMsg, Color.Black, false);
			}
			//---消息插件弹出
			if (_return != 0)
			{
				MessageBoxPlus.Show(this.m_COMMForm, this.m_COMMErrMsg + "\r\n" + "错误号：" + _return.ToString() + "\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return _return;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override int CloseDevice()
		{
			int _return = 0;
			//---
			if ((this.defaultSerialPort!=null)&&(this.m_COMMIndex!=0))
			{
				if (this.defaultSerialPort.IsOpen)
				{
					//---等待端口事件处理完成
					while (!((this.m_COMMSTATE == USE_STATE.IDLE)||(this.m_COMMSTATE == USE_STATE.ERROR)))
					{
						Application.DoEvents();
					}
					//---注销事件接收函数
					this.defaultSerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.OnEventDataReceivedHandler);
					//---端口状态，空闲
					this.m_COMMSTATE = USE_STATE.IDLE;
					//---关闭端口
					this.defaultSerialPort.Close();
					//---判断端口是否关闭成功
					if (this.defaultSerialPort.IsOpen==false)
					{
						this.m_COMMErrMsg = "端口关闭成功！\r\n";
					}
					else
					{
						this.m_COMMErrMsg = "端口关闭失败！\r\n";
						_return = 1;
					}
					
					this.m_COMMName = null;
					this.m_COMMIndex = 0;
					this.m_COMMParam.defaultName = this.m_COMMName;
				}
				else
				{


					//---释放端口
					this.defaultSerialPort.Close();
					//---消息提示
					this.m_COMMErrMsg = "端口初始化失败！\r\n";
					_return = 2;
				}
			}
			else
			{
				if(this.defaultSerialPort != null)
				{
					//---释放端口
					this.defaultSerialPort.Close();
					//---结束函数
					return 4;
				}
				else
				{
					this.m_COMMErrMsg = "端口对象未初始化！\r\n";
					_return = 3;
				}
			}
			//---消息插件弹出
			if (_return != 0)
			{
				MessageBoxPlus.Show(this.m_COMMForm, this.m_COMMErrMsg + "\r\n" + "错误号：" + _return.ToString() + "\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CloseDevice(string argName, RichTextBox msg = null)
		{
			int _return = 0;
			if (this.defaultSerialPort != null)
			{
				//---
				if (this.defaultSerialPort.PortName==argName)
				{
					if (this.defaultSerialPort.IsOpen)
					{
						//---等待端口事件处理完成
						while (!((this.m_COMMSTATE == USE_STATE.IDLE) || (this.m_COMMSTATE == USE_STATE.ERROR)))
						{
							Application.DoEvents();
						}
						//---注销事件接收函数
						this.defaultSerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.OnEventDataReceivedHandler);
						//---端口状态，空闲
						this.m_COMMSTATE = USE_STATE.IDLE;
						//---关闭端口
						this.defaultSerialPort.Close();
						//---判断端口是否关闭成功
						if (this.defaultSerialPort.IsOpen == false)
						{
							this.m_COMMErrMsg = "端口关闭成功！\r\n";
						}
						else
						{
							this.m_COMMErrMsg = "端口关闭失败！\r\n";
							_return = 1;
						}
					}
					else
					{
						this.m_COMMErrMsg = "端口初始化失败！\r\n";
						_return = 2;
					}
					this.m_COMMName = null;
					this.m_COMMIndex = 0;
					this.m_COMMParam.defaultName = this.m_COMMName;
				}
				else
				{
					this.m_COMMErrMsg = "端口名称不匹配！\r\n";
					_return = 3;
				}
			}
			else
			{
				this.m_COMMErrMsg = "端口对象未初始化！\r\n";
				_return = 4;
			}
			//---消息插件弹出
			if (_return != 0)
			{
				MessageBoxPlus.Show(this.m_COMMForm, this.m_COMMErrMsg + "\r\n" + "错误号：" + _return.ToString() + "\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CloseDevice(int argIndex, RichTextBox msg = null)
		{
			int _return = 0;
			if (this.defaultSerialPort != null)
			{
				//---
				if (this.defaultSerialPort.PortName == ("COM"+argIndex.ToString()))
				{
					if (this.defaultSerialPort.IsOpen)
					{
						//---等待端口事件处理完成
						while (!((this.m_COMMSTATE == USE_STATE.IDLE) || (this.m_COMMSTATE == USE_STATE.ERROR)))
						{
							Application.DoEvents();
						}
						//---注销事件接收函数
						this.defaultSerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.OnEventDataReceivedHandler);
						//---端口状态，空闲
						this.m_COMMSTATE = USE_STATE.IDLE;
						//---关闭端口
						this.defaultSerialPort.Close();
						//---判断端口是否关闭成功
						if (this.defaultSerialPort.IsOpen == false)
						{
							this.m_COMMErrMsg = "端口关闭成功！\r\n";
						}
						else
						{
							this.m_COMMErrMsg = "端口关闭失败！\r\n";
							_return = 1;
						}
					}
					else
					{
						this.m_COMMErrMsg = "端口初始化失败！\r\n";
						_return = 2;
					}
					this.m_COMMName = null;
					this.m_COMMIndex = 0;
					this.m_COMMParam.defaultName = this.m_COMMName;
				}
				else
				{
					this.m_COMMErrMsg = "端口名称不匹配！\r\n";
					_return = 3;
				}
			}
			else
			{
				this.m_COMMErrMsg = "端口对象未初始化！\r\n";
				_return = 4;
			}
			//---消息插件弹出
			if (_return != 0)
			{
				MessageBoxPlus.Show(this.m_COMMForm, this.m_COMMErrMsg + "\r\n" + "错误号：" + _return.ToString() + "\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return _return;
		}

		/// <summary>
		/// 检测设备
		/// </summary>
		/// <returns></returns>
		public override bool IsAttached()
		{
			if (this.defaultSerialPort!=null)
			{
				return this.defaultSerialPort.IsOpen;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portIndex"></param>
		/// <returns></returns>
		public override bool IsAttached(string argName)
		{

			if ((this.defaultSerialPort != null) && (this.defaultSerialPort.PortName == argName))
			{
				return this.defaultSerialPort.IsOpen;
			}
			else
			{
				return false;
			}
		}

		#endregion

		#endregion

		#region 事件定义

		/// <summary>
		/// 数据接收事件
		/// </summary>
		public override EventCOMM m_OnEventDataReceived
		{
			get
			{
				return base.m_OnEventDataReceived;
			}
			set
			{
				base.m_OnEventDataReceived = value;
			}
		}

		/// <summary>
		/// 设备移除事件
		/// </summary>
		public override EventCOMM m_OnEventDeviceRemoved
		{
			get
			{
				return base.m_OnEventDeviceRemoved;
			}

			set
			{
				base.m_OnEventDeviceRemoved = value;
			}
		}

		/// <summary>
		/// 通讯端口同步事件
		/// </summary>
		public override EventCOMMSYNC m_OnEventCOMMYNC
		{
			get
			{
				return base.m_OnEventCOMMYNC;
			}
			set
			{
				base.m_OnEventCOMMYNC = value;
			}
		}

		/// <summary>
		/// 通讯数据接收事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void OnEventDataReceivedHandler(object sender, EventArgs e)
		{
			string str = e.ToString();
			//---判断事件的类型
			if ((str == "SerialDataReceivedEventArgs") || (str == "System.IO.Ports.SerialDataReceivedEventArgs"))
			{
				if ((this.defaultSerialPort != null) && (this.defaultSerialPort.IsOpen == true) &&
				    (this.m_COMMSTATE == USE_STATE.IDLE))
				{
					//---设置状态为事件读取
					this.m_COMMSTATE = USE_STATE.EVENT_READ;
					//---执行委托函数
					this.m_OnEventDataReceived?.Invoke(sender, e);
					//---设置状态为空闲模式
					this.m_COMMSTATE = USE_STATE.IDLE;
				}
			}
		}


		/// <summary>
		/// 监控端口事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		public override void WatcherPortEventHandler(Object sender, EventArrivedEventArgs e)
		{
			if (e.NewEvent.ClassPath.ClassName == "__InstanceCreationEvent")
			{
				//---设备增加处理函数
				this.AddDevice(this.m_COMMComboBox, this.m_COMMRichTextBox);
			}
			else if (e.NewEvent.ClassPath.ClassName == "__InstanceDeletionEvent")
			{
				//---设备减少处理函数
				this.RemoveDevice(this.m_COMMComboBox, this.m_COMMRichTextBox);
				//---执行设备移除函数
				this.m_OnEventDeviceRemoved?.Invoke(sender, e);
			}
		}
		#endregion

	}
}
