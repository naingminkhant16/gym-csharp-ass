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

        private void btnLogout_Click(object sender, EventArgs e)
        {

            Auth.Logout();

            frmAdminLogin adminLogin = new frmAdminLogin();
            this.Hide();
            adminLogin.Show();
        }

        private void frmAdminMenu_Load(object sender, EventArgs e)
        {
            loginAsToolStripMenuItem.Text += " " + Auth.Username;
        }

        private void btnTrainers_Click(object sender, EventArgs e)
        {
            frmAdminTrainers trainers = new frmAdminTrainers();
            this.Hide();
            trainers.Show();
        }

        private void adminSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword();
            this.Hide();
            changePassword.Show();
        }
    }
}
