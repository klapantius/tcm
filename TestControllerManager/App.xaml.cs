﻿using System;
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
                ioc.Register<ITestControllerFactory, FakeTestControllerFactory>(Lifestyle.Singleton);
                ioc.Register<IBuildServer, FakeBuildServer>(Lifestyle.Singleton);
            }
            else
            {
                ioc.Register<ITestControllerFactory, TestControllerFactory>(Lifestyle.Singleton);
                ioc.Register<ITfsTeamProjectCollection, TfsTeamProjectCollectionWrapper>(Lifestyle.Singleton);
                ioc.Register(() => new Uri("https://tfs.healthcare.siemens.com:8090/tfs/ikm.tpc.projects"), Lifestyle.Singleton);
                ioc.Register(() => ioc.GetInstance<ITfsTeamProjectCollection>().GetService<IBuildServer>());
            }
            ioc.Register<IConfiguration, Configuration>(Lifestyle.Singleton);
            ioc.Register<IMainViewModel, MainViewModel>();
            ioc.Register<MainWindow, MainWindow>();
            ioc.Register(() => Dispatcher, Lifestyle.Singleton);
            ioc.Register<IDispatcherService, DispatcherService>();

            MainWindow = ioc.GetInstance<MainWindow>();

            MainWindow.Show();
        }
    }
}
