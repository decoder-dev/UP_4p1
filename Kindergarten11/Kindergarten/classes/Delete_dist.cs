﻿using System;

namespace Kindergarten
{
    internal class Delete_dist
    {
        public static bool Delete_Proverka(string kod_dist)
        {
            try
            {
                string sql = "SELECT count(Kod_Discipline) FROM lessons where Kod_Discipline ='" + kod_dist + "';";
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