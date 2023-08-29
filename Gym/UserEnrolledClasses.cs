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
    public partial class frmUserEnrolledClasses : Form
    {
        public frmUserEnrolledClasses()
        {
            InitializeComponent();
        }



        private void frmUserEnrolledClasses_Load(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection($"select Class.Id,Class.Title,Class.Category,Trainer.Name as [Trainer Name]," +
              $"Class.Venue,Class.Num_Of_Sessions,Class.Start_Date,Class.Fees" +
              $" from Enrollment inner join Class on Class.Id=Enrollment.Class_Id inner join Trainer on Class.Trainer_Id=Trainer.Id " +
              $"where Enrollment.Member_Id='{Auth.Id}'");
            dgv1.DataSource = db.GetDataTable();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            frmUserMenu userMenu = new frmUserMenu();
            this.Hide();
            userMenu.Show();
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection($"select Class.Id,Class.Title,Class.Category,Trainer.Name as [Trainer Name]," +
              $"Class.Venue,Class.Num_Of_Sessions,Class.Start_Date,Class.Fees" +
              $" from Enrollment inner join Class on Class.Id=Enrollment.Class_Id inner join Trainer on Class.Trainer_Id=Trainer.Id " +
              $"where Enrollment.Member_Id='{Auth.Id}'");
            dgv1.DataSource = db.GetDataTable();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection($"select Class.Id,Class.Title,Class.Category,Trainer.Name as [Trainer Name]," +
                $"Class.Venue,Class.Num_Of_Sessions,Class.Start_Date,Class.Fees" +
                $" from Enrollment inner join Class on Class.Id=Enrollment.Class_Id inner join Trainer on Class.Trainer_Id=Trainer.Id " +
                $"where Enrollment.Member_Id='{Auth.Id}' and ( Class.Title like '%{txtSearch.Text.Trim()}%' or Class.Id like '%{txtSearch.Text}%' or Class.Category like '%{txtSearch.Text}%' or Trainer.Name like '%{txtSearch.Text}%')");
            dgv1.DataSource = db.GetDataTable();
        }
    }
}
