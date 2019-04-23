namespace Harry.LabCOMMPort
{
	partial class COMMBasePortPlus
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COMMBasePortPlus));
			this.groupBox_COMMName = new System.Windows.Forms.GroupBox();
			this.panel_COMMName = new System.Windows.Forms.Panel();
			this.button_COMMInit = new System.Windows.Forms.Button();
			this.label_COMMName = new System.Windows.Forms.Label();
			this.comboBox_COMMName = new System.Windows.Forms.ComboBox();
			this.panel_COMM = new System.Windows.Forms.Panel();
			this.pictureBox_COMMState = new System.Windows.Forms.PictureBox();
			this.groupBox_COMMName.SuspendLayout();
			this.panel_COMMName.SuspendLayout();
			this.panel_COMM.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMMState)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox_COMMName
			// 
			this.groupBox_COMMName.Controls.Add(this.panel_COMMName);
			resources.ApplyResources(this.groupBox_COMMName, "groupBox_COMMName");
			this.groupBox_COMMName.Name = "groupBox_COMMName";
			this.groupBox_COMMName.TabStop = false;
			// 
			// panel_COMMPortName
			// 
			this.panel_COMMName.Controls.Add(this.pictureBox_COMMState);
			this.panel_COMMName.Controls.Add(this.button_COMMInit);
			this.panel_COMMName.Controls.Add(this.label_COMMName);
			this.panel_COMMName.Controls.Add(this.comboBox_COMMName);
			resources.ApplyResources(this.panel_COMMName, "panel_COMMPortName");
			this.panel_COMMName.Name = "panel_COMMPortName";
			// 
			// button_COMMInit
			// 
			resources.ApplyResources(this.button_COMMInit, "button_COMMInit");
			this.button_COMMInit.Name = "button_COMMInit";
			this.button_COMMInit.UseVisualStyleBackColor = true;
			// 
			// label_COMMName
			// 
			resources.ApplyResources(this.label_COMMName, "label_COMMName");
			this.label_COMMName.Name = "label_COMMName";
			// 
			// comboBox_COMMName
			// 
			this.comboBox_COMMName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_COMMName.FormattingEnabled = true;
			resources.ApplyResources(this.comboBox_COMMName, "comboBox_COMMName");
			this.comboBox_COMMName.Name = "comboBox_COMMName";
			// 
			// panel_COMM
			// 
			this.panel_COMM.Controls.Add(this.groupBox_COMMName);
			resources.ApplyResources(this.panel_COMM, "panel_COMM");
			this.panel_COMM.Name = "panel_COMM";
			// 
			// pictureBox_COMMState
			// 
			resources.ApplyResources(this.pictureBox_COMMState, "pictureBox_COMMState");
			this.pictureBox_COMMState.Name = "pictureBox_COMMState";
			this.pictureBox_COMMState.TabStop = false;
			this.pictureBox_COMMState.Tag = "1";
			// 
			// COMMBasePortPlus
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel_COMM);
			this.Name = "COMMBasePortPlus";
			this.groupBox_COMMName.ResumeLayout(false);
			this.panel_COMMName.ResumeLayout(false);
			this.panel_COMMName.PerformLayout();
			this.panel_COMM.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMMState)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label_COMMName;
		public System.Windows.Forms.Panel panel_COMMName;
		public System.Windows.Forms.PictureBox pictureBox_COMMState;
		public System.Windows.Forms.Button button_COMMInit;
		public System.Windows.Forms.Panel panel_COMM;
		public System.Windows.Forms.ComboBox comboBox_COMMName;
		public System.Windows.Forms.GroupBox groupBox_COMMName;
	}
}
