using System;

namespace Kindergarten
{
    internal class DBRed_data_vac
    {
        public static bool Red(string kod_vak, DateTime data, string kod_kid, string kod)
        {
            try
            {
                string sql = @"update vaccination_data set Kod_vaccination ='" + kod_vak + "',Date_of_vaccination='" + data.ToString("yy-MM-dd") + "',Birth_certificate_nomber='" + kod_kid + "' where Kod_vaccination_data ='" + kod + "';";
                DBConnection.mycommand.CommandText = sql;

                if (DBConnection.mycommand.ExecuteNonQuery() > 0)
                {
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