using System;
using System.IO;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Discipline : Form
    {
        public static string kod;
        public static string name;
        public static string time;

        public Discipline()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Discipline_Load(object sender, EventArgs e)
        {
            DBGetDistiplin.Get();
            dataGridView1.DataSource = DBGetDistiplin.Distplin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Distiplin ad1 = new Add_Distiplin();
            ad1.Show();
        }

        /// <summary>
        /// \Записывается в журнал события
		/// path - путь к txt файлу
		/// Entrance - сегодняшняя дата и время\
        /// Удаления записи в таблице "Дисциплина"
        /// dialogResult - диалоговое окно на подтверждения удаления записи
        /// Delete_dist.Delete_Proverka - проверка что запись не используется в другой таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string kod = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string path = Directory.GetCurrentDirectory();
            path = path + @"\Журнал событий.txt";
            DateTime Entrance = DateTime.Now;

            if (Delete_dist.Delete_Proverka(kod) == true)
            {
                DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите удалить запись?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    DBDelete_Dist.Delete(Convert.ToInt32(kod));
                    DBGetDistiplin.Get();
                    File.AppendAllText(path, "\r\n УДАЛЕНИЯ ДИСЦИПЛИНЫ   УДАЛИЛ(А):" + DBAuthorization.fio + "  ВРЕМЯ:" + Entrance.ToShortTimeString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kod = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            time = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            Red_dist d1 = new Red_dist();
            d1.Show();
        }
    }
}