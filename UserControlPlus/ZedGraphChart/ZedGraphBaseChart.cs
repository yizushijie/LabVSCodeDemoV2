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

		public virtual ZedGraphControl m_ZedGraph
		{
			get
			{
				return this.zedGraphChart;
			}
			set
			{
				this.zedGraphChart = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Description("曲线命名的字体的大小"), Category("自定义属性")]
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

		#region 属性定义

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

		/// <summary>
		/// 
		/// </summary>
		public ZedGraphBaseChart(ZedGraphControl zedGraph)
		{
			if (zedGraph!=null)
			{
				this.components = new System.ComponentModel.Container();
				this.SuspendLayout();
				// 
				// zedGraphCurveChart
				// 
				zedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
				zedGraph.IsAutoScrollRange = true;
				zedGraph.Location = new System.Drawing.Point(0, 0);
				zedGraph.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
				zedGraph.Name = "zedGraphCurveChart";
				zedGraph.ScrollGrace = 0D;
				zedGraph.ScrollMaxX = 0D;
				zedGraph.ScrollMaxY = 0D;
				zedGraph.ScrollMaxY2 = 0D;
				zedGraph.ScrollMinX = 0D;
				zedGraph.ScrollMinY = 0D;
				zedGraph.ScrollMinY2 = 0D;
				zedGraph.Size = new System.Drawing.Size(443, 340);
				zedGraph.TabIndex = 0;
				// 
				// ZedGraphBaseChart
				// 
				this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.Controls.Add(zedGraph);
				this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
				this.Name = "ZedGraphChart";
				this.Size = new System.Drawing.Size(443, 340);
				this.ResumeLayout(false);

				this.CreateZedGraph(zedGraph);
			}
			
		}


		#endregion

		#region 私有函数
		/// <summary>
		/// 初始化
		/// </summary>
		private void InitZedGraph()
		{
			//---Y轴显示大网格
			this.zedGraphChart.GraphPane.YAxis.MajorGrid.IsVisible = true;

			//---X轴显示大网格
			this.zedGraphChart.GraphPane.XAxis.MajorGrid.IsVisible = true;

			//---鼠标经过图表上的点时是否气泡显示该点所对应的值
			this.zedGraphChart.IsShowPointValues = true;
			//---处理鼠标经过图表上的点时是否气泡显示该点所对应的值的事件
			this.zedGraphChart.PointValueEvent += new ZedGraphControl.PointValueHandler(this.PointValueEventHandler);

			//---是否显示横向滚动条
			//this.zedGraphChart.IsShowHScrollBar = true;
			//---是否显示纵向滚动条
			//this.zedGraphChart.IsShowVScrollBar = true;
			this.zedGraphChart.IsAutoScrollRange = true;

			//---是否显示右键菜单，如果指定了ContextMenuStrip会一直显示指定的ContextMenu
			this.zedGraphChart.IsShowContextMenu = true;

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

		#region 事件
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
						break;
					default:
						//this.DefaultZoom();
						break;
				}
			}
			else
			{
				this.DefaultZoom();
			}
		}

		#endregion

		#region 公共函数

		/// <summary>
		/// 创建控件
		/// </summary>
		/// <param name="zedGraph"></param>
		public virtual void CreateZedGraph(ZedGraphControl zedGraph)
		{
			if (zedGraph != null)
			{
				//---Y轴显示大网格
				zedGraph.GraphPane.YAxis.MajorGrid.IsVisible = true;

				//---X轴显示大网格
				zedGraph.GraphPane.XAxis.MajorGrid.IsVisible = true;

				//---鼠标经过图表上的点时是否气泡显示该点所对应的值
				zedGraph.IsShowPointValues = true;
				//---处理鼠标经过图表上的点时是否气泡显示该点所对应的值的事件
				zedGraph.PointValueEvent += new ZedGraphControl.PointValueHandler(this.PointValueEventHandler);

				//---是否允许缩放
				zedGraph.IsEnableZoom = true;
				//this.zedGraphCurveChart.sy
				//---缩放事件处理
				zedGraph.ZoomEvent += new ZedGraphControl.ZoomEventHandler(this.ZoomEventHandler);

				//---刷新图形控件
				this.RefreshZedGraph(zedGraph);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void ClearZedGraph()
		{
			if (this.zedGraphChart!=null)
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
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="zedGraph"></param>
		public virtual void ClearZedGraph(ZedGraphControl zedGraph)
		{
			if (zedGraph!=null)
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
			if (zedGraph==null)
			{
				return;
			}
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
		/// 
		/// </summary>
		public virtual void DefaultZoom()
		{
			this.RestoreScale(this.zedGraphChart.GraphPane);
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void DefaultZoom(ZedGraphControl zedGraph)
		{
			if (zedGraph==null)
			{
				return;
			}
			this.RestoreScale(zedGraph.GraphPane);
		}

		/// <summary>
		/// 字体的大小
		/// </summary>
		/// <param name="size"></param>
		public virtual void FontSize( float size, bool isRefresh = true)
		{
			this.zedGraphChart.GraphPane.Title.FontSpec.Size = size;
			this.zedGraphChart.GraphPane.XAxis.Scale.FontSpec.Size = size;
			this.zedGraphChart.GraphPane.XAxis.Title.FontSpec.Size = size;
			this.zedGraphChart.GraphPane.YAxis.Scale.FontSpec.Size = size;
			this.zedGraphChart.GraphPane.YAxis.Title.FontSpec.Size = size;
			//---修改曲线项字体大小,字体外部有一个矩形框
			this.zedGraphChart.GraphPane.Legend.FontSpec.Size = (size > 2 ? (size - 2) : 2);
			//---刷新显示
			if (isRefresh)
			{
				this.RefreshZedGraph();
			}
		}

		/// <summary>
		/// 字体的大小
		/// </summary>
		/// <param name="size"></param>
		public virtual void FontSize(ZedGraphControl zedGraph, float size, bool isRefresh = true)
		{
			zedGraph.GraphPane.Title.FontSpec.Size = size;
			zedGraph.GraphPane.XAxis.Scale.FontSpec.Size = size;
			zedGraph.GraphPane.XAxis.Title.FontSpec.Size = size;
			zedGraph.GraphPane.YAxis.Scale.FontSpec.Size = size;
			zedGraph.GraphPane.YAxis.Title.FontSpec.Size = size;
			//---修改曲线项字体大小,字体外部有一个矩形框
			zedGraph.GraphPane.Legend.FontSpec.Size = (size > 2 ? (size - 2) : 2);
			//---刷新显示
			if (isRefresh)
			{
				this.RefreshZedGraph(zedGraph);
			}
		}


		/// <summary>
		/// 添加数据点
		/// </summary>
		/// <param name="curveName"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public virtual void AddPoint(string curveName, double x, double y)
		{
			//---异步调用
			if (this.zedGraphChart.InvokeRequired)
			{
				this.zedGraphChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.zedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
				//---增加坐标XY轴的点
				IPointListEdit ip = this.zedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
		public virtual void AddPoint(string curveName, PointPair xypoint)
		{
			//---异步调用
			if (this.zedGraphChart.InvokeRequired)
			{
				this.zedGraphChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.zedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
				//---增加坐标XY轴的点
				IPointListEdit ip = this.zedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
		public virtual void AddPoint(string curveName, double[] x, double[] y)
		{
			int i = 0;
			//---异步调用
			if (this.zedGraphChart.InvokeRequired)
			{
				this.zedGraphChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.zedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
				//---增加坐标XY轴的点
				IPointListEdit ip = this.zedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
		public virtual void AddPoint(string curveName, PointPair[] xypoint)
		{
			int i = 0;
			//---异步调用
			if (this.zedGraphChart.InvokeRequired)
			{
				this.zedGraphChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.zedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
				//---增加坐标XY轴的点
				IPointListEdit ip = this.zedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
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


		#endregion

	}
}
