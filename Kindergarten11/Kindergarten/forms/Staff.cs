using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Staff : Form
    {
        public static string kod;
        public static string FIO;
        public static string Telephone;
        public static string Post;
        public static string Login;

        public Staff()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///  Заполнение comboBox-кса (
        /// comboBox1 - Должность
        /// )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Staff_Load(object sender, EventArgs e)
        {
            // dataGridView1.Columns['Column7'].DisplayIndex = 6;
            radioButton1.Checked = true;
            DBGet_staff.Get();
            dataGridView1.DataSource = DBGet_staff.dtStaff;
            string post = "SELECT Kod_post,Name FROM post;";

            //Должность
            DBConnection.mycommand.CommandText = post;
            DataTable post_staff = new DataTable();
            DBConnection.msDataAdapter.Fill(post_staff);

            comboBox1.DataSource = post_staff;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Kod_post";
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_staff ad1 = new Add_staff();
            ad1.Show();
            MessageBox.Show("Пароль по умолчанию : 1", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        ///  \Записывается в журнал события
        /// path - путь к txt файлу
        /// Entrance - сегодняшняя дата и время\
        /// Удаления записи в таблице "Сотрудники" (по кнопке на форме)
        /// dialogResult - диалоговое окно на подтверждения удаления записи
        /// Delete_staff - проверка что запись не используется в другой таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string kod1 = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            string path = Directory.GetCurrentDirectory();
            path = path + @"\Журнал событий.txt";
            DateTime Entrance = DateTime.Now;
            if (Delete_staff.Delete_Proverka(kod1) == true)
            {
                DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить запись ? ", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    DBDelete_staff.delete(kod1);
                    DBGet_staff.Get();
                    File.AppendAllText(path, "\r\n УДАЛЕНИЯ СОТРУДНИКА   УДАЛИЛ(А):" + DBAuthorization.fio + "  ВРЕМЯ:" + Entrance.ToShortTimeString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kod = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            FIO = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Telephone = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Post = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Login = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            Red_staff s1 = new Red_staff();
            s1.Show();
        }

        /// <summary>
        /// Фильтрация по должности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                Filter_staff.Filter_group(comboBox1.Text);
            }
            else
            {
                MessageBox.Show("Выберите должность", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DBGet_staff.Get();
        }

        /// <summary>
        /// Сортировка по ФИО сотрудников
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void фИОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Filter_staff.Cortirovka_FIO_staff(0);
            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    Filter_staff.Cortirovka_FIO_staff(1);
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        /// <summary>
        ///  \Записывается в журнал события
		/// path - путь к txt файлу
		/// Entrance - сегодняшняя дата и время\
        /// Удаления записи в таблице "Сотрудники" (по кнопке в таблице)
        /// dialogResult - диалоговое окно на подтверждения удаления записи
        /// Delete_staff - проверка что запись не используется в другой таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string kod1 = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                string path = Directory.GetCurrentDirectory();
                path = path + @"\Журнал событий.txt";
                DateTime Entrance = DateTime.Now;
                if (Delete_staff.Delete_Proverka(kod1) == true)
                {
                    DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить запись ? ", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes)
                    {
                        DBDelete_staff.delete(kod1);
                        DBGet_staff.Get();
                        File.AppendAllText(path, "\r\n УДАЛЕНИЯ СОТРУДНИКА   УДАЛИЛ(А):" + DBAuthorization.fio + "  ВРЕМЯ:" + Entrance.ToShortTimeString());
                    }
                }
            }
        }
    }
}