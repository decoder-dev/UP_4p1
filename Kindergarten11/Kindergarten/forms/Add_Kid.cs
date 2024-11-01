using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Add_Kid : Form
    {
        public Add_Kid()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Заполнение comboBox-кса (
        /// comboBox1 - ФИО отца
        /// comboBox2 - тип группы
        /// comboBox6 - ФИО матери
        /// )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Kid_Load(object sender, EventArgs e)
        {
            // textBox6.Text = "2314572489";
            label8.Text = "Выберите тип группы";
            comboBox7.Enabled = false;
            string type_group = "SELECT Kod_typegroup,Name FROM deti.types_of_group;";
            string group = "SELECT Kod_Group,Name FROM group_kid;";
            string FIO_dad = "Select Kod_p,concat(parents.Name_dad,' ',parents.Surname_dad,' ',parents.Patronymic_dad)AS FIO_dad from parents;";
            string Fio_mom = "Select Kod_p,concat(parents.Name_mom,' ',parents.Surname_mom,' ',parents.Patronymic_mom)AS FIO_mom from parents;";

            //заполнить группу
            //DBConnection.mycommand.CommandText = group;
            // DataTable dt = new DataTable();
            // DBConnection.msDataAdapter.Fill(dt);

            //    comboBox7.DataSource = dt;
            //    comboBox7.DisplayMember = "Name";// столбец для отображения
            //    comboBox7.ValueMember = "Kod_Group";//столбец с id
            //    comboBox7.SelectedIndex = -1;

            //Тип группы
            DBConnection.mycommand.CommandText = type_group;
            DataTable type = new DataTable();
            DBConnection.msDataAdapter.Fill(type);

            comboBox2.DataSource = type;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Kod_typegroup";
            comboBox2.SelectedIndex = -1;

            //ФИО отца
            DBConnection.mycommand.CommandText = FIO_dad;
            DataTable dad = new DataTable();
            DBConnection.msDataAdapter.Fill(dad);

            comboBox1.DataSource = dad;
            comboBox1.DisplayMember = "FIO_dad";
            comboBox1.ValueMember = "Kod_p";
            comboBox1.SelectedIndex = -1;

            //ФИО матери
            DBConnection.mycommand.CommandText = Fio_mom;
            DataTable mom = new DataTable();
            DBConnection.msDataAdapter.Fill(mom);

            comboBox6.DataSource = mom;
            comboBox6.DisplayMember = "FIO_mom";
            comboBox6.ValueMember = "Kod_p";
            comboBox6.SelectedIndex = -1;
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char nomber = e.KeyChar;
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8) && (!Char.IsDigit(nomber)) && (e.KeyChar != 32) && (e.KeyChar != '.') && (e.KeyChar != ',') && (e.KeyChar != ';') && (e.KeyChar != ':'))
            {
                e.Handled = true;
            }
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

        /// <summary>
        /// Поиск паспортных данных одного из родителей по двум comboBox-ксам (ФИО отца и матери)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                MessageBox.Show("Выберите значения");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// \Записывается в журнал события
		/// path - путь к txt файлу
		/// Entrance - сегодняшняя дата и время\
        /// Добавления новой записи в таблицу "ребенок"
        ///     Проверки:
        ///     Кол-во детей в группе (Filter_kid)
        ///     Возраст (Proverka_kid(AGE_FROM,AGE_UP))
        ///     Пустые поля
        ///     на повторения записи по полю свидетельство о рождении (Proverka_kid.Proverka)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            DateTime today = DateTime.Today;

            int age = today.Year - date.Year;
            string path = Directory.GetCurrentDirectory();
            path = path + @"\Журнал событий.txt";
            DateTime Exit = DateTime.Now;

            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (comboBox7.Text != "") && (textBox5.Text != "") && (textBox6.Text != ""))
            {
                Proverka_kid.AGE_FROM(comboBox2.Text);
                Proverka_kid.AGE_UP(comboBox2.Text);

                if ((age >= Proverka_kid.age_from) && (age <= Proverka_kid.age_up))
                {
                    int count = Filter_kid.Count_kidOFgroup(comboBox7.SelectedValue.ToString()) + 1;
                    int countTypeGroup = Filter_kid.Count_kid_typeOFgroup(comboBox7.SelectedValue.ToString());
                    if (Proverka_kid.Proverka(textBox1.Text) == true)
                    {
                        if (count > countTypeGroup)
                        {
                            MessageBox.Show("Количество детей в группе достигло максимума", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DBAdd_kid.Add(textBox1.Text, textBox3.Text, textBox2.Text, textBox4.Text, textBox5.Text, textBox6.Text, comboBox7.SelectedValue.ToString(), date);
                            DBGet_kid.Get();
                            this.Close();

                            File.AppendAllText(path, "\r\nДОБАВЛЕНИЕ НОВОГО РЕБЕНКА" + textBox2.Text + " " + textBox3.Text + " " + textBox4.Text + "  ДОБАВИЛ(А):" + DBAuthorization.fio + "  ВРЕМЯ:" + Exit.ToShortTimeString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неверный возраст", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Заполните поля", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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