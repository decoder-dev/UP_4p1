using System.Data;

namespace Kindergarten
{
    internal class DBGet_data_vac
    {
        public static DataTable dtDataVac = new DataTable();

        public static void Get()
        {
            try
            {
                string sql = @"SELECT vaccination_data.Kod_vaccination_data,vaccinations.Name,vaccination_data.Date_of_vaccination,concat(kid.Name,' ',kid.Surname,' ',kid.Patronymic) AS FIO_kid FROM vaccination_data,vaccinations,kid where vaccination_data.Kod_vaccination = vaccinations.Kod_vaccination AND vaccination_data.Birth_certificate_nomber = kid.Birth_certificate_nomber ;";

                DBConnection.mycommand.CommandText = sql;
                dtDataVac.Clear();
                DBConnection.msDataAdapter.Fill(dtDataVac);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных ", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}