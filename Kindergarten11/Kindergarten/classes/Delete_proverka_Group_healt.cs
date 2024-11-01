using System;

namespace Kindergarten
{
    internal class Delete_proverka_Group_healt
    {
        public static bool Delete_Proverka(string kod_type)
        {
            try
            {
                string sql = "SELECT count(Kod_health_group) FROM medical_card where Kod_health_group ='" + kod_type + "';";
                DBConnection.mycommand.CommandText = sql;

                Object rez = DBConnection.mycommand.ExecuteScalar();

                int rez1 = Convert.ToInt32(rez);

                if (rez1 <= 0)
                {
                    return true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Запись используется в другой таблице", "Удаление невозможно", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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