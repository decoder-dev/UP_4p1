using System;

namespace Kindergarten
{
    internal class DBRed_kid
    {
        public static bool Red(string Kod_kid, string New_kod_kid, string Surname, string Name, string Patronymic, string Place_of_residence, string Kod_p, string Kod_group, DateTime date)
        {
            try
            {
                string sql = @"Update kid set Birth_certificate_nomber='" + New_kod_kid + "',Surname='" + Surname + "',Name='" + Name + "',Patronymic='" + Patronymic + "',Place_of_residence='" + Place_of_residence + "',Kod_p='" + Kod_p + "',Kod_group='" + Kod_group + "',Date_of_birth='" + date.ToString("yy-MM-dd") + "' where Birth_certificate_nomber ='" + Kod_kid + "'; ";
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