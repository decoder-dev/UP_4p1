using System;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Add_group_healt : Form
    {
        public Add_group_healt()
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
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Добавление новой записи в справочник "health_group"
        /// Proverka_health_group - проверка на повторение записи (по полю номера группы здоровья)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (Proverka_health_group.Proverka(textBox1.Text) == true)
                {
                    DBAdd_healt_group.Add(textBox1.Text);
                    DBGet_group_healt.Get();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните поле", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Add_group_healt_Load(object sender, EventArgs e)
        {
        }
    }
}