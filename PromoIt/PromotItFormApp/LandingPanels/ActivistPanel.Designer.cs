namespace PromotItFormApp.LandingPanels
{
    partial class ActivistPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivistPanel));
            this.pnlPanelBottom = new System.Windows.Forms.Panel();
            this.dgrdCampaigns = new System.Windows.Forms.DataGridView();
            this.clmnHashtag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnWebpage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonProductListGrid = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridNPO = new System.Windows.Forms.DataGridView();
            this.pnlPanelTop = new System.Windows.Forms.Panel();
            this.labelSATitle = new System.Windows.Forms.Label();
            this.panelBalance = new System.Windows.Forms.Panel();
            this.txtCashBalanceCheck = new System.Windows.Forms.Label();
            this.lblTotalBalance = new System.Windows.Forms.Label();
            this.panelMessages = new System.Windows.Forms.Panel();
            this.lblMessages = new System.Windows.Forms.Label();
            this.pnlPanelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdCampaigns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNPO)).BeginInit();
            this.pnlPanelTop.SuspendLayout();
            this.panelBalance.SuspendLayout();
            this.panelMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPanelBottom
            // 
            this.pnlPanelBottom.BackColor = System.Drawing.Color.White;
            this.pnlPanelBottom.Controls.Add(this.dgrdCampaigns);
            this.pnlPanelBottom.Controls.Add(this.dataGridNPO);
            this.pnlPanelBottom.Location = new System.Drawing.Point(20, 283);
            this.pnlPanelBottom.Name = "pnlPanelBottom";
            this.pnlPanelBottom.Size = new System.Drawing.Size(1204, 417);
            this.pnlPanelBottom.TabIndex = 0;
            // 
            // dgrdCampaigns
            // 
            this.dgrdCampaigns.AllowUserToAddRows = false;
            this.dgrdCampaigns.AllowUserToDeleteRows = false;
            this.dgrdCampaigns.AllowUserToResizeColumns = false;
            this.dgrdCampaigns.AllowUserToResizeRows = false;
            this.dgrdCampaigns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrdCampaigns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrdCampaigns.BackgroundColor = System.Drawing.Color.White;
            this.dgrdCampaigns.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgrdCampaigns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdCampaigns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnHashtag,
            this.clmnWebpage,
            this.balance,
            this.buttonProductListGrid});
            this.dgrdCampaigns.GridColor = System.Drawing.Color.White;
            this.dgrdCampaigns.Location = new System.Drawing.Point(33, 28);
            this.dgrdCampaigns.MultiSelect = false;
            this.dgrdCampaigns.Name = "dgrdCampaigns";
            this.dgrdCampaigns.ReadOnly = true;
            this.dgrdCampaigns.RowHeadersVisible = false;
            this.dgrdCampaigns.RowHeadersWidth = 51;
            this.dgrdCampaigns.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgrdCampaigns.RowTemplate.Height = 29;
            this.dgrdCampaigns.ShowEditingIcon = false;
            this.dgrdCampaigns.Size = new System.Drawing.Size(1142, 372);
            this.dgrdCampaigns.TabIndex = 5;
            this.dgrdCampaigns.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridSA_CellClick);
            // 
            // clmnHashtag
            // 
            this.clmnHashtag.DataPropertyName = "clmnHashtag";
            this.clmnHashtag.HeaderText = "Hashtag";
            this.clmnHashtag.MinimumWidth = 6;
            this.clmnHashtag.Name = "clmnHashtag";
            this.clmnHashtag.ReadOnly = true;
            // 
            // clmnWebpage
            // 
            this.clmnWebpage.DataPropertyName = "clmnWebpage";
            this.clmnWebpage.HeaderText = "URL";
            this.clmnWebpage.MinimumWidth = 6;
            this.clmnWebpage.Name = "clmnWebpage";
            this.clmnWebpage.ReadOnly = true;
            // 
            // balance
            // 
            this.balance.DataPropertyName = "balance";
            this.balance.HeaderText = "Balance";
            this.balance.MinimumWidth = 6;
            this.balance.Name = "balance";
            this.balance.ReadOnly = true;
            // 
            // buttonProductListGrid
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.buttonProductListGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.buttonProductListGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProductListGrid.HeaderText = "";
            this.buttonProductListGrid.MinimumWidth = 6;
            this.buttonProductListGrid.Name = "buttonProductListGrid";
            this.buttonProductListGrid.ReadOnly = true;
            this.buttonProductListGrid.Text = "Product List";
            this.buttonProductListGrid.UseColumnTextForButtonValue = true;
            // 
            // dataGridNPO
            // 
            this.dataGridNPO.AllowUserToAddRows = false;
            this.dataGridNPO.AllowUserToDeleteRows = false;
            this.dataGridNPO.AllowUserToResizeColumns = false;
            this.dataGridNPO.AllowUserToResizeRows = false;
            this.dataGridNPO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridNPO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridNPO.BackgroundColor = System.Drawing.Color.White;
            this.dataGridNPO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridNPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridNPO.GridColor = System.Drawing.Color.White;
            this.dataGridNPO.Location = new System.Drawing.Point(-1956, -600);
            this.dataGridNPO.MultiSelect = false;
            this.dataGridNPO.Name = "dataGridNPO";
            this.dataGridNPO.ReadOnly = true;
            this.dataGridNPO.RowHeadersVisible = false;
            this.dataGridNPO.RowHeadersWidth = 51;
            this.dataGridNPO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridNPO.RowTemplate.Height = 29;
            this.dataGridNPO.ShowEditingIcon = false;
            this.dataGridNPO.Size = new System.Drawing.Size(608, 143);
            this.dataGridNPO.TabIndex = 1;
            // 
            // pnlPanelTop
            // 
            this.pnlPanelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(145)))), ((int)(((byte)(139)))));
            this.pnlPanelTop.Controls.Add(this.labelSATitle);
            this.pnlPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPanelTop.Location = new System.Drawing.Point(0, 0);
            this.pnlPanelTop.Name = "pnlPanelTop";
            this.pnlPanelTop.Size = new System.Drawing.Size(1236, 135);
            this.pnlPanelTop.TabIndex = 0;
            this.pnlPanelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSA_Paint);
            // 
            // labelSATitle
            // 
            this.labelSATitle.AutoSize = true;
            this.labelSATitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSATitle.ForeColor = System.Drawing.Color.White;
            this.labelSATitle.Location = new System.Drawing.Point(12, 50);
            this.labelSATitle.Name = "labelSATitle";
            this.labelSATitle.Size = new System.Drawing.Size(133, 28);
            this.labelSATitle.TabIndex = 0;
            this.labelSATitle.Text = "Social Activist";
            // 
            // panelBalance
            // 
            this.panelBalance.BackColor = System.Drawing.Color.White;
            this.panelBalance.Controls.Add(this.txtCashBalanceCheck);
            this.panelBalance.Controls.Add(this.lblTotalBalance);
            this.panelBalance.Location = new System.Drawing.Point(20, 147);
            this.panelBalance.Name = "panelBalance";
            this.panelBalance.Size = new System.Drawing.Size(396, 124);
            this.panelBalance.TabIndex = 1;
            // 
            // txtCashBalanceCheck
            // 
            this.txtCashBalanceCheck.AutoSize = true;
            this.txtCashBalanceCheck.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtCashBalanceCheck.ForeColor = System.Drawing.Color.Green;
            this.txtCashBalanceCheck.Location = new System.Drawing.Point(131, 18);
            this.txtCashBalanceCheck.Name = "txtCashBalanceCheck";
            this.txtCashBalanceCheck.Size = new System.Drawing.Size(28, 25);
            this.txtCashBalanceCheck.TabIndex = 0;
            this.txtCashBalanceCheck.Text = "|$";
            // 
            // lblTotalBalance
            // 
            this.lblTotalBalance.AutoSize = true;
            this.lblTotalBalance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalBalance.Location = new System.Drawing.Point(8, 18);
            this.lblTotalBalance.Name = "lblTotalBalance";
            this.lblTotalBalance.Size = new System.Drawing.Size(117, 25);
            this.lblTotalBalance.TabIndex = 0;
            this.lblTotalBalance.Text = "Total Balance:";
            // 
            // panelMessages
            // 
            this.panelMessages.BackColor = System.Drawing.Color.White;
            this.panelMessages.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMessages.BackgroundImage")));
            this.panelMessages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelMessages.Controls.Add(this.lblMessages);
            this.panelMessages.Location = new System.Drawing.Point(610, 141);
            this.panelMessages.Name = "panelMessages";
            this.panelMessages.Size = new System.Drawing.Size(614, 124);
            this.panelMessages.TabIndex = 0;
            // 
            // lblMessages
            // 
            this.lblMessages.AutoSize = true;
            this.lblMessages.BackColor = System.Drawing.Color.Gainsboro;
            this.lblMessages.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblMessages.ForeColor = System.Drawing.Color.Black;
            this.lblMessages.Location = new System.Drawing.Point(15, 14);
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Size = new System.Drawing.Size(72, 23);
            this.lblMessages.TabIndex = 2;
            this.lblMessages.Text = "Message";
            // 
            // pnlActivist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 712);
            this.Controls.Add(this.panelMessages);
            this.Controls.Add(this.panelBalance);
            this.Controls.Add(this.pnlPanelTop);
            this.Controls.Add(this.pnlPanelBottom);
            this.MaximumSize = new System.Drawing.Size(1254, 759);
            this.MinimumSize = new System.Drawing.Size(1254, 759);
            this.Name = "pnlActivist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Social Activist Dashboard";
            this.pnlPanelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdCampaigns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNPO)).EndInit();
            this.pnlPanelTop.ResumeLayout(false);
            this.pnlPanelTop.PerformLayout();
            this.panelBalance.ResumeLayout(false);
            this.panelBalance.PerformLayout();
            this.panelMessages.ResumeLayout(false);
            this.panelMessages.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPanelBottom;
        private System.Windows.Forms.Panel pnlPanelTop;
        private System.Windows.Forms.Label labelSATitle;
        private System.Windows.Forms.Panel panelBalance;
        private System.Windows.Forms.Panel panelMessages;
        private System.Windows.Forms.DataGridView dataGridNPO;
        private System.Windows.Forms.Label txtCashBalanceCheck;
        private System.Windows.Forms.Label lblTotalBalance;
        private System.Windows.Forms.DataGridView dgrdCampaigns;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnHashtag;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnWebpage;
        private System.Windows.Forms.DataGridViewTextBoxColumn balance;
        private System.Windows.Forms.DataGridViewButtonColumn buttonProductListGrid;
        private System.Windows.Forms.Label lblMessages;
    }
}