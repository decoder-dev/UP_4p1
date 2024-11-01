using System;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Group_healt : Form
    {
        public static string group;
        public static string kod;

        public Group_healt()
        {
            InitializeComponent();
        }

        private void Group_healt_Load(object sender, EventArgs e)
        {
            DBGet_group_healt.Get();
            dataGridView1.DataSource = DBGet_group_healt.dtHealt;
        }

        /// <summary>
        /// Удаления записи в таблице "Группа здоровья"
        /// dialogResult - диалоговое окно на подтверждения удаления записи
        ///Delete_proverka_Group_healt - проверка что запись не используется в другой таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string kod = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (Delete_proverka_Group_healt.Delete_Proverka(kod) == true)
            {
                DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    string kod1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                    DBDelete_healt_group.Delete(kod1);
                    DBGet_group_healt.Get();
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
            group = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            Red_health_group rhg1 = new Red_health_group();
            rhg1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_group_healt agh1 = new Add_group_healt();
            agh1.Show();
        }
    }
}