namespace TestControllerManager.BusinessLogic
{
    public interface ITfsTeamProjectCollection
    {
        T GetService<T>();
    }
}
