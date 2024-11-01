namespace Kindergarten
{
    internal class DBDelete_typegroup
    {
        public static bool Delete(string kod)
        {
            try
            {
                string sql = @"delete from types_of_group where Kod_typegroup ='" + kod + "'; ";
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