using System;

namespace Kindergarten
{
    internal class DBGet_add_parents
    {
        public static string Pasport;

        public static void Get(string FIO_dad, string FIO_mom)
        {
            try
            {
                string sql = @"Select parents.Kod_p from parents where concat(parents.Name_dad,' ',parents.Surname_dad,' ',parents.Patronymic_dad)='" + FIO_dad + "' AND concat(parents.Name_mom,' ',parents.Surname_mom,' ',parents.Patronymic_mom) = '" + FIO_mom + "';";

                DBConnection.mycommand.CommandText = sql;
                Object result = DBConnection.mycommand.ExecuteScalar();

                if (result != null)
                {
                    Pasport = result.ToString();
                }
                else
                {
                    Pasport = null;
                    System.Windows.Forms.MessageBox.Show("Запись не найдена", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch
            {
                Pasport = null;
                System.Windows.Forms.MessageBox.Show("Ошибка при выводе сообщения", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}