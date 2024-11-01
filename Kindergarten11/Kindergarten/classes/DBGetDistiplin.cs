using System.Data;

namespace Kindergarten
{
    internal class DBGetDistiplin
    {
        public static DataTable Distplin = new DataTable();

        public static void Get()
        {
            try
            {
                string sql = "SELECT * FROM deti.discipline;";
                DBConnection.mycommand.CommandText = sql;

                Distplin.Clear();
                DBConnection.msDataAdapter.Fill(Distplin);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}