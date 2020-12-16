using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using surveyVSS;
using surveyVSS.service;

namespace surveyVSS
{
    class Timer
    {
        private static System.Timers.Timer serverTime;

        public Timer()
        {
            serverTime = new System.Timers.Timer();
            serverTime.Interval = 5000;
            serverTime.Elapsed += ServerTime_Elapsed;
        }

        private async void ServerTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            await HttpHelpers.RunAsync(Constan.URL + "time");


            if (e.SignalTime.Hour >= 17)
            {

            }
        }
    }

}
