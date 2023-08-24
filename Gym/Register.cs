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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }
        private int newId;

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Validation validation = new Validation(errorProvider);
            validation.CheckRequired(txtName);
            validation.CheckRequired(txtPassword);
            validation.CheckRequired(txtComPassword);
            validation.CheckRequired(txtAge);
            validation.CheckRequired(txtPhone);


            if (string.IsNullOrEmpty(errorProvider.GetError(txtName)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtPassword)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtComPassword)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtAge)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtName)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtPhone))
                )
            {
                //required inputs validation passed
                if (txtPassword.Text.Trim() != txtComPassword.Text.Trim())//check passwords
                {
                    MessageBox.Show("Password doesn't match!", "Password Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else//password validation passed
                {
                    // phone validation
                    try
                    {
                        Convert.ToInt32(txtPhone.Text.Trim());//validation for string inputs
                        if (txtPhone.Text.Trim().Length > 10)
                        {
                            MessageBox.Show("Phone Number can't longer than 10 characters!", "Invalid Phone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            //all validations passed
                            string name = txtName.Text.Trim();
                            string password = Password.Hash(txtPassword.Text.Trim());
                            string username = txtUsername.Text.Trim();
                            string gender = (rdbFemale.Checked) ? "Female" : "Male";

                            string age = txtAge.Text.Trim();
                            string phone = txtPhone.Text.Trim();
                            string status = "Active";


                            DBConnection db = new DBConnection($"insert into Member(Id,Name,Username,Password,Age,Gender,Status,Phone)" +
                                $" values('{newId}','{name}','{username}','{password}','{age}','{gender}','{status}','{phone}')");

                            DialogResult dialogResult = MessageBox.Show("Successfully registered.Login Now.", "Login Now", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                            autoId();

                            if (dialogResult == DialogResult.Yes)
                            {
                                frmWelcome welcome = new frmWelcome();
                                this.Hide();
                                welcome.Show();
                            }
                            else
                            {
                                Clear();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Phone Number", "Invalid Phone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }

        }

        private void lklLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmWelcome welcome = new frmWelcome();
            this.Hide();
            welcome.Show();
        }


        private void autoId()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Naing Min Khant\Documents\Gym.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select max(Id) from Member", con);
            newId = Convert.ToInt32(cmd.ExecuteScalar());
            newId++;
            con.Close();
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtUsername.Text = txtName.Text.ToLower().Replace(" ", "_") + "_" + newId;
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            autoId();
        }
        private void Clear()
        {
            txtName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtAge.Text = "";
            txtPhone.Text = "";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnPassShowHide_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            txtComPassword.UseSystemPasswordChar = !txtComPassword.UseSystemPasswordChar;
        }
    }
}
