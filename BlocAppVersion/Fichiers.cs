using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlocAppVersion
{
    class Fichiers
    {
        public static void CreateFichier()
        {
            string[] lines = new string[] { "09:00", "17:57" };
            try
            {
               
               
                
                if (!File.Exists(Globalvars.PATHFICHIERSCHEDULES))
                {
                    File.WriteAllLines(Globalvars.PATHFICHIERSCHEDULES, lines);
                  //  Console.WriteLine("File written successfully."+ Globalvars.PATHFICHIERSCHEDULES);
                }
                else
                {
                   // Console.WriteLine("File already exists.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
