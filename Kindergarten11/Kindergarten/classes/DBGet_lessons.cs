using System.Data;

namespace Kindergarten
{
    internal class DBGet_lessons
    {
        public static DataTable dtLesson = new DataTable();

        public static void Get()
        {
            try
            {
                string sql = @"SELECT lessons.Kod_Lessons,group_kid.Name,staff.FIO, discipline.Name_dist,lessons.Date_lesson,lessons.Hlong_hour
                                FROM lessons,group_kid,discipline,staff where lessons.Kod_Group = group_kid.Kod_Group AND lessons.Kod_Discipline = discipline.Kod_Discipline
                                AND lessons.Kod_staff = staff.Kod_staff;";

                DBConnection.mycommand.CommandText = sql;
                dtLesson.Clear();
                DBConnection.msDataAdapter.Fill(dtLesson);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных ", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}