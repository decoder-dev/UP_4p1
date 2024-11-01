using System;
using System.IO;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Group_kid : Form
    {
        public static string Name;
        public static string nomber;
        public static string type;
        public static string kod;

        public Group_kid()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Group_kid_Load(object sender, EventArgs e)
        {
            DBGet_Group_kid.Get();
            dataGridView1.DataSource = DBGet_Group_kid.Group_kid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Group_kid agk1 = new Add_Group_kid();
            agk1.Show();
        }

        /// <summary>
        /// \Записывается в журнал события
		/// path - путь к txt файлу
		/// Entrance - сегодняшняя дата и время\
        /// Удаления записи в таблице "Группа"
        /// dialogResult - диалоговое окно на подтверждения удаления записи
        /// Delete_group_kid - проверка что запись не используется в другой таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string path = Directory.GetCurrentDirectory();
            path = path + @"\Журнал событий.txt";
            DateTime Entrance = DateTime.Now;

            if (Delete_group_kid.Delete_Proverka(Convert.ToString(kod)) == true)
            {
                DialogResult dialog = MessageBox.Show("Вы уверены что хотите удалить запись?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    DBDelete_Group_kid.Delete(kod);
                    DBGet_Group_kid.Get();
                    File.AppendAllText(path, "\r\n УДАЛЕНИЯ ГРУППЫ   УДАЛИЛ(А):" + DBAuthorization.fio + "  ВРЕМЯ:" + Entrance.ToShortTimeString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kod = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            type = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            nomber = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            Red_group_kid rgk1 = new Red_group_kid();
            rgk1.Show();
        }

        private void списокВыбраннойГруппыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doc_group dg1 = new Doc_group();
            dg1.Show();
        }
    }
}