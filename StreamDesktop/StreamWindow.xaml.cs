using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace StreamYourDesktop
{
    /// <summary>
    /// Interaction logic for StreamWindow.xaml
    /// </summary>
    public partial class StreamWindow : Window
    {

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);
 
        private const int WM_COMMAND = 0x111;
        private const int MIN_ALL = 419;
        private const int MIN_ALL_UNDO = 416;


        [DllImport("User32")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        private const byte UP = 2;
        private const byte CTRL = 17;
        private const byte ESC = 27;


        public StreamWindow()
        {
            InitializeComponent();
            Maximize();
            //ShowDesktop();
            //OpenStartMenu();
        }

        public void Maximize()
        {
            this.Show();
            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;
            this.Title = "St(r)eam your Desktop";
        }

        public void ShowDesktop()
        {
            IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
            SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL, IntPtr.Zero);
        }

        public void HideDesktop()
        {
            IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
            SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL_UNDO, IntPtr.Zero);
        }

        public void OpenStartMenu()
        {
            // Press Ctrl-Esc key to open Start menu
            keybd_event(CTRL, 0, 0, 0);
            keybd_event(ESC, 0, 0, 0);

            // Need to Release those two keys
            keybd_event(CTRL, 0, UP, 0);
            keybd_event(ESC, 0, UP, 0);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
        
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            OpenStartMenu();
        }
    }
}