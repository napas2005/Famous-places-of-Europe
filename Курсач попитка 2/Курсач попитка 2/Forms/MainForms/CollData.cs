using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Курсач_попитка_2.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Курсач_попитка_2
{
    public partial class CollData : Form
    {
        DataBaseCfg cfg = new DataBaseCfg();
        private User currentUser;
        public CollData(User user)
        {
            InitializeComponent();
            currentUser = user;
            cfg.readCollectiveFamplaces(guna2DataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AreushuretoClose areushuretoClose = new AreushuretoClose();
            areushuretoClose.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Adding sort = new Adding(currentUser);
            sort.Show();
        }

        private void ButtonTrip_Click_1(object sender, EventArgs e)
        {
            Famousplaces famousplaces = new Famousplaces(currentUser);
            famousplaces.Show();
            this.Hide();

        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            Adding sort = new Adding(currentUser);
            sort.Show();
            this.Hide();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            cfg.DeletePlace(guna2TextBox1.Text);
            cfg.readCollectiveFamplaces(guna2DataGridView1);
        }
    }
}
