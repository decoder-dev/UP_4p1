using System;

namespace Kindergarten
{
    internal class DBAdd_lessons
    {
        public static bool Add(string kod_group, string kod_staff, string kod_disciplin, DateTime date, string hour)
        {
            try
            {
                string sql = "insert into lessons VALUES (null,'" + kod_group + "','" + kod_staff + "','" + kod_disciplin + "','" + date.ToString("yy-MM-dd") + "','" + hour + "');";
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