using System;
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

            if (e.Args.Length > 0 && e.Args[1].Equals("/test", StringComparison.InvariantCulture))
            {
                ioc.Register<IConfiguration, FakeConfiguration>(Lifestyle.Singleton);
            }
            else
            {
                ioc.Register<IConfiguration, Configuration>(Lifestyle.Singleton);
                ioc.Register<ITestControllerFactory, TestControllerFactory>(Lifestyle.Singleton);
                ioc.Register<IBuildServer, BuildServerWrapper>(Lifestyle.Singleton);
                ioc.Register<IMainViewModel, MainViewModel>();
            }
            ioc.Register(() => ioc.GetInstance<IConfiguration>().TpcUri, Lifestyle.Singleton);
            ioc.Register(() => Dispatcher, Lifestyle.Singleton);
            ioc.Register<IDispatcherService, DispatcherService>();
            ioc.Register<MainWindow, MainWindow>();

            MainWindow = ioc.GetInstance<MainWindow>();

            MainWindow.Show();
        }
    }
}
