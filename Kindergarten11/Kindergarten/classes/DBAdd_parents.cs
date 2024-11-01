namespace Kindergarten
{
    internal class DBAdd_parents
    {
        public static bool Add(string Kod_p, string Surname_mom, string Name_mom, string Patronymic_mom, string Surname_dad, string Name_dad, string Patronymic_dad, string Telephone_mom, string Telephone_dad, string Place_of_work_mom, string Place_of_work_dad, string Number_of_parents)
        {
            try
            {
                string sql = @"insert into parents  values('" + Kod_p + "','" + Surname_mom + "','" + Name_mom + "','" + Patronymic_mom + "','" + Surname_dad + "','" + Name_dad + "','" + Patronymic_dad + "'," +
                                "'" + Telephone_mom + "', '" + Telephone_dad + "','" + Place_of_work_mom + "','" + Place_of_work_dad + "','" + Number_of_parents + "');";
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