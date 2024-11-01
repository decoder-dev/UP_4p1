using System;

namespace Kindergarten
{
    internal class DBAdd_kid
    {
        public static bool Add(string Kod_kid, string Surname, string Name, string Patronymic, string Place_of_residence, string Kod_p, string Kod_group, DateTime date)
        {
            try
            {
                string sql = "insert into kid VALUES ('" + Kod_kid + "','" + Surname + "','" + Name + "','" + Patronymic + "','" + Place_of_residence + "','" + Kod_p + "', '" + Kod_group + "','" + date.ToString("yy-MM-dd") + "');";
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