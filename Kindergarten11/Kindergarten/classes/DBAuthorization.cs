using System;

namespace Kindergarten
{
    internal class DBAuthorization
    {
        public static string fio;
        public static string telephone;

        /// <summary>
        /// Поиск должности в таблице "Сотрудники" по логину и паролю
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public static void Authorization(string login, string password)
        {
            try
            {
                string sql = @"Select staff.Kod_post from staff where staff.Login='" + login + "' and staff.Password = md5('" + password + "');";

                DBConnection.mycommand.CommandText = sql;
                Object result = DBConnection.mycommand.ExecuteScalar();

                if (result != null)
                {
                    DBConnection.user = login;
                    DBConnection.Role = (int)result;
                }
                else
                {
                    DBConnection.Role = 0;
                    DBConnection.user = null;
                }
            }
            catch
            {
                DBConnection.Role = 0;
                DBConnection.user = null;
                System.Windows.Forms.MessageBox.Show("Ошибка при авторизации", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Поиск ФИО сотрудника в таблице "Сотрудник"  по логину и паролю
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public static void FIO(string login, string password)
        {
            try
            {
                string sql = @"Select staff.FIO from staff where staff.Login='" + login + "' and staff.Password = md5('" + password + "');";

                DBConnection.mycommand.CommandText = sql;
                Object result = DBConnection.mycommand.ExecuteScalar();

                if (result != null)
                {
                    fio = result.ToString();
                }
                else
                {
                    fio = null;
                }
            }
            catch
            {
                fio = null;
                System.Windows.Forms.MessageBox.Show("Ошибка при выводе сообщения", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Поиск телефона в таблице "Сотрудник"  по логину и паролю
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public static void Telephone(string login, string password)
        {
            try
            {
                string sql = @"Select staff.Telephone from staff where staff.Login='" + login + "' and staff.Password = md5('" + password + "');";

                DBConnection.mycommand.CommandText = sql;
                Object result = DBConnection.mycommand.ExecuteScalar();
                if (result != null)
                {
                    telephone = result.ToString();
                }
                else
                {
                    telephone = null;
                }
            }
            catch
            {
                telephone = null;
                System.Windows.Forms.MessageBox.Show("Ошибка при выводе сообщения", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}