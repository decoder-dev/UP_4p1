using System;

namespace Kindergarten
{
    internal class Proverka_med_cart
    {
        public static bool Proverka(string kod_kid)
        {
            try
            {
                string sql = @"Select count(Birth_certificate_nomber) from medical_card where Birth_certificate_nomber='" + kod_kid + "';";
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