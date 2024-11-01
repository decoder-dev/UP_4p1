namespace Kindergarten
{
    internal class DBDelete_data_vac
    {
        public static bool Delete(string Kod)
        {
            try
            {
                string sql = "delete from vaccination_data where Kod_vaccination_data ='" + Kod + "';";
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