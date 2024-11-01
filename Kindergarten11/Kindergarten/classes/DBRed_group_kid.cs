namespace Kindergarten
{
    internal class DBRed_group_kid
    {
        public static bool Red(string name, string kod_type, string nomber, string kod)
        {
            try
            {
                string sql = @"update group_kid set Name ='" + name + "',Kod_typegroup='" + kod_type + "',Nomber_office = '" + nomber + "' where Kod_Group ='" + kod + "';";
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