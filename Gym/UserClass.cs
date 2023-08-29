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

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            Validation validation = new Validation(errorProvider);
            validation.CheckRequired(txtToEnrollId);

            if (string.IsNullOrEmpty(errorProvider.GetError(txtToEnrollId)))
            {
                string query = $"insert into Enrollment(Member_Id,Class_Id) values ('{Auth.Id}','{txtToEnrollId.Text.Trim()}')";
                DBConnection db = new DBConnection(query);
                MessageBox.Show("Successfully Enrolled", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtToEnrollId.Text = "";
            }
        }
    }
}
