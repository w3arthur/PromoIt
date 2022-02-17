namespace PromotItFormApp.ChildPanels
{
    partial class CompanyChildPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyChildPanel));
            this.pnlPanelGlobal = new System.Windows.Forms.Panel();
            this.lblBottom = new System.Windows.Forms.Label();
            this.lblLableTop = new System.Windows.Forms.Label();
            this.labelServiceComp = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.pnlPanelGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPanelGlobal
            // 
            this.pnlPanelGlobal.BackColor = System.Drawing.Color.White;
            this.pnlPanelGlobal.Controls.Add(this.lblBottom);
            this.pnlPanelGlobal.Controls.Add(this.lblLableTop);
            this.pnlPanelGlobal.Controls.Add(this.labelServiceComp);
            this.pnlPanelGlobal.Controls.Add(this.btnPrevious);
            this.pnlPanelGlobal.Location = new System.Drawing.Point(-2, 0);
            this.pnlPanelGlobal.Name = "pnlPanelGlobal";
            this.pnlPanelGlobal.Size = new System.Drawing.Size(863, 461);
            this.pnlPanelGlobal.TabIndex = 0;
            // 
            // lblBottom
            // 
            this.lblBottom.AutoSize = true;
            this.lblBottom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBottom.Location = new System.Drawing.Point(14, 181);
            this.lblBottom.Name = "lblBottom";
            this.lblBottom.Size = new System.Drawing.Size(604, 60);
            this.lblBottom.TabIndex = 0;
            this.lblBottom.Text = "Conditions should be fully achieved before a deposit takes place in the user\'s ba" +
    "lance.\r\n\r\n (Read the previous page)";
            // 
            // lblLableTop
            // 
            this.lblLableTop.AutoSize = true;
            this.lblLableTop.Location = new System.Drawing.Point(14, 52);
            this.lblLableTop.Name = "lblLableTop";
            this.lblLableTop.Size = new System.Drawing.Size(813, 120);
            this.lblLableTop.TabIndex = 0;
            this.lblLableTop.Text = resources.GetString("lblLableTop.Text");
            // 
            // labelServiceComp
            // 
            this.labelServiceComp.AutoSize = true;
            this.labelServiceComp.BackColor = System.Drawing.Color.Transparent;
            this.labelServiceComp.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelServiceComp.ForeColor = System.Drawing.Color.White;
            this.labelServiceComp.Location = new System.Drawing.Point(11, 10);
            this.labelServiceComp.Name = "labelServiceComp";
            this.labelServiceComp.Size = new System.Drawing.Size(117, 31);
            this.labelServiceComp.TabIndex = 0;
            this.labelServiceComp.Text = "IS IT FREE?";
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(14, 403);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(151, 35);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.buttonPreviousCompany_Click);
            // 
            // CompanyChildPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 450);
            this.Controls.Add(this.pnlPanelGlobal);
            this.MaximumSize = new System.Drawing.Size(872, 497);
            this.MinimumSize = new System.Drawing.Size(872, 497);
            this.Name = "CompanyChildPage";
            this.Text = "Promoit - CompanyChildPage";
            this.Load += new System.EventHandler(this.CompanyChildPage_Load);
            this.pnlPanelGlobal.ResumeLayout(false);
            this.pnlPanelGlobal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPanelGlobal;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblLableTop;
        private System.Windows.Forms.Label labelServiceComp;
        private System.Windows.Forms.Label lblBottom;
    }
}