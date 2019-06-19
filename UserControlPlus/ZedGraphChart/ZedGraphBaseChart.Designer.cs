namespace Harry.LabUserControlPlus
{
	partial class ZedGraphBaseChart
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
			this.zedGraphChart = new ZedGraph.ZedGraphControl();
			this.SuspendLayout();
			// 
			// zedGraphCurveChart
			// 
			this.zedGraphChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedGraphChart.IsAutoScrollRange = true;
			this.zedGraphChart.Location = new System.Drawing.Point(0, 0);
			this.zedGraphChart.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.zedGraphChart.Name = "zedGraphCurveChart";
			this.zedGraphChart.ScrollGrace = 0D;
			this.zedGraphChart.ScrollMaxX = 0D;
			this.zedGraphChart.ScrollMaxY = 0D;
			this.zedGraphChart.ScrollMaxY2 = 0D;
			this.zedGraphChart.ScrollMinX = 0D;
			this.zedGraphChart.ScrollMinY = 0D;
			this.zedGraphChart.ScrollMinY2 = 0D;
			this.zedGraphChart.Size = new System.Drawing.Size(443, 340);
			this.zedGraphChart.TabIndex = 0;
			// 
			// ZedGraphBaseChart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.zedGraphChart);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "ZedGraphBaseChart";
			this.Size = new System.Drawing.Size(443, 340);
			this.ResumeLayout(false);

		}

		#endregion

		private ZedGraph.ZedGraphControl zedGraphChart;
	}
}
