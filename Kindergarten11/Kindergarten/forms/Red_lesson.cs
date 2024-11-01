using System;
using System.Data;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Red_lesson : Form
    {
        public Red_lesson()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Заполнение comboBox-кса (
        /// comboBox1 - Группа
        /// comboBox2 - ФИО сотрудника
        /// comboBox6 - Дисциплина
        /// )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Red_lesson_Load(object sender, EventArgs e)
        {
            string group = "SELECT Kod_Group,Name FROM group_kid;";
            string FIO_staff = "SELECT Kod_staff,FIO FROM staff;";
            string dist = "SELECT Kod_Discipline,Name_dist FROM discipline;";

            //Группа
            DBConnection.mycommand.CommandText = group;
            DataTable gro = new DataTable();

            gro.Clear();
            DBConnection.msDataAdapter.Fill(gro);

            comboBox1.DataSource = gro;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Kod_Group";

            comboBox1.SelectedIndex = -1;

            //ФИО сотрудника
            DBConnection.mycommand.CommandText = FIO_staff;
            DataTable FIO = new DataTable();

            FIO.Clear();
            DBConnection.msDataAdapter.Fill(FIO);

            comboBox2.DataSource = FIO;
            comboBox2.DisplayMember = "FIO";
            comboBox2.ValueMember = "Kod_staff";

            comboBox2.SelectedIndex = -1;

            //Дисциплина
            DBConnection.mycommand.CommandText = dist;
            DataTable d = new DataTable();

            d.Clear();
            DBConnection.msDataAdapter.Fill(d);

            comboBox3.DataSource = d;
            comboBox3.DisplayMember = "Name_dist";
            comboBox3.ValueMember = "Kod_Discipline";

            comboBox3.SelectedIndex = -1;

            comboBox1.Text = Lessons.Group;
            comboBox2.Text = Lessons.FIO_staff;
            comboBox3.Text = Lessons.Disctiplin;
            dateTimePicker1.Value = Lessons.date_lesson;
            textBox1.Text = Lessons.hour;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

            textBox1.Text = "";

            DateTime date = DateTime.Now;
            dateTimePicker1.Value = date;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((!Char.IsDigit(number)) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Редактирования записи в таблицу "Занятия" за недельный период времени (От Пн до Пт)
        ///
        /// weekBefore,weekUp - переменный для подсчета недельнего периода
        /// Find_hour_dist_fromlessonsproverka - находит стандартное значения кол-во часов выбранной дисциплины, который учитель должен провести за недельный период
        /// Proverka_hour_lesson.Proverka - проверят сколько часов, выбранной дисциплины, за недельный период времени было уже проведено
        /// Proverka_hour_lesson.Hour - переменна, которая хранит кол-во часов выбранной дисциплины, за недельный период времени, которые были уже проведены
        /// Find_hour_dist_fromlessonsproverka.Hour_dist - переменная, которая хранит стандартное значения часов выбранной дисциплины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            DateTime weekBefore = date;
            DateTime weekUp = date;

            //int i, n;
            //DateTime[] mass = new DateTime[7];
            //n = 7;

            //DateTime weekBefore = date.AddDays(-1);

            //for (i = 0; i < 7; i++)
            //{
            //    if ((weekBefore.DayOfWeek.ToString() == "Saturday") || (weekBefore.DayOfWeek.ToString() == "Sunday"))
            //    {
            //        weekBefore = weekBefore.AddDays(-1);
            //        i--;
            //    }
            //    else
            //    {
            //        mass[i] = weekBefore;
            //        weekBefore = weekBefore.AddDays(-1);
            //    }
            //}

            //for (i = 0; i < 7; i++)
            //{
            //	textBox2.Text += mass[i].ToString() + "\r\n";

            //}

            //MessageBox.Show(mass[6].ToString());
            if ((date.DayOfWeek.ToString() == "Saturday") || (date.DayOfWeek.ToString() == "Sunday"))
            {
                MessageBox.Show("Нельзя добавлять занятия в субботу или воскресенья", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (date.DayOfWeek.ToString() == "Monday")
                {
                    weekBefore = date;
                    weekUp = date.AddDays(4);
                }
                if (date.DayOfWeek.ToString() == "Tuesday")
                {
                    weekBefore = date.AddDays(-1);
                    weekUp = date.AddDays(3);
                }
                if (date.DayOfWeek.ToString() == "Wednesday")
                {
                    weekBefore = date.AddDays(-2);
                    weekUp = date.AddDays(2);
                }
                if (date.DayOfWeek.ToString() == "Thursday")
                {
                    weekBefore = date.AddDays(-3);
                    weekUp = date.AddDays(1);
                }
                if (date.DayOfWeek.ToString() == "Friday")
                {
                    weekBefore = date.AddDays(-4);
                    weekUp = date;
                }

                if ((comboBox1.Text != "") && (comboBox2.Text != "") && (comboBox3.Text != "") && (textBox1.Text != ""))
                {
                    if (Convert.ToInt32(textBox1.Text) == 0)
                    {
                        MessageBox.Show("Количество часов должно быть больше 0", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Find_hour_dist_fromlessonsproverka.Find(comboBox3.Text);
                        Proverka_hour_lesson.Proverka(comboBox3.SelectedValue.ToString(), comboBox1.SelectedValue.ToString(), weekBefore, weekUp);

                        int vcego = (Proverka_hour_lesson.Hour - Convert.ToInt32(Lessons.hour)) + Convert.ToInt32(textBox1.Text);

                        if (vcego > Find_hour_dist_fromlessonsproverka.Hour_dist)
                        {
                            MessageBox.Show("Превышено количество часов", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (Convert.ToInt32(textBox1.Text) > Find_hour_dist_fromlessonsproverka.Hour_dist)
                            {
                                MessageBox.Show("Превышено количество часов", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DBRed_lesson.Red(comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString(), date, textBox1.Text, Lessons.Kod);
                                DBGet_lessons.Get();
                                this.Close();
                            }
                        }
                    }
                }
            }
        }
    }
}