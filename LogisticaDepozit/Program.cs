using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using WMPLib;

namespace LogisticaDepozit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Environment.SetEnvironmentVariable("EMAIL_ADDRESS", "dariusturcu085@gmail.com");
            Environment.SetEnvironmentVariable("EMAIL_PASSWORD", "mpyb eofx qyvf wlbv");


            Application.Run(new HomePageForm());
        }
    }
}
