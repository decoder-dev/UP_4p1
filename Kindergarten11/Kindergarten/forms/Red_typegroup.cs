using System;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Red_typegroup : Form
    {
        public Red_typegroup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
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

        private void Red_typegroup_Load(object sender, EventArgs e)
        {
            textBox1.Text = Types_of_group.name;
            textBox2.Text = Types_of_group.age_from;
            textBox3.Text = Types_of_group.age_up;
            textBox4.Text = Types_of_group.count_kid;
        }

        /// <summary>
        ///
        /// Редактирование записи в таблицу "Типа группы"
        /// Proverka_typegroup - проверка на повторения записи (по полю названия типа группы)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != Types_of_group.name)
            {
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
                            DBRed_type_group.Red(textBox1.Text, textBox2.Text, textBox3.Text, Types_of_group.kod, textBox4.Text);
                            DBGet_type_group.Get();
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поле", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != ""))
                {
                    if (Convert.ToInt32(textBox4.Text) > 25)
                    {
                        MessageBox.Show("Максимальное кол-во детей в группе - 25 ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DBRed_type_group.Red(textBox1.Text, textBox2.Text, textBox3.Text, Types_of_group.kod, textBox4.Text);
                        DBGet_type_group.Get();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поле", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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