namespace Kindergarten
{
    internal class DBRed_post
    {
        public static bool Red(string name, string kod)
        {
            try
            {
                string sql = @"update post set Name ='" + name + "' where Kod_post ='" + kod + "';";
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