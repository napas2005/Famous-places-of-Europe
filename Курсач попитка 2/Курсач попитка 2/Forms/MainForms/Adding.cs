using Guna.UI2.WinForms;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Курсач_попитка_2.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Image = System.Drawing.Image;

namespace Курсач_попитка_2
{
    public partial class Adding : Form
    {
        private User currentUser;
        DataBaseCfg cfg = new DataBaseCfg();
        public Adding(User user)
        {
            InitializeComponent();
            currentUser = user;
            cfg.readFamplaces(guna2DataGridView1, currentUser);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AreushuretoClose areushuretoClose = new AreushuretoClose();
            areushuretoClose.Show();
        }

        private void ButtonTrip_Click_1(object sender, EventArgs e)
        {
            Famousplaces famousplaces = new Famousplaces(currentUser);
            famousplaces.Show();
            this.Hide();

        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            CollData search = new CollData(currentUser);
            search.Show();
            this.Hide();

        }
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.bmp;*.jpg;*.jpeg;*.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DataBaseCfg _db = new DataBaseCfg();
            FamPlace place = new FamPlace(guna2TextBox1.Text, guna2ComboBox1.Text, dateTimePicker1.Value, guna2TextBox2.Text, guna2TextBox3.Text, 0, pictureBox2);
            var userCollection = _db.GetCollection(); 
            var placeNameExists = userCollection.Find(u => u.Places.Any(t => t.Name == guna2TextBox3.Text)).Any();
            if (placeNameExists)
            {
                MessageBox.Show("Таке місце вже додано");
                return;
            }
            else
            {
                currentUser.AddPlace(place);
                _db.readFamplaces(guna2DataGridView1, currentUser);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FamPlace place = new FamPlace(guna2TextBox1.Text, guna2ComboBox1.Text, dateTimePicker1.Value, guna2TextBox2.Text, guna2TextBox3.Text, 0, pictureBox2);
            cfg.AddPlace(place);
            MessageBox.Show("Об'єкт успішно додано в загальну базу");
        }

    }
}
