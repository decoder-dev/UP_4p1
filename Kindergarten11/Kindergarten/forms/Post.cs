using System;
using System.IO;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class Post : Form
    {
        public static string name;
        public static string kod;

        public Post()
        {
            InitializeComponent();
        }

        private void Post_Load(object sender, EventArgs e)
        {
            DBGet_Post.Get();
            dataGridView1.DataSource = DBGet_Post.dtPost;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Addpost ap1 = new Addpost();
            ap1.Show();
        }

        /// <summary>
        /// \Записывается в журнал события
		/// path - путь к txt файлу
		/// Entrance - сегодняшняя дата и время\
        /// Удаления записи в справочнике "Должность"
        /// dialogResult - диалоговое окно на подтверждения удаления записи
        /// Delete_post - проверка что запись не используется в другой таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path = path + @"\Журнал событий.txt";
            DateTime Entrance = DateTime.Now;
            string kod1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (Delete_post.Delete_Proverka(kod1) == true)
            {
                DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    DBDelete_post.Delete(kod1);
                    DBGet_Post.Get();
                    File.AppendAllText(path, "\r\n УДАЛЕНИЯ ДОЛЖНОСТИ   УДАЛИЛ(А):" + DBAuthorization.fio + "  ВРЕМЯ:" + Entrance.ToShortTimeString());
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
            name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Redpost rp1 = new Redpost();
            rp1.Show();
        }
    }
}