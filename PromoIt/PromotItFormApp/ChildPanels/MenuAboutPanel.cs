using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromotItFormApp.ChildPanels
{
    public partial class MenuAboutPanel : Form
    {
        private Form? activeForm;
        public MenuAboutPanel()
        {
            InitializeComponent();
        }
        private void MenuAboutPage_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        private void LoadTheme()
        {
            foreach (Control buttons in this.Controls)
            {
                if (buttons.GetType() == typeof(Button))
                {
                    Button button = (Button)buttons;
                    buttons.BackColor = ThemeColor.PrimaryColor;
                    buttons.ForeColor = Color.White;
                    button.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }

                labelAboutUs.BackColor = ThemeColor.PrimaryColor;
                labelAboutCoop.BackColor = ThemeColor.SecondaryColor;
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            activeForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlPannelGlobal.Controls.Add(childForm);
            this.pnlPannelGlobal.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void buttonAboutNext_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildPanels.AboutSecondPanel(), sender);
        }
    }
}
