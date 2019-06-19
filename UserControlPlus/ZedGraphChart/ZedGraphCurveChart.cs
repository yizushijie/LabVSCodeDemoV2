using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using ZedGraph;

namespace Harry.LabUserControlPlus
{
	public class ZedGraphCurveChart : ZedGraphBaseChart,ICloneable
	{
		#region 变量定义

		#endregion
		#region 属性定义
		
		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public ZedGraphCurveChart():base()
		{
			this.Init();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="zedGraph"></param>
		public ZedGraphCurveChart(ZedGraphControl zedGraph)
		{
			base.CreateZedGraph(zedGraph);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="zgcc"></param>
		public ZedGraphCurveChart(ZedGraphCurveChart zgcc)
		{
			base.CreateZedGraph(zgcc.m_ZedGraphChart);
		}
		
		#endregion

		#region 私有函数

		/// <summary>
		/// 
		/// </summary>
		private  void InitChart()
		{
			base.m_Title = "标题";
			base.m_XAxisTitle = "X轴";
			base.m_YAxisTitle = "Y轴";
			base.Init(24);
		}

		#endregion
		#region 公共函数

		/// <summary>
		/// 
		/// </summary>
		public override  void Init()
		{
			this.InitChart();
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Init(float size,bool isRefresh=false )
		{
			base.Init(size, isRefresh);
			this.InitChart();
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
			if (this.m_ZedGraphChart.InvokeRequired)
			{
				this.m_ZedGraphChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 //---查空操作
									 if (this.m_ZedGraphChart.GraphPane.CurveList.Count == 0)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
									 }
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.m_ZedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
									 //---判断曲线是否存在
									 if (ip == null)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
										 ip = this.m_ZedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
				if (this.m_ZedGraphChart.GraphPane.CurveList.Count == 0)
				{
					//---添加曲线
					this.AddCurve(curveName);
				}
				//---增加坐标XY轴的点
				IPointListEdit ip = this.m_ZedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
				//---判断曲线是否存在
				if (ip == null)
				{
					//---添加曲线
					this.AddCurve(curveName);
					ip = this.m_ZedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
			if (this.m_ZedGraphChart.InvokeRequired)
			{
				this.m_ZedGraphChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 //---查空操作
									 if (this.m_ZedGraphChart.GraphPane.CurveList.Count == 0)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
									 }
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.m_ZedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
									 //---判断曲线是否存在
									 if (ip == null)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
										 ip = this.m_ZedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
				if (this.m_ZedGraphChart.GraphPane.CurveList.Count == 0)
				{
					//---添加曲线
					this.AddCurve(curveName);
				}
				//---增加坐标XY轴的点
				IPointListEdit ip = this.m_ZedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
				//---判断曲线是否存在
				if (ip == null)
				{
					//---添加曲线
					this.AddCurve(curveName);
					ip = this.m_ZedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
			if (this.m_ZedGraphChart.InvokeRequired)
			{
				this.m_ZedGraphChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 //---查空操作
									 if (this.m_ZedGraphChart.GraphPane.CurveList.Count == 0)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
									 }
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.m_ZedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
									 //---判断曲线是否存在
									 if (ip == null)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
										 ip = this.m_ZedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
				if (this.m_ZedGraphChart.GraphPane.CurveList.Count == 0)
				{
					//---添加曲线
					this.AddCurve(curveName);
				}
				//---增加坐标XY轴的点
				IPointListEdit ip = this.m_ZedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
				//---判断曲线是否存在
				if (ip == null)
				{
					//---添加曲线
					this.AddCurve(curveName);
					ip = this.m_ZedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
			if (this.m_ZedGraphChart.InvokeRequired)
			{
				this.m_ZedGraphChart.BeginInvoke((EventHandler)
								 (delegate
								 {
									 //---查空操作
									 if (this.m_ZedGraphChart.GraphPane.CurveList.Count == 0)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
									 }
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.m_ZedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
									 //---判断曲线是否存在
									 if (ip == null)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
										 ip = this.m_ZedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
				if (this.m_ZedGraphChart.GraphPane.CurveList.Count == 0)
				{
					//---添加曲线
					this.AddCurve(curveName);
				}
				//---增加坐标XY轴的点
				IPointListEdit ip = this.m_ZedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
				//---判断曲线是否存在
				if (ip == null)
				{
					//---添加曲线
					this.AddCurve(curveName);
					ip = this.m_ZedGraphChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
			LineItem myCurve = this.m_ZedGraphChart.GraphPane.AddCurve(addCurve, null, curveColor, curveType);
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
			LineItem myCurve = this.m_ZedGraphChart.GraphPane.AddCurve(addCurve, list, curveColor, curveType);
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
			LineItem myCurve = this.m_ZedGraphChart.GraphPane.AddCurve(addCurve, null, curveColor, SymbolType.Circle);
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
			LineItem myCurve = this.m_ZedGraphChart.GraphPane.AddCurve(addCurve, null, Color.Blue, SymbolType.None);
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
			LineItem myCurve = this.m_ZedGraphChart.GraphPane.AddCurve(addCurve, list, curveColor, SymbolType.None);
			if (isFillColor)
			{
				myCurve.Symbol.Fill = new Fill(curveColor);
			}
			return myCurve;
		}


		#endregion

		#region 克隆函数

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		object ICloneable.Clone()
		{
			return this.Clone();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ZedGraphCurveChart Clone()
		{
			return new ZedGraphCurveChart(this);
		}

		#endregion

	}
}
