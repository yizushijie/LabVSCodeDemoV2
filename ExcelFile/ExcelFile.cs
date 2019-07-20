
using Microsoft.Office.Interop.Excel;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Harry.LabExcelFile
{
	public partial class ExcelFile
	{
		#region 变量定义
		/// <summary>
		/// 工作变量
		/// </summary>
		private Microsoft.Office.Interop.Excel.Application defaultExcel = null;
		
		/// <summary>
		/// 记录工作薄
		/// </summary>
		private _Workbook defaultCurrentBook;
		
		/// <summary>
		/// 记录工作表
		/// </summary>
		private _Worksheet defaultCurrentSheet;

		/// <summary>
		/// 使用的工作薄
		/// </summary>
		private Microsoft.Office.Interop.Excel.Range defaultWorkSheet = null;

		/// <summary>
		/// 当前行变量
		/// </summary>
		private int defaultCurrentRow = 2;

		/// <summary>
		/// 当前列变量
		/// </summary>
		private int defaultCurrentColumn = 1;

		/// <summary>
		/// 当前记录数
		/// </summary>
		private int defaultCurrentIndex = 0;


		/// <summary>
		/// 记录的行位置
		/// </summary>
		private int defaultRecordRow = 3;
		
		/// <summary>
		/// 记录的列位置
		/// </summary>
		private int defaultRecordColumn = 3;

		#endregion

		#region 属性定义

		#endregion

		#region 构造函数

		#endregion

		#region 公共函数

		public virtual void Init()
		{
			if (this.defaultExcel == null)
			{
				this.defaultExcel = new Microsoft.Office.Interop.Excel.Application();
				if (defaultExcel == null)
				{
					MessageBox.Show("Excel Don't Run !");
				}
				this.defaultExcel.Visible = true;
				this.defaultExcel.DisplayAlerts = false;
			}
			else
			{
				MessageBox.Show("There already Open an Excel Application !");
			}
		}


		/// <summary>
		/// 创建Excel文件
		/// </summary>
		/// <param name="FileName"></param>
		public virtual void CreateExcel(string FileName)
		{
			object Nothing = System.Reflection.Missing.Value;
			var app = new Microsoft.Office.Interop.Excel.Application();
			app.Visible = false;
			Workbook workbook = app.Workbooks.Add(Nothing);
			Worksheet worksheet = (Worksheet)workbook.Sheets[1];
			worksheet.Name = "Work";
		}

		/// <summary>
		/// 获得指定序号的列的名称;
		/// </summary>
		/// <param name="_list"></param>
		/// <returns></returns>
		public virtual string GetColumnName(int column)
		{
			column--;
			int i = column / 26;
			int j = column % 26;
			char _first = 'A';
			char _c1 = (char)(_first + i - 1);
			char _c2 = (char)(_first + j);
			if (i == 0)
				return (string.Format("{0}", _c2));
			else
				return (string.Format("{0}{1}", _c1, _c2));
		}

		/// <summary>
		/// 选择工作区和工作表;
		/// </summary>
		/// <param name="_select"></param>
		/// <returns></returns>
		public virtual string SelectWorkSheet(out Range _select)
		{
			this.defaultCurrentBook = this.defaultExcel.ActiveWorkbook;
			if (this.defaultCurrentBook == null)
			{
				MessageBox.Show("Please Open or New a Excel File!", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				_select = null;
				return "";
			}
			this.defaultCurrentSheet = (_Worksheet)this.defaultExcel.ActiveSheet;
			_select = (Range)this.defaultExcel.Selection;                //.ActiveCell;
			this.defaultCurrentRow = _select.Row;
			this.defaultCurrentColumn = _select.Column;
			string _return = this.defaultExcel.ActiveWindow.Caption + "->" + this.defaultCurrentSheet.Name + " ->("
				+ _select.Row.ToString() + "," + GetColumnName(_select.Column) + ")";
			return _return;
		}

		/// <summary>
		/// 在记录期间,如果用户试图关闭工作薄,则相应用户操作;
		/// </summary>
		/// <param name="Wb"></param>
		/// <param name="Cancel"></param>
		public virtual void Events_WorkbookBeforeClose(Workbook Wb, ref bool Cancel)
		{
			DialogResult _result = MessageBox.Show("You Ensure Close this Workbook during Working !", "Warning!!!",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
			if (_result == DialogResult.OK)
				Cancel = false;
			else
			{
				this.defaultExcel = null;
				Cancel = true;
			}
		}

		/// <summary>
		/// 保存工作表
		/// </summary>
		public virtual void SaveFile()
		{
			try
			{
				if (this.defaultExcel != null)
				{
					this.defaultCurrentBook.Save();
				}
			}
			catch (SystemException e)
			{
				MessageBox.Show(e.ToString());
			}
		}

		/// <summary>
		/// 退出
		/// </summary>
		public virtual void Quit()
		{
			if (this.defaultExcel != null)
			{
				this.defaultExcel.WorkbookBeforeClose -= new AppEvents_WorkbookBeforeCloseEventHandler(Events_WorkbookBeforeClose);
				this.defaultExcel.DisplayAlerts = true;
				this.defaultExcel = null;
				System.Runtime.InteropServices.Marshal.ReleaseComObject(this.defaultExcel);
				this.defaultExcel = null;
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void OpenExcel()
		{
			this.Init();
			this.defaultCurrentBook = this.defaultExcel.Workbooks.Add(true);
		}

		/// <summary>
		/// 选择工作薄;
		/// </summary>
		/// <returns>对应工作薄的工作表信息;</returns>
		public string SelectWorkBook()
		{
			if (this.defaultExcel != null)
			{
				string _return = this.SelectWorkSheet(out this.defaultWorkSheet);
				// 获取行数 ;
				this.defaultRecordRow = this.defaultWorkSheet.Row;
				// 获取列数 ;
				this.defaultRecordColumn = this.defaultWorkSheet.Column;
				return _return;
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 保存测试结果;
		/// </summary>
		/// <param name="_row">行信息</param>
		/// <param name="_col">列信息</param>
		/// <param name="_value">浮点型的数据</param>
		public void SaveResult(int _row, int _col, float _value)
		{
			if (this.defaultExcel != null)
			{
				_row += defaultRecordRow;
				_col += this.defaultRecordColumn;
				//选择数据位置;
				((Range)this.defaultCurrentSheet.Cells[_row, _col]).Select();
				//填写数据值;
				((Range)this.defaultCurrentSheet.Cells[_row, _col]).Value2 = _value;
			}
		}

		/// <summary>
		/// 保存数据;
		/// </summary>
		/// <param name="_row">行信息</param>
		/// <param name="_col">列信息</param>
		/// <param name="_value">字符序列信息</param>
		public void SaveResult(int _row, int _col, string _value)
		{
			if (this.defaultExcel != null)
			{
				_row += defaultRecordRow;
				_col += this.defaultRecordColumn;
				//选择数据位置;
				((Range)this.defaultCurrentSheet.Cells[_row, _col]).Select();
				//填写数据;
				((Range)this.defaultCurrentSheet.Cells[_row, _col]).Value2 = _value;
			}
		}

		/// <summary>
		/// 指定工作表保存信息;
		/// </summary>
		/// <param name="_booksheet">工作表</param>
		/// <param name="_row">行信息</param>
		/// <param name="_col">列信息</param>
		/// <param name="_value">数据信息</param>
		public void SaveResult(_Worksheet _booksheet, int _row, int _col, string _value)
		{
			if (this.defaultExcel != null)
			{
				_row += defaultRecordRow;
				_col += this.defaultRecordColumn;
				((_Worksheet)_booksheet).Activate();
				//((Excel.Range)this.CurrentSheet.Cells[_row,_col]).Select();
				((Range)_booksheet.Cells[_row, _col]).Select();
				((Range)_booksheet.Cells[_row, _col]).Value2 = _value;
			}
		}
		/// <summary>
		/// 指定工作表，指定宽度保存信息;
		/// </summary>
		/// <param name="_booksheet">工作表信息</param>
		/// <param name="_row">行信息</param>
		/// <param name="_col">列信息</param>
		/// <param name="_value">数据信息</param>
		/// <param name="width">宽度信息</param>
		public void SaveResult(_Worksheet _booksheet, int _row, int _col, string _value, int width)
		{
			if (this.defaultExcel != null)
			{
				_row += defaultRecordRow;
				_col += this.defaultRecordColumn;
				//((_Worksheet)_booksheet).Activate();
				_booksheet.Activate();
				//((Excel.Range)this.CurrentSheet.Cells[_row,_col]).Select();
				((Range)_booksheet.Cells[_row, _col]).Select();
				((Range)_booksheet.Cells[_row, _col]).Value2 = _value;
				((Range)_booksheet.Cells[_row, _col]).ColumnWidth = width;
			}
		}

		#endregion

		#region 私有函数


		#endregion
	}
}
