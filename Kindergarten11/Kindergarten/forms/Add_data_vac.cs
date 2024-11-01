using System;
using System.Data;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Add_data_vac : Form
    {
        public Add_data_vac()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Заполнение comboBox-кса (comboBox1 - имя вакцинации, comboBox2 - ФИО ребенка)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_data_vac_Load(object sender, EventArgs e)
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            DateTime now = DateTime.Now;
            dateTimePicker1.Value = now;
        }

        /// <summary>
        /// Добавление записи в таблицу "vaccination_data"
        ///   Proverka_data_vac - проверка на повторение записи (по коду вакцинации,дате и коду ребенка)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;

            if ((comboBox1.Text != "") && (comboBox2.Text != ""))
            {
                if (Proverka_data_vac.Proverka(comboBox1.SelectedValue.ToString(), date, comboBox2.SelectedValue.ToString()) == true)
                {
                    DBAdd_data_vac.Add(comboBox1.SelectedValue.ToString(), date, comboBox2.SelectedValue.ToString());
                    DBGet_data_vac.Get();
                    this.Close();
                }
            }
        }
    }
}