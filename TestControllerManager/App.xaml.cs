using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Interop;

using WinAPI = TestControllerManager.View.WinAPI;
using TestControllerManager.ViewModel;


namespace TestControllerManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int WsChild = 0x40000000;
        private const int WsVisible = 0x10000000;

        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow = new MainWindow
            {
                DataContext = MainWindowViewModelFactory.CreateMainViewModel(DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            };
            MainWindow.Show();
        }

        private static void ShowPreviewScreen(IntPtr previewWindow)
        {
            WinAPI.NativeMethods.RECT parentRect;
            WinAPI.NativeMethods.GetWindowRect(previewWindow, out parentRect);

            var wpfWin32 = new HwndSource(0,
                                           WsVisible | WsChild,
                                           0,
                                           0,
                                           0,
                                           parentRect.Right - parentRect.Left + 1,
                                           parentRect.Bottom - parentRect.Top + 1,
                                           "Screensaver Preview",
                                           previewWindow,
                                           false);
            var mainWindow = new MainWindow()
            {
                IsHitTestVisible = false,
                DataContext = MainWindowViewModelFactory.CreateMainViewModel(true)
            };
            wpfWin32.RootVisual = mainWindow;
            wpfWin32.Disposed += delegate
            {
                Current.Shutdown();
            };
        }

    }
}
