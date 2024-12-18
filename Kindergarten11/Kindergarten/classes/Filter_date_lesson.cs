﻿using System;

namespace Kindergarten
{
    internal class Filter_date_lesson
    {
        public static void Filter(DateTime start, DateTime end)
        {
            try
            {
                string sql = @"SELECT lessons.Kod_Lessons,group_kid.Name,staff.FIO, discipline.Name_dist,lessons.Date_lesson,lessons.Hlong_hour
								FROM lessons,group_kid,discipline,staff where lessons.Kod_Group = group_kid.Kod_Group AND lessons.Kod_Discipline = discipline.Kod_Discipline
								AND lessons.Kod_staff = staff.Kod_staff AND DATE(lessons.Date_lesson) BETWEEN '" + start.ToString("yy-MM-dd") + "' AND '" + end.ToString("yy-MM-dd") + "';";

                DBConnection.mycommand.CommandText = sql;
                DBGet_lessons.dtLesson.Clear();
                DBConnection.msDataAdapter.Fill(DBGet_lessons.dtLesson);

                object rezKod_p = DBConnection.mycommand.ExecuteScalar();

                if (rezKod_p != null)
                {
                }
                else
                {
                    string sql1 = @"SELECT lessons.Kod_Lessons,group_kid.Name,staff.FIO, discipline.Name_dist,lessons.Date_lesson,lessons.Hlong_hour
                                FROM lessons,group_kid,discipline,staff where lessons.Kod_Group = group_kid.Kod_Group AND lessons.Kod_Discipline = discipline.Kod_Discipline
                                AND lessons.Kod_staff = staff.Kod_staff;";

                    DBConnection.mycommand.CommandText = sql1;
                    DBGet_lessons.dtLesson.Clear();
                    DBConnection.msDataAdapter.Fill(DBGet_lessons.dtLesson);

                    System.Windows.Forms.MessageBox.Show("Записей не найдено", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных ", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}