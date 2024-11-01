using System.Data;

namespace Kindergarten
{
    internal class DBGet_Post
    {
        public static DataTable dtPost = new DataTable();

        public static void Get()
        {
            try
            {
                string sql = @"SELECT * FROM deti.post;";
                DBConnection.mycommand.CommandText = sql;
                dtPost.Clear();
                DBConnection.msDataAdapter.Fill(dtPost);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}