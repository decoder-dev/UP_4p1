using System;
using System.Data;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Red_kid : Form
    {
        public Red_kid()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Заполнение comboBox-кса (
        /// comboBox7 - Группа
        /// comboBox1 - ФИО отца
        /// comboBox2 - тип группы
        /// comboBox6 - ФИО матери
        /// )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Red_kid_Load(object sender, EventArgs e)
        {
            textBox1.Text = Kid.Nomder_certific;
            textBox2.Text = Kid.Namekid;
            textBox3.Text = Kid.Surnamekid;
            textBox4.Text = Kid.Patronymickid;
            textBox5.Text = Kid.Place;
            dateTimePicker1.Value = Kid.dateBith;
            DBGet_add_parents.Get(Kid.FIO_dad, Kid.FIO_mom);
            textBox6.Text = DBGet_add_parents.Pasport;

            label8.Text = "Выберите тип группы";

            string group = "SELECT Kod_Group,Name FROM group_kid;";
            string FIO_dad = "Select Kod_p,concat(parents.Name_dad,' ',parents.Surname_dad,' ',parents.Patronymic_dad)AS FIO_dad from parents;";
            string Fio_mom = "Select Kod_p,concat(parents.Name_mom,' ',parents.Surname_mom,' ',parents.Patronymic_mom)AS FIO_mom from parents;";
            string type_group = "SELECT Kod_typegroup,Name FROM deti.types_of_group;";
            DBConnection.mycommand.CommandText = group;
            DataTable dt = new DataTable();
            DBConnection.msDataAdapter.Fill(dt);
            comboBox7.DataSource = dt;
            comboBox7.DisplayMember = "Name";
            comboBox7.ValueMember = "Kod_Group";
            comboBox7.SelectedIndex = -1;
            DBConnection.mycommand.CommandText = type_group;
            DataTable type = new DataTable();
            DBConnection.msDataAdapter.Fill(type);
            comboBox2.DataSource = type;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Kod_typegroup";
            comboBox2.SelectedIndex = -1;
            DBConnection.mycommand.CommandText = FIO_dad;
            DataTable dad = new DataTable();
            DBConnection.msDataAdapter.Fill(dad);
            comboBox1.DataSource = dad;
            comboBox1.DisplayMember = "FIO_dad";
            comboBox1.ValueMember = "Kod_p";
            comboBox1.SelectedIndex = -1;
            DBConnection.mycommand.CommandText = Fio_mom;
            DataTable mom = new DataTable();
            DBConnection.msDataAdapter.Fill(mom);

            comboBox6.DataSource = mom;
            comboBox6.DisplayMember = "FIO_mom";
            comboBox6.ValueMember = "Kod_p";
            comboBox6.SelectedIndex = -1;

            comboBox7.Text = Kid.Group;
            comboBox1.Text = Kid.FIO_dad;
            comboBox6.Text = Kid.FIO_mom;

            Find_type_group.Proverka(Kid.Group);

            comboBox2.Text = Find_type_group.Type;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char nomber = e.KeyChar;
            if ((!Char.IsDigit(nomber)) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox7.SelectedIndex = -1;
            textBox5.Text = "";
            comboBox1.SelectedIndex = -1;

            comboBox6.SelectedIndex = -1;
            textBox6.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((comboBox1.Text != "") && (comboBox6.Text != ""))
            {
                DBGet_add_parents.Get(comboBox1.Text, comboBox6.Text);
                textBox6.Text = DBGet_add_parents.Pasport;

                //MessageBox.Show(comboBox1.Text, comboBox6.Text);
            }
            else
            {
                MessageBox.Show("Выберите значения", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        ///  Редактирование записи в таблице "Ребенок"
        ///   Проверки:
        ///     Кол-во детей в группе (Filter_kid)
        ///     Возраст (Proverka_kid(AGE_FROM,AGE_UP))
        ///     Пустые поля
        ///     на повторения записи по полю свидетельство о рождении (Proverka_kid.Proverka)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (comboBox7.Text != "") && (textBox5.Text != "") && (textBox6.Text != ""))
            {
                DateTime date = dateTimePicker1.Value;
                DateTime today = DateTime.Today;

                int age = today.Year - date.Year;

                int count = Filter_kid.Count_kidOFgroup(comboBox7.SelectedValue.ToString()) + 1;
                int countTypeGroup = Filter_kid.Count_kid_typeOFgroup(comboBox7.SelectedValue.ToString());

                Proverka_kid.AGE_FROM(comboBox2.Text);
                Proverka_kid.AGE_UP(comboBox2.Text);

                if ((age >= Proverka_kid.age_from) && (age <= Proverka_kid.age_up))
                {
                    if (textBox1.Text != Kid.Nomder_certific)
                    {
                        if (Proverka_kid.Proverka(textBox1.Text) == true)
                        {
                            if (comboBox7.Text != Kid.Group)
                            {
                                if (count > countTypeGroup)
                                {
                                    MessageBox.Show("Количество детей в группе достигло максимума", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    DBRed_kid.Red(Kid.Nomder_certific, textBox1.Text, textBox3.Text, textBox2.Text, textBox4.Text, textBox5.Text, textBox6.Text, comboBox7.SelectedValue.ToString(), date);
                                    DBGet_kid.Get();
                                    this.Close();
                                }
                            }
                            else
                            {
                                DBRed_kid.Red(Kid.Nomder_certific, textBox1.Text, textBox3.Text, textBox2.Text, textBox4.Text, textBox5.Text, textBox6.Text, comboBox7.SelectedValue.ToString(), date);
                                DBGet_kid.Get();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        if (comboBox7.Text != Kid.Group)
                        {
                            if (count > countTypeGroup)
                            {
                                MessageBox.Show("Количество детей в группе достигло максимума", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DBRed_kid.Red(Kid.Nomder_certific, textBox1.Text, textBox3.Text, textBox2.Text, textBox4.Text, textBox5.Text, textBox6.Text, comboBox7.SelectedValue.ToString(), date);
                                DBGet_kid.Get();
                                this.Close();
                            }
                        }
                        else
                        {
                            DBRed_kid.Red(Kid.Nomder_certific, textBox1.Text, textBox3.Text, textBox2.Text, textBox4.Text, textBox5.Text, textBox6.Text, comboBox7.SelectedValue.ToString(), date);
                            DBGet_kid.Get();
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неккоретный возраст", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Заполните поля", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox5_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char nomber = e.KeyChar;
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8) && (!Char.IsDigit(nomber)) && (e.KeyChar != 32) && (e.KeyChar != '.') && (e.KeyChar != ',') && (e.KeyChar != ';') && (e.KeyChar != ':'))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char nomber = e.KeyChar;
            if ((!Char.IsDigit(nomber)) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// В зависимости от выбора из comboBox2-кса типа группы, в comboBox7 будут отображаться группы, соотвествующей выбранной типа группы
        /// Например:
        ///  comboBox2 = Ясельная группа
        ///  comboBox7 = Пчела,Утконосы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox7.Enabled = true;
            label8.Text = "";
            string type = comboBox2.SelectedValue.ToString();
            Add_kid_type_group.Type(type);

            comboBox7.DataSource = Add_kid_type_group.dt;
            comboBox7.DisplayMember = "Name";// столбец для отображения
            comboBox7.ValueMember = "Kod_Group";//столбец с id
            comboBox7.SelectedIndex = -1;
        }
    }
}