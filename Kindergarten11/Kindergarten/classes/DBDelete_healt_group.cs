namespace Kindergarten
{
    internal class DBDelete_healt_group
    {
        public static bool Delete(string kod)
        {
            try
            {
                string sql = @"Delete from health_group where Kod_health_group='" + kod + "';";
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