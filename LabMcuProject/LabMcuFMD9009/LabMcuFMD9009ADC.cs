using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabMcuProject
{
	public partial  class LabMcuFMD9009
	{
		#region 变量定义

		#endregion

		#region 属性定义

		public override string[] m_ADCVREFMode
		{
			get
			{
				base.m_ADCVREFMode = new string[]
				{
					"VREF_AREF",
					"VREF_AVCC",
					"VREF_BG1 ",
					"VREF_BG2 "
				};
				return base.m_ADCVREFMode;
			}
			set
			{
				//base.m_ADCVREFMode = new string[]
				//{
				//	"VREF_AREF",
				//	"VREF_AVCC",
				//	"VREF_BG1 ",
				//	"VREF_BG2 "
				//};
				base.m_ADCVREFMode = value;
			}
		}

		/// <summary>
		/// ADC通道的选择
		/// </summary>
		public override string[] m_ADCChannel
		{
			get
			{
				base.m_ADCChannel = new string[]
				{
					"ADC0",
					"ADC1",
					"ADC2",
					"ADC3",
					"ADC4",
					"ADC5",
					"ADC6",
					"ADC7",
					"ADC0P_ADC0N_X10"   ,
					"ADC1P_ADC0N_X10"   ,
					"ADC0P_ADC0N_X200"  ,
					"ADC1P_ADC0N_X200"  ,
					"ADC2P_ADC2N_X10"   ,
					"ADC3P_ADC2N_X10"   ,
					"ADC2P_ADC2N_X200"  ,
					"ADC3P_ADC2N_X200"  ,
					"ADC0P_ADC1N_X1"    ,
					"ADC1P_ADC1N_X1"    ,
					"ADC2P_ADC1N_X1"    ,
					"ADC3P_ADC1N_X1"    ,
					"ADC4P_ADC1N_X1"    ,
					"ADC5P_ADC1N_X1"    ,
					"ADC6P_ADC1N_X1"    ,
					"ADC7P_ADC1N_X1"    ,
					"ADC0P_ADC2N_X1"    ,
					"ADC1P_ADC2N_X1"    ,
					"ADC2P_ADC2N_X1"    ,
					"ADC3P_ADC2N_X1"    ,
					"ADC4P_ADC2N_X1"    ,
					"ADC5P_ADC2N_X1"    ,
					"BG1" ,
					"GND"
				};
				return base.m_ADCChannel;
			}
			set
			{
				//base.m_ADCChannel = new string[]
				//{
				//	"ADC0",
				//	"ADC1",
				//	"ADC2",
				//	"ADC3",
				//	"ADC4",
				//	"ADC5",
				//	"ADC6",
				//	"ADC7",
				//	"ADC0P_ADC0N_X10"   ,
				//	"ADC1P_ADC0N_X10"   ,
				//	"ADC0P_ADC0N_X200"  ,
				//	"ADC1P_ADC0N_X200"  ,
				//	"ADC2P_ADC2N_X10"   ,
				//	"ADC3P_ADC2N_X10"   ,
				//	"ADC2P_ADC2N_X200"  ,
				//	"ADC3P_ADC2N_X200"  ,
				//	"ADC0P_ADC1N_X1"    ,
				//	"ADC1P_ADC1N_X1"    ,
				//	"ADC2P_ADC1N_X1"    ,
				//	"ADC3P_ADC1N_X1"    ,
				//	"ADC4P_ADC1N_X1"    ,
				//	"ADC5P_ADC1N_X1"    ,
				//	"ADC6P_ADC1N_X1"    ,
				//	"ADC7P_ADC1N_X1"    ,
				//	"ADC0P_ADC2N_X1"    ,
				//	"ADC1P_ADC2N_X1"    ,
				//	"ADC2P_ADC2N_X1"    ,
				//	"ADC3P_ADC2N_X1"    ,
				//	"ADC4P_ADC2N_X1"    ,
				//	"ADC5P_ADC2N_X1"    ,
				//	"BG1" ,
				//	"GND"
				//};
				base.m_ADCChannel = value;
			}
		}

		#endregion

		#region 构造函数

		#endregion

		#region 公共函数

		#endregion

		#region 私有函数

		#endregion
	}
}
