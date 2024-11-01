namespace Kindergarten
{
    internal class DBRed_dist
    {
        public static bool Red(string time, string name, string kod)
        {
            try
            {
                string sql = @"update discipline set Name_dist ='" + name + "',Number_of_hours_per_week='" + time + "' where Kod_Discipline ='" + kod + "';";
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