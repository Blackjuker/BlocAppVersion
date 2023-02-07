using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlocAppVersion
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!File.Exists(Globalvars.PATHFICHIERSCHEDULES))
            {
                RegisterActions.DeleteRegistre();
                RegisterActions.createRegistre(Globalvars.ProjetNamePath + "BlocAppVersion.exe");
                Application.Run(new Form1());
            }
            else
            {
                Application.Run(new Form1());
            }
        }
    }
}
