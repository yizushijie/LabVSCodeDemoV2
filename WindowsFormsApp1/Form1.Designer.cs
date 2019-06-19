namespace WindowsFormsApp1
{
	partial class Form1
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
			Harry.LabCOMMPort.COMMSerialPortParam commSerialPortParam1 = new Harry.LabCOMMPort.COMMSerialPortParam();
			this.curveChart1 = new Harry.LabUserControlPlus.CurveChart();
			this.richTextBoxEx1 = new Harry.LabUserControlPlus.RichTextBoxEx();
			this.commSerialPortPlus1 = new Harry.LabCOMMPort.COMMSerialPortPlus();
			this.zedGraphCurveChart1 = new Harry.LabUserControlPlus.ZedGraphCurveChart();
			this.SuspendLayout();
			// 
			// curveChart1
			// 
			this.curveChart1.Location = new System.Drawing.Point(529, 36);
			this.curveChart1.m_LabelFontSize = 12F;
			this.curveChart1.m_Title = "标题";
			this.curveChart1.m_TitleFontSize = 16F;
			this.curveChart1.m_XAxisScaleFontSize = 14F;
			this.curveChart1.m_XAxisScaleMajorStep = 0.1D;
			this.curveChart1.m_XAxisScaleMax = 1.0000000000000002D;
			this.curveChart1.m_XAxisScaleMin = 0D;
			this.curveChart1.m_XAxisTitle = "X轴";
			this.curveChart1.m_XAxisTitleFontSize = 14F;
			this.curveChart1.m_YAxisScaleFontSize = 14F;
			this.curveChart1.m_YAxisScaleMajorStep = 0.1D;
			this.curveChart1.m_YAxisScaleMax = 1.0000000000000002D;
			this.curveChart1.m_YAxisScaleMin = 0D;
			this.curveChart1.m_YAxisTitle = "Y 轴";
			this.curveChart1.m_YAxisTitleFontSize = 14F;
			this.curveChart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.curveChart1.Name = "curveChart1";
			this.curveChart1.Size = new System.Drawing.Size(392, 347);
			this.curveChart1.TabIndex = 3;
			// 
			// richTextBoxEx1
			// 
			this.richTextBoxEx1.Location = new System.Drawing.Point(39, 166);
			this.richTextBoxEx1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richTextBoxEx1.Name = "richTextBoxEx1";
			this.richTextBoxEx1.Size = new System.Drawing.Size(437, 72);
			this.richTextBoxEx1.TabIndex = 0;
			this.richTextBoxEx1.Text = "";
			// 
			// commSerialPortPlus1
			// 
			this.commSerialPortPlus1.Location = new System.Drawing.Point(39, 36);
			this.commSerialPortPlus1.m_COMMForm = null;
			this.commSerialPortPlus1.m_COMMPort = null;
			this.commSerialPortPlus1.m_COMMPortParam = commSerialPortParam1;
			this.commSerialPortPlus1.m_COMMRichTextBox = null;
			this.commSerialPortPlus1.Margin = new System.Windows.Forms.Padding(5);
			this.commSerialPortPlus1.Name = "commSerialPortPlus1";
			this.commSerialPortPlus1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.commSerialPortPlus1.Size = new System.Drawing.Size(356, 76);
			this.commSerialPortPlus1.TabIndex = 1;
			// 
			// zedGraphCurveChart1
			// 
			this.zedGraphCurveChart1.Location = new System.Drawing.Point(529, 387);
			this.zedGraphCurveChart1.m_FontSize = 24F;
			this.zedGraphCurveChart1.m_Title = "标题";
			this.zedGraphCurveChart1.m_TitleFontSize = 24F;
			this.zedGraphCurveChart1.m_XAxisScaleFontSize = 24F;
			this.zedGraphCurveChart1.m_XAxisScaleMajorStep = 0.1D;
			this.zedGraphCurveChart1.m_XAxisScaleMax = 1.0000000000000002D;
			this.zedGraphCurveChart1.m_XAxisScaleMin = 0D;
			this.zedGraphCurveChart1.m_XAxisTitle = "X轴";
			this.zedGraphCurveChart1.m_XAxisTitleFontSize = 24F;
			this.zedGraphCurveChart1.m_YAxisScaleFontSize = 24F;
			this.zedGraphCurveChart1.m_YAxisScaleMajorStep = 0.2D;
			this.zedGraphCurveChart1.m_YAxisScaleMax = 1D;
			this.zedGraphCurveChart1.m_YAxisScaleMin = 0D;
			this.zedGraphCurveChart1.m_YAxisTitle = "Y轴";
			this.zedGraphCurveChart1.m_YAxisTitleFontSize = 24F;
			this.zedGraphCurveChart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.zedGraphCurveChart1.Name = "zedGraphCurveChart1";
			this.zedGraphCurveChart1.Size = new System.Drawing.Size(392, 340);
			this.zedGraphCurveChart1.TabIndex = 4;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1360, 748);
			this.Controls.Add(this.zedGraphCurveChart1);
			this.Controls.Add(this.curveChart1);
			this.Controls.Add(this.commSerialPortPlus1);
			this.Controls.Add(this.richTextBoxEx1);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private Harry.LabUserControlPlus.RichTextBoxEx richTextBoxEx1;
		private Harry.LabCOMMPort.COMMSerialPortPlus commSerialPortPlus1;
		private Harry.LabUserControlPlus.CurveChart curveChart1;
		private Harry.LabUserControlPlus.ZedGraphCurveChart zedGraphCurveChart1;
	}
}

