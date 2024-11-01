namespace Kindergarten
{
    internal class DBRed_healt_group
    {
        public static bool Red(string group, string kod)
        {
            try
            {
                string sql = @"update health_group set health_group.Group ='" + group + "' where  health_group.Kod_health_group='" + kod + "';";
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