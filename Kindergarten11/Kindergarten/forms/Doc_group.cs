using System;
using System.Data;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Doc_group : Form
    {
        public static string Group_name;

        public Doc_group()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Заполнение comboBox-кса (
        /// comboBox1 - Группа
        /// )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Doc_group_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///  Формирования выходного excel документа "Список выбранной группы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                Group_name = comboBox1.Text;
                if (Excel_doc_Group.GetGroup(Group_name) == true)
                {
                    Excel_doc_Group.SqlToExcels();
                }
            }
            else
            {
                MessageBox.Show("Выберите группу", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}