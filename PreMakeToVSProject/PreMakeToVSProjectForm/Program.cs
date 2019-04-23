using System;
using System.Collections.Generic;
using System.Linq;
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
				Application.Run(new PreMakeToVSProjectForm(arg[0]));
			}
			else
			{
				Application.Run(new PreMakeToVSProjectForm());
			}
			
		}
	}
}
