namespace Kindergarten
{
    internal class DBDelete_kid
    {
        public static bool Delete(string cert)
        {
            try
            {
                string sql = "Delete From deti.kid where Birth_certificate_nomber='" + cert + "';";
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