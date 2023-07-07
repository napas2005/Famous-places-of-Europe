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

namespace Курсач_попитка_2
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DataBaseCfg cfg = new DataBaseCfg();
            User user = new User();
            user.login = guna2TextBox1.Text;
            user.password = guna2TextBox2.Text;
            cfg.GetCollection().InsertOne(user);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void ButtonTrip_Click(object sender, EventArgs e)
        {
            AreushuretoClose areushuretoClose = new AreushuretoClose();
            areushuretoClose.Show();
        }
    }
}
