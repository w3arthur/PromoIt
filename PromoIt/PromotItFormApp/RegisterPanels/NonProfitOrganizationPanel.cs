using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PromotItLibrary.Models;
using PromotItLibrary.Classes;
using PromotItLibrary.Patterns;

namespace PromotItFormApp.RegisterPanels
{
    public partial class NonProfitOrganizationPanel : Form
    {
        public NonProfitOrganizationPanel()
        {
            InitializeComponent();
        }

        private void panelNPORegistr_Paint(object sender, PaintEventArgs e)
        {
            pnlPanelTop.BackColor = ThemeColor.PrimaryColor;
            pnlPanelTop.ForeColor = Color.White;
        }

        private void buttonCloseNPOForm_Click(object sender, EventArgs e) => CloseWindow();

        private void buttonNPORegister_Click(object sender, EventArgs e) => RegisterNonProfitOrganizationAsync();

        private void NonProfitOrganizationForm_Load(object sender, EventArgs e) { }

        private void CloseWindow()
        {
            if (btnX != null) return;
            this.CloseWindow();
            RegisterPanel roleSystem = new RegisterPanel();
            roleSystem.ShowDialog();
        }

        private async Task RegisterNonProfitOrganizationAsync()
        {
            try
            {
                if (txtName.Text == "" || txtUserName.Text == "" || txtPassword.Text == "" || txtWebSite.Text == "" || txtEmail.Text == "")
                    throw new Exception("Please fill the fields required!");

                NonProfitUser nonProfitUser = new NonProfitUser()
                {
                    Name = txtName.Text,
                    UserName = txtUserName.Text,
                    UserPassword = txtPassword.Text,
                    Email = txtEmail.Text,
                    WebSite = txtWebSite.Text,
                };

                bool result = await nonProfitUser.RegisterAsync();
                if (!result)
                {
                    Loggings.ErrorLog($"Non Profit Company User cant register UserName ({nonProfitUser.UserName})");
                    throw new Exception("Registeration Fail");
                }

                Configuration.CorrentUser = new Users(nonProfitUser);
                Configuration.LoginUser = new Users(nonProfitUser);
                Loggings.ReportLog($"Non Profit Company User registered UserName ({nonProfitUser.UserName})");
                
                this.Hide();
                (new LoginPanel()).ShowDialog();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

    }
}
