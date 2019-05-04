using Harry.LabUserControlPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Harry.LabPreMakeToVSProject
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
		static void Main(string[] arg)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (arg.Count()>0)
			{
                string str = null;
                for (int i = 0; i < arg.Length; i++)
                {
                    str += arg[i].ToString();
                }
                //MessageBox.Show(str);
                Application.Run(new PreMakeToVSProjectForm(str));
			}
			else
			{
				Application.Run(new PreMakeToVSProjectForm());
			}
			
		}
	}
}
