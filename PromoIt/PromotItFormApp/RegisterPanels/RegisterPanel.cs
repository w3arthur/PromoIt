using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromotItFormApp.RegisterPanels
{
    public partial class RegisterPanel : Form
    {       
        public RegisterPanel()
        {
            InitializeComponent();
        }

        private void buttonRegisterRole_Click(object sender, EventArgs e) => GetRadioButtonPage();

        private void panelRoleRegister_Paint(object sender, PaintEventArgs e)
        {
            pnlPanelTop.BackColor = ThemeColor.PrimaryColor;
            pnlPanelTop.ForeColor = Color.White;
        }
        private void radioButtonAdmin_KeyDown(object sender, KeyEventArgs e) => PressingEnter(e);
        private void radioButtonNPO_KeyDown(object sender, KeyEventArgs e) => PressingEnter(e);
        private void radioButtonBSR_KeyDown(object sender, KeyEventArgs e) => PressingEnter(e);
        private void radioButtonSA_KeyDown(object sender, KeyEventArgs e) => PressingEnter(e);
        private void RoleSystem_Load(object sender, EventArgs e) { }


        private void PressingEnter(KeyEventArgs e) {  if (e.KeyCode == Keys.Enter) btnRegister.PerformClick(); }

        private void GetRadioButtonPage() 
        {
            try
            {
                Form? form =
                    chkAdmin.Checked ? new AdminRegisterPanel() :
                    chkNonProfit.Checked ? new NonProfitOrganizationPanel() :
                    chkBuisness.Checked ? new BusinessCompanyRegisterPanel() :
                    chkActivist.Checked ? new ActivistRegisterPanel() :
                    null;
                this.Hide();
                form?.ShowDialog();
                this.Close();
            }
            catch { }
        }

    }
}
