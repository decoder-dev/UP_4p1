namespace Kindergarten
{
    internal class Filter_parents
    {
        public static void Filter(string FIO)
        {
            try
            {
                string sql;

                sql = @"SELECT Kod_p,Name_dad,Surname_dad,Patronymic_dad,
                               Name_mom,Surname_mom,Patronymic_mom,Telephone_dad,
                               Telephone_mom,Place_of_work_mom,Place_of_work_dad,Number_of_parents FROM parents
                               where concat(parents.Name_dad,' ',parents.Surname_dad,' ',parents.Patronymic_dad,' ',parents.Name_mom,' ',parents.Surname_mom,' ',parents.Patronymic_mom) LIKE '%" + FIO + "%';;";

                DBConnection.mycommand.CommandText = sql;
                DBGet_parents.dtParents.Clear();
                DBConnection.msDataAdapter.Fill(DBGet_parents.dtParents);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}