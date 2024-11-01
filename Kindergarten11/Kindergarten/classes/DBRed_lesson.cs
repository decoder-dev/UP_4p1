using System;

namespace Kindergarten
{
    internal class DBRed_lesson
    {
        public static bool Red(string kod_group, string kod_staff, string kod_disciplin, DateTime date, string hour, string kod_lesson)
        {
            try
            {
                string sql = @"update lessons set Kod_Group ='" + kod_group + "',Kod_staff='" + kod_staff + "'," +
                    "Kod_Discipline ='" + kod_disciplin + "',Date_lesson='" + date.ToString("yy-MM-dd") + "',Hlong_hour='" + hour + "' where  Kod_Lessons='" + kod_lesson + "';";
                DBConnection.mycommand.CommandText = sql;

                if (DBConnection.mycommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}