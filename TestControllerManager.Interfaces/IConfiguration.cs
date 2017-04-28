using System;


namespace TestControllerManager
{
    public interface IConfiguration
    {
        Uri TpcUri { get; }
        string TeamProject { get; }
        string Favourites { get; }
        bool AgentMonitoringEnabled { get; }
        int Port { get; }
        string DomainSuffix { get; }

        void Save();
    }
}