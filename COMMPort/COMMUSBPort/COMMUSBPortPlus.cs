using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabCOMMPort
{
	public partial class COMMUSBPortPlus : COMMBasePortPlus
	{
		#region 属性定义

		/// <summary>
		/// 
		/// </summary>
		public override COMMBasePort m_COMMPort
		{
			get
			{
				return base.m_COMMPort;
			}

			set
			{
				base.m_COMMPort = value;
			}
		}

		#endregion

		#region 构造函数
		/// <summary>
		/// 
		/// </summary>
		public COMMUSBPortPlus():base()
		{
			InitializeComponent();
			base.Init();
		}
		/// <summary>
		/// 
		/// </summary>
		public COMMUSBPortPlus(Form argForm)
		{
			InitializeComponent();

			base.Init(argForm);
		}
		/// <summary>
		/// 
		/// </summary>
		public COMMUSBPortPlus(RichTextBox argRichTextBox)
		{
			InitializeComponent();

			base.Init(argRichTextBox);
		}
		/// <summary>
		/// 
		/// </summary>
		public COMMUSBPortPlus(Form argForm, RichTextBox argRichTextBox)
		{
			InitializeComponent();

			base.Init(argForm,argRichTextBox);
		}

		/// <summary>
		/// 
		/// </summary>
		public COMMUSBPortPlus(Form argForm, COMMBasePort argCOMM, RichTextBox argRichTextBox)
		{
			InitializeComponent();
			this.Init(argForm, argCOMM, argRichTextBox);
		}

		#endregion

		#region 函数定义

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		/// <param name="argCOMM"></param>
		/// <param name="argComboBox"></param>
		/// <param name="argRichTextBox"></param>
		public override void Init(Form argForm, COMMBasePort argCOMM,RichTextBox argRichTextBox)
		{
			base.m_COMMForm = argForm;
			this.m_COMMPort = (COMMUSBPort)argCOMM;
			base.m_COMMRichTextBox = argRichTextBox;
		}

		#endregion

	}
}
