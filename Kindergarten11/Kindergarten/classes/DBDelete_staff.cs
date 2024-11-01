namespace Kindergarten
{
    internal class DBDelete_staff
    {
        public static bool delete(string kod)
        {
            try
            {
                string sql = @"delete from staff where Kod_staff ='" + kod + "';";
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