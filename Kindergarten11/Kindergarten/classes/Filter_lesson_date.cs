using System;

namespace Kindergarten
{
    internal class Filter_lesson_date
    {
        public static void Filter(DateTime date)
        {
            try
            {
                string sql = @"SELECT lessons.Kod_Lessons,group_kid.Name,staff.FIO, discipline.Name_dist,lessons.Date_lesson,lessons.Hlong_hour
								FROM lessons,group_kid,discipline,staff where lessons.Kod_Group = group_kid.Kod_Group AND lessons.Kod_Discipline = discipline.Kod_Discipline
								AND lessons.Kod_staff = staff.Kod_staff AND Kod_Group = '" + date.ToString("yy-MM-dd") + "';";

                DBConnection.mycommand.CommandText = sql;
                DBGet_lessons.dtLesson.Clear();
                DBConnection.msDataAdapter.Fill(DBGet_lessons.dtLesson);
            }
            catch
            {
            }
        }
    }
}