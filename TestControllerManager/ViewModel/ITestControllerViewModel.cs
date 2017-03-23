using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestControllerManager.Annotations;

namespace TestControllerManager.ViewModel
{
    public interface ITestControllerViewModel
    {
        string Name { get; set; }
        bool IsFavourite { get; set; }
        bool IsAvailable { get; }
        string AvailabilityText { get; }
        bool IsSelected { get; set; }
        bool IsSpecial { get; }
        //List<ITestAgentViewModel> AgentViewModels { get; }
        //List<ITestAgent> Agents { get; }
        //void RefreshAgent(ITestAgent agent);
    }

    public class TestControllerViewModel : ITestControllerViewModel, INotifyPropertyChanged
    {
        private TestControllerData myModel;
        private bool myIsAvailable;
        private string myAvailabilityText;
        private bool myIsSelected;

        public TestControllerViewModel(string name, bool isFavourite)
        {
            myModel = new TestControllerData()
            {
                Name = name,
                IsFavourite = isFavourite
            };
            IsAvailable = true;
            AvailabilityText = "status is unkown yet";
            IsSelected = false;
        }

        public string Name
        {
            get { return myModel.Name; }
            set
            {
                myModel.Name = value;
                OnPropertyChanged();
            }
        }
        public bool IsFavourite
        {
            get { return myModel.IsFavourite; }
            set
            {
                myModel.IsFavourite = value;
                OnPropertyChanged();
            }
        }

        public bool IsAvailable
        {
            get { return myIsAvailable; }
            private set
            {
                myIsAvailable = value;
                OnPropertyChanged();
            }
        }

        public string AvailabilityText
        {
            get { return myAvailabilityText; }
            private set
            {
                myAvailabilityText = value;
                OnPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get { return myIsSelected; }
            set { myIsSelected = value; }
        }

        public bool IsSpecial { get { return false; } }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    internal class TestControllerData
    {
        public string Name;
        public bool IsFavourite;
        //public List<TestAgentData> TestAgents;
    }
}
