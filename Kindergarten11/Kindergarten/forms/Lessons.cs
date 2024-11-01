using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using word = Microsoft.Office.Interop.Word;

namespace Kindergarten
{
    public partial class Lessons : Form
    {
        public static string Kod;
        public static string Group;
        public static string FIO_staff;
        public static string Disctiplin;
        public static DateTime date_lesson;
        public static string hour;

        public Lessons()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Заполнение comboBox-кса (
        /// comboBox1 - Группа )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lessons_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            DBGet_lessons.Get();
            dataGridView1.DataSource = DBGet_lessons.dtLesson;

            string group = "SELECT Kod_Group,Name FROM group_kid;";
            string date = "SELECT Kod_Lessons,Date_lesson FROM lessons;";

            //группа
            DBConnection.mycommand.CommandText = group;
            DataTable group_kid = new DataTable();
            DBConnection.msDataAdapter.Fill(group_kid);

            comboBox1.DataSource = group_kid;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Kod_Group";

            comboBox1.SelectedIndex = -1;

            ////date
            //DBConnection.mycommand.CommandText = date;
            //DataTable date_s = new DataTable();
            //DBConnection.msDataAdapter.Fill(date_s);

            //comboBox2.DataSource = date_s;
            //comboBox2.DisplayMember = "Date_lesson";
            //comboBox2.ValueMember = "Kod_Lessons";

            //comboBox2.SelectedIndex = -1;

            //comboBox3.DataSource = date_s;
            //comboBox3.DisplayMember = "Date_lesson";
            //comboBox3.ValueMember = "Kod_Lessons";

            //comboBox3.SelectedIndex = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Удаления в таблице "Занятия"
        /// dialogResult - диалоговое окно на подтверждения удаления записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string kod = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                DBDelete_lesson.Delete(kod);
                DBGet_lessons.Get();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_lessons al1 = new Add_lessons();
            al1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kod = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Group = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            FIO_staff = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Disctiplin = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            date_lesson = DateTime.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            hour = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            Red_lesson rl1 = new Red_lesson();
            rl1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DBGet_lessons.Get();
            comboBox1.SelectedIndex = -1;
        }

        /// <summary>
        /// Фильтрация по группе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            Filter_Group_lesson.Filter(comboBox1.SelectedValue.ToString());
        }

        /// <summary>
        /// Фильтрация периоду даты проведенных занятий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            DateTime s = dateTimePicker1.Value;
            DateTime en = dateTimePicker2.Value;

            Filter_date_lesson.Filter(s, en);
            // Filter_lesson_date.Filter();
        }

        /// <summary>
        /// Сортировка по сотрудникам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void сотрудникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Cortirovka_lesson.Filter(1);
            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    Cortirovka_lesson.Filter(0);
                }
            }
        }

        /// <summary>
        /// Формирования выходного документа "Отчет о проведенных занятиях за недельный период времени" в Word-е
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void отчетОПроведенныхЗанятияхЗаНедельныйПериодВремениToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value == dateTimePicker2.Value)
            {
                MessageBox.Show("Укажите в фильтрации недельный период времени", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DateTime dateFrom = dateTimePicker1.Value;
                DateTime dateUp = dateTimePicker2.Value;
                if ((dateUp.DayOfWeek.ToString() == "Saturday" || dateUp.DayOfWeek.ToString() == "Sunday") || (dateFrom.DayOfWeek.ToString() == "Saturday" || dateFrom.DayOfWeek.ToString() == "Sunday"))
                {
                    MessageBox.Show("Нельзя выбирать занятия в субботу или воскресенья", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (dateFrom < dateUp)
                    {
                        if (Output_documents.Lesson(dateFrom, dateUp) == true)
                        {
                            DateTime date = DateTime.Now;
                            DateTime DataShort = date;
                            var app = new word.Application();
                            app.Visible = false;
                            string path = Directory.GetCurrentDirectory();

                            var doc = app.Documents.Open(path + @"\Отчет о проведенных занятиях за недельный период времени.docx"); // открыли файл Word, который является как бы
                                                                                                                                    // шаблоном и содержит закладки
                            doc.Activate();
                            doc.Bookmarks["Date_creation"].Range.Text = ' ' + date.ToShortDateString();// заполнили закладки, созданные в Wordе
                            doc.Bookmarks["FIO_Head"].Range.Text = ' ' + DBAuthorization.fio;
                            doc.Bookmarks["date_from"].Range.Text = dateFrom.ToShortDateString();
                            doc.Bookmarks["date_up"].Range.Text = dateUp.ToShortDateString();
                            // doc.Bookmarks["Group"].Range.Font =  new Font("Times New Roman",12,FontStyle.Regular);
                            doc.Bookmarks["Group"].Range.Text = Output_documents.Group_lesson;
                            doc.Bookmarks["Staff"].Range.Text = Output_documents.Staff_lesson;
                            doc.Bookmarks["Dist"].Range.Text = Output_documents.Dist_lesson;
                            doc.Bookmarks["Date_dist"].Range.Text = Output_documents.Date_dist_lesson;
                            doc.Bookmarks["hour"].Range.Text = Output_documents.Hour_lesson;

                            doc.Saved = true;
                            doc.SaveAs2(path + @"\Отчет о проведенных занятиях за недельный период времени2.docx"); // сохранили файл со вставками в закладки под новым именем
                            MessageBox.Show("Данные сохранены в новом doc-файле!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            doc.SaveAs2(path + @"\Отчет о проведенных занятиях за недельный период времени3.pdf", word.WdSaveFormat.wdFormatPDF); // сохранили файл со вставками в
                                                                                                                                                  // закладки под новым именем в pdf
                            MessageBox.Show("Данные сохранены в новом pdf-файле!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            doc.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неккоретно выбран диапозон даты", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}