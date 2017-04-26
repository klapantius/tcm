using System;
using System.Collections.Generic;


namespace TestControllerManager.BusinessLogic
{
    internal class FakeTestAgent: ITestAgent
    {
        public FakeTestAgent(ITestController tc, string name)
        {
            Name = name;
            Online = true;
            Status = TestAgentStatus.Ready;
            TestController = tc;
        }
        public string Name { get; private set; }
        public IEnumerable<Tuple<string, string>> Attributes { get; private set; }
        public bool Online { get; set; }
        public TestAgentStatus Status { get; private set; }
        public ITestController TestController { get; private set; }
    }
}
