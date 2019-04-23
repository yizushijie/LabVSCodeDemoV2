namespace Harry.LabCOMMPort
{
	partial class COMMSerialPortPlus
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
			this.panel_COMMName.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMMState)).BeginInit();
			this.panel_COMM.SuspendLayout();
			this.groupBox_COMMName.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBox_COMMName
			// 
			this.comboBox_COMMName.IntegralHeight = false;
			// 
			// COMMSerialPortPlus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "COMMSerialPortPlus";
			this.panel_COMMName.ResumeLayout(false);
			this.panel_COMMName.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMMState)).EndInit();
			this.panel_COMM.ResumeLayout(false);
			this.groupBox_COMMName.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
	}
}
