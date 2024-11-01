namespace Kindergarten
{
    internal class DBDelete_Dist
    {
        public static bool Delete(int Kod)
        {
            try
            {
                string sql = "delete from discipline where Kod_Discipline ='" + Kod + "';";
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