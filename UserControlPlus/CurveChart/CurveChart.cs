using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Harry.LabUserControlPlus
{
	public partial class CurveChart : UserControl
	{

		#region 变量定义

		#endregion

		#region 属性定义

		/// <summary>
		/// 
		/// </summary>
		public virtual ZedGraphControl m_ZedGraph 
		{
			get
			{
				return this.zedGraphCurveChart;
			}
			set
			{
				this.zedGraphCurveChart = value;
			}
		}

		/// <summary>
		/// 标题栏
		/// </summary>
		[Description("标题栏"), Category("自定义属性")]
		public virtual string m_Title
		{
			get
			{
				return this.zedGraphCurveChart.GraphPane.Title.Text;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.Title.Text = value;
			}
		}

		/// <summary>
		/// X轴标题栏
		/// </summary>
		[Description("X轴标题栏"), Category("自定义属性")]
		public virtual string m_XAxisTitle
		{
			get
			{
				return this.zedGraphCurveChart.GraphPane.XAxis.Title.Text;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.XAxis.Title.Text = value;
			}
		}

		/// <summary>
		/// Y轴标题栏
		/// </summary>
		[Description("Y轴标题栏"), Category("自定义属性")]
		public virtual string m_YAxisTitle
		{
			get
			{
				return this.zedGraphCurveChart.GraphPane.YAxis.Title.Text;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.YAxis.Title.Text = value;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public CurveChart()
		{
			InitializeComponent();
			//---初始化控件
			this.InitZedGraph();
		}
		#endregion

		#region 私有函数

		/// <summary>
		/// 初始化
		/// </summary>
		private void InitZedGraph()
		{
			//---垂直参考线
			//---显示大网格
			this.zedGraphCurveChart.GraphPane.YAxis.MajorGrid.IsVisible = true;

			//---显示小网格
			//this.zedGraphCurveChart.GraphPane.YAxis.MinorGrid.IsVisible = true;

			//---大网格实线显示
			this.zedGraphCurveChart.GraphPane.YAxis.MajorGrid.DashOff = (float)this.zedGraphCurveChart.GraphPane.YAxis.Scale.MajorStep * 10;

			//---小网格虚线显示
			//this.zedGraphCurveChart.GraphPane.YAxis.MinorGrid.DashOff = 1;

			//---网格点的步进刻度
			//this.zedGraphCurveChart.GraphPane.YAxis.Scale.MajorStep =5;
			//this.zedGraphControl_myChart.GraphPane.YAxis.Scale.MinorStep = this.zedGraphControl_myChart.GraphPane.YAxis.Scale.MajorStep / 5.0;

			//---Y轴扫描的最大值和最小值
			//this.zedGraphControl_myChart.GraphPane.YAxis.Scale.Min = (this.zedGraphControl_myChart.GraphPane.YAxis.Scale.MinorStep*(-1.00));
			//this.zedGraphControl_myChart.GraphPane.YAxis.Scale.Max = 10;

			//---水平参考线
			//---显示大网格
			this.zedGraphCurveChart.GraphPane.XAxis.MajorGrid.IsVisible = true;

			//---显示小网格
			//this.zedGraphCurveChart.GraphPane.XAxis.MinorGrid.IsVisible = true;

			//---大网格实线显示
			this.zedGraphCurveChart.GraphPane.XAxis.MajorGrid.DashOff = (float)this.zedGraphCurveChart.GraphPane.XAxis.Scale.MajorStep * 10;

			//---小网格虚线显示
			//this.zedGraphCurveChart.GraphPane.XAxis.MinorGrid.DashOff = 1;

			//---网格点的步进刻度
			//this.zedGraphCurveChart.GraphPane.XAxis.Scale.MajorStep = 2;
			//this.zedGraphControl_myChart.GraphPane.XAxis.Scale.MinorStep = this.zedGraphControl_myChart.GraphPane.XAxis.Scale.MajorStep / 5.0;

			//---X轴扫描的最大值和最小值
			//this.zedGraphCurveChart.GraphPane.XAxis.Scale.Min = 0;
			//this.zedGraphCurveChart.GraphPane.XAxis.Scale.Max = 10;
			//---滚动条自动滚动到最右边
			//this.zedGraphControl_myChart.ScrollMaxX = this.zedGraphControl_myChart.GraphPane.XAxis.Scale.Max;

			//---是否显示横向滚动条
			this.zedGraphCurveChart.IsShowHScrollBar = true;
			//---是否显示纵向滚动条
			this.zedGraphCurveChart.IsShowVScrollBar = true;
			this.zedGraphCurveChart.IsAutoScrollRange = true;

			//---是否显示右键菜单，如果指定了ContextMenuStrip会一直显示指定的ContextMenu
			this.zedGraphCurveChart.IsShowContextMenu = true;

			//--- 复制图像时是否显示提示信息
			//zedGraph.IsShowCopyMessage
			///---鼠标在图表上移动时是否显示鼠标所在点对应的坐标值
			//zedGraph.IsShowCursorValues

			//---鼠标经过图表上的点时是否气泡显示该点所对应的值
			this.zedGraphCurveChart.IsShowPointValues = true;
			//---处理鼠标经过图表上的点时是否气泡显示该点所对应的值的事件
			this.zedGraphCurveChart.PointValueEvent += new ZedGraphControl.PointValueHandler(this.PointValueEventHandler);

			//---是否允许横向缩放
			this.zedGraphCurveChart.IsEnableHZoom = true;
			//使用滚轮时以鼠标所在点进行缩放还是以图形中心进行缩放
			//this.zedGraphControl_myChart.IsZoomOnMouseCenter=false;
			//---是否允许纵向缩放
			this.zedGraphCurveChart.IsEnableVZoom = true;
			//---放大缩小
			this.zedGraphCurveChart.ZoomStepFraction = 0.1;
			//---是否允许缩放
			this.zedGraphCurveChart.IsEnableZoom = true;
			//---缩放事件处理
			this.zedGraphCurveChart.ZoomEvent += new ZedGraphControl.ZoomEventHandler(this.ZoomEventHandler);

			//---在图表是添加一些文本
			//---左键拖拽放大\n鼠标中键滚放缩\n右键菜单
			//TextObj text = new TextObj( "Zoom: left mouse & drag\nPan: middle mouse & drag\nContext Menu: right mouse",
			//							0.05f, 0.95f, CoordType.ChartFraction, AlignH.Left, AlignV.Bottom);
			//text.FontSpec.StringAlignment = StringAlignment.Near;
			//this.zedGraphControl_myChart.GraphPane.GraphObjList.Add(text);

			//---处理自定义X轴刻度格式事件
			///this.zedGraphControl_myChart.GraphPane.XAxis.ScaleFormatEvent += new Axis.ScaleFormatHandler(XAxisScaleFormatEventHandler);
			//---处理自定义Y轴刻度格式事件
			///this.zedGraphControl_myChart.GraphPane.YAxis.ScaleFormatEvent += new Axis.ScaleFormatHandler(YScaleFormatEventHandler);

			//---将刷新图形控件
			this.RefreshZedGraph();
		}
		#endregion

		#region 公共函数
		/// <summary>
		/// 处理鼠标经过图表上的点时是否气泡显示该点所对应的值
		/// </summary>
		/// <param name="control"></param>
		/// <param name="pane"></param>
		/// <param name="curve"></param>
		/// <param name="iPt"></param>
		/// <returns></returns>
		private string PointValueEventHandler(ZedGraphControl control, GraphPane pane, CurveItem curve, int iPt)
		{
			//---获取点的值
			PointPair pt = curve[iPt];
			//---返回的结果
			string _return = "X:" + pt.X.ToString("f2") + "\r\n" + "Y:" + pt.Y.ToString("f2") + "\r\n";
			return _return;
		}

		/// <summary>
		/// 缩放事件处理
		/// </summary>
		/// <param name="control"></param>
		/// <param name="oldState"></param>
		/// <param name="newState"></param>
		private void ZoomEventHandler(ZedGraphControl control, ZoomState oldState, ZoomState newState)
		{

		}

		/// <summary>
		/// 处理自定义X轴刻度格式
		/// </summary>
		/// <param name="pane"></param>
		/// <param name="axis"></param>
		/// <param name="val"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public string XAxisScaleFormatEventHandler(GraphPane pane, Axis axis, double val, int index)
		{
			return (val + 50).ToString();
		}

		/// <summary>
		/// 适应右键菜单使用中文
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="menuStrip"></param>
		/// <param name="mousePt"></param>
		/// <param name="objState"></param>
		private void ContextMenuBuilderHandler(ZedGraphControl sender, ContextMenuStrip menuStrip, Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
		{
			try
			{
				//每次循环只能遍历一个键
				foreach (ToolStripMenuItem item in menuStrip.Items)
				{
					if ((string)item.Tag == "copy")
					{
						item.Text = "复制";
						item.Visible = true;
						break;
					}
				}
				foreach (ToolStripMenuItem item in menuStrip.Items)
				{
					if ((string)item.Tag == "save_as")
					{
						item.Text = "另存图表";
						item.Visible = true;
						break;
					}
				}

				foreach (ToolStripMenuItem item in menuStrip.Items)
				{
					if ((string)item.Tag == "show_val")
					{
						item.Text = "显示XY值";
						item.Visible = true;
						break;
					}
				}
				foreach (ToolStripMenuItem item in menuStrip.Items)
				{
					if ((string)item.Tag == "unzoom")
					{
						item.Text = "上一视图";
						item.Visible = true;
						break;
					}
				}
				foreach (ToolStripMenuItem item in menuStrip.Items)
				{
					if ((string)item.Tag == "undo_all")
					{
						item.Text = "还原缩放/移动";
						item.Visible = true;
						break;
					}
				}
				foreach (ToolStripMenuItem item in menuStrip.Items)
				{
					if ((string)item.Tag == "print")
					{
						menuStrip.Items.Remove(item);
						item.Visible = false; //不显示
						break;
					}
				}
				foreach (ToolStripMenuItem item in menuStrip.Items)
				{
					if ((string)item.Tag == "page_setup")
					{
						menuStrip.Items.Remove(item);//移除菜单项
						item.Visible = false; //不显示
						break;
					}
				}
				foreach (ToolStripMenuItem item in menuStrip.Items)
				{
					if ((string)item.Tag == "set_default")
					{
						menuStrip.Items.Remove(item);//移除菜单项
						item.Visible = false; //不显示
						break;
					}
				}

			}
			catch (System.Exception ex)
			{
				MessageBox.Show("初始化右键菜单错误" + ex.ToString());
			}
		}

		/// <summary>
		/// 处理自定义Y轴刻度格式
		/// </summary>
		/// <param name="pane"></param>
		/// <param name="axis"></param>
		/// <param name="val"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public string YAxisScaleFormatEventHandler(GraphPane pane, Axis axis, double val, int index)
		{
			return (val + 50).ToString();
		}

		/// <summary>
		/// 刷新控件的值
		/// </summary>
		public virtual void RefreshZedGraph()
		{
			this.zedGraphCurveChart.AxisChange();
			//---异步调用
			if (this.zedGraphCurveChart.InvokeRequired)
			{
				this.zedGraphCurveChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 this.zedGraphCurveChart.Refresh();
								 }));
			}
			else
			{
				this.zedGraphCurveChart.Refresh();
			}
		}

		#endregion

	}
}
