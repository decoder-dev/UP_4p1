using System;
using System.IO;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Red_info_staff : Form
    {
        public Red_info_staff()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((!Char.IsDigit(number)) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// \Записывается в журнал события
		/// path - путь к txt файлу
		/// Exit - сегодняшняя дата и время\
        /// Редактирования пароля в таблице "Сотрудники"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
            {
                Red_staff_password.Red(textBox1.Text, Form1.log);
                MessageBox.Show("Пароль изменен", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

                string path = Directory.GetCurrentDirectory();
                path = path + @"\Журнал событий.txt";
                DateTime Exit = DateTime.Now;
                File.AppendAllText(path, "\r\nИЗМЕНЕНИЕ ПАРОЛЯ  СОТРУДНИК:" + DBAuthorization.fio + "  ВРЕМЯ:" + Exit.ToShortTimeString());
            }
            else
            {
                MessageBox.Show("Пароли не совпадают", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}