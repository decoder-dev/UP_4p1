namespace Kindergarten
{
    internal class DBAdd_vaction
    {
        public static bool Add(string name)
        {
            try
            {
                string sql = @"Insert into vaccinations values (null,'" + name + "');";
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