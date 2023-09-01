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
    public partial class frmUserEditProfile : Form
    {
        public frmUserEditProfile()
        {
            InitializeComponent();
        }
        private void GetData()
        {
            DBConnection db = new DBConnection($"select Name,Username,Age,Phone,Status,Gender from Member where Id='{Auth.Id}'");
            DataTable dt = db.GetDataTable();

            txtName.Text = dt.Rows[0]["Name"].ToString();
            txtAge.Text = dt.Rows[0]["Age"].ToString();
            txtUsername.Text = dt.Rows[0]["Username"].ToString();
            txtPhone.Text = dt.Rows[0]["Phone"].ToString();
            cboStatus.Text = dt.Rows[0]["Status"].ToString();


            rdbMale.Checked = (dt.Rows[0]["Gender"].ToString().Trim() == "Male") ? true : false;
            rdbFemale.Checked = !rdbMale.Checked;
        }
        private void frmUserEditProfile_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmUserMenu userMenu = new frmUserMenu();
            this.Hide();
            userMenu.Show();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //check required validation
            Validation validation = new Validation(errorProvider);
            validation.CheckRequired(txtName);
            validation.CheckRequired(txtUsername);
            validation.CheckRequired(txtAge);
            validation.CheckRequired(txtPhone);
            validation.CheckRequired(cboStatus);



            if (string.IsNullOrEmpty(errorProvider.GetError(txtName)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtUsername)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtAge)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtPhone)) &&
                string.IsNullOrEmpty(errorProvider.GetError(cboStatus))
                )
            {
                //check duplicated username
                DBConnection checkUsernameDuplicated = new DBConnection($"select Username from Member where Username='{txtUsername.Text.Trim()}' and Id!='{Auth.Id}'");

                if (checkUsernameDuplicated.GetDataTable().Rows.Count > 0)
                {
                    MessageBox.Show("Username is already taken", "Invalid Username",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // phone validation
                    try
                    {
                        Convert.ToInt32(txtPhone.Text.Trim());//validation for string inputs
                        Convert.ToInt32(txtAge.Text.Trim());//validation for string inputs
                        if (txtPhone.Text.Trim().Length > 10)
                        {
                            MessageBox.Show("Phone Number can't longer than 10 characters!",
                                "Invalid Phone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            //all validations passed
                            string name = txtName.Text.Trim();
                            string username = txtUsername.Text.Trim();
                            string gender = (rdbMale.Checked) ? "Male" : "Female";
                            string age = txtAge.Text.Trim();
                            string phone = txtPhone.Text.Trim();
                            string status = cboStatus.Text;

                            DBConnection db = new DBConnection($"update Member set Name='{name}',Username='{username}',Age='{age}',Gender='{gender}',Status='{status}',Phone='{phone}' where Id='{Auth.Id}'");

                            MessageBox.Show("Successfully Updated.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GetData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Invalid", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
