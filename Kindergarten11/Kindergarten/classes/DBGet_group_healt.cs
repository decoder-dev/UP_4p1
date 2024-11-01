using System.Data;

namespace Kindergarten
{
    internal class DBGet_group_healt
    {
        public static DataTable dtHealt = new DataTable();

        public static void Get()
        {
            try
            {
                string sql = @"SELECT * FROM deti.health_group;";
                DBConnection.mycommand.CommandText = sql;
                dtHealt.Clear();
                DBConnection.msDataAdapter.Fill(dtHealt);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных ", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}