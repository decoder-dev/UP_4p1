using System;
using System.Data;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Med_cart : Form
    {
        public static string kod;
        public static string FIO_kid;
        public static string Post;
        public static string Vec;
        public static string Group_healt;
        public static string xpon;

        public Med_cart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Заполнение comboBox-кса (
        /// comboBox1 - ФИО ребенка
        /// comboBox2 - Группа здоровья
        /// )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Med_cart_Load(object sender, EventArgs e)
        {
            DBGet_Med_cart.Get();
            dataGridView1.DataSource = DBGet_Med_cart.Med_cart;

            string FIO_kid = "SELECT Birth_certificate_nomber,concat(Name,' ',Surname,' ',Patronymic)  AS Fio_kid FROM kid;";
            string Group_healt = "SELECT health_group.Kod_health_group,health_group.Group FROM health_group;";

            //ФИО kid
            DBConnection.mycommand.CommandText = FIO_kid;
            DataTable kid = new DataTable();
            DBConnection.msDataAdapter.Fill(kid);

            comboBox1.DataSource = kid;
            comboBox1.DisplayMember = "Fio_kid";
            comboBox1.ValueMember = "Birth_certificate_nomber";
            comboBox1.SelectedIndex = -1;

            //Группа здоровья
            DBConnection.mycommand.CommandText = Group_healt;
            DataTable Group = new DataTable();
            DBConnection.msDataAdapter.Fill(Group);

            comboBox2.DataSource = Group;
            comboBox2.DisplayMember = "Group";
            comboBox2.ValueMember = "Kod_health_group";
            comboBox2.SelectedIndex = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Med_cart am1 = new Add_Med_cart();
            am1.Show();
        }

        /// <summary>
        /// Удаления записи в таблице "Мед карта"
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
                DBDelete_med_cart.Delete(kod);
                DBGet_Med_cart.Get();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kod = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            FIO_kid = dataGridView1.CurrentRow.Cells[1].Value.ToString() + ' ' + dataGridView1.CurrentRow.Cells[2].Value.ToString() + ' ' + dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Post = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Vec = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            Group_healt = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            xpon = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            Red_med_cart rm1 = new Red_med_cart();
            rm1.Show();
        }

        /// <summary>
        /// Фильтрация по ФИО ребенка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                Filter_med_cart_FIO_kid.Filter(comboBox1.Text);
            }
            else
            {
                MessageBox.Show("Выберите ФИО ребенка", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Фильтрация по группе здоровья
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                Filter_med_cart_healtGroup.Filter(comboBox2.Text);
            }
            else
            {
                MessageBox.Show("Выберите группу здоровья", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DBGet_Med_cart.Get();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void списокДетейВыбраннойГруппыИмеющихХраническоеЗаболеванияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doc_group_med_cart m1 = new Doc_group_med_cart();
            m1.Show();
        }
    }
}