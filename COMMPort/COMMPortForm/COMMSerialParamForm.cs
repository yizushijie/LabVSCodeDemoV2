using Harry.LabUserGenFunc;
using Harry.LabWinAPI;
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
	public partial class COMMSerialParamForm : COMMBaseForm
	{

		#region 变量定义

		private System.Windows.Forms.Timer defaultTimer = new System.Windows.Forms.Timer();

		private int defaultTimerCount = 0;

		#endregion

		#region 属性定义

		/// <summary>
		/// 配置参数
		/// </summary>
		public virtual COMMPortParam m_COMMParam
		{
			get
			{
				return this.commSerialPortParam.m_COMMParam;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>

		public COMMSerialParamForm()
		{
			InitializeComponent();
			//---限定最小尺寸
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;

			this.StartUpInit();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cbb"></param>
		public COMMSerialParamForm(string argName)
		{
			InitializeComponent();
			//---限定最小尺寸
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
			//---
			this.Init(argName);

			this.StartUpInit();

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="commSerialPortParam"></param>
		public COMMSerialParamForm(string argName, COMMPortParam commPortParam)
		{
			InitializeComponent();
			//---限定最小尺寸
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
			//---
			this.Init(argName, commPortParam);
			this.StartUpInit();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="commSerialPortParam"></param>
		public COMMSerialParamForm(ComboBox argName, COMMPortParam commSerialPortParam)
		{
			InitializeComponent();
			//---限定最小尺寸
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
			//---刷新设备
			this.Init(argName, commSerialPortParam);
			this.StartUpInit();
		}

		#endregion
		
		#region 公共函数

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="cbb"></param>
		public virtual void Init(string argName)
		{
			this.commSerialPortParam.m_COMMComboBox.Items.Clear();
			this.commSerialPortParam.m_COMMComboBox.Items.Add(argName);
			this.commSerialPortParam.m_COMMComboBox.SelectedIndex = 0;

			//---设置图片
			this.commSerialPortParam.m_COMMPictureBox.Image = Properties.Resources.error;

			//---通信端口的名称不可更改
			this.commSerialPortParam.RefreshComboBox(this.commSerialPortParam.m_COMMComboBox, true/*false*/);

			//---注册事件
			this.commSerialPortParam.m_COMMButton.Click += new EventHandler(this.Button_Click);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		public virtual void Init(ComboBox argName)
		{
			int i = 0;
			//---刷新设备存在的通信端口
			this.commSerialPortParam.m_COMMComboBox.Items.Clear();
			for (i = 0; i < argName.Items.Count; i++)
			{
				this.commSerialPortParam.m_COMMComboBox.Items.Add(argName.Items[i]);
			}
			this.commSerialPortParam.m_COMMComboBox.SelectedIndex = argName.SelectedIndex;

			//---设置图片
			this.commSerialPortParam.m_COMMPictureBox.Image = Properties.Resources.error;
			//---通信端口的名称不可更改
			this.commSerialPortParam.RefreshComboBox(this.commSerialPortParam.m_COMMComboBox, true/*false*/);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		public virtual void Init(string argName,COMMPortParam commSerialPortParam)
		{
			this.Init(argName);
			if (commSerialPortParam==null)
			{
				return;
			}
			//---波特率
			int index = this.commSerialPortParam.m_COMMBaudRateComboBox.Items.IndexOf(commSerialPortParam.defaultBaudRate);
			if (index<0)
			{
				this.commSerialPortParam.m_COMMBaudRateComboBox.Items.Add(commSerialPortParam.defaultBaudRate);
				this.commSerialPortParam.m_COMMBaudRateComboBox.SelectedIndex = this.commSerialPortParam.m_COMMBaudRateComboBox.Items.Count - 1;
			}
			else
			{
				this.commSerialPortParam.m_COMMBaudRateComboBox.SelectedIndex = index;
			}
			//---数据位
			index= this.commSerialPortParam.m_COMMDataBitsComboBox.Items.IndexOf(commSerialPortParam.defaultDataBits);
			if (index<0)
			{
				this.commSerialPortParam.m_COMMDataBitsComboBox.SelectedIndex = 0;
			}
			else
			{
				this.commSerialPortParam.m_COMMDataBitsComboBox.SelectedIndex = index;
			}
			//---停止位
			index = this.commSerialPortParam.m_COMMStopBitsComboBox.Items.IndexOf(commSerialPortParam.defaultStopBits);
			if (index < 0)
			{
				this.commSerialPortParam.m_COMMStopBitsComboBox.SelectedIndex = 0;
			}
			else
			{
				this.commSerialPortParam.m_COMMStopBitsComboBox.SelectedIndex = index;
			}
			//---校验位
			index = this.commSerialPortParam.m_COMMParityComboBox.Items.IndexOf(commSerialPortParam.defaultParity);
			if (index < 0)
			{
				this.commSerialPortParam.m_COMMParityComboBox.SelectedIndex = 0;
			}
			else
			{
				this.commSerialPortParam.m_COMMParityComboBox.SelectedIndex = index;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argName"></param>
		public virtual void Init(ComboBox argName, COMMPortParam commSerialPortParam)
		{
			this.Init(argName);
			if (commSerialPortParam == null)
			{
				return;
			}
			//---波特率
			int index = this.commSerialPortParam.m_COMMBaudRateComboBox.Items.IndexOf(commSerialPortParam.defaultBaudRate);
			if (index < 0)
			{
				this.commSerialPortParam.m_COMMBaudRateComboBox.Items.Add(commSerialPortParam.defaultBaudRate);
				this.commSerialPortParam.m_COMMBaudRateComboBox.SelectedIndex = this.commSerialPortParam.m_COMMBaudRateComboBox.Items.Count - 1;
			}
			else
			{
				this.commSerialPortParam.m_COMMBaudRateComboBox.SelectedIndex = index;
			}
			//---数据位
			index = this.commSerialPortParam.m_COMMDataBitsComboBox.Items.IndexOf(commSerialPortParam.defaultDataBits);
			if (index < 0)
			{
				this.commSerialPortParam.m_COMMDataBitsComboBox.SelectedIndex = 0;
			}
			else
			{
				this.commSerialPortParam.m_COMMDataBitsComboBox.SelectedIndex = index;
			}
			//---停止位
			index = this.commSerialPortParam.m_COMMStopBitsComboBox.Items.IndexOf(commSerialPortParam.defaultStopBits);
			if (index < 0)
			{
				this.commSerialPortParam.m_COMMStopBitsComboBox.SelectedIndex = 0;
			}
			else
			{
				this.commSerialPortParam.m_COMMStopBitsComboBox.SelectedIndex = index;
			}
			//---校验位
			index = this.commSerialPortParam.m_COMMParityComboBox.Items.IndexOf(commSerialPortParam.defaultParity);
			if (index < 0)
			{
				this.commSerialPortParam.m_COMMParityComboBox.SelectedIndex = 0;
			}
			else
			{
				this.commSerialPortParam.m_COMMParityComboBox.SelectedIndex = index;
			}
		}


		/// <summary>
		/// 按键点击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void Button_Click(object sender, System.EventArgs e)
		{
			//---停止定时器的运行
			this.defaultTimer.Enabled = false;
			//---获取配置的参数
			this.commSerialPortParam.m_COMMParam.defaultName	 = this.commSerialPortParam.m_COMMComboBox.Text;
			this.commSerialPortParam.m_COMMParam.defaultBaudRate = this.commSerialPortParam.m_COMMBaudRateComboBox.Text;
			this.commSerialPortParam.m_COMMParam.defaultDataBits = this.commSerialPortParam.m_COMMDataBitsComboBox.Text;
			this.commSerialPortParam.m_COMMParam.defaultParity   = this.commSerialPortParam.m_COMMParityComboBox.Text;
			this.commSerialPortParam.m_COMMParam.defaultStopBits = this.commSerialPortParam.m_COMMStopBitsComboBox.Text;
			//---返回操作完成状态
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		/// <summary>
		/// 定时器滴答事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void Timer_Tick(object sender, EventArgs e)
		{
			//---获取鼠标在控件中的位置
			Point mousePoint = this.commSerialPortParam.groupBox_COMM.PointToClient(MousePosition);
			if ((mousePoint.X>0)&&(mousePoint.Y<-10))
			{
				if (this.defaultTimerCount <2)
				{
					this.defaultTimerCount++;
					return;
				}
			}
			this.defaultTimerCount = 0;
			//---判断鼠标是否移除控件的位置
			if (!this.ClientRectangle.Contains(mousePoint))
			{
				//---停止定时器的运行
				this.defaultTimer.Enabled = false;
				//---返回状态是中止
				this.DialogResult = System.Windows.Forms.DialogResult.Abort;
			}
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

		#region 私有函数


		/// <summary>
		/// 启动初始化
		/// </summary>
		private void StartUpInit()
		{
			this.commSerialPortParam.TabIndex = 0;
			//---注册事件
			this.commSerialPortParam.m_COMMButton.Click += new EventHandler(this.Button_Click);
			
			//---启动定时器用于检测鼠标离开界面导致弹出的浮动窗体不能够及时关闭
			if (this.defaultTimer==null)
			{
				this.defaultTimer = new System.Windows.Forms.Timer();
			}
			this.defaultTimer.Interval = 300;
			this.defaultTimer.Enabled = true;
			this.defaultTimer.Tick+=new EventHandler(this.Timer_Tick);
		}

		#endregion
	}
}
