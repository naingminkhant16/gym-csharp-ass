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
    public partial class frmUserMenu : Form
    {
        public frmUserMenu()
        {
            InitializeComponent();
        }

        private void frmUserMenu_Load(object sender, EventArgs e)
        {
            lblWelcome.Text += " " + Auth.Username;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Auth.Logout();
            frmWelcome welcome = new frmWelcome();
            this.Hide();
            welcome.Show();
        }

        private void btnTrainer_Click(object sender, EventArgs e)
        {
            frmUserTrainer userTrainer = new frmUserTrainer();
            this.Hide();
            userTrainer.Show();

        }

        private void btnClasses_Click(object sender, EventArgs e)
        {
            frmUserClass userClass = new frmUserClass();
            this.Hide();
            userClass.Show();
        }

        private void myEnrolledClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserEnrolledClasses enrolledClasses = new frmUserEnrolledClasses();
            this.Hide();
            enrolledClasses.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword("Member");
            changePassword.Show();
            this.Hide();
        }

        private void editProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserEditProfile editProfile = new frmUserEditProfile();
            editProfile.Show();
            this.Hide();
        }

       
    }
}
