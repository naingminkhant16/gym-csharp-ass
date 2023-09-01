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
    public partial class frmChangePassword : Form
    {
        private string tableName;
        public frmChangePassword(string TableName)
        {
            tableName = TableName;
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (tableName == "Admin")
            {
                frmAdminMenu aMenu = new frmAdminMenu();
                aMenu.Show();
            }
            if (tableName == "Member")
            {
                frmUserMenu userMenu = new frmUserMenu();
                userMenu.Show();
            }
            this.Hide();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Auth.Username;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //required validation
            Validation validation = new Validation(errorProvider);
            validation.CheckRequired(txtNewPass);
            validation.CheckRequired(txtConfirmPass);


            if (string.IsNullOrEmpty(errorProvider.GetError(txtNewPass)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtConfirmPass))
                )
            {
                if (txtNewPass.Text.Trim().Length < 8)//password length check
                {
                    MessageBox.Show("Password should have atleast 8 characters!", "Password Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtNewPass.Text.Trim() != txtConfirmPass.Text.Trim())//password match check
                {
                    MessageBox.Show("Password doesn't match!", "Password Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else//passed all validation
                {
                    string password = Password.Hash(txtNewPass.Text.Trim());
                    DBConnection db = new DBConnection($"update {tableName} set Password='{password}' " +
                        $"where Id='{Auth.Id}'");
                    MessageBox.Show("Password successfully changed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNewPass.Text = txtConfirmPass.Text = "";
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNewPass.Text = txtConfirmPass.Text = "";
        }

        private void btnPassShowHide_Click(object sender, EventArgs e)
        {
            txtNewPass.UseSystemPasswordChar = txtConfirmPass.UseSystemPasswordChar = !txtNewPass.UseSystemPasswordChar;
        }
    }
}
