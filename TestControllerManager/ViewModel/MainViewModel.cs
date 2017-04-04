using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Data;

using Microsoft.TeamFoundation.Build.Client;

using TestControllerManager.BusinessLogic;
using TestControllerManager.Model;


namespace TestControllerManager.ViewModel
{
    public class MainViewModel : IMainViewModel
    {
        private readonly IConfiguration myConfiguration;
        private readonly IBuildServer myBuildServer;
        private readonly ITestControllerFactory myTestControllerFactory;
        private readonly IDispatcherService myDispatcher;

        private MainWindowData myData;
        
        private readonly ObservableCollection<ITestControllerViewModel> myTestControllers;
        private ITestControllerViewModel myTestController;

        public ICollectionView TestControllers
        {
            get
            {
                var result = CollectionViewSource.GetDefaultView(myTestControllers);
                result.SortDescriptions.Add(new SortDescription("IsFavourite", ListSortDirection.Descending));
                //result.SortDescriptions.Add(new SortDescription("IsSpecial", ListSortDirection.Descending));
                result.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                return result;
            }
        }

        public MainViewModel(IConfiguration configuration, IBuildServer buildServer, ITestControllerFactory testControllerFactory, IDispatcherService dispatcher)
        {
            myConfiguration = configuration;
            myBuildServer = buildServer;
            myTestControllers = new ObservableCollection<ITestControllerViewModel>();
            myTestControllerFactory = testControllerFactory;
            myDispatcher = dispatcher;
            myData = new MainWindowData();

            LoadFavouriteControllers();
        }

        private async void LoadFavouriteControllers()
        {
            var favs = myConfiguration.Favourites.Split(',');

            await Task.Run(() =>
            {
                favs.Select(f => new TestControllerViewModel(f, true))
                    .ToList()
                    .ForEach(c => myDispatcher.InvokeAsync(() => myTestControllers.Add(c)));
            });
        }

        public int Bar
        {
            get { return myData.Bar; }
            set
            {
                myData.Bar = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public ITestControllerViewModel TestController
        {
            get { return myTestController; }
            set
            {
                myTestController = value;
                // change list of test agents
            }
        }
    }
}
