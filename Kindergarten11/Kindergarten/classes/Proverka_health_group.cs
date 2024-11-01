using System;

namespace Kindergarten
{
    internal class Proverka_health_group
    {
        public static bool Proverka(string group)
        {
            try
            {
                string sql = @"Select count(health_group.Group) from health_group where health_group.Group='" + group + "';";
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