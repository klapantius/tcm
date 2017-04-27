using System;
using System.Collections.Generic;
using System.Linq;

namespace TestControllerManager.BusinessLogic
{
    internal class FakeTestController : ITestController
    {
        private readonly List<ITestAgent> myAgents = new List<ITestAgent>();
        public FakeTestController(string tcName)
        {
            Enumerable.Range(1, 10)
                .ToList()
                .ForEach(i => 
                    myAgents.Add(new FakeTestAgent(this, string.Format("{0}_Agent{1:D2}", tcName, i))));
        }
        public IEnumerable<ITestAgent> Agents { get { return myAgents; } }
        public void SetOnline(ITestAgent agent, bool online)
        {
            throw new NotImplementedException();
        }
    }
}
