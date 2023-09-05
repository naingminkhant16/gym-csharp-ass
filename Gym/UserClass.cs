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
    public partial class frmUserClass : Form
    {
        public frmUserClass()
        {
            InitializeComponent();
        }

        private void UserClass_Load(object sender, EventArgs e)
        {
            string query = "select Class.Id,Class.Title,Class.Category,Trainer.Name as [Trainer Name]," +
                "Class.Venue,Class.Num_Of_Sessions,Class.Start_Date,Class.Fees from Class inner join Trainer on Class.Trainer_Id=Trainer.Id";

            DBConnection db = new DBConnection(query);
            dgv1.DataSource = db.GetDataTable();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string query = "select Class.Id,Class.Title,Class.Category,Trainer.Name as [Trainer Name]," +
                "Class.Venue,Class.Num_Of_Sessions,Class.Start_Date,Class.Fees from Class inner join Trainer on Class.Trainer_Id=Trainer.Id";

            DBConnection db = new DBConnection(query);
            dgv1.DataSource = db.GetDataTable();

            txtToEnrollId.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmUserMenu userMenu = new frmUserMenu();
            this.Hide();
            userMenu.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = "select Class.Id,Class.Title,Class.Category,Trainer.Name as [Trainer Name]," +
              "Class.Venue,Class.Num_Of_Sessions,Class.Start_Date,Class.Fees from Class inner join Trainer on Class.Trainer_Id=Trainer.Id" +
              $" where Class.Title like '%{txtSearch.Text.Trim()}%' or Class.Id like '%{txtSearch.Text}%' or Class.Category like '%{txtSearch.Text}%' or Trainer.Name like '%{txtSearch.Text}%'";

            DBConnection db = new DBConnection(query);
            dgv1.DataSource = db.GetDataTable();
        }
        private int newId()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Naing Min Khant\Documents\Gym.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("select max(Id) from Enrollment", con);
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

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv1.Rows[e.RowIndex];
            txtToEnrollId.Text = row.Cells["Id"].Value.ToString();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            Validation validation = new Validation(errorProvider);
            validation.CheckRequired(txtToEnrollId);

            if (string.IsNullOrEmpty(errorProvider.GetError(txtToEnrollId)))
            {
                try
                {
                    int classId = int.Parse(txtToEnrollId.Text.Trim());
                    DBConnection cls = new DBConnection($"Select Id from Class where Id='{classId}'");

                    if (cls.GetDataTable().Rows.Count != 1)
                    {
                        MessageBox.Show("Invalid Id", "Invalid Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Please confirm to enroll.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information); ;

                        if (dialogResult == DialogResult.Yes)
                        {
                            string query = $"insert into Enrollment(Id,Member_Id,Class_Id) values ('{newId()}','{Auth.Id}','{classId}')";
                            DBConnection db = new DBConnection(query);
                            MessageBox.Show("Successfully Enrolled", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtToEnrollId.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

}
