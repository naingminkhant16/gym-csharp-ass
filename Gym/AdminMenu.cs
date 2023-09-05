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
    public partial class frmAdminMenu : Form
    {
        public frmAdminMenu()
        {
            InitializeComponent();
        }

        private void frmAdminMenu_Load(object sender, EventArgs e)
        {
            loginAsToolStripMenuItem.Text += " " + Auth.Username;
        }     

        private void adminSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword("Admin");
            this.Hide();
            changePassword.Show();
        }

        private void addNewAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewAdmin newAdmin = new frmAddNewAdmin();
            this.Hide();
            newAdmin.Show();
        }    

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Auth.Logout();
            frmAdminLogin adminLogin = new frmAdminLogin();
            this.Hide();
            adminLogin.Show();
        }

        private void btnTrainer_Click(object sender, EventArgs e)
        {
            frmAdminTrainers trainers = new frmAdminTrainers();
            this.Hide();
            trainers.Show();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            frmAdminMember adminMember = new frmAdminMember();
            this.Hide();
            adminMember.Show();
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            frmAdminGymClass gymClass = new frmAdminGymClass();
            this.Hide();
            gymClass.Show();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            frmAdminEnrollment adminEnrollment = new frmAdminEnrollment();
            this.Hide();
            adminEnrollment.Show();
        }
    }
}
