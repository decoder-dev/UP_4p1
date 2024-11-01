using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Add_staff : Form
    {
        public Add_staff()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Заполнение comboBox-кса (
        /// comboBox1 - Должность
        /// )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_staff_Load(object sender, EventArgs e)
        {
            string posy = "SELECT Kod_post,Name FROM post;";

            DBConnection.mycommand.CommandText = posy;
            DataTable post = new DataTable();
            post.Clear();
            DBConnection.msDataAdapter.Fill(post);

            comboBox1.DataSource = post;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Kod_post";
            comboBox1.SelectedItem = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8) && (e.KeyChar != 32) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedIndex = -1;
            maskedTextBox1.Text = "";
        }

        /// <summary>
        /// \Записывается в журнал события
		/// path - путь к txt файлу
		/// Entrance - сегодняшняя дата и время\
        ///
        /// Добавления новой записи в таблицу "Сотрудники"
        /// Proverka_staff_login.Proverka_log - проверка на повторения записи (по полю логина)
        /// Proverka_staff_login.Proverka_telephone - проверка на повтороения записи (по полю телефона)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path = path + @"\Журнал событий.txt";
            DateTime Entrance = DateTime.Now;
            if ((textBox1.Text != "") && (textBox4.Text != "") && (maskedTextBox1.Text != ""))
            {
                if (maskedTextBox1.Text.Length == 13)
                {
                    if (Proverka_staff_login.Proverka_log(textBox1.Text) == true)
                    {
                        if (Proverka_staff_login.Proverka_telephone(maskedTextBox1.Text) == true)
                        {
                            DBAdd_staff.Add(textBox4.Text, maskedTextBox1.Text, comboBox1.SelectedValue.ToString(), textBox1.Text);
                            DBGet_staff.Get();
                            this.Close();
                            File.AppendAllText(path, "\r\n ДОБАВЛЕНИЯ НОВОГО СОТРУДНИКА" + textBox1.Text + "   ДОБАВИЛ(А):" + DBAuthorization.fio + "  ВРЕМЯ:" + Entrance.ToShortTimeString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Заполните номер телефона", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Заполните поля", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}