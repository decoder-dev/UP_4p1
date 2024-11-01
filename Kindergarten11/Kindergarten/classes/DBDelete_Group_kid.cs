namespace Kindergarten
{
    internal class DBDelete_Group_kid
    {
        public static bool Delete(int kod)
        {
            try
            {
                string sql = "Delete from group_kid where Kod_Group = '" + kod + "';";
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