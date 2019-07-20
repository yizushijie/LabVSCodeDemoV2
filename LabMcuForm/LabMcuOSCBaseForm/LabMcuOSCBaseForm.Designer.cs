namespace Harry.LabMcuForm
{
	partial class LabMcuOSCBaseForm
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
			this.components = new System.ComponentModel.Container();
			Harry.LabCOMMPort.COMMPortParam commPortParam1 = new Harry.LabCOMMPort.COMMPortParam();
			Harry.LabCOMMPort.COMMPortParam commPortParam3 = new Harry.LabCOMMPort.COMMPortParam();
			this.groupBox_ProgramDigitalPower = new System.Windows.Forms.GroupBox();
			this.panel_Excel = new System.Windows.Forms.Panel();
			this.button_SelectExcel = new System.Windows.Forms.Button();
			this.button_OpenExcel = new System.Windows.Forms.Button();
			this.textBox_ExcelPath = new System.Windows.Forms.TextBox();
			this.label_ExcelPath = new System.Windows.Forms.Label();
			this.richTextBoxEx_Msg = new Harry.LabUserControlPlus.RichTextBoxEx();
			this.groupBox_TestDevice = new System.Windows.Forms.GroupBox();
			this.groupBox_ScanOSCFunc = new System.Windows.Forms.GroupBox();
			this.button_STOPFunc = new System.Windows.Forms.Button();
			this.button_DoOSCFunc = new System.Windows.Forms.Button();
			this.label_StopPowerUnite = new System.Windows.Forms.Label();
			this.label_StepPowerUnite = new System.Windows.Forms.Label();
			this.label_StartPowerUnite = new System.Windows.Forms.Label();
			this.numericUpDownPlus_StopPower = new Harry.LabUserControlPlus.NumericUpDownPlus();
			this.label_StopPower = new System.Windows.Forms.Label();
			this.numericUpDownPlus_StepPower = new Harry.LabUserControlPlus.NumericUpDownPlus();
			this.label_StepPower = new System.Windows.Forms.Label();
			this.numericUpDownPlus_StartPower = new Harry.LabUserControlPlus.NumericUpDownPlus();
			this.label_StartPower = new System.Windows.Forms.Label();
			this.numericUpDownPlus_DigitalPowerChannel = new Harry.LabUserControlPlus.NumericUpDownPlus();
			this.label_DigitalPowerCH = new System.Windows.Forms.Label();
			this.commSerialPortPlus_Device = new Harry.LabCOMMPort.COMMSerialPortPlus();
			this.GPD3303Plus_DigitalPower = new Harry.LabDigitalPower.GPD3303Plus();
			this.groupBox_ProgramDigitalPower.SuspendLayout();
			this.panel_Excel.SuspendLayout();
			this.groupBox_TestDevice.SuspendLayout();
			this.groupBox_ScanOSCFunc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_StopPower)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_StepPower)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_StartPower)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_DigitalPowerChannel)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox_ProgramDigitalPower
			// 
			this.groupBox_ProgramDigitalPower.Controls.Add(this.GPD3303Plus_DigitalPower);
			this.groupBox_ProgramDigitalPower.Location = new System.Drawing.Point(12, 12);
			this.groupBox_ProgramDigitalPower.Name = "groupBox_ProgramDigitalPower";
			this.groupBox_ProgramDigitalPower.Size = new System.Drawing.Size(313, 226);
			this.groupBox_ProgramDigitalPower.TabIndex = 4;
			this.groupBox_ProgramDigitalPower.TabStop = false;
			this.groupBox_ProgramDigitalPower.Text = "可编程电源";
			// 
			// panel_Excel
			// 
			this.panel_Excel.Controls.Add(this.button_SelectExcel);
			this.panel_Excel.Controls.Add(this.button_OpenExcel);
			this.panel_Excel.Controls.Add(this.textBox_ExcelPath);
			this.panel_Excel.Controls.Add(this.label_ExcelPath);
			this.panel_Excel.Location = new System.Drawing.Point(331, 12);
			this.panel_Excel.Name = "panel_Excel";
			this.panel_Excel.Size = new System.Drawing.Size(530, 43);
			this.panel_Excel.TabIndex = 6;
			// 
			// button_SelectExcel
			// 
			this.button_SelectExcel.Location = new System.Drawing.Point(441, 8);
			this.button_SelectExcel.Name = "button_SelectExcel";
			this.button_SelectExcel.Size = new System.Drawing.Size(75, 23);
			this.button_SelectExcel.TabIndex = 3;
			this.button_SelectExcel.Text = "选择数据表";
			this.button_SelectExcel.UseVisualStyleBackColor = true;
			// 
			// button_OpenExcel
			// 
			this.button_OpenExcel.Location = new System.Drawing.Point(360, 8);
			this.button_OpenExcel.Name = "button_OpenExcel";
			this.button_OpenExcel.Size = new System.Drawing.Size(75, 23);
			this.button_OpenExcel.TabIndex = 2;
			this.button_OpenExcel.Text = "打开数据表";
			this.button_OpenExcel.UseVisualStyleBackColor = true;
			// 
			// textBox_ExcelPath
			// 
			this.textBox_ExcelPath.Location = new System.Drawing.Point(62, 10);
			this.textBox_ExcelPath.Name = "textBox_ExcelPath";
			this.textBox_ExcelPath.Size = new System.Drawing.Size(292, 21);
			this.textBox_ExcelPath.TabIndex = 1;
			// 
			// label_ExcelPath
			// 
			this.label_ExcelPath.AutoSize = true;
			this.label_ExcelPath.Location = new System.Drawing.Point(15, 13);
			this.label_ExcelPath.Name = "label_ExcelPath";
			this.label_ExcelPath.Size = new System.Drawing.Size(41, 12);
			this.label_ExcelPath.TabIndex = 0;
			this.label_ExcelPath.Text = "数据表";
			// 
			// richTextBoxEx_Msg
			// 
			this.richTextBoxEx_Msg.Location = new System.Drawing.Point(331, 61);
			this.richTextBoxEx_Msg.Name = "richTextBoxEx_Msg";
			this.richTextBoxEx_Msg.Size = new System.Drawing.Size(531, 412);
			this.richTextBoxEx_Msg.TabIndex = 7;
			this.richTextBoxEx_Msg.Text = "";
			// 
			// groupBox_TestDevice
			// 
			this.groupBox_TestDevice.Controls.Add(this.groupBox_ScanOSCFunc);
			this.groupBox_TestDevice.Controls.Add(this.commSerialPortPlus_Device);
			this.groupBox_TestDevice.Location = new System.Drawing.Point(12, 244);
			this.groupBox_TestDevice.Name = "groupBox_TestDevice";
			this.groupBox_TestDevice.Size = new System.Drawing.Size(313, 229);
			this.groupBox_TestDevice.TabIndex = 8;
			this.groupBox_TestDevice.TabStop = false;
			this.groupBox_TestDevice.Text = "测试设备";
			// 
			// groupBox_ScanOSCFunc
			// 
			this.groupBox_ScanOSCFunc.Controls.Add(this.button_STOPFunc);
			this.groupBox_ScanOSCFunc.Controls.Add(this.button_DoOSCFunc);
			this.groupBox_ScanOSCFunc.Controls.Add(this.label_StopPowerUnite);
			this.groupBox_ScanOSCFunc.Controls.Add(this.label_StepPowerUnite);
			this.groupBox_ScanOSCFunc.Controls.Add(this.label_StartPowerUnite);
			this.groupBox_ScanOSCFunc.Controls.Add(this.numericUpDownPlus_StopPower);
			this.groupBox_ScanOSCFunc.Controls.Add(this.label_StopPower);
			this.groupBox_ScanOSCFunc.Controls.Add(this.numericUpDownPlus_StepPower);
			this.groupBox_ScanOSCFunc.Controls.Add(this.label_StepPower);
			this.groupBox_ScanOSCFunc.Controls.Add(this.numericUpDownPlus_StartPower);
			this.groupBox_ScanOSCFunc.Controls.Add(this.label_StartPower);
			this.groupBox_ScanOSCFunc.Controls.Add(this.numericUpDownPlus_DigitalPowerChannel);
			this.groupBox_ScanOSCFunc.Controls.Add(this.label_DigitalPowerCH);
			this.groupBox_ScanOSCFunc.Location = new System.Drawing.Point(6, 87);
			this.groupBox_ScanOSCFunc.Name = "groupBox_ScanOSCFunc";
			this.groupBox_ScanOSCFunc.Size = new System.Drawing.Size(299, 132);
			this.groupBox_ScanOSCFunc.TabIndex = 6;
			this.groupBox_ScanOSCFunc.TabStop = false;
			this.groupBox_ScanOSCFunc.Text = "OSC功能扫描";
			// 
			// button_STOPFunc
			// 
			this.button_STOPFunc.Location = new System.Drawing.Point(220, 99);
			this.button_STOPFunc.Name = "button_STOPFunc";
			this.button_STOPFunc.Size = new System.Drawing.Size(73, 23);
			this.button_STOPFunc.TabIndex = 18;
			this.button_STOPFunc.Text = "结束";
			this.button_STOPFunc.UseVisualStyleBackColor = true;
			// 
			// button_DoOSCFunc
			// 
			this.button_DoOSCFunc.Location = new System.Drawing.Point(220, 66);
			this.button_DoOSCFunc.Name = "button_DoOSCFunc";
			this.button_DoOSCFunc.Size = new System.Drawing.Size(73, 23);
			this.button_DoOSCFunc.TabIndex = 17;
			this.button_DoOSCFunc.Text = "开始扫描";
			this.button_DoOSCFunc.UseVisualStyleBackColor = true;
			// 
			// label_StopPowerUnite
			// 
			this.label_StopPowerUnite.AutoSize = true;
			this.label_StopPowerUnite.Location = new System.Drawing.Point(137, 104);
			this.label_StopPowerUnite.Name = "label_StopPowerUnite";
			this.label_StopPowerUnite.Size = new System.Drawing.Size(17, 12);
			this.label_StopPowerUnite.TabIndex = 10;
			this.label_StopPowerUnite.Text = "mV";
			// 
			// label_StepPowerUnite
			// 
			this.label_StepPowerUnite.AutoSize = true;
			this.label_StepPowerUnite.Location = new System.Drawing.Point(137, 77);
			this.label_StepPowerUnite.Name = "label_StepPowerUnite";
			this.label_StepPowerUnite.Size = new System.Drawing.Size(17, 12);
			this.label_StepPowerUnite.TabIndex = 9;
			this.label_StepPowerUnite.Text = "mV";
			// 
			// label_StartPowerUnite
			// 
			this.label_StartPowerUnite.AutoSize = true;
			this.label_StartPowerUnite.Location = new System.Drawing.Point(137, 50);
			this.label_StartPowerUnite.Name = "label_StartPowerUnite";
			this.label_StartPowerUnite.Size = new System.Drawing.Size(17, 12);
			this.label_StartPowerUnite.TabIndex = 8;
			this.label_StartPowerUnite.Text = "mV";
			// 
			// numericUpDownPlus_StopPower
			// 
			this.numericUpDownPlus_StopPower.Location = new System.Drawing.Point(67, 102);
			this.numericUpDownPlus_StopPower.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDownPlus_StopPower.Name = "numericUpDownPlus_StopPower";
			this.numericUpDownPlus_StopPower.Size = new System.Drawing.Size(64, 21);
			this.numericUpDownPlus_StopPower.TabIndex = 7;
			this.numericUpDownPlus_StopPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownPlus_StopPower.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			// 
			// label_StopPower
			// 
			this.label_StopPower.AutoSize = true;
			this.label_StopPower.Location = new System.Drawing.Point(8, 104);
			this.label_StopPower.Name = "label_StopPower";
			this.label_StopPower.Size = new System.Drawing.Size(53, 12);
			this.label_StopPower.TabIndex = 6;
			this.label_StopPower.Text = "终止电压";
			// 
			// numericUpDownPlus_StepPower
			// 
			this.numericUpDownPlus_StepPower.Location = new System.Drawing.Point(67, 75);
			this.numericUpDownPlus_StepPower.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownPlus_StepPower.Name = "numericUpDownPlus_StepPower";
			this.numericUpDownPlus_StepPower.Size = new System.Drawing.Size(64, 21);
			this.numericUpDownPlus_StepPower.TabIndex = 5;
			this.numericUpDownPlus_StepPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownPlus_StepPower.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			// 
			// label_StepPower
			// 
			this.label_StepPower.AutoSize = true;
			this.label_StepPower.Location = new System.Drawing.Point(8, 77);
			this.label_StepPower.Name = "label_StepPower";
			this.label_StepPower.Size = new System.Drawing.Size(53, 12);
			this.label_StepPower.TabIndex = 4;
			this.label_StepPower.Text = "步进电压";
			// 
			// numericUpDownPlus_StartPower
			// 
			this.numericUpDownPlus_StartPower.Location = new System.Drawing.Point(67, 48);
			this.numericUpDownPlus_StartPower.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDownPlus_StartPower.Name = "numericUpDownPlus_StartPower";
			this.numericUpDownPlus_StartPower.Size = new System.Drawing.Size(64, 21);
			this.numericUpDownPlus_StartPower.TabIndex = 3;
			this.numericUpDownPlus_StartPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownPlus_StartPower.Value = new decimal(new int[] {
            1800,
            0,
            0,
            0});
			// 
			// label_StartPower
			// 
			this.label_StartPower.AutoSize = true;
			this.label_StartPower.Location = new System.Drawing.Point(8, 50);
			this.label_StartPower.Name = "label_StartPower";
			this.label_StartPower.Size = new System.Drawing.Size(53, 12);
			this.label_StartPower.TabIndex = 2;
			this.label_StartPower.Text = "起始电压";
			// 
			// numericUpDownPlus_DigitalPowerChannel
			// 
			this.numericUpDownPlus_DigitalPowerChannel.Location = new System.Drawing.Point(67, 21);
			this.numericUpDownPlus_DigitalPowerChannel.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.numericUpDownPlus_DigitalPowerChannel.Name = "numericUpDownPlus_DigitalPowerChannel";
			this.numericUpDownPlus_DigitalPowerChannel.Size = new System.Drawing.Size(64, 21);
			this.numericUpDownPlus_DigitalPowerChannel.TabIndex = 1;
			this.numericUpDownPlus_DigitalPowerChannel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label_DigitalPowerCH
			// 
			this.label_DigitalPowerCH.AutoSize = true;
			this.label_DigitalPowerCH.Location = new System.Drawing.Point(8, 23);
			this.label_DigitalPowerCH.Name = "label_DigitalPowerCH";
			this.label_DigitalPowerCH.Size = new System.Drawing.Size(53, 12);
			this.label_DigitalPowerCH.TabIndex = 0;
			this.label_DigitalPowerCH.Text = "电源通道";
			// 
			// commSerialPortPlus_Device
			// 
			this.commSerialPortPlus_Device.Location = new System.Drawing.Point(6, 20);
			this.commSerialPortPlus_Device.m_COMM = null;
			this.commSerialPortPlus_Device.m_COMMBaudRate = 115200;
			this.commSerialPortPlus_Device.m_COMMForm = null;
			this.commSerialPortPlus_Device.m_COMMParam = commPortParam1;
			this.commSerialPortPlus_Device.m_COMMRichTextBox = null;
			this.commSerialPortPlus_Device.m_COMMShowParamMenu = true;
			this.commSerialPortPlus_Device.Name = "commSerialPortPlus_Device";
			this.commSerialPortPlus_Device.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.commSerialPortPlus_Device.Size = new System.Drawing.Size(266, 61);
			this.commSerialPortPlus_Device.TabIndex = 0;
			// 
			// GPD3303Plus_DigitalPower
			// 
			this.GPD3303Plus_DigitalPower.Location = new System.Drawing.Point(6, 20);
			this.GPD3303Plus_DigitalPower.m_COMM = null;
			this.GPD3303Plus_DigitalPower.m_COMMBaudRate = 115200;
			this.GPD3303Plus_DigitalPower.m_COMMForm = null;
			this.GPD3303Plus_DigitalPower.m_COMMParam = commPortParam3;
			this.GPD3303Plus_DigitalPower.m_COMMRichTextBox = null;
			this.GPD3303Plus_DigitalPower.m_COMMShowParamMenu = true;
			this.GPD3303Plus_DigitalPower.Name = "GPD3303Plus_DigitalPower";
			this.GPD3303Plus_DigitalPower.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.GPD3303Plus_DigitalPower.Size = new System.Drawing.Size(296, 200);
			this.GPD3303Plus_DigitalPower.TabIndex = 4;
			// 
			// LabMcuOSCBaseForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(869, 481);
			this.Controls.Add(this.groupBox_TestDevice);
			this.Controls.Add(this.richTextBoxEx_Msg);
			this.Controls.Add(this.panel_Excel);
			this.Controls.Add(this.groupBox_ProgramDigitalPower);
			this.Name = "LabMcuOSCBaseForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LabMcuOSCBaseForm";
			this.groupBox_ProgramDigitalPower.ResumeLayout(false);
			this.panel_Excel.ResumeLayout(false);
			this.panel_Excel.PerformLayout();
			this.groupBox_TestDevice.ResumeLayout(false);
			this.groupBox_ScanOSCFunc.ResumeLayout(false);
			this.groupBox_ScanOSCFunc.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_StopPower)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_StepPower)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_StartPower)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_DigitalPowerChannel)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox_ProgramDigitalPower;
		private LabDigitalPower.GPD3303Plus GPD3303Plus_DigitalPower;
		private System.Windows.Forms.Panel panel_Excel;
		private System.Windows.Forms.Button button_SelectExcel;
		private System.Windows.Forms.Button button_OpenExcel;
		private System.Windows.Forms.TextBox textBox_ExcelPath;
		private System.Windows.Forms.Label label_ExcelPath;
		private LabUserControlPlus.RichTextBoxEx richTextBoxEx_Msg;
		private System.Windows.Forms.GroupBox groupBox_TestDevice;
		public System.Windows.Forms.GroupBox groupBox_ScanOSCFunc;
		private System.Windows.Forms.Button button_STOPFunc;
		private System.Windows.Forms.Button button_DoOSCFunc;
		private System.Windows.Forms.Label label_StopPowerUnite;
		private System.Windows.Forms.Label label_StepPowerUnite;
		private System.Windows.Forms.Label label_StartPowerUnite;
		private LabUserControlPlus.NumericUpDownPlus numericUpDownPlus_StopPower;
		private System.Windows.Forms.Label label_StopPower;
		private LabUserControlPlus.NumericUpDownPlus numericUpDownPlus_StepPower;
		private System.Windows.Forms.Label label_StepPower;
		private LabUserControlPlus.NumericUpDownPlus numericUpDownPlus_StartPower;
		private System.Windows.Forms.Label label_StartPower;
		private LabUserControlPlus.NumericUpDownPlus numericUpDownPlus_DigitalPowerChannel;
		private System.Windows.Forms.Label label_DigitalPowerCH;
		private LabCOMMPort.COMMSerialPortPlus commSerialPortPlus_Device;
	}
}