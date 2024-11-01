using System;

namespace Kindergarten
{
    internal class Find_hour_dist_fromlessonsproverka
    {
        public static int Hour_dist;

        public static bool Find(string dist)
        {
            try
            {
                string sql = "SELECT Number_of_hours_per_week FROM discipline Where Name_dist='" + dist + "';";
                DBConnection.mycommand.CommandText = sql;

                Object rez = DBConnection.mycommand.ExecuteScalar();

                if (rez != null)
                {
                    Hour_dist = Convert.ToInt32(rez);
                    return true;
                }
                else
                {
                    Hour_dist = 0;
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