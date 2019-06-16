namespace Harry.LabDigitalAcquisitionCard
{
	partial class DigitalAcquisitionCardForm
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

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			Harry.LabCOMMPort.COMMSerialPortParam commSerialPortParam2 = new Harry.LabCOMMPort.COMMSerialPortParam();
			this.commSerialPortPlus1 = new Harry.LabCOMMPort.COMMSerialPortPlus();
			this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
			this.SuspendLayout();
			// 
			// commSerialPortPlus1
			// 
			this.commSerialPortPlus1.Location = new System.Drawing.Point(13, 13);
			this.commSerialPortPlus1.m_COMMForm = null;
			this.commSerialPortPlus1.m_COMMPort = null;
			this.commSerialPortPlus1.m_COMMPortParam = commSerialPortParam2;
			this.commSerialPortPlus1.m_COMMRichTextBox = null;
			this.commSerialPortPlus1.Margin = new System.Windows.Forms.Padding(4);
			this.commSerialPortPlus1.Name = "commSerialPortPlus1";
			this.commSerialPortPlus1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.commSerialPortPlus1.Size = new System.Drawing.Size(356, 76);
			this.commSerialPortPlus1.TabIndex = 0;
			// 
			// zedGraphControl1
			// 
			this.zedGraphControl1.Location = new System.Drawing.Point(13, 286);
			this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.zedGraphControl1.Name = "zedGraphControl1";
			this.zedGraphControl1.ScrollGrace = 0D;
			this.zedGraphControl1.ScrollMaxX = 0D;
			this.zedGraphControl1.ScrollMaxY = 0D;
			this.zedGraphControl1.ScrollMaxY2 = 0D;
			this.zedGraphControl1.ScrollMinX = 0D;
			this.zedGraphControl1.ScrollMinY = 0D;
			this.zedGraphControl1.ScrollMinY2 = 0D;
			this.zedGraphControl1.Size = new System.Drawing.Size(356, 260);
			this.zedGraphControl1.TabIndex = 1;
			// 
			// DigitalAcquisitionCardForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 558);
			this.Controls.Add(this.zedGraphControl1);
			this.Controls.Add(this.commSerialPortPlus1);
			this.Name = "DigitalAcquisitionCardForm";
			this.Text = "数字采集卡";
			this.ResumeLayout(false);

		}

		#endregion

		private LabCOMMPort.COMMSerialPortPlus commSerialPortPlus1;
		private ZedGraph.ZedGraphControl zedGraphControl1;
	}
}

