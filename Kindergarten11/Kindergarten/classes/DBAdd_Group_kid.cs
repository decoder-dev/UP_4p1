namespace Kindergarten
{
    internal class DBAdd_Group_kid
    {
        public static bool Add(string Name, int type, int nomber_off)
        {
            try
            {
                string sql = "insert into group_kid VALUES (null,'" + Name + "','" + type + "','" + nomber_off + "');";
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