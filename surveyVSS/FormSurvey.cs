using surveyVSS.model;
using surveyVSS.service;
using surveyVSS;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Timers;
using System.Drawing;
using System.Net;

namespace surveyVSS
{

    public partial class survey : Form
    {
        public survey()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private async void Very_Good_Click(object sender, EventArgs e)
        {

            var surveyModel = new SurveyModel()
            {
                type = "1",
                hostName = Hostname.GetHostName()
            };
            await new HttpHelpers().PostAsync(Constan.URL + "add", surveyModel);
            MessageBox.Show("Chúc bạn buổi tối tốt lành.");
            this.Close();

        }

        private async void Good_Click(object sender, EventArgs e)
        {
            var surveyModel = new SurveyModel()
            {
                type = "2",
                hostName = Hostname.GetHostName()
            };
            await new HttpHelpers().PostAsync(Constan.URL + "add", surveyModel);
            MessageBox.Show("Chúc bạn buổi tối tốt lành.");
            this.Close();

        }

        private async void Bad_Click(object sender, EventArgs e)
        {
            var surveyModel = new SurveyModel()
            {
                type = "3",
                hostName = Hostname.GetHostName()
        };
            await new HttpHelpers().PostAsync(Constan.URL + "add", surveyModel);
            MessageBox.Show("Chúc bạn buổi tối tốt lành.");
            this.Close();

        }

        private async void Angry_Click(object sender, EventArgs e)
        {
            var surveyModel = new SurveyModel()
            {
                type = "4",
                hostName = Hostname.GetHostName()
            };
            
            //  await new HttpHelpers().PostAsync(Constan.URL + "add", surveyModel);
            MessageBox.Show("Chúc bạn buổi tối tốt lành.");
            this.Close();
        }

        private async void survey_Load(object sender, EventArgs e)
        {
            // this.Hide();
            await HttpHelpers.RunAsync(Constan.URL + "time");
            while (false)
            {
                
                if (DateTime.Now.ToString("hh:mm").Equals("11:47"))
                {
                    this.Show();
                    break;
                }
            }
            //this.TopMost = true;

        }

        private void survey_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Clip = this.Bounds;
        }

        //private int X = 0;
        //private int Y = 0;
        //private void survey_MouseLeave(object sender, EventArgs e)
        //{
        //    if (Cursor.Position.X < this.Bounds.X + 50)
        //        X = Cursor.Position.X + 20;
        //    else
        //        X = Cursor.Position.X - 20;

        //    if (Cursor.Position.Y < this.Bounds.Y + 50)
        //        Y = Cursor.Position.Y + 20;
        //    else
        //        Y = Cursor.Position.Y - 20;
        //}

        //private void survey_MouseMove(object sender, MouseEventArgs e)
        //{
        //    Cursor.Position = new Point(Cursor.Position.X - 500, Cursor.Position.Y - 500);
        //    Cursor.Clip = new Rectangle(this.Location, this.Size);

        //}
    }
}
