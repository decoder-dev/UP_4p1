namespace Kindergarten
{
    internal class DBRed_type_group
    {
        public static bool Red(string name, string age_from, string age_up, string kod, string count_kid)
        {
            try
            {
                string sql = @"Update types_of_group set Name='" + name + "',Age_from='" + age_from + "',Age_up_to='" + age_up + "', Count_kid='" + count_kid + "' where Kod_typegroup ='" + kod + "'; ";
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