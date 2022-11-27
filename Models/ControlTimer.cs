using System;
using System.Diagnostics;
using System.Windows.Threading;

namespace WorkTracker.Models
{
    public class ControlTimer
    {
        private DispatcherTimer timer;
        private Stopwatch stopwatch;
        readonly CreateDBEntry createDBE = new CreateDBEntry();

        public string _timeText = "hi!";

        public ControlTimer()
        {
            CreateTimer();
        }

        private void CreateTimer()
        {
            timer = new DispatcherTimer();
            stopwatch = new Stopwatch();
            timer.Tick += new EventHandler(progress_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
        }

        private void progress_Tick(object sender, EventArgs e)
        {
            _timeText = stopwatch.Elapsed.ToString("hh\\:mm\\:ss");
        }

        public void ToggleTimer(string name)
        {
            int status;
            if (!timer.IsEnabled)
            {
                timer.Start();
                stopwatch.Start();
                status = 1;
            }
            else
            {
                timer.Stop();
                stopwatch.Stop();
                status = 0;
            }

            createDBE.CreateEntry(name,
                          DateTime.Now.ToString("D"),
                          DateTime.Now.ToString("t"),
                          DateTime.Now.ToString("t"),
                          _timeText,
                          stopwatch.Elapsed.Seconds, status);
        }
    }
}
