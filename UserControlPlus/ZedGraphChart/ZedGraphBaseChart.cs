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
	public partial class ZedGraphBaseChart : UserControl
	{

		#region 变量定义

		#endregion

		#region 属性定义

		/// <summary>
		/// 
		/// </summary>
		public virtual ZedGraphControl m_ZedGraphChart
		{
			get
			{
				return this.zedGraphChart;
			}
			set
			{
				if (this.zedGraphChart == null)
				{
					this.zedGraphChart = new ZedGraphControl();
				}
				this.zedGraphChart = value;
			}
		}

		/// <summary>
		/// 标题栏
		/// </summary>
		[Description("标题"), Category("自定义属性")]
		public virtual string m_Title
		{
			get
			{
				return this.zedGraphChart.GraphPane.Title.Text;
			}

			set
			{
				this.zedGraphChart.GraphPane.Title.Text = value;
				//---刷新控件
				this.RefreshZedGraph();
			}
		}

		/// <summary>
		/// 标题栏
		/// </summary>
		[Description("标题字体大小"), Category("自定义属性")]
		public virtual float m_TitleFontSize
		{
			get
			{
				return this.zedGraphChart.GraphPane.Title.FontSpec.Size;
			}

			set
			{
				this.zedGraphChart.GraphPane.Title.FontSpec.Size = value;
				//---刷新控件
				this.RefreshZedGraph();
			}
		}

		/// <summary>
		/// X轴标题栏
		/// </summary>
		[Description("X轴标题"), Category("自定义属性")]
		public virtual string m_XAxisTitle
		{
			get
			{
				return this.zedGraphChart.GraphPane.XAxis.Title.Text;
			}

			set
			{
				this.zedGraphChart.GraphPane.XAxis.Title.Text = value;
				//---刷新控件
				this.RefreshZedGraph();
			}
		}

		/// <summary>
		/// X轴标题栏
		/// </summary>
		[Description("X轴标题字体大小"), Category("自定义属性")]
		public virtual float m_XAxisTitleFontSize
		{
			get
			{
				return this.zedGraphChart.GraphPane.XAxis.Title.FontSpec.Size;
			}

			set
			{
				this.zedGraphChart.GraphPane.XAxis.Title.FontSpec.Size = value;
				//---刷新控件
				this.RefreshZedGraph();
			}
		}

		/// <summary>
		/// X轴标题栏
		/// </summary>
		[Description("X轴扫描数据的最大值"), Category("自定义属性")]
		public virtual double m_XAxisScaleMax
		{
			get
			{
				return this.zedGraphChart.GraphPane.XAxis.Scale.Max;
			}

			set
			{
				this.zedGraphChart.GraphPane.XAxis.Scale.Max = value;
				//---刷新控件
				this.RefreshZedGraph();
			}
		}

		/// <summary>
		/// X轴标题栏
		/// </summary>
		[Description("X轴扫描数据的最小值"), Category("自定义属性")]
		public virtual double m_XAxisScaleMin
		{
			get
			{
				return this.zedGraphChart.GraphPane.XAxis.Scale.Min;
			}

			set
			{
				this.zedGraphChart.GraphPane.XAxis.Scale.Min = value;
				//---刷新控件
				this.RefreshZedGraph();
			}
		}

		/// <summary>
		/// X轴标题栏
		/// </summary>
		[Description("X轴最大格点的步进"), Category("自定义属性")]
		public virtual double m_XAxisScaleMajorStep
		{
			get
			{
				return this.zedGraphChart.GraphPane.XAxis.Scale.MajorStep;
			}

			set
			{
				this.zedGraphChart.GraphPane.XAxis.Scale.MajorStep = value;
				this.zedGraphChart.GraphPane.XAxis.Scale.MinorStep = (this.zedGraphChart.GraphPane.XAxis.Scale.MajorStep / 5);
				//---刷新控件
				this.RefreshZedGraph();
			}
		}

		/// <summary>
		/// X轴刻度
		/// </summary>
		[Description("X轴刻度的字体大小"), Category("自定义属性")]
		public virtual float m_XAxisScaleFontSize
		{
			get
			{
				return this.zedGraphChart.GraphPane.XAxis.Scale.FontSpec.Size;
			}

			set
			{
				this.zedGraphChart.GraphPane.XAxis.Scale.FontSpec.Size = value;
				//---刷新控件
				this.RefreshZedGraph();
			}
		}

		/// <summary>
		/// Y轴标题栏
		/// </summary>
		[Description("Y轴标题"), Category("自定义属性")]
		public virtual string m_YAxisTitle
		{
			get
			{
				return this.zedGraphChart.GraphPane.YAxis.Title.Text;
			}

			set
			{
				this.zedGraphChart.GraphPane.YAxis.Title.Text = value;
				//---刷新控件
				this.RefreshZedGraph();
			}
		}

		/// <summary>
		/// Y轴标题栏
		/// </summary>
		[Description("Y轴标题字体大小"), Category("自定义属性")]
		public virtual float m_YAxisTitleFontSize
		{
			get
			{
				return this.zedGraphChart.GraphPane.YAxis.Title.FontSpec.Size;
			}

			set
			{
				this.zedGraphChart.GraphPane.YAxis.Title.FontSpec.Size = value;
				//---刷新控件
				this.RefreshZedGraph();
			}
		}

		/// <summary>
		/// X轴标题栏
		/// </summary>
		[Description("Y轴数据最大值"), Category("自定义属性")]
		public virtual double m_YAxisScaleMax
		{
			get
			{
				return this.zedGraphChart.GraphPane.YAxis.Scale.Max;
			}

			set
			{
				this.zedGraphChart.GraphPane.YAxis.Scale.Max = value;
				//---刷新控件
				this.RefreshZedGraph();
			}
		}

		/// <summary>
		/// X轴标题栏
		/// </summary>
		[Description("Y轴数据最小值"), Category("自定义属性")]
		public virtual double m_YAxisScaleMin
		{
			get
			{
				return this.zedGraphChart.GraphPane.YAxis.Scale.Min;
			}

			set
			{
				this.zedGraphChart.GraphPane.YAxis.Scale.Min = value;
				//---刷新控件
				this.RefreshZedGraph();
			}
		}

		/// <summary>
		/// X轴标题栏
		/// </summary>
		[Description("Y轴最大格点的步进"), Category("自定义属性")]
		public virtual double m_YAxisScaleMajorStep
		{
			get
			{
				return this.zedGraphChart.GraphPane.YAxis.Scale.MajorStep;
			}

			set
			{
				this.zedGraphChart.GraphPane.YAxis.Scale.MajorStep = value;
				this.zedGraphChart.GraphPane.YAxis.Scale.MinorStep = (this.zedGraphChart.GraphPane.YAxis.Scale.MajorStep / 5);
				//---刷新控件
				this.RefreshZedGraph();
			}
		}

		/// <summary>
		/// Y轴刻度
		/// </summary>
		[Description("Y轴刻度的字体大小"), Category("自定义属性")]
		public virtual float m_YAxisScaleFontSize
		{
			get
			{
				return this.zedGraphChart.GraphPane.YAxis.Scale.FontSpec.Size;
			}

			set
			{
				this.zedGraphChart.GraphPane.YAxis.Scale.FontSpec.Size = value;
				//---刷新控件
				this.RefreshZedGraph();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Description("曲线名称的字体的大小"), Category("自定义属性")]
		public virtual float m_FontSize
		{
			get
			{
				return this.zedGraphChart.GraphPane.Legend.FontSpec.Size;
			}

			set
			{
				this.zedGraphChart.GraphPane.Legend.FontSpec.Size = value;
				//---刷新控件
				this.RefreshZedGraph();
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public ZedGraphBaseChart()
		{
			InitializeComponent();
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
			this.zedGraphChart.GraphPane.YAxis.MajorGrid.IsVisible = true;

			//---显示小网格
			//this.zedGraphCurveChart.GraphPane.YAxis.MinorGrid.IsVisible = true;

			//---大网格实线显示
			//this.zedGraphCurveChart.GraphPane.YAxis.MajorGrid.DashOff = (float)this.zedGraphCurveChart.GraphPane.YAxis.Scale.MajorStep * 50;

			this.zedGraphChart.GraphPane.YAxis.MajorGrid.DashOff = (float)this.zedGraphChart.GraphPane.YAxis.Scale.MajorStep * 50;

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
			this.zedGraphChart.GraphPane.XAxis.MajorGrid.IsVisible = true;

			//---显示小网格
			//this.zedGraphCurveChart.GraphPane.XAxis.MinorGrid.IsVisible = true;

			//---大网格实线显示
			this.zedGraphChart.GraphPane.XAxis.MajorGrid.DashOff = (float)this.zedGraphChart.GraphPane.XAxis.Scale.MajorStep * 50;

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
			this.zedGraphChart.IsShowHScrollBar = true;
			//---是否显示纵向滚动条
			this.zedGraphChart.IsShowVScrollBar = true;
			this.zedGraphChart.IsAutoScrollRange = true;

			//---是否显示右键菜单，如果指定了ContextMenuStrip会一直显示指定的ContextMenu
			this.zedGraphChart.IsShowContextMenu = true;

			//--- 复制图像时是否显示提示信息
			//zedGraph.IsShowCopyMessage
			///---鼠标在图表上移动时是否显示鼠标所在点对应的坐标值
			//zedGraph.IsShowCursorValues

			//---鼠标经过图表上的点时是否气泡显示该点所对应的值
			this.zedGraphChart.IsShowPointValues = true;
			//---处理鼠标经过图表上的点时是否气泡显示该点所对应的值的事件
			this.zedGraphChart.PointValueEvent += new ZedGraphControl.PointValueHandler(this.PointValueEventHandler);

			//---是否允许横向移动
			this.zedGraphChart.IsEnableHPan = true;
			//---是否允许纵向移动
			this.zedGraphChart.IsEnableVPan = true;

			//---是否允许横向缩放
			this.zedGraphChart.IsEnableHZoom = true;
			//使用滚轮时以鼠标所在点进行缩放还是以图形中心进行缩放
			this.zedGraphChart.IsZoomOnMouseCenter = false;
			//---是否允许纵向缩放
			this.zedGraphChart.IsEnableVZoom = true;
			//---放大缩小的灵敏度
			this.zedGraphChart.ZoomStepFraction = 0.1;
			//---是否允许缩放
			this.zedGraphChart.IsEnableZoom = true;
			//this.zedGraphCurveChart.sy
			//---缩放事件处理
			this.zedGraphChart.ZoomEvent += new ZedGraphControl.ZoomEventHandler(this.ZoomEventHandler);

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

			//---右键菜单
			this.zedGraphChart.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(this.ContextMenuBuilderHandler);

			//---刷新图形控件
			this.RefreshZedGraph();

		}

		/// <summary>
		/// 还原缩放或者移动
		/// </summary>
		/// <param name="primaryPane"></param>
		private void RestoreScale(GraphPane primaryPane)
		{
			if (primaryPane != null)
			{
				//Go ahead and save the old zoomstates, which provides an "undo"-like capability
				//ZoomState oldState = primaryPane.ZoomStack.Push( primaryPane, ZoomState.StateType.Zoom );
				ZoomState oldState = new ZoomState(primaryPane, ZoomState.StateType.Zoom);

				using (Graphics g = this.zedGraphChart.CreateGraphics())
				{
					if (this.zedGraphChart.IsSynchronizeXAxes || this.zedGraphChart.IsSynchronizeYAxes)
					{
						foreach (GraphPane pane in zedGraphChart.MasterPane.PaneList)
						{
							pane.ZoomStack.Push(pane, ZoomState.StateType.Zoom);
							this.ResetAutoScale(pane, g);
						}
					}
					else
					{
						primaryPane.ZoomStack.Push(primaryPane, ZoomState.StateType.Zoom);
						this.ResetAutoScale(primaryPane, g);
					}

				}
				this.RefreshZedGraph();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pane"></param>
		/// <param name="g"></param>
		private void ResetAutoScale(GraphPane pane, Graphics g)
		{
			pane.XAxis.Scale.MinAuto = true;
			pane.XAxis.Scale.MaxAuto = true;
			pane.XAxis.Scale.MajorStepAuto = false;
			pane.XAxis.Scale.MinorStepAuto = true;
			pane.XAxis.CrossAuto = true;
			pane.XAxis.Scale.MagAuto = true;
			pane.XAxis.Scale.FormatAuto = true;
			pane.AxisChange(g);

			pane.X2Axis.Scale.MinAuto = true;
			pane.X2Axis.Scale.MaxAuto = true;
			pane.X2Axis.Scale.MajorStepAuto = false;
			pane.X2Axis.Scale.MinorStepAuto = true;
			pane.X2Axis.CrossAuto = true;
			pane.X2Axis.Scale.MagAuto = true;
			pane.X2Axis.Scale.FormatAuto = true;
			pane.AxisChange(g);

			foreach (YAxis axis in pane.YAxisList)
			{
				axis.Scale.MinAuto = true;
				axis.Scale.MaxAuto = true;
				axis.Scale.MajorStepAuto = false;
				axis.Scale.MinorStepAuto = true;
				axis.CrossAuto = true;
				axis.Scale.MagAuto = true;
				axis.Scale.FormatAuto = true;
				pane.AxisChange(g);
			}
			foreach (Y2Axis axis in pane.Y2AxisList)
			{
				axis.Scale.MinAuto = true;
				axis.Scale.MaxAuto = true;
				axis.Scale.MajorStepAuto = false;
				axis.Scale.MinorStepAuto = true;
				axis.CrossAuto = true;
				axis.Scale.MagAuto = true;
				axis.Scale.FormatAuto = true;
				pane.AxisChange(g);
			}
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
		public virtual string PointValueEventHandler(ZedGraphControl control, GraphPane pane, CurveItem curve, int iPt)
		{
			//---获取点的值
			PointPair pt = curve[iPt];
			//---返回的结果
			string _return = "X:" + pt.X.ToString("f2") + "\r\n" + "Y:" + pt.Y.ToString("f2") + "\r\n";
			return _return;
		}

		/// <summary>
		/// 缩放事件处理-
		/// </summary>
		/// <param name="control"></param>
		/// <param name="oldState"></param>
		/// <param name="newState"></param>
		public virtual void ZoomEventHandler(ZedGraphControl control, ZoomState oldState, ZoomState newState)
		{
			ZoomState zs = control.GraphPane.ZoomStack.Top;
			if (zs != null)
			{
				switch (zs.Type)
				{
					case ZoomState.StateType.Pan:
						break;
					case ZoomState.StateType.Scroll:
						break;
					case ZoomState.StateType.WheelZoom:
					case ZoomState.StateType.Zoom:
						//break
					default:
						this.DefaultZoom();
						break;
				}
			}
			else
			{
				this.DefaultZoom();
			}
		}

		/// <summary>
		/// 处理自定义X轴刻度格式
		/// </summary>
		/// <param name="pane"></param>
		/// <param name="axis"></param>
		/// <param name="val"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public virtual string XAxisScaleFormatEventHandler(GraphPane pane, Axis axis, double val, int index)
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
		public virtual void ContextMenuBuilderHandler(ZedGraphControl sender, ContextMenuStrip menuStrip, Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
		{
			/*
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
						item.Text = "";
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
						item.Text = "还原默认大小";
						//menuStrip.Items.Remove(item);//移除菜单项
						item.Visible = false; //不显示
						break;
					}
				}

			}
			catch (System.Exception ex)
			{
				MessageBox.Show("初始化右键菜单错误" + ex.ToString());
			}
			*/
		}

		/// <summary>
		/// 处理自定义Y轴刻度格式
		/// </summary>
		/// <param name="pane"></param>
		/// <param name="axis"></param>
		/// <param name="val"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public virtual string YAxisScaleFormatEventHandler(GraphPane pane, Axis axis, double val, int index)
		{
			return (val + 50).ToString();
		}

		/// <summary>
		/// 刷新控件的值
		/// </summary>
		public virtual void RefreshZedGraph()
		{
			//---异步调用
			if (this.zedGraphChart.InvokeRequired)
			{
				this.zedGraphChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 this.zedGraphChart.AxisChange();
									 this.zedGraphChart.Refresh();
								 }));
			}
			else
			{
				this.zedGraphChart.AxisChange();
				this.zedGraphChart.Refresh();
			}
		}

		/// <summary>
		/// 刷新控件
		/// </summary>
		/// <param name="zedGraph"></param>
		public virtual void RefreshZedGraph(ZedGraphControl zedGraph)
		{
			if (zedGraph!=null)
			{
				//---异步调用
				if (zedGraph.InvokeRequired)
				{
					zedGraph.BeginInvoke((EventHandler)
									 (delegate
									 {
										 zedGraph.AxisChange();
										 zedGraph.Refresh();
									 }));
				}
				else
				{
					zedGraph.AxisChange();
					zedGraph.Refresh();
				}
			}
			
		}

		/// <summary>
		/// 创建控件
		/// </summary>
		/// <param name="zedGraph"></param>
		public virtual void CreateZedGraph(ZedGraphControl zedGraph)
		{
			if (zedGraph != null)
			{
				//---垂直参考线
				//---显示大网格
				zedGraph.GraphPane.YAxis.MajorGrid.IsVisible = true;

				//---显示小网格
				//zedGrapht.GraphPane.YAxis.MinorGrid.IsVisible = true;

				//---大网格实线显示
				//zedGraph.GraphPane.YAxis.MajorGrid.DashOff = (float)this.zedGraphCurveChart.GraphPane.YAxis.Scale.MajorStep * 50;

				zedGraph.GraphPane.YAxis.MajorGrid.DashOff = (float)(zedGraph.GraphPane.YAxis.Scale.MajorStep * 50);

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
				zedGraph.GraphPane.XAxis.MajorGrid.IsVisible = true;

				//---显示小网格
				//this.zedGraphCurveChart.GraphPane.XAxis.MinorGrid.IsVisible = true;

				//---大网格实线显示
				zedGraph.GraphPane.XAxis.MajorGrid.DashOff = (float)(zedGraph.GraphPane.XAxis.Scale.MajorStep * 50);

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
				zedGraph.IsShowHScrollBar = true;
				//---是否显示纵向滚动条
				zedGraph.IsShowVScrollBar = true;
				zedGraph.IsAutoScrollRange = true;

				//---是否显示右键菜单，如果指定了ContextMenuStrip会一直显示指定的ContextMenu
				zedGraph.IsShowContextMenu = true;

				//--- 复制图像时是否显示提示信息
				//zedGraph.IsShowCopyMessage
				///---鼠标在图表上移动时是否显示鼠标所在点对应的坐标值
				//zedGraph.IsShowCursorValues

				//---鼠标经过图表上的点时是否气泡显示该点所对应的值
				zedGraph.IsShowPointValues = true;
				//---处理鼠标经过图表上的点时是否气泡显示该点所对应的值的事件
				zedGraph.PointValueEvent += new ZedGraphControl.PointValueHandler(this.PointValueEventHandler);

				//---是否允许横向移动
				zedGraph.IsEnableHPan = true;
				//---是否允许纵向移动
				zedGraph.IsEnableVPan = true;

				//---是否允许横向缩放
				zedGraph.IsEnableHZoom = true;
				//使用滚轮时以鼠标所在点进行缩放还是以图形中心进行缩放
				zedGraph.IsZoomOnMouseCenter = false;
				//---是否允许纵向缩放
				zedGraph.IsEnableVZoom = true;
				//---放大缩小的灵敏度
				zedGraph.ZoomStepFraction = 0.1;
				//---是否允许缩放
				zedGraph.IsEnableZoom = true;
				//this.zedGraphCurveChart.sy
				//---缩放事件处理
				zedGraph.ZoomEvent += new ZedGraphControl.ZoomEventHandler(this.ZoomEventHandler);

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

				//---右键菜单
				zedGraph.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(this.ContextMenuBuilderHandler);

				//---刷新图形控件
				this.RefreshZedGraph(zedGraph);
			}
		}

		/// <summary>
		/// 清除控件
		/// </summary>
		public virtual void ClearZedGraph()
		{
			//---异步调用
			if (this.zedGraphChart.InvokeRequired)
			{
				this.zedGraphChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 this.zedGraphChart.GraphPane.CurveList.Clear();
								 }));
			}
			else
			{
				this.zedGraphChart.GraphPane.CurveList.Clear();
			}
		}

		/// <summary>
		/// 清除控件
		/// </summary>
		public virtual void ClearZedGraph(ZedGraphControl zedGraph)
		{
			//---异步调用
			if (zedGraph.InvokeRequired)
			{
				zedGraph.BeginInvoke((EventHandler)
								 (delegate
								 {
									 zedGraph.GraphPane.CurveList.Clear();
								 }));
			}
			else
			{
				zedGraph.GraphPane.CurveList.Clear();
			}
		}
		
		/// <summary>
		/// 字体的大小
		/// </summary>
		/// <param name="size"></param>
		public virtual void FontSize(float size, bool isRefresh = true)
		{
			this.m_TitleFontSize = size;
			this.m_XAxisScaleFontSize = size;
			this.m_XAxisTitleFontSize = size;
			this.m_YAxisScaleFontSize = size;
			this.m_YAxisTitleFontSize = size;
			//---修改曲线项字体大小,字体外部有一个矩形框
			this.zedGraphChart.GraphPane.Legend.FontSpec.Size = size;
			////---修改单一曲线字体的大小,字体外部有一个矩形框
			//int i = 0;
			//if (this.zedGraphCurveChart.GraphPane.CurveList.Count > 0)
			//{
			//	for (i = 0; i < this.zedGraphCurveChart.GraphPane.CurveList.Count; i++)
			//	{
			//		if (this.zedGraphCurveChart.GraphPane.CurveList[i].Label.FontSpec == null)
			//		{
			//			this.zedGraphCurveChart.GraphPane.CurveList[i].Label.FontSpec = new FontSpec("Arial",20,Color.Black,true,false,false);
			//		}
			//		this.zedGraphCurveChart.GraphPane.CurveList[i].Label.FontSpec.Size = size;
			//	}
			//}
			if (isRefresh)
			{
				//---刷新显示
				this.RefreshZedGraph();
			}
		}


		/// <summary>
		/// 字体的大小
		/// </summary>
		/// <param name="size"></param>
		public virtual void FontSize(ZedGraphControl zedGraph,float size, bool isRefresh = true)
		{
			zedGraph.GraphPane.Title.FontSpec.Size = size;
			zedGraph.GraphPane.XAxis.Scale.FontSpec.Size = size;
			zedGraph.GraphPane.XAxis.Title.FontSpec.Size = size;
			zedGraph.GraphPane.YAxis.Scale.FontSpec.Size = size;
			zedGraph.GraphPane.YAxis.Title.FontSpec.Size = size;
			//---修改曲线项字体大小,字体外部有一个矩形框
			zedGraph.GraphPane.Legend.FontSpec.Size = (size>2?(size-2):2);
			//---刷新显示
			if (isRefresh)
			{
				this.RefreshZedGraph(zedGraph);
			}
		}

		/// <summary>
		/// 恢复默认大小
		/// </summary>
		public virtual void DefaultZoom()
		{
			if (this.zedGraphChart != null)
			{
				//if(this.zedGraphCurveChart.MasterPane!=null)
				//{
				//	//GraphPane pane = this.zedGraphCurveChart.MasterPane.FindPane(new Point());
				//	//this.RestoreScale(pane);
				//}
				this.RestoreScale(this.zedGraphChart.GraphPane);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void DefaultZoom(ZedGraphControl zedGraph)
		{
			if (zedGraph != null)
			{
				this.RestoreScale(zedGraph.GraphPane);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="size"></param>
		public virtual void Init()
		{
			this.DefaultZoom();
		}

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="size"></param>
		public virtual void Init(float size, bool isRefresh = false)
		{
			this.FontSize(size, isRefresh);
			this.DefaultZoom();
		}

		#endregion

	}
}
