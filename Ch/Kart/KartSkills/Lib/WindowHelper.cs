using System.Windows;

namespace KartSkills.Lib
{
    public class WindowHelper
    {
        public Window MainWindow = Application.Current.MainWindow;

        public static void OpenNewWindow(Window window)
        {
            Application.Current.MainWindow = window;
            Application.Current.MainWindow.Show();
        }
    }
}
