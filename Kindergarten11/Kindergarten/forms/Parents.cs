using System;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Parents : Form
    {
        public static string Kod_p;
        public static string Surname_mom;
        public static string Name_mom;
        public static string Patronymic_mom;
        public static string Surname_dad;
        public static string Name_dad;
        public static string Patronymic_dad;
        public static string telephone_mom;
        public static string telephone_dad;
        public static string Place_work_mom;
        public static string Place_work_dad;
        public static string Number_parents;

        public Parents()
        {
            InitializeComponent();
        }

        private void Parents_Load(object sender, EventArgs e)
        {
            DBGet_parents.Get();
            dataGridView1.DataSource = DBGet_parents.dtParents;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_parents ap1 = new Add_parents();
            ap1.Show();
        }

        /// <summary>
        /// Удаления записи в таблице "Родиетли"
        /// dialogResult - диалоговое окно на подтверждения удаления записи
        ///Delete_proverka_parents - проверка что запись не используется в другой таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string kod_p = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (Delete_proverka_parents.Delete_Proverka(kod_p) == true)
            {
                DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    DBDelete_parents.Delete(kod_p);
                    DBGet_parents.Get();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kod_p = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Name_dad = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Surname_dad = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Patronymic_dad = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Name_mom = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Surname_mom = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            Patronymic_mom = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            telephone_dad = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            telephone_mom = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            Place_work_mom = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            Place_work_dad = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            Number_parents = dataGridView1.CurrentRow.Cells[11].Value.ToString();

            Red_parents rp1 = new Red_parents();
            rp1.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8) && (e.KeyChar != 32))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Фильтрация по ФИО отца и матери
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Filter_parents.Filter(textBox1.Text);
        }
    }
}