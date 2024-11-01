using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Menu_head : Form
    {
        public Menu_head()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void сотрудникToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void Menu_head_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dd MMMM yyyy");
            pictureBox1.Image = Properties.Resources.Детский_сад;
            textBox1.Text = Form1.log;
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = Form1.FIO;
            textBox2.ForeColor = Color.Gray;
            textBox3.Text = Form1.Telephone;
            textBox3.ForeColor = Color.Gray;
        }

        private void прививкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vaccination v1 = new Vaccination();
            v1.Show();
        }

        private void видыГруппыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Types_of_group tog1 = new Types_of_group();
            tog1.Show();
        }

        private void должностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Post p1 = new Post();
            p1.Show();
        }

        private void группаЗдоровьяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Group_healt gh1 = new Group_healt();
            gh1.Show();
        }

        private void детиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Kid k1 = new Kid();
            k1.Show();
        }

        private void родителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parents p1 = new Parents();
            p1.Show();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff s1 = new Staff();
            s1.Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void дисциплиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Discipline d1 = new Discipline();

            d1.Show();
        }

        private void медКартаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Med_cart m1 = new Med_cart();
            m1.Show();
        }

        private void группаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Group_kid g1 = new Group_kid();
            g1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void вакцинацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data_vaccination d1 = new Data_vaccination();
            d1.Show();
        }

        private void проведенныеЗанятияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lessons l1 = new Lessons();
            l1.button1.Enabled = false;
            l1.button2.Enabled = false;
            l1.button3.Enabled = false;
            l1.Show();
        }

        private void просмотрТаблицToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Red_info_staff rs1 = new Red_info_staff();
            rs1.Show();
        }

        private void медКартаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Med_cart m1 = new Med_cart();
            m1.Show();
            m1.button1.Enabled = false;
            m1.button2.Enabled = false;
            m1.button3.Enabled = false;

            m1.документыToolStripMenuItem.Enabled = false;
        }

        private void вакцинацияToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Data_vaccination v1 = new Data_vaccination();
            v1.Show();
            v1.button1.Enabled = false;
            v1.button2.Enabled = false;
            v1.button3.Enabled = false;
        }

        private void видыГруппыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Types_of_group t1 = new Types_of_group();
            t1.Show();
        }
    }
}