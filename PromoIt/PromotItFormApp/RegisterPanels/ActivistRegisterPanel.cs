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
    public partial class ActivistRegisterPanel : Form
    {
        public ActivistRegisterPanel()
        {
            InitializeComponent();
        }

        private void panelSARegister_Paint(object sender, PaintEventArgs e)
        {
            pnlPanelTop.BackColor = ThemeColor.PrimaryColor;
            pnlPanelTop.ForeColor = Color.White;
        }

        private void buttonCloseSAForm_Click(object sender, EventArgs e)
        {
            if (btnX != null)
            {
                Close();
                RegisterPanel roleSystem = new RegisterPanel();
                roleSystem.ShowDialog();
            }
        }

        private void buttonSARegister_Click(object sender, EventArgs e) => RegisterSocialActivistAsync();
        private void SocialActivistForm_Load(object sender, EventArgs e) { }


        private async Task RegisterSocialActivistAsync()
        {
            try
            {
                if (btnName.Text == "" || txtUserName.Text == "" || txtPassword.Text == "" || txtEmail.Text == "" || txtAddress.Text == "" || txtPhoneNumber.Text == "")
                    throw new Exception("Please fill the fields required!");

                ActivistUser activistUser = new ActivistUser()
                {
                    Name = btnName.Text,
                    UserName = txtUserName.Text,
                    UserPassword = txtPassword.Text,
                    Email = txtEmail.Text,
                    Address = txtAddress.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                };

                bool result = await activistUser.RegisterAsync();
                if (!result)
                {
                    Loggings.ErrorLog($"Activist User cant register UserName ({activistUser.UserName})");
                    throw new Exception("Registeration Fail");
                } 

                Configuration.CorrentUser = activistUser;
                Configuration.LoginUser = new Users(activistUser);
                Loggings.ReportLog($"Activist User registered UserName ({activistUser.UserName})");

                this.Hide();
                (new LoginPanel()).ShowDialog();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

    }
}
