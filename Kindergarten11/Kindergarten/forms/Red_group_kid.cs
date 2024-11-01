using System;
using System.Data;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Red_group_kid : Form
    {
        public static string proverka;

        public Red_group_kid()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        /// <summary>
        /// Заполнение comboBox-кса (comboBox1 - имя типа группы)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Red_group_kid_Load(object sender, EventArgs e)
        {
            textBox1.Text = Group_kid.Name;
            textBox2.Text = Group_kid.nomber;
            proverka = Group_kid.Name;

            string sql = "SELECT * FROM types_of_group;";
            DBConnection.mycommand.CommandText = sql;

            DataTable type = new DataTable();
            type.Clear();
            DBConnection.msDataAdapter.Fill(type);

            comboBox1.DataSource = type;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Kod_typegroup";

            comboBox1.Text = Group_kid.type;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8) && (e.KeyChar != 32))
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Редактирование записи в таблицу "Группы"
        /// Proverka_group_kid - проверка на повторении записи (по полю название группы и номера кабинета)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
                if (textBox1.Text != proverka)
                {
                    if (Proverka_group_kid.Proverka(textBox1.Text, textBox2.Text) == true)
                    {
                        DBRed_group_kid.Red(textBox1.Text, comboBox1.SelectedValue.ToString(), textBox2.Text, Group_kid.kod);
                        DBGet_Group_kid.Get();
                        this.Close();
                    }
                }
                else
                {
                    if (Proverka_group_kid.Proverka(" ", textBox2.Text) == true)
                    {
                        DBRed_group_kid.Red(textBox1.Text, comboBox1.SelectedValue.ToString(), textBox2.Text, Group_kid.kod);
                        DBGet_Group_kid.Get();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните поля", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8) && (e.KeyChar != 32))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char nomber = e.KeyChar;
            if ((!Char.IsDigit(nomber)) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }
    }
}