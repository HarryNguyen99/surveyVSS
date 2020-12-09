using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace surveyVSS
{
    public partial class survey : Form
    {

        public const int WM_QUERYENDSESSION = 0x0011;
        public const int WM_ENDSESSION = 0x0016;
        public const uint SHUTDOWN_NORETRY = 0x00000001;

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShutdownBlockReasonCreate(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string reason);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShutdownBlockReasonDestroy(IntPtr hWnd);
        [DllImport("kernel32.dll")]
        static extern bool SetProcessShutdownParameters(uint dwLevel, uint dwFlags);

        public survey()
        {
            InitializeComponent();
            this.FormClosing += Survey_FormClosing;
            // Define the priority of the application (0x3FF = The higher priority)
            SetProcessShutdownParameters(0x3FF, SHUTDOWN_NORETRY);

            // Set the SystemEvents class to receive event notification when a user 
            // preference changes, the palette changes, or when display settings change.
            SystemEvents.UserPreferenceChanging += new UserPreferenceChangingEventHandler(SystemEvents_UserPreferenceChanging);
            SystemEvents.PaletteChanged += new EventHandler(SystemEvents_PaletteChanged);
            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);
            SystemEvents.EventsThreadShutdown += new EventHandler(SystemEvents_EventsThreadShutdown);
            Application.ApplicationExit += Application_ApplicationExit;
            // For demonstration purposes, this application sits idle waiting for events.
            Console.WriteLine("This application is waiting for system events.");
            Console.WriteLine("Press <Enter> to terminate this application.");
            Console.ReadLine();


            void SystemEvents_EventsThreadShutdown(object sender, EventArgs e)
            {
                MessageBox.Show("ok");
            }

            // This method is called when a user preference changes.
            void SystemEvents_UserPreferenceChanging(object sender, UserPreferenceChangingEventArgs e)
            {
                Console.WriteLine("The user preference is changing. Category={0}", e.Category);
            }

            // This method is called when the palette changes.
            void SystemEvents_PaletteChanged(object sender, EventArgs e)
            {
                Console.WriteLine("The palette changed.");
            }

            // This method is called when the display settings change.
            void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
            {
                Console.WriteLine("The display settings changed.");
            }

        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {

        }

        private void Survey_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {

            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION || m.Msg == WM_ENDSESSION)
            {
                // Prevent windows shutdown
                ShutdownBlockReasonCreate(this.Handle, "I want to live!");
                ThreadPool.QueueUserWorkItem(o =>
                {
                    this.BeginInvoke((Action)(() =>
                    {
                        // This method must be called on the same thread as the one that have create the Handle, so use BeginInvoke
                        ShutdownBlockReasonCreate(this.Handle, "Now I must die!");
                        // Allow Windows to shutdown
                        ShutdownBlockReasonDestroy(this.Handle);
                        Process.Start("chrome", "-a");
                    }));
                });

                return;
            }

            base.WndProc(ref m);
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

            this.Close();

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
    }
}
