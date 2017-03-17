using System.ComponentModel;

using TestControllerManager.Model;


namespace TestControllerManager.ViewModel
{
    public class MainWindowViewModelPreview: IMainViewModel
    {
        private MainWindowData myData;

        public MainWindowViewModelPreview()
        {
            Foo = "Test Test Test";
            Bar = 42;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string Foo { get; set; }
        public int Bar { get; set; }
    }
}