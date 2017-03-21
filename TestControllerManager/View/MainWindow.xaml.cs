using System.Windows;
using System.Windows.Threading;

using TestControllerManager.ViewModel;


namespace TestControllerManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMainViewModel myMainViewModel;
        private readonly IDispatcherService myDispatcher;

        public MainWindow(IDispatcherService dispatcher, IMainViewModel mainViewModel)
        {
            InitializeComponent();

            myMainViewModel = mainViewModel;
            myDispatcher = dispatcher;

        }
    }
}
