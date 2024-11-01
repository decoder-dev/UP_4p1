using System;

namespace Kindergarten
{
    internal class Proverka_data_vac
    {
        public static bool Proverka(string kod_vac, DateTime data, string kod_kid)
        {
            try
            {
                string sql = @"Select count(Kod_vaccination_data) from vaccination_data where Kod_vaccination='" + kod_vac + "' AND Date_of_vaccination ='" + data.ToString("yy-MM-dd") + "' AND Birth_certificate_nomber='" + kod_kid + "' ;";
                DBConnection.mycommand.CommandText = sql;

                Object rez = DBConnection.mycommand.ExecuteScalar();

                int rex = Convert.ToInt32(rez);

                if (rex <= 0)
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