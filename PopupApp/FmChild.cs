using System;
using System.Windows.Forms;
using AhDung.WinForm.Controls;
using Harry.LabUserControlPlus;

namespace AhDung
{
    public partial class FmChild : Form
    {
		/// <summary>
		/// 右键功能按键
		/// </summary>
		private ContextMenuStrip usedContextMenuStrip = new ContextMenuStrip();

		private FmMDI OwnerOrParent
        {
            get
            {
                return (FmMDI)(IsMdiChild ? MdiParent : Owner);
            }
        }

        public FmChild()
        {
            InitializeComponent();

            this.AddCOMMSerialPortParam();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OwnerOrParent.PopupLayer(typeof(InputPopDemo), sender);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OwnerOrParent.PopupLayer(typeof(InputPopDemo), sender);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
			/*
            using (FloatLayerBase p = OwnerOrParent.CreateLayer(typeof(CalcPopDemo)))
            {
                if (p.ShowDialog(textBox1) != System.Windows.Forms.DialogResult.OK)
                { return; }

                textBox1.Text = ((CalcPopDemo)p).Result.ToString();
            }
			*/
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            if (label1.Tag != null) { return; }

            FloatLayerBase p = OwnerOrParent.CreateLayer(typeof(TipPopDemo));
            label1.Tag = p;
            p.VisibleChanged += (a, b) => { if (!((a as Control).Visible)) { label1.Tag = null; } };
            p.Show(label1, 0, label1.Height + 3);
        }

		public void COMMSerialPortParam_Click(object sender, EventArgs e)
		{
			//using (FloatLayerBase p = OwnerOrParent.CreateLayer(typeof(CalcPopDemo)))
			//{
			//	if (p.ShowDialog(textBox1) != System.Windows.Forms.DialogResult.OK)
			//	{ return; }

			//	textBox1.Text = ((CalcPopDemo)p).Result.ToString();
			//}
			FloatLayerBase p = new CalcPopDemo();
			if (p.ShowDialog(textBox1) != System.Windows.Forms.DialogResult.OK)
			{ return; }

			textBox1.Text = ((CalcPopDemo)p).Result.ToString();
		}


		/// <summary>
		/// 添加串口参数配置
		/// </summary>
		private void AddCOMMSerialPortParam()
		{

			//---添加右键菜单
			//加载contextMenuTrip的子项---消息显示的清楚和
			ToolStripItem tsItem;

			this.ContextMenuStrip = this.usedContextMenuStrip;

			//---添加清楚消息的功能
			tsItem = ContextMenuPlus.AddContextMenu("参数配置", this.usedContextMenuStrip.Items, new EventHandler(this.COMMSerialPortParam_Click));

			this.ContextMenuStrip.Width = 32;
		}


	}
}
