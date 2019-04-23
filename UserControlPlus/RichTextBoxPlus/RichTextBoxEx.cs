
using Harry.LabUserControlPlus;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Harry.LabUserControlPlus
{
	/// <summary>
	/// 功能拓展
	/// </summary>
	public class RichTextBoxEx : RichTextBox
	{
		#region 变量定义

		/// <summary>
		///
		/// </summary>
		private ContextMenuStrip userContextMenuStrip = new ContextMenuStrip();
        
		#endregion 变量定义

		#region 构造函数

		/// <summary>
		///
		/// </summary>
		public RichTextBoxEx() : base()
		{
			//加载contextMenuTrip的子项---消息显示的清楚和
			ToolStripItem tsItem;
			this.ContextMenuStrip=this.userContextMenuStrip;

			//---添加清楚消息的功能
			tsItem= ContextMenuPlus.AddContextMenu("清除", this.userContextMenuStrip.Items, new EventHandler(this.Clear_Click));

			this.ContextMenuStrip.Width=64;
		}

		#endregion 构造函数

		#region 事件定义

		/// <summary>
		/// 删除操作
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Clear_Click(object sender, EventArgs e)
		{
			this.Clear();
        }

		#endregion 事件定义
	}
}