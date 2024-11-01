using System;

namespace Kindergarten
{
    internal class Proverka_hour_lesson
    {
        public static int Hour;

        public static bool Proverka(string Kod_dist, string Kod_group, DateTime date_from, DateTime date_up)
        {
            try
            {
                string sql = "Select sum(Hlong_hour) From lessons Where Kod_Discipline='" + Kod_dist + "' AND Kod_Group='" + Kod_group + "' AND Date_lesson Between '" + date_from.ToString("yy-MM-dd") + "' AND '" + date_up.ToString("yy-MM-dd") + "'";
                DBConnection.mycommand.CommandText = sql;

                Object rez = DBConnection.mycommand.ExecuteScalar();

                if (rez != null)
                {
                    Hour = Convert.ToInt32(rez);
                    return true;
                }
                else
                {
                    Hour = 0;
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