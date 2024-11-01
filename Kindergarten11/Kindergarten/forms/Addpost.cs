using System;
using System.IO;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Addpost : Form
    {
        public Addpost()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
        /// Добавления новой записи в справочник "должность"
        /// Proverkapost - проверка на повторения записи (по полю названия должности)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path = path + @"\Журнал событий.txt";
            DateTime Entrance = DateTime.Now;
            if (textBox1.Text != "")
            {
                if (Proverkapost.Proverka(textBox1.Text) == true)
                {
                    DBAdd_post.Add(textBox1.Text);
                    DBGet_Post.Get();
                    this.Close();
                    File.AppendAllText(path, "\r\n ДОБАВЛЕНИЯ НОВОЙ ДОЛЖНОСТИ" + textBox1.Text + "   ДОБАВИЛ(А):" + DBAuthorization.fio + "  ВРЕМЯ:" + Entrance.ToShortTimeString());
                }
            }
            else
            {
                MessageBox.Show("Заполните поле", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}