using surveyVSS.model;
using surveyVSS.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace surveyVSS
{
    public partial class survey : Form
    {

        public survey()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string hostname = "";
            System.Net.IPHostEntry ip = new IPHostEntry();
            hostname = System.Net.Dns.GetHostName();
            ip = System.Net.Dns.GetHostByName(hostname);
            Console.WriteLine("Tên của host này là :" + ip.HostName);
            Console.ReadLine();

            foreach (System.Net.IPAddress listip in ip.AddressList)
            {
                Console.WriteLine("ĐịaIP của host này là :" + listip.ToString());
                Console.ReadLine();
            }

           
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ok2");
            this.Close();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ok3");
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ok4");
            this.Close();
        }

        public static event Microsoft.Win32.SessionEndingEventHandler SessionEnding;
        private static int WM_QUERYENDSESSION = 0x11;
        private static bool systemShutdown = false;
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

        } 
        //WndProc   

        //private void Form1_Closing(
        //    System.Object sender,
        //    System.ComponentModel.CancelEventArgs e)
        //{
        //    if (systemShutdown)
        //    // Reset the variable because the user might cancel the   
        //    // shutdown.  
        //    {
        //        systemShutdown = false;
        //        if (DialogResult.Yes == MessageBox.Show("My application",
        //            "Do you want to save your work before logging off?",
        //            MessageBoxButtons.YesNo))
        //        {
        //            e.Cancel = true;
        //        }
        //        else
        //        {
        //            e.Cancel = false;
        //        }
        //    }
        //}

        private void survey_Load(object sender, FormClosingEventArgs e)
        {
            if (systemShutdown)
            {
                // reset the variable since they may cancel the shutdown
                systemShutdown = false;
                e.Cancel = false;

            }
            else
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
