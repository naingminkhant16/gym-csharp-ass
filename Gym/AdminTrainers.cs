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
    public partial class frmAdminTrainers : Form
    {
        public frmAdminTrainers()
        {
            InitializeComponent();
        }

        private void GetData(string query = "select * from Trainer")
        {
            DBConnection db = new DBConnection(query);
            dgv1.DataSource = db.GetDataTable();
        }

        private void frmAdminTrainers_Load(object sender, EventArgs e)
        {
            txtId.Text = newId().ToString();
            GetData();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnCreate.Enabled = false;


            DataGridViewRow row = dgv1.Rows[e.RowIndex];
            txtId.Text = row.Cells["Id"].Value.ToString();
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtAge.Text = row.Cells["Age"].Value.ToString();
            txtAddress.Text = row.Cells["Address"].Value.ToString();
            txtPhone.Text = row.Cells["Phone"].Value.ToString();
            cboStatus.Text = row.Cells["Status"].Value.ToString();


            rdbMale.Checked = (row.Cells["Gender"].Value.ToString().Trim() == "Male") ? true : false;
            rdbFemale.Checked = !rdbMale.Checked;

        }

        private int newId()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Naing Min Khant\Documents\Gym.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("select max(Id) from Trainer", con);
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
        private void Clear()
        {
            btnUpdate.Enabled = false;
            btnCreate.Enabled = true;
            txtId.Text = newId().ToString();
            txtName.Text = "";
            txtAge.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            cboStatus.Text = "";
            rdbFemale.Checked = false;
            rdbMale.Checked = true;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmAdminMenu frmAdminMenu = new frmAdminMenu();
            this.Hide();
            frmAdminMenu.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = $"select * from Trainer where Name like '%{txtSearch.Text.Trim()}%' " +
                $"or Id like '%{txtSearch.Text}%'";

            GetData(query);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetData();
            Clear();
            txtToDeleteId.Text = "";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateOrUpdateOperation("create");
        }

        private void CreateOrUpdateOperation(string operationName)
        {
            //check text boxes required validation
            Validation validation = new Validation(errorProvider);
            validation.CheckRequired(txtName);
            validation.CheckRequired(txtAge);
            validation.CheckRequired(txtAddress);
            validation.CheckRequired(txtPhone);

            //check status  combox required validation
            if (string.IsNullOrEmpty(cboStatus.Text)) errorProvider.SetError(cboStatus, "*Select One");


            //check if required validations pass
            if (string.IsNullOrEmpty(errorProvider.GetError(txtName)) &&
                string.IsNullOrEmpty(errorProvider.GetError(cboStatus)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtAge)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtName)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtPhone)))
            {//all required validation passed

                //check age and phone number validation 
                try
                {
                    int age = Convert.ToInt32(txtAge.Text.Trim());
                    int phone = Convert.ToInt32(txtPhone.Text.Trim());

                    string gender = (rdbMale.Checked) ? "Male" : "Female";

                    if (operationName.ToLower() == "create")//insert
                    {
                        string query = $"insert into Trainer(Id,Name,Age,Address,Phone,Status,Gender) values" +
                      $"('{txtId.Text.Trim()}','{txtName.Text.Trim()}','{age}','{txtAddress.Text.Trim()}'," +
                      $"'{phone}','{cboStatus.Text}','{gender}')";
                        DBConnection db = new DBConnection(query);
                    }
                    else if (operationName.ToLower() == "update")//update
                    {
                        string query = $"update Trainer set Name='{txtName.Text.Trim()}',Age='{age}',Address='{txtAddress.Text.Trim()}'," +
                      $"Phone='{phone}',Status='{cboStatus.Text}',Gender='{gender}' where Id='{txtId.Text.Trim()}'";
                        DBConnection db = new DBConnection(query);
                    }

                    MessageBox.Show("Operation Success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                        DBConnection db = new DBConnection($"delete from Trainer where Id='{idToDelete}'");

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CreateOrUpdateOperation("update");
        }
    }
}
