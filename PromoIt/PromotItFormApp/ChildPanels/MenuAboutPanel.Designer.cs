namespace PromotItFormApp.ChildPanels
{
    partial class MenuAboutPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuAboutPanel));
            this.btnNext = new System.Windows.Forms.Button();
            this.labelAboutUs = new System.Windows.Forms.Label();
            this.labelAboutCoop = new System.Windows.Forms.Label();
            this.lblLableTop = new System.Windows.Forms.Label();
            this.pnlPannelGlobal = new System.Windows.Forms.Panel();
            this.lblBottom2 = new System.Windows.Forms.Label();
            this.lblLableBottom1 = new System.Windows.Forms.Label();
            this.pnlPannelGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(691, 403);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(151, 35);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.buttonAboutNext_Click);
            // 
            // labelAboutUs
            // 
            this.labelAboutUs.AutoSize = true;
            this.labelAboutUs.BackColor = System.Drawing.Color.Transparent;
            this.labelAboutUs.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelAboutUs.ForeColor = System.Drawing.Color.White;
            this.labelAboutUs.Location = new System.Drawing.Point(12, 9);
            this.labelAboutUs.Name = "labelAboutUs";
            this.labelAboutUs.Size = new System.Drawing.Size(46, 31);
            this.labelAboutUs.TabIndex = 0;
            this.labelAboutUs.Text = "US:";
            // 
            // labelAboutCoop
            // 
            this.labelAboutCoop.AutoSize = true;
            this.labelAboutCoop.BackColor = System.Drawing.Color.Transparent;
            this.labelAboutCoop.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelAboutCoop.ForeColor = System.Drawing.Color.White;
            this.labelAboutCoop.Location = new System.Drawing.Point(12, 225);
            this.labelAboutCoop.Name = "labelAboutCoop";
            this.labelAboutCoop.Size = new System.Drawing.Size(172, 31);
            this.labelAboutCoop.TabIndex = 0;
            this.labelAboutCoop.Text = "COOPERATION:";
            // 
            // lblLableTop
            // 
            this.lblLableTop.AutoSize = true;
            this.lblLableTop.Location = new System.Drawing.Point(12, 49);
            this.lblLableTop.Name = "lblLableTop";
            this.lblLableTop.Size = new System.Drawing.Size(842, 140);
            this.lblLableTop.TabIndex = 0;
            this.lblLableTop.Text = resources.GetString("lblLableTop.Text");
            // 
            // pnlPannelGlobal
            // 
            this.pnlPannelGlobal.BackColor = System.Drawing.Color.White;
            this.pnlPannelGlobal.Controls.Add(this.lblBottom2);
            this.pnlPannelGlobal.Controls.Add(this.lblLableBottom1);
            this.pnlPannelGlobal.Controls.Add(this.lblLableTop);
            this.pnlPannelGlobal.Controls.Add(this.labelAboutCoop);
            this.pnlPannelGlobal.Controls.Add(this.labelAboutUs);
            this.pnlPannelGlobal.Controls.Add(this.btnNext);
            this.pnlPannelGlobal.Location = new System.Drawing.Point(0, 0);
            this.pnlPannelGlobal.Name = "pnlPannelGlobal";
            this.pnlPannelGlobal.Size = new System.Drawing.Size(862, 460);
            this.pnlPannelGlobal.TabIndex = 1;
            // 
            // lblBottom2
            // 
            this.lblBottom2.AutoSize = true;
            this.lblBottom2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBottom2.Location = new System.Drawing.Point(12, 315);
            this.lblBottom2.Name = "lblBottom2";
            this.lblBottom2.Size = new System.Drawing.Size(218, 20);
            this.lblBottom2.TabIndex = 0;
            this.lblBottom2.Text = "(Full details in the next page!)";
            // 
            // lblLableBottom1
            // 
            this.lblLableBottom1.AutoSize = true;
            this.lblLableBottom1.Location = new System.Drawing.Point(12, 264);
            this.lblLableBottom1.Name = "lblLableBottom1";
            this.lblLableBottom1.Size = new System.Drawing.Size(831, 40);
            this.lblLableBottom1.TabIndex = 1;
            this.lblLableBottom1.Text = "In full cooperation with known business companies, which they donate products to " +
    "support and giving voice to their idelogy \r\nand mutual agenda.";
            // 
            // MenuAboutPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 450);
            this.Controls.Add(this.pnlPannelGlobal);
            this.MaximumSize = new System.Drawing.Size(872, 497);
            this.MinimumSize = new System.Drawing.Size(872, 497);
            this.Name = "MenuAboutPage";
            this.Text = "Pronoit - About Promoit";
            this.Load += new System.EventHandler(this.MenuAboutPage_Load);
            this.pnlPannelGlobal.ResumeLayout(false);
            this.pnlPannelGlobal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label labelAboutUs;
        private System.Windows.Forms.Label labelAboutCoop;
        private System.Windows.Forms.Label lblLableTop;
        private System.Windows.Forms.Panel pnlPannelGlobal;
        private System.Windows.Forms.Label lblBottom2;
        private System.Windows.Forms.Label lblLableBottom1;
    }
}