using System.ComponentModel;

using TestControllerManager.Model;


namespace TestControllerManager.ViewModel
{
    public class MainViewModelPreview: IMainViewModel
    {
        private MainWindowData myData;

        public MainViewModelPreview()
        {
            Foo = "Test Foo Test Foo Test Foo";
            Bar = 42;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string Foo { get; set; }
        public int Bar { get; set; }
        public ICollectionView TestControllers { get; private set; }
    }
}