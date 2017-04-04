namespace TestControllerManager.BusinessLogic
{
    internal class FakeTestControllerFactory : ITestControllerFactory
    {
        public ITestController CreateController(string hostName)
        {
            return new FakeTestController(hostName);
        }
    }
}
