using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromotItFormApp
{
    public partial class PromotIt : Form
    {
        //Fields
        private Button? currentButton;
        private Random random;
        private int tempIndex;
        private Form? activeForm;

        //Constructor

        public PromotIt()
        {
            InitializeComponent();
            random = new Random();
            btnX.Visible = false;            
        }

        //Methods

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);

            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color); 
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildPanels.MenuHomePanel(), sender);
            //ActivateButton(sender);
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildPanels.MenuAboutPanel(), sender);
            //ActivateButton(sender);
        }

        private void buttonTwitter_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildPanels.MenuTwitterPanel(), sender);
            //ActivateButton(sender);
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            RegisterPanels.RegisterPanel registerForm = new RegisterPanels.RegisterPanel();
            btnX.Visible = false;
            registerForm.ShowDialog();            
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {            
            ActivateButton(sender);
            btnX.Visible = false;
            RegisterPanels.LoginPanel loginForm = new RegisterPanels.LoginPanel();
            loginForm.ShowDialog();
        }

        private void buttonCloseChildForm_Click(object sender, EventArgs e) 
        {
            if (activeForm != null)            
                activeForm.Close();            
            Reset();
        }


        //private void panelDesktopPanel_Paint_1(object sender, PaintEventArgs e) { }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 11.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    panelTitleBar.BackColor = color;
                    pnlLeftLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnX.Visible = true;

                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            activeForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlMiddlePanel.Controls.Add(childForm);
            this.pnlMiddlePanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblHome.Text = childForm.Text;
        }

        private void Reset()
        {  
            DisableButton();
            lblHome.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(141, 145, 139);
            pnlLeftLogo.BackColor = Color.FromArgb(36, 35, 49);
            currentButton = null;
            btnX.Visible = false;
        }

        private void DisableButton()
        {
            foreach (Control previousButton in panelMenu.Controls)
            {
                if (previousButton.GetType() == typeof(Button))
                {
                    previousButton.BackColor = Color.FromArgb(49, 54, 56);
                    previousButton.ForeColor = Color.White;
                    previousButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
            }
        }

    }
}
