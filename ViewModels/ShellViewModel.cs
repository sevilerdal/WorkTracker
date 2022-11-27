using Caliburn.Micro;

namespace WorkTracker.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public TimerViewModel timerVM;
        public MenuViewModel menuVM;
        public DataViewModel dataVM;

        public ShellViewModel()
        {
            CreateContents();

        }
        public void CreateContents()
        {
            timerVM = new TimerViewModel();
            menuVM = new MenuViewModel();
            dataVM = new DataViewModel();
        }

        public TimerViewModel TimerView
        {
            get { return timerVM; }
            set { timerVM = value; }
        }

        public MenuViewModel MenuView
        {
            get { return menuVM; }
            set { menuVM = value; }
        }
        public DataViewModel DataView
        {
            get { return dataVM; }
            set { dataVM = value; }
        }
    }
}