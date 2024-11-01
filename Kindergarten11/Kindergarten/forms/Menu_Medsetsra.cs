using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Menu_Medsetsra : Form
    {
        public Menu_Medsetsra()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Medsetsra_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Red_info_staff r1 = new Red_info_staff();
            r1.Show();
        }

        private void занятияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Med_cart m1 = new Med_cart();
            m1.Show();
        }

        private void вакцинацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data_vaccination v1 = new Data_vaccination();
            v1.Show();
        }

        private void группаЗдоровьяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Group_healt gh1 = new Group_healt();
            gh1.Show();
        }

        private void прививкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vaccination v1 = new Vaccination();
            v1.Show();
        }

        private void ребенокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kid k1 = new Kid();
            k1.Show();
            k1.button1.Enabled = false;
            k1.button2.Enabled = false;
            k1.button3.Enabled = false;
            k1.выходныеДанныеToolStripMenuItem.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Red_info_staff r1 = new Red_info_staff();
            r1.Show();
        }
    }
}