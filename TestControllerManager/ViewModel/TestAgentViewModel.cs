using System.ComponentModel;
using System.Runtime.CompilerServices;

using TestControllerManager.Annotations;
using TestControllerManager.BusinessLogic;


namespace TestControllerManager.ViewModel
{
    public class TestAgentViewModel : ITestAgentViewModel, INotifyPropertyChanged
    {
        private readonly ITestAgent myAgent;
        private bool? myScheduled;

        public TestAgentViewModel(ITestAgent agent)
        {
            myAgent = agent;
            StatusDetails = string.Empty; //todo: remove this if implementation is available
        }

        public string Name { get { return myAgent.Name; } }
        public string Status { get { return myAgent.Status.ToString(); } }

        public bool? Scheduled
        {
            get { return myScheduled; }
            set
            {
                myScheduled = value;
                OnPropertyChanged();
            }
        }

        //todo: implement StatusDetails
        public string StatusDetails { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void DeleteSchedule()
        {
            Scheduled = null;
        }
    }
}
