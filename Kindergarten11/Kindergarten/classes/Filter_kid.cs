using System;

namespace Kindergarten
{
    public class Filter_kid
    {
        public static void Filter_Fio_kid(string FIO_kid)
        {
            try
            {
                string sql = @"SELECT kid.Birth_certificate_nomber,kid.Name,kid.Surname,kid.Patronymic,
                              kid.Place_of_residence,group_kid.Name, kid.Date_of_birth,
                              concat(parents.Name_dad,' ',parents.Surname_dad,' ',parents.Patronymic_dad)AS FIO_dad,concat(parents.Name_mom,' ',parents.Surname_mom,' ',parents.Patronymic_mom) AS FIO_mom,parents.Telephone_dad,parents.Telephone_mom FROM kid, parents,group_kid
                              where kid.Kod_p =parents.Kod_p and kid.Kod_Group = group_kid.Kod_Group AND concat(kid.Name,' ',kid.Surname,' ',kid.Patronymic) LIKE '%" + FIO_kid + "%';";
                DBConnection.mycommand.CommandText = sql;

                DBGet_kid.dtKid.Clear();
                DBConnection.msDataAdapter.Fill(DBGet_kid.dtKid);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        public static bool Filter_Group(string Group)
        {
            try
            {
                string sql = @"SELECT kid.Birth_certificate_nomber,kid.Name,kid.Surname,kid.Patronymic,
                              kid.Place_of_residence,group_kid.Name, kid.Date_of_birth,
                              concat(parents.Name_dad,' ',parents.Surname_dad,' ',parents.Patronymic_dad)AS FIO_dad,concat(parents.Name_mom,' ',parents.Surname_mom,' ',parents.Patronymic_mom) AS FIO_mom,parents.Telephone_dad,parents.Telephone_mom FROM kid, parents,group_kid
                              where kid.Kod_p =parents.Kod_p and kid.Kod_Group = group_kid.Kod_Group AND group_kid.Kod_Group ='" + Group + "';";

                DBConnection.mycommand.CommandText = sql;

                Object rez = DBConnection.mycommand.ExecuteScalar();

                if (rez != null)
                {
                    DBGet_kid.dtKid.Clear();
                    DBConnection.msDataAdapter.Fill(DBGet_kid.dtKid);
                    return true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Запись не найдена", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return false;
                }
            }
            catch
            {
                return false;
                System.Windows.Forms.MessageBox.Show("Ошибка при отображении данных", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        public static int Count_kidOFgroup(string Kod_group)
        {
            try
            {
                string sql = "SELECT count(kid.Name) FROM kid,group_kid WHERE kid.Kod_Group=group_kid.Kod_Group AND kid.Kod_Group ='" + Kod_group + "';";

                DBConnection.mycommand.CommandText = sql;
                Object rez = DBConnection.mycommand.ExecuteScalar();

                if (rez != null)
                {
                    return Convert.ToInt32(rez);
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public static int Count_kid_typeOFgroup(string Kod_group)
        {
            try
            {
                string sql = "SELECT Count_kid FROM group_kid,types_of_group WHERE types_of_group.Kod_typegroup=group_kid.Kod_typegroup AND group_kid.Kod_Group ='" + Kod_group + "';";

                DBConnection.mycommand.CommandText = sql;
                Object rez = DBConnection.mycommand.ExecuteScalar();

                if (rez != null)
                {
                    return Convert.ToInt32(rez);
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}