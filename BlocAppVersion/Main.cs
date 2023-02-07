using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlocAppVersion
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.TopMost = true;
            label1.Text = "Have you updated your register?";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Form form in Globalvars.ListForms)
            {
                form.Close();
            }
        }
    }
}
