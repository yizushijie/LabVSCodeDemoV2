using Harry.LabMcuProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabMcuForm
{
	public partial class LabMcuADCFMD9009Form : LabMcuADCBaseForm
	{

		#region 变量定义

		#endregion

		#region 属性定义

		#endregion

		#region 构造函数

		public LabMcuADCFMD9009Form() : base()
		{
			this.StartUpInit();

			InitializeComponent();
		}

		#endregion

		#region 公共函数

		/// <summary>
		/// 
		/// </summary>
		public override void Init()
		{
			this.m_ComboBoxSelectADCVREFMode.Items.Clear();
			this.m_ComboBoxSelectADCChannel.Items.Clear();

			if ((this.m_LabMcuDevice != null) && (this.m_LabMcuDevice.m_ADCVREFMode.Length > 1))
			{
				this.m_ComboBoxSelectADCVREFMode.Items.AddRange(this.m_LabMcuDevice.m_ADCVREFMode);
				this.m_ComboBoxSelectADCVREFMode.SelectedIndex = 0;
			}

			if ((this.m_LabMcuDevice != null) && (this.m_LabMcuDevice.m_ADCChannel.Length > 1))
			{
				this.m_ComboBoxSelectADCChannel.Items.AddRange(this.m_LabMcuDevice.m_ADCChannel);
				this.m_ComboBoxSelectADCChannel.SelectedIndex = 0;
			}
		}

		#endregion

		#region 私有函数
		private void StartUpInit()
		{
			this.m_LabMcuDevice = new LabMcuFMD9009();

			this.Init();
		}
		#endregion
	}
}
