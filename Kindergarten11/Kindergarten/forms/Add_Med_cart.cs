using System;
using System.Data;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Add_Med_cart : Form
    {
        public Add_Med_cart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox2.SelectedIndex = -1;
        }

        /// <summary>
        /// Заполнение comboBox-кса (
        /// comboBox1 - ФИО ребенка
        /// comboBox2 - Группа здоровья
        /// )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Med_cart_Load(object sender, EventArgs e)
        {
            string kid = "SELECT Birth_certificate_nomber,concat(Name,' ',Surname,' ',Patronymic) AS FIO_kid FROM kid;";

            string group_healt = "SELECT health_group.Kod_health_group,health_group.Group FROM health_group;";

            //ФИО дитя
            DBConnection.mycommand.CommandText = kid;
            DataTable kid1 = new DataTable();
            kid1.Clear();
            DBConnection.msDataAdapter.Fill(kid1);

            comboBox1.DataSource = kid1;
            comboBox1.DisplayMember = "FIO_kid";
            comboBox1.ValueMember = "Birth_certificate_nomber";

            comboBox1.SelectedIndex = -1;

            //Группа здоровья

            DBConnection.mycommand.CommandText = group_healt;
            DataTable group_healt1 = new DataTable();
            group_healt1.Clear();
            DBConnection.msDataAdapter.Fill(group_healt1);

            comboBox2.DataSource = group_healt1;
            comboBox2.DisplayMember = "Group";
            comboBox2.ValueMember = "Kod_health_group";

            comboBox2.SelectedIndex = -1;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char nomber = e.KeyChar;
            if ((!Char.IsDigit(nomber)) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char nomber = e.KeyChar;
            if ((!Char.IsDigit(nomber)) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Добавление новой записи в таблицу "Мед карта"
        /// Proverka_med_cart - проверка на повторения записи (по полю свидетельство о рождении)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (comboBox1.Text != "") && (comboBox2.Text != "") && (textBox3.Text != ""))
            {
                if (Proverka_med_cart.Proverka(comboBox1.SelectedValue.ToString()) == true)
                {
                    DBAdd_med_cart.Add(comboBox1.SelectedValue.ToString(), textBox1.Text, textBox2.Text, comboBox2.SelectedValue.ToString(), textBox3.Text);
                    DBGet_Med_cart.Get();
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