using System.Data;

namespace Kindergarten
{
    internal class DBGet_kid
    {
        public static DataTable dtKid = new DataTable();

        public static void Get()
        {
            try
            {
                string sql = @"SELECT kid.Birth_certificate_nomber,kid.Name,kid.Surname,kid.Patronymic,
                              kid.Place_of_residence,group_kid.Name, kid.Date_of_birth,
                              concat(parents.Name_dad,' ',parents.Surname_dad,' ',parents.Patronymic_dad)AS FIO_dad,concat(parents.Name_mom,' ',parents.Surname_mom,' ',parents.Patronymic_mom) AS FIO_mom,parents.Telephone_dad,parents.Telephone_mom FROM kid, parents,group_kid
                              where kid.Kod_p =parents.Kod_p and kid.Kod_Group = group_kid.Kod_Group;";
                DBConnection.mycommand.CommandText = sql;

                dtKid.Clear();
                DBConnection.msDataAdapter.Fill(dtKid);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}