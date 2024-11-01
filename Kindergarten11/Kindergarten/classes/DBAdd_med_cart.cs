namespace Kindergarten
{
    internal class DBAdd_med_cart
    {
        public static bool Add(string kod_kid, string rost, string vec, string group_healt, string xpon)
        {
            try
            {
                string sql = "insert into medical_card VALUES (null,'" + kod_kid + "','" + rost + "','" + vec + "','" + group_healt + "','" + xpon + "');";
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