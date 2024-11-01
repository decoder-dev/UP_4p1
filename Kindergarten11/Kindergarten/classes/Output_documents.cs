using MySql.Data.MySqlClient;
using System;

namespace Kindergarten
{
    internal class Output_documents
    {
        public static string Group_lesson;
        public static string Staff_lesson;
        public static string Dist_lesson;
        public static string Date_dist_lesson;
        public static string Hour_lesson;

        /// <summary>
        /// Запросы для формирования выходных docx документов "Информация о выбранном ребенке" и "Отчет о проведенных занятиях за недельный период времени"
        /// </summary>
        /// <param name="Kid"></param>
        /// <returns></returns>
        public static string Post_medcart_infoKid(string Kid)
        {
            string s = "";
            DBConnection.mycommand.CommandText = "SELECT Height FROM medical_card WHERE Birth_certificate_nomber='" + Kid + "';";
            MySqlDataReader reader_tovar = DBConnection.mycommand.ExecuteReader();

            if (reader_tovar.HasRows)
            {
                while (reader_tovar.Read())
                {
                    object tov = reader_tovar["Height"];
                    s = s + tov.ToString();
                }
                reader_tovar.Close();
                return s;
            }
            return s;
        }

        public static string Vec_medcart_infoKid(string Kid)
        {
            string s = "";
            DBConnection.mycommand.CommandText = "SELECT Weight FROM medical_card WHERE Birth_certificate_nomber='" + Kid + "';";
            MySqlDataReader reader_tovar = DBConnection.mycommand.ExecuteReader();

            if (reader_tovar.HasRows)
            {
                while (reader_tovar.Read())
                {
                    object tov = reader_tovar["Weight"];
                    s = s + tov.ToString();
                }
                reader_tovar.Close();
                return s;
            }
            return s;
        }

        public static string Healt_group_medcart_infoKid(string Kid)
        {
            string s = "";
            DBConnection.mycommand.CommandText = "SELECT health_group.Group FROM medical_card,health_group WHERE medical_card.Kod_health_group = health_group.Kod_health_group AND medical_card.Birth_certificate_nomber='" + Kid + "';";
            MySqlDataReader reader_tovar = DBConnection.mycommand.ExecuteReader();

            if (reader_tovar.HasRows)
            {
                while (reader_tovar.Read())
                {
                    object tov = reader_tovar["Group"];
                    s = s + tov.ToString();
                }
                reader_tovar.Close();
                return s;
            }
            return s;
        }

        public static string Xpon_medcart_infoKid(string Kid)
        {
            string s = "";
            DBConnection.mycommand.CommandText = "SELECT Chronic_diseases FROM medical_card WHERE Birth_certificate_nomber='" + Kid + "';";
            MySqlDataReader reader_tovar = DBConnection.mycommand.ExecuteReader();

            if (reader_tovar.HasRows)
            {
                while (reader_tovar.Read())
                {
                    object tov = reader_tovar["Chronic_diseases"];
                    s = s + tov.ToString();
                }
                reader_tovar.Close();
                return s;
            }
            return s;
        }

        public static string Place_workDAD_parents_infoKid(string Kid)
        {
            string s = "";
            DBConnection.mycommand.CommandText = "SELECT parents.Place_of_work_dad FROM kid,parents WHERE parents.Kod_p = kid.Kod_p AND Birth_certificate_nomber ='" + Kid + "';";
            MySqlDataReader reader_tovar = DBConnection.mycommand.ExecuteReader();

            if (reader_tovar.HasRows)
            {
                while (reader_tovar.Read())
                {
                    object tov = reader_tovar["Place_of_work_dad"];
                    s = s + tov.ToString();
                }
                reader_tovar.Close();
                return s;
            }
            return s;
        }

        public static string Place_workMOM_parents_infoKid(string Kid)
        {
            string s = "";
            DBConnection.mycommand.CommandText = "SELECT parents.Place_of_work_mom FROM kid,parents WHERE parents.Kod_p = kid.Kod_p AND Birth_certificate_nomber ='" + Kid + "';";
            MySqlDataReader reader_tovar = DBConnection.mycommand.ExecuteReader();

            if (reader_tovar.HasRows)
            {
                while (reader_tovar.Read())
                {
                    object tov = reader_tovar["Place_of_work_mom"];
                    s = s + tov.ToString();
                }
                reader_tovar.Close();
                return s;
            }
            return s;
        }

        public static bool Lesson(DateTime start, DateTime end)
        {
            string sql = @"SELECT group_kid.Name,staff.FIO, discipline.Name_dist,lessons.Date_lesson,lessons.Hlong_hour
								FROM lessons,group_kid,discipline,staff where lessons.Kod_Group = group_kid.Kod_Group AND lessons.Kod_Discipline = discipline.Kod_Discipline
								AND lessons.Kod_staff = staff.Kod_staff AND DATE(lessons.Date_lesson) BETWEEN '" + start.ToString("yy-MM-dd") + "' AND '" + end.ToString("yy-MM-dd") + "';";
            DBConnection.mycommand.CommandText = sql;

            object rezKod_p = DBConnection.mycommand.ExecuteScalar();

            if (rezKod_p != null)
            {
                MySqlDataReader reader_tovar = DBConnection.mycommand.ExecuteReader();

                if (reader_tovar.HasRows)
                {
                    while (reader_tovar.Read())
                    {
                        object group = reader_tovar["Name"];
                        Group_lesson = Group_lesson + group.ToString() + "\r\n";

                        object staff = reader_tovar["FIO"];
                        Staff_lesson = Staff_lesson + staff.ToString() + "\r\n";

                        object dist = reader_tovar["Name_dist"];
                        Dist_lesson = Dist_lesson + dist.ToString() + "\r\n";

                        object date = reader_tovar["Date_lesson"];
                        DateTime Date_D = Convert.ToDateTime(date);
                        Date_dist_lesson = Date_dist_lesson + Date_D.ToShortDateString() + "\r\n";

                        object hour = reader_tovar["Hlong_hour"];
                        Hour_lesson = Hour_lesson + hour.ToString() + "\r\n";
                    }
                    reader_tovar.Close();
                    return true;
                }
                return true;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Записей не найдено", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return false;
            }
        }
    }
}