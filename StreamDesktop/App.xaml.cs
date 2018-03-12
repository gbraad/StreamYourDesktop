using System;
using System.Windows;

namespace StreamDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static TrayIcon TrayIcon;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            TrayIcon = new TrayIcon();
        }

    }
}
