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
		public override COMMBasePort m_COMM
		{
			get
			{
				return base.m_COMM;
			}

			set
			{
				base.m_COMM = value;
			}
		}

		/// <summary>
		/// 端口参数信息
		/// </summary>
		public override COMMPortParam m_COMMParam
		{
			get
			{
				if (base.m_COMMParam == null)
				{
					base.m_COMMParam = new COMMUSBPortParam();
				}
				else
				{
					base.m_COMMParam.Init(0x2013, 0x03EB);
				}
				return base.m_COMMParam;
			}
			set
			{
				if (base.m_COMMParam==null)
				{
					base.m_COMMParam = new COMMUSBPortParam();
				}
				base.m_COMMParam = value;
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
			this.m_COMM = (COMMUSBPort)argCOMM;
			base.m_COMMRichTextBox = argRichTextBox;
		}

		#endregion

	}
}
