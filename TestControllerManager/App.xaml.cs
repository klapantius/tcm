using System.Windows;
using SimpleInjector;
using TestControllerManager.ViewModel;


namespace TestControllerManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var ioc = new Container();
            ioc.Register(() => Dispatcher, Lifestyle.Singleton);
            ioc.Register<IDispatcherService, DispatcherService>();
            ioc.Register<IMainViewModel, MainViewModel>();
            ioc.Register<MainWindow, MainWindow>();
            //ioc.Register(() => new Uri("https://tfs.healthcare.siemens.com:8090/tfs/ikm.tpc.projects"), Lifestyle.Singleton);

            MainWindow = ioc.GetInstance<MainWindow>();

            MainWindow.Show();
        }
    }
}
