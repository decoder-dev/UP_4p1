namespace Kindergarten
{
    internal class DBDelete_parents
    {
        public static bool Delete(string kod)
        {
            try
            {
                string sql = @"delete from parents where Kod_p ='" + kod + "';";
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