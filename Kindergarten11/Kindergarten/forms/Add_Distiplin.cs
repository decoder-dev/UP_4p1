using System;
using System.IO;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Add_Distiplin : Form
    {
        public Add_Distiplin()
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
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char nomder = e.KeyChar;
            if ((!Char.IsDigit(nomder)) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8) && (e.KeyChar != 32))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// \Записывается в журнал события
        /// path - путь к txt файлу
        /// Entrance - сегодняшняя дата и время\
        /// Добавление новой записи в таблицу "дисциплина"
        ///  Proverka_dist - проверка на повторение записи (по полю "название дисциплины")
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path = path + @"\Журнал событий.txt";
            DateTime Entrance = DateTime.Now;

            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
                if (Convert.ToInt32(textBox2.Text) <= 5)
                {
                    if (Proverka_dist.Proverka(textBox1.Text) == true)
                    {
                        DBAdd_dist.Add(textBox1.Text, Convert.ToInt32(textBox2.Text));
                        DBGetDistiplin.Get();
                        this.Close();
                        File.AppendAllText(path, "\r\n ДОБАВЛЕНИЯ НОВОЙ ДИСЦИПЛИНЫ " + textBox1.Text + "   ДОБАВИЛ(А):" + DBAuthorization.fio + "  ВРЕМЯ:" + Entrance.ToShortTimeString());
                    }
                }
                else
                {
                    MessageBox.Show("Количество часов привышенно", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Заполните поля", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Add_Distiplin_Load(object sender, EventArgs e)
        {
        }
    }
}