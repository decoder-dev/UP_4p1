namespace Kindergarten
{
    internal class Find_parents
    {
        public static bool Proverka(string FIO_mom, string FIO_dad)
        {
            try
            {
                string sql = "Select Kod_p from parents where concat(parents.Name_mom,' ',parents.Surname_mom,' ',parents.Patronymic_mom) = '" + FIO_mom + "' AND  concat(parents.Name_dad,' ',parents.Surname_dad,' ',parents.Patronymic_dad) = '" + FIO_dad + "';";
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