
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
            this.btnClasses = new System.Windows.Forms.Button();
            this.btnEnrollment = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTrainers
            // 
            this.btnTrainers.BackColor = System.Drawing.Color.Red;
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
            this.btnMembers.BackColor = System.Drawing.Color.Fuchsia;
            this.btnMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMembers.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMembers.Location = new System.Drawing.Point(439, 247);
            this.btnMembers.Name = "btnMembers";
            this.btnMembers.Size = new System.Drawing.Size(216, 48);
            this.btnMembers.TabIndex = 3;
            this.btnMembers.Text = "Members";
            this.btnMembers.UseVisualStyleBackColor = false;
            // 
            // btnClasses
            // 
            this.btnClasses.BackColor = System.Drawing.Color.Blue;
            this.btnClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClasses.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClasses.Location = new System.Drawing.Point(169, 146);
            this.btnClasses.Name = "btnClasses";
            this.btnClasses.Size = new System.Drawing.Size(216, 48);
            this.btnClasses.TabIndex = 4;
            this.btnClasses.Text = "Gym Classes";
            this.btnClasses.UseVisualStyleBackColor = false;
            // 
            // btnEnrollment
            // 
            this.btnEnrollment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEnrollment.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnrollment.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEnrollment.Location = new System.Drawing.Point(169, 247);
            this.btnEnrollment.Name = "btnEnrollment";
            this.btnEnrollment.Size = new System.Drawing.Size(216, 48);
            this.btnEnrollment.TabIndex = 5;
            this.btnEnrollment.Text = "Enrollment";
            this.btnEnrollment.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogout.Location = new System.Drawing.Point(373, 350);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(78, 36);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminSettingToolStripMenuItem,
            this.loginAsToolStripMenuItem});
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
            // loginAsToolStripMenuItem
            // 
            this.loginAsToolStripMenuItem.Enabled = false;
            this.loginAsToolStripMenuItem.Name = "loginAsToolStripMenuItem";
            this.loginAsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.loginAsToolStripMenuItem.Text = "Login As";
            // 
            // frmAdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Gym.Properties.Resources.R;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnEnrollment);
            this.Controls.Add(this.btnClasses);
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
        private System.Windows.Forms.Button btnClasses;
        private System.Windows.Forms.Button btnEnrollment;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginAsToolStripMenuItem;
    }
}