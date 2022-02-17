namespace PromotItFormApp.LandingPanelsActions
{
    partial class BusinessNewProductPanel
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
            this.panelNewProduct = new System.Windows.Forms.Panel();
            this.labelNewProduct = new System.Windows.Forms.Label();
            this.panelProductMain = new System.Windows.Forms.Panel();
            this.buttonSaveProduct = new System.Windows.Forms.Button();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.panelNewProduct.SuspendLayout();
            this.panelProductMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNewProduct
            // 
            this.panelNewProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(145)))), ((int)(((byte)(139)))));
            this.panelNewProduct.Controls.Add(this.labelNewProduct);
            this.panelNewProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNewProduct.Location = new System.Drawing.Point(0, 0);
            this.panelNewProduct.Name = "panelNewProduct";
            this.panelNewProduct.Size = new System.Drawing.Size(477, 122);
            this.panelNewProduct.TabIndex = 0;
            // 
            // labelNewProduct
            // 
            this.labelNewProduct.AutoSize = true;
            this.labelNewProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNewProduct.ForeColor = System.Drawing.Color.White;
            this.labelNewProduct.Location = new System.Drawing.Point(12, 44);
            this.labelNewProduct.Name = "labelNewProduct";
            this.labelNewProduct.Size = new System.Drawing.Size(125, 28);
            this.labelNewProduct.TabIndex = 0;
            this.labelNewProduct.Text = "New Product";
            // 
            // panelProductMain
            // 
            this.panelProductMain.BackColor = System.Drawing.Color.White;
            this.panelProductMain.Controls.Add(this.buttonSaveProduct);
            this.panelProductMain.Controls.Add(this.textBoxPrice);
            this.panelProductMain.Controls.Add(this.labelPrice);
            this.panelProductMain.Controls.Add(this.textBoxQuantity);
            this.panelProductMain.Controls.Add(this.labelQuantity);
            this.panelProductMain.Controls.Add(this.textBoxProductName);
            this.panelProductMain.Controls.Add(this.labelProductName);
            this.panelProductMain.Location = new System.Drawing.Point(8, 145);
            this.panelProductMain.Name = "panelProductMain";
            this.panelProductMain.Size = new System.Drawing.Size(462, 466);
            this.panelProductMain.TabIndex = 0;
            // 
            // buttonSaveProduct
            // 
            this.buttonSaveProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            this.buttonSaveProduct.FlatAppearance.BorderSize = 0;
            this.buttonSaveProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveProduct.ForeColor = System.Drawing.Color.White;
            this.buttonSaveProduct.Location = new System.Drawing.Point(31, 298);
            this.buttonSaveProduct.Name = "buttonSaveProduct";
            this.buttonSaveProduct.Size = new System.Drawing.Size(392, 47);
            this.buttonSaveProduct.TabIndex = 0;
            this.buttonSaveProduct.Text = "Save";
            this.buttonSaveProduct.UseVisualStyleBackColor = false;
            this.buttonSaveProduct.Click += new System.EventHandler(this.buttonSaveProduct_Click);
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(14, 191);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(392, 27);
            this.textBoxPrice.TabIndex = 0;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPrice.Location = new System.Drawing.Point(14, 163);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(53, 25);
            this.labelPrice.TabIndex = 0;
            this.labelPrice.Text = "Price:";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(14, 121);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(392, 27);
            this.textBoxQuantity.TabIndex = 0;
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelQuantity.Location = new System.Drawing.Point(14, 93);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(84, 25);
            this.labelQuantity.TabIndex = 0;
            this.labelQuantity.Text = "Quantity:";
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(14, 53);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(392, 27);
            this.textBoxProductName.TabIndex = 0;
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelProductName.Location = new System.Drawing.Point(14, 25);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(130, 25);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.Text = "Product Name:";
            // 
            // BusinessNewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 617);
            this.Controls.Add(this.panelNewProduct);
            this.Controls.Add(this.panelProductMain);
            this.MaximumSize = new System.Drawing.Size(495, 664);
            this.MinimumSize = new System.Drawing.Size(495, 664);
            this.Name = "BusinessNewProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Product";
            this.panelNewProduct.ResumeLayout(false);
            this.panelNewProduct.PerformLayout();
            this.panelProductMain.ResumeLayout(false);
            this.panelProductMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNewProduct;
        private System.Windows.Forms.Label labelNewProduct;
        private System.Windows.Forms.Panel panelProductMain;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Button buttonSaveProduct;
    }
}