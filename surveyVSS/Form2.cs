using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace surveyVSS
{


    public partial class Form2 : Form
    {
        private static int WM_QUERYENDSESSION = 0x11;
        private static bool systemShutdown = false;

        public Form2()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION)
            {
                MessageBox.Show("queryendsession: this is a logoff, shutdown, or reboot");
                systemShutdown = true;
            }

            // If this is WM_QUERYENDSESSION, the closing event should be  
            // raised in the base WndProc.  
            base.WndProc(ref m);

        } //WndProc   

        private void Form2_Closing(System.Object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (systemShutdown)
            // Reset the variable because the user might cancel the   
            // shutdown.  
            {
                systemShutdown = false;
                if (DialogResult.Yes == MessageBox.Show("My application",
                    "Do you want to save your work before logging off?",
                    MessageBoxButtons.YesNo))
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }
    }
}
