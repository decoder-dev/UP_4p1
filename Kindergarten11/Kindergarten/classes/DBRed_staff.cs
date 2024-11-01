namespace Kindergarten
{
    internal class DBRed_staff
    {
        public static bool Red(string FIO, string Telephone, string kod_post, string login, string kod)
        {
            try
            {
                string sql = @"update staff set FIO ='" + FIO + "',Telephone='" + Telephone + "',Kod_post ='" + kod_post + "',Login='" + login + "' where Kod_staff ='" + kod + "';";
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