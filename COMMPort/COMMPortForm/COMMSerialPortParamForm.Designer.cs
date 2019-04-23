namespace Harry.LabCOMMPort
{
	partial class COMMSerialPortParamForm
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
			Harry.LabCOMMPort.COMMSerialPortParam commSerialPortParam1 = new Harry.LabCOMMPort.COMMSerialPortParam();
			this.commSerialPortPlusFullParam = new Harry.LabCOMMPort.COMMSerialPortPlusFull();
			this.SuspendLayout();
			// 
			// commSerialPortPlusFullParam
			// 
			this.commSerialPortPlusFullParam.Location = new System.Drawing.Point(0, 0);
			this.commSerialPortPlusFullParam.m_COMMForm = null;
			this.commSerialPortPlusFullParam.m_COMMPort = null;
			this.commSerialPortPlusFullParam.m_COMMRichTextBox = null;
			this.commSerialPortPlusFullParam.m_COMMSerialPortParam = commSerialPortParam1;
			this.commSerialPortPlusFullParam.Margin = new System.Windows.Forms.Padding(5);
			this.commSerialPortPlusFullParam.Name = "commSerialPortPlusFullParam";
			this.commSerialPortPlusFullParam.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.commSerialPortPlusFullParam.Size = new System.Drawing.Size(208, 242);
			this.commSerialPortPlusFullParam.TabIndex = 0;
			// 
			// COMMSerialPortParamForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(208, 242);
			this.Controls.Add(this.commSerialPortPlusFullParam);
			this.Name = "COMMSerialPortParamForm";
			this.Text = "COMMSerialPortParamForm";
			this.ResumeLayout(false);

			//this.commSerialPortPlusFullParam.m_COMMComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			//this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			//this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			//this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			//this.commSerialPortPlusFullParam.m_ComboBoxCOMMPortParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
		}

		#endregion

		private COMMSerialPortPlusFull commSerialPortPlusFullParam;
	}
}