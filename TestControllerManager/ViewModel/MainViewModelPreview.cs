using System.Collections.ObjectModel;
using System.ComponentModel;
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
            Foo = "Test Foo Test Foo Test Foo";
            Bar = 42;
            myTestControllers = new ObservableCollection<ITestControllerViewModel>()
            {
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string Foo { get; set; }
        public int Bar { get; set; }

        public ICollectionView TestControllers
        {
            get
            {
                return CollectionViewSource.GetDefaultView(myTestControllers);
            }
        }
    }
}