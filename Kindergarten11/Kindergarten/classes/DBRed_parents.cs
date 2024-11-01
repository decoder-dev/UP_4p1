namespace Kindergarten
{
    internal class DBRed_parents
    {
        public static bool Red(string Kod_p, string Surname_mom, string Name_mom, string Patronymic_mom, string Surname_dad, string Name_dad, string Patronymic_dad, string Telephone_mom, string Telephone_dad, string Place_of_work_mom, string Place_of_work_dad, string Number_of_parents, string New_kod)
        {
            try
            {
                string sql = @"update parents set Surname_mom ='" + Surname_mom + "',Name_mom='" + Name_mom + "',Patronymic_mom = '" + Patronymic_mom + "'," +
                               "Surname_dad='" + Surname_dad + "',Name_dad='" + Name_dad + "',Patronymic_dad='" + Patronymic_dad + "'," +
                               "Telephone_mom='" + Telephone_mom + "',Telephone_dad='" + Telephone_dad + "',Place_of_work_mom='" + Place_of_work_mom + "'," +
                               "Place_of_work_dad='" + Place_of_work_dad + "',Number_of_parents='" + Number_of_parents + "',Kod_p ='" + New_kod + "' where Kod_p ='" + Kod_p + "';";
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