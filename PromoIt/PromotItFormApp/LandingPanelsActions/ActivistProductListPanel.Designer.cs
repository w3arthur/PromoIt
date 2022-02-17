namespace PromotItFormApp.LandingPanelsActions
{
    partial class ActivistProductListPanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridProductList = new System.Windows.Forms.DataGridView();
            this.clmnProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnBusinessUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnProductQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonBuyGrid = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridProductList
            // 
            this.dataGridProductList.AllowUserToAddRows = false;
            this.dataGridProductList.AllowUserToDeleteRows = false;
            this.dataGridProductList.AllowUserToResizeColumns = false;
            this.dataGridProductList.AllowUserToResizeRows = false;
            this.dataGridProductList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridProductList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridProductList.BackgroundColor = System.Drawing.Color.White;
            this.dataGridProductList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProductList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnProductId,
            this.clmnBusinessUser,
            this.clmnProductName,
            this.clmnProductQuantity,
            this.clmnProductPrice,
            this.buttonBuyGrid});
            this.dataGridProductList.GridColor = System.Drawing.Color.White;
            this.dataGridProductList.Location = new System.Drawing.Point(24, 39);
            this.dataGridProductList.MultiSelect = false;
            this.dataGridProductList.Name = "dataGridProductList";
            this.dataGridProductList.ReadOnly = true;
            this.dataGridProductList.RowHeadersVisible = false;
            this.dataGridProductList.RowHeadersWidth = 51;
            this.dataGridProductList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridProductList.RowTemplate.Height = 29;
            this.dataGridProductList.ShowEditingIcon = false;
            this.dataGridProductList.Size = new System.Drawing.Size(812, 372);
            this.dataGridProductList.TabIndex = 0;
            this.dataGridProductList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProductList_CellClick);
            // 
            // clmnProductId
            // 
            this.clmnProductId.DataPropertyName = "clmnProductId";
            this.clmnProductId.HeaderText = "clmnProductId";
            this.clmnProductId.MinimumWidth = 6;
            this.clmnProductId.Name = "clmnProductId";
            this.clmnProductId.ReadOnly = true;
            this.clmnProductId.Visible = false;
            // 
            // clmnBusinessUser
            // 
            this.clmnBusinessUser.DataPropertyName = "clmnBusinessUser";
            this.clmnBusinessUser.HeaderText = "clmnBusinessUser";
            this.clmnBusinessUser.MinimumWidth = 6;
            this.clmnBusinessUser.Name = "clmnBusinessUser";
            this.clmnBusinessUser.ReadOnly = true;
            this.clmnBusinessUser.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnBusinessUser.Visible = false;
            // 
            // clmnProductName
            // 
            this.clmnProductName.DataPropertyName = "clmnProductName";
            this.clmnProductName.HeaderText = "Product Name";
            this.clmnProductName.MinimumWidth = 6;
            this.clmnProductName.Name = "clmnProductName";
            this.clmnProductName.ReadOnly = true;
            // 
            // clmnProductQuantity
            // 
            this.clmnProductQuantity.DataPropertyName = "clmnProductQuantity";
            this.clmnProductQuantity.HeaderText = "Quantity";
            this.clmnProductQuantity.MinimumWidth = 6;
            this.clmnProductQuantity.Name = "clmnProductQuantity";
            this.clmnProductQuantity.ReadOnly = true;
            // 
            // clmnProductPrice
            // 
            this.clmnProductPrice.DataPropertyName = "clmnProductPrice";
            this.clmnProductPrice.HeaderText = "Price";
            this.clmnProductPrice.MinimumWidth = 6;
            this.clmnProductPrice.Name = "clmnProductPrice";
            this.clmnProductPrice.ReadOnly = true;
            // 
            // buttonBuyGrid
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.buttonBuyGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.buttonBuyGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBuyGrid.HeaderText = "";
            this.buttonBuyGrid.MinimumWidth = 6;
            this.buttonBuyGrid.Name = "buttonBuyGrid";
            this.buttonBuyGrid.ReadOnly = true;
            this.buttonBuyGrid.Text = "Buy";
            this.buttonBuyGrid.UseColumnTextForButtonValue = true;
            // 
            // ActivistProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 450);
            this.Controls.Add(this.dataGridProductList);
            this.Name = "ActivistProductList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products List";
            this.Shown += new System.EventHandler(this.ProductList_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridProductList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnBusinessUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnProductQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnProductPrice;
        private System.Windows.Forms.DataGridViewButtonColumn buttonBuyGrid;
    }
}