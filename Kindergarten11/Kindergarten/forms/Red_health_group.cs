using System;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Red_health_group : Form
    {
        public Red_health_group()
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

        private void Red_health_group_Load(object sender, EventArgs e)
        {
            textBox1.Text = Group_healt.group;
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
        /// Редактирование новой записи в справочник "health_group"
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
                    DBRed_healt_group.Red(textBox1.Text, Group_healt.kod);
                    DBGet_group_healt.Get();
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