using System;
using System.Data;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Red_data_vac : Form
    {
        public static string FIOkid;
        public static DateTime date2;
        public static string Name_v;

        public Red_data_vac()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Заполнение comboBox-кса (comboBox1 - имя вакцинации, comboBox2 - ФИО ребенка)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Red_data_vac_Load(object sender, EventArgs e)
        {
            string vac = "SELECT Kod_vaccination,Name FROM vaccinations;";
            string kid = "SELECT Birth_certificate_nomber,concat(kid.Name,' ',kid.Surname,' ',kid.Patronymic) AS FIO_kid FROM deti.kid;";

            //Вакцинация
            DBConnection.mycommand.CommandText = vac;
            DataTable v = new DataTable();
            DBConnection.msDataAdapter.Fill(v);

            comboBox1.DataSource = v;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Kod_vaccination";
            comboBox1.SelectedIndex = -1;

            //ФИО ребенка
            DBConnection.mycommand.CommandText = kid;
            DataTable k = new DataTable();
            DBConnection.msDataAdapter.Fill(k);

            comboBox2.DataSource = k;
            comboBox2.DisplayMember = "FIO_kid";
            comboBox2.ValueMember = "Birth_certificate_nomber";
            comboBox2.SelectedIndex = -1;

            comboBox1.Text = Data_vaccination.Name_vac;
            Name_v = Data_vaccination.Name_vac; ;
            comboBox2.Text = Data_vaccination.FIO_kid;
            FIOkid = Data_vaccination.FIO_kid;
            dateTimePicker1.Value = Data_vaccination.date;
            date2 = Data_vaccination.date;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            DateTime now = DateTime.Now;
            dateTimePicker1.Value = now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Редактирование записи в таблицу "vaccination_data"
        ///   Proverka_data_vac - проверка на повторение записи (по коду вакцинации,дате и коду ребенка)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime date1 = dateTimePicker1.Value;

            if ((comboBox1.Text != "") && (comboBox2.Text != ""))
            {
                if ((comboBox1.Text != Name_v) || (comboBox2.Text != FIOkid) || (dateTimePicker1.Value != date2))
                {
                    if (Proverka_data_vac.Proverka(comboBox1.SelectedValue.ToString(), date1, comboBox2.SelectedValue.ToString()) == true)
                    {
                        DBRed_data_vac.Red(comboBox1.SelectedValue.ToString(), date1, comboBox2.SelectedValue.ToString(), Data_vaccination.kod1);
                        DBGet_data_vac.Get();
                        this.Close();
                    }
                }
                else
                {
                    DBRed_data_vac.Red(comboBox1.SelectedValue.ToString(), date1, comboBox2.SelectedValue.ToString(), Data_vaccination.kod1);
                    DBGet_data_vac.Get();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните поля", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}