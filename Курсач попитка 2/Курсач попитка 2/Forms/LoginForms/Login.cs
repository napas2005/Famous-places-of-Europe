using Guna.UI2.WinForms;
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

namespace Курсач_попитка_2
{
    public partial class Login : Form
    {
        public Login()
        {
                InitializeComponent();
                ConfigClass cfg = new ConfigClass();
        }

        private void ButtonTrip_Click(object sender, EventArgs e)
        {
            AreushuretoClose areushuretoClose = new AreushuretoClose();
            areushuretoClose.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DataBaseCfg db = new DataBaseCfg();
            User usr = db.GetUser(guna2TextBox1.Text);
            if (db.GetCollection().Find(u=> u.login == guna2TextBox1.Text && u.password == guna2TextBox2.Text).FirstOrDefault() != null)
            {
                Famousplaces famousplaces = new Famousplaces(usr);
                famousplaces.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Логін або пароль невірний");
            }
        }
    }
}
