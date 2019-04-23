using Harry.LabCOMMPort;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		private COMMBasePort usedPort = null;
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.usedPort = new COMMSerialPort();
			this.commSerialPortPlus1.Init(this, this.usedPort, this.richTextBoxEx1, true, true);
		}
	}
}
