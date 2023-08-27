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
    public partial class frmAdminGymClass : Form
    {
        public frmAdminGymClass()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmAdminMenu adminMenu = new frmAdminMenu();
            this.Hide();
            adminMenu.Show();
        }

        private void GetData(string query = "select Class.Id,Class.Title,Class.Category,Trainer.Name as [Trainer Name]," +
                "Class.Venue,Class.Num_Of_Sessions,Class.Start_Date,Class.Fees from Class inner join Trainer on Class.Trainer_Id=Trainer.Id")
        {
            DBConnection db = new DBConnection(query);
            dgv1.DataSource = db.GetDataTable();
        }

        private int newId()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Naing Min Khant\Documents\Gym.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("select max(Id) from Class", con);
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
        private void frmAdminGymClass_Load(object sender, EventArgs e)
        {
            //get classes data
            GetData();

            //set trainer combobox items
            DBConnection trainerNames = new DBConnection("select Name from Trainer");
            foreach (DataRow row in trainerNames.GetDataTable().Rows)
            {
                cboTrainer.Items.Add(row["Name"].ToString());
            }

            //set new id
            txtId.Text = newId().ToString();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnCreate.Enabled = false;

            DataGridViewRow row = dgv1.Rows[e.RowIndex];
            txtId.Text = row.Cells["Id"].Value.ToString();
            txtTitle.Text = row.Cells["Title"].Value.ToString();
            txtCategory.Text = row.Cells["Category"].Value.ToString();
            cboTrainer.SelectedItem = row.Cells["Trainer Name"].Value.ToString();
            txtVenue.Text = row.Cells["Venue"].Value.ToString();
            txtNumsOfSession.Text = row.Cells["Num_Of_Sessions"].Value.ToString();
            dtpStartDate.Value = DateTime.Parse(row.Cells["Start_Date"].Value.ToString());
            txtFees.Text = row.Cells["Fees"].Value.ToString();
        }
        private void Clear()
        {
            btnUpdate.Enabled = false;
            btnCreate.Enabled = true;

            txtId.Text = newId().ToString();
            txtTitle.Text = "";
            txtCategory.Text = "";
            cboTrainer.SelectedIndex = 0;
            txtVenue.Text = "";
            txtNumsOfSession.Text = "";
            dtpStartDate.Text = "";
            txtFees.Text = "";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
            GetData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = $"select Class.Id,Class.Title,Class.Category,Trainer.Name as [Trainer Name]," +
                $"Class.Venue,Class.Num_Of_Sessions,Class.Start_Date,Class.Fees from Class inner join Trainer on Class.Trainer_Id=Trainer.Id" +
                $" where Class.Title like '%{txtSearch.Text.Trim()}%' or Class.Id like '%{txtSearch.Text}%' or Class.Category like '%{txtSearch.Text}%' or Trainer.Name like '%{txtSearch.Text}%'";
            GetData(query);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateOrUpdateOperation("create");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CreateOrUpdateOperation("update");
        }

        private void CreateOrUpdateOperation(string operationName)
        {
            Validation validation = new Validation(errorProvider);
            validation.CheckRequired(txtTitle);
            validation.CheckRequired(txtCategory);
            validation.CheckRequired(cboTrainer);
            validation.CheckRequired(txtVenue);
            validation.CheckRequired(txtNumsOfSession);
            validation.CheckRequired(txtFees);

            if (string.IsNullOrEmpty(errorProvider.GetError(txtTitle)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtCategory)) &&
                string.IsNullOrEmpty(errorProvider.GetError(cboTrainer)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtVenue)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtNumsOfSession)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtFees))
                )
            {//required validation passed
                try
                {
                    double fees = Convert.ToDouble(txtFees.Text.Trim());
                    if (fees < 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        DBConnection tr = new DBConnection($"select Id from Trainer where Name='{cboTrainer.Text}'");
                        string trainerId = tr.GetDataTable().Rows[0]["Id"].ToString();


                        if (operationName.ToLower() == "create")//insert operation
                        {
                            DBConnection db = new DBConnection($"insert into Class(Id,Title,Category,Trainer_Id,Venue,Num_Of_Sessions,Start_Date,Fees)" +
                                $" values('{txtId.Text.Trim()}','{txtTitle.Text.Trim()}','{txtCategory.Text.Trim()}','{trainerId}','{txtVenue.Text.Trim()}','{txtNumsOfSession.Text.Trim()}','{dtpStartDate.Value}','{fees}')");
                        }
                        else if (operationName.ToLower() == "update")//update opreation
                        {
                            DBConnection db = new DBConnection($"update Class set Title='{txtTitle.Text.Trim()}',Category='{txtCategory.Text.Trim()}'," +
                                $"Trainer_Id='{trainerId}',Venue='{txtVenue.Text.Trim()}',Num_Of_Sessions='{txtNumsOfSession.Text.Trim()}',Start_Date='{dtpStartDate.Value}',Fees='{fees}' where Id='{txtId.Text.Trim()}'");
                        }

                        MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GetData();
                        Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Fees Input!", "Fees Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        DBConnection db = new DBConnection($"delete from Class where Id='{idToDelete}'");

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
