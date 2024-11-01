using System;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Add_parents : Form
    {
        public Add_parents()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_parents_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Parents;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "1(мать)")
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
            }
            else
            {
                if (comboBox1.Text == "1(отец)")
                {
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = false;
                }
                else
                {
                    if (comboBox1.Text == "2")
                    {
                        groupBox1.Enabled = true;
                        groupBox2.Enabled = true;
                    }
                }
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char nomber = e.KeyChar;
            if ((!Char.IsDigit(nomber)) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
        }

        /// <summary>
        /// Добавление новой записи в таблицу "Родители"
        ///
        /// Proverka_parents.Proverka_kod - Проверка в таблице "родители" по коду
        /// Proverka_parents.Proverka_telephone_momANDtelephone_dad - Проверка в таблице "родители" по телефону отца и матери
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Выберите количество родителей", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (textBox1.Text.Length != 10 || (textBox1.Text.Length > 10))
                {
                    MessageBox.Show("Заполните паспортные данные", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (comboBox1.SelectedIndex == 1)
                    {
                        if ((textBox1.Text != "") && (textBox8.Text != "") && (textBox7.Text != "") && (textBox9.Text != ""))
                        {
                            if (maskedTextBox2.Text.Length == 13)
                            {
                                if (Proverka_parents.Proverka_kod(textBox1.Text) == true)
                                {
                                    if (Proverka_parents.Proverka_telephone_momANDtelephone_dad(maskedTextBox2.Text, maskedTextBox2.Text) == true)
                                    {
                                        DBAdd_parents.Add(textBox1.Text, null, null, null, textBox7.Text, textBox8.Text, textBox5.Text, null, maskedTextBox2.Text, null, textBox9.Text, "1");
                                        DBGet_parents.Get();
                                        this.Close();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Заполните поле 'Телефон'", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Заполните поля", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (comboBox1.SelectedIndex == 0)
                    {
                        if ((textBox1.Text != "") && (textBox6.Text != "") && (textBox4.Text != "") && (textBox2.Text != ""))
                        {
                            if (maskedTextBox1.Text.Length == 13)
                            {
                                if (Proverka_parents.Proverka_kod(textBox1.Text) == true)
                                {
                                    if (Proverka_parents.Proverka_telephone_momANDtelephone_dad(maskedTextBox1.Text, maskedTextBox1.Text) == true)
                                    {
                                        DBAdd_parents.Add(textBox1.Text, textBox4.Text, textBox6.Text, textBox3.Text, "", "", "", maskedTextBox1.Text, "", textBox2.Text, "", "1");
                                        DBGet_parents.Get();
                                        this.Close();
                                    }
                                    else
                                    {
                                        maskedTextBox2.Text = "";
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Заполните поле 'Телефон'", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Заполните поля", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (comboBox1.SelectedIndex == 2)
                    {
                        if ((textBox1.Text != "") && (textBox6.Text != "") && (textBox4.Text != "") && (textBox2.Text != "") && (maskedTextBox2.Text != "") && (textBox8.Text != "") && (textBox7.Text != "") && (textBox9.Text != ""))
                        {
                            if ((maskedTextBox2.Text.Length == 13) && (maskedTextBox1.Text.Length == 13))
                            {
                                if (Proverka_parents.Proverka_kod(textBox1.Text) == true)
                                {
                                    //string mother_nom = maskedTextBox1.Text;
                                    //string father_nom = maskedTextBox2.Text;
                                    if (Proverka_parents.Proverka_telephone_momANDtelephone_dad(maskedTextBox1.Text, maskedTextBox2.Text) == true)
                                    {
                                        if (Proverka_parents.Proverka_telephone_momANDtelephone_dad(maskedTextBox1.Text, maskedTextBox1.Text) == true)
                                        {
                                            if (Proverka_parents.Proverka_telephone_momANDtelephone_dad(maskedTextBox2.Text, maskedTextBox2.Text) == true)
                                            {
                                                if (maskedTextBox1.Text != maskedTextBox2.Text)
                                                {
                                                    DBAdd_parents.Add(textBox1.Text, textBox4.Text, textBox6.Text, textBox3.Text, textBox7.Text, textBox8.Text, textBox5.Text, maskedTextBox1.Text, maskedTextBox2.Text, textBox2.Text, textBox9.Text, "2");
                                                    DBGet_parents.Get();
                                                    this.Close();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Телефон отца и матери одинаковый", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Заполните поля", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Очистка не активного groupBox-кса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                textBox6.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
                maskedTextBox1.Text = "";
            }

            if (comboBox1.SelectedIndex == 0)
            {
                textBox8.Text = "";
                textBox5.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                maskedTextBox2.Text = "";
            }
        }
    }
}