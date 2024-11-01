using System;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Red_dist : Form
    {
        public static string proverka;

        public Red_dist()
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8) && (e.KeyChar != 32))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char nomder = e.KeyChar;
            if ((!Char.IsDigit(nomder)) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Редактирование новой записи в таблицу "дисциплина"
        ///  Proverka_dist - проверка на повторение записи (по полю "название дисциплины")
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
                if (textBox1.Text != proverka)
                {
                    if (Convert.ToInt32(textBox2.Text) <= 5)
                    {
                        if (Proverka_dist.Proverka(textBox1.Text) == true)
                        {
                            DBRed_dist.Red(textBox2.Text, textBox1.Text, Discipline.kod);
                            DBGetDistiplin.Get();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Количество часов привышенно", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (Convert.ToInt32(textBox2.Text) <= 5)
                    {
                        DBRed_dist.Red(textBox2.Text, textBox1.Text, Discipline.kod);
                        DBGetDistiplin.Get();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Количество часов привышенно", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните поля", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Red_dist_Load(object sender, EventArgs e)
        {
            textBox1.Text = Discipline.name;
            textBox2.Text = Discipline.time;
            proverka = Discipline.name;
        }
    }
}