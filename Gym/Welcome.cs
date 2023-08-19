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
    public partial class frmWelcome : Form
    {
        public frmWelcome()
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

                DBConnection db = new DBConnection($"select * from Member" +
                    $" where Username = '{txtUsername.Text.Trim()}' and" +
                    $" Password = '{password}'");


                if (db.GetDataTable().Rows.Count == 1)
                {
                    MessageBox.Show("Login Success");
                    frmUserMenu userMenu = new frmUserMenu();
                    this.Hide();
                    userMenu.Show();
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
    }
}
