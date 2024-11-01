using System;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Vaccination : Form
    {
        public static string nname;
        public static string kod;

        public Vaccination()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Vaccination_Load(object sender, EventArgs e)
        {
            DBGet_vaccination.Getvac();
            dataGridView1.DataSource = DBGet_vaccination.dtVaccination;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_vaccination ad1 = new Add_vaccination();
            ad1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nname = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            kod = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Red_vaccination red1 = new Red_vaccination();
            red1.Show();
        }

        /// <summary>
        /// Удаления записи в таблице "Вакцина"
        /// dialogResult - диалоговое окно на подтверждения удаления записи
        /// Delete_vactin - проверка что запись не используется в другой таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            kod = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (Delete_vactin.Delete_Proverka(kod) == true)
            {
                DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    DBDelete_vaction.delete(kod);
                    DBGet_vaccination.Getvac();
                }
            }
        }
    }
}