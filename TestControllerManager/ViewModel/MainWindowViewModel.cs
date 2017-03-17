using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

using TestControllerManager.Model;


namespace TestControllerManager.ViewModel
{
    public interface IMainViewModel: INotifyPropertyChanged
    {
        string Foo { get; set; }
        int Bar { get; set; }
    }

    public class MainWindowViewModel : IMainViewModel
    {
        private MainWindowData myData;

        public MainWindowViewModel()
        {
            myData = new MainWindowData();
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                Foo = "hello";
            }
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
