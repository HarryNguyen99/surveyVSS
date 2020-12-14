using Microsoft.Win32;
using surveyVSS.model;
using surveyVSS.service;
using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
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

      

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //string hostname = "";
            //System.Net.IPHostEntry ip = new IPHostEntry();
            //hostname = System.Net.Dns.GetHostName();
            //ip = System.Net.Dns.GetHostByName(hostname);
            //Console.WriteLine("Tên của host này là :" + ip.HostName);
            //Console.ReadLine();

            //foreach (System.Net.IPAddress listip in ip.AddressList)
            //{
            //    Console.WriteLine("ĐịaIP của host này là :" + listip.ToString());
            //    Console.ReadLine();
            //}

            //tesst
            var testModel = new TestModel()
            {
                Body = "test",
                Id = 99999,
                UserId = 1,
                Title = "Test"
            };
            //await new HttpHelpers().PostAsync("https://jsonplaceholder.typicode.com/posts", testModel);
            //await HttpHelpers.RunAsync("https://jsonplaceholder.typicode.com/posts/1/comments");

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

        private  async void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ok4");
            
            this.Close();
        }

        private async void survey_Load(object sender, EventArgs e)
        {
            //this.Hide();

            while (false)
            {
                if (DateTime.Now.ToString("hh:mm").Equals("17:00"))
                {
                    this.Show();
                    break;
                }
                await Task.Delay(100);
            }



        }
    }
}
