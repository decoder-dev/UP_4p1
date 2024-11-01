namespace Kindergarten
{
    internal class DBAdd_post
    {
        public static bool Add(string name)
        {
            try
            {
                string sql = @"insert into post value(null,'" + name + "');";
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