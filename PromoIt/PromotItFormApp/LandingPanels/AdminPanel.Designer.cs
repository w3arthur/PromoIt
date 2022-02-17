namespace PromotItFormApp.LandingPanels
{
    partial class AdminPanel
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
            this.pnlPanelTop = new System.Windows.Forms.Panel();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.btnCampaignsReport = new System.Windows.Forms.Button();
            this.btnUsersReport = new System.Windows.Forms.Button();
            this.btnTweetsReport = new System.Windows.Forms.Button();
            this.lblReportsData = new System.Windows.Forms.Label();
            this.dgrdReportsData = new System.Windows.Forms.DataGridView();
            this.pnlPanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdReportsData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPanelTop
            // 
            this.pnlPanelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(145)))), ((int)(((byte)(139)))));
            this.pnlPanelTop.Controls.Add(this.lblAdmin);
            this.pnlPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPanelTop.Location = new System.Drawing.Point(0, 0);
            this.pnlPanelTop.Name = "pnlPanelTop";
            this.pnlPanelTop.Size = new System.Drawing.Size(579, 135);
            this.pnlPanelTop.TabIndex = 0;
            this.pnlPanelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAdmin_Paint);
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAdmin.ForeColor = System.Drawing.Color.White;
            this.lblAdmin.Location = new System.Drawing.Point(11, 43);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(159, 28);
            this.lblAdmin.TabIndex = 0;
            this.lblAdmin.Text = "ProLobby Owner";
            // 
            // btnCampaignsReport
            // 
            this.btnCampaignsReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            this.btnCampaignsReport.FlatAppearance.BorderSize = 0;
            this.btnCampaignsReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCampaignsReport.ForeColor = System.Drawing.Color.White;
            this.btnCampaignsReport.Location = new System.Drawing.Point(11, 251);
            this.btnCampaignsReport.Name = "btnCampaignsReport";
            this.btnCampaignsReport.Size = new System.Drawing.Size(171, 47);
            this.btnCampaignsReport.TabIndex = 0;
            this.btnCampaignsReport.Text = "Campaigns";
            this.btnCampaignsReport.UseVisualStyleBackColor = false;
            this.btnCampaignsReport.Click += new System.EventHandler(this.buttonCampaignsAdmin_Click);
            // 
            // btnUsersReport
            // 
            this.btnUsersReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            this.btnUsersReport.FlatAppearance.BorderSize = 0;
            this.btnUsersReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsersReport.ForeColor = System.Drawing.Color.White;
            this.btnUsersReport.Location = new System.Drawing.Point(203, 251);
            this.btnUsersReport.Name = "btnUsersReport";
            this.btnUsersReport.Size = new System.Drawing.Size(171, 47);
            this.btnUsersReport.TabIndex = 0;
            this.btnUsersReport.Text = "Users";
            this.btnUsersReport.UseVisualStyleBackColor = false;
            this.btnUsersReport.Click += new System.EventHandler(this.buttonUsersAdmin_Click);
            // 
            // btnTweetsReport
            // 
            this.btnTweetsReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            this.btnTweetsReport.FlatAppearance.BorderSize = 0;
            this.btnTweetsReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTweetsReport.ForeColor = System.Drawing.Color.White;
            this.btnTweetsReport.Location = new System.Drawing.Point(398, 251);
            this.btnTweetsReport.Name = "btnTweetsReport";
            this.btnTweetsReport.Size = new System.Drawing.Size(171, 47);
            this.btnTweetsReport.TabIndex = 0;
            this.btnTweetsReport.Text = "Tweets";
            this.btnTweetsReport.UseVisualStyleBackColor = false;
            this.btnTweetsReport.Click += new System.EventHandler(this.buttonTweetsAdmin_Click);
            // 
            // lblReportsData
            // 
            this.lblReportsData.AutoSize = true;
            this.lblReportsData.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblReportsData.Location = new System.Drawing.Point(11, 192);
            this.lblReportsData.Name = "lblReportsData";
            this.lblReportsData.Size = new System.Drawing.Size(97, 31);
            this.lblReportsData.TabIndex = 0;
            this.lblReportsData.Text = "Reports:";
            // 
            // dgrdReportsData
            // 
            this.dgrdReportsData.AllowUserToAddRows = false;
            this.dgrdReportsData.AllowUserToDeleteRows = false;
            this.dgrdReportsData.AllowUserToResizeColumns = false;
            this.dgrdReportsData.AllowUserToResizeRows = false;
            this.dgrdReportsData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrdReportsData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrdReportsData.BackgroundColor = System.Drawing.Color.White;
            this.dgrdReportsData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgrdReportsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdReportsData.GridColor = System.Drawing.Color.White;
            this.dgrdReportsData.Location = new System.Drawing.Point(11, 320);
            this.dgrdReportsData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgrdReportsData.MultiSelect = false;
            this.dgrdReportsData.Name = "dgrdReportsData";
            this.dgrdReportsData.ReadOnly = true;
            this.dgrdReportsData.RowHeadersVisible = false;
            this.dgrdReportsData.RowHeadersWidth = 51;
            this.dgrdReportsData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgrdReportsData.RowTemplate.Height = 25;
            this.dgrdReportsData.ShowEditingIcon = false;
            this.dgrdReportsData.Size = new System.Drawing.Size(557, 305);
            this.dgrdReportsData.TabIndex = 0;
            // 
            // pnlAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 637);
            this.Controls.Add(this.dgrdReportsData);
            this.Controls.Add(this.lblReportsData);
            this.Controls.Add(this.btnTweetsReport);
            this.Controls.Add(this.btnUsersReport);
            this.Controls.Add(this.btnCampaignsReport);
            this.Controls.Add(this.pnlPanelTop);
            this.MaximumSize = new System.Drawing.Size(597, 684);
            this.MinimumSize = new System.Drawing.Size(597, 684);
            this.Name = "pnlAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promoit - Admin Dashboard";
            this.pnlPanelTop.ResumeLayout(false);
            this.pnlPanelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdReportsData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPanelTop;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Button btnCampaignsReport;
        private System.Windows.Forms.Button btnUsersReport;
        private System.Windows.Forms.Button btnTweetsReport;
        private System.Windows.Forms.Label lblReportsData;
        private System.Windows.Forms.DataGridView dgrdReportsData;
    }
}