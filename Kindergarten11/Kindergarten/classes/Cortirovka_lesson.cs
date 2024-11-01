namespace Kindergarten
{
    internal class Cortirovka_lesson
    {
        public static void Filter(int des_asc)
        {
            try
            {
                if (des_asc == 0)
                {
                    string sql = @"SELECT lessons.Kod_Lessons,group_kid.Name,staff.FIO, discipline.Name_dist,lessons.Date_lesson,lessons.Hlong_hour
								FROM lessons,group_kid,discipline,staff where lessons.Kod_Group = group_kid.Kod_Group AND lessons.Kod_Discipline = discipline.Kod_Discipline
								AND lessons.Kod_staff = staff.Kod_staff  order by staff.FIO DESC ;";

                    DBConnection.mycommand.CommandText = sql;
                    DBGet_lessons.dtLesson.Clear();
                    DBConnection.msDataAdapter.Fill(DBGet_lessons.dtLesson);
                }
                else
                {
                    if (des_asc == 1)
                    {
                        string sql = @"SELECT lessons.Kod_Lessons,group_kid.Name,staff.FIO, discipline.Name_dist,lessons.Date_lesson,lessons.Hlong_hour
								FROM lessons,group_kid,discipline,staff where lessons.Kod_Group = group_kid.Kod_Group AND lessons.Kod_Discipline = discipline.Kod_Discipline
								AND lessons.Kod_staff = staff.Kod_staff  order by staff.FIO ASC ;";

                        DBConnection.mycommand.CommandText = sql;
                        DBGet_lessons.dtLesson.Clear();
                        DBConnection.msDataAdapter.Fill(DBGet_lessons.dtLesson);
                    }
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных ", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}