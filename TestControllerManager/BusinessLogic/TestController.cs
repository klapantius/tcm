using System.Collections.Generic;
using System.Linq;


namespace TestControllerManager.BusinessLogic
{
    public class TestController : ITestController
    {
        private object TestControllerObject { get; set; }

        public TestController(object controllerObject)
        {
            TestControllerObject = controllerObject;
        }

        public IEnumerable<ITestAgent> Agents
        {
            get
            {
                return ((IEnumerable<object>) TestControllerObject.GetType().GetMethod("GetAllAgents").Invoke(TestControllerObject, null))
                    .Select(agent => new TestAgent(agent, this));
            }
        }

        public void SetOnline(ITestAgent agent, bool online)
        {
            TestControllerObject.GetType().GetMethod("SetAgentOperationalState").Invoke(TestControllerObject, new object[] { agent.Name, online });
        }
    }
}