using System;

namespace Kindergarten
{
    internal class Proverka_kid
    {
        public static int age_from;
        public static int age_up;

        public static bool Proverka(string Birth_certificate_nomber)
        {
            try
            {
                string sql = "SELECT count(Birth_certificate_nomber) FROM kid Where Birth_certificate_nomber ='" + Birth_certificate_nomber + "';";

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

        public static bool AGE_FROM(string type)
        {
            try
            {
                string sql = "SELECT Age_from FROM types_of_group where Name='" + type + "';";
                DBConnection.mycommand.CommandText = sql;

                Object rez = DBConnection.mycommand.ExecuteScalar();

                if (rez != null)
                {
                    age_from = Convert.ToInt32(rez);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool AGE_UP(string type)
        {
            try
            {
                string sql = "SELECT Age_up_to FROM types_of_group where Name='" + type + "';";
                DBConnection.mycommand.CommandText = sql;

                Object rez = DBConnection.mycommand.ExecuteScalar();

                if (rez != null)
                {
                    age_up = Convert.ToInt32(rez);
                    return true;
                }
                else
                {
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