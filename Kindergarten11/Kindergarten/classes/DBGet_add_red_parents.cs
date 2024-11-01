using System.Data;

namespace Kindergarten
{
    internal class DBGet_add_red_parents
    {
        public static DataTable Parents = new DataTable();

        public static void Get()
        {
            try
            {
                string sql;

                sql = @"SELECT Kod_p,concat(parents.Name_dad,' ',parents.Surname_dad,' ',parents.Patronymic_dad)AS FIO_dad,
                               concat(parents.Name_mom,' ',parents.Surname_mom,' ',parents.Patronymic_mom) AS FIO_mom,Telephone_dad,
                               Telephone_mom,Place_of_work_mom,Place_of_work_dad,Number_of_parents FROM parents;";

                DBConnection.mycommand.CommandText = sql;
                Parents.Clear();
                DBConnection.msDataAdapter.Fill(Parents);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}