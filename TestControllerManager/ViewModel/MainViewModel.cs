using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;

using Microsoft.TeamFoundation.Build.Client;

using TestControllerManager.BusinessLogic;
using TestControllerManager.Model;


namespace TestControllerManager.ViewModel
{
    public class MainViewModel : IMainViewModel
    {
        private MainWindowData myData;
        private readonly ITestControllerFactory myTestControllerFactory;
        
        private readonly ObservableCollection<ITestControllerViewModel> myTestControllers;
        public ICollectionView TestControllers
        {
            get
            {
                var result = CollectionViewSource.GetDefaultView(myTestControllers);
                //result.SortDescriptions.Add(new SortDescription("IsFavourite", ListSortDirection.Descending));
                //result.SortDescriptions.Add(new SortDescription("IsSpecial", ListSortDirection.Descending));
                //result.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                return result;
            }
        }

        public MainViewModel(IBuildServer buildServer, ITestControllerFactory testControllerFactory)
        {
            myTestControllerFactory = testControllerFactory;
            myData = new MainWindowData();
            Foo = "hello";
            Bar = 21;
        }

        public string Foo
        {
            get { return myData.Foo; }
            set
            {
                myData.Foo = value;
                OnPropertyChanged();
            }
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


    }
}
