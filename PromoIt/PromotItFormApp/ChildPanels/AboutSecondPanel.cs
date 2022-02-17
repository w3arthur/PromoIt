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
    public partial class AboutSecondPanel : Form
    {
        private Form? activeForm;
        public AboutSecondPanel()
        {
            InitializeComponent();
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

                labelTermsService.BackColor = ThemeColor.PrimaryColor;
                labelPoints.BackColor = ThemeColor.SecondaryColor;
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            activeForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlPanelGlobal.Controls.Add(childForm);
            this.pnlPanelGlobal.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void buttonPreviousAbout_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildPanels.MenuAboutPanel(), sender);
        }

        private void AboutSecondPage_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void buttoNextAboutS_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildPanels.CompanyChildPanel(), sender);
        }
    }
}
