using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocAppVersion
{
    class RegisterActions
    {
        public RegisterActions()
        {

        }
        public static void createRegistre(string programmePath)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue("AppBlock", programmePath);
            key.Close();



            //redemarrage de l'ordinateur
            Process.Start("shutdown", "/r /t 30");
        }

        public static void DeleteRegistre()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.DeleteValue("AppBlock", false);
            key.Close();
        }
    }
    
}
