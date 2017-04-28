using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

using TestControllerManager.Annotations;
using TestControllerManager.BusinessLogic;


namespace TestControllerManager.ViewModel
{
    public class TestControllerViewModel : ITestControllerViewModel, INotifyPropertyChanged
    {
        private ITestControllerFactory myFactory;
        private ITestController myBusinessLogic;
        private TestControllerData myModel;
        private bool myIsAvailable;
        private string myAvailabilityText;
        private bool myIsSelected;

        public TestControllerViewModel(string name, ITestController businessLogic, bool isFavourite)
        {
            myModel = new TestControllerData();
            Name = name;
            myBusinessLogic = businessLogic;
            IsFavourite = isFavourite;
            IsAvailable = true;
            AvailabilityText = "status is unkown yet";
            IsSelected = false;
            Agents=new List<ITestAgentViewModel>();
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
            set
            {
                if (myIsSelected = value) OnPropertyChanged("Agents");
            }
        }

        public bool IsSpecial
        {
            get { return false; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return Name;
        }

        public List<ITestAgentViewModel> Agents { get; private set; }

        public void UpdateAgents()
        {
            var vtas = new List<ITestAgentViewModel>();
            myBusinessLogic.Agents.ToList()
                .ForEach(ta =>
                {
                    vtas.Add(new TestAgentViewModel(ta));
                    if (Agents.All(a => a != vtas.Last())) Agents.Add(vtas.Last());
                });
            var toBeDeleted = Agents.Where(a => vtas.All(vta => vta != a)).ToList();
            toBeDeleted.ForEach(tbd => Agents.Remove(tbd));
            OnPropertyChanged("Agents");
            //Agents.ForEach(a => a.Update()));
        }

    }
}