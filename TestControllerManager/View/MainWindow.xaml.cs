using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

using TestControllerManager.ViewModel;


namespace TestControllerManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMainViewModel myViewModel;
        private readonly IDispatcherService myDispatcher;

        public MainWindow(IDispatcherService dispatcher, IMainViewModel mainViewModel)
        {
            InitializeComponent();

            myViewModel = mainViewModel;
            myDispatcher = dispatcher;

            DataContext = myViewModel;
        }

        private void TestControllerSelectionComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e == null) return;
            var selectionChangedEvent = (SelectionChangedEventArgs)e;
            myViewModel.TestController =
                (selectionChangedEvent.AddedItems == null || selectionChangedEvent.AddedItems.Count == 0) ?
                    null :
                    (TestControllerViewModel)selectionChangedEvent.AddedItems[0];

        }
    }
}
