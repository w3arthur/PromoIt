namespace PromotItFormApp.ChildPanels
{
    partial class MenuTwitterPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuTwitterPanel));
            this.lblTop = new System.Windows.Forms.Label();
            this.pnlPannelGlobal = new System.Windows.Forms.Panel();
            this.btnTwitterLink = new System.Windows.Forms.Button();
            this.pnlPannelGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.BackColor = System.Drawing.Color.Transparent;
            this.lblTop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTop.ForeColor = System.Drawing.Color.Black;
            this.lblTop.Location = new System.Drawing.Point(205, 44);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(430, 28);
            this.lblTop.TabIndex = 1;
            this.lblTop.Text = "This is our official Twitter\'s profile, stay updated!";
            // 
            // pnlPannelGlobal
            // 
            this.pnlPannelGlobal.BackColor = System.Drawing.Color.White;
            this.pnlPannelGlobal.Controls.Add(this.btnTwitterLink);
            this.pnlPannelGlobal.Controls.Add(this.lblTop);
            this.pnlPannelGlobal.ForeColor = System.Drawing.Color.Transparent;
            this.pnlPannelGlobal.Location = new System.Drawing.Point(0, 0);
            this.pnlPannelGlobal.Name = "pnlPannelGlobal";
            this.pnlPannelGlobal.Size = new System.Drawing.Size(861, 461);
            this.pnlPannelGlobal.TabIndex = 2;
            // 
            // btnTwitterLink
            // 
            this.btnTwitterLink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            this.btnTwitterLink.FlatAppearance.BorderSize = 0;
            this.btnTwitterLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTwitterLink.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTwitterLink.Image = ((System.Drawing.Image)(resources.GetObject("btnTwitterLink.Image")));
            this.btnTwitterLink.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTwitterLink.Location = new System.Drawing.Point(342, 91);
            this.btnTwitterLink.Name = "btnTwitterLink";
            this.btnTwitterLink.Size = new System.Drawing.Size(173, 43);
            this.btnTwitterLink.TabIndex = 0;
            this.btnTwitterLink.Text = "Twitter";
            this.btnTwitterLink.UseVisualStyleBackColor = false;
            this.btnTwitterLink.Click += new System.EventHandler(this.buttonTwitter_Click);
            // 
            // MenuTwitterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 450);
            this.Controls.Add(this.pnlPannelGlobal);
            this.MaximumSize = new System.Drawing.Size(872, 497);
            this.MinimumSize = new System.Drawing.Size(872, 497);
            this.Name = "MenuTwitterPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promoit - Twitter Page";
            this.Load += new System.EventHandler(this.MenuTwitterPage_Load);
            this.pnlPannelGlobal.ResumeLayout(false);
            this.pnlPannelGlobal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Panel pnlPannelGlobal;
        private System.Windows.Forms.Button btnTwitterLink;
    }
}