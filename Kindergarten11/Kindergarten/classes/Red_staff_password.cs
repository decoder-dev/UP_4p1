namespace Kindergarten
{
    internal class Red_staff_password
    {
        public static bool Red(string password, string Login)
        {
            try

            {
                string sql = @"update staff set Password =md5('" + password + "') where Login = '" + Login + "';";
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