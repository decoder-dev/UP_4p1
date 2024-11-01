using System;

namespace Kindergarten
{
    public class Proverkapost
    {
        public static bool Proverka(string name)
        {
            try
            {
                string sql = @"select count(Name) from post where Name = '" + name + "';";
                DBConnection.mycommand.CommandText = sql;

                Object rez = DBConnection.mycommand.ExecuteScalar();
                int rex = Convert.ToInt32(rez);

                if (rex <= 0)
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
    }
}