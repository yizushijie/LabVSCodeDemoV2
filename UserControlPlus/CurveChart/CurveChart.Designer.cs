namespace Harry.LabUserControlPlus
{
	partial class CurveChart
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.zedGraphCurveChart = new ZedGraph.ZedGraphControl();
			this.SuspendLayout();
			// 
			// zedGraphCurveChart
			// 
			this.zedGraphCurveChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedGraphCurveChart.Location = new System.Drawing.Point(0, 0);
			this.zedGraphCurveChart.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.zedGraphCurveChart.Name = "zedGraphCurveChart";
			this.zedGraphCurveChart.ScrollGrace = 0D;
			this.zedGraphCurveChart.ScrollMaxX = 0D;
			this.zedGraphCurveChart.ScrollMaxY = 0D;
			this.zedGraphCurveChart.ScrollMaxY2 = 0D;
			this.zedGraphCurveChart.ScrollMinX = 0D;
			this.zedGraphCurveChart.ScrollMinY = 0D;
			this.zedGraphCurveChart.ScrollMinY2 = 0D;
			this.zedGraphCurveChart.Size = new System.Drawing.Size(442, 340);
			this.zedGraphCurveChart.TabIndex = 0;
			this.zedGraphCurveChart.ZoomStepFraction = 0.01D;
			// 
			// CurveChart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.zedGraphCurveChart);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "CurveChart";
			this.Size = new System.Drawing.Size(442, 340);
			this.ResumeLayout(false);

		}

		#endregion

		private ZedGraph.ZedGraphControl zedGraphCurveChart;
	}
}
