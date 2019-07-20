namespace Harry.LabCOMMPort
{
	partial class COMMSerialParamForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Harry.LabCOMMPort.COMMPortParam commPortParam1 = new Harry.LabCOMMPort.COMMPortParam();
			this.commSerialPortParam = new Harry.LabCOMMPort.COMMSerialPortPlusFull();
			this.SuspendLayout();
			// 
			// commSerialPortParam
			// 
			this.commSerialPortParam.Dock = System.Windows.Forms.DockStyle.Fill;
			this.commSerialPortParam.Location = new System.Drawing.Point(0, 0);
			this.commSerialPortParam.m_COMM = null;
			this.commSerialPortParam.m_COMMForm = null;
			this.commSerialPortParam.m_COMMParam = commPortParam1;
			this.commSerialPortParam.m_COMMRichTextBox = null;
			this.commSerialPortParam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.commSerialPortParam.Name = "commSerialPortParam";
			this.commSerialPortParam.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.commSerialPortParam.Size = new System.Drawing.Size(158, 194);
			this.commSerialPortParam.TabIndex = 0;
			// 
			// COMMSerialParamForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(158, 194);
			this.Controls.Add(this.commSerialPortParam);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "COMMSerialParamForm";
			this.Text = "COMMSerialPortParamForm";
			this.ResumeLayout(false);

		}

		#endregion

		private COMMSerialPortPlusFull commSerialPortParam;
	}
}