using System.Data;

namespace Kindergarten
{
    internal class DBGet_parents
    {
        public static DataTable dtParents = new DataTable();

        public static void Get()
        {
            try
            {
                string sql;

                sql = @"SELECT Kod_p,Name_dad,Surname_dad,Patronymic_dad,
                               Name_mom,Surname_mom,Patronymic_mom,Telephone_dad,
                               Telephone_mom,Place_of_work_mom,Place_of_work_dad,Number_of_parents FROM parents;";

                DBConnection.mycommand.CommandText = sql;
                dtParents.Clear();
                DBConnection.msDataAdapter.Fill(dtParents);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}