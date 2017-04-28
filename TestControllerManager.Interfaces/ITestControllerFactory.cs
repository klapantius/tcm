namespace TestControllerManager.BusinessLogic
{
    public interface ITestControllerFactory
    {
        ITestController CreateController(string hostName);
    }
}
