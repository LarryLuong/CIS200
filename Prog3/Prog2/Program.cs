// Program 3
// CIS 200-75
// Fall 2022
// Due: 11/23/2022
// By: Larry Nguyen 5317169

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPVApp
{
    [Serializable]
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
            Application.Run(new Prog2Form());
        }
    }
}
