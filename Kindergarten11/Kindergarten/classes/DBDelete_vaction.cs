namespace Kindergarten
{
    internal class DBDelete_vaction
    {
        public static bool delete(string kod)
        {
            try
            {
                string sql = @"delete from vaccinations where Kod_vaccination ='" + kod + "';";
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