using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlocAppVersion
{
    public partial class Form1 : Form
    {
        Main mainsForm;
        public Form1()
        {
            InitializeComponent();
            Globalvars.ListForms = new List<Form>();

            if (File.Exists(Globalvars.PATHFICHIERSCHEDULES)==false)
            {

                Fichiers.CreateFichier();
                RegisterActions.DeleteRegistre();
                RegisterActions.createRegistre(Globalvars.ProjetNamePath + @"\BlocAppVersion.exe");
                
               
            }


            new SchedularsActions();



            ShowMainFormOnAllScreen();

           // MessageBox.Show(Globalvars.ProjetNamePath);

        }

        private void ShowMainFormOnAllScreen()
        {
            this.WindowState = FormWindowState.Minimized;
            //   int i = 1;
            foreach (Screen screen in Screen.AllScreens)
            {
                mainsForm = new Main
                {
                    StartPosition = FormStartPosition.Manual,
                    Location = screen.WorkingArea.Location,
                    
                    Size = screen.Bounds.Size,
                    TopMost = true
                };
                Globalvars.ListForms.Add(mainsForm);
                mainsForm.Show();
            }

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
