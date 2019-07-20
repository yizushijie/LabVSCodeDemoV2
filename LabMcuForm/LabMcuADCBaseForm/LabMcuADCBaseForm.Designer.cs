using Harry.LabCOMMPort;

namespace Harry.LabMcuForm
{
	partial class LabMcuADCBaseForm
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
			Harry.LabCOMMPort.COMMPortParam commPortParam2 = new Harry.LabCOMMPort.COMMPortParam();
			this.groupBox_TestDevice = new System.Windows.Forms.GroupBox();
			this.panel_SampleNum = new System.Windows.Forms.Panel();
			this.numericUpDownPlus_SampleNum = new Harry.LabUserControlPlus.NumericUpDownPlus();
			this.label_ADCSampleNum = new System.Windows.Forms.Label();
			this.button_WriteADCSampleNum = new System.Windows.Forms.Button();
			this.button_ReadADCSampleNum = new System.Windows.Forms.Button();
			this.groupBox_ScanADCFunc = new System.Windows.Forms.GroupBox();
			this.button_STOPFunc = new System.Windows.Forms.Button();
			this.button_DoADCFunc = new System.Windows.Forms.Button();
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
			this.panel_ADCChannel = new System.Windows.Forms.Panel();
			this.label_SelectADCChannel = new System.Windows.Forms.Label();
			this.comboBoxEx_SelectADCChannel = new Harry.LabUserControlPlus.ComboBoxEx();
			this.button_WriteADCChannel = new System.Windows.Forms.Button();
			this.button_ReadADCChannel = new System.Windows.Forms.Button();
			this.panel_ADCVREF = new System.Windows.Forms.Panel();
			this.label_SelectADCVREF = new System.Windows.Forms.Label();
			this.comboBoxEx_SelectADCVREFMode = new Harry.LabUserControlPlus.ComboBoxEx();
			this.button_WriteADCVREFMode = new System.Windows.Forms.Button();
			this.button_ReadADCVREFMode = new System.Windows.Forms.Button();
			this.commSerialPortPlus_Device = new Harry.LabCOMMPort.COMMSerialPortPlus();
			this.groupBox_ProgramDigitalPower = new System.Windows.Forms.GroupBox();
			this.GPD3303Plus_DigitalPower = new Harry.LabDigitalPower.GPD3303Plus();
			this.richTextBoxEx_Msg = new Harry.LabUserControlPlus.RichTextBoxEx();
			this.panel_Excel = new System.Windows.Forms.Panel();
			this.button_SelectExcel = new System.Windows.Forms.Button();
			this.button_OpenExcel = new System.Windows.Forms.Button();
			this.textBox_ExcelPath = new System.Windows.Forms.TextBox();
			this.label_ExcelPath = new System.Windows.Forms.Label();
			this.groupBox_TestDevice.SuspendLayout();
			this.panel_SampleNum.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_SampleNum)).BeginInit();
			this.groupBox_ScanADCFunc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_StopPower)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_StepPower)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_StartPower)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_DigitalPowerChannel)).BeginInit();
			this.panel_ADCChannel.SuspendLayout();
			this.panel_ADCVREF.SuspendLayout();
			this.groupBox_ProgramDigitalPower.SuspendLayout();
			this.panel_Excel.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox_TestDevice
			// 
			this.groupBox_TestDevice.Controls.Add(this.panel_SampleNum);
			this.groupBox_TestDevice.Controls.Add(this.groupBox_ScanADCFunc);
			this.groupBox_TestDevice.Controls.Add(this.panel_ADCChannel);
			this.groupBox_TestDevice.Controls.Add(this.panel_ADCVREF);
			this.groupBox_TestDevice.Controls.Add(this.commSerialPortPlus_Device);
			this.groupBox_TestDevice.Location = new System.Drawing.Point(12, 244);
			this.groupBox_TestDevice.Name = "groupBox_TestDevice";
			this.groupBox_TestDevice.Size = new System.Drawing.Size(313, 350);
			this.groupBox_TestDevice.TabIndex = 2;
			this.groupBox_TestDevice.TabStop = false;
			this.groupBox_TestDevice.Text = "测试设备";
			// 
			// panel_SampleNum
			// 
			this.panel_SampleNum.Controls.Add(this.numericUpDownPlus_SampleNum);
			this.panel_SampleNum.Controls.Add(this.label_ADCSampleNum);
			this.panel_SampleNum.Controls.Add(this.button_WriteADCSampleNum);
			this.panel_SampleNum.Controls.Add(this.button_ReadADCSampleNum);
			this.panel_SampleNum.Location = new System.Drawing.Point(6, 169);
			this.panel_SampleNum.Name = "panel_SampleNum";
			this.panel_SampleNum.Size = new System.Drawing.Size(299, 36);
			this.panel_SampleNum.TabIndex = 6;
			// 
			// numericUpDownPlus_SampleNum
			// 
			this.numericUpDownPlus_SampleNum.Location = new System.Drawing.Point(62, 8);
			this.numericUpDownPlus_SampleNum.Name = "numericUpDownPlus_SampleNum";
			this.numericUpDownPlus_SampleNum.Size = new System.Drawing.Size(69, 21);
			this.numericUpDownPlus_SampleNum.TabIndex = 7;
			this.numericUpDownPlus_SampleNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownPlus_SampleNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label_ADCSampleNum
			// 
			this.label_ADCSampleNum.AutoSize = true;
			this.label_ADCSampleNum.Location = new System.Drawing.Point(3, 10);
			this.label_ADCSampleNum.Name = "label_ADCSampleNum";
			this.label_ADCSampleNum.Size = new System.Drawing.Size(53, 12);
			this.label_ADCSampleNum.TabIndex = 13;
			this.label_ADCSampleNum.Text = "采样次数";
			// 
			// button_WriteADCSampleNum
			// 
			this.button_WriteADCSampleNum.Location = new System.Drawing.Point(249, 6);
			this.button_WriteADCSampleNum.Name = "button_WriteADCSampleNum";
			this.button_WriteADCSampleNum.Size = new System.Drawing.Size(45, 23);
			this.button_WriteADCSampleNum.TabIndex = 17;
			this.button_WriteADCSampleNum.Text = "设置";
			this.button_WriteADCSampleNum.UseVisualStyleBackColor = true;
			// 
			// button_ReadADCSampleNum
			// 
			this.button_ReadADCSampleNum.Location = new System.Drawing.Point(198, 6);
			this.button_ReadADCSampleNum.Name = "button_ReadADCSampleNum";
			this.button_ReadADCSampleNum.Size = new System.Drawing.Size(45, 23);
			this.button_ReadADCSampleNum.TabIndex = 16;
			this.button_ReadADCSampleNum.Text = "读取";
			this.button_ReadADCSampleNum.UseVisualStyleBackColor = true;
			// 
			// groupBox_ScanADCFunc
			// 
			this.groupBox_ScanADCFunc.Controls.Add(this.button_STOPFunc);
			this.groupBox_ScanADCFunc.Controls.Add(this.button_DoADCFunc);
			this.groupBox_ScanADCFunc.Controls.Add(this.label_StopPowerUnite);
			this.groupBox_ScanADCFunc.Controls.Add(this.label_StepPowerUnite);
			this.groupBox_ScanADCFunc.Controls.Add(this.label_StartPowerUnite);
			this.groupBox_ScanADCFunc.Controls.Add(this.numericUpDownPlus_StopPower);
			this.groupBox_ScanADCFunc.Controls.Add(this.label_StopPower);
			this.groupBox_ScanADCFunc.Controls.Add(this.numericUpDownPlus_StepPower);
			this.groupBox_ScanADCFunc.Controls.Add(this.label_StepPower);
			this.groupBox_ScanADCFunc.Controls.Add(this.numericUpDownPlus_StartPower);
			this.groupBox_ScanADCFunc.Controls.Add(this.label_StartPower);
			this.groupBox_ScanADCFunc.Controls.Add(this.numericUpDownPlus_DigitalPowerChannel);
			this.groupBox_ScanADCFunc.Controls.Add(this.label_DigitalPowerCH);
			this.groupBox_ScanADCFunc.Location = new System.Drawing.Point(6, 211);
			this.groupBox_ScanADCFunc.Name = "groupBox_ScanADCFunc";
			this.groupBox_ScanADCFunc.Size = new System.Drawing.Size(299, 132);
			this.groupBox_ScanADCFunc.TabIndex = 6;
			this.groupBox_ScanADCFunc.TabStop = false;
			this.groupBox_ScanADCFunc.Text = "ADC功能扫描";
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
			// button_DoADCFunc
			// 
			this.button_DoADCFunc.Location = new System.Drawing.Point(220, 66);
			this.button_DoADCFunc.Name = "button_DoADCFunc";
			this.button_DoADCFunc.Size = new System.Drawing.Size(73, 23);
			this.button_DoADCFunc.TabIndex = 17;
			this.button_DoADCFunc.Text = "开始扫描";
			this.button_DoADCFunc.UseVisualStyleBackColor = true;
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
            4096,
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
            16,
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
            2,
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
			// panel_ADCChannel
			// 
			this.panel_ADCChannel.Controls.Add(this.label_SelectADCChannel);
			this.panel_ADCChannel.Controls.Add(this.comboBoxEx_SelectADCChannel);
			this.panel_ADCChannel.Controls.Add(this.button_WriteADCChannel);
			this.panel_ADCChannel.Controls.Add(this.button_ReadADCChannel);
			this.panel_ADCChannel.Location = new System.Drawing.Point(6, 128);
			this.panel_ADCChannel.Name = "panel_ADCChannel";
			this.panel_ADCChannel.Size = new System.Drawing.Size(299, 35);
			this.panel_ADCChannel.TabIndex = 5;
			// 
			// label_SelectADCChannel
			// 
			this.label_SelectADCChannel.AutoSize = true;
			this.label_SelectADCChannel.Location = new System.Drawing.Point(3, 10);
			this.label_SelectADCChannel.Name = "label_SelectADCChannel";
			this.label_SelectADCChannel.Size = new System.Drawing.Size(47, 12);
			this.label_SelectADCChannel.TabIndex = 13;
			this.label_SelectADCChannel.Text = "ADC通道";
			// 
			// comboBoxEx_SelectADCChannel
			// 
			this.comboBoxEx_SelectADCChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEx_SelectADCChannel.FormattingEnabled = true;
			this.comboBoxEx_SelectADCChannel.IntegralHeight = false;
			this.comboBoxEx_SelectADCChannel.Items.AddRange(new object[] {
            "设定电压",
            "设定电流",
            "读取电压",
            "读取电流"});
			this.comboBoxEx_SelectADCChannel.Location = new System.Drawing.Point(62, 7);
			this.comboBoxEx_SelectADCChannel.Name = "comboBoxEx_SelectADCChannel";
			this.comboBoxEx_SelectADCChannel.Size = new System.Drawing.Size(130, 20);
			this.comboBoxEx_SelectADCChannel.TabIndex = 12;
			// 
			// button_WriteADCChannel
			// 
			this.button_WriteADCChannel.Location = new System.Drawing.Point(249, 5);
			this.button_WriteADCChannel.Name = "button_WriteADCChannel";
			this.button_WriteADCChannel.Size = new System.Drawing.Size(45, 23);
			this.button_WriteADCChannel.TabIndex = 17;
			this.button_WriteADCChannel.Text = "设置";
			this.button_WriteADCChannel.UseVisualStyleBackColor = true;
			// 
			// button_ReadADCChannel
			// 
			this.button_ReadADCChannel.Location = new System.Drawing.Point(198, 5);
			this.button_ReadADCChannel.Name = "button_ReadADCChannel";
			this.button_ReadADCChannel.Size = new System.Drawing.Size(45, 23);
			this.button_ReadADCChannel.TabIndex = 16;
			this.button_ReadADCChannel.Text = "读取";
			this.button_ReadADCChannel.UseVisualStyleBackColor = true;
			// 
			// panel_ADCVREF
			// 
			this.panel_ADCVREF.Controls.Add(this.label_SelectADCVREF);
			this.panel_ADCVREF.Controls.Add(this.comboBoxEx_SelectADCVREFMode);
			this.panel_ADCVREF.Controls.Add(this.button_WriteADCVREFMode);
			this.panel_ADCVREF.Controls.Add(this.button_ReadADCVREFMode);
			this.panel_ADCVREF.Location = new System.Drawing.Point(6, 87);
			this.panel_ADCVREF.Name = "panel_ADCVREF";
			this.panel_ADCVREF.Size = new System.Drawing.Size(299, 35);
			this.panel_ADCVREF.TabIndex = 4;
			// 
			// label_SelectADCVREF
			// 
			this.label_SelectADCVREF.AutoSize = true;
			this.label_SelectADCVREF.Location = new System.Drawing.Point(3, 10);
			this.label_SelectADCVREF.Name = "label_SelectADCVREF";
			this.label_SelectADCVREF.Size = new System.Drawing.Size(53, 12);
			this.label_SelectADCVREF.TabIndex = 13;
			this.label_SelectADCVREF.Text = "参考电压";
			// 
			// comboBoxEx_SelectADCVREFMode
			// 
			this.comboBoxEx_SelectADCVREFMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEx_SelectADCVREFMode.FormattingEnabled = true;
			this.comboBoxEx_SelectADCVREFMode.Items.AddRange(new object[] {
            "设定电压",
            "设定电流",
            "读取电压",
            "读取电流"});
			this.comboBoxEx_SelectADCVREFMode.Location = new System.Drawing.Point(62, 7);
			this.comboBoxEx_SelectADCVREFMode.Name = "comboBoxEx_SelectADCVREFMode";
			this.comboBoxEx_SelectADCVREFMode.Size = new System.Drawing.Size(130, 20);
			this.comboBoxEx_SelectADCVREFMode.TabIndex = 12;
			// 
			// button_WriteADCVREFMode
			// 
			this.button_WriteADCVREFMode.Location = new System.Drawing.Point(249, 5);
			this.button_WriteADCVREFMode.Name = "button_WriteADCVREFMode";
			this.button_WriteADCVREFMode.Size = new System.Drawing.Size(45, 23);
			this.button_WriteADCVREFMode.TabIndex = 17;
			this.button_WriteADCVREFMode.Text = "设置";
			this.button_WriteADCVREFMode.UseVisualStyleBackColor = true;
			// 
			// button_ReadADCVREFMode
			// 
			this.button_ReadADCVREFMode.Location = new System.Drawing.Point(198, 5);
			this.button_ReadADCVREFMode.Name = "button_ReadADCVREFMode";
			this.button_ReadADCVREFMode.Size = new System.Drawing.Size(45, 23);
			this.button_ReadADCVREFMode.TabIndex = 16;
			this.button_ReadADCVREFMode.Text = "读取";
			this.button_ReadADCVREFMode.UseVisualStyleBackColor = true;
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
			// groupBox_ProgramDigitalPower
			// 
			this.groupBox_ProgramDigitalPower.Controls.Add(this.GPD3303Plus_DigitalPower);
			this.groupBox_ProgramDigitalPower.Location = new System.Drawing.Point(12, 12);
			this.groupBox_ProgramDigitalPower.Name = "groupBox_ProgramDigitalPower";
			this.groupBox_ProgramDigitalPower.Size = new System.Drawing.Size(313, 226);
			this.groupBox_ProgramDigitalPower.TabIndex = 3;
			this.groupBox_ProgramDigitalPower.TabStop = false;
			this.groupBox_ProgramDigitalPower.Text = "可编程电源";
			// 
			// GPD3303Plus_DigitalPower
			// 
			this.GPD3303Plus_DigitalPower.Location = new System.Drawing.Point(6, 20);
			this.GPD3303Plus_DigitalPower.m_COMM = null;
			this.GPD3303Plus_DigitalPower.m_COMMBaudRate = 115200;
			this.GPD3303Plus_DigitalPower.m_COMMForm = null;
			this.GPD3303Plus_DigitalPower.m_COMMParam = commPortParam2;
			this.GPD3303Plus_DigitalPower.m_COMMRichTextBox = null;
			this.GPD3303Plus_DigitalPower.m_COMMShowParamMenu = true;
			this.GPD3303Plus_DigitalPower.Name = "GPD3303Plus_DigitalPower";
			this.GPD3303Plus_DigitalPower.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.GPD3303Plus_DigitalPower.Size = new System.Drawing.Size(296, 200);
			this.GPD3303Plus_DigitalPower.TabIndex = 4;
			// 
			// richTextBoxEx_Msg
			// 
			this.richTextBoxEx_Msg.Location = new System.Drawing.Point(331, 61);
			this.richTextBoxEx_Msg.Name = "richTextBoxEx_Msg";
			this.richTextBoxEx_Msg.Size = new System.Drawing.Size(531, 533);
			this.richTextBoxEx_Msg.TabIndex = 4;
			this.richTextBoxEx_Msg.Text = "";
			// 
			// panel_Excel
			// 
			this.panel_Excel.Controls.Add(this.button_SelectExcel);
			this.panel_Excel.Controls.Add(this.button_OpenExcel);
			this.panel_Excel.Controls.Add(this.textBox_ExcelPath);
			this.panel_Excel.Controls.Add(this.label_ExcelPath);
			this.panel_Excel.Location = new System.Drawing.Point(332, 12);
			this.panel_Excel.Name = "panel_Excel";
			this.panel_Excel.Size = new System.Drawing.Size(530, 43);
			this.panel_Excel.TabIndex = 5;
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
			// LabMcuADCBaseForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(874, 599);
			this.Controls.Add(this.panel_Excel);
			this.Controls.Add(this.richTextBoxEx_Msg);
			this.Controls.Add(this.groupBox_ProgramDigitalPower);
			this.Controls.Add(this.groupBox_TestDevice);
			this.Name = "LabMcuADCBaseForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LabMcuADCBaseForm";
			this.groupBox_TestDevice.ResumeLayout(false);
			this.panel_SampleNum.ResumeLayout(false);
			this.panel_SampleNum.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_SampleNum)).EndInit();
			this.groupBox_ScanADCFunc.ResumeLayout(false);
			this.groupBox_ScanADCFunc.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_StopPower)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_StepPower)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_StartPower)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_DigitalPowerChannel)).EndInit();
			this.panel_ADCChannel.ResumeLayout(false);
			this.panel_ADCChannel.PerformLayout();
			this.panel_ADCVREF.ResumeLayout(false);
			this.panel_ADCVREF.PerformLayout();
			this.groupBox_ProgramDigitalPower.ResumeLayout(false);
			this.panel_Excel.ResumeLayout(false);
			this.panel_Excel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Harry.LabCOMMPort.COMMSerialPortPlus commSerialPortPlus_Device;
		private System.Windows.Forms.GroupBox groupBox_ProgramDigitalPower;
		private LabDigitalPower.GPD3303Plus GPD3303Plus_DigitalPower;
		private System.Windows.Forms.Label label_SelectADCVREF;
		private System.Windows.Forms.Button button_WriteADCChannel;
		private System.Windows.Forms.Button button_ReadADCChannel;
		private System.Windows.Forms.Button button_WriteADCVREFMode;
		private System.Windows.Forms.Button button_ReadADCVREFMode;
		private LabUserControlPlus.NumericUpDownPlus numericUpDownPlus_DigitalPowerChannel;
		private System.Windows.Forms.Label label_DigitalPowerCH;
		private LabUserControlPlus.NumericUpDownPlus numericUpDownPlus_StopPower;
		private System.Windows.Forms.Label label_StopPower;
		private LabUserControlPlus.NumericUpDownPlus numericUpDownPlus_StepPower;
		private System.Windows.Forms.Label label_StepPower;
		private LabUserControlPlus.NumericUpDownPlus numericUpDownPlus_StartPower;
		private System.Windows.Forms.Label label_StartPower;
		private System.Windows.Forms.Label label_StartPowerUnite;
		private System.Windows.Forms.Label label_StopPowerUnite;
		private System.Windows.Forms.Label label_StepPowerUnite;
		private System.Windows.Forms.Button button_DoADCFunc;
		private LabUserControlPlus.RichTextBoxEx richTextBoxEx_Msg;
		private LabUserControlPlus.ComboBoxEx comboBoxEx_SelectADCChannel;
		private LabUserControlPlus.ComboBoxEx comboBoxEx_SelectADCVREFMode;
		private LabUserControlPlus.NumericUpDownPlus numericUpDownPlus_SampleNum;
		private System.Windows.Forms.Label label_ADCSampleNum;
		private System.Windows.Forms.Button button_WriteADCSampleNum;
		private System.Windows.Forms.Button button_ReadADCSampleNum;
		private System.Windows.Forms.Button button_STOPFunc;
		private System.Windows.Forms.Panel panel_Excel;
		private System.Windows.Forms.Button button_SelectExcel;
		private System.Windows.Forms.Button button_OpenExcel;
		private System.Windows.Forms.TextBox textBox_ExcelPath;
		private System.Windows.Forms.Label label_ExcelPath;
		private System.Windows.Forms.GroupBox groupBox_TestDevice;
		private System.Windows.Forms.Label label_SelectADCChannel;
		public System.Windows.Forms.Panel panel_ADCVREF;
		public System.Windows.Forms.Panel panel_SampleNum;
		public System.Windows.Forms.Panel panel_ADCChannel;
		public System.Windows.Forms.GroupBox groupBox_ScanADCFunc;
	}
}