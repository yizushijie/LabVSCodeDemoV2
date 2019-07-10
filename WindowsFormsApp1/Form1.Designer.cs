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
			Harry.LabCOMMPort.COMMSerialPortParam commSerialPortParam2 = new Harry.LabCOMMPort.COMMSerialPortParam();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.button_OpenPower = new System.Windows.Forms.Button();
			this.button_ClosePower = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.numericUpDownPlus1 = new Harry.LabUserControlPlus.NumericUpDownPlus();
			this.richTextBoxEx1 = new Harry.LabUserControlPlus.RichTextBoxEx();
			this.commSerialPortPlus1 = new Harry.LabCOMMPort.COMMSerialPortPlus();
			this.gpD3303Plus1 = new Harry.LabDigitalPower.GPD3303Plus();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus1)).BeginInit();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 200;
			this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// button_OpenPower
			// 
			this.button_OpenPower.Location = new System.Drawing.Point(29, 121);
			this.button_OpenPower.Name = "button_OpenPower";
			this.button_OpenPower.Size = new System.Drawing.Size(75, 23);
			this.button_OpenPower.TabIndex = 3;
			this.button_OpenPower.Text = "打开电源";
			this.button_OpenPower.UseVisualStyleBackColor = true;
			this.button_OpenPower.Click += new System.EventHandler(this.Button_OpenPower_Click);
			// 
			// button_ClosePower
			// 
			this.button_ClosePower.Location = new System.Drawing.Point(119, 121);
			this.button_ClosePower.Name = "button_ClosePower";
			this.button_ClosePower.Size = new System.Drawing.Size(75, 23);
			this.button_ClosePower.TabIndex = 4;
			this.button_ClosePower.Text = "关闭电源";
			this.button_ClosePower.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(119, 151);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "设置电压";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// numericUpDownPlus1
			// 
			this.numericUpDownPlus1.DecimalPlaces = 3;
			this.numericUpDownPlus1.Location = new System.Drawing.Point(29, 152);
			this.numericUpDownPlus1.Name = "numericUpDownPlus1";
			this.numericUpDownPlus1.Size = new System.Drawing.Size(75, 21);
			this.numericUpDownPlus1.TabIndex = 7;
			this.numericUpDownPlus1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownPlus1.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
			// 
			// richTextBoxEx1
			// 
			this.richTextBoxEx1.Location = new System.Drawing.Point(29, 298);
			this.richTextBoxEx1.Margin = new System.Windows.Forms.Padding(2);
			this.richTextBoxEx1.Name = "richTextBoxEx1";
			this.richTextBoxEx1.Size = new System.Drawing.Size(329, 58);
			this.richTextBoxEx1.TabIndex = 0;
			this.richTextBoxEx1.Text = "";
			// 
			// commSerialPortPlus1
			// 
			this.commSerialPortPlus1.Location = new System.Drawing.Point(29, 29);
			this.commSerialPortPlus1.m_COMMForm = null;
			this.commSerialPortPlus1.m_COMM = null;
			this.commSerialPortPlus1.m_COMMParam = commSerialPortParam1;
			this.commSerialPortPlus1.m_COMMRichTextBox = null;
			this.commSerialPortPlus1.Margin = new System.Windows.Forms.Padding(4);
			this.commSerialPortPlus1.Name = "commSerialPortPlus1";
			this.commSerialPortPlus1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.commSerialPortPlus1.Size = new System.Drawing.Size(267, 61);
			this.commSerialPortPlus1.TabIndex = 1;
			// 
			// gpD3303Plus1
			// 
			this.gpD3303Plus1.Location = new System.Drawing.Point(380, 50);
			this.gpD3303Plus1.m_COMMForm = null;
			this.gpD3303Plus1.m_COMM = null;
			this.gpD3303Plus1.m_COMMParam = commSerialPortParam2;
			this.gpD3303Plus1.m_COMMRichTextBox = null;
			this.gpD3303Plus1.Name = "gpD3303Plus1";
			this.gpD3303Plus1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.gpD3303Plus1.Size = new System.Drawing.Size(296, 200);
			this.gpD3303Plus1.TabIndex = 8;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1020, 598);
			this.Controls.Add(this.gpD3303Plus1);
			this.Controls.Add(this.numericUpDownPlus1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button_ClosePower);
			this.Controls.Add(this.button_OpenPower);
			this.Controls.Add(this.commSerialPortPlus1);
			this.Controls.Add(this.richTextBoxEx1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Harry.LabUserControlPlus.RichTextBoxEx richTextBoxEx1;
		private Harry.LabCOMMPort.COMMSerialPortPlus commSerialPortPlus1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button button_OpenPower;
		private System.Windows.Forms.Button button_ClosePower;
		private System.Windows.Forms.Button button1;
		private Harry.LabUserControlPlus.NumericUpDownPlus numericUpDownPlus1;
		private Harry.LabDigitalPower.GPD3303Plus gpD3303Plus1;
	}
}

