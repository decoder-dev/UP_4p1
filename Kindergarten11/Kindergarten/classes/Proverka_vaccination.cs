using System;

namespace Kindergarten
{
    internal class Proverka_vaccination
    {
        public static bool Proverka(string name)
        {
            try
            {
                string sql = @"Select count(name) from vaccinations where Name='" + name + "';";
                DBConnection.mycommand.CommandText = sql;

                Object rez = DBConnection.mycommand.ExecuteScalar();

                int rez1 = Convert.ToInt32(rez);

                if ((rez1 <= 0))
                {
                    return true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Повторение записи", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}