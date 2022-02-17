namespace PromotItFormApp.LandingPanels
{
    partial class BusinessPanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlPanelTop = new System.Windows.Forms.Panel();
            this.labelBCRTitle = new System.Windows.Forms.Label();
            this.lblActivists = new System.Windows.Forms.Label();
            this.lblCampaignsList = new System.Windows.Forms.Label();
            this.Hashtag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgrdCampains = new System.Windows.Forms.DataGridView();
            this.clmnHashtag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnWebpage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonProductListGrid = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonDonateGrid = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgrdActivists = new System.Windows.Forms.DataGridView();
            this.clmnActivist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnProductDonatedId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlPanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdCampains)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdActivists)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPanelTop
            // 
            this.pnlPanelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(145)))), ((int)(((byte)(139)))));
            this.pnlPanelTop.Controls.Add(this.labelBCRTitle);
            this.pnlPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPanelTop.Location = new System.Drawing.Point(0, 0);
            this.pnlPanelTop.Name = "pnlPanelTop";
            this.pnlPanelTop.Size = new System.Drawing.Size(1123, 135);
            this.pnlPanelTop.TabIndex = 0;
            this.pnlPanelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBCR_Paint);
            // 
            // labelBCRTitle
            // 
            this.labelBCRTitle.AutoSize = true;
            this.labelBCRTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBCRTitle.ForeColor = System.Drawing.Color.White;
            this.labelBCRTitle.Location = new System.Drawing.Point(12, 50);
            this.labelBCRTitle.Name = "labelBCRTitle";
            this.labelBCRTitle.Size = new System.Drawing.Size(306, 28);
            this.labelBCRTitle.TabIndex = 0;
            this.labelBCRTitle.Text = "Business Company Representative";
            // 
            // lblActivists
            // 
            this.lblActivists.AutoSize = true;
            this.lblActivists.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblActivists.Location = new System.Drawing.Point(30, 155);
            this.lblActivists.Name = "lblActivists";
            this.lblActivists.Size = new System.Drawing.Size(127, 31);
            this.lblActivists.TabIndex = 0;
            this.lblActivists.Text = "Buyers List:";
            // 
            // lblCampaignsList
            // 
            this.lblCampaignsList.AutoSize = true;
            this.lblCampaignsList.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCampaignsList.Location = new System.Drawing.Point(588, 155);
            this.lblCampaignsList.Name = "lblCampaignsList";
            this.lblCampaignsList.Size = new System.Drawing.Size(175, 31);
            this.lblCampaignsList.TabIndex = 0;
            this.lblCampaignsList.Text = "Campaigns List:";
            // 
            // Hashtag
            // 
            this.Hashtag.HeaderText = "Hashtag";
            this.Hashtag.MinimumWidth = 6;
            this.Hashtag.Name = "Hashtag";
            this.Hashtag.Width = 125;
            // 
            // URL
            // 
            this.URL.HeaderText = "URL";
            this.URL.MinimumWidth = 6;
            this.URL.Name = "URL";
            this.URL.Width = 125;
            // 
            // dgrdCampains
            // 
            this.dgrdCampains.AllowUserToAddRows = false;
            this.dgrdCampains.AllowUserToDeleteRows = false;
            this.dgrdCampains.AllowUserToResizeColumns = false;
            this.dgrdCampains.AllowUserToResizeRows = false;
            this.dgrdCampains.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrdCampains.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrdCampains.BackgroundColor = System.Drawing.Color.White;
            this.dgrdCampains.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgrdCampains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdCampains.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnHashtag,
            this.clmnWebpage,
            this.buttonProductListGrid,
            this.buttonDonateGrid});
            this.dgrdCampains.GridColor = System.Drawing.Color.White;
            this.dgrdCampains.Location = new System.Drawing.Point(576, 199);
            this.dgrdCampains.MultiSelect = false;
            this.dgrdCampains.Name = "dgrdCampains";
            this.dgrdCampains.ReadOnly = true;
            this.dgrdCampains.RowHeadersVisible = false;
            this.dgrdCampains.RowHeadersWidth = 51;
            this.dgrdCampains.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgrdCampains.RowTemplate.Height = 29;
            this.dgrdCampains.ShowEditingIcon = false;
            this.dgrdCampains.Size = new System.Drawing.Size(527, 491);
            this.dgrdCampains.TabIndex = 0;
            this.dgrdCampains.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBC_CellClick);
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
            this.clmnWebpage.DataPropertyName = "clmnWebPage";
            this.clmnWebpage.HeaderText = "URL";
            this.clmnWebpage.MinimumWidth = 6;
            this.clmnWebpage.Name = "clmnWebpage";
            this.clmnWebpage.ReadOnly = true;
            // 
            // buttonProductListGrid
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.buttonProductListGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.buttonProductListGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProductListGrid.HeaderText = "";
            this.buttonProductListGrid.MinimumWidth = 6;
            this.buttonProductListGrid.Name = "buttonProductListGrid";
            this.buttonProductListGrid.ReadOnly = true;
            this.buttonProductListGrid.Text = "Product List";
            this.buttonProductListGrid.UseColumnTextForButtonValue = true;
            // 
            // buttonDonateGrid
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.buttonDonateGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.buttonDonateGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDonateGrid.HeaderText = "";
            this.buttonDonateGrid.MinimumWidth = 6;
            this.buttonDonateGrid.Name = "buttonDonateGrid";
            this.buttonDonateGrid.ReadOnly = true;
            this.buttonDonateGrid.Text = "Donate";
            this.buttonDonateGrid.UseColumnTextForButtonValue = true;
            // 
            // dgrdActivists
            // 
            this.dgrdActivists.AllowUserToAddRows = false;
            this.dgrdActivists.AllowUserToDeleteRows = false;
            this.dgrdActivists.AllowUserToResizeColumns = false;
            this.dgrdActivists.AllowUserToResizeRows = false;
            this.dgrdActivists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrdActivists.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrdActivists.BackgroundColor = System.Drawing.Color.White;
            this.dgrdActivists.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgrdActivists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdActivists.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnActivist,
            this.clmnProduct,
            this.clmnProductDonatedId,
            this.dataGridViewButtonColumn1});
            this.dgrdActivists.GridColor = System.Drawing.Color.White;
            this.dgrdActivists.Location = new System.Drawing.Point(21, 199);
            this.dgrdActivists.MultiSelect = false;
            this.dgrdActivists.Name = "dgrdActivists";
            this.dgrdActivists.ReadOnly = true;
            this.dgrdActivists.RowHeadersVisible = false;
            this.dgrdActivists.RowHeadersWidth = 51;
            this.dgrdActivists.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgrdActivists.RowTemplate.Height = 29;
            this.dgrdActivists.ShowEditingIcon = false;
            this.dgrdActivists.Size = new System.Drawing.Size(516, 491);
            this.dgrdActivists.TabIndex = 0;
            this.dgrdActivists.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBuyers_CellClick);
            // 
            // clmnActivist
            // 
            this.clmnActivist.DataPropertyName = "clmnActivist";
            this.clmnActivist.HeaderText = "Buyer name";
            this.clmnActivist.MinimumWidth = 6;
            this.clmnActivist.Name = "clmnActivist";
            this.clmnActivist.ReadOnly = true;
            // 
            // clmnProduct
            // 
            this.clmnProduct.DataPropertyName = "clmnProduct";
            this.clmnProduct.HeaderText = "Product Name";
            this.clmnProduct.MinimumWidth = 6;
            this.clmnProduct.Name = "clmnProduct";
            this.clmnProduct.ReadOnly = true;
            // 
            // clmnProductDonatedId
            // 
            this.clmnProductDonatedId.DataPropertyName = "clmnProductDonatedId";
            this.clmnProductDonatedId.HeaderText = "clmnProductDonatedId";
            this.clmnProductDonatedId.MinimumWidth = 6;
            this.clmnProductDonatedId.Name = "clmnProductDonatedId";
            this.clmnProductDonatedId.ReadOnly = true;
            this.clmnProductDonatedId.Visible = false;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.MinimumWidth = 6;
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Text = "Send product";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // BusinessPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 719);
            this.Controls.Add(this.dgrdActivists);
            this.Controls.Add(this.dgrdCampains);
            this.Controls.Add(this.lblCampaignsList);
            this.Controls.Add(this.lblActivists);
            this.Controls.Add(this.pnlPanelTop);
            this.MaximumSize = new System.Drawing.Size(1141, 766);
            this.MinimumSize = new System.Drawing.Size(1141, 766);
            this.Name = "BusinessPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Business Company Dashboard";
            this.pnlPanelTop.ResumeLayout(false);
            this.pnlPanelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdCampains)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdActivists)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPanelTop;
        private System.Windows.Forms.Label labelBCRTitle;
        private System.Windows.Forms.Label lblActivists;
        private System.Windows.Forms.Label lblCampaignsList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hashtag;
        private System.Windows.Forms.DataGridViewTextBoxColumn URL;
        private System.Windows.Forms.DataGridView dgrdCampains;
        private System.Windows.Forms.DataGridView dgrdActivists;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnHashtag;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnWebpage;
        private System.Windows.Forms.DataGridViewButtonColumn buttonProductListGrid;
        private System.Windows.Forms.DataGridViewButtonColumn buttonDonateGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnActivist;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnProductDonatedId;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
    }
}