namespace Kindergarten
{
    internal class DBAdd_dist
    {
        public static bool Add(string Name, int hour)
        {
            try
            {
                string sql = "insert into discipline  values(null,'" + Name + "','" + hour + "');";
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