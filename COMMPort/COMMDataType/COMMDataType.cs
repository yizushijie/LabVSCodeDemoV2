using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabCOMMPort
{
	/// <summary>
	/// 数据通讯类型
	/// </summary>
	public partial class COMMDataType
	{
		#region 变量定义

		/// <summary>
		/// crc校验值
		/// </summary>
		public UInt32 defaultCRCVal = 0;

		/// <summary>
		/// 使用的CRC方式
		/// </summary>
		public USE_CRC defaultCRCMode = USE_CRC.CRC_NONE;

		/// <summary>
		/// 数据原始长度
		/// </summary>
		public int defaultOriginalLength = 0;

		/// <summary>
		/// 数据的实际长度
		/// </summary>
		public int defaultRealityLength = 0;

		/// <summary>
		/// 数据的原始格式
		/// </summary>
		public List<byte> defaultOriginalByte = null;

		/// <summary>
		/// 数据存储
		/// </summary>
		public List<byte> defaultRealityByte = null;

		/// <summary>
		/// 字节数据命令
		/// </summary>
		public List<byte> defaultDataByte = null;
		
		/// <summary>
		/// 主命令
		/// </summary>
		public byte defaultParentCMD = 0;

		/// <summary>
		/// 子命令
		/// </summary>
		public byte defaultChildCMD = 0;

		/// <summary>
		/// 结果标志位
		/// </summary>
		public byte defaultResultFlag = 0;

		/// <summary>
		/// 真实数据的索引
		/// </summary>
		public int defaultRealityIndex = 0;

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public COMMDataType()
		{
			this.Init();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bufferSize"></param>
		/// <param name="commByte"></param>
		public COMMDataType(int bufferSize, byte[] commByte)
		{
			this.Init(bufferSize, commByte);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="commByte"></param>
		public COMMDataType(int bufferSize, byte[] commByte, ref bool isChildCMD)
		{
			this.Init(bufferSize, commByte, ref isChildCMD);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="commByte"></param>
		public COMMDataType(int bufferSize, List<byte> commByte)
		{
			this.Init(bufferSize, commByte);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="commByte"></param>
		public COMMDataType(int bufferSize, List<byte> commByte, ref bool isChildCMD)
		{
			this.Init(bufferSize, commByte, ref isChildCMD);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="crcMode"></param>
		/// <param name="commByte"></param>
		public COMMDataType(int bufferSize, USE_CRC crcMode, byte[] commByte)
		{
			this.Init(bufferSize, crcMode, commByte);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="crcMode"></param>
		/// <param name="commByte"></param>
		public COMMDataType(int bufferSize, USE_CRC crcMode, byte[] commByte, ref bool isChildCMD)
		{
			this.Init(bufferSize, crcMode, commByte, ref isChildCMD);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="crcVal"></param>
		/// <param name="crcMode"></param>
		public COMMDataType(int bufferSize, UInt32 crcVal, USE_CRC crcMode, byte[] commByte)
		{
			this.Init(bufferSize, crcVal, crcMode, commByte);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="crcVal"></param>
		/// <param name="crcMode"></param>
		public COMMDataType(int bufferSize, UInt32 crcVal, USE_CRC crcMode, byte[] commByte, ref bool isChildCMD)
		{
			this.Init(bufferSize, crcVal, crcMode, commByte, ref isChildCMD);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bufferSize"></param>
		/// <param name="crcMode"></param>
		/// <param name="commByte"></param>
		public COMMDataType(int bufferSize, USE_CRC crcMode, List<byte> commByte)
		{
			this.Init(bufferSize, crcMode, commByte);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="crcVal"></param>
		/// <param name="crcMode"></param>
		public COMMDataType(int bufferSize, USE_CRC crcMode, List<byte> commByte, ref bool isChildCMD)
		{
			this.Init(bufferSize, crcMode, commByte, ref isChildCMD);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="crcVal"></param>
		/// <param name="crcMode"></param>
		public COMMDataType(int bufferSize, UInt32 crcVal, USE_CRC crcMode, List<byte> commByte)
		{
			this.Init(bufferSize, crcVal, crcMode, commByte);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="crcVal"></param>
		/// <param name="crcMode"></param>
		public COMMDataType(int bufferSize, UInt32 crcVal, USE_CRC crcMode, List<byte> commByte, ref bool isChildCMD)
		{
			this.Init(bufferSize, crcVal, crcMode, commByte, ref isChildCMD);
		}

		#endregion

		#region 私有函数

		/// <summary>
		/// 获取通讯数据
		/// </summary>
		private int GetCOMMByte(int bufferSize)
		{
			int _return = 0;
			if ((this.defaultOriginalByte == null) || (this.defaultOriginalByte.Count == 0))
			{
				_return = 1;
			}
			else
			{
				//---数据总长度
				this.defaultOriginalLength = this.defaultOriginalByte.Count;
				this.defaultRealityLength = this.defaultOriginalLength;
				//---解析CRC
				if ((this.defaultCRCMode == USE_CRC.CRC_CHECKSUM) || (this.defaultCRCMode == USE_CRC.CRC_CRC8))
				{
					this.defaultRealityLength -= 1;
					this.defaultCRCVal = this.defaultOriginalByte[this.defaultRealityLength];
				}
				else if (this.defaultCRCMode == USE_CRC.CRC_CRC16)
				{
					this.defaultRealityLength -= 2;
					this.defaultCRCVal = this.defaultOriginalByte[this.defaultRealityLength];
					this.defaultCRCVal = (this.defaultCRCVal << 8) + this.defaultOriginalByte[this.defaultRealityLength];
				}
				else if (this.defaultCRCMode == USE_CRC.CRC_CRC32)
				{
					this.defaultRealityLength -= 2;
					this.defaultCRCVal = this.defaultOriginalByte[this.defaultRealityLength];
					this.defaultCRCVal = (this.defaultCRCVal << 8) + this.defaultOriginalByte[this.defaultRealityLength + 1];
					this.defaultCRCVal = (this.defaultCRCVal << 8) + this.defaultOriginalByte[this.defaultRealityLength + 2];
					this.defaultCRCVal = (this.defaultCRCVal << 8) + this.defaultOriginalByte[this.defaultRealityLength + 2];
				}

				//---数据缓存区
				if ((this.defaultRealityByte == null) || (this.defaultRealityByte.Count > 0))
				{
					this.defaultRealityByte = new List<byte>();
				}

				//---数据拷贝
				for (_return = 0; _return < this.defaultRealityLength; _return++)
				{
					this.defaultRealityByte.Add(this.defaultOriginalByte[_return]);
				}

				//---数据传输最大缓存区
				if (bufferSize < 250)
				{
					this.defaultRealityLength -= 2;
					this.defaultRealityByte[1] = (byte)(this.defaultRealityLength);

					this.defaultParentCMD = this.defaultRealityByte[2];
					
				}
				else
				{
					this.defaultRealityLength -= 3;
					this.defaultRealityByte[1] = (byte)(this.defaultRealityLength >> 8);
					this.defaultRealityByte[2] = (byte)(this.defaultRealityLength);

					this.defaultParentCMD = this.defaultRealityByte[3];
					
				}
				_return = 0;
			}
			return _return;
		}

		/// <summary>
		/// 获取通讯数据
		/// </summary>
		private int GetCOMMByte(int bufferSize, ref bool isChildCMD)
		{
			int _return = 0;
			if ((this.defaultOriginalByte == null) || (this.defaultOriginalByte.Count == 0))
			{
				_return = 1;
			}
			else
			{
				//---数据总长度
				this.defaultOriginalLength = this.defaultOriginalByte.Count;
				this.defaultRealityLength = this.defaultOriginalLength;
				//---解析CRC
				if ((this.defaultCRCMode == USE_CRC.CRC_CHECKSUM) || (this.defaultCRCMode == USE_CRC.CRC_CRC8))
				{
					this.defaultRealityLength -= 1;
					this.defaultCRCVal = this.defaultOriginalByte[this.defaultRealityLength];
				}
				else if (this.defaultCRCMode == USE_CRC.CRC_CRC16)
				{
					this.defaultRealityLength -= 2;
					this.defaultCRCVal = this.defaultOriginalByte[this.defaultRealityLength];
					this.defaultCRCVal = (this.defaultCRCVal << 8) + this.defaultOriginalByte[this.defaultRealityLength];
				}
				else if (this.defaultCRCMode == USE_CRC.CRC_CRC32)
				{
					this.defaultRealityLength -= 2;
					this.defaultCRCVal = this.defaultOriginalByte[this.defaultRealityLength];
					this.defaultCRCVal = (this.defaultCRCVal << 8) + this.defaultOriginalByte[this.defaultRealityLength + 1];
					this.defaultCRCVal = (this.defaultCRCVal << 8) + this.defaultOriginalByte[this.defaultRealityLength + 2];
					this.defaultCRCVal = (this.defaultCRCVal << 8) + this.defaultOriginalByte[this.defaultRealityLength + 2];
				}

				//---数据缓存区
				if (this.defaultRealityByte == null)
				{
					this.defaultRealityByte = new List<byte>();
				}
				else
				{
					this.defaultRealityByte.Clear();
				}

				//---数据拷贝,数据信息中不包含CRC信息
				for (_return = 0; _return < this.defaultRealityLength; _return++)
				{
					this.defaultRealityByte.Add(this.defaultOriginalByte[_return]);
				}
				
				//---数据传输最大缓存区
				if (bufferSize < 250)
				{
					this.defaultRealityLength -= 2;
					this.defaultRealityByte[1] = (byte)(this.defaultRealityLength);

					this.defaultParentCMD = this.defaultRealityByte[2];
					if (isChildCMD)
					{
						this.defaultChildCMD = this.defaultRealityByte[3];
						this.defaultResultFlag = this.defaultRealityByte[4];
						this.defaultRealityIndex = 5;
					}
					else
					{
						this.defaultChildCMD = 0;
						this.defaultResultFlag = this.defaultRealityByte[3];
						this.defaultRealityIndex = 4;
					}
				}
				else
				{
					this.defaultRealityLength -= 3;
					this.defaultRealityByte[1] = (byte)(this.defaultRealityLength >> 8);
					this.defaultRealityByte[2] = (byte)(this.defaultRealityLength);

					this.defaultParentCMD = this.defaultRealityByte[3];
					if (isChildCMD)
					{
						this.defaultChildCMD = this.defaultRealityByte[4];
						this.defaultResultFlag = this.defaultRealityByte[5];
						this.defaultRealityIndex = 6;
					}
					else
					{
						this.defaultChildCMD = 0;
						this.defaultResultFlag = this.defaultRealityByte[4];
						this.defaultRealityIndex = 5;
					}
				}
				//---空检查
				if (this.defaultDataByte==null)
				{
					this.defaultDataByte = new List<byte>();
				}
				else
				{
					this.defaultDataByte.Clear();
				}
				if (this.defaultRealityIndex<this.defaultRealityByte.Count)
				{
					//---数据拷贝,数据仅仅是传输过程中的数据，不包含CRC校验和报头以及命令和结果标识
					for (_return = defaultRealityIndex; _return < defaultRealityByte.Count; _return++)
					{
						this.defaultDataByte.Add(this.defaultRealityByte[_return]);
					}
				}
				_return = 0;
			}
			isChildCMD = false;
			return _return;
		}

		#endregion

		#region 公共函数

		/// <summary>
		/// 
		/// </summary>
		public virtual int Init()
		{
			this.defaultCRCVal = 0;
			this.defaultCRCMode = USE_CRC.CRC_NONE;
			this.defaultOriginalLength = 0;
			this.defaultOriginalByte = null;
			this.defaultRealityByte = null;

			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual int Init(int bufferSize, byte[] commByte)
		{
			this.defaultOriginalByte = new List<byte>();
			this.defaultOriginalByte.AddRange(commByte);
			return this.GetCOMMByte(bufferSize);
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual int Init(int bufferSize, byte[] commByte, ref bool isChildCMD)
		{
			this.defaultOriginalByte = new List<byte>();
			this.defaultOriginalByte.AddRange(commByte);
			return this.GetCOMMByte(bufferSize, ref isChildCMD);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="commByte"></param>
		public virtual int Init(int bufferSize, List<byte> commByte)
		{
			this.defaultOriginalByte = commByte;
			return this.GetCOMMByte(bufferSize);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="commByte"></param>
		public virtual int Init(int bufferSize, List<byte> commByte, ref bool isChildCMD)
		{
			this.defaultOriginalByte = commByte;
			return this.GetCOMMByte(bufferSize, ref isChildCMD);
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual int Init(int bufferSize, USE_CRC crcMode, byte[] commByte)
		{
			this.defaultCRCMode = crcMode;
			this.defaultOriginalByte = new List<byte>();
			this.defaultOriginalByte.AddRange(commByte);
			return this.GetCOMMByte(bufferSize);
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual int Init(int bufferSize, USE_CRC crcMode, byte[] commByte, ref bool isChildCMD)
		{
			this.defaultCRCMode = crcMode;
			this.defaultOriginalByte = new List<byte>();
			this.defaultOriginalByte.AddRange(commByte);
			return this.GetCOMMByte(bufferSize, ref isChildCMD);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="crcVal"></param>
		/// <param name="crcMode"></param>
		public virtual int Init(int bufferSize, UInt32 crcVal, USE_CRC crcMode, byte[] commByte)
		{
			this.defaultCRCVal = crcVal;
			this.defaultCRCMode = crcMode;
			this.defaultOriginalByte = new List<byte>();
			this.defaultOriginalByte.AddRange(commByte);
			return this.GetCOMMByte(bufferSize);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="crcVal"></param>
		/// <param name="crcMode"></param>
		public virtual int Init(int bufferSize, UInt32 crcVal, USE_CRC crcMode, byte[] commByte, ref bool isChildCMD)
		{
			this.defaultCRCVal = crcVal;
			this.defaultCRCMode = crcMode;
			this.defaultOriginalByte = new List<byte>();
			this.defaultOriginalByte.AddRange(commByte);
			return this.GetCOMMByte(bufferSize, ref isChildCMD);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="crcMode"></param>
		/// <param name="commByte"></param>
		public virtual int Init(int bufferSize, USE_CRC crcMode, List<byte> commByte)
		{
			this.defaultCRCMode = crcMode;
			this.defaultOriginalByte = commByte;
			return this.GetCOMMByte(bufferSize);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="crcMode"></param>
		/// <param name="commByte"></param>
		public virtual int Init(int bufferSize, USE_CRC crcMode, List<byte> commByte, ref bool isChildCMD)
		{
			this.defaultCRCMode = crcMode;
			this.defaultOriginalByte = commByte;
			return this.GetCOMMByte(bufferSize, ref isChildCMD);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="crcVal"></param>
		/// <param name="crcMode"></param>
		/// <param name="commByte"></param>
		public virtual int Init(int bufferSize, UInt32 crcVal, USE_CRC crcMode, List<byte> commByte)
		{
			this.defaultCRCVal = crcVal;
			this.defaultCRCMode = crcMode;
			this.defaultOriginalByte = commByte;
			return this.GetCOMMByte(bufferSize);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="crcVal"></param>
		/// <param name="crcMode"></param>
		/// <param name="commByte"></param>
		public virtual int Init(int bufferSize, UInt32 crcVal, USE_CRC crcMode, List<byte> commByte, ref bool isChildCMD)
		{
			this.defaultCRCVal = crcVal;
			this.defaultCRCMode = crcMode;
			this.defaultOriginalByte = commByte;
			return this.GetCOMMByte(bufferSize, ref isChildCMD);
		}
		#endregion
	}
}
