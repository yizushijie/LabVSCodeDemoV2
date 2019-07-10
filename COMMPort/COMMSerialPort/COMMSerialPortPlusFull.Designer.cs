﻿namespace Harry.LabCOMMPort
{
	partial class COMMSerialPortPlusFull
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
			this.label_COMMPortBaudRate = new System.Windows.Forms.Label();
			this.comboBox_COMMBaudRate = new System.Windows.Forms.ComboBox();
			this.comboBox_COMMStopBits = new System.Windows.Forms.ComboBox();
			this.label_COMMPortStopBits = new System.Windows.Forms.Label();
			this.comboBox_COMMDataBits = new System.Windows.Forms.ComboBox();
			this.label_COMMPortDataBits = new System.Windows.Forms.Label();
			this.comboBox_COMMParity = new System.Windows.Forms.ComboBox();
			this.label_COMMPortParity = new System.Windows.Forms.Label();
			this.panel_COMMName.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMM)).BeginInit();
			this.panel_COMM.SuspendLayout();
			this.groupBox_COMM.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel_COMMPortName
			// 
			this.panel_COMMName.Controls.Add(this.comboBox_COMMParity);
			this.panel_COMMName.Controls.Add(this.label_COMMPortParity);
			this.panel_COMMName.Controls.Add(this.comboBox_COMMDataBits);
			this.panel_COMMName.Controls.Add(this.label_COMMPortDataBits);
			this.panel_COMMName.Controls.Add(this.comboBox_COMMStopBits);
			this.panel_COMMName.Controls.Add(this.label_COMMPortStopBits);
			this.panel_COMMName.Controls.Add(this.comboBox_COMMBaudRate);
			this.panel_COMMName.Controls.Add(this.label_COMMPortBaudRate);
			this.panel_COMMName.Location = new System.Drawing.Point(5, 23);
			this.panel_COMMName.Margin = new System.Windows.Forms.Padding(5);
			this.panel_COMMName.Size = new System.Drawing.Size(189, 199);
			this.panel_COMMName.Controls.SetChildIndex(this.comboBox_COMM, 0);
			this.panel_COMMName.Controls.SetChildIndex(this.button_COMM, 0);
			this.panel_COMMName.Controls.SetChildIndex(this.pictureBox_COMM, 0);
			this.panel_COMMName.Controls.SetChildIndex(this.label_COMMPortBaudRate, 0);
			this.panel_COMMName.Controls.SetChildIndex(this.comboBox_COMMBaudRate, 0);
			this.panel_COMMName.Controls.SetChildIndex(this.label_COMMPortStopBits, 0);
			this.panel_COMMName.Controls.SetChildIndex(this.comboBox_COMMStopBits, 0);
			this.panel_COMMName.Controls.SetChildIndex(this.label_COMMPortDataBits, 0);
			this.panel_COMMName.Controls.SetChildIndex(this.comboBox_COMMDataBits, 0);
			this.panel_COMMName.Controls.SetChildIndex(this.label_COMMPortParity, 0);
			this.panel_COMMName.Controls.SetChildIndex(this.comboBox_COMMParity, 0);
			// 
			// pictureBox_COMMState
			// 
			this.pictureBox_COMM.Location = new System.Drawing.Point(25, 169);
			this.pictureBox_COMM.Margin = new System.Windows.Forms.Padding(5);
			// 
			// button_COMMInit
			// 
			this.button_COMM.Location = new System.Drawing.Point(76, 169);
			this.button_COMM.Margin = new System.Windows.Forms.Padding(5);
			this.button_COMM.Size = new System.Drawing.Size(109, 31);
			this.button_COMM.Text = "配置设备";
			// 
			// panel_COMM
			// 
			this.panel_COMM.Margin = new System.Windows.Forms.Padding(5);
			this.panel_COMM.Padding = new System.Windows.Forms.Padding(5);
			this.panel_COMM.Size = new System.Drawing.Size(209, 237);
			// 
			// groupBox_COMMName
			// 
			this.groupBox_COMM.Location = new System.Drawing.Point(5, 5);
			this.groupBox_COMM.Margin = new System.Windows.Forms.Padding(5);
			this.groupBox_COMM.Padding = new System.Windows.Forms.Padding(5);
			this.groupBox_COMM.Size = new System.Drawing.Size(199, 227);
			// 
			// label_COMMPortBaudRate
			// 
			this.label_COMMPortBaudRate.AutoSize = true;
			this.label_COMMPortBaudRate.Location = new System.Drawing.Point(8, 42);
			this.label_COMMPortBaudRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label_COMMPortBaudRate.Name = "label_COMMPortBaudRate";
			this.label_COMMPortBaudRate.Size = new System.Drawing.Size(60, 15);
			this.label_COMMPortBaudRate.TabIndex = 4;
			this.label_COMMPortBaudRate.Tag = "";
			this.label_COMMPortBaudRate.Text = "波特率:";
			// 
			// comboBox_COMMPortBaudRate
			// 
			this.comboBox_COMMBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_COMMBaudRate.FormattingEnabled = true;
			this.comboBox_COMMBaudRate.IntegralHeight = false;
			this.comboBox_COMMBaudRate.Items.AddRange(new object[] {
            "自定义",
            "1382400",
            "921600",
            "460800",
            "256000",
            "230400",
            "128000",
            "115200",
            "76800",
            "57600",
            "43000",
            "38400",
            "19200",
            "9600",
            "4800",
            "2400",
            "1200"});
			this.comboBox_COMMBaudRate.Location = new System.Drawing.Point(76, 39);
			this.comboBox_COMMBaudRate.Margin = new System.Windows.Forms.Padding(4);
			this.comboBox_COMMBaudRate.Name = "comboBox_COMMPortBaudRate";
			this.comboBox_COMMBaudRate.Size = new System.Drawing.Size(109, 23);
			this.comboBox_COMMBaudRate.TabIndex = 5;
			// 
			// comboBox_COMMPortStopBits
			// 
			this.comboBox_COMMStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_COMMStopBits.FormattingEnabled = true;
			this.comboBox_COMMStopBits.IntegralHeight = false;
			this.comboBox_COMMStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
			this.comboBox_COMMStopBits.Location = new System.Drawing.Point(76, 71);
			this.comboBox_COMMStopBits.Margin = new System.Windows.Forms.Padding(4);
			this.comboBox_COMMStopBits.Name = "comboBox_COMMPortStopBits";
			this.comboBox_COMMStopBits.Size = new System.Drawing.Size(109, 23);
			this.comboBox_COMMStopBits.TabIndex = 7;
			// 
			// label_COMMPortStopBits
			// 
			this.label_COMMPortStopBits.AutoSize = true;
			this.label_COMMPortStopBits.Location = new System.Drawing.Point(8, 75);
			this.label_COMMPortStopBits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label_COMMPortStopBits.Name = "label_COMMPortStopBits";
			this.label_COMMPortStopBits.Size = new System.Drawing.Size(60, 15);
			this.label_COMMPortStopBits.TabIndex = 6;
			this.label_COMMPortStopBits.Tag = "";
			this.label_COMMPortStopBits.Text = "停止位:";
			// 
			// comboBox_COMMPortDataBits
			// 
			this.comboBox_COMMDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_COMMDataBits.FormattingEnabled = true;
			this.comboBox_COMMDataBits.IntegralHeight = false;
			this.comboBox_COMMDataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
			this.comboBox_COMMDataBits.Location = new System.Drawing.Point(76, 104);
			this.comboBox_COMMDataBits.Margin = new System.Windows.Forms.Padding(4);
			this.comboBox_COMMDataBits.Name = "comboBox_COMMPortDataBits";
			this.comboBox_COMMDataBits.Size = new System.Drawing.Size(109, 23);
			this.comboBox_COMMDataBits.TabIndex = 9;
			// 
			// label_COMMPortDataBits
			// 
			this.label_COMMPortDataBits.AutoSize = true;
			this.label_COMMPortDataBits.Location = new System.Drawing.Point(8, 108);
			this.label_COMMPortDataBits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label_COMMPortDataBits.Name = "label_COMMPortDataBits";
			this.label_COMMPortDataBits.Size = new System.Drawing.Size(60, 15);
			this.label_COMMPortDataBits.TabIndex = 8;
			this.label_COMMPortDataBits.Tag = "";
			this.label_COMMPortDataBits.Text = "数据位:";
			// 
			// comboBox_COMMPortParity
			// 
			this.comboBox_COMMParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_COMMParity.FormattingEnabled = true;
			this.comboBox_COMMParity.IntegralHeight = false;
			this.comboBox_COMMParity.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
			this.comboBox_COMMParity.Location = new System.Drawing.Point(76, 136);
			this.comboBox_COMMParity.Margin = new System.Windows.Forms.Padding(4);
			this.comboBox_COMMParity.Name = "comboBox_COMMPortParity";
			this.comboBox_COMMParity.Size = new System.Drawing.Size(109, 23);
			this.comboBox_COMMParity.TabIndex = 11;
			// 
			// label_COMMPortParity
			// 
			this.label_COMMPortParity.AutoSize = true;
			this.label_COMMPortParity.Location = new System.Drawing.Point(8, 140);
			this.label_COMMPortParity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label_COMMPortParity.Name = "label_COMMPortParity";
			this.label_COMMPortParity.Size = new System.Drawing.Size(60, 15);
			this.label_COMMPortParity.TabIndex = 10;
			this.label_COMMPortParity.Tag = "";
			this.label_COMMPortParity.Text = "校验位:";
			// 
			// COMMSerialPortPlusFull
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "COMMSerialPortPlusFull";
			this.Size = new System.Drawing.Size(209, 239);
			this.panel_COMMName.ResumeLayout(false);
			this.panel_COMMName.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMM)).EndInit();
			this.panel_COMM.ResumeLayout(false);
			this.groupBox_COMM.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox_COMMBaudRate;
		private System.Windows.Forms.Label label_COMMPortBaudRate;
		private System.Windows.Forms.ComboBox comboBox_COMMParity;
		private System.Windows.Forms.Label label_COMMPortParity;
		private System.Windows.Forms.ComboBox comboBox_COMMDataBits;
		private System.Windows.Forms.Label label_COMMPortDataBits;
		private System.Windows.Forms.ComboBox comboBox_COMMStopBits;
		private System.Windows.Forms.Label label_COMMPortStopBits;
	}
}
