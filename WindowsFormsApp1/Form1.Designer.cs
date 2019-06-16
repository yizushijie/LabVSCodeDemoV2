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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.commSerialPortPlus1 = new Harry.LabCOMMPort.COMMSerialPortPlus();
			this.richTextBoxEx1 = new Harry.LabUserControlPlus.RichTextBoxEx();
			this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
			this.axCWButton21 = new AxCWUIControlsLib.AxCWButton2();
			((System.ComponentModel.ISupportInitialize)(this.axCWButton21)).BeginInit();
			this.SuspendLayout();
			// 
			// commSerialPortPlus1
			// 
			this.commSerialPortPlus1.Location = new System.Drawing.Point(39, 36);
			this.commSerialPortPlus1.m_COMMForm = null;
			this.commSerialPortPlus1.m_COMMPort = null;
			this.commSerialPortPlus1.m_COMMPortParam = commSerialPortParam1;
			this.commSerialPortPlus1.m_COMMRichTextBox = null;
			this.commSerialPortPlus1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.commSerialPortPlus1.Name = "commSerialPortPlus1";
			this.commSerialPortPlus1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.commSerialPortPlus1.Size = new System.Drawing.Size(356, 76);
			this.commSerialPortPlus1.TabIndex = 1;
			// 
			// richTextBoxEx1
			// 
			this.richTextBoxEx1.Location = new System.Drawing.Point(39, 166);
			this.richTextBoxEx1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richTextBoxEx1.Name = "richTextBoxEx1";
			this.richTextBoxEx1.Size = new System.Drawing.Size(647, 72);
			this.richTextBoxEx1.TabIndex = 0;
			this.richTextBoxEx1.Text = "";
			// 
			// zedGraphControl1
			// 
			this.zedGraphControl1.Location = new System.Drawing.Point(39, 270);
			this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.zedGraphControl1.Name = "zedGraphControl1";
			this.zedGraphControl1.ScrollGrace = 0D;
			this.zedGraphControl1.ScrollMaxX = 0D;
			this.zedGraphControl1.ScrollMaxY = 0D;
			this.zedGraphControl1.ScrollMaxY2 = 0D;
			this.zedGraphControl1.ScrollMinX = 0D;
			this.zedGraphControl1.ScrollMinY = 0D;
			this.zedGraphControl1.ScrollMinY2 = 0D;
			this.zedGraphControl1.Size = new System.Drawing.Size(437, 310);
			this.zedGraphControl1.TabIndex = 2;
			// 
			// axCWButton21
			// 
			this.axCWButton21.Location = new System.Drawing.Point(484, 270);
			this.axCWButton21.Name = "axCWButton21";
			this.axCWButton21.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axCWButton21.OcxState")));
			this.axCWButton21.Size = new System.Drawing.Size(201, 70);
			this.axCWButton21.TabIndex = 4;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 748);
			this.Controls.Add(this.axCWButton21);
			this.Controls.Add(this.zedGraphControl1);
			this.Controls.Add(this.commSerialPortPlus1);
			this.Controls.Add(this.richTextBoxEx1);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.axCWButton21)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Harry.LabUserControlPlus.RichTextBoxEx richTextBoxEx1;
		private Harry.LabCOMMPort.COMMSerialPortPlus commSerialPortPlus1;
		private ZedGraph.ZedGraphControl zedGraphControl1;
		private AxCWUIControlsLib.AxCWButton2 axCWButton21;
	}
}

