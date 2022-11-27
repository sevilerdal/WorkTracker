using Caliburn.Micro;
using ProcessData;
using SqliteDBAccess;
using System.Collections.Generic;
using System.Linq;

namespace WorkTracker.ViewModels
{
    public class DataViewModel : Screen
    {
        public DataViewModel()
        {
            LoadData();
        }

        public void LoadData()
        {
            List<Session> reversed = Enumerable.Reverse(SqlDBAccess.GetEntries()).ToList();
            sessions = new BindableCollection<Session>(reversed);
            NotifyOfPropertyChange(() => sessions);
        }

        private BindableCollection<Session> sessions;

        public BindableCollection<Session> Entries
        {
            get { return sessions; }
            set
            {
                sessions = value;
                NotifyOfPropertyChange(() => Entries);
            }
        }

    }
}
