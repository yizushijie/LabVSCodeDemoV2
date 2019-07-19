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
			LabMcuADCBaseForm labMcuADCBaseForm = this;
			labMcuADCBaseForm.components = new System.ComponentModel.Container();
			Harry.LabCOMMPort.COMMPortParam commSerialPortParam3 = new Harry.LabCOMMPort.COMMPortParam();
			Harry.LabCOMMPort.COMMPortParam commSerialPortParam1 = new Harry.LabCOMMPort.COMMPortParam();
			labMcuADCBaseForm.groupBox_TestDevice = new System.Windows.Forms.GroupBox();
			labMcuADCBaseForm.panel_SampleNum = new System.Windows.Forms.Panel();
			labMcuADCBaseForm.numericUpDownPlus_SampleNum = new Harry.LabUserControlPlus.NumericUpDownPlus();
			labMcuADCBaseForm.label_ADCSampleNum = new System.Windows.Forms.Label();
			labMcuADCBaseForm.button_WriteADCSampleNum = new System.Windows.Forms.Button();
			labMcuADCBaseForm.button_ReadADCSampleNum = new System.Windows.Forms.Button();
			labMcuADCBaseForm.groupBox_ScanADCFunc = new System.Windows.Forms.GroupBox();
			labMcuADCBaseForm.button_STOPFunc = new System.Windows.Forms.Button();
			labMcuADCBaseForm.button_DoADCFunc = new System.Windows.Forms.Button();
			labMcuADCBaseForm.label_StopPowerUnite = new System.Windows.Forms.Label();
			labMcuADCBaseForm.label_StepPowerUnite = new System.Windows.Forms.Label();
			labMcuADCBaseForm.label_StartPowerUnite = new System.Windows.Forms.Label();
			labMcuADCBaseForm.numericUpDownPlus_StopPower = new Harry.LabUserControlPlus.NumericUpDownPlus();
			labMcuADCBaseForm.label_StopPower = new System.Windows.Forms.Label();
			labMcuADCBaseForm.numericUpDownPlus_StepPower = new Harry.LabUserControlPlus.NumericUpDownPlus();
			labMcuADCBaseForm.label_StepPower = new System.Windows.Forms.Label();
			labMcuADCBaseForm.numericUpDownPlus_StartPower = new Harry.LabUserControlPlus.NumericUpDownPlus();
			labMcuADCBaseForm.label_StartPower = new System.Windows.Forms.Label();
			labMcuADCBaseForm.numericUpDownPlus_DigitalPowerChannel = new Harry.LabUserControlPlus.NumericUpDownPlus();
			labMcuADCBaseForm.label_DigitalPowerCH = new System.Windows.Forms.Label();
			labMcuADCBaseForm.panel_ADCChannel = new System.Windows.Forms.Panel();
			labMcuADCBaseForm.label_SelectADCChannel = new System.Windows.Forms.Label();
			labMcuADCBaseForm.comboBoxEx_SelectADCChannel = new Harry.LabUserControlPlus.ComboBoxEx();
			labMcuADCBaseForm.button_WriteADCChannel = new System.Windows.Forms.Button();
			labMcuADCBaseForm.button_ReadADCChannel = new System.Windows.Forms.Button();
			labMcuADCBaseForm.panel_ADCVREF = new System.Windows.Forms.Panel();
			labMcuADCBaseForm.label_SelectADCVREF = new System.Windows.Forms.Label();
			labMcuADCBaseForm.comboBoxEx_SelectADCVREFMode = new Harry.LabUserControlPlus.ComboBoxEx();
			labMcuADCBaseForm.button_WriteADCVREFMode = new System.Windows.Forms.Button();
			labMcuADCBaseForm.button_ReadADCVREFMode = new System.Windows.Forms.Button();
			labMcuADCBaseForm.commSerialPortPlus_Device = new Harry.LabCOMMPort.COMMSerialPortPlus();
			labMcuADCBaseForm.groupBox_ProgramDigitalPower = new System.Windows.Forms.GroupBox();
			labMcuADCBaseForm.GPD3303Plus_DigitalPower = new Harry.LabDigitalPower.GPD3303Plus();
			labMcuADCBaseForm.richTextBoxEx_Msg = new Harry.LabUserControlPlus.RichTextBoxEx();
			labMcuADCBaseForm.groupBox_TestDevice.SuspendLayout();
			labMcuADCBaseForm.panel_SampleNum.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)labMcuADCBaseForm.numericUpDownPlus_SampleNum).BeginInit();
			labMcuADCBaseForm.groupBox_ScanADCFunc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)labMcuADCBaseForm.numericUpDownPlus_StopPower).BeginInit();
			((System.ComponentModel.ISupportInitialize)labMcuADCBaseForm.numericUpDownPlus_StepPower).BeginInit();
			((System.ComponentModel.ISupportInitialize)labMcuADCBaseForm.numericUpDownPlus_StartPower).BeginInit();
			((System.ComponentModel.ISupportInitialize)labMcuADCBaseForm.numericUpDownPlus_DigitalPowerChannel).BeginInit();
			labMcuADCBaseForm.panel_ADCChannel.SuspendLayout();
			labMcuADCBaseForm.panel_ADCVREF.SuspendLayout();
			labMcuADCBaseForm.groupBox_ProgramDigitalPower.SuspendLayout();
			labMcuADCBaseForm.SuspendLayout();
			// 
			// groupBox_TestDevice
			// 
			labMcuADCBaseForm.groupBox_TestDevice.Controls.Add(labMcuADCBaseForm.panel_SampleNum);
			labMcuADCBaseForm.groupBox_TestDevice.Controls.Add(labMcuADCBaseForm.groupBox_ScanADCFunc);
			labMcuADCBaseForm.groupBox_TestDevice.Controls.Add(labMcuADCBaseForm.panel_ADCChannel);
			labMcuADCBaseForm.groupBox_TestDevice.Controls.Add(labMcuADCBaseForm.panel_ADCVREF);
			labMcuADCBaseForm.groupBox_TestDevice.Controls.Add(labMcuADCBaseForm.commSerialPortPlus_Device);
			labMcuADCBaseForm.groupBox_TestDevice.Location = new System.Drawing.Point(12, 244);
			labMcuADCBaseForm.groupBox_TestDevice.Name = "groupBox_TestDevice";
			labMcuADCBaseForm.groupBox_TestDevice.Size = new System.Drawing.Size(313, 350);
			labMcuADCBaseForm.groupBox_TestDevice.TabIndex = 2;
			labMcuADCBaseForm.groupBox_TestDevice.TabStop = false;
			labMcuADCBaseForm.groupBox_TestDevice.Text = "测试设备";
			// 
			// panel_SampleNum
			// 
			labMcuADCBaseForm.panel_SampleNum.Controls.Add(labMcuADCBaseForm.numericUpDownPlus_SampleNum);
			labMcuADCBaseForm.panel_SampleNum.Controls.Add(labMcuADCBaseForm.label_ADCSampleNum);
			labMcuADCBaseForm.panel_SampleNum.Controls.Add(labMcuADCBaseForm.button_WriteADCSampleNum);
			labMcuADCBaseForm.panel_SampleNum.Controls.Add(labMcuADCBaseForm.button_ReadADCSampleNum);
			labMcuADCBaseForm.panel_SampleNum.Location = new System.Drawing.Point(6, 169);
			labMcuADCBaseForm.panel_SampleNum.Name = "panel_SampleNum";
			labMcuADCBaseForm.panel_SampleNum.Size = new System.Drawing.Size(299, 36);
			labMcuADCBaseForm.panel_SampleNum.TabIndex = 6;
			// 
			// numericUpDownPlus_SampleNum
			// 
			labMcuADCBaseForm.numericUpDownPlus_SampleNum.Location = new System.Drawing.Point(62, 8);
			labMcuADCBaseForm.numericUpDownPlus_SampleNum.Name = "numericUpDownPlus_SampleNum";
			labMcuADCBaseForm.numericUpDownPlus_SampleNum.Size = new System.Drawing.Size(69, 21);
			labMcuADCBaseForm.numericUpDownPlus_SampleNum.TabIndex = 7;
			labMcuADCBaseForm.numericUpDownPlus_SampleNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			labMcuADCBaseForm.numericUpDownPlus_SampleNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label_ADCSampleNum
			// 
			labMcuADCBaseForm.label_ADCSampleNum.AutoSize = true;
			labMcuADCBaseForm.label_ADCSampleNum.Location = new System.Drawing.Point(3, 10);
			labMcuADCBaseForm.label_ADCSampleNum.Name = "label_ADCSampleNum";
			labMcuADCBaseForm.label_ADCSampleNum.Size = new System.Drawing.Size(53, 12);
			labMcuADCBaseForm.label_ADCSampleNum.TabIndex = 13;
			labMcuADCBaseForm.label_ADCSampleNum.Text = "采样次数";
			// 
			// button_WriteADCSampleNum
			// 
			labMcuADCBaseForm.button_WriteADCSampleNum.Location = new System.Drawing.Point(249, 6);
			labMcuADCBaseForm.button_WriteADCSampleNum.Name = "button_WriteADCSampleNum";
			labMcuADCBaseForm.button_WriteADCSampleNum.Size = new System.Drawing.Size(45, 23);
			labMcuADCBaseForm.button_WriteADCSampleNum.TabIndex = 17;
			labMcuADCBaseForm.button_WriteADCSampleNum.Text = "设置";
			labMcuADCBaseForm.button_WriteADCSampleNum.UseVisualStyleBackColor = true;
			// 
			// button_ReadADCSampleNum
			// 
			labMcuADCBaseForm.button_ReadADCSampleNum.Location = new System.Drawing.Point(198, 6);
			labMcuADCBaseForm.button_ReadADCSampleNum.Name = "button_ReadADCSampleNum";
			labMcuADCBaseForm.button_ReadADCSampleNum.Size = new System.Drawing.Size(45, 23);
			labMcuADCBaseForm.button_ReadADCSampleNum.TabIndex = 16;
			labMcuADCBaseForm.button_ReadADCSampleNum.Text = "读取";
			labMcuADCBaseForm.button_ReadADCSampleNum.UseVisualStyleBackColor = true;
			// 
			// groupBox_ScanADCFunc
			// 
			labMcuADCBaseForm.groupBox_ScanADCFunc.Controls.Add(labMcuADCBaseForm.button_STOPFunc);
			labMcuADCBaseForm.groupBox_ScanADCFunc.Controls.Add(labMcuADCBaseForm.button_DoADCFunc);
			labMcuADCBaseForm.groupBox_ScanADCFunc.Controls.Add(labMcuADCBaseForm.label_StopPowerUnite);
			labMcuADCBaseForm.groupBox_ScanADCFunc.Controls.Add(labMcuADCBaseForm.label_StepPowerUnite);
			labMcuADCBaseForm.groupBox_ScanADCFunc.Controls.Add(labMcuADCBaseForm.label_StartPowerUnite);
			labMcuADCBaseForm.groupBox_ScanADCFunc.Controls.Add(labMcuADCBaseForm.numericUpDownPlus_StopPower);
			labMcuADCBaseForm.groupBox_ScanADCFunc.Controls.Add(labMcuADCBaseForm.label_StopPower);
			labMcuADCBaseForm.groupBox_ScanADCFunc.Controls.Add(labMcuADCBaseForm.numericUpDownPlus_StepPower);
			labMcuADCBaseForm.groupBox_ScanADCFunc.Controls.Add(labMcuADCBaseForm.label_StepPower);
			labMcuADCBaseForm.groupBox_ScanADCFunc.Controls.Add(labMcuADCBaseForm.numericUpDownPlus_StartPower);
			labMcuADCBaseForm.groupBox_ScanADCFunc.Controls.Add(labMcuADCBaseForm.label_StartPower);
			labMcuADCBaseForm.groupBox_ScanADCFunc.Controls.Add(labMcuADCBaseForm.numericUpDownPlus_DigitalPowerChannel);
			labMcuADCBaseForm.groupBox_ScanADCFunc.Controls.Add(labMcuADCBaseForm.label_DigitalPowerCH);
			labMcuADCBaseForm.groupBox_ScanADCFunc.Location = new System.Drawing.Point(6, 211);
			labMcuADCBaseForm.groupBox_ScanADCFunc.Name = "groupBox_ScanADCFunc";
			labMcuADCBaseForm.groupBox_ScanADCFunc.Size = new System.Drawing.Size(299, 132);
			labMcuADCBaseForm.groupBox_ScanADCFunc.TabIndex = 6;
			labMcuADCBaseForm.groupBox_ScanADCFunc.TabStop = false;
			labMcuADCBaseForm.groupBox_ScanADCFunc.Text = "ADC功能扫描";
			// 
			// button_STOPFunc
			// 
			labMcuADCBaseForm.button_STOPFunc.Location = new System.Drawing.Point(220, 99);
			labMcuADCBaseForm.button_STOPFunc.Name = "button_STOPFunc";
			labMcuADCBaseForm.button_STOPFunc.Size = new System.Drawing.Size(73, 23);
			labMcuADCBaseForm.button_STOPFunc.TabIndex = 18;
			labMcuADCBaseForm.button_STOPFunc.Text = "结束";
			labMcuADCBaseForm.button_STOPFunc.UseVisualStyleBackColor = true;
			// 
			// button_DoADCFunc
			// 
			labMcuADCBaseForm.button_DoADCFunc.Location = new System.Drawing.Point(220, 66);
			labMcuADCBaseForm.button_DoADCFunc.Name = "button_DoADCFunc";
			labMcuADCBaseForm.button_DoADCFunc.Size = new System.Drawing.Size(73, 23);
			labMcuADCBaseForm.button_DoADCFunc.TabIndex = 17;
			labMcuADCBaseForm.button_DoADCFunc.Text = "开始扫描";
			labMcuADCBaseForm.button_DoADCFunc.UseVisualStyleBackColor = true;
			// 
			// label_StopPowerUnite
			// 
			labMcuADCBaseForm.label_StopPowerUnite.AutoSize = true;
			labMcuADCBaseForm.label_StopPowerUnite.Location = new System.Drawing.Point(137, 104);
			labMcuADCBaseForm.label_StopPowerUnite.Name = "label_StopPowerUnite";
			labMcuADCBaseForm.label_StopPowerUnite.Size = new System.Drawing.Size(17, 12);
			labMcuADCBaseForm.label_StopPowerUnite.TabIndex = 10;
			labMcuADCBaseForm.label_StopPowerUnite.Text = "mV";
			// 
			// label_StepPowerUnite
			// 
			labMcuADCBaseForm.label_StepPowerUnite.AutoSize = true;
			labMcuADCBaseForm.label_StepPowerUnite.Location = new System.Drawing.Point(137, 77);
			labMcuADCBaseForm.label_StepPowerUnite.Name = "label_StepPowerUnite";
			labMcuADCBaseForm.label_StepPowerUnite.Size = new System.Drawing.Size(17, 12);
			labMcuADCBaseForm.label_StepPowerUnite.TabIndex = 9;
			labMcuADCBaseForm.label_StepPowerUnite.Text = "mV";
			// 
			// label_StartPowerUnite
			// 
			labMcuADCBaseForm.label_StartPowerUnite.AutoSize = true;
			labMcuADCBaseForm.label_StartPowerUnite.Location = new System.Drawing.Point(137, 50);
			labMcuADCBaseForm.label_StartPowerUnite.Name = "label_StartPowerUnite";
			labMcuADCBaseForm.label_StartPowerUnite.Size = new System.Drawing.Size(17, 12);
			labMcuADCBaseForm.label_StartPowerUnite.TabIndex = 8;
			labMcuADCBaseForm.label_StartPowerUnite.Text = "mV";
			// 
			// numericUpDownPlus_StopPower
			// 
			labMcuADCBaseForm.numericUpDownPlus_StopPower.Location = new System.Drawing.Point(67, 102);
			labMcuADCBaseForm.numericUpDownPlus_StopPower.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			labMcuADCBaseForm.numericUpDownPlus_StopPower.Name = "numericUpDownPlus_StopPower";
			labMcuADCBaseForm.numericUpDownPlus_StopPower.Size = new System.Drawing.Size(64, 21);
			labMcuADCBaseForm.numericUpDownPlus_StopPower.TabIndex = 7;
			labMcuADCBaseForm.numericUpDownPlus_StopPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			labMcuADCBaseForm.numericUpDownPlus_StopPower.Value = new decimal(new int[] {
            4096,
            0,
            0,
            0});
			// 
			// label_StopPower
			// 
			labMcuADCBaseForm.label_StopPower.AutoSize = true;
			labMcuADCBaseForm.label_StopPower.Location = new System.Drawing.Point(8, 104);
			labMcuADCBaseForm.label_StopPower.Name = "label_StopPower";
			labMcuADCBaseForm.label_StopPower.Size = new System.Drawing.Size(53, 12);
			labMcuADCBaseForm.label_StopPower.TabIndex = 6;
			labMcuADCBaseForm.label_StopPower.Text = "终止电压";
			// 
			// numericUpDownPlus_StepPower
			// 
			labMcuADCBaseForm.numericUpDownPlus_StepPower.Location = new System.Drawing.Point(67, 75);
			labMcuADCBaseForm.numericUpDownPlus_StepPower.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			labMcuADCBaseForm.numericUpDownPlus_StepPower.Name = "numericUpDownPlus_StepPower";
			labMcuADCBaseForm.numericUpDownPlus_StepPower.Size = new System.Drawing.Size(64, 21);
			labMcuADCBaseForm.numericUpDownPlus_StepPower.TabIndex = 5;
			labMcuADCBaseForm.numericUpDownPlus_StepPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			labMcuADCBaseForm.numericUpDownPlus_StepPower.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
			// 
			// label_StepPower
			// 
			labMcuADCBaseForm.label_StepPower.AutoSize = true;
			labMcuADCBaseForm.label_StepPower.Location = new System.Drawing.Point(8, 77);
			labMcuADCBaseForm.label_StepPower.Name = "label_StepPower";
			labMcuADCBaseForm.label_StepPower.Size = new System.Drawing.Size(53, 12);
			labMcuADCBaseForm.label_StepPower.TabIndex = 4;
			labMcuADCBaseForm.label_StepPower.Text = "步进电压";
			// 
			// numericUpDownPlus_StartPower
			// 
			labMcuADCBaseForm.numericUpDownPlus_StartPower.Location = new System.Drawing.Point(67, 48);
			labMcuADCBaseForm.numericUpDownPlus_StartPower.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			labMcuADCBaseForm.numericUpDownPlus_StartPower.Name = "numericUpDownPlus_StartPower";
			labMcuADCBaseForm.numericUpDownPlus_StartPower.Size = new System.Drawing.Size(64, 21);
			labMcuADCBaseForm.numericUpDownPlus_StartPower.TabIndex = 3;
			labMcuADCBaseForm.numericUpDownPlus_StartPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label_StartPower
			// 
			labMcuADCBaseForm.label_StartPower.AutoSize = true;
			labMcuADCBaseForm.label_StartPower.Location = new System.Drawing.Point(8, 50);
			labMcuADCBaseForm.label_StartPower.Name = "label_StartPower";
			labMcuADCBaseForm.label_StartPower.Size = new System.Drawing.Size(53, 12);
			labMcuADCBaseForm.label_StartPower.TabIndex = 2;
			labMcuADCBaseForm.label_StartPower.Text = "起始电压";
			// 
			// numericUpDownPlus_DigitalPowerChannel
			// 
			labMcuADCBaseForm.numericUpDownPlus_DigitalPowerChannel.Location = new System.Drawing.Point(67, 21);
			labMcuADCBaseForm.numericUpDownPlus_DigitalPowerChannel.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			labMcuADCBaseForm.numericUpDownPlus_DigitalPowerChannel.Name = "numericUpDownPlus_DigitalPowerChannel";
			labMcuADCBaseForm.numericUpDownPlus_DigitalPowerChannel.Size = new System.Drawing.Size(64, 21);
			labMcuADCBaseForm.numericUpDownPlus_DigitalPowerChannel.TabIndex = 1;
			labMcuADCBaseForm.numericUpDownPlus_DigitalPowerChannel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label_DigitalPowerCH
			// 
			labMcuADCBaseForm.label_DigitalPowerCH.AutoSize = true;
			labMcuADCBaseForm.label_DigitalPowerCH.Location = new System.Drawing.Point(8, 23);
			labMcuADCBaseForm.label_DigitalPowerCH.Name = "label_DigitalPowerCH";
			labMcuADCBaseForm.label_DigitalPowerCH.Size = new System.Drawing.Size(53, 12);
			labMcuADCBaseForm.label_DigitalPowerCH.TabIndex = 0;
			labMcuADCBaseForm.label_DigitalPowerCH.Text = "电源通道";
			// 
			// panel_ADCChannel
			// 
			labMcuADCBaseForm.panel_ADCChannel.Controls.Add(labMcuADCBaseForm.label_SelectADCChannel);
			labMcuADCBaseForm.panel_ADCChannel.Controls.Add(labMcuADCBaseForm.comboBoxEx_SelectADCChannel);
			labMcuADCBaseForm.panel_ADCChannel.Controls.Add(labMcuADCBaseForm.button_WriteADCChannel);
			labMcuADCBaseForm.panel_ADCChannel.Controls.Add(labMcuADCBaseForm.button_ReadADCChannel);
			labMcuADCBaseForm.panel_ADCChannel.Location = new System.Drawing.Point(6, 128);
			labMcuADCBaseForm.panel_ADCChannel.Name = "panel_ADCChannel";
			labMcuADCBaseForm.panel_ADCChannel.Size = new System.Drawing.Size(299, 35);
			labMcuADCBaseForm.panel_ADCChannel.TabIndex = 5;
			// 
			// label_SelectADCChannel
			// 
			labMcuADCBaseForm.label_SelectADCChannel.AutoSize = true;
			labMcuADCBaseForm.label_SelectADCChannel.Location = new System.Drawing.Point(3, 10);
			labMcuADCBaseForm.label_SelectADCChannel.Name = "label_SelectADCChannel";
			labMcuADCBaseForm.label_SelectADCChannel.Size = new System.Drawing.Size(47, 12);
			labMcuADCBaseForm.label_SelectADCChannel.TabIndex = 13;
			labMcuADCBaseForm.label_SelectADCChannel.Text = "ADC通道";
			// 
			// comboBoxEx_SelectADCChannel
			// 
			labMcuADCBaseForm.comboBoxEx_SelectADCChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			labMcuADCBaseForm.comboBoxEx_SelectADCChannel.FormattingEnabled = true;
			labMcuADCBaseForm.comboBoxEx_SelectADCChannel.IntegralHeight = false;
			labMcuADCBaseForm.comboBoxEx_SelectADCChannel.Items.AddRange(new object[] {
            "设定电压",
            "设定电流",
            "读取电压",
            "读取电流"});
			labMcuADCBaseForm.comboBoxEx_SelectADCChannel.Location = new System.Drawing.Point(62, 7);
			labMcuADCBaseForm.comboBoxEx_SelectADCChannel.Name = "comboBoxEx_SelectADCChannel";
			labMcuADCBaseForm.comboBoxEx_SelectADCChannel.Size = new System.Drawing.Size(130, 20);
			labMcuADCBaseForm.comboBoxEx_SelectADCChannel.TabIndex = 12;
			// 
			// button_WriteADCChannel
			// 
			labMcuADCBaseForm.button_WriteADCChannel.Location = new System.Drawing.Point(249, 5);
			labMcuADCBaseForm.button_WriteADCChannel.Name = "button_WriteADCChannel";
			labMcuADCBaseForm.button_WriteADCChannel.Size = new System.Drawing.Size(45, 23);
			labMcuADCBaseForm.button_WriteADCChannel.TabIndex = 17;
			labMcuADCBaseForm.button_WriteADCChannel.Text = "设置";
			labMcuADCBaseForm.button_WriteADCChannel.UseVisualStyleBackColor = true;
			// 
			// button_ReadADCChannel
			// 
			labMcuADCBaseForm.button_ReadADCChannel.Location = new System.Drawing.Point(198, 5);
			labMcuADCBaseForm.button_ReadADCChannel.Name = "button_ReadADCChannel";
			labMcuADCBaseForm.button_ReadADCChannel.Size = new System.Drawing.Size(45, 23);
			labMcuADCBaseForm.button_ReadADCChannel.TabIndex = 16;
			labMcuADCBaseForm.button_ReadADCChannel.Text = "读取";
			labMcuADCBaseForm.button_ReadADCChannel.UseVisualStyleBackColor = true;
			// 
			// panel_ADCVREF
			// 
			labMcuADCBaseForm.panel_ADCVREF.Controls.Add(labMcuADCBaseForm.label_SelectADCVREF);
			labMcuADCBaseForm.panel_ADCVREF.Controls.Add(labMcuADCBaseForm.comboBoxEx_SelectADCVREFMode);
			labMcuADCBaseForm.panel_ADCVREF.Controls.Add(labMcuADCBaseForm.button_WriteADCVREFMode);
			labMcuADCBaseForm.panel_ADCVREF.Controls.Add(labMcuADCBaseForm.button_ReadADCVREFMode);
			labMcuADCBaseForm.panel_ADCVREF.Location = new System.Drawing.Point(6, 87);
			labMcuADCBaseForm.panel_ADCVREF.Name = "panel_ADCVREF";
			labMcuADCBaseForm.panel_ADCVREF.Size = new System.Drawing.Size(299, 35);
			labMcuADCBaseForm.panel_ADCVREF.TabIndex = 4;
			// 
			// label_SelectADCVREF
			// 
			labMcuADCBaseForm.label_SelectADCVREF.AutoSize = true;
			labMcuADCBaseForm.label_SelectADCVREF.Location = new System.Drawing.Point(3, 10);
			labMcuADCBaseForm.label_SelectADCVREF.Name = "label_SelectADCVREF";
			labMcuADCBaseForm.label_SelectADCVREF.Size = new System.Drawing.Size(53, 12);
			labMcuADCBaseForm.label_SelectADCVREF.TabIndex = 13;
			labMcuADCBaseForm.label_SelectADCVREF.Text = "参考电压";
			// 
			// comboBoxEx_SelectADCVREFMode
			// 
			labMcuADCBaseForm.comboBoxEx_SelectADCVREFMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			labMcuADCBaseForm.comboBoxEx_SelectADCVREFMode.FormattingEnabled = true;
			labMcuADCBaseForm.comboBoxEx_SelectADCVREFMode.Items.AddRange(new object[] {
            "设定电压",
            "设定电流",
            "读取电压",
            "读取电流"});
			labMcuADCBaseForm.comboBoxEx_SelectADCVREFMode.Location = new System.Drawing.Point(62, 7);
			labMcuADCBaseForm.comboBoxEx_SelectADCVREFMode.Name = "comboBoxEx_SelectADCVREFMode";
			labMcuADCBaseForm.comboBoxEx_SelectADCVREFMode.Size = new System.Drawing.Size(130, 20);
			labMcuADCBaseForm.comboBoxEx_SelectADCVREFMode.TabIndex = 12;
			// 
			// button_WriteADCVREFMode
			// 
			labMcuADCBaseForm.button_WriteADCVREFMode.Location = new System.Drawing.Point(249, 5);
			labMcuADCBaseForm.button_WriteADCVREFMode.Name = "button_WriteADCVREFMode";
			labMcuADCBaseForm.button_WriteADCVREFMode.Size = new System.Drawing.Size(45, 23);
			labMcuADCBaseForm.button_WriteADCVREFMode.TabIndex = 17;
			labMcuADCBaseForm.button_WriteADCVREFMode.Text = "设置";
			labMcuADCBaseForm.button_WriteADCVREFMode.UseVisualStyleBackColor = true;
			// 
			// button_ReadADCVREFMode
			// 
			labMcuADCBaseForm.button_ReadADCVREFMode.Location = new System.Drawing.Point(198, 5);
			labMcuADCBaseForm.button_ReadADCVREFMode.Name = "button_ReadADCVREFMode";
			labMcuADCBaseForm.button_ReadADCVREFMode.Size = new System.Drawing.Size(45, 23);
			labMcuADCBaseForm.button_ReadADCVREFMode.TabIndex = 16;
			labMcuADCBaseForm.button_ReadADCVREFMode.Text = "读取";
			labMcuADCBaseForm.button_ReadADCVREFMode.UseVisualStyleBackColor = true;
			// 
			// commSerialPortPlus_Device
			// 
			labMcuADCBaseForm.commSerialPortPlus_Device.Location = new System.Drawing.Point(6, 20);
			labMcuADCBaseForm.commSerialPortPlus_Device.m_COMM = null;
			labMcuADCBaseForm.commSerialPortPlus_Device.m_COMMBaudRate = 115200;
			labMcuADCBaseForm.commSerialPortPlus_Device.m_COMMForm = null;
			labMcuADCBaseForm.commSerialPortPlus_Device.m_COMMParam = commSerialPortParam3;
			labMcuADCBaseForm.commSerialPortPlus_Device.m_COMMRichTextBox = null;
			labMcuADCBaseForm.commSerialPortPlus_Device.m_COMMShowParamMenu = true;
			labMcuADCBaseForm.commSerialPortPlus_Device.Name = "commSerialPortPlus_Device";
			labMcuADCBaseForm.commSerialPortPlus_Device.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			labMcuADCBaseForm.commSerialPortPlus_Device.Size = new System.Drawing.Size(266, 61);
			labMcuADCBaseForm.commSerialPortPlus_Device.TabIndex = 0;
			// 
			// groupBox_ProgramDigitalPower
			// 
			labMcuADCBaseForm.groupBox_ProgramDigitalPower.Controls.Add(labMcuADCBaseForm.GPD3303Plus_DigitalPower);
			labMcuADCBaseForm.groupBox_ProgramDigitalPower.Location = new System.Drawing.Point(12, 12);
			labMcuADCBaseForm.groupBox_ProgramDigitalPower.Name = "groupBox_ProgramDigitalPower";
			labMcuADCBaseForm.groupBox_ProgramDigitalPower.Size = new System.Drawing.Size(313, 226);
			labMcuADCBaseForm.groupBox_ProgramDigitalPower.TabIndex = 3;
			labMcuADCBaseForm.groupBox_ProgramDigitalPower.TabStop = false;
			labMcuADCBaseForm.groupBox_ProgramDigitalPower.Text = "可编程电源";
			// 
			// GPD3303Plus_DigitalPower
			// 
			labMcuADCBaseForm.GPD3303Plus_DigitalPower.Location = new System.Drawing.Point(6, 20);
			labMcuADCBaseForm.GPD3303Plus_DigitalPower.m_COMM = null;
			labMcuADCBaseForm.GPD3303Plus_DigitalPower.m_COMMBaudRate = 115200;
			labMcuADCBaseForm.GPD3303Plus_DigitalPower.m_COMMForm = null;
			labMcuADCBaseForm.GPD3303Plus_DigitalPower.m_COMMParam = commSerialPortParam1;
			labMcuADCBaseForm.GPD3303Plus_DigitalPower.m_COMMRichTextBox = null;
			labMcuADCBaseForm.GPD3303Plus_DigitalPower.m_COMMShowParamMenu = true;
			labMcuADCBaseForm.GPD3303Plus_DigitalPower.Name = "GPD3303Plus_DigitalPower";
			labMcuADCBaseForm.GPD3303Plus_DigitalPower.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			labMcuADCBaseForm.GPD3303Plus_DigitalPower.Size = new System.Drawing.Size(296, 200);
			labMcuADCBaseForm.GPD3303Plus_DigitalPower.TabIndex = 4;
			// 
			// richTextBoxEx_Msg
			// 
			labMcuADCBaseForm.richTextBoxEx_Msg.Location = new System.Drawing.Point(331, 13);
			labMcuADCBaseForm.richTextBoxEx_Msg.Name = "richTextBoxEx_Msg";
			labMcuADCBaseForm.richTextBoxEx_Msg.Size = new System.Drawing.Size(447, 581);
			labMcuADCBaseForm.richTextBoxEx_Msg.TabIndex = 4;
			labMcuADCBaseForm.richTextBoxEx_Msg.Text = "";
			// 
			// LabMcuADCBaseForm
			// 
			labMcuADCBaseForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			labMcuADCBaseForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			labMcuADCBaseForm.AutoSize = true;
			labMcuADCBaseForm.ClientSize = new System.Drawing.Size(790, 599);
			labMcuADCBaseForm.Controls.Add(labMcuADCBaseForm.richTextBoxEx_Msg);
			labMcuADCBaseForm.Controls.Add(labMcuADCBaseForm.groupBox_ProgramDigitalPower);
			labMcuADCBaseForm.Controls.Add(labMcuADCBaseForm.groupBox_TestDevice);
			labMcuADCBaseForm.Name = "LabMcuADCBaseForm";
			labMcuADCBaseForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			labMcuADCBaseForm.Text = "LabMcuADCBaseForm";
			labMcuADCBaseForm.groupBox_TestDevice.ResumeLayout(false);
			labMcuADCBaseForm.panel_SampleNum.ResumeLayout(false);
			labMcuADCBaseForm.panel_SampleNum.PerformLayout();
			((System.ComponentModel.ISupportInitialize)labMcuADCBaseForm.numericUpDownPlus_SampleNum).EndInit();
			labMcuADCBaseForm.groupBox_ScanADCFunc.ResumeLayout(false);
			labMcuADCBaseForm.groupBox_ScanADCFunc.PerformLayout();
			((System.ComponentModel.ISupportInitialize)labMcuADCBaseForm.numericUpDownPlus_StopPower).EndInit();
			((System.ComponentModel.ISupportInitialize)labMcuADCBaseForm.numericUpDownPlus_StepPower).EndInit();
			((System.ComponentModel.ISupportInitialize)labMcuADCBaseForm.numericUpDownPlus_StartPower).EndInit();
			((System.ComponentModel.ISupportInitialize)labMcuADCBaseForm.numericUpDownPlus_DigitalPowerChannel).EndInit();
			labMcuADCBaseForm.panel_ADCChannel.ResumeLayout(false);
			labMcuADCBaseForm.panel_ADCChannel.PerformLayout();
			labMcuADCBaseForm.panel_ADCVREF.ResumeLayout(false);
			labMcuADCBaseForm.panel_ADCVREF.PerformLayout();
			labMcuADCBaseForm.groupBox_ProgramDigitalPower.ResumeLayout(false);
			labMcuADCBaseForm.ResumeLayout(false);

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
		public System.Windows.Forms.Panel panel_ADCVREF;
		public System.Windows.Forms.GroupBox groupBox_TestDevice;
		public System.Windows.Forms.Label label_SelectADCChannel;
		public System.Windows.Forms.Panel panel_SampleNum;
		public System.Windows.Forms.Panel panel_ADCChannel;
		public System.Windows.Forms.GroupBox groupBox_ScanADCFunc;
	}
}