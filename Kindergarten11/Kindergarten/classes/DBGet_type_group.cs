using System.Data;

namespace Kindergarten
{
    internal class DBGet_type_group
    {
        public static DataTable dtType_Group = new DataTable();

        public static void Get()
        {
            try
            {
                string sql = @"SELECT * FROM deti.types_of_group;";
                DBConnection.mycommand.CommandText = sql;
                dtType_Group.Clear();
                DBConnection.msDataAdapter.Fill(dtType_Group);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}