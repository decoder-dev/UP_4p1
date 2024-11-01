using System;

namespace Kindergarten
{
    internal class Filter_staff
    {
        public static void Filter_group(string post)
        {
            try
            {
                string sql = @"SELECT Kod_staff,FIO,Telephone,post.Name,Login,Password FROM staff,post where staff.Kod_post = post.Kod_post and staff.Kod_post not in (4) AND post.Name='" + post + "';";
                DBConnection.mycommand.CommandText = sql;

                Object rez = DBConnection.mycommand.ExecuteScalar();

                if (rez != null)
                {
                    DBGet_staff.dtStaff.Clear();
                    DBConnection.msDataAdapter.Fill(DBGet_staff.dtStaff);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Запись не найдена", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        public static void Cortirovka_FIO_staff(int nomber_ASC_DESC)
        {
            try
            {
                string sql = "";

                if (nomber_ASC_DESC == 0)
                {
                    sql = @"SELECT Kod_staff,FIO,Telephone,post.Name,Login,Password FROM staff,post where staff.Kod_post = post.Kod_post and staff.Kod_post not in (4) order by FIO DESC;";
                }
                else
                {
                    if (nomber_ASC_DESC == 1)
                    {
                        sql = @"SELECT Kod_staff,FIO,Telephone,post.Name,Login,Password FROM staff,post where staff.Kod_post = post.Kod_post and staff.Kod_post not in (4) order by FIO ASC;";
                    }
                }

                DBConnection.mycommand.CommandText = sql;
                DBGet_staff.dtStaff.Clear();
                DBConnection.msDataAdapter.Fill(DBGet_staff.dtStaff);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}