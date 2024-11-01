using System;
using System.IO;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Add_type_group : Form
    {
        public Add_type_group()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        /// <summary>
        /// \Записывается в журнал события
		/// path - путь к txt файлу
		/// Entrance - сегодняшняя дата и время\
        ///
        /// Добавления новой записи в таблицу "Типа группы"
        /// Proverka_typegroup - проверка на повторения записи (по полю названия типа группы)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path = path + @"\Журнал событий.txt";
            DateTime Entrance = DateTime.Now;

            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != ""))
            {
                if (Proverka_typegroup.Proverka(textBox1.Text) == true)
                {
                    if (Convert.ToInt32(textBox4.Text) > 20)
                    {
                        MessageBox.Show("Максимальное кол-во детей в группе - 20 ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DBAdd_typegroup.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                        DBGet_type_group.Get();
                        this.Close();
                        File.AppendAllText(path, "\r\n ДОБАВЛЕНИЯ НОВОГО ТИПА ГРУППЫ" + textBox1.Text + "   ДОБАВИЛ(А):" + DBAuthorization.fio + "  ВРЕМЯ:" + Entrance.ToShortTimeString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните поле", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8) && (e.KeyChar != 32) && (!Char.IsDigit(number)))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char nomber = e.KeyChar;
            if ((!Char.IsDigit(nomber)) && (e.KeyChar != 8) && (e.KeyChar != 32))
            {
                e.Handled = true;
            }
        }
    }
}