using System;

namespace Kindergarten
{
    internal class Filter_data_vac
    {
        public static void Filter_FIO_kid(string FIO_kid)
        {
            try
            {
                string sql = @"SELECT vaccination_data.Kod_vaccination_data,vaccinations.Name,vaccination_data.Date_of_vaccination,concat(kid.Name,' ',kid.Surname,' ',kid.Patronymic) AS FIO_kid FROM vaccination_data,vaccinations,kid where vaccination_data.Kod_vaccination = vaccinations.Kod_vaccination AND vaccination_data.Birth_certificate_nomber = kid.Birth_certificate_nomber AND concat(kid.Name,' ',kid.Surname,' ',kid.Patronymic) = '" + FIO_kid + "';";

                DBConnection.mycommand.CommandText = sql;
                Object rez = DBConnection.mycommand.ExecuteScalar();

                if (rez != null)
                {
                    DBGet_data_vac.dtDataVac.Clear();
                    DBConnection.msDataAdapter.Fill(DBGet_data_vac.dtDataVac);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Запись не найдена", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных ", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        public static void Filter_Group(string Kod_Group)
        {
            try
            {
                string sql = @"SELECT vaccination_data.Kod_vaccination_data,vaccinations.Name,vaccination_data.Date_of_vaccination,concat(kid.Name,' ',kid.Surname,' ',kid.Patronymic) AS FIO_kid FROM vaccination_data,vaccinations,kid where vaccination_data.Kod_vaccination = vaccinations.Kod_vaccination AND vaccination_data.Birth_certificate_nomber = kid.Birth_certificate_nomber AND kid.Kod_Group = '" + Kod_Group + "';";

                DBConnection.mycommand.CommandText = sql;
                Object rez = DBConnection.mycommand.ExecuteScalar();

                if (rez != null)
                {
                    DBGet_data_vac.dtDataVac.Clear();
                    DBConnection.msDataAdapter.Fill(DBGet_data_vac.dtDataVac);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Запись не найдена", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных ", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        public static void Filter_Vac(string vac)
        {
            try
            {
                string sql = @"SELECT vaccination_data.Kod_vaccination_data,vaccinations.Name,vaccination_data.Date_of_vaccination,concat(kid.Name,' ',kid.Surname,' ',kid.Patronymic) AS FIO_kid FROM vaccination_data,vaccinations,kid where vaccination_data.Kod_vaccination = vaccinations.Kod_vaccination AND vaccination_data.Birth_certificate_nomber = kid.Birth_certificate_nomber AND vaccinations.Name ='" + vac + "';";

                DBConnection.mycommand.CommandText = sql;
                Object rez = DBConnection.mycommand.ExecuteScalar();

                if (rez != null)
                {
                    DBGet_data_vac.dtDataVac.Clear();
                    DBConnection.msDataAdapter.Fill(DBGet_data_vac.dtDataVac);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Запись не найдена", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных ", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        public static void Filter_VacANDGroup(string vac, string Kod_Group)
        {
            try
            {
                string sql = @"SELECT vaccination_data.Kod_vaccination_data,vaccinations.Name,vaccination_data.Date_of_vaccination,concat(kid.Name,' ',kid.Surname,' ',kid.Patronymic) AS FIO_kid FROM vaccination_data,vaccinations,kid where vaccination_data.Kod_vaccination = vaccinations.Kod_vaccination AND vaccination_data.Birth_certificate_nomber = kid.Birth_certificate_nomber AND vaccinations.Name ='" + vac + "' AND kid.Kod_Group = '" + Kod_Group + "';";

                DBConnection.mycommand.CommandText = sql;
                Object rez = DBConnection.mycommand.ExecuteScalar();

                if (rez != null)
                {
                    DBGet_data_vac.dtDataVac.Clear();
                    DBConnection.msDataAdapter.Fill(DBGet_data_vac.dtDataVac);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Запись не найдена", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных ", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}