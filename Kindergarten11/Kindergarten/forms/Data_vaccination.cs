using System;
using System.Data;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Data_vaccination : Form
    {
        public static string kod1;
        public static string FIO_kid;
        public static DateTime date;
        public static string Name_vac;

        public Data_vaccination()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///  Заполнение comboBox-кса (
        /// comboBox1 - ФИО ребенка
        /// comboBox2 - Группа
        /// comboBox6 - Вакцина
        /// )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_vaccination_Load(object sender, EventArgs e)
        {
            DBGet_data_vac.Get();
            dataGridView1.DataSource = DBGet_data_vac.dtDataVac;

            string FIO_kid = "SELECT Birth_certificate_nomber,concat(Name,' ',Surname,' ',Patronymic) AS FIO_kid FROM kid;";
            string Group = "SELECT Kod_Group,Name FROM group_kid;";
            string Vac = "SELECT Kod_vaccination,Name FROM vaccinations;";

            //Ребенок
            DBConnection.mycommand.CommandText = FIO_kid;
            DataTable kid = new DataTable();
            DBConnection.msDataAdapter.Fill(kid);

            comboBox1.DataSource = kid;
            comboBox1.DisplayMember = "FIO_kid";
            comboBox1.ValueMember = "Birth_certificate_nomber";
            comboBox1.SelectedIndex = -1;
            //Группа
            DBConnection.mycommand.CommandText = Group;
            DataTable group_kid = new DataTable();
            DBConnection.msDataAdapter.Fill(group_kid);

            comboBox2.DataSource = group_kid;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Kod_Group";
            comboBox2.SelectedIndex = -1;
            //Вакцина
            DBConnection.mycommand.CommandText = Vac;
            DataTable vaccion = new DataTable();
            DBConnection.msDataAdapter.Fill(vaccion);

            comboBox3.DataSource = vaccion;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Kod_vaccination";
            comboBox3.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_data_vac a1 = new Add_data_vac();
            a1.Show();
        }

        /// <summary>
        /// Удаления записи
        /// dialogResult -диалоговое окно на подтверждения удаления записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string kod = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите удалить запись?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                DBDelete_data_vac.Delete(kod);
                DBGet_data_vac.Get();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kod1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Name_vac = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            date = DateTime.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            FIO_kid = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            Red_data_vac r1 = new Red_data_vac();
            r1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DBGet_data_vac.Get();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
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
                Filter_data_vac.Filter_FIO_kid(comboBox1.Text);
            }
            else
            {
                MessageBox.Show("Выберите ФИО ребенка", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Фильтрация по Группе и Вакцине отдельно и вместе
        /// Filter_data_vac.Filter_VacANDGroup - фильтрация по группе и вакцине вместе
        /// Filter_data_vac.Filter_Group - фильтрация по группе
        /// Filter_data_vac.Filter_Vac - фильтрация по вакцине
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                Filter_data_vac.Filter_VacANDGroup(comboBox3.Text, comboBox2.SelectedValue.ToString());
            }
            else
            {
                Filter_data_vac.Filter_Group(comboBox2.SelectedValue.ToString());
            }
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                Filter_data_vac.Filter_VacANDGroup(comboBox3.Text, comboBox2.SelectedValue.ToString());
            }
            else
            {
                Filter_data_vac.Filter_Vac(comboBox3.Text);
            }
        }
    }
}