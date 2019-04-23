using Harry.LabUserGenFunc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Harry.LabPreMakeToVSProject
{
    public partial class PreMakeToVSProjectForm : Form
    {

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public PreMakeToVSProjectForm()
		{
			InitializeComponent();
			this.Init();
		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="path"></param>
		public PreMakeToVSProjectForm(string path)
		{
			InitializeComponent();
			this.Init();
			this.TextBox_SrcProjectPath.Text = path;
		}

		#region 公共函数


		/// <summary>
		/// 按键点击事件处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void button_Click(object sender, EventArgs e)
		{
			Button bt = (Button)sender;
			bt.Enabled = false;
			bool _return = true;
			switch (bt.Text)
			{
				case "选择项目":
					this.TextBox_SrcProjectPath.Text = new ProjectFunc().GetPathAndProjectVersion(this.comboBox_SrcProjectVersion.Text);
					if ((this.TextBox_SrcProjectPath.Text == string.Empty) || (this.TextBox_SrcProjectPath.Text == null))
					{
						_return = false;
					}
					break;

				case "工程转换":
					_return = new ProjectFunc().ManageToVSProject(this.TextBox_SrcProjectPath.Text, this.comboBox_SrcProjectVersion.Text);
					if (_return)
					{
						_return = this.UsePreMakeToVsProject();
						if (_return)
						{
							if (this.checkBox_CloseApplication.Checked)
							{
								Application.Exit();
							}
						}
					}
					break;

				default:
					break;
			}
			bt.Enabled = true;
		}
		/// <summary>
		/// 使用PreMaKe创建VS项目
		/// </summary>
		/// <returns></returns>
		private bool UsePreMakeToVsProject()
		{
			string vsPath = null;
			if (this.comboBox_SrcProjectVersion.Text == "IAR")
			{
				vsPath = Path.GetDirectoryName(this.TextBox_SrcProjectPath.Text);

				//vsPath = Directory.GetParent(Path.GetDirectoryName(this.TextBox_SrcPath.Text)).FullName;
			}
			else if (this.comboBox_SrcProjectVersion.Text == "Keil")
			{
				vsPath = Path.GetDirectoryName(this.TextBox_SrcProjectPath.Text);

				//vsPath = Directory.GetParent(Path.GetDirectoryName(this.TextBox_SrcPath.Text)).FullName;
			}
			else
			{
				return false;
			}

			//---启动进程
			Process proc = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = @"Resources\premake5.exe",

					//Arguments = "--File=\"" + Path.GetDirectoryName(this.TextBox_SrcPath.Text) + "\\premake5.lua\" " + this.comboBox_VSVersion.Text,
					Arguments = "--File=\"" + vsPath + "\\premake5.lua\" " + this.comboBox_VisualStudioVersion.Text,
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true
				}
			};

			//---启动应用
			proc.Start();
			string makeOut = proc.StandardOutput.ReadToEnd();

			//---创建VS工程
			if (proc.ExitCode == 0)
			{
				MessageBox.Show(makeOut, @"Make output");

				//---创建VS工程
				if (this.comboBox_VisualStudioVersion.Text.Contains("vs"))
				{
					if (this.checkBox_OpenVSProject.Checked)
					{
						DialogResult dialogResult = MessageBox.Show(@"Open Project ?", Text, MessageBoxButtons.YesNo);
						if (dialogResult == DialogResult.Yes)
						{
							ProcessStartInfo psi = new ProcessStartInfo(Path.ChangeExtension(this.TextBox_SrcProjectPath.Text, "sln"));

							//ProcessStartInfo psi = new ProcessStartInfo(Path.ChangeExtension(vsPath, "sln"));
							//{
							//	UseShellExecute = true
							//};
							Process.Start(psi);
						}
					}
				}
			}
			else
			{
				MessageBox.Show(makeOut, @"Make output", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return true;
		}

		#endregion

		#region 私有函数

		/// <summary>
		/// 
		/// </summary>
		private void Init()
		{
			this.comboBox_SrcProjectVersion.SelectedIndex = 0;
			this.comboBox_VisualStudioVersion.SelectedIndex = 0;
			this.button_SelectSrcProject.Click += new System.EventHandler(this.button_Click);
			this.button_ToVisualProject.Click += new System.EventHandler(this.button_Click);
		}

		#endregion

	}
}
