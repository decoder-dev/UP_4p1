using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Menu_mentor : Form
    {
        public Menu_mentor()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Close();
        }

        private void Menu_mentor_Load(object sender, EventArgs e)
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

        private void ребенокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kid k1 = new Kid();
            k1.button1.Enabled = false;
            k1.button2.Enabled = false;
            k1.button3.Enabled = false;
            k1.выходныеДанныеToolStripMenuItem.Enabled = false;
            k1.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void занятияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lessons l2 = new Lessons();
            l2.Show();
            l2.отчетОПроведенныхЗанятияхЗаНедельныйПериодВремениToolStripMenuItem.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Red_info_staff r1 = new Red_info_staff();
            r1.Show();
        }
    }
}