using System;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Redpost : Form
    {
        public Redpost()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8) && (e.KeyChar != 32))
            {
                e.Handled = true;
            }
        }

        private void Redpost_Load(object sender, EventArgs e)
        {
            textBox1.Text = Post.name;
        }

        /// <summary>
        /// Редактирование записи в справочник "должность"
        /// Proverkapost - проверка на повторения записи (по полю названия должности)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (Proverkapost.Proverka(textBox1.Text) == true)
                {
                    DBRed_post.Red(textBox1.Text, Post.kod);
                    DBGet_Post.Get();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните поле", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}