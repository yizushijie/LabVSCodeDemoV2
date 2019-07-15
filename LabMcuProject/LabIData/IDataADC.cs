using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabMcuProject
{
	/// <summary>
	/// ADC采样数据的处理
	/// </summary>
	public partial class IDataADC
	{

		#region 变量定义

		/// <summary>
		/// ADC采样的结果
		/// </summary>
		public List<int> defaultADCResult = null;

		/// <summary>
		/// ADC采样结果的计算值
		/// </summary>
		public List<float> defaultPowerResult = null;

		/// <summary>
		/// 求取均值的位置
		/// </summary>
		public int defaultAVGPositionIndex = 1;
		
		/// <summary>
		/// ADC的位数
		/// </summary>
		public int defaultADCBits = 10;

		/// <summary>
		/// 参考电压
		/// </summary>
		public float defaultVREF = 5.0F;

		#endregion

		#region 属性定义

		/// <summary>
		/// ADC采样均值
		/// </summary>
		public virtual int m_ADCAVGResult
		{
			get
			{
				int i = 0;
				int index = 0;
				int length = 0;
				int _return = 0;
				if (this.defaultADCResult.Count<=(2*this.defaultAVGPositionIndex))
				{
					index = 0;
				}
				else
				{
					index = this.defaultAVGPositionIndex;
				}
				length = this.defaultADCResult.Count-index;
				if (this.defaultADCResult.Count>0)
				{
					for (i = index; i < length; i++)
					{
						_return += this.defaultADCResult[i];
					}
					return (_return / (i-index));
				}
				else
				{
					return 0;
				}
			}
		}

		/// <summary>
		/// ADC采样计算均值
		/// </summary>
		public virtual float m_PowerAVGResult
		{
			get
			{
				int i = 0;
				int index = 0;
				int length = 0;
				float _return = 0;
				if (this.defaultPowerResult.Count <= (2 * this.defaultAVGPositionIndex))
				{
					index = 0;
				}
				else
				{
					index = this.defaultAVGPositionIndex;
				}
				length = this.defaultPowerResult.Count - index;
				if (this.defaultPowerResult.Count > 0)
				{
					for (i = index; i < length; i++)
					{
						_return += this.defaultPowerResult[i];
					}
					return (_return / (i - index));
				}
				else
				{
					return 0;
				}
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public IDataADC()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="vrefPower"></param>
		public IDataADC(float adcVREF,int adcBits=10)
		{
			this.defaultVREF = adcVREF;
			this.defaultADCBits = adcBits;
		}

		#endregion

		#region 公共函数

		/// <summary>
		/// 
		/// </summary>
		public virtual void Init()
		{
			this.defaultADCResult = null;
			this.defaultPowerResult = null;
			this.defaultAVGPositionIndex = 1;
			this.defaultADCBits = 10;
			this.defaultVREF = 5.00f;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="adcResult"></param>
		/// <param name="isHighFirst"></param>
		public virtual void Init(byte[] adcResult, int position = 0, bool isHighFirst = true)
		{
			int i = 0;
			int byteToADCResultNum = 0;
			if (this.defaultADCBits<=8)
			{
				byteToADCResultNum = 1;
			}
			else if(this.defaultADCBits<=16)
			{
				byteToADCResultNum = 2;
			}
			else if(this.defaultADCBits<=24)
			{
				byteToADCResultNum = 3;
			}
			else
			{
				byteToADCResultNum = 4;
			}
			//---判断起始位置是不是偶数，不是偶数向后移动一位，保证数据是偶数
			position += ((adcResult.Length - position) % byteToADCResultNum);

			if (this.defaultADCResult==null)
			{
				this.defaultADCResult = new List<int>();
			}
			else
			{
				this.defaultADCResult.Clear();
			}
			int adcVal = 0;
			int j = 0;
			for ( i = position; i < adcResult.Length; i+= byteToADCResultNum)
			{
				adcVal = 0;
				if (isHighFirst)
				{
					for (j = 0; j < byteToADCResultNum; j++)
					{
						adcVal <<= 8;
						adcVal += adcResult[i+j];
					}
					
				}
				else
				{
					for (j = 0; j < byteToADCResultNum; j++)
					{
						adcVal <<= 8;
						adcVal += adcResult[i + byteToADCResultNum-1-j];						
					}
				}
				//---保存数据
				this.defaultADCResult.Add(adcVal);
			}
			//---计算转换结果的电压值
			if (this.defaultPowerResult==null)
			{
				this.defaultPowerResult = new List<float>();
			}
			else
			{
				this.defaultPowerResult.Clear();
			}
			float adcPower = 0;
			for ( i = 0; i < this.defaultADCResult.Count; i++)
			{
				adcPower = (this.defaultVREF * this.defaultADCResult[i]) / (1 << this.defaultADCBits);
				this.defaultPowerResult.Add(adcPower);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="adcResult"></param>
		/// <param name="position"></param>
		/// <param name="isHighFirst"></param>
		public virtual void Init(List<byte> adcResult, int position = 0, bool isHighFirst = true)
		{
			this.Init(adcResult.ToArray(), position, isHighFirst);
		}

		#endregion

		#region 私有函数

		#endregion

	}
}
