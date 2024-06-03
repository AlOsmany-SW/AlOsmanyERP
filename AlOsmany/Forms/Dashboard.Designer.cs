using System;

namespace AlOsmany.Forms
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUserInfo = new System.Windows.Forms.Button();
            this.btnServices = new System.Windows.Forms.Button();
            this.btnRequests = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.userListToolStripMenuItem,
            this.newUserToolStripMenuItem,
            this.newServiceToolStripMenuItem,
            this.yearReportToolStripMenuItem,
            this.serviceReportToolStripMenuItem,
            this.customerReportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(732, 28);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.exitToolStripMenuItem.Text = "EXIT";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // userListToolStripMenuItem
            // 
            this.userListToolStripMenuItem.Name = "userListToolStripMenuItem";
            this.userListToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.userListToolStripMenuItem.Text = "User List";
            this.userListToolStripMenuItem.Click += new System.EventHandler(this.userListToolStripMenuItem_Click);
            // 
            // newUserToolStripMenuItem
            // 
            this.newUserToolStripMenuItem.Name = "newUserToolStripMenuItem";
            this.newUserToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.newUserToolStripMenuItem.Text = "New User";
            this.newUserToolStripMenuItem.Click += new System.EventHandler(this.newUserToolStripMenuItem_Click);
            // 
            // newServiceToolStripMenuItem
            // 
            this.newServiceToolStripMenuItem.Name = "newServiceToolStripMenuItem";
            this.newServiceToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.newServiceToolStripMenuItem.Text = "New Service";
            this.newServiceToolStripMenuItem.Click += new System.EventHandler(this.newServiceToolStripMenuItem_Click_1);
            // 
            // yearReportToolStripMenuItem
            // 
            this.yearReportToolStripMenuItem.Name = "yearReportToolStripMenuItem";
            this.yearReportToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.yearReportToolStripMenuItem.Text = "Year Report";
            this.yearReportToolStripMenuItem.Click += new System.EventHandler(this.yearReportToolStripMenuItem_Click);
            // 
            // serviceReportToolStripMenuItem
            // 
            this.serviceReportToolStripMenuItem.Name = "serviceReportToolStripMenuItem";
            this.serviceReportToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.serviceReportToolStripMenuItem.Text = "Service Report";
            this.serviceReportToolStripMenuItem.Click += new System.EventHandler(this.serviceReportToolStripMenuItem_Click);
            // 
            // customerReportToolStripMenuItem
            // 
            this.customerReportToolStripMenuItem.Name = "customerReportToolStripMenuItem";
            this.customerReportToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.customerReportToolStripMenuItem.Text = "Customer Report";
            this.customerReportToolStripMenuItem.Click += new System.EventHandler(this.customerReportToolStripMenuItem_Click);
            // 
            // btnUserInfo
            // 
            this.btnUserInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnUserInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUserInfo.BackgroundImage")));
            this.btnUserInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUserInfo.FlatAppearance.BorderSize = 0;
            this.btnUserInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserInfo.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserInfo.Location = new System.Drawing.Point(500, 425);
            this.btnUserInfo.Name = "btnUserInfo";
            this.btnUserInfo.Size = new System.Drawing.Size(150, 150);
            this.btnUserInfo.TabIndex = 43;
            this.btnUserInfo.UseVisualStyleBackColor = false;
            this.btnUserInfo.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnServices
            // 
            this.btnServices.BackColor = System.Drawing.Color.Transparent;
            this.btnServices.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnServices.BackgroundImage")));
            this.btnServices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnServices.FlatAppearance.BorderSize = 0;
            this.btnServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServices.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServices.Location = new System.Drawing.Point(285, 275);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(150, 150);
            this.btnServices.TabIndex = 44;
            this.btnServices.UseVisualStyleBackColor = false;
            this.btnServices.Visible = false;
            this.btnServices.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRequests
            // 
            this.btnRequests.BackColor = System.Drawing.Color.Transparent;
            this.btnRequests.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRequests.BackgroundImage")));
            this.btnRequests.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRequests.FlatAppearance.BorderSize = 0;
            this.btnRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequests.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequests.Location = new System.Drawing.Point(85, 105);
            this.btnRequests.Name = "btnRequests";
            this.btnRequests.Size = new System.Drawing.Size(150, 150);
            this.btnRequests.TabIndex = 45;
            this.btnRequests.UseVisualStyleBackColor = false;
            this.btnRequests.Click += new System.EventHandler(this.button3_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(732, 653);
            this.Controls.Add(this.btnRequests);
            this.Controls.Add(this.btnServices);
            this.Controls.Add(this.btnUserInfo);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yearReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerReportToolStripMenuItem;
        private System.Windows.Forms.Button btnUserInfo;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.ToolStripMenuItem userListToolStripMenuItem;
        private System.Windows.Forms.Button btnRequests;
    }
}