using System;
using System.Data;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Red_staff : Form
    {
        public static string proverka;

        public Red_staff()
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
            textBox4.Text = "";
            comboBox1.SelectedIndex = -1;
            maskedTextBox1.Text = "";
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8) && (e.KeyChar != 32) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        ///  Заполнение comboBox-кса (
        /// comboBox1 - Должность
        /// )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Red_staff_Load(object sender, EventArgs e)
        {
            string posy = "SELECT Kod_post,Name FROM post;";

            DBConnection.mycommand.CommandText = posy;
            DataTable post = new DataTable();
            post.Clear();
            DBConnection.msDataAdapter.Fill(post);

            comboBox1.DataSource = post;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Kod_post";
            comboBox1.SelectedItem = -1;

            textBox1.Text = Staff.Login;
            textBox4.Text = Staff.FIO;
            maskedTextBox1.Text = Staff.Telephone;
            comboBox1.Text = Staff.Post;
            proverka = Staff.Login;
        }

        /// <summary>
        ///
        /// Редактирование записи в таблицу "Сотрудники"
        /// Proverka_staff_login.Proverka_log - проверка на повторения записи (по полю логина)
        /// Proverka_staff_login.Proverka_telephone - проверка на повтороения записи (по полю телефона)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox4.Text != "") && (maskedTextBox1.Text != ""))
            {
                if (textBox1.Text != proverka)
                {
                    if (Proverka_staff_login.Proverka_log(textBox1.Text) == true)
                    {
                        if (maskedTextBox1.Text.Length == 13)
                        {
                            if (maskedTextBox1.Text != Staff.Telephone)
                            {
                                if (Proverka_staff_login.Proverka_telephone(maskedTextBox1.Text) == true)
                                {
                                    DBRed_staff.Red(textBox4.Text, maskedTextBox1.Text, comboBox1.SelectedValue.ToString(), textBox1.Text, Staff.kod);
                                    DBGet_staff.Get();
                                    this.Close();
                                }
                            }
                            else
                            {
                                DBRed_staff.Red(textBox4.Text, maskedTextBox1.Text, comboBox1.SelectedValue.ToString(), textBox1.Text, Staff.kod);
                                DBGet_staff.Get();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Заполните номер телефона", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    if (maskedTextBox1.Text.Length == 13)
                    {
                        if (maskedTextBox1.Text != Staff.Telephone)
                        {
                            if (Proverka_staff_login.Proverka_telephone(maskedTextBox1.Text) == true)
                            {
                                DBRed_staff.Red(textBox4.Text, maskedTextBox1.Text, comboBox1.SelectedValue.ToString(), textBox1.Text, Staff.kod);
                                DBGet_staff.Get();
                                this.Close();
                            }
                        }
                        else
                        {
                            DBRed_staff.Red(textBox4.Text, maskedTextBox1.Text, comboBox1.SelectedValue.ToString(), textBox1.Text, Staff.kod);
                            DBGet_staff.Get();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните номер телефона", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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