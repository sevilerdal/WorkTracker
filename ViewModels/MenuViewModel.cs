using Caliburn.Micro;
using System.Windows;

namespace WorkTracker.ViewModels
{
    public class MenuViewModel : Screen
    {
        private readonly string docLink="https://github.com/sevilerdal/WorkTracker";
        public void SettingsButton()
        {
            MessageBox.Show("Upcoming features : Auto-save, notifications");
        }
        public void HelpButton()
        {
            MessageBoxResult messageBoxResult =
                MessageBox.Show("Do you like to go to documentation?", "Help",
                MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            if (messageBoxResult.ToString() == "Yes")
            {
                System.Diagnostics.Process.Start(docLink);
            }
        }
    }
}
