using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym
{
    public partial class frmAdminLogin : Form
    {
        public frmAdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Validation validation = new Validation(errorProvider);

            validation.CheckRequired(txtUsername);
            validation.CheckRequired(txtPassword);

            if (string.IsNullOrEmpty(errorProvider.GetError(txtUsername)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtPassword)))
            {
                string password = Password.Hash(txtPassword.Text.Trim());//hash user input password

                DBConnection db = new DBConnection($"select * from Admin" +
                    $" where Username = '{txtUsername.Text.Trim()}' and" +
                    $" Password = '{password}'");


                if (db.GetDataTable().Rows.Count == 1)
                {
                    MessageBox.Show("Login Success");

                    //add auth value 
                    Auth.Id = Convert.ToInt32(db.GetDataTable().Rows[0]["Id"]);
                    Auth.Username = db.GetDataTable().Rows[0]["Username"].ToString();

                    frmAdminMenu adminMenu = new frmAdminMenu();
                    this.Hide();
                    adminMenu.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Username Or Password!", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void lklWelcome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmWelcome welcome = new frmWelcome();
            this.Hide();
            welcome.Show();
        }

        private void btnPassShowHide_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }
    }
}
