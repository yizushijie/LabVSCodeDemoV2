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
	public partial class ZedGraphCurveChart : ZedGraphBaseChart
	{
		#region 变量定义

		#endregion

		#region 属性定义

		#endregion

		#region 构造函数
		public ZedGraphCurveChart()
		{
			this.Init();
		}
		#endregion

		#region 私有函数

		/// <summary>
		/// 
		/// </summary>
		private void Init()
		{
			this.m_ZedGraph.GraphPane.Title.Text = "标题";
			this.m_ZedGraph.GraphPane.XAxis.Title.Text = "X轴";
			this.m_ZedGraph.GraphPane.YAxis.Title.Text = "X轴";
			this.FontSize(16);
		}


		/// <summary>
		/// 添加曲线
		/// </summary>
		/// <param name="addCurve"></param>
		/// <param name="curveColor"></param>
		/// <param name="curveType"></param>
		private LineItem AddCurve(string addCurve, Color curveColor, SymbolType curveType, bool isFillColor = false)
		{
			LineItem myCurve = this.m_ZedGraph.GraphPane.AddCurve(addCurve, null, curveColor, curveType);
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
		private LineItem AddCurve(string addCurve, PointPairList list, Color curveColor, SymbolType curveType, bool isFillColor = false)
		{
			LineItem myCurve = this.m_ZedGraph.GraphPane.AddCurve(addCurve, list, curveColor, curveType);
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
		private  LineItem AddCurve(string addCurve, Color curveColor, bool isFillColor = false)
		{
			LineItem myCurve = this.m_ZedGraph.GraphPane.AddCurve(addCurve, null, curveColor, SymbolType.Circle);
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
		private  LineItem AddCurve(string addCurve, bool isFillColor = false)
		{
			LineItem myCurve = this.m_ZedGraph.GraphPane.AddCurve(addCurve, null, Color.Blue, SymbolType.None);
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
		private  LineItem AddCurve(string addCurve, PointPairList list, Color curveColor, bool isFillColor = false)
		{
			LineItem myCurve = this.m_ZedGraph.GraphPane.AddCurve(addCurve, list, curveColor, SymbolType.None);
			if (isFillColor)
			{
				myCurve.Symbol.Fill = new Fill(curveColor);
			}
			return myCurve;
		}


		#endregion

		#region 公共函数

		/// <summary>
		/// 添加数据点
		/// </summary>
		/// <param name="curveName"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public override void AddPoint(string curveName, double x, double y)
		{
			//---异步调用
			if (this.m_ZedGraph.InvokeRequired)
			{
				this.m_ZedGraph.BeginInvoke((EventHandler)
								 (delegate
								 {
									 //---查空操作
									 if (this.m_ZedGraph.GraphPane.CurveList.Count == 0)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
									 }
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.m_ZedGraph.GraphPane.CurveList[curveName].Points as IPointListEdit;
									 //---判断曲线是否存在
									 if (ip == null)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
										 ip = this.m_ZedGraph.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
				if (this.m_ZedGraph.GraphPane.CurveList.Count == 0)
				{
					//---添加曲线
					this.AddCurve(curveName);
				}
				//---增加坐标XY轴的点
				IPointListEdit ip = this.m_ZedGraph.GraphPane.CurveList[curveName].Points as IPointListEdit;
				//---判断曲线是否存在
				if (ip == null)
				{
					//---添加曲线
					this.AddCurve(curveName);
					ip = this.m_ZedGraph.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
		public override void AddPoint(string curveName, PointPair xypoint)
		{
			//---异步调用
			if (this.m_ZedGraph.InvokeRequired)
			{
				this.m_ZedGraph.BeginInvoke((EventHandler)
								 (delegate
								 {
									 //---查空操作
									 if (this.m_ZedGraph.GraphPane.CurveList.Count == 0)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
									 }
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.m_ZedGraph.GraphPane.CurveList[curveName].Points as IPointListEdit;
									 //---判断曲线是否存在
									 if (ip == null)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
										 ip = this.m_ZedGraph.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
				if (this.m_ZedGraph.GraphPane.CurveList.Count == 0)
				{
					//---添加曲线
					this.AddCurve(curveName);
				}
				//---增加坐标XY轴的点
				IPointListEdit ip = this.m_ZedGraph.GraphPane.CurveList[curveName].Points as IPointListEdit;
				//---判断曲线是否存在
				if (ip == null)
				{
					//---添加曲线
					this.AddCurve(curveName);
					ip = this.m_ZedGraph.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
		public override void AddPoint(string curveName, double[] x, double[] y)
		{
			int i = 0;
			//---异步调用
			if (this.m_ZedGraph.InvokeRequired)
			{
				this.m_ZedGraph.BeginInvoke((EventHandler)
								 (delegate
								 {
									 //---查空操作
									 if (this.m_ZedGraph.GraphPane.CurveList.Count == 0)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
									 }
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.m_ZedGraph.GraphPane.CurveList[curveName].Points as IPointListEdit;
									 //---判断曲线是否存在
									 if (ip == null)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
										 ip = this.m_ZedGraph.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
				if (this.m_ZedGraph.GraphPane.CurveList.Count == 0)
				{
					//---添加曲线
					this.AddCurve(curveName);
				}
				//---增加坐标XY轴的点
				IPointListEdit ip = this.m_ZedGraph.GraphPane.CurveList[curveName].Points as IPointListEdit;
				//---判断曲线是否存在
				if (ip == null)
				{
					//---添加曲线
					this.AddCurve(curveName);
					ip = this.m_ZedGraph.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
		public override void AddPoint(string curveName, PointPair[] xypoint)
		{
			int i = 0;
			//---异步调用
			if (this.m_ZedGraph.InvokeRequired)
			{
				this.m_ZedGraph.BeginInvoke((EventHandler)
								 (delegate
								 {
									 //---查空操作
									 if (this.m_ZedGraph.GraphPane.CurveList.Count == 0)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
									 }
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.m_ZedGraph.GraphPane.CurveList[curveName].Points as IPointListEdit;
									 //---判断曲线是否存在
									 if (ip == null)
									 {
										 //---添加曲线
										 this.AddCurve(curveName);
										 ip = this.m_ZedGraph.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
				if (this.m_ZedGraph.GraphPane.CurveList.Count == 0)
				{
					//---添加曲线
					this.AddCurve(curveName);
				}
				//---增加坐标XY轴的点
				IPointListEdit ip = this.m_ZedGraph.GraphPane.CurveList[curveName].Points as IPointListEdit;
				//---判断曲线是否存在
				if (ip == null)
				{
					//---添加曲线
					this.AddCurve(curveName);
					ip = this.m_ZedGraph.GraphPane.CurveList[curveName].Points as IPointListEdit;
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
		
		#endregion

	}
}
