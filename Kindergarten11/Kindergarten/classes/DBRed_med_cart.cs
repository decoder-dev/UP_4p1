namespace Kindergarten
{
    internal class DBRed_med_cart
    {
        public static bool Red(string kod_kid, string rost, string vec, string group_healt, string xpon, string kod)
        {
            try
            {
                string sql = @"update medical_card set Birth_certificate_nomber ='" + kod_kid + "',Height='" + rost + "'," +
                    "Weight ='" + vec + "',Kod_health_group='" + group_healt + "',Chronic_diseases='" + xpon + "' where  Kod_medical_card='" + kod + "';";
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