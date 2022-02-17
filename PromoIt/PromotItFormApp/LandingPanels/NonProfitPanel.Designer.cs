namespace PromotItFormApp.LandingPanels
{
    partial class NonProfitPanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlPanelTop = new System.Windows.Forms.Panel();
            this.lblNonProfitOrganization = new System.Windows.Forms.Label();
            this.pnlPanelBottom = new System.Windows.Forms.Panel();
            this.dgrdNonProfit = new System.Windows.Forms.DataGridView();
            this.clmnCampaignName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnHashtag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.webpage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCreator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDeleteGrid = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnNewCampaign = new System.Windows.Forms.Button();
            this.pnlPanelTop.SuspendLayout();
            this.pnlPanelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdNonProfit)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPanelTop
            // 
            this.pnlPanelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(145)))), ((int)(((byte)(139)))));
            this.pnlPanelTop.Controls.Add(this.lblNonProfitOrganization);
            this.pnlPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPanelTop.Location = new System.Drawing.Point(0, 0);
            this.pnlPanelTop.Name = "pnlPanelTop";
            this.pnlPanelTop.Size = new System.Drawing.Size(1141, 135);
            this.pnlPanelTop.TabIndex = 0;
            this.pnlPanelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelNPO_Paint);
            // 
            // lblNonProfitOrganization
            // 
            this.lblNonProfitOrganization.AutoSize = true;
            this.lblNonProfitOrganization.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNonProfitOrganization.ForeColor = System.Drawing.Color.White;
            this.lblNonProfitOrganization.Location = new System.Drawing.Point(12, 50);
            this.lblNonProfitOrganization.Name = "lblNonProfitOrganization";
            this.lblNonProfitOrganization.Size = new System.Drawing.Size(225, 28);
            this.lblNonProfitOrganization.TabIndex = 0;
            this.lblNonProfitOrganization.Text = "Non-Profit Organization";
            // 
            // pnlPanelBottom
            // 
            this.pnlPanelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPanelBottom.BackColor = System.Drawing.Color.White;
            this.pnlPanelBottom.Controls.Add(this.dgrdNonProfit);
            this.pnlPanelBottom.Controls.Add(this.btnNewCampaign);
            this.pnlPanelBottom.Location = new System.Drawing.Point(28, 160);
            this.pnlPanelBottom.Name = "pnlPanelBottom";
            this.pnlPanelBottom.Size = new System.Drawing.Size(1084, 429);
            this.pnlPanelBottom.TabIndex = 0;
            // 
            // dgrdNonProfit
            // 
            this.dgrdNonProfit.AllowUserToAddRows = false;
            this.dgrdNonProfit.AllowUserToDeleteRows = false;
            this.dgrdNonProfit.AllowUserToResizeColumns = false;
            this.dgrdNonProfit.AllowUserToResizeRows = false;
            this.dgrdNonProfit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrdNonProfit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrdNonProfit.BackgroundColor = System.Drawing.Color.White;
            this.dgrdNonProfit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgrdNonProfit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdNonProfit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnCampaignName,
            this.clmnHashtag,
            this.webpage,
            this.clmnCreator,
            this.buttonDeleteGrid});
            this.dgrdNonProfit.GridColor = System.Drawing.Color.White;
            this.dgrdNonProfit.Location = new System.Drawing.Point(17, 90);
            this.dgrdNonProfit.MultiSelect = false;
            this.dgrdNonProfit.Name = "dgrdNonProfit";
            this.dgrdNonProfit.ReadOnly = true;
            this.dgrdNonProfit.RowHeadersVisible = false;
            this.dgrdNonProfit.RowHeadersWidth = 51;
            this.dgrdNonProfit.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgrdNonProfit.RowTemplate.Height = 29;
            this.dgrdNonProfit.ShowEditingIcon = false;
            this.dgrdNonProfit.Size = new System.Drawing.Size(1051, 321);
            this.dgrdNonProfit.TabIndex = 0;
            this.dgrdNonProfit.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridNPO_CellClick);
            // 
            // clmnCampaignName
            // 
            this.clmnCampaignName.DataPropertyName = "clmnCampaignName";
            this.clmnCampaignName.HeaderText = "Campaign Name";
            this.clmnCampaignName.MinimumWidth = 6;
            this.clmnCampaignName.Name = "clmnCampaignName";
            this.clmnCampaignName.ReadOnly = true;
            // 
            // clmnHashtag
            // 
            this.clmnHashtag.DataPropertyName = "clmnHashtag";
            this.clmnHashtag.HeaderText = "Hashtag";
            this.clmnHashtag.MinimumWidth = 6;
            this.clmnHashtag.Name = "clmnHashtag";
            this.clmnHashtag.ReadOnly = true;
            // 
            // webpage
            // 
            this.webpage.DataPropertyName = "clmnWebsite";
            this.webpage.HeaderText = "URL";
            this.webpage.MinimumWidth = 6;
            this.webpage.Name = "webpage";
            this.webpage.ReadOnly = true;
            // 
            // clmnCreator
            // 
            this.clmnCreator.DataPropertyName = "clmnCreator";
            this.clmnCreator.HeaderText = "Campaign Creator";
            this.clmnCreator.MinimumWidth = 6;
            this.clmnCreator.Name = "clmnCreator";
            this.clmnCreator.ReadOnly = true;
            // 
            // buttonDeleteGrid
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.buttonDeleteGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.buttonDeleteGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteGrid.HeaderText = "";
            this.buttonDeleteGrid.MinimumWidth = 6;
            this.buttonDeleteGrid.Name = "buttonDeleteGrid";
            this.buttonDeleteGrid.ReadOnly = true;
            this.buttonDeleteGrid.Text = "Delete";
            this.buttonDeleteGrid.UseColumnTextForButtonValue = true;
            // 
            // btnNewCampaign
            // 
            this.btnNewCampaign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            this.btnNewCampaign.FlatAppearance.BorderSize = 0;
            this.btnNewCampaign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewCampaign.ForeColor = System.Drawing.Color.White;
            this.btnNewCampaign.Location = new System.Drawing.Point(17, 21);
            this.btnNewCampaign.Name = "btnNewCampaign";
            this.btnNewCampaign.Size = new System.Drawing.Size(172, 47);
            this.btnNewCampaign.TabIndex = 0;
            this.btnNewCampaign.Text = "New";
            this.btnNewCampaign.UseVisualStyleBackColor = false;
            this.btnNewCampaign.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // NonProfitPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 605);
            this.Controls.Add(this.pnlPanelBottom);
            this.Controls.Add(this.pnlPanelTop);
            this.MaximumSize = new System.Drawing.Size(1159, 652);
            this.MinimumSize = new System.Drawing.Size(1159, 652);
            this.Name = "NonProfitPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Non-Profit Organzation Dashboard";
            this.Shown += new System.EventHandler(this.NPOrganizationPanel_Shown);
            this.pnlPanelTop.ResumeLayout(false);
            this.pnlPanelTop.PerformLayout();
            this.pnlPanelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdNonProfit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPanelTop;
        private System.Windows.Forms.Label lblNonProfitOrganization;
        private System.Windows.Forms.Panel pnlPanelBottom;
        private System.Windows.Forms.Button btnNewCampaign;
        private System.Windows.Forms.DataGridView dgrdNonProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnCampaignName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnHashtag;
        private System.Windows.Forms.DataGridViewTextBoxColumn webpage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnCreator;
        private System.Windows.Forms.DataGridViewButtonColumn buttonDeleteGrid;
    }
}