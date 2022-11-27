using ProcessData;
using SqliteDBAccess;
using System.ComponentModel;

namespace WorkTracker.Models
{
    public class CreateDBEntry : INotifyPropertyChanged
    {
        readonly TimerData timerData = new TimerData();
        readonly ValidateData validateData = new ValidateData();
        public event PropertyChangedEventHandler PropertyChanged;

        public void CreateEntry(string projName, string startDate, string startTime, string endTime, string timePassed, int seconds, int status)
        {
            var newSession = timerData.GenerateEntry(projName, startDate, startTime, endTime, timePassed, seconds, status);
            if (status == 1) return;

            if (validateData.DataIsValid(newSession))
            {
                SqlDBAccess.SaveSession(newSession);
                OnPropertyChanged("Entries");
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
