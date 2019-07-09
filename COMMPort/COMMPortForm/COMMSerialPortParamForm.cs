using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Harry.LabCOMMPort
{
	public partial class COMMSerialPortParamForm : COMMBaseForm
	{

		#region 变量定义


		#endregion

		#region 属性定义

		/// <summary>
		/// 配置参数
		/// </summary>
		public virtual COMMSerialPortParam m_COMMPortParam
		{
			get
			{
				return this.commSerialPortPlusFullParam.m_COMMPortParam;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>

		public COMMSerialPortParamForm()
		{
			InitializeComponent();
			//---限定最小尺寸
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cbb"></param>
		public COMMSerialPortParamForm(string argName)
		{
			InitializeComponent();
			//---限定最小尺寸
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
			//---
			this.Init(argName);

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="commSerialPortParam"></param>
		public COMMSerialPortParamForm(string argName, COMMSerialPortParam commSerialPortParam)
		{
			InitializeComponent();
			//---限定最小尺寸
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
			//---
			this.Init(argName, commSerialPortParam);

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="commSerialPortParam"></param>
		public COMMSerialPortParamForm(ComboBox argName, COMMSerialPortParam commSerialPortParam)
		{
			InitializeComponent();
			//---限定最小尺寸
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
			//---刷新设备
			this.Init(argName, commSerialPortParam);

		}

		#endregion

		#region 函数定义

		#region 公共函数

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="cbb"></param>
		public virtual void Init(string argName)
		{
			this.commSerialPortPlusFullParam.m_COMMComboBox.Items.Clear();
			this.commSerialPortPlusFullParam.m_COMMComboBox.Items.Add(argName);
			this.commSerialPortPlusFullParam.m_COMMComboBox.SelectedIndex = 0;

			//---设置图片
			this.commSerialPortPlusFullParam.m_PictureBoxCOMMState.Image = Properties.Resources.error;

			//---通信端口的名称不可更改
			this.commSerialPortPlusFullParam.RefreshComboBox(this.commSerialPortPlusFullParam.m_COMMComboBox, true/*false*/);

			//---注册事件
			this.commSerialPortPlusFullParam.m_ButtonCOMMInit.Click += new EventHandler(this.Button_Click);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		public virtual void Init(ComboBox argName)
		{
			int i = 0;
			//---刷新设备存在的通信端口
			this.commSerialPortPlusFullParam.m_COMMComboBox.Items.Clear();
			for (i = 0; i < argName.Items.Count; i++)
			{
				this.commSerialPortPlusFullParam.m_COMMComboBox.Items.Add(argName.Items[i]);
			}
			this.commSerialPortPlusFullParam.m_COMMComboBox.SelectedIndex = argName.SelectedIndex;

			//---设置图片
			this.commSerialPortPlusFullParam.m_PictureBoxCOMMState.Image = Properties.Resources.error;
			//---通信端口的名称不可更改
			this.commSerialPortPlusFullParam.RefreshComboBox(this.commSerialPortPlusFullParam.m_COMMComboBox, true/*false*/);
			//---注册事件
			this.commSerialPortPlusFullParam.m_ButtonCOMMInit.Click += new EventHandler(this.Button_Click);

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		public virtual void Init(string argName,COMMSerialPortParam commSerialPortParam)
		{
			this.Init(argName);
			if (commSerialPortParam==null)
			{
				return;
			}
			//---波特率
			int index = this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortBaudRate.Items.IndexOf(commSerialPortParam.defaultBaudRate);
			if (index<0)
			{
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortBaudRate.Items.Add(commSerialPortParam.defaultBaudRate);
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortBaudRate.SelectedIndex = this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortBaudRate.Items.Count - 1;
			}
			else
			{
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortBaudRate.SelectedIndex = index;
			}
			//---数据位
			index= this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortDataBits.Items.IndexOf(commSerialPortParam.defaultDataBits);
			if (index<0)
			{
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortDataBits.SelectedIndex = 0;
			}
			else
			{
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortDataBits.SelectedIndex = index;
			}
			//---停止位
			index = this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortStopBits.Items.IndexOf(commSerialPortParam.defaultStopBits);
			if (index < 0)
			{
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortStopBits.SelectedIndex = 0;
			}
			else
			{
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortStopBits.SelectedIndex = index;
			}
			//---校验位
			index = this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortParity.Items.IndexOf(commSerialPortParam.defaultParity);
			if (index < 0)
			{
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortParity.SelectedIndex = 0;
			}
			else
			{
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortParity.SelectedIndex = index;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		public virtual void Init(ComboBox argName, COMMSerialPortParam commSerialPortParam)
		{
			this.Init(argName);
			if (commSerialPortParam == null)
			{
				return;
			}
			//---波特率
			int index = this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortBaudRate.Items.IndexOf(commSerialPortParam.defaultBaudRate);
			if (index < 0)
			{
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortBaudRate.Items.Add(commSerialPortParam.defaultBaudRate);
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortBaudRate.SelectedIndex = this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortBaudRate.Items.Count - 1;
			}
			else
			{
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortBaudRate.SelectedIndex = index;
			}
			//---数据位
			index = this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortDataBits.Items.IndexOf(commSerialPortParam.defaultDataBits);
			if (index < 0)
			{
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortDataBits.SelectedIndex = 0;
			}
			else
			{
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortDataBits.SelectedIndex = index;
			}
			//---停止位
			index = this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortStopBits.Items.IndexOf(commSerialPortParam.defaultStopBits);
			if (index < 0)
			{
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortStopBits.SelectedIndex = 0;
			}
			else
			{
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortStopBits.SelectedIndex = index;
			}
			//---校验位
			index = this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortParity.Items.IndexOf(commSerialPortParam.defaultParity);
			if (index < 0)
			{
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortParity.SelectedIndex = 0;
			}
			else
			{
				this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortParity.SelectedIndex = index;
			}
		}


		/// <summary>
		/// 按键点击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Button_Click(object sender, System.EventArgs e)
		{
			this.commSerialPortPlusFullParam.m_COMMPortParam.defaultName = this.commSerialPortPlusFullParam.comboBox_COMMName.Text;
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		public void SetComboBoxText(string text)
		{
			this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortBaudRate.Text = text;
		}
		/// <summary>
		/// 关闭窗体
		/// </summary>
		public override void CloseForm()
		{
			base.CloseForm();
			this.Dispose();
		}

		#endregion

		#endregion

	}
}
