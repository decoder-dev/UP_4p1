using System;
using System.IO;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Form1 : Form
    {
        public static string log;
        public static string password;
        public static string FIO;
        public static string Telephone;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// \Записывается вход/ошибка авторизации пользователя в журнал события
		/// path - путь к txt файлу
		/// Entrance - сегодняшняя дата и время\
        /// Авторизация пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
                string path = Directory.GetCurrentDirectory();
                path = path + @"\Журнал событий.txt";
                DateTime Entrance = DateTime.Now;
                DBAuthorization.Authorization(textBox1.Text, textBox2.Text);
                DBAuthorization.FIO(textBox1.Text, textBox2.Text);
                DBAuthorization.Telephone(textBox1.Text, textBox2.Text);

                log = textBox1.Text;
                password = textBox2.Text;
                FIO = DBAuthorization.fio;
                Telephone = DBAuthorization.telephone;

                switch (DBConnection.Role)
                {
                    case 0:
                        MessageBox.Show("Неверные данные", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        File.AppendAllText(path, "\r\n" + Entrance.ToShortDateString() + "\r\nОШИБКА АВТОРИЗАЦИИ  ВРЕМЯ:" + Entrance.ToShortTimeString());
                        break;

                    case 1:
                        MessageBox.Show("Добро пожаловать, " + DBAuthorization.fio, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Menu_mentor m1 = new Menu_mentor();
                        m1.Show();
                        File.AppendAllText(path, "\r\n" + Entrance.ToShortDateString() + "\r\nВХОД:" + DBAuthorization.fio + "  ВРЕМЯ:" + Entrance.ToShortTimeString());
                        break;

                    case 4:
                        MessageBox.Show("Добро пожаловать, " + DBAuthorization.fio, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Menu_head m2 = new Menu_head();
                        m2.Show();
                        File.AppendAllText(path, "\r\n" + Entrance.ToShortDateString() + "\r\nВХОД:" + DBAuthorization.fio + "  ВРЕМЯ:" + Entrance.ToShortTimeString());
                        break;

                    case 2:
                        MessageBox.Show("Неверные данные", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        File.AppendAllText(path, "\r\n" + Entrance.ToShortDateString() + "\r\nОШИБКА АВТОРИЗАЦИИ  ВРЕМЯ:" + Entrance.ToShortTimeString());
                        break;

                    case 3:
                        MessageBox.Show("Неверные данные", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        File.AppendAllText(path, "\r\n" + Entrance.ToShortDateString() + "\r\nОШИБКА АВТОРИЗАЦИИ  ВРЕМЯ:" + Entrance.ToShortTimeString());
                        break;

                    case 5:
                        MessageBox.Show("Добро пожаловать, " + DBAuthorization.fio, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Menu_Medsetsra m3 = new Menu_Medsetsra();
                        m3.Show();
                        File.AppendAllText(path, "\r\n" + Entrance.ToShortDateString() + "\r\nВХОД:" + DBAuthorization.fio + "  ВРЕМЯ:" + Entrance.ToShortTimeString());
                        break;
                }
            }
            else
            {
                MessageBox.Show("Заполните поля");
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (DBConnection.connect_BD() == false)
            {
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        /// <summary>
        /// \Записывается выход пользователя в журнал события
		/// path - путь к txt файлу
		/// Exit - сегодняшняя дата и время\
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button3_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path = path + @"\Журнал событий.txt";
            DateTime Exit = DateTime.Now;
            File.AppendAllText(path, "\r\nВЫХОД:" + DBAuthorization.fio + "  ВРЕМЯ:" + Exit.ToShortTimeString());
            this.Close();
        }
    }
}