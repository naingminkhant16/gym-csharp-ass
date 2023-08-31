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
    public partial class frmAdminEnrollment : Form
    {
        public frmAdminEnrollment()
        {
            InitializeComponent();
        }
        private void GetData(string query = "select Enrollment.Id,Class.Title as [Class Title],Class.Category,Trainer.Name as [Trainer Name],Member.Name as [Member Name] from Enrollment inner join Class on Enrollment.Class_Id=Class.Id inner join Member on Enrollment.Member_Id=Member.Id inner join Trainer on Class.Trainer_Id=Trainer.Id")
        {
            DBConnection db = new DBConnection(query);
            dgv1.DataSource = db.GetDataTable();
        }
        private void frmAdminEnrollment_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = $"select Enrollment.Id,Class.Title as [Class Title],Class.Category,Trainer.Name as [Trainer Name],Member.Name as [Member Name] from Enrollment inner join Class on Enrollment.Class_Id=Class.Id inner join Member on Enrollment.Member_Id=Member.Id inner join Trainer on Class.Trainer_Id=Trainer.Id where Member.Name like '%{txtSearch.Text.Trim()}%' or Class.Title like '%{txtSearch.Text.Trim()}%' or Trainer.Name like '%{txtSearch.Text.Trim()}%'";
            GetData(query);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetData();
            txtSearch.Text = txtToDeleteId.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmAdminMenu adminMenu = new frmAdminMenu();
            this.Hide();
            adminMenu.Show();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            try
            {
                //validation
                Validation validation = new Validation(errorProvider);
                validation.CheckRequired(txtToDeleteId);

                if (string.IsNullOrEmpty(errorProvider.GetError(txtToDeleteId)))
                {
                    int idToDelete = Convert.ToInt32(txtToDeleteId.Text.Trim());

                    DBConnection cls = new DBConnection($"Select Id from Enrollment where Id='{idToDelete}'");

                    if (cls.GetDataTable().Rows.Count != 1)
                    {
                        MessageBox.Show("Invalid Id", "Invalid Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //ask confirmation message
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Confirmation",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.Yes)
                        {
                            DBConnection db = new DBConnection($"delete from Enrollment where Id='{idToDelete}'");

                            MessageBox.Show("Successfully deleted",
                              "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtToDeleteId.Text = "";
                            GetData();
                        }
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
