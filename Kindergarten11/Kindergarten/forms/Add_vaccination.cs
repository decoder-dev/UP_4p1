using System;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Add_vaccination : Form
    {
        public Add_vaccination()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8) && (e.KeyChar != 32))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Добавления новой записи  в справочник "Вакцинация"
        /// Proverka_vaccination - проверка на повторения записи (по полю названия вакцинации)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (Proverka_vaccination.Proverka(textBox1.Text) == true)
                {
                    DBAdd_vaction.Add(textBox1.Text);
                    DBGet_vaccination.Getvac();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните поле", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Add_vaccination_Load(object sender, EventArgs e)
        {
        }
    }
}