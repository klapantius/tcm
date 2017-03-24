using System;
using System.Collections;
using System.Collections.Generic;


namespace TestControllerManager.BusinessLogic
{
    public class TestAgent : ITestAgent
    {
        private object TestAgentObject { get; set; }

        public TestAgent(object agent, TestController testController)
        {
            TestAgentObject = agent;
            TestController = testController;
        }

        public string Name
        {
            get
            {
                return (string)TestAgentObject.GetType().GetProperty("AgentName").GetValue(TestAgentObject);
            }
        }
        public IEnumerable<Tuple<string, string>> Attributes
        {
            get
            {
                var attributes =
                    TestAgentObject.GetType().GetProperty("Attributes").GetValue(TestAgentObject) as IEnumerable;
                foreach (var attribute in attributes)
                {
                    var kvp = (KeyValuePair<string, string>)attribute;
                    yield return new Tuple<string, string>(kvp.Key, kvp.Value);
                }
            }
        }
        public bool Online
        {
            get { return (bool)TestAgentObject.GetType().GetProperty("Online").GetValue(TestAgentObject); }
            set { TestController.SetOnline(this, value); }
        }
        public TestAgentStatus Status
        {
            get
            {
                var agentInformation = TestAgentObject.GetType().GetProperty("AgentInformation").GetValue(TestAgentObject);
                var status = (int)agentInformation.GetType().GetProperty("Status").GetValue(agentInformation);
                return (TestAgentStatus)status;
            }
        }
        public ITestController TestController { get; private set; }
    }
}