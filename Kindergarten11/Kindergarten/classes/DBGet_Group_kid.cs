using System.Data;

namespace Kindergarten
{
    internal class DBGet_Group_kid
    {
        public static DataTable Group_kid = new DataTable();

        public static void Get()
        {
            try
            {
                string sql = @"SELECT group_kid.Kod_Group,group_kid.Name,types_of_group.Name,group_kid.Nomber_office
                                FROM group_kid,types_of_group where group_kid.Kod_typegroup = types_of_group.Kod_typegroup;";
                DBConnection.mycommand.CommandText = sql;

                Group_kid.Clear();
                DBConnection.msDataAdapter.Fill(Group_kid);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}