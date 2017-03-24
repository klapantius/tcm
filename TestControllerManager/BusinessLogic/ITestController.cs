using System.Collections.Generic;

namespace TestControllerManager.BusinessLogic
{
    public interface ITestController
    {
        IEnumerable<ITestAgent> Agents { get; }
        void SetOnline(ITestAgent agent, bool online);
    }

}
