using System.ComponentModel;


namespace TestControllerManager.ViewModel
{
    public interface IMainViewModel : INotifyPropertyChanged
    {
        int Bar { get; set; }
        ICollectionView TestControllers { get; }
    }
}