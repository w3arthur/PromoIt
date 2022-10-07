//using Microsoft.Azure.Cosmos;
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
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItFormApp;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Patterns;

namespace PromotItFormApp.RegisterPanels
{
    public partial class LoginPanel : Form
    {
        public LoginPanel()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;

            UserSetValues();
        }

        private void buttonLoginForm_Click(object sender, EventArgs e) => GetLoginAsync();

        private void panelLoginForm_Paint(object sender, PaintEventArgs e)
        {
            pnlPanelTop.BackColor = ThemeColor.PrimaryColor;
            pnlPanelTop.ForeColor = Color.White;
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e) => PressingEnter(e);

        private void textBoxUsername_KeyDown(object sender, KeyEventArgs e) => PressingEnter(e);


        private void UserSetValues() 
        {
            IUsers user = Configuration.LoginUser;
            if (user != null && !string.IsNullOrEmpty(user.UserName))
            {
                txtUserName.Text = user.UserName;
                if (!string.IsNullOrEmpty(user.UserPassword))
                    txtPassword.Text = user.UserPassword;
            }
        }

        private void PressingEnter(KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Enter) btnLogin.PerformClick();
        }

        private async Task GetLoginAsync()
        {
            try
            {
                if (txtUserName.Text == "" || txtPassword.Text == "")
                    throw new Exception("Please provide a username and password");
                Users user = new Users()
                {
                    UserName = txtUserName.Text.Trim(),
                    UserPassword = txtPassword.Text.Trim(),
                };

                IUsers loggedinUser = await user.LoginAsync();
                if (loggedinUser == null)
                {
                    Loggings.ErrorLog($"User cant login UserName ({txtUserName.Text}), Wrong UserName or Password");
                    throw new Exception("Wrong username or password!");
                }

                Configuration.CorrentUser = loggedinUser;
                Configuration.LoginUser = new Users(loggedinUser);

                string? type = loggedinUser.UserType;
                Form? form =
                    type == "admin" ? new LandingPanels.AdminPanel() :
                    type == "non-profit" ? new LandingPanels.NonProfitPanel() :
                    type == "business" ? new LandingPanels.BusinessPanel() :
                    type == "activist" ? new LandingPanels.ActivistPanel() :
                    null;
                if (form == null)
                {
                    Loggings.ErrorLog($"User cant login UserName ({user.UserName})");
                    throw new Exception("The system does not recognize you!");
                }
                Loggings.ReportLog($"User login UserName ({loggedinUser.UserName})");

                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}