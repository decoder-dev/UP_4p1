namespace Kindergarten
{
    internal class DBAdd_typegroup
    {
        public static bool Add(string name, string From, string Up_to, string count_kid)
        {
            try
            {
                string sql = @"Insert into types_of_group values (null,'" + name + "','" + From + "','" + Up_to + "','" + count_kid + "');";
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