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
    public partial class frmAdminMember : Form
    {
        public frmAdminMember()
        {
            InitializeComponent();
        }

        private void GetData(string query = "select Id,Name,Username,Age,Gender,Status,Phone from Member")
        {
            DBConnection db = new DBConnection(query);
            dgv1.DataSource = db.GetDataTable();
        }

        private void frmAdminMember_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetData($"select Id,Name,Username,Age,Gender,Status,Phone from Member where Name like '%{txtSearch.Text}%' or Id like '%{txtSearch.Text}%'");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetData();
            Clear();
        }
        private void Clear()
        {
            txtId.Text = txtName.Text = txtUsername.Text = txtAge.Text = txtPhone.Text = cboStatus.Text = txtToDeleteId.Text = "";
            rdbMale.Checked = rdbFemale.Checked = false;
        }
        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv1.Rows[e.RowIndex];
            txtId.Text = row.Cells["Id"].Value.ToString();
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtAge.Text = row.Cells["Age"].Value.ToString();
            txtUsername.Text = row.Cells["Username"].Value.ToString();
            txtPhone.Text = row.Cells["Phone"].Value.ToString();
            cboStatus.Text = row.Cells["Status"].Value.ToString();


            rdbMale.Checked = (row.Cells["Gender"].Value.ToString().Trim() == "Male") ? true : false;
            rdbFemale.Checked = !rdbMale.Checked;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //check text boxes required validation
            Validation validation = new Validation(errorProvider);
            validation.CheckRequired(txtName);
            validation.CheckRequired(txtAge);
            validation.CheckRequired(txtUsername);
            validation.CheckRequired(txtPhone);

            //check status  combox required validation
            if (string.IsNullOrEmpty(cboStatus.Text)) errorProvider.SetError(cboStatus, "*Select One");


            //check if required validations pass
            if (string.IsNullOrEmpty(errorProvider.GetError(txtName)) &&
                string.IsNullOrEmpty(errorProvider.GetError(cboStatus)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtAge)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtUsername)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtPhone)))
            {//all required validation passed

                //check age and phone number validation 
                try
                {
                    int age = Convert.ToInt32(txtAge.Text.Trim());
                    int phone = Convert.ToInt32(txtPhone.Text.Trim());

                    string gender = (rdbMale.Checked) ? "Male" : "Female";



                    string query = $"update Member set Name='{txtName.Text.Trim()}',Age='{age}',Username='{txtUsername.Text.Trim().Replace(' ', '_')}'," +
                  $"Phone='{phone}',Status='{cboStatus.Text}',Gender='{gender}' where Id='{txtId.Text.Trim()}'";
                    DBConnection db = new DBConnection(query);


                    MessageBox.Show("Successfully Updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Clear();
                    GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid input in Age or Phone! Only Numbers are allowed in those fields!",
                        "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmAdminMenu adminMenu = new frmAdminMenu();
            this.Hide();
            adminMenu.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //validation
                Validation validation = new Validation(errorProvider);
                validation.CheckRequired(txtToDeleteId);

                if (string.IsNullOrEmpty(errorProvider.GetError(txtToDeleteId)))
                {
                    int idToDelete = Convert.ToInt32(txtToDeleteId.Text.Trim());

                    //ask confirmation message
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Confirmation",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        DBConnection db = new DBConnection($"delete from Member where Id='{idToDelete}'");

                        MessageBox.Show("Successfully deleted",
                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtToDeleteId.Text = "";
                        GetData();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input!",
                      "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
