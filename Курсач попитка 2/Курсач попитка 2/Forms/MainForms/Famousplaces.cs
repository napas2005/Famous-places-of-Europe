using MongoDB.Driver;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Курсач_попитка_2.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Курсач_попитка_2
{
    public partial class Famousplaces : Form
    {
        private User currentUser;
        DataBaseCfg _db = new DataBaseCfg();

        public Famousplaces(User user)
        {
            currentUser = user;
            InitializeComponent();
            _db.readFamplaces(guna2DataGridView1, currentUser);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            AreushuretoClose freushuretoClose = new AreushuretoClose();
            freushuretoClose.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Adding sort = new Adding(currentUser);
            sort.Show();
            this.Hide();

        }

        private void guna2TextBox3_Click(object sender, EventArgs e)
        {
            guna2TextBox3.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var userCollection = _db.GetCollection();
            var placeNameExists = userCollection.Find(u => u.Places.Any(t => t.Name == guna2TextBox1.Text)).Any();
            if (!placeNameExists)
            {
                MessageBox.Show("Такого місця не існує");
                return;
            }
            currentUser.DelPlace(guna2TextBox1.Text);
            _db.updateUser(currentUser);
            _db.readFamplaces(guna2DataGridView1, currentUser);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            _db.SortByTemp(guna2DataGridView1, currentUser, guna2ComboBox1.Text);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            _db.ChangeRate(guna2DataGridView1, currentUser, guna2TextBox3.Text, (int)guna2RatingStar1.Value);
            _db.readFamplaces(guna2DataGridView1, currentUser);
        }

        private void guna2TextBox1_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Adding sort = new Adding(currentUser);
            sort.Show();
            this.Hide();
        }
        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            DataBaseCfg cfg = new DataBaseCfg();
            cfg.SearchPlaces(guna2DataGridView1, currentUser, guna2TextBox2.Text);
        }

        private void guna2TextBox2_Click(object sender, EventArgs e)
        {
            guna2TextBox2.Text = "";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            CollData search = new CollData(currentUser);
            search.Show();
            this.Hide();
        }
    }
}
