using System;
using System.IO;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Types_of_group : Form
    {
        public static string kod;
        public static string name;
        public static string age_from;
        public static string age_up;
        public static string count_kid;

        public Types_of_group()
        {
            InitializeComponent();
        }

        private void Types_of_group_Load(object sender, EventArgs e)
        {
            DBGet_type_group.Get();
            dataGridView1.DataSource = DBGet_type_group.dtType_Group;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_type_group adtp1 = new Add_type_group();
            adtp1.Show();
        }

        /// <summary>
        /// \Записывается в журнал события
		/// path - путь к txt файлу
		/// Entrance - сегодняшняя дата и время\
        /// Удаления записи в таблице "Тип группы"
        /// dialogResult - диалоговое окно на подтверждения удаления записи
        /// Delete_proverka_type_group - проверка что запись не используется в другой таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string kod = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string path = Directory.GetCurrentDirectory();
            path = path + @"\Журнал событий.txt";
            DateTime Entrance = DateTime.Now;

            if (Delete_proverka_type_group.Delete_Proverka(kod) == true)
            {
                DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    string kod1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    DBDelete_typegroup.Delete(kod1);
                    DBGet_type_group.Get();
                    File.AppendAllText(path, "\r\n УДАЛЕНИЯ ТИПА ГРУППЫ   УДАЛИЛ(А):" + DBAuthorization.fio + "  ВРЕМЯ:" + Entrance.ToShortTimeString());
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kod = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            age_from = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            age_up = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            count_kid = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            Red_typegroup ry1 = new Red_typegroup();
            ry1.Show();
        }
    }
}