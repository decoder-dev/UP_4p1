using System;

namespace Kindergarten
{
    internal class Filter_med_cart_FIO_kid
    {
        public static void Filter(string FIO_kid)
        {
            try
            {
                string sql = @"SELECT medical_card.Kod_medical_card,kid.Name,kid.Surname,kid.Patronymic,medical_card.Height,medical_card.Weight,health_group.Group,medical_card.Chronic_diseases
                           FROM medical_card,kid,health_group where medical_card.Birth_certificate_nomber = kid.Birth_certificate_nomber
                           AND medical_card.Kod_health_group = health_group.Kod_health_group AND concat(kid.Name,' ',kid.Surname,' ',kid.Patronymic)='" + FIO_kid + "';";
                DBConnection.mycommand.CommandText = sql;
                Object rez = DBConnection.mycommand.ExecuteScalar();

                if (rez != null)
                {
                    DBGet_Med_cart.Med_cart.Clear();
                    DBConnection.msDataAdapter.Fill(DBGet_Med_cart.Med_cart);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Записей не найдено", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}