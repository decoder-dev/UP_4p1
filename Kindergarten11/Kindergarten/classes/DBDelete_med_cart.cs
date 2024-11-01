namespace Kindergarten
{
    internal class DBDelete_med_cart
    {
        public static bool Delete(string kod)
        {
            try
            {
                string sql = "Delete From medical_card where Kod_medical_card='" + kod + "';";
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