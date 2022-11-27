using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WorkTracker.Models;
using WorkTracker.ViewModels;

namespace WorkTracker.Views
{
    public partial class TimerView : UserControl
    {
        private DispatcherTimer timer;
        private Stopwatch stopwatch;
        private string _timeText;
        readonly CreateDBEntry createDBE = new CreateDBEntry();
        readonly DataViewModel dataVM = new DataViewModel();

        public TimerView()
        {
            CreateTimer();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleTimer(WorkInput.Text);
            dataVM.LoadData();
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
            _timeText = TimerDisplay.Text = stopwatch.Elapsed.ToString("hh\\:mm\\:ss");

        }
        int status;
        public void ToggleTimer(string name)
        {
            if (!timer.IsEnabled)
            {
                CreateTimer();
                timer.Start();
                stopwatch.Start();
                status = 1;
                buttonImage.Source = new BitmapImage(new Uri(@"C:\\Users\\Ozg\\source\\repos\\WorkTracker\\WorkTracker\\Images\StopButton.png"));

            }
            else
            {
                timer.Stop();
                stopwatch.Stop();
                status = 0;
                buttonImage.Source = new BitmapImage(new Uri(@"C:\\Users\\Ozg\\source\\repos\\WorkTracker\\WorkTracker\\Images\PlayBtton.png"));

            }
            createDBE.CreateEntry(name,
                          DateTime.Now.ToString("D"),
                          DateTime.Now.ToString("t"),
                          DateTime.Now.ToString("t"),
                          _timeText,
                          stopwatch.Elapsed.Seconds, status);
        }

        private void WorkInput_GotFocus(object sender, RoutedEventArgs e)
        {
            WorkInput.Text = "";
        }
    }
}