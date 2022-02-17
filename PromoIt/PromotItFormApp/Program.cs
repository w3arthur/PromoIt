using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PromotItFormApp.LandingPanels;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;

namespace PromotItFormApp
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Loggings.ReportLog("Windows Form Start");
            

            Application.Run(new PromotIt() );
        }

    }

}
