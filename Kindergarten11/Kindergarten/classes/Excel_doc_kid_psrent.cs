using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Kindergarten
{
    internal class Excel_doc_kid_psrent
    {
        public static Excel.Application xlApp;

        //Лист
        public static Excel.Worksheet xlSheet;

        //Выделеная область
        public static Excel.Range xlSheetRange;

        public static DataTable dtgroup = new DataTable();

        public static void SqlToExcels()
        {
            xlApp = new Excel.Application();
            try
            {
                xlApp.Workbooks.Add(Type.Missing);

                xlApp.Interactive = false;
                xlApp.EnableEvents = false;

                xlSheet = (Excel.Worksheet)xlApp.Sheets[1];
                xlSheet.Name = "Список выбранной группы";

                Excel.Range _excelCells1 = (Excel.Range)xlSheet.get_Range("A1", "A3").Cells;
                // Производим объединение
                _excelCells1.Merge(Type.Missing);
                xlSheet.Cells[1, 3] = @"Детский сад" + "\r\n" + "'Зебра'";

                Excel.Range excelCells = xlSheet.Range[xlSheet.Cells[1, 1], xlSheet.Cells[1, 1]];
                xlSheet.Cells[1, 1] = @"Детский сад" + "\r\n" + "'Зебра'";

                Excel.Range excelCells1 = xlSheet.Range[xlSheet.Cells[1, 2], xlSheet.Cells[1, 2]];
                xlSheet.Cells[1, 2] = @"Дата создания документа: ";

                Excel.Range excelCells2 = xlSheet.Range[xlSheet.Cells[1, 3], xlSheet.Cells[1, 3]];
                xlSheet.Cells[1, 3] = DateTime.Now.ToShortDateString();

                Excel.Range excelCells3 = xlSheet.Range[xlSheet.Cells[2, 2], xlSheet.Cells[2, 2]];
                xlSheet.Cells[2, 2] = @"Документ сформирован: ";

                Excel.Range excelCells4 = xlSheet.Range[xlSheet.Cells[2, 3], xlSheet.Cells[2, 3]];
                xlSheet.Cells[2, 3] = DBAuthorization.fio;

                xlSheet.Cells.get_Range("A5", "Z5").ColumnWidth = 50;

                excelCells2.Merge(Type.Missing);

                excelCells.Cells.Font.Bold = true;
                excelCells.Cells.Font.Size = 18;
                excelCells.Font.Italic = true;

                excelCells1.Cells.Font.Bold = true;
                excelCells1.Cells.Font.Size = 14;
                excelCells1.Font.Italic = true;
                excelCells1.Font.Color = ColorTranslator.ToOle(Color.MidnightBlue);

                excelCells2.Cells.Font.Size = 12;
                excelCells2.Font.Italic = true;
                excelCells4.Cells.Font.Size = 12;
                excelCells4.Font.Italic = true;

                excelCells3.Cells.Font.Bold = true;
                excelCells3.Cells.Font.Size = 14;
                excelCells3.Font.Italic = true;
                excelCells3.Font.Color = ColorTranslator.ToOle(Color.MidnightBlue);

                GetGroup();

                int collInd = 0;
                int rowInd;
                string data = "";

                for (int i = 0; i < dtgroup.Columns.Count; i++)
                {
                    data = dtgroup.Columns[i].ColumnName.ToString();
                    xlSheet.Cells[5, i + 1] = data;

                    xlSheetRange = xlSheet.get_Range("A5:Z5", Type.Missing);
                    xlSheetRange.Font.Color = ColorTranslator.ToOle(Color.MidnightBlue);
                    xlSheetRange.Font.Size = 12;
                    xlSheetRange.Font.Bold = true;
                    xlSheetRange.WrapText = true;
                    xlSheetRange.Font.Bold = true;
                }

                for (rowInd = 0; rowInd < dtgroup.Rows.Count; rowInd++)
                {
                    for (collInd = 0; collInd < dtgroup.Columns.Count; collInd++)
                    {
                        data = dtgroup.Rows[rowInd].ItemArray[collInd].ToString();
                        xlSheet.Cells[rowInd + 6, collInd + 1] = data;
                    }
                }
                xlSheetRange = xlSheet.UsedRange;

                xlSheetRange.Columns.AutoFit();
                xlSheetRange.Rows.AutoFit();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка формирования таблицы", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            finally
            {
                string path = Directory.GetCurrentDirectory();
                xlSheet.SaveAs(path + @"\Список детей, имеющих одного родителя в семье.xlsx");
                System.Windows.Forms.MessageBox.Show("Данные сохранены в xlsx-файле", "Готово", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                xlApp.Interactive = true;
                xlApp.ScreenUpdating = true;
                xlApp.UserControl = true;
                xlApp.Workbooks.Close();
                xlApp.Quit();
                Process[] ps2 = System.Diagnostics.Process.GetProcessesByName("EXCEL");
                foreach (Process p2 in ps2)
                {
                    p2.Kill();
                }
            }
        }

        public static bool GetGroup()
        {
            try
            {
                string sql = @"SELECT concat(kid.Name,' ',kid.Surname,' ',kid.Patronymic) AS 'ФИО ребенка' ,
								concat(parents.Name_dad,' ',parents.Surname_dad,' ',parents.Patronymic_dad)AS 'ФИО отца',
								concat(parents.Name_mom,' ',parents.Surname_mom,' ',parents.Patronymic_mom) AS 'ФИО матери',
								parents.Place_of_work_dad AS 'Место работы отца',
								parents.Place_of_work_mom AS 'Место работы матери',
								parents.Telephone_dad AS 'Телефон отца',
								parents.Telephone_mom AS 'Телефон матери'
								FROM kid,parents where kid.Kod_p =parents.Kod_p AND parents.Number_of_parents=1;";

                DBConnection.mycommand.CommandText = sql;

                object rez = DBConnection.mycommand.ExecuteScalar();
                if (rez != null)
                {
                    Object result = DBConnection.mycommand.ExecuteScalar();
                    dtgroup.Clear();
                    DBConnection.msDataAdapter.Fill(dtgroup);
                    return true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Записей не найдено", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return false;
                }
            }
            catch
            {
                return false;
                System.Windows.Forms.MessageBox.Show("Ошибка при получении списка клиентов!", "Ошибка", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}