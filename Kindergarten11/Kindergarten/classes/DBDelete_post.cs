namespace Kindergarten
{
    internal class DBDelete_post
    {
        public static bool Delete(string kod)
        {
            try
            {
                string sql = @"Delete from post where Kod_post = '" + kod + "';";
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