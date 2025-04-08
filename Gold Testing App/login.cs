using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gold_Testing_App
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = useridtxtbox.Text; // Corrected semicolon issue
            pass = passwordtxtbox.Text;

            // Corrected comparison operator and added logic
            if (user == "admin" && pass == "1212")
            {                                
                //MessageBox.Show("Login successful!"); // Add logic for successful login
                 Home party = new Home();
                 party.Show();
                 this.Close();
            }
            else
            {
                MessageBox.Show("Please enter the valid User Id And Password"); // Handle incorrect credentials
            }
        }

    }
}
