namespace Kindergarten
{
    internal class DBDelete_lesson
    {
        public static bool Delete(string kod)
        {
            try
            {
                string sql = @"Delete from lessons where Kod_Lessons = '" + kod + "';";
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