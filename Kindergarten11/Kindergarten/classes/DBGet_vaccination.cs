using System.Data;

namespace Kindergarten
{
    internal class DBGet_vaccination
    {
        public static DataTable dtVaccination = new DataTable();

        public static void Getvac()
        {
            try
            {
                string sql = @"SELECT vaccinations.Kod_vaccination,vaccinations.Name FROM vaccinations;";

                DBConnection.mycommand.CommandText = sql;
                dtVaccination.Clear();
                DBConnection.msDataAdapter.Fill(dtVaccination);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}