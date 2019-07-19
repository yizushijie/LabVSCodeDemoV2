using System;
using System.Windows.Forms;

namespace Harry.LabMainForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new LabLoginForm());
			LabLoginForm frmLogin = new LabLoginForm();
			if (frmLogin.ShowDialog() == DialogResult.OK)
			{
				Application.Run(new LabMdiForm());
			}
		}
    }
}
