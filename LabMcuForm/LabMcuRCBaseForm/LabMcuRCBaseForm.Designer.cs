namespace Harry.LabMcuForm
{
	partial class LabMcuRCBaseForm
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
			this.groupBox_TestDevice.SuspendLayout();
			this.panel_ADCChannel.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox_ScanADCFunc
			// 
			this.groupBox_ScanADCFunc.Location = new System.Drawing.Point(6, 87);
			this.groupBox_ScanADCFunc.Text = "OSC频率电压";
			// 
			// LabMcuRCBaseForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 597);
			this.Controls.Add(this.panel_ADCVREF);
			this.Controls.Add(this.panel_SampleNum);
			this.Controls.Add(this.panel_ADCChannel);
			this.Name = "LabMcuRCBaseForm";
			this.Text = "LabMcuRCBaseForm";
			this.groupBox_TestDevice.ResumeLayout(false);
			this.panel_ADCChannel.ResumeLayout(false);
			this.panel_ADCChannel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
	}
}