using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using T_Manager.Modal;

namespace T_Manager
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
            //Application.Run(new FImport());
            //return;
            if (MHeTHong.IsSet(MHeTHong.DATE) == true)
            {
                Application.Run(new FMain());
            }
            else
            {
                Application.Run(new FImport());
            }
        }
    }
}
