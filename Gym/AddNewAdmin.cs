using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym
{
    public partial class frmAddNewAdmin : Form
    {
        public frmAddNewAdmin()
        {
            InitializeComponent();
        }

        private int newId()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Naing Min Khant\Documents\Gym.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("select max(Id) from Admin", con);
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                newId++;
                con.Close();
                return newId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //required validation
            Validation validation = new Validation(errorProvider);
            validation.CheckRequired(txtUsername);
            validation.CheckRequired(txtPassword);
            validation.CheckRequired(txtConfirmPass);


            if (string.IsNullOrEmpty(errorProvider.GetError(txtUsername)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtPassword)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtConfirmPass))
                )
            {
                if (txtPassword.Text.Trim().Length < 8)//password length check
                {
                    MessageBox.Show("Password should have atleast 8 characters!", "Password Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtPassword.Text.Trim() != txtConfirmPass.Text.Trim())//password match check
                {
                    MessageBox.Show("Password doesn't match!", "Password Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else//passed all validation
                {
                    string password = Password.Hash(txtPassword.Text.Trim());
                    DBConnection db = new DBConnection($"insert into Admin(Id,Username,Password) values ('{newId()}','{txtUsername.Text.Trim()}','{password}')");
                    MessageBox.Show("New Admin successfully Created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Text = txtPassword.Text = txtConfirmPass.Text = "";
                }
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            frmAdminMenu AdminMenu = new frmAdminMenu();
            AdminMenu.Show();
            this.Hide();
        }

        private void btnPassShowHide_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = txtConfirmPass.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = txtPassword.Text = txtConfirmPass.Text = "";
        }
    }
}
