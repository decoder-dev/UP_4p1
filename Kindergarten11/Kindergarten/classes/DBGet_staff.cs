using System.Data;

namespace Kindergarten
{
    internal class DBGet_staff
    {
        public static DataTable dtStaff = new DataTable();

        public static void Get()
        {
            try
            {
                string sql = @"SELECT Kod_staff,FIO,Telephone,post.Name,Login,Password FROM staff,post where staff.Kod_post = post.Kod_post and staff.Kod_post not in (4);";
                DBConnection.mycommand.CommandText = sql;

                dtStaff.Clear();
                DBConnection.msDataAdapter.Fill(dtStaff);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}