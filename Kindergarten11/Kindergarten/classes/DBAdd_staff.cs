namespace Kindergarten
{
    internal class DBAdd_staff
    {
        public static bool Add(string FIO, string telephone, string Post, string Login)
        {
            try
            {
                string sql = "insert into staff  values(null,'" + FIO + "','" + telephone + "','" + Post + "','" + Login + "',md5('1'));";
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