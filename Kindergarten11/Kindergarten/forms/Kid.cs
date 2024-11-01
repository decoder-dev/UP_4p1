using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using word = Microsoft.Office.Interop.Word;

namespace Kindergarten
{
    public partial class Kid : Form
    {
        public static string FIO_dad;
        public static string FIO_mom;

        public static string Nomder_certific;
        public static string Namekid;
        public static string Surnamekid;
        public static string Patronymickid;

        public static string Place;
        public static string Group;
        public static DateTime dateBith;

        public Kid()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Заполнение comboBox-кса (
        /// comboBox1 - Группа
        /// )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kid_Load(object sender, EventArgs e)
        {
            DBGet_kid.Get();
            dataGridView1.DataSource = DBGet_kid.dtKid;

            string Group = "SELECT Kod_Group,Name FROM group_kid;";

            //Группа
            DBConnection.mycommand.CommandText = Group;
            DataTable groupkid = new DataTable();
            DBConnection.msDataAdapter.Fill(groupkid);

            comboBox1.DataSource = groupkid;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Kod_Group";
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Kid ak1 = new Add_Kid();
            ak1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nomder_certific = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Namekid = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Surnamekid = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Patronymickid = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Place = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Group = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dateBith = DateTime.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            FIO_dad = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            FIO_mom = dataGridView1.CurrentRow.Cells[8].Value.ToString();

            Red_kid rk = new Red_kid();
            rk.Show();
        }

        /// <summary>
        /// \Записывается в журнал события
		/// path - путь к txt файлу
		/// Entrance - сегодняшняя дата и время\
        /// Удаления записи в таблице "Ребенок"
        /// dialogResult - диалоговое окно на подтверждения удаления записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string kod = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            string path = Directory.GetCurrentDirectory();
            path = path + @"\Журнал событий.txt";
            DateTime Entrance = DateTime.Now;

            DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите удалить запись?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                DBDelete_kid.Delete(kod);
                DBGet_kid.Get();
                File.AppendAllText(path, "\r\n УДАЛЕНИЯ РЕБЕНКА   УДАЛИЛ(А)" + DBAuthorization.fio + "  ВРЕМЯ:" + Entrance.ToShortTimeString());
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void сорToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Фильтрация по ФИО ребенка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Filter_kid.Filter_Fio_kid(textBox1.Text);
        }

        /// <summary>
        /// Фильтрация по группе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                Filter_kid.Filter_Group(comboBox1.SelectedValue.ToString());

                textBox2.Text = Convert.ToString(Filter_kid.Count_kidOFgroup(comboBox1.SelectedValue.ToString()));
            }
            else
            {
                MessageBox.Show("Выберите группу", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DBGet_kid.Get();
            comboBox1.SelectedIndex = -1;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8) && (e.KeyChar != 32))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Формирования выходного документа "Информация о выбранном ребенке" в Word-е
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void информацияОРебенкеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            DateTime DataShort = date;
            var app = new word.Application();
            app.Visible = false;
            string path = Directory.GetCurrentDirectory();
            var doc = app.Documents.Open(path + @"\Информация о выбранном ребенке.docx"); // открыли файл Word, который является как бы
                                                                                          // шаблоном и содержит закладки
            doc.Activate();
            doc.Bookmarks["Date_creation"].Range.Text = ' ' + date.ToShortDateString();// заполнили закладки, созданные в Wordе
            doc.Bookmarks["FIO_Head"].Range.Text = ' ' + DBAuthorization.fio;
            doc.Bookmarks["FIO_kid"].Range.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString() + ' ' + dataGridView1.CurrentRow.Cells[2].Value.ToString() + ' ' + dataGridView1.CurrentRow.Cells[3].Value.ToString();
            DataShort = DateTime.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            doc.Bookmarks["Kid_date"].Range.Text = DataShort.ToShortDateString();
            doc.Bookmarks["Kid_place"].Range.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            doc.Bookmarks["Kid_group"].Range.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            doc.Bookmarks["Kid_post"].Range.Text = Output_documents.Post_medcart_infoKid(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            doc.Bookmarks["Kid_vec"].Range.Text = Output_documents.Vec_medcart_infoKid(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            doc.Bookmarks["Kid_group_healt"].Range.Text = Output_documents.Healt_group_medcart_infoKid(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            doc.Bookmarks["Kid_xpon"].Range.Text = Output_documents.Xpon_medcart_infoKid(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            doc.Bookmarks["Father_FIO"].Range.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            doc.Bookmarks["Father_place_work"].Range.Text = Output_documents.Place_workDAD_parents_infoKid(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            doc.Bookmarks["Father_telephone"].Range.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            doc.Bookmarks["Mather_FIO"].Range.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            doc.Bookmarks["Mather_place_work"].Range.Text = Output_documents.Place_workMOM_parents_infoKid(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            doc.Bookmarks["Mather_telephone"].Range.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();

            doc.Saved = true;
            doc.SaveAs2(path + @"\Информация о выбранном ребенке2.docx"); // сохранили файл со вставками в закладки под новым именем
            MessageBox.Show("Данные сохранены в новом doc-файле!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            doc.SaveAs2(path + @"\Информация о выбранном ребенке3.pdf", word.WdSaveFormat.wdFormatPDF); // сохранили файл со вставками в
                                                                                                        // закладки под новым именем в pdf
            MessageBox.Show("Данные сохранены в новом pdf-файле!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            doc.Close();
        }

        /// <summary>
        /// Формирования выходного excel документа "Список детей, имеющих одного родителя в семье"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void списокДетейИмеющегоОдногоРодителяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Excel_doc_kid_psrent.GetGroup() == true)
            {
                Excel_doc_kid_psrent.SqlToExcels();
            }
        }
    }
}