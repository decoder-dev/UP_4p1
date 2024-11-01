namespace Kindergarten
{
    internal class DBRed_vaction
    {
        public static bool Red(string kod, string name)
        {
            try
            {
                string sql = @"Update vaccinations set Name='" + name + "' where Kod_vaccination='" + kod + "';";
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