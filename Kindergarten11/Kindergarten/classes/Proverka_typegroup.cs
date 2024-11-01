using System;

namespace Kindergarten
{
    internal class Proverka_typegroup
    {
        public static bool Proverka(string name)
        {
            try
            {
                string sql = @"Select count(name) from types_of_group where Name='" + name + "';";
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