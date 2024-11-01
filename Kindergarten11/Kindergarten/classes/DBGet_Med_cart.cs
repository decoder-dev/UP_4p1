using System.Data;

namespace Kindergarten
{
    internal class DBGet_Med_cart
    {
        public static DataTable Med_cart = new DataTable();

        public static void Get()
        {
            try
            {
                string sql = @"SELECT medical_card.Kod_medical_card,kid.Name,kid.Surname,kid.Patronymic,medical_card.Height,medical_card.Weight,health_group.Group,medical_card.Chronic_diseases
                           FROM medical_card,kid,health_group where medical_card.Birth_certificate_nomber = kid.Birth_certificate_nomber
                           AND medical_card.Kod_health_group = health_group.Kod_health_group;";
                DBConnection.mycommand.CommandText = sql;

                Med_cart.Clear();
                DBConnection.msDataAdapter.Fill(Med_cart);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}