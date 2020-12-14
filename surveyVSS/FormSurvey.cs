using surveyVSS.model;
using surveyVSS.service;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Timers;
namespace surveyVSS
{
    public partial class survey : Form
    {
        private static System.Timers.Timer serverTime;
        public survey()
        {
            InitializeComponent();
            serverTime = new System.Timers.Timer();
            serverTime.Interval = 5000;
            serverTime.Elapsed += ServerTime_Elapsed;
        }

        private void ServerTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (e.SignalTime.Hour >= 17)
            { 

            }
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
     
            var surveyModel = new SurveyModel()
            {
                type = "1"
            };
            await new HttpHelpers().PostAsync("http://localhost:8080/api/moodSuvervey/add", surveyModel);
            MessageBox.Show("Chúc bạn buổi tối tốt lành.");
            this.Close();

        }

        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            var surveyModel = new SurveyModel()
            {
                type = "2"
            };
            await new HttpHelpers().PostAsync("http://localhost:8080/api/moodSuvervey/add", surveyModel);
            MessageBox.Show("Chúc bạn buổi tối tốt lành.");
            this.Close();

        }

        private async void pictureBox3_Click(object sender, EventArgs e)
        {
            var surveyModel = new SurveyModel()
            {
                type = "3"
            };
            await new HttpHelpers().PostAsync("http://localhost:8080/api/moodSuvervey/add", surveyModel);
            MessageBox.Show("Chúc bạn buổi tối tốt lành.");
            this.Close();
        }

        private  async void pictureBox4_Click(object sender, EventArgs e)
        {
            var surveyModel = new SurveyModel()
            {
                type = "4"
            };
            //  await new HttpHelpers().PostAsync("http://localhost:8080/api/moodSuvervey/add", surveyModel);
            MessageBox.Show("Chúc bạn buổi tối tốt lành.");
            this.Close();
        }

        private async void survey_Load(object sender, EventArgs e)
        {
           // this.Hide();

            while (false)
            {
                //await HttpHelpers.RunAsync("http://localhost:8080/api/moodSuvervey/");
                if (DateTime.Now.ToString("hh:mm").Equals("11:47"))
                {
                    this.Show();
                    break;
                }
            }
            this.TopMost = true;
        }

        private void survey_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Clip = this.Bounds;
        }
    }
}
