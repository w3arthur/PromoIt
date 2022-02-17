namespace PromotItFormApp.RegisterPanels
{
    partial class RegisterPanel
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
            this.chkAdmin = new System.Windows.Forms.RadioButton();
            this.chkNonProfit = new System.Windows.Forms.RadioButton();
            this.chkBuisness = new System.Windows.Forms.RadioButton();
            this.chkActivist = new System.Windows.Forms.RadioButton();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblRegister = new System.Windows.Forms.Label();
            this.pnlPanelTop = new System.Windows.Forms.Panel();
            this.pnlPanelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Location = new System.Drawing.Point(162, 140);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(74, 24);
            this.chkAdmin.TabIndex = 0;
            this.chkAdmin.TabStop = true;
            this.chkAdmin.Text = "Admin";
            this.chkAdmin.UseVisualStyleBackColor = true;
            this.chkAdmin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radioButtonAdmin_KeyDown);
            // 
            // chkNonProfit
            // 
            this.chkNonProfit.AutoSize = true;
            this.chkNonProfit.Location = new System.Drawing.Point(162, 193);
            this.chkNonProfit.Name = "chkNonProfit";
            this.chkNonProfit.Size = new System.Drawing.Size(190, 24);
            this.chkNonProfit.TabIndex = 1;
            this.chkNonProfit.TabStop = true;
            this.chkNonProfit.Text = "Non-Profit Organization";
            this.chkNonProfit.UseVisualStyleBackColor = true;
            this.chkNonProfit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radioButtonNPO_KeyDown);
            // 
            // chkBuisness
            // 
            this.chkBuisness.AutoSize = true;
            this.chkBuisness.Location = new System.Drawing.Point(162, 240);
            this.chkBuisness.Name = "chkBuisness";
            this.chkBuisness.Size = new System.Drawing.Size(152, 24);
            this.chkBuisness.TabIndex = 2;
            this.chkBuisness.TabStop = true;
            this.chkBuisness.Text = "Business Company";
            this.chkBuisness.UseVisualStyleBackColor = true;
            this.chkBuisness.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radioButtonBSR_KeyDown);
            // 
            // chkActivist
            // 
            this.chkActivist.AutoSize = true;
            this.chkActivist.Location = new System.Drawing.Point(162, 294);
            this.chkActivist.Name = "chkActivist";
            this.chkActivist.Size = new System.Drawing.Size(122, 24);
            this.chkActivist.TabIndex = 3;
            this.chkActivist.TabStop = true;
            this.chkActivist.Text = "Social Activist";
            this.chkActivist.UseVisualStyleBackColor = true;
            this.chkActivist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radioButtonSA_KeyDown);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(116, 402);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(246, 47);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Confirm";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.buttonRegisterRole_Click);
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.BackColor = System.Drawing.Color.Transparent;
            this.lblRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRegister.ForeColor = System.Drawing.Color.White;
            this.lblRegister.Location = new System.Drawing.Point(12, 33);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(135, 28);
            this.lblRegister.TabIndex = 2;
            this.lblRegister.Text = "Role Selection";
            // 
            // pnlPanelTop
            // 
            this.pnlPanelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(145)))), ((int)(((byte)(139)))));
            this.pnlPanelTop.Controls.Add(this.lblRegister);
            this.pnlPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPanelTop.Location = new System.Drawing.Point(0, 0);
            this.pnlPanelTop.Name = "pnlPanelTop";
            this.pnlPanelTop.Size = new System.Drawing.Size(487, 99);
            this.pnlPanelTop.TabIndex = 3;
            this.pnlPanelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRoleRegister_Paint);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 523);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.chkActivist);
            this.Controls.Add(this.chkBuisness);
            this.Controls.Add(this.chkNonProfit);
            this.Controls.Add(this.chkAdmin);
            this.Controls.Add(this.pnlPanelTop);
            this.Location = new System.Drawing.Point(450, 480);
            this.MaximumSize = new System.Drawing.Size(505, 570);
            this.MinimumSize = new System.Drawing.Size(505, 570);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promoit Register";
            this.Load += new System.EventHandler(this.RoleSystem_Load);
            this.pnlPanelTop.ResumeLayout(false);
            this.pnlPanelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton chkAdmin;
        private System.Windows.Forms.RadioButton chkNonProfit;
        private System.Windows.Forms.RadioButton chkBuisness;
        private System.Windows.Forms.RadioButton chkActivist;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.Panel pnlPanelTop;
    }
}