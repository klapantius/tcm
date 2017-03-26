using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

using TestControllerManager.Model;


namespace TestControllerManager.ViewModel
{
    public class MainViewModelPreview : IMainViewModel
    {
        private MainWindowData myData;
        private readonly ObservableCollection<ITestControllerViewModel> myTestControllers;

        public MainViewModelPreview()
        {
            Bar = 42;
            myTestControllers = new ObservableCollection<ITestControllerViewModel>()
            {
                new TestControllerViewModel("Favourite 1", true),
                new TestControllerViewModel("Favourite 2", true),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Bar { get; set; }

        public ICollectionView TestControllers
        {
            get
            {
                return CollectionViewSource.GetDefaultView(myTestControllers);
            }
        }

        public ITestControllerViewModel TestController { get; set; }
    }
}