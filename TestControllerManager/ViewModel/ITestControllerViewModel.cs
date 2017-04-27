using System.Collections.Generic;

using TestControllerManager.BusinessLogic;


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
        List<ITestAgentViewModel> Agents { get; }
        void UpdateAgents();
        //void RefreshAgent(ITestAgent agent);
    }

    internal class TestControllerData
    {
        public string Name;
        public bool IsFavourite;
        public List<ITestAgent> TestAgents;
    }
}
