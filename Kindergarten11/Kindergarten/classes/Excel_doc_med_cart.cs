using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Kindergarten
{
    internal class Excel_doc_med_cart
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

                //xlSheet.Cells[1, 1] = Properties.Resources.
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

                Excel.Range excelCells5 = xlSheet.Range[xlSheet.Cells[3, 2], xlSheet.Cells[3, 2]];
                xlSheet.Cells[3, 2] = @"Группа: ";

                Excel.Range excelCells6 = xlSheet.Range[xlSheet.Cells[3, 3], xlSheet.Cells[3, 3]];
                xlSheet.Cells[3, 3] = Doc_group_med_cart.Group_med_cart;

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
                excelCells6.Cells.Font.Size = 12;
                excelCells6.Font.Italic = true;

                excelCells3.Cells.Font.Bold = true;
                excelCells3.Cells.Font.Size = 14;
                excelCells3.Font.Italic = true;
                excelCells3.Font.Color = ColorTranslator.ToOle(Color.MidnightBlue);

                excelCells5.Cells.Font.Bold = true;
                excelCells5.Cells.Font.Size = 14;
                excelCells5.Font.Italic = true;
                excelCells5.Font.Color = ColorTranslator.ToOle(Color.MidnightBlue);

                GetGroup(Doc_group_med_cart.Group_med_cart);

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
                xlSheet.SaveAs(path + @"\Список детей выбранной группы имеющих хроническое заболевание.xlsx");
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

        public static bool GetGroup(string Group)
        {
            try
            {
                string sql = @"SELECT concat(kid.Name,' ',kid.Surname,' ',kid.Patronymic) AS 'ФИО ребенка',medical_card.Chronic_diseases AS 'Хронические заболевания'  FROM kid,group_kid,medical_card,health_group
								where kid.Kod_Group = group_kid.Kod_Group AND  medical_card.Birth_certificate_nomber =kid.Birth_certificate_nomber
								AND health_group.Kod_health_group =medical_card.Kod_health_group AND
								group_kid.Name = '" + Group + "' AND  health_group.Group=3;";
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