namespace PromotItFormApp.RegisterPanels
{
    partial class AdminRegisterPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminRegisterPanel));
            this.labelAdminTitle = new System.Windows.Forms.Label();
            this.lnlName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.pnlPanelTop = new System.Windows.Forms.Panel();
            this.btnX = new System.Windows.Forms.Button();
            this.pnlPanelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAdminTitle
            // 
            this.labelAdminTitle.AutoSize = true;
            this.labelAdminTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelAdminTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAdminTitle.ForeColor = System.Drawing.Color.White;
            this.labelAdminTitle.Location = new System.Drawing.Point(13, 29);
            this.labelAdminTitle.Name = "labelAdminTitle";
            this.labelAdminTitle.Size = new System.Drawing.Size(195, 28);
            this.labelAdminTitle.TabIndex = 0;
            this.labelAdminTitle.Text = "Admin  Registeration";
            // 
            // lnlName
            // 
            this.lnlName.AutoSize = true;
            this.lnlName.Location = new System.Drawing.Point(13, 108);
            this.lnlName.Name = "lnlName";
            this.lnlName.Size = new System.Drawing.Size(79, 20);
            this.lnlName.TabIndex = 0;
            this.lnlName.Text = "Full Name:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(13, 172);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(78, 20);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 234);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 20);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Password:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 131);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(407, 27);
            this.txtName.TabIndex = 0;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(12, 195);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(407, 27);
            this.txtUserName.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 257);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(407, 27);
            this.txtPassword.TabIndex = 3;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(149, 413);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(172, 47);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.buttonAdminRegister_ClickAsync);
            // 
            // pnlPanelTop
            // 
            this.pnlPanelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(145)))), ((int)(((byte)(139)))));
            this.pnlPanelTop.Controls.Add(this.btnX);
            this.pnlPanelTop.Controls.Add(this.labelAdminTitle);
            this.pnlPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPanelTop.Location = new System.Drawing.Point(0, 0);
            this.pnlPanelTop.Name = "pnlPanelTop";
            this.pnlPanelTop.Size = new System.Drawing.Size(487, 83);
            this.pnlPanelTop.TabIndex = 3;
            this.pnlPanelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAdminRegistr_Paint);
            // 
            // btnX
            // 
            this.btnX.FlatAppearance.BorderSize = 0;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Image = ((System.Drawing.Image)(resources.GetObject("btnX.Image")));
            this.btnX.Location = new System.Drawing.Point(421, 23);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(54, 46);
            this.btnX.TabIndex = 5;
            this.btnX.UseVisualStyleBackColor = true;
            this.btnX.Click += new System.EventHandler(this.buttonCloseAdminForm_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 523);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lnlName);
            this.Controls.Add(this.pnlPanelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(505, 570);
            this.MinimumSize = new System.Drawing.Size(505, 570);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register - Admin";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.pnlPanelTop.ResumeLayout(false);
            this.pnlPanelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAdminTitle;
        private System.Windows.Forms.Label lnlName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Panel pnlPanelTop;
        private System.Windows.Forms.Button btnX;
    }
}