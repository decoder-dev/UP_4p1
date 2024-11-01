using System;

namespace Kindergarten
{
    internal class Proverka_group_kid
    {
        public static bool Proverka(string Name, string nomber)
        {
            try
            {
                string sql = "Select count(name) from group_kid where Name = '" + Name + "'OR Nomber_office ='" + nomber + "';";
                DBConnection.mycommand.CommandText = sql;

                Object rez = DBConnection.mycommand.ExecuteScalar();

                int rez1 = Convert.ToInt32(rez);

                if (rez1 <= 0)
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