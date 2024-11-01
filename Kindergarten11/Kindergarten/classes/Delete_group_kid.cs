using System;

namespace Kindergarten
{
    internal class Delete_group_kid
    {
        public static bool Delete_Proverka(string kod_type)
        {
            try
            {
                string sql = "SELECT count(Kod_Group) FROM kid where Kod_Group ='" + kod_type + "';";
                DBConnection.mycommand.CommandText = sql;

                Object rez = DBConnection.mycommand.ExecuteScalar();

                int rez1 = Convert.ToInt32(rez);

                if (rez1 <= 0)
                {
                    string sql1 = "SELECT count(Kod_Group) FROM lessons where Kod_Group ='" + kod_type + "';";
                    DBConnection.mycommand.CommandText = sql1;

                    Object rez0 = DBConnection.mycommand.ExecuteScalar();

                    int rez2 = Convert.ToInt32(rez0);
                    if (rez2 <= 0)
                    {
                        return true;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Запись используется в другой таблице", "Удаление невозможно", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return false;
                    }
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