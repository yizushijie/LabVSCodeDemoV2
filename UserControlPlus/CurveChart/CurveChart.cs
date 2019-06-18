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

		/// <summary>
		/// 
		/// </summary>
		private double _oldXAxisRange = 0;

		/// <summary>
		/// 
		/// </summary>
		private double _oldYAxisRange = 0;

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
				if (this.zedGraphCurveChart==null)
				{
					this.zedGraphCurveChart = new ZedGraphControl();
				}
				this.zedGraphCurveChart = value;
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
				return this.zedGraphCurveChart.GraphPane.Title.Text;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.Title.Text = value;
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
				return this.zedGraphCurveChart.GraphPane.Title.FontSpec.Size;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.Title.FontSpec.Size = value;
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
				return this.zedGraphCurveChart.GraphPane.XAxis.Title.Text;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.XAxis.Title.Text = value;
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
				return this.zedGraphCurveChart.GraphPane.XAxis.Title.FontSpec.Size;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.XAxis.Title.FontSpec.Size = value;
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
				return this.zedGraphCurveChart.GraphPane.XAxis.Scale.Max;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.XAxis.Scale.Max = value;
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
				return this.zedGraphCurveChart.GraphPane.XAxis.Scale.Min;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.XAxis.Scale.Min = value;
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
				return this.zedGraphCurveChart.GraphPane.XAxis.Scale.MajorStep;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.XAxis.Scale.MajorStep = value;
				this.zedGraphCurveChart.GraphPane.XAxis.Scale.MinorStep = (this.zedGraphCurveChart.GraphPane.XAxis.Scale.MajorStep / 5);
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
				return this.zedGraphCurveChart.GraphPane.XAxis.Scale.FontSpec.Size;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.XAxis.Scale.FontSpec.Size = value;
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
				return this.zedGraphCurveChart.GraphPane.YAxis.Title.Text;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.YAxis.Title.Text = value;
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
				return this.zedGraphCurveChart.GraphPane.YAxis.Title.FontSpec.Size;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.YAxis.Title.FontSpec.Size = value;
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
				return this.zedGraphCurveChart.GraphPane.YAxis.Scale.Max;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.YAxis.Scale.Max = value;
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
				return this.zedGraphCurveChart.GraphPane.YAxis.Scale.Min;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.YAxis.Scale.Min = value;
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
				return this.zedGraphCurveChart.GraphPane.YAxis.Scale.MajorStep;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.YAxis.Scale.MajorStep = value;
				this.zedGraphCurveChart.GraphPane.YAxis.Scale.MinorStep = (this.zedGraphCurveChart.GraphPane.YAxis.Scale.MajorStep / 5);
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
				return this.zedGraphCurveChart.GraphPane.YAxis.Scale.FontSpec.Size;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.YAxis.Scale.FontSpec.Size = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Description("曲线名称的字体的大小"), Category("自定义属性")]
		public virtual float m_LabelFontSize
		{
			get
			{
				return this.zedGraphCurveChart.GraphPane.Legend.FontSpec.Size;
			}

			set
			{
				this.zedGraphCurveChart.GraphPane.Legend.FontSpec.Size = value;
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
			//this.zedGraphCurveChart.GraphPane.YAxis.MajorGrid.DashOff = (float)this.zedGraphCurveChart.GraphPane.YAxis.Scale.MajorStep * 50;

			this.zedGraphCurveChart.GraphPane.YAxis.MajorGrid.DashOff = (float)this.zedGraphCurveChart.GraphPane.YAxis.Scale.MajorStep * 50;

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
			this.zedGraphCurveChart.GraphPane.XAxis.MajorGrid.DashOff = (float)this.zedGraphCurveChart.GraphPane.XAxis.Scale.MajorStep * 50;

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

			//---是否允许横向移动
			this.zedGraphCurveChart.IsEnableHPan = true;
			//---是否允许纵向移动
			this.zedGraphCurveChart.IsEnableVPan = true;

			//---是否允许横向缩放
			this.zedGraphCurveChart.IsEnableHZoom = true;
			//使用滚轮时以鼠标所在点进行缩放还是以图形中心进行缩放
			this.zedGraphCurveChart.IsZoomOnMouseCenter=false;
			//---是否允许纵向缩放
			this.zedGraphCurveChart.IsEnableVZoom = true;
			//---放大缩小的灵敏度
			this.zedGraphCurveChart.ZoomStepFraction =0.1;
			//---是否允许缩放
			this.zedGraphCurveChart.IsEnableZoom = true;
			//this.zedGraphCurveChart.sy
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

			//---右键菜单
			this.zedGraphCurveChart.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(this.ContextMenuBuilderHandler);

			//---Y轴量程
			this._oldYAxisRange = this.zedGraphCurveChart.GraphPane.YAxis.Scale.Max- this.zedGraphCurveChart.GraphPane.YAxis.Scale.Min;
			//---X轴量程
			this._oldXAxisRange = this.zedGraphCurveChart.GraphPane.XAxis.Scale.Max - this.zedGraphCurveChart.GraphPane.XAxis.Scale.Min;

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

				using (Graphics g = this.zedGraphCurveChart.CreateGraphics())
				{
					if (this.zedGraphCurveChart.IsSynchronizeXAxes || this.zedGraphCurveChart.IsSynchronizeYAxes)
					{
						foreach (GraphPane pane in zedGraphCurveChart.MasterPane.PaneList)
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
			if (zs!=null)
			{
				switch (zs.Type)
				{
					case ZoomState.StateType.Pan:
						break;
					case ZoomState.StateType.Scroll:
						break;
					case ZoomState.StateType.WheelZoom:
					case ZoomState.StateType.Zoom:
						//this.zedGraphCurveChart.GraphPane.YAxis.MajorGrid.DashOff = (float)(50/((this._oldYAxisRange / (this.zedGraphCurveChart.GraphPane.YAxis.Scale.Max- this.zedGraphCurveChart.GraphPane.YAxis.Scale.Min))));
						//this.zedGraphCurveChart.GraphPane.XAxis.MajorGrid.DashOff = (float)(this._oldXAxisRange / (this.zedGraphCurveChart.GraphPane.XAxis.Scale.Max- this.zedGraphCurveChart.GraphPane.XAxis.Scale.Min)) * 50;
						//this.RefreshZedGraph();
						break;
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
			if (this.zedGraphCurveChart.InvokeRequired)
			{
				this.zedGraphCurveChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 this.zedGraphCurveChart.AxisChange();
									 this.zedGraphCurveChart.Refresh();
								 }));
			}
			else
			{
				this.zedGraphCurveChart.AxisChange();
				this.zedGraphCurveChart.Refresh();
			}
		}

		/// <summary>
		/// 刷新控件
		/// </summary>
		/// <param name="zedGraph"></param>
		public virtual void RefreshZedGraph(ZedGraphControl zedGraph)
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

		/// <summary>
		/// 创建控件
		/// </summary>
		/// <param name="zedGraph"></param>
		public virtual void CreateZedGraph(ZedGraphControl zedGraph)
		{
			this.m_ZedGraph = zedGraph;
			this.InitZedGraph();
		}

		/// <summary>
		/// 清除控件
		/// </summary>
		public virtual void ClearZedGraph()
		{
			//---异步调用
			if (this.zedGraphCurveChart.InvokeRequired)
			{
				this.zedGraphCurveChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 this.zedGraphCurveChart.GraphPane.CurveList.Clear();
								 }));
			}
			else
			{
				this.zedGraphCurveChart.GraphPane.CurveList.Clear();
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
		/// 添加数据点
		/// </summary>
		/// <param name="curveName"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public virtual void AddXYPoint(string curveName, double x, double y)
		{
			//---异步调用
			if (this.zedGraphCurveChart.InvokeRequired)
			{
				this.zedGraphCurveChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 //---查空操作
									 if (this.zedGraphCurveChart.GraphPane.CurveList.Count == 0)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
									 }
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.zedGraphCurveChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
									 //---判断曲线是否存在
									 if (ip == null)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
									 }
									 //---添加数据
									 if (ip != null)
									 {
										 ip.Add(x, y);
										 //---刷新显示
										 this.RefreshZedGraph();
									 }
								 }));
			}
			else
			{
				//---查空操作
				if (this.zedGraphCurveChart.GraphPane.CurveList.Count == 0)
				{
					//---添加曲线
					this.AddCurve(curveName);
				}
				//---增加坐标XY轴的点
				IPointListEdit ip = this.zedGraphCurveChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
				//---判断曲线是否存在
				if (ip == null)
				{
					//---添加曲线
					this.AddCurve(curveName);
				}
				//---添加数据
				if (ip != null)
				{
					ip.Add(x, y);

					//---刷新显示
					this.RefreshZedGraph();
				}
			}
		}

		/// <summary>
		/// 添加数据点
		/// </summary>
		/// <param name="curveName"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public virtual void AddXYPoint(string curveName, PointPair xypoint)
		{
			//---异步调用
			if (this.zedGraphCurveChart.InvokeRequired)
			{
				this.zedGraphCurveChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 //---查空操作
									 if (this.zedGraphCurveChart.GraphPane.CurveList.Count == 0)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
									 }
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.zedGraphCurveChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
									 //---判断曲线是否存在
									 if (ip == null)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
									 }
									 //---添加数据
									 if (ip != null)
									 {
										 ip.Add(xypoint);
										 //---刷新显示
										 this.RefreshZedGraph();
									 }
								 }));
			}
			else
			{
				//---查空操作
				if (this.zedGraphCurveChart.GraphPane.CurveList.Count == 0)
				{
					//---添加曲线
					this.AddCurve(curveName);
				}
				//---增加坐标XY轴的点
				IPointListEdit ip = this.zedGraphCurveChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
				//---判断曲线是否存在
				if (ip == null)
				{
					//---添加曲线
					this.AddCurve(curveName);
				}
				//---添加数据
				if (ip != null)
				{
					ip.Add(xypoint);
					//---刷新显示
					this.RefreshZedGraph();
				}
			}
		}

		/// <summary>
		/// 添加数据点
		/// </summary>
		/// <param name="curveName"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public virtual void AddXYPoint(string curveName, double[] x, double[] y)
		{
			int i = 0;
			//---异步调用
			if (this.zedGraphCurveChart.InvokeRequired)
			{
				this.zedGraphCurveChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 //---查空操作
									 if (this.zedGraphCurveChart.GraphPane.CurveList.Count == 0)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
									 }
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.zedGraphCurveChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
									 //---判断曲线是否存在
									 if (ip == null)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
									 }
									 //---添加数据
									 if ((ip != null) && (x.Length == y.Length))
									 {
										 for (i = 0; i < x.Length; i++)
										 {
											 ip.Add(x[i], y[i]);
										 }
										 //---刷新显示
										 this.RefreshZedGraph();
									 }
								 }));
			}
			else
			{
				//---查空操作
				if (this.zedGraphCurveChart.GraphPane.CurveList.Count==0)
				{
					//---添加曲线
					this.AddCurve(curveName);
				}
				//---增加坐标XY轴的点
				IPointListEdit ip = this.zedGraphCurveChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
				//---判断曲线是否存在
				if (ip == null)
				{
					//---添加曲线
					this.AddCurve(curveName);
				}
				//---添加数据
				if ((ip != null) && (x.Length == y.Length))
				{
					for (i = 0; i < x.Length; i++)
					{
						ip.Add(x[i], y[i]);
					}
					//---刷新显示
					this.RefreshZedGraph();
				}
			}
		}

		/// <summary>
		/// 添加数据点
		/// </summary>
		/// <param name="curveName"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public virtual void AddXYPoint(string curveName, PointPair[] xypoint)
		{
			int i = 0;
			//---异步调用
			if (this.zedGraphCurveChart.InvokeRequired)
			{
				this.zedGraphCurveChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 //---查空操作
									 if (this.zedGraphCurveChart.GraphPane.CurveList.Count == 0)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
									 }
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.zedGraphCurveChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
									 //---判断曲线是否存在
									 if (ip == null)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
									 }
									 //---添加数据
									 if (ip != null)
									 {
										 for (i = 0; i < xypoint.Length; i++)
										 {
											 ip.Add(xypoint[i]);
										 }
										 //---刷新显示
										 this.RefreshZedGraph();
									 }
										
								 }));
			}
			else
			{
				//---查空操作
				if (this.zedGraphCurveChart.GraphPane.CurveList.Count == 0)
				{
					//---添加曲线
					this.AddCurve(curveName);
				}
				//---增加坐标XY轴的点
				IPointListEdit ip = this.zedGraphCurveChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
				//---判断曲线是否存在
				if (ip == null)
				{
					//---添加曲线
					this.AddCurve(curveName);
				}
				//---添加数据
				if (ip != null)
				{
					for (i = 0; i < xypoint.Length; i++)
					{
						ip.Add(xypoint[i]);
					}
					//---刷新显示
					this.RefreshZedGraph();
				}
			}
		}

		/// <summary>
		/// 添加曲线
		/// </summary>
		/// <param name="addCurve"></param>
		/// <param name="curveColor"></param>
		/// <param name="curveType"></param>
		public virtual LineItem AddCurve(string addCurve, Color curveColor, SymbolType curveType, bool isFillColor = false)
		{
			LineItem myCurve = this.zedGraphCurveChart.GraphPane.AddCurve(addCurve,null, curveColor, curveType);
			if (isFillColor)
			{
				myCurve.Symbol.Fill = new Fill(curveColor);
			}
			return myCurve;
		}

		/// <summary>
		/// 显示曲线
		/// </summary>
		/// <param name="addCurve"></param>
		/// <param name="list"></param>
		/// <param name="curveColor"></param>
		/// <param name="curveType"></param>
		/// <returns></returns>
		public virtual LineItem AddCurve(string addCurve, PointPairList list, Color curveColor, SymbolType curveType, bool isFillColor = false)
		{
			LineItem myCurve = this.zedGraphCurveChart.GraphPane.AddCurve(addCurve,list, curveColor, curveType);
			if (isFillColor)
			{
				myCurve.Symbol.Fill = new Fill(curveColor);
			}
			return myCurve;
		}

		/// <summary>
		/// 显示曲线
		/// </summary>
		/// <param name="addCurve"></param>
		/// <param name="curveColor"></param>
		/// <returns></returns>
		public virtual LineItem AddCurve(string addCurve, Color curveColor, bool isFillColor = false)
		{
			LineItem myCurve = this.zedGraphCurveChart.GraphPane.AddCurve(addCurve,null, curveColor, SymbolType.Circle);
			if (isFillColor)
			{
				myCurve.Symbol.Fill = new Fill(curveColor);
			}
			return myCurve;
		}

		/// <summary>
		/// 添加曲线
		/// </summary>
		/// <param name="addCurve"></param>
		/// <param name="isFillColor"></param>
		/// <returns></returns>
		public virtual LineItem AddCurve(string addCurve, bool isFillColor = false)
		{
			LineItem myCurve = this.zedGraphCurveChart.GraphPane.AddCurve(addCurve, null, Color.Blue, SymbolType.None);
			if (isFillColor)
			{
				myCurve.Symbol.Fill = new Fill(Color.Blue);
			}
			return myCurve;
		}


		/// <summary>
		/// 显示图标
		/// </summary>
		/// <param name="addCurve"></param>
		/// <param name="list"></param>
		/// <param name="curveColor"></param>
		/// <returns></returns>
		public virtual LineItem AddCurve(string addCurve, PointPairList list, Color curveColor, bool isFillColor = false)
		{
			LineItem myCurve = this.zedGraphCurveChart.GraphPane.AddCurve(addCurve,list, curveColor, SymbolType.None);
			if (isFillColor)
			{
				myCurve.Symbol.Fill = new Fill(curveColor);
			}
			return myCurve;
		}

		/// <summary>
		/// 字体的大小
		/// </summary>
		/// <param name="size"></param>
		public virtual void FontSize(float size,bool isRefresh=true)
		{
			int i = 0;
			this.m_TitleFontSize = size;
			this.m_XAxisScaleFontSize = size;
			this.m_XAxisTitleFontSize = size;
			this.m_YAxisScaleFontSize = size;
			this.m_YAxisTitleFontSize = size;
			//---修改曲线项字体大小,字体外部有一个矩形框
			this.zedGraphCurveChart.GraphPane.Legend.FontSpec.Size = size;
			////---修改单一曲线字体的大小,字体外部有一个矩形框
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
		/// 恢复默认大小
		/// </summary>
		public virtual void DefaultZoom()
		{
			if (this.zedGraphCurveChart!=null)
			{
				//if(this.zedGraphCurveChart.MasterPane!=null)
				//{
				//	//GraphPane pane = this.zedGraphCurveChart.MasterPane.FindPane(new Point());
				//	//this.RestoreScale(pane);
				//}
				this.RestoreScale(this.zedGraphCurveChart.GraphPane);
			}
		}

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="size"></param>
		public virtual void Init(float size)
		{
			this.FontSize(size,false);
			this.DefaultZoom();
		}

		#endregion

	}
}
