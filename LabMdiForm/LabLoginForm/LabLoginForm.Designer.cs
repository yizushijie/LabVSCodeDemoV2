namespace Harry.LabMainForm
{
	partial class LabLoginForm
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
			this.groupBox_UserLogin = new System.Windows.Forms.GroupBox();
			this.textBox_UserPassword = new System.Windows.Forms.TextBox();
			this.textBox_UserName = new System.Windows.Forms.TextBox();
			this.label_UserPassword = new System.Windows.Forms.Label();
			this.label_UserName = new System.Windows.Forms.Label();
			this.button_Login = new System.Windows.Forms.Button();
			this.button_Logoff = new System.Windows.Forms.Button();
			this.groupBox_UserLogin.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox_UserLogin
			// 
			this.groupBox_UserLogin.Controls.Add(this.button_Logoff);
			this.groupBox_UserLogin.Controls.Add(this.button_Login);
			this.groupBox_UserLogin.Controls.Add(this.textBox_UserPassword);
			this.groupBox_UserLogin.Controls.Add(this.textBox_UserName);
			this.groupBox_UserLogin.Controls.Add(this.label_UserPassword);
			this.groupBox_UserLogin.Controls.Add(this.label_UserName);
			this.groupBox_UserLogin.Location = new System.Drawing.Point(138, 102);
			this.groupBox_UserLogin.Name = "groupBox_UserLogin";
			this.groupBox_UserLogin.Size = new System.Drawing.Size(221, 169);
			this.groupBox_UserLogin.TabIndex = 0;
			this.groupBox_UserLogin.TabStop = false;
			this.groupBox_UserLogin.Text = "用户登录";
			// 
			// textBox_UserPassword
			// 
			this.textBox_UserPassword.Location = new System.Drawing.Point(75, 78);
			this.textBox_UserPassword.Name = "textBox_UserPassword";
			this.textBox_UserPassword.Size = new System.Drawing.Size(100, 21);
			this.textBox_UserPassword.TabIndex = 3;
			this.textBox_UserPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox_UserName
			// 
			this.textBox_UserName.Location = new System.Drawing.Point(75, 39);
			this.textBox_UserName.Name = "textBox_UserName";
			this.textBox_UserName.Size = new System.Drawing.Size(100, 21);
			this.textBox_UserName.TabIndex = 2;
			this.textBox_UserName.Text = "Admin";
			this.textBox_UserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label_UserPassword
			// 
			this.label_UserPassword.AutoSize = true;
			this.label_UserPassword.Location = new System.Drawing.Point(34, 81);
			this.label_UserPassword.Name = "label_UserPassword";
			this.label_UserPassword.Size = new System.Drawing.Size(35, 12);
			this.label_UserPassword.TabIndex = 1;
			this.label_UserPassword.Text = "密 码";
			// 
			// label_UserName
			// 
			this.label_UserName.AutoSize = true;
			this.label_UserName.Location = new System.Drawing.Point(28, 42);
			this.label_UserName.Name = "label_UserName";
			this.label_UserName.Size = new System.Drawing.Size(41, 12);
			this.label_UserName.TabIndex = 0;
			this.label_UserName.Text = "用户名";
			// 
			// button_Login
			// 
			this.button_Login.Location = new System.Drawing.Point(30, 131);
			this.button_Login.Name = "button_Login";
			this.button_Login.Size = new System.Drawing.Size(75, 23);
			this.button_Login.TabIndex = 0;
			this.button_Login.Text = "登录";
			this.button_Login.UseVisualStyleBackColor = true;
			// 
			// button_Logoff
			// 
			this.button_Logoff.Location = new System.Drawing.Point(123, 131);
			this.button_Logoff.Name = "button_Logoff";
			this.button_Logoff.Size = new System.Drawing.Size(75, 23);
			this.button_Logoff.TabIndex = 5;
			this.button_Logoff.Text = "注销";
			this.button_Logoff.UseVisualStyleBackColor = true;
			// 
			// LabLoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 420);
			this.Controls.Add(this.groupBox_UserLogin);
			this.Name = "LabLoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "登录窗体";
			this.groupBox_UserLogin.ResumeLayout(false);
			this.groupBox_UserLogin.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox_UserLogin;
		private System.Windows.Forms.Label label_UserPassword;
		private System.Windows.Forms.Label label_UserName;
		private System.Windows.Forms.TextBox textBox_UserPassword;
		private System.Windows.Forms.TextBox textBox_UserName;
		private System.Windows.Forms.Button button_Logoff;
		private System.Windows.Forms.Button button_Login;
	}
}