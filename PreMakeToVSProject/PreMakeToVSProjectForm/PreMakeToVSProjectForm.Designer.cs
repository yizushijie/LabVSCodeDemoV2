namespace Harry.LabPreMakeToVSProject
{
	partial class PreMakeToVSProjectForm
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

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.TextBox_SrcProjectPath = new System.Windows.Forms.TextBox();
			this.button_SelectSrcProject = new System.Windows.Forms.Button();
			this.label_SrcProjectName = new System.Windows.Forms.Label();
			this.label_SrcProjectVersion = new System.Windows.Forms.Label();
			this.comboBox_SrcProjectVersion = new System.Windows.Forms.ComboBox();
			this.label_VisualStudioProjectVersion = new System.Windows.Forms.Label();
			this.comboBox_VisualStudioVersion = new System.Windows.Forms.ComboBox();
			this.button_ToVisualProject = new System.Windows.Forms.Button();
			this.checkBox_CloseApplication = new System.Windows.Forms.CheckBox();
			this.checkBox_OpenVSProject = new System.Windows.Forms.CheckBox();
			this.groupBox_DesProject = new System.Windows.Forms.GroupBox();
			this.groupBox_SrcProject = new System.Windows.Forms.GroupBox();
			this.groupBox_DesProject.SuspendLayout();
			this.groupBox_SrcProject.SuspendLayout();
			this.SuspendLayout();
			// 
			// TextBox_SrcProjectPath
			// 
			this.TextBox_SrcProjectPath.Location = new System.Drawing.Point(87, 25);
			this.TextBox_SrcProjectPath.Margin = new System.Windows.Forms.Padding(4);
			this.TextBox_SrcProjectPath.Name = "TextBox_SrcProjectPath";
			this.TextBox_SrcProjectPath.Size = new System.Drawing.Size(393, 25);
			this.TextBox_SrcProjectPath.TabIndex = 2;
			// 
			// button_SelectSrcProject
			// 
			this.button_SelectSrcProject.Location = new System.Drawing.Point(494, 21);
			this.button_SelectSrcProject.Margin = new System.Windows.Forms.Padding(4);
			this.button_SelectSrcProject.Name = "button_SelectSrcProject";
			this.button_SelectSrcProject.Size = new System.Drawing.Size(100, 29);
			this.button_SelectSrcProject.TabIndex = 3;
			this.button_SelectSrcProject.Text = "选择项目";
			this.button_SelectSrcProject.UseVisualStyleBackColor = true;
			// 
			// label_SrcProjectName
			// 
			this.label_SrcProjectName.AutoSize = true;
			this.label_SrcProjectName.Location = new System.Drawing.Point(12, 28);
			this.label_SrcProjectName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label_SrcProjectName.Name = "label_SrcProjectName";
			this.label_SrcProjectName.Size = new System.Drawing.Size(67, 15);
			this.label_SrcProjectName.TabIndex = 4;
			this.label_SrcProjectName.Text = "项目名称";
			// 
			// label_SrcProjectVersion
			// 
			this.label_SrcProjectVersion.AutoSize = true;
			this.label_SrcProjectVersion.Location = new System.Drawing.Point(16, 32);
			this.label_SrcProjectVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label_SrcProjectVersion.Name = "label_SrcProjectVersion";
			this.label_SrcProjectVersion.Size = new System.Drawing.Size(91, 15);
			this.label_SrcProjectVersion.TabIndex = 5;
			this.label_SrcProjectVersion.Text = "项目工程IDE";
			// 
			// comboBox_SrcProjectVersion
			// 
			this.comboBox_SrcProjectVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_SrcProjectVersion.FormattingEnabled = true;
			this.comboBox_SrcProjectVersion.Items.AddRange(new object[] {
            "Keil",
            "IAR"});
			this.comboBox_SrcProjectVersion.Location = new System.Drawing.Point(15, 51);
			this.comboBox_SrcProjectVersion.Margin = new System.Windows.Forms.Padding(4);
			this.comboBox_SrcProjectVersion.Name = "comboBox_SrcProjectVersion";
			this.comboBox_SrcProjectVersion.Size = new System.Drawing.Size(92, 23);
			this.comboBox_SrcProjectVersion.TabIndex = 6;
			// 
			// label_VisualStudioProjectVersion
			// 
			this.label_VisualStudioProjectVersion.AutoSize = true;
			this.label_VisualStudioProjectVersion.Location = new System.Drawing.Point(130, 32);
			this.label_VisualStudioProjectVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label_VisualStudioProjectVersion.Name = "label_VisualStudioProjectVersion";
			this.label_VisualStudioProjectVersion.Size = new System.Drawing.Size(103, 15);
			this.label_VisualStudioProjectVersion.TabIndex = 7;
			this.label_VisualStudioProjectVersion.Text = "VisualStudio";
			// 
			// comboBox_VisualStudioVersion
			// 
			this.comboBox_VisualStudioVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_VisualStudioVersion.FormattingEnabled = true;
			this.comboBox_VisualStudioVersion.Items.AddRange(new object[] {
            "vs2019",
            "vs2017",
            "vs2015",
            "vs2013",
            "vs2012",
            "vs2010",
            "vs2008",
            "vs2005"});
			this.comboBox_VisualStudioVersion.Location = new System.Drawing.Point(133, 51);
			this.comboBox_VisualStudioVersion.Margin = new System.Windows.Forms.Padding(4);
			this.comboBox_VisualStudioVersion.Name = "comboBox_VisualStudioVersion";
			this.comboBox_VisualStudioVersion.Size = new System.Drawing.Size(100, 23);
			this.comboBox_VisualStudioVersion.TabIndex = 8;
			// 
			// button_ToVisualProject
			// 
			this.button_ToVisualProject.Location = new System.Drawing.Point(494, 28);
			this.button_ToVisualProject.Margin = new System.Windows.Forms.Padding(4);
			this.button_ToVisualProject.Name = "button_ToVisualProject";
			this.button_ToVisualProject.Size = new System.Drawing.Size(100, 29);
			this.button_ToVisualProject.TabIndex = 9;
			this.button_ToVisualProject.Text = "工程转换";
			this.button_ToVisualProject.UseVisualStyleBackColor = true;
			// 
			// checkBox_CloseApplication
			// 
			this.checkBox_CloseApplication.AutoSize = true;
			this.checkBox_CloseApplication.Checked = true;
			this.checkBox_CloseApplication.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_CloseApplication.Location = new System.Drawing.Point(256, 28);
			this.checkBox_CloseApplication.Margin = new System.Windows.Forms.Padding(4);
			this.checkBox_CloseApplication.Name = "checkBox_CloseApplication";
			this.checkBox_CloseApplication.Size = new System.Drawing.Size(119, 19);
			this.checkBox_CloseApplication.TabIndex = 10;
			this.checkBox_CloseApplication.Text = "自动关闭应用";
			this.checkBox_CloseApplication.UseVisualStyleBackColor = true;
			// 
			// checkBox_OpenVSProject
			// 
			this.checkBox_OpenVSProject.AutoSize = true;
			this.checkBox_OpenVSProject.Location = new System.Drawing.Point(256, 55);
			this.checkBox_OpenVSProject.Margin = new System.Windows.Forms.Padding(4);
			this.checkBox_OpenVSProject.Name = "checkBox_OpenVSProject";
			this.checkBox_OpenVSProject.Size = new System.Drawing.Size(105, 19);
			this.checkBox_OpenVSProject.TabIndex = 11;
			this.checkBox_OpenVSProject.Text = "打开VS工程";
			this.checkBox_OpenVSProject.UseVisualStyleBackColor = true;
			// 
			// groupBox_DesProject
			// 
			this.groupBox_DesProject.Controls.Add(this.comboBox_SrcProjectVersion);
			this.groupBox_DesProject.Controls.Add(this.label_SrcProjectVersion);
			this.groupBox_DesProject.Controls.Add(this.comboBox_VisualStudioVersion);
			this.groupBox_DesProject.Controls.Add(this.label_VisualStudioProjectVersion);
			this.groupBox_DesProject.Controls.Add(this.button_ToVisualProject);
			this.groupBox_DesProject.Controls.Add(this.checkBox_OpenVSProject);
			this.groupBox_DesProject.Controls.Add(this.checkBox_CloseApplication);
			this.groupBox_DesProject.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_DesProject.Location = new System.Drawing.Point(0, 75);
			this.groupBox_DesProject.Name = "groupBox_DesProject";
			this.groupBox_DesProject.Size = new System.Drawing.Size(601, 86);
			this.groupBox_DesProject.TabIndex = 15;
			this.groupBox_DesProject.TabStop = false;
			this.groupBox_DesProject.Text = "工程转换";
			// 
			// groupBox_SrcProject
			// 
			this.groupBox_SrcProject.Controls.Add(this.label_SrcProjectName);
			this.groupBox_SrcProject.Controls.Add(this.TextBox_SrcProjectPath);
			this.groupBox_SrcProject.Controls.Add(this.button_SelectSrcProject);
			this.groupBox_SrcProject.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_SrcProject.Location = new System.Drawing.Point(0, 8);
			this.groupBox_SrcProject.Name = "groupBox_SrcProject";
			this.groupBox_SrcProject.Size = new System.Drawing.Size(601, 67);
			this.groupBox_SrcProject.TabIndex = 14;
			this.groupBox_SrcProject.TabStop = false;
			this.groupBox_SrcProject.Text = "项目工程";
			// 
			// PreMakeToVSProjectForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(601, 168);
			this.Controls.Add(this.groupBox_DesProject);
			this.Controls.Add(this.groupBox_SrcProject);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "PreMakeToVSProjectForm";
			this.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "创建VisualStudio工程";
			this.groupBox_DesProject.ResumeLayout(false);
			this.groupBox_DesProject.PerformLayout();
			this.groupBox_SrcProject.ResumeLayout(false);
			this.groupBox_SrcProject.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox TextBox_SrcProjectPath;
		private System.Windows.Forms.Button button_SelectSrcProject;
		private System.Windows.Forms.Label label_SrcProjectName;
		private System.Windows.Forms.Label label_SrcProjectVersion;
		private System.Windows.Forms.ComboBox comboBox_SrcProjectVersion;
		private System.Windows.Forms.Label label_VisualStudioProjectVersion;
		private System.Windows.Forms.ComboBox comboBox_VisualStudioVersion;
		private System.Windows.Forms.Button button_ToVisualProject;
		private System.Windows.Forms.CheckBox checkBox_CloseApplication;
		private System.Windows.Forms.CheckBox checkBox_OpenVSProject;
		private System.Windows.Forms.GroupBox groupBox_DesProject;
		private System.Windows.Forms.GroupBox groupBox_SrcProject;
	}
}

