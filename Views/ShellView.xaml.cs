using System.Windows;
using System.Windows.Input;
using WorkTracker.ViewModels;

namespace WorkTracker.Views
{
    public partial class ShellView : Window
    {
        readonly ShellViewModel shellVM = new ShellViewModel();
        public ShellView()
        {
            InitializeComponent();
            shellVM.CreateContents();
        }


        public void Shell_MouseEnter(object sender, MouseEventArgs e)
        {
            Opacity = 1;
        }

        private void Shell_MouseLeave(object sender, MouseEventArgs e)
        {
            Opacity = 0.75;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}