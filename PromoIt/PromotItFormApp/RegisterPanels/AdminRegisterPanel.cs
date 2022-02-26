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

namespace PromotItFormApp.RegisterPanels
{
    public partial class AdminRegisterPanel : Form
    {
        public AdminRegisterPanel()
        {
            InitializeComponent();
        }

        private void panelAdminRegistr_Paint(object sender, PaintEventArgs e)
        {
            pnlPanelTop.BackColor = ThemeColor.PrimaryColor;
            pnlPanelTop.ForeColor = Color.White;
        }

        private void buttonCloseAdminForm_Click(object sender, EventArgs e) => CloseWindow();

        private void buttonAdminRegister_ClickAsync(object sender, EventArgs e) =>  AdminRegisterAsync();
        private void AdminForm_Load(object sender, EventArgs e) { }


        private void CloseWindow()
        {
            if (btnX != null) this.CloseWindow();
            (new RegisterPanel()).ShowDialog();
        }

        private async Task AdminRegisterAsync() 
        {
            try
            {
                if (txtName.Text == "" || txtUserName.Text == "" || txtPassword.Text == "")
                    throw new Exception("Please fill the fields required!");

                AdminUser adminUser = new AdminUser()
                {
                    Name = txtName.Text,
                    UserName = txtUserName.Text,
                    UserPassword = txtPassword.Text,
                };
                
                bool result = await adminUser.RegisterAsync();
                if (!result)
                {
                    Loggings.ErrorLog($"Admin User cant register UserName ({adminUser.UserName})");
                    throw new Exception("Registeration Fail");
                }
                
                Configuration.CorrentUser = adminUser;
                Configuration.LoginUser = new Users(adminUser);
                Loggings.ReportLog($"Admin User registered UserName ({adminUser.UserName})");

                this.Hide();
                (new LoginPanel()).ShowDialog();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


    }
}
