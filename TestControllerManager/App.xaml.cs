using System;
using System.Reflection;
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

            if (e.Args.Length > 0 && e.Args[0].Equals("/test", StringComparison.InvariantCulture))
            {
                var assembly = Assembly.Load(AssemblyName.GetAssemblyName("FakeBusinessLogic.dll"));
                ioc.Register(() => (ITestControllerFactory)assembly.GetType("FakeTestControllerFactory"), Lifestyle.Singleton);
                ioc.Register(() => (IBuildServer)assembly.GetType("FakeBuildServer"), Lifestyle.Singleton);
                ioc.Register(typeof(IConfiguration), assembly.GetType("TestControllerManager.BusinessLogic.FakeConfiguration"), Lifestyle.Singleton);
            }
            else
            {
                ioc.Register<ITestControllerFactory, TestControllerFactory>(Lifestyle.Singleton);
                ioc.Register<ITfsTeamProjectCollection, TfsTeamProjectCollectionWrapper>(Lifestyle.Singleton);
                ioc.Register(() => ioc.GetInstance<IConfiguration>().TpcUri, Lifestyle.Singleton);
                ioc.Register(() => ioc.GetInstance<ITfsTeamProjectCollection>().GetService<IBuildServer>());
                ioc.Register<IConfiguration, Configuration>(Lifestyle.Singleton);
            }
            ioc.Register<IMainViewModel, MainViewModel>();
            ioc.Register(() => Dispatcher, Lifestyle.Singleton);
            ioc.Register<IDispatcherService, DispatcherService>();
            ioc.Register<MainWindow, MainWindow>();

            MainWindow = ioc.GetInstance<MainWindow>();

            MainWindow.Show();
        }
    }

    class FakedTypesLoader
    {
    }
}
