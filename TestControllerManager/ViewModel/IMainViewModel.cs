using System.ComponentModel;


namespace TestControllerManager.ViewModel
{
    public interface IMainViewModel : INotifyPropertyChanged
    {
        string Foo { get; set; }
        int Bar { get; set; }
        ICollectionView TestControllers { get; }
    }
}