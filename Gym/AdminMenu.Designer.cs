
namespace Gym
{
    partial class frmAdminMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTrainers = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMembers = new System.Windows.Forms.Button();
            this.btnGymClasses = new System.Windows.Forms.Button();
            this.btnEnrollment = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTrainers
            // 
            this.btnTrainers.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnTrainers.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrainers.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTrainers.Location = new System.Drawing.Point(439, 146);
            this.btnTrainers.Name = "btnTrainers";
            this.btnTrainers.Size = new System.Drawing.Size(216, 48);
            this.btnTrainers.TabIndex = 0;
            this.btnTrainers.Text = "Trainers";
            this.btnTrainers.UseVisualStyleBackColor = false;
            this.btnTrainers.Click += new System.EventHandler(this.btnTrainers_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(273, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Admin Dashboard";
            // 
            // btnMembers
            // 
            this.btnMembers.BackColor = System.Drawing.Color.Purple;
            this.btnMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMembers.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMembers.Location = new System.Drawing.Point(439, 247);
            this.btnMembers.Name = "btnMembers";
            this.btnMembers.Size = new System.Drawing.Size(216, 48);
            this.btnMembers.TabIndex = 3;
            this.btnMembers.Text = "Members";
            this.btnMembers.UseVisualStyleBackColor = false;
            this.btnMembers.Click += new System.EventHandler(this.btnMembers_Click);
            // 
            // btnGymClasses
            // 
            this.btnGymClasses.BackColor = System.Drawing.Color.Maroon;
            this.btnGymClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGymClasses.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGymClasses.Location = new System.Drawing.Point(169, 146);
            this.btnGymClasses.Name = "btnGymClasses";
            this.btnGymClasses.Size = new System.Drawing.Size(216, 48);
            this.btnGymClasses.TabIndex = 4;
            this.btnGymClasses.Text = "Gym Classes";
            this.btnGymClasses.UseVisualStyleBackColor = false;
            this.btnGymClasses.Click += new System.EventHandler(this.btnGymClasses_Click);
            // 
            // btnEnrollment
            // 
            this.btnEnrollment.BackColor = System.Drawing.Color.Navy;
            this.btnEnrollment.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnrollment.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEnrollment.Location = new System.Drawing.Point(169, 247);
            this.btnEnrollment.Name = "btnEnrollment";
            this.btnEnrollment.Size = new System.Drawing.Size(216, 48);
            this.btnEnrollment.TabIndex = 5;
            this.btnEnrollment.Text = "Enrollment";
            this.btnEnrollment.UseVisualStyleBackColor = false;
            this.btnEnrollment.Click += new System.EventHandler(this.btnEnrollment_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminSettingToolStripMenuItem,
            this.addNewAdminToolStripMenuItem,
            this.loginAsToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminSettingToolStripMenuItem
            // 
            this.adminSettingToolStripMenuItem.Name = "adminSettingToolStripMenuItem";
            this.adminSettingToolStripMenuItem.Size = new System.Drawing.Size(131, 20);
            this.adminSettingToolStripMenuItem.Text = "⚙️ Change Password ";
            this.adminSettingToolStripMenuItem.Click += new System.EventHandler(this.adminSettingToolStripMenuItem_Click);
            // 
            // addNewAdminToolStripMenuItem
            // 
            this.addNewAdminToolStripMenuItem.Name = "addNewAdminToolStripMenuItem";
            this.addNewAdminToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.addNewAdminToolStripMenuItem.Text = "Add New Admin";
            this.addNewAdminToolStripMenuItem.Click += new System.EventHandler(this.addNewAdminToolStripMenuItem_Click);
            // 
            // loginAsToolStripMenuItem
            // 
            this.loginAsToolStripMenuItem.Enabled = false;
            this.loginAsToolStripMenuItem.Name = "loginAsToolStripMenuItem";
            this.loginAsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.loginAsToolStripMenuItem.Text = "Login As";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // frmAdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEnrollment);
            this.Controls.Add(this.btnGymClasses);
            this.Controls.Add(this.btnMembers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTrainers);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmAdminMenu";
            this.Text = "Admin Dashborad";
            this.Load += new System.EventHandler(this.frmAdminMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTrainers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMembers;
        private System.Windows.Forms.Button btnGymClasses;
        private System.Windows.Forms.Button btnEnrollment;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
    }
}