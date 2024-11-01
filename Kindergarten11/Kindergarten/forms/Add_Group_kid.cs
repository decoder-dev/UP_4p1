using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Add_Group_kid : Form
    {
        public Add_Group_kid()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8) && (e.KeyChar != 32))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Заполнение comboBox-кса (comboBox1 - имя типа группы)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Group_kid_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM types_of_group;";

            DBConnection.mycommand.CommandText = sql;
            DataTable type = new DataTable();

            type.Clear();
            DBConnection.msDataAdapter.Fill(type);

            comboBox1.DataSource = type;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Kod_typegroup";
            comboBox1.SelectedIndex = -1;
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
        /// \Записывается в журнал события
        /// path - путь к txt файлу
        /// Entrance - сегодняшняя дата и время\
        /// Добавление новой записи в таблицу "Группы"
        /// Proverka_group_kid - проверка на повторении записи (по полю название группы и номера кабинета)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path = path + @"\Журнал событий.txt";
            DateTime Entrance = DateTime.Now;

            if ((textBox1.Text != "") && (textBox2.Text != "") && (comboBox1.SelectedIndex != -1))
            {
                if (Proverka_group_kid.Proverka(textBox1.Text, textBox2.Text) == true)
                {
                    int nom = Convert.ToInt32(textBox2.Text);
                    DBAdd_Group_kid.Add(textBox1.Text, Convert.ToInt32(comboBox1.SelectedValue.ToString()), nom);
                    DBGet_Group_kid.Get();
                    this.Close();
                    File.AppendAllText(path, "\r\n ДОБАВЛЕНИЯ НОВОЙ ГРУППЫ" + textBox1.Text + "   ДОБАВИЛ(А):" + DBAuthorization.fio + "  ВРЕМЯ:" + Entrance.ToShortTimeString());
                }
            }
            else
            {
                MessageBox.Show("Заполните поля", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}