using System;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Red_parents : Form
    {
        public static int proverka = 0;//0-все хорошо 1 - есть повторения

        public Red_parents()
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

        private void Red_parents_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Parents;
            textBox1.Text = Parents.Kod_p;
            if ((Parents.Name_dad == "") && (Parents.Name_mom != ""))
            {
                comboBox1.SelectedIndex = 0;
                groupBox1.Enabled = false;

                textBox6.Text = Parents.Name_mom;
                textBox4.Text = Parents.Surname_mom;
                textBox3.Text = Parents.Patronymic_mom;
                maskedTextBox1.Text = Parents.telephone_mom;
                textBox2.Text = Parents.Place_work_mom;
            }

            if ((Parents.Name_dad != "") && (Parents.Name_mom == ""))
            {
                comboBox1.SelectedIndex = 1;
                groupBox2.Enabled = false;

                textBox8.Text = Parents.Name_dad;
                textBox7.Text = Parents.Surname_dad;
                textBox5.Text = Parents.Patronymic_dad;
                maskedTextBox2.Text = Parents.telephone_dad;
                textBox9.Text = Parents.Place_work_dad;
            }

            if ((Parents.Name_dad != "") && (Parents.Name_mom != ""))
            {
                comboBox1.SelectedIndex = 2;

                textBox6.Text = Parents.Name_mom;
                textBox4.Text = Parents.Surname_mom;
                textBox3.Text = Parents.Patronymic_mom;
                maskedTextBox1.Text = Parents.telephone_mom;
                textBox2.Text = Parents.Place_work_mom;

                textBox8.Text = Parents.Name_dad;
                textBox7.Text = Parents.Surname_dad;
                textBox5.Text = Parents.Patronymic_dad;
                maskedTextBox2.Text = Parents.telephone_dad;
                textBox9.Text = Parents.Place_work_dad;
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Редактирование записи в таблицу "Родители"
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
                proverka = 1;
            }
            else
            {
                if ((textBox1.Text.Length != 10) || (textBox1.Text.Length > 10))
                {
                    MessageBox.Show("Заполните паспортные данные", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    proverka = 1;
                }
                else
                {
                    //Отец
                    if (comboBox1.SelectedIndex == 1)
                    {
                        if ((textBox8.Text != "") && (textBox7.Text != "") && (textBox9.Text != ""))
                        {
                            if (maskedTextBox2.Text.Length == 13)
                            {
                                if (textBox1.Text != Parents.Kod_p)
                                {
                                    if (Proverka_parents.Proverka_kod(textBox1.Text) == true)
                                    {
                                        if (maskedTextBox2.Text != Parents.telephone_dad)
                                        {
                                            if (Proverka_parents.Proverka_telephone_momANDtelephone_dad(maskedTextBox2.Text, maskedTextBox2.Text) == true)
                                            {
                                                DBRed_parents.Red(Parents.Kod_p, "", "", "", textBox7.Text, textBox8.Text, textBox5.Text, "", maskedTextBox2.Text, "", textBox9.Text, "1", textBox1.Text);
                                                DBGet_parents.Get();
                                                this.Close();
                                            }
                                        }
                                        else
                                        {
                                            DBRed_parents.Red(Parents.Kod_p, "", "", "", textBox7.Text, textBox8.Text, textBox5.Text, "", maskedTextBox2.Text, "", textBox9.Text, "1", textBox1.Text);
                                            DBGet_parents.Get();
                                            this.Close();
                                        }
                                    }
                                }
                                else
                                {
                                    DBRed_parents.Red(Parents.Kod_p, "", "", "", textBox7.Text, textBox8.Text, textBox5.Text, "", maskedTextBox2.Text, "", textBox9.Text, "1", textBox1.Text);
                                    DBGet_parents.Get();
                                    this.Close();
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

                    //Мать
                    if (comboBox1.SelectedIndex == 0)
                    {
                        if ((textBox6.Text != "") && (textBox4.Text != "") && (textBox2.Text != ""))
                        {
                            if (maskedTextBox1.Text.Length == 13)
                            {
                                if (textBox1.Text != Parents.Kod_p)
                                {
                                    if (Proverka_parents.Proverka_kod(textBox1.Text) == true)
                                    {
                                        if (maskedTextBox1.Text != Parents.telephone_mom)
                                        {
                                            if (Proverka_parents.Proverka_telephone_momANDtelephone_dad(maskedTextBox1.Text, maskedTextBox1.Text) == true)
                                            {
                                                DBRed_parents.Red(Parents.Kod_p, textBox4.Text, textBox6.Text, textBox3.Text, "", "", "", maskedTextBox1.Text, "", textBox2.Text, "", "1", textBox1.Text);
                                                DBGet_parents.Get();
                                                this.Close();
                                            }
                                        }
                                        else
                                        {
                                            DBRed_parents.Red(Parents.Kod_p, textBox4.Text, textBox6.Text, textBox3.Text, "", "", "", maskedTextBox1.Text, "", textBox2.Text, "", "1", textBox1.Text);
                                            DBGet_parents.Get();
                                            this.Close();
                                        }
                                    }
                                }
                                else
                                {
                                    DBRed_parents.Red(Parents.Kod_p, textBox4.Text, textBox6.Text, textBox3.Text, "", "", "", maskedTextBox1.Text, "", textBox2.Text, "", "1", textBox1.Text);
                                    DBGet_parents.Get();
                                    this.Close();
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
                    // Оба родителя
                    if (comboBox1.SelectedIndex == 2)
                    {
                        if ((textBox6.Text != "") && (textBox4.Text != "") && (textBox2.Text != "") && (maskedTextBox2.Text != "") && (textBox8.Text != "") && (textBox7.Text != "") && (textBox9.Text != ""))
                        {
                            if ((maskedTextBox2.Text.Length == 13) && (maskedTextBox1.Text.Length == 13))
                            {
                                if (textBox1.Text != Parents.Kod_p)
                                {
                                    if (Proverka_parents.Proverka_kod(textBox1.Text) == true)
                                    {
                                        if ((maskedTextBox1.Text != Parents.telephone_mom) || (maskedTextBox2.Text != Parents.telephone_dad))
                                        {
                                            if (Proverka_parents.Proverka_telephone_momANDtelephone_dad(maskedTextBox1.Text, maskedTextBox2.Text) == true)
                                            {
                                                if (Proverka_parents.Proverka_telephone_momANDtelephone_dad(maskedTextBox1.Text, maskedTextBox1.Text) == true)
                                                {
                                                    if (Proverka_parents.Proverka_telephone_momANDtelephone_dad(maskedTextBox2.Text, maskedTextBox2.Text) == true)
                                                    {
                                                        if (maskedTextBox2.Text != maskedTextBox1.Text)
                                                        {
                                                            DBRed_parents.Red(Parents.Kod_p, textBox4.Text, textBox6.Text, textBox3.Text, textBox7.Text, textBox8.Text, textBox5.Text, maskedTextBox1.Text, maskedTextBox2.Text, textBox2.Text, textBox9.Text, "2", textBox1.Text);
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
                                        else
                                        {
                                            if (maskedTextBox1.Text != maskedTextBox2.Text)
                                            {
                                                DBRed_parents.Red(Parents.Kod_p, textBox4.Text, textBox6.Text, textBox3.Text, textBox7.Text, textBox8.Text, textBox5.Text, maskedTextBox1.Text, maskedTextBox2.Text, textBox2.Text, textBox9.Text, "2", textBox1.Text);
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
                                else
                                {
                                    if ((maskedTextBox1.Text != Parents.telephone_mom) || (maskedTextBox2.Text != Parents.telephone_dad))
                                    {
                                        if (Proverka_parents.Proverka_telephone_momANDtelephone_dad(maskedTextBox1.Text, maskedTextBox2.Text) == true)
                                        {
                                            if (Proverka_parents.Proverka_telephone_momANDtelephone_dad(maskedTextBox1.Text, maskedTextBox1.Text) == true)
                                            {
                                                if (Proverka_parents.Proverka_telephone_momANDtelephone_dad(maskedTextBox2.Text, maskedTextBox2.Text) == true)
                                                {
                                                    if (maskedTextBox2.Text != maskedTextBox1.Text)
                                                    {
                                                        DBRed_parents.Red(Parents.Kod_p, textBox4.Text, textBox6.Text, textBox3.Text, textBox7.Text, textBox8.Text, textBox5.Text, maskedTextBox1.Text, maskedTextBox2.Text, textBox2.Text, textBox9.Text, "2", textBox1.Text);
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
                                    else
                                    {
                                        if (maskedTextBox1.Text != maskedTextBox2.Text)
                                        {
                                            DBRed_parents.Red(Parents.Kod_p, textBox4.Text, textBox6.Text, textBox3.Text, textBox7.Text, textBox8.Text, textBox5.Text, maskedTextBox1.Text, maskedTextBox2.Text, textBox2.Text, textBox9.Text, "2", textBox1.Text);
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
                }
            }
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