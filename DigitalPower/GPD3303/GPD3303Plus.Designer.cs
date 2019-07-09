namespace Harry.LabDigitalPower
{
	partial class GPD3303Plus
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
			Harry.LabCOMMPort.COMMSerialPortParam commSerialPortParam1 = new Harry.LabCOMMPort.COMMSerialPortParam();
			this.groupBox_PowerCH1 = new System.Windows.Forms.GroupBox();
			this.label_CH1Mode = new System.Windows.Forms.Label();
			this.comboBoxEx_CH1Mode = new Harry.LabUserControlPlus.ComboBoxEx();
			this.button_WriteCH1 = new System.Windows.Forms.Button();
			this.button_ReadCH1 = new System.Windows.Forms.Button();
			this.label_CH1CurrentUnite = new System.Windows.Forms.Label();
			this.numericUpDownPlus_CH1Current = new Harry.LabUserControlPlus.NumericUpDownPlus();
			this.label_CH1Current = new System.Windows.Forms.Label();
			this.label_CH1VoltageUnite = new System.Windows.Forms.Label();
			this.numericUpDownPlus_CH1Voltage = new Harry.LabUserControlPlus.NumericUpDownPlus();
			this.label_CH1Voltage = new System.Windows.Forms.Label();
			this.groupBox_CH2 = new System.Windows.Forms.GroupBox();
			this.label_CH2Mode = new System.Windows.Forms.Label();
			this.button_WriteCH2 = new System.Windows.Forms.Button();
			this.comboBoxEx_CH2Mode = new Harry.LabUserControlPlus.ComboBoxEx();
			this.button_ReadCH2 = new System.Windows.Forms.Button();
			this.label_CH2CurrentUnite = new System.Windows.Forms.Label();
			this.numericUpDownPlus_CH2Current = new Harry.LabUserControlPlus.NumericUpDownPlus();
			this.label_CH2Current = new System.Windows.Forms.Label();
			this.label_CH2VoltageUnite = new System.Windows.Forms.Label();
			this.numericUpDownPlus_CH2Voltage = new Harry.LabUserControlPlus.NumericUpDownPlus();
			this.label_CH2Voltage = new System.Windows.Forms.Label();
			this.panel_COMMName.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMMState)).BeginInit();
			this.panel_COMM.SuspendLayout();
			this.groupBox_COMMName.SuspendLayout();
			this.groupBox_PowerCH1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_CH1Current)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_CH1Voltage)).BeginInit();
			this.groupBox_CH2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_CH2Current)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_CH2Voltage)).BeginInit();
			this.SuspendLayout();
			// 
			// panel_COMMName
			// 
			this.panel_COMMName.Controls.Add(this.groupBox_CH2);
			this.panel_COMMName.Controls.Add(this.groupBox_PowerCH1);
			this.panel_COMMName.Size = new System.Drawing.Size(284, 172);
			this.panel_COMMName.Controls.SetChildIndex(this.groupBox_PowerCH1, 0);
			this.panel_COMMName.Controls.SetChildIndex(this.comboBox_COMMName, 0);
			this.panel_COMMName.Controls.SetChildIndex(this.button_COMMInit, 0);
			this.panel_COMMName.Controls.SetChildIndex(this.pictureBox_COMMState, 0);
			this.panel_COMMName.Controls.SetChildIndex(this.groupBox_CH2, 0);
			// 
			// button_COMMInit
			// 
			this.button_COMMInit.Location = new System.Drawing.Point(187, 2);
			// 
			// panel_COMM
			// 
			this.panel_COMM.Size = new System.Drawing.Size(296, 198);
			// 
			// groupBox_COMMName
			// 
			this.groupBox_COMMName.Size = new System.Drawing.Size(290, 192);
			// 
			// groupBox_PowerCH1
			// 
			this.groupBox_PowerCH1.Controls.Add(this.label_CH1Mode);
			this.groupBox_PowerCH1.Controls.Add(this.comboBoxEx_CH1Mode);
			this.groupBox_PowerCH1.Controls.Add(this.button_WriteCH1);
			this.groupBox_PowerCH1.Controls.Add(this.button_ReadCH1);
			this.groupBox_PowerCH1.Controls.Add(this.label_CH1CurrentUnite);
			this.groupBox_PowerCH1.Controls.Add(this.numericUpDownPlus_CH1Current);
			this.groupBox_PowerCH1.Controls.Add(this.label_CH1Current);
			this.groupBox_PowerCH1.Controls.Add(this.label_CH1VoltageUnite);
			this.groupBox_PowerCH1.Controls.Add(this.numericUpDownPlus_CH1Voltage);
			this.groupBox_PowerCH1.Controls.Add(this.label_CH1Voltage);
			this.groupBox_PowerCH1.Location = new System.Drawing.Point(8, 34);
			this.groupBox_PowerCH1.Name = "groupBox_PowerCH1";
			this.groupBox_PowerCH1.Size = new System.Drawing.Size(132, 135);
			this.groupBox_PowerCH1.TabIndex = 4;
			this.groupBox_PowerCH1.TabStop = false;
			this.groupBox_PowerCH1.Text = "通道1";
			// 
			// label_CH1Mode
			// 
			this.label_CH1Mode.AutoSize = true;
			this.label_CH1Mode.Location = new System.Drawing.Point(6, 77);
			this.label_CH1Mode.Name = "label_CH1Mode";
			this.label_CH1Mode.Size = new System.Drawing.Size(29, 12);
			this.label_CH1Mode.TabIndex = 11;
			this.label_CH1Mode.Text = "模式";
			// 
			// comboBoxEx_CH1Mode
			// 
			this.comboBoxEx_CH1Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEx_CH1Mode.FormattingEnabled = true;
			this.comboBoxEx_CH1Mode.Items.AddRange(new object[] {
            "设定电压",
            "设定电流",
            "读取电压",
            "读取电流",
            "打开输出",
            "关闭输出"});
			this.comboBoxEx_CH1Mode.Location = new System.Drawing.Point(41, 74);
			this.comboBoxEx_CH1Mode.Name = "comboBoxEx_CH1Mode";
			this.comboBoxEx_CH1Mode.Size = new System.Drawing.Size(82, 20);
			this.comboBoxEx_CH1Mode.TabIndex = 10;
			// 
			// button_WriteCH1
			// 
			this.button_WriteCH1.Location = new System.Drawing.Point(73, 103);
			this.button_WriteCH1.Name = "button_WriteCH1";
			this.button_WriteCH1.Size = new System.Drawing.Size(50, 23);
			this.button_WriteCH1.TabIndex = 8;
			this.button_WriteCH1.Text = "设置";
			this.button_WriteCH1.UseVisualStyleBackColor = true;
			// 
			// button_ReadCH1
			// 
			this.button_ReadCH1.Location = new System.Drawing.Point(8, 103);
			this.button_ReadCH1.Name = "button_ReadCH1";
			this.button_ReadCH1.Size = new System.Drawing.Size(50, 23);
			this.button_ReadCH1.TabIndex = 7;
			this.button_ReadCH1.Text = "读取";
			this.button_ReadCH1.UseVisualStyleBackColor = true;
			// 
			// label_CH1CurrentUnite
			// 
			this.label_CH1CurrentUnite.AutoSize = true;
			this.label_CH1CurrentUnite.Location = new System.Drawing.Point(112, 49);
			this.label_CH1CurrentUnite.Name = "label_CH1CurrentUnite";
			this.label_CH1CurrentUnite.Size = new System.Drawing.Size(11, 12);
			this.label_CH1CurrentUnite.TabIndex = 5;
			this.label_CH1CurrentUnite.Text = "A";
			// 
			// numericUpDownPlus_CH1Current
			// 
			this.numericUpDownPlus_CH1Current.DecimalPlaces = 3;
			this.numericUpDownPlus_CH1Current.Location = new System.Drawing.Point(41, 47);
			this.numericUpDownPlus_CH1Current.Name = "numericUpDownPlus_CH1Current";
			this.numericUpDownPlus_CH1Current.Size = new System.Drawing.Size(65, 21);
			this.numericUpDownPlus_CH1Current.TabIndex = 4;
			this.numericUpDownPlus_CH1Current.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label_CH1Current
			// 
			this.label_CH1Current.AutoSize = true;
			this.label_CH1Current.Location = new System.Drawing.Point(6, 49);
			this.label_CH1Current.Name = "label_CH1Current";
			this.label_CH1Current.Size = new System.Drawing.Size(29, 12);
			this.label_CH1Current.TabIndex = 3;
			this.label_CH1Current.Text = "电流";
			// 
			// label_CH1VoltageUnite
			// 
			this.label_CH1VoltageUnite.AutoSize = true;
			this.label_CH1VoltageUnite.Location = new System.Drawing.Point(112, 22);
			this.label_CH1VoltageUnite.Name = "label_CH1VoltageUnite";
			this.label_CH1VoltageUnite.Size = new System.Drawing.Size(11, 12);
			this.label_CH1VoltageUnite.TabIndex = 2;
			this.label_CH1VoltageUnite.Text = "V";
			// 
			// numericUpDownPlus_CH1Voltage
			// 
			this.numericUpDownPlus_CH1Voltage.DecimalPlaces = 3;
			this.numericUpDownPlus_CH1Voltage.Location = new System.Drawing.Point(41, 20);
			this.numericUpDownPlus_CH1Voltage.Name = "numericUpDownPlus_CH1Voltage";
			this.numericUpDownPlus_CH1Voltage.Size = new System.Drawing.Size(65, 21);
			this.numericUpDownPlus_CH1Voltage.TabIndex = 1;
			this.numericUpDownPlus_CH1Voltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label_CH1Voltage
			// 
			this.label_CH1Voltage.AutoSize = true;
			this.label_CH1Voltage.Location = new System.Drawing.Point(6, 22);
			this.label_CH1Voltage.Name = "label_CH1Voltage";
			this.label_CH1Voltage.Size = new System.Drawing.Size(29, 12);
			this.label_CH1Voltage.TabIndex = 0;
			this.label_CH1Voltage.Text = "电压";
			// 
			// groupBox_CH2
			// 
			this.groupBox_CH2.Controls.Add(this.label_CH2Mode);
			this.groupBox_CH2.Controls.Add(this.button_WriteCH2);
			this.groupBox_CH2.Controls.Add(this.comboBoxEx_CH2Mode);
			this.groupBox_CH2.Controls.Add(this.button_ReadCH2);
			this.groupBox_CH2.Controls.Add(this.label_CH2CurrentUnite);
			this.groupBox_CH2.Controls.Add(this.numericUpDownPlus_CH2Current);
			this.groupBox_CH2.Controls.Add(this.label_CH2Current);
			this.groupBox_CH2.Controls.Add(this.label_CH2VoltageUnite);
			this.groupBox_CH2.Controls.Add(this.numericUpDownPlus_CH2Voltage);
			this.groupBox_CH2.Controls.Add(this.label_CH2Voltage);
			this.groupBox_CH2.Location = new System.Drawing.Point(146, 34);
			this.groupBox_CH2.Name = "groupBox_CH2";
			this.groupBox_CH2.Size = new System.Drawing.Size(132, 135);
			this.groupBox_CH2.TabIndex = 5;
			this.groupBox_CH2.TabStop = false;
			this.groupBox_CH2.Text = "通道2";
			// 
			// label_CH2Mode
			// 
			this.label_CH2Mode.AutoSize = true;
			this.label_CH2Mode.Location = new System.Drawing.Point(6, 77);
			this.label_CH2Mode.Name = "label_CH2Mode";
			this.label_CH2Mode.Size = new System.Drawing.Size(29, 12);
			this.label_CH2Mode.TabIndex = 13;
			this.label_CH2Mode.Text = "模式";
			// 
			// button_WriteCH2
			// 
			this.button_WriteCH2.Location = new System.Drawing.Point(73, 103);
			this.button_WriteCH2.Name = "button_WriteCH2";
			this.button_WriteCH2.Size = new System.Drawing.Size(50, 23);
			this.button_WriteCH2.TabIndex = 9;
			this.button_WriteCH2.Text = "设置";
			this.button_WriteCH2.UseVisualStyleBackColor = true;
			// 
			// comboBoxEx_CH2Mode
			// 
			this.comboBoxEx_CH2Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEx_CH2Mode.FormattingEnabled = true;
			this.comboBoxEx_CH2Mode.Items.AddRange(new object[] {
            "设定电压",
            "设定电流",
            "读取电压",
            "读取电流",
            "打开输出",
            "关闭输出"});
			this.comboBoxEx_CH2Mode.Location = new System.Drawing.Point(41, 74);
			this.comboBoxEx_CH2Mode.Name = "comboBoxEx_CH2Mode";
			this.comboBoxEx_CH2Mode.Size = new System.Drawing.Size(82, 20);
			this.comboBoxEx_CH2Mode.TabIndex = 12;
			// 
			// button_ReadCH2
			// 
			this.button_ReadCH2.Location = new System.Drawing.Point(8, 103);
			this.button_ReadCH2.Name = "button_ReadCH2";
			this.button_ReadCH2.Size = new System.Drawing.Size(50, 23);
			this.button_ReadCH2.TabIndex = 8;
			this.button_ReadCH2.Text = "读取";
			this.button_ReadCH2.UseVisualStyleBackColor = true;
			// 
			// label_CH2CurrentUnite
			// 
			this.label_CH2CurrentUnite.AutoSize = true;
			this.label_CH2CurrentUnite.Location = new System.Drawing.Point(112, 47);
			this.label_CH2CurrentUnite.Name = "label_CH2CurrentUnite";
			this.label_CH2CurrentUnite.Size = new System.Drawing.Size(11, 12);
			this.label_CH2CurrentUnite.TabIndex = 5;
			this.label_CH2CurrentUnite.Text = "A";
			// 
			// numericUpDownPlus_CH2Current
			// 
			this.numericUpDownPlus_CH2Current.DecimalPlaces = 3;
			this.numericUpDownPlus_CH2Current.Location = new System.Drawing.Point(41, 47);
			this.numericUpDownPlus_CH2Current.Name = "numericUpDownPlus_CH2Current";
			this.numericUpDownPlus_CH2Current.Size = new System.Drawing.Size(65, 21);
			this.numericUpDownPlus_CH2Current.TabIndex = 4;
			this.numericUpDownPlus_CH2Current.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label_CH2Current
			// 
			this.label_CH2Current.AutoSize = true;
			this.label_CH2Current.Location = new System.Drawing.Point(6, 49);
			this.label_CH2Current.Name = "label_CH2Current";
			this.label_CH2Current.Size = new System.Drawing.Size(29, 12);
			this.label_CH2Current.TabIndex = 3;
			this.label_CH2Current.Text = "电流";
			// 
			// label_CH2VoltageUnite
			// 
			this.label_CH2VoltageUnite.AutoSize = true;
			this.label_CH2VoltageUnite.Location = new System.Drawing.Point(112, 22);
			this.label_CH2VoltageUnite.Name = "label_CH2VoltageUnite";
			this.label_CH2VoltageUnite.Size = new System.Drawing.Size(11, 12);
			this.label_CH2VoltageUnite.TabIndex = 2;
			this.label_CH2VoltageUnite.Text = "V";
			// 
			// numericUpDownPlus_CH2Voltage
			// 
			this.numericUpDownPlus_CH2Voltage.DecimalPlaces = 3;
			this.numericUpDownPlus_CH2Voltage.Location = new System.Drawing.Point(41, 20);
			this.numericUpDownPlus_CH2Voltage.Name = "numericUpDownPlus_CH2Voltage";
			this.numericUpDownPlus_CH2Voltage.Size = new System.Drawing.Size(65, 21);
			this.numericUpDownPlus_CH2Voltage.TabIndex = 1;
			this.numericUpDownPlus_CH2Voltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label_CH2Voltage
			// 
			this.label_CH2Voltage.AutoSize = true;
			this.label_CH2Voltage.Location = new System.Drawing.Point(6, 22);
			this.label_CH2Voltage.Name = "label_CH2Voltage";
			this.label_CH2Voltage.Size = new System.Drawing.Size(29, 12);
			this.label_CH2Voltage.TabIndex = 0;
			this.label_CH2Voltage.Text = "电压";
			// 
			// GPD3303Plus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.m_COMMPortParam = commSerialPortParam1;
			this.Name = "GPD3303Plus";
			this.Size = new System.Drawing.Size(296, 200);
			this.panel_COMMName.ResumeLayout(false);
			this.panel_COMMName.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMMState)).EndInit();
			this.panel_COMM.ResumeLayout(false);
			this.groupBox_COMMName.ResumeLayout(false);
			this.groupBox_PowerCH1.ResumeLayout(false);
			this.groupBox_PowerCH1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_CH1Current)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_CH1Voltage)).EndInit();
			this.groupBox_CH2.ResumeLayout(false);
			this.groupBox_CH2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_CH2Current)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlus_CH2Voltage)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox groupBox_PowerCH1;
		private System.Windows.Forms.Label label_CH1VoltageUnite;
		private LabUserControlPlus.NumericUpDownPlus numericUpDownPlus_CH1Voltage;
		private System.Windows.Forms.Label label_CH1Voltage;
		private System.Windows.Forms.Label label_CH1CurrentUnite;
		private LabUserControlPlus.NumericUpDownPlus numericUpDownPlus_CH1Current;
		private System.Windows.Forms.Label label_CH1Current;
		private System.Windows.Forms.GroupBox groupBox_CH2;
		private System.Windows.Forms.Label label_CH2CurrentUnite;
		private LabUserControlPlus.NumericUpDownPlus numericUpDownPlus_CH2Current;
		private System.Windows.Forms.Label label_CH2Current;
		private System.Windows.Forms.Label label_CH2VoltageUnite;
		private LabUserControlPlus.NumericUpDownPlus numericUpDownPlus_CH2Voltage;
		private System.Windows.Forms.Label label_CH2Voltage;
		private System.Windows.Forms.Button button_WriteCH1;
		private System.Windows.Forms.Button button_ReadCH1;
		private System.Windows.Forms.Button button_WriteCH2;
		private System.Windows.Forms.Button button_ReadCH2;
		private System.Windows.Forms.Label label_CH2Mode;
		private LabUserControlPlus.ComboBoxEx comboBoxEx_CH2Mode;
		private System.Windows.Forms.Label label_CH1Mode;
		public LabUserControlPlus.ComboBoxEx comboBoxEx_CH1Mode;
	}
}
