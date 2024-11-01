using System;

namespace Kindergarten
{
    public class Proverka_parents
    {
        /// <summary>
        /// Проверка в таблице "родители" по трем условиям (код,телефон матери, телефон отца)
        /// </summary>
        /// <param name="Kod_p"></param>
        /// <param name="Telephone_mom"></param>
        /// <param name="Telephone_dad"></param>
        /// <returns></returns>
        public static bool Proverka(string Kod_p, string Telephone_mom, string Telephone_dad)
        {
            try
            {
                string sql = "Select count(Kod_p) from parents where Kod_p = '" + Kod_p + "' OR Telephone_mom='" + Telephone_mom + "' OR Telephone_dad='" + Telephone_dad + "';";
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

        /// <summary>
        /// Проверка в таблице "родители" по коду
        /// </summary>
        /// <param name="Kod_p"></param>
        /// <returns></returns>
        public static bool Proverka_kod(string Kod_p)
        {
            try
            {
                string sql = "Select count(Kod_p) from parents where Kod_p = '" + Kod_p + "' ;";
                DBConnection.mycommand.CommandText = sql;

                Object rez = DBConnection.mycommand.ExecuteScalar();

                int rez1 = Convert.ToInt32(rez);

                if (rez1 <= 0)
                {
                    return true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Повторение паспортных данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    Red_parents.proverka = 1;
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Проверка в таблице "родители" по телефону матери
        /// </summary>
        /// <param name="Telephone_mom"></param>
        /// <returns></returns>
        public static bool Proverka_telephone_mom(string Telephone_mom)
        {
            try
            {
                string sql = "Select count(Kod_p) from parents where Telephone_mom='" + Telephone_mom + "' ";
                DBConnection.mycommand.CommandText = sql;

                Object rez = DBConnection.mycommand.ExecuteScalar();

                int rez1 = Convert.ToInt32(rez);

                if (rez1 <= 0)
                {
                    return true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Повторение телефона матери", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    Red_parents.proverka = 1;
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Проверка в таблице "родители" по телефону отца
        /// </summary>
        /// <param name="Telephone_dad"></param>
        /// <returns></returns>
        public static bool Proverka_telephone_dad(string Telephone_dad)
        {
            try
            {
                string sql = "Select count(Kod_p) from parents where  Telephone_dad='" + Telephone_dad + "';";
                DBConnection.mycommand.CommandText = sql;

                Object rez = DBConnection.mycommand.ExecuteScalar();

                int rez1 = Convert.ToInt32(rez);

                if (rez1 <= 0)
                {
                    return true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Повторение телефона отца", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    Red_parents.proverka = 1;
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Проверка в таблице "родители" по телефону отца и матери
        /// </summary>
        /// <param name="Telephone_mom"></param>
        /// <param name="Telephone_dad"></param>
        /// <returns></returns>
        public static bool Proverka_telephone_momANDtelephone_dad(string Telephone_mom, string Telephone_dad)
        {
            try
            {
                string sql = "Select count(Kod_p) from parents where Telephone_mom='" + Telephone_mom + "' OR Telephone_dad='" + Telephone_dad + "';";
                DBConnection.mycommand.CommandText = sql;

                Object rez = DBConnection.mycommand.ExecuteScalar();

                int rez1 = Convert.ToInt32(rez);

                if (rez1 <= 0)
                {
                    return true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Повторение телефона ", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    Red_parents.proverka = 1;
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