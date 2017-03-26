using System.Windows;

using Microsoft.TeamFoundation.Build.Client;

using SimpleInjector;

using TestControllerManager.BusinessLogic;
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
            ioc.Register<ITestControllerFactory, TestControllerFactory>(Lifestyle.Singleton);
            ioc.Register<IBuildServer, BuildServerWrapper>(Lifestyle.Singleton);
            ioc.Register<IConfiguration, Configuration>(Lifestyle.Singleton);
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
