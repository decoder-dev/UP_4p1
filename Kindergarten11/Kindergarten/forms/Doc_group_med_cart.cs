using System;
using System.Data;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Doc_group_med_cart : Form
    {
        public static string Group_med_cart;

        public Doc_group_med_cart()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
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
        private void Doc_group_med_cart_Load(object sender, EventArgs e)
        {
            string group = "SELECT Kod_Group,Name FROM group_kid;";

            DBConnection.mycommand.CommandText = group;
            DataTable g = new DataTable();
            DBConnection.msDataAdapter.Fill(g);

            comboBox1.DataSource = g;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Kod_Group";
            comboBox1.SelectedIndex = -1;
        }

        /// <summary>
        ///  Формирования выходного excel документа "Список детей выбранной группы имеющих хроническое заболевание"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                Group_med_cart = comboBox1.Text;
                if (Excel_doc_med_cart.GetGroup(Group_med_cart) == true)
                {
                    Excel_doc_med_cart.SqlToExcels();
                }
            }
            else
            {
                MessageBox.Show("Выберите группу", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}