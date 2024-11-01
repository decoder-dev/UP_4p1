namespace Kindergarten
{
    internal class DBAdd_healt_group
    {
        public static bool Add(string group)
        {
            try
            {
                string sql = @"insert into health_group values(null,'" + group + "')";
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