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
    public partial class frmUserTrainer : Form
    {
        public frmUserTrainer()
        {
            InitializeComponent();
        }

        private void frmUserTrainer_Load(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection("select * from Trainer");
            dgv1.DataSource = db.GetDataTable();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmUserMenu userMenu = new frmUserMenu();
            this.Hide();
            userMenu.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection($"select * from Trainer where Name like " +
                $"'%{txtSearch.Text.Trim()}%' or Id like '%{txtSearch.Text.Trim()}%'");
            dgv1.DataSource = db.GetDataTable();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection("select * from Trainer");
            dgv1.DataSource = db.GetDataTable();
        }
    }
}
