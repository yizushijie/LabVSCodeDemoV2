using Harry.LabCOMMPort;
using NPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		private COMMBasePort usedPort = null;
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.usedPort = new COMMSerialPort();
			this.commSerialPortPlus1.Init(this, this.usedPort, this.richTextBoxEx1, true, true);
			this.InitZedGraph();
			//this.plotline();
			//this.InitChart();
			this.GraphCurve();
		}


		/// <summary>
		/// 初始化
		/// </summary>
		private void InitZedGraph()
		{
			////---垂直参考线
			////---显示大网格
			//this.zedGraphControl1.GraphPane.YAxis.MajorGrid.IsVisible = true;

			////---显示小网格
			////this.zedGraphControl1.GraphPane.YAxis.MinorGrid.IsVisible = true;

			////---大网格实线显示
			//this.zedGraphControl1.GraphPane.YAxis.MajorGrid.DashOff = 5;

			////---小网格虚线显示
			////this.zedGraphControl1.GraphPane.YAxis.MinorGrid.DashOff = 10;

			////---网格点的步进刻度
			////this.zedGraphControl1.GraphPane.YAxis.Scale.MajorStep = 2;
			////this.zedGraphControl_myChart.GraphPane.YAxis.Scale.MinorStep = this.zedGraphControl_myChart.GraphPane.YAxis.Scale.MajorStep / 5.0;

			////---Y轴扫描的最大值和最小值
			////this.zedGraphControl_myChart.GraphPane.YAxis.Scale.Min = (this.zedGraphControl_myChart.GraphPane.YAxis.Scale.MinorStep*(-1.00));
			////this.zedGraphControl_myChart.GraphPane.YAxis.Scale.Max = 10;

			////---水平参考线
			////---显示大网格
			//this.zedGraphControl1.GraphPane.XAxis.MajorGrid.IsVisible = true;

			////---显示小网格
			////this.zedGraphControl1.GraphPane.XAxis.MinorGrid.IsVisible = true;

			////---大网格实线显示
			////this.zedGraphControl1.GraphPane.XAxis.Scale.FontSpec.Size = 90;
			//this.zedGraphControl1.GraphPane.XAxis.MajorGrid.DashOff = 5;

			//this.zedGraphControl1.GraphPane.XAxis.Title.Text = "时间";
			//this.zedGraphControl1.GraphPane.YAxis.Title.Text = "电压值";

			//this.zedGraphControl1.GraphPane.XAxis.Title.FontSpec.Size = 30;
			//this.zedGraphControl1.GraphPane.YAxis.Title.FontSpec.Size = 30;

			//this.zedGraphControl1.GraphPane.Title.FontSpec.Size = 30;
			////---小网格虚线显示
			////this.zedGraphControl1.GraphPane.XAxis.MinorGrid.DashOff = 0;

			////---网格点的步进刻度
			////this.zedGraphControl1.GraphPane.XAxis.Scale.MajorStep = 2;
			////this.zedGraphControl_myChart.GraphPane.XAxis.Scale.MinorStep = this.zedGraphControl_myChart.GraphPane.XAxis.Scale.MajorStep / 5.0;

			////---X轴扫描的最大值和最小值
			////this.zedGraphControl1.GraphPane.XAxis.Scale.Min = 0;
			////this.zedGraphControl1.GraphPane.XAxis.Scale.Max = 10;
			////---滚动条自动滚动到最右边
			////this.zedGraphControl_myChart.ScrollMaxX = this.zedGraphControl_myChart.GraphPane.XAxis.Scale.Max;

			////---是否显示横向滚动条
			//this.zedGraphControl1.IsShowHScrollBar = true;
			////---是否显示纵向滚动条
			//this.zedGraphControl1.IsShowVScrollBar = true;
			////this.zedGraphControl1.IsAutoScrollRange = true;

			////---是否显示右键菜单，如果指定了ContextMenuStrip会一直显示指定的ContextMenu
			//this.zedGraphControl1.IsShowContextMenu = true;

			////--- 复制图像时是否显示提示信息
			////zedGraph.IsShowCopyMessage
			/////---鼠标在图表上移动时是否显示鼠标所在点对应的坐标值
			////zedGraph.IsShowCursorValues

			////---鼠标经过图表上的点时是否气泡显示该点所对应的值
			//this.zedGraphControl1.IsShowPointValues = true;
			////---处理鼠标经过图表上的点时是否气泡显示该点所对应的值的事件
			////this.zedGraphControl1.PointValueEvent += new ZedGraphControl.PointValueHandler(this.PointValueEventHandler);

			////---是否允许横向缩放
			////this.zedGraphControl1.IsEnableHZoom = true;
			////使用滚轮时以鼠标所在点进行缩放还是以图形中心进行缩放
			////this.zedGraphControl_myChart.IsZoomOnMouseCenter=false;
			////---是否允许纵向缩放
			////this.zedGraphControl1.IsEnableVZoom = true;
			////---放大缩小
			//this.zedGraphControl1.ZoomStepFraction = 0.2;
			////---是否允许缩放
			////this.zedGraphControl1.IsEnableZoom = true;
			////---缩放事件处理
			////this.zedGraphControl1.ZoomEvent += new ZedGraphControl.ZoomEventHandler(this.ZoomEventHandler);

			////---在图表是添加一些文本
			////---左键拖拽放大\n鼠标中键滚放缩\n右键菜单
			////TextObj text = new TextObj( "Zoom: left mouse & drag\nPan: middle mouse & drag\nContext Menu: right mouse",
			////							0.05f, 0.95f, CoordType.ChartFraction, AlignH.Left, AlignV.Bottom);
			////text.FontSpec.StringAlignment = StringAlignment.Near;
			////this.zedGraphControl_myChart.GraphPane.GraphObjList.Add(text);

			////---处理自定义X轴刻度格式事件
			/////this.zedGraphControl_myChart.GraphPane.XAxis.ScaleFormatEvent += new Axis.ScaleFormatHandler(XAxisScaleFormatEventHandler);
			////---处理自定义Y轴刻度格式事件
			/////this.zedGraphControl_myChart.GraphPane.YAxis.ScaleFormatEvent += new Axis.ScaleFormatHandler(YScaleFormatEventHandler);

			////---将刷新图形控件
			//this.zedGraphControl1.Refresh();
		}

		/*
		public void plotline()
		{
			// --- Plotting ---
			this.plotSurface2D1.Clear();
			// --- Grid Code ---
			Grid mygrid = new Grid();
			//mygrid.HorizontalGridType = Grid.GridType.None;
			mygrid.HorizontalGridType = Grid.GridType.Fine;
			mygrid.VerticalGridType = Grid.GridType.Fine;
			plotSurface2D1.Add(mygrid);
			plotSurface2D1.Title = "Test";
			StepPlot line = new StepPlot();
			line.Pen = new Pen(Color.Red, 1);
			//line.OrdinateData = new int[] { 0, 1, 0, 1, 1, 0 };
			line.HideVerticalSegments = false;
			plotSurface2D1.Add(line);
			plotSurface2D1.Refresh();
		}
		*/

		//private void InitChart()
		//{
		//	//定义图表区域
		//	this.chart1.ChartAreas.Clear();
		//	ChartArea chartArea1 = new ChartArea("C1");
		//	this.chart1.ChartAreas.Add(chartArea1);
		//	//定义存储和显示点的容器
		//	this.chart1.Series.Clear();
		//	Series series1 = new Series("S1");
		//	series1.ChartArea = "C1";
		//	this.chart1.Series.Add(series1);
		//	//设置图表显示样式
		//	this.chart1.ChartAreas[0].AxisY.Minimum = 0;
		//	this.chart1.ChartAreas[0].AxisY.Maximum = 100;
		//	this.chart1.ChartAreas[0].AxisX.Interval = 5;
		//	this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
		//	this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
		//	//设置标题
		//	this.chart1.Titles.Clear();
		//	this.chart1.Titles.Add("S01");
		//	this.chart1.Titles[0].Text = "XXX显示";
		//	this.chart1.Titles[0].ForeColor = Color.RoyalBlue;
		//	this.chart1.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
		//	//设置图表显示样式
		//	this.chart1.Series[0].Color = Color.Red;
		//	//if (rb1.Checked)
		//	//{
		//	//	this.chart1.Titles[0].Text = string.Format("XXX {0} 显示", rb1.Text);
		//	//	this.chart1.Series[0].ChartType = SeriesChartType.Line;
		//	//}
		//	//if (rb2.Checked)
		//	//{
		//	//	this.chart1.Titles[0].Text = string.Format("XXX {0} 显示", rb2.Text);
		//	//	this.chart1.Series[0].ChartType = SeriesChartType.Spline;
		//	//}
		//	this.chart1.Titles[0].Text = string.Format("XXX {0} 显示", "折线图");
		//	this.chart1.Series[0].ChartType = SeriesChartType.Line;
		//	this.chart1.Series[0].Points.Clear();
		//}

		/// <summary>
		/// 绘制曲线
		/// </summary>
		/// <param name=""></param>
		public void GraphCurve()
		{
			int i = 0;
			double[] xPoint = new double[50];
			double[] yPoint = new double[50];
		
			for ( i = 0; i < 50; i++)
			{
				xPoint[i] =i*2;
				yPoint[i] = i * 2+100;
			}
			//this.curveChart1.AddCurve("随机数");
			//if (this.curveChart1.m_ZedGraph.GraphPane.CurveList[0].Label.FontSpec==null)
			//{
			//	this.curveChart1.m_ZedGraph.GraphPane.CurveList[0].Label.FontSpec = new ZedGraph.FontSpec();
			//}
			//this.curveChart1.m_ZedGraph.GraphPane.CurveList[0].Label.FontSpec.Size =12;
			this.curveChart1.m_XAxisScaleMax = xPoint[49]+2;
			this.curveChart1.m_XAxisScaleMin = xPoint[0];
			//this.curveChart1.m_XAxisScaleFontSize = 16;
			//this.curveChart1.m_YAxisScaleFontSize = 16;
			//this.curveChart1.m_XAxisTitleFontSize = 16;
			//this.curveChart1.m_YAxisTitleFontSize = 16;
			//this.curveChart1.m_TitleFontSize = 16;
			//this.curveChart1.m_YAxisScaleMax = yPoint[49]+2;
			//this.curveChart1.m_YAxisScaleMin = yPoint[0];
			this.curveChart1.m_XAxisScaleMajorStep =20;
			this.curveChart1.m_YAxisScaleMajorStep =20;
			this.curveChart1.AddXYPoint("随机数", xPoint, yPoint);
			//this.curveChart1.FontSize(16);
			//this.curveChart1.DefaultZoom();
			this.curveChart1.Init(24);

			this.zedGraphCurveChart1.m_XAxisScaleMajorStep = 20;
			this.zedGraphCurveChart1.m_YAxisScaleMajorStep = 20;
			this.zedGraphCurveChart1.AddXYPoint("随机数", xPoint, yPoint);
			//this.curveChart1.FontSize(16);
			//this.curveChart1.DefaultZoom();
			this.zedGraphCurveChart1.Init(24);
		}

	}
}


