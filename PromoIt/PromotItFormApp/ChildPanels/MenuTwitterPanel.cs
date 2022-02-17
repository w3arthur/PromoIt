using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromotItFormApp.ChildPanels
{
    public partial class MenuTwitterPanel : Form
    {
        public MenuTwitterPanel()
        {
            InitializeComponent();
        }

        private void MenuTwitterPage_Load(object sender, EventArgs e)
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

                lblTop.BackColor = ThemeColor.PrimaryColor;                
            }
        }

        private void buttonTwitter_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://twitter.com/MalulYaron") { UseShellExecute = true });
        }
    }
}
