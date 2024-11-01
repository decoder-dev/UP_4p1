using System;

namespace Kindergarten
{
    internal class Delete_proverka_type_group
    {
        public static bool Delete_Proverka(string kod_type)
        {
            try
            {
                string sql = "SELECT count(Kod_typegroup) FROM group_kid where Kod_typegroup ='" + kod_type + "';";
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