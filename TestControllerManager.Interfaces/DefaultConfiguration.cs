using System;


namespace TestControllerManager
{
    public class DefaultConfiguration : IConfiguration
    {
        public Uri TpcUri { get { return new Uri("https://tfs.healthcare.siemens.com:8090/tfs/ikm.tpc.projects"); } }
        public string TeamProject { get { return "syngo.net"; } }
        public string Favourites { get { return "FO9DE01T2230VD,FO9DE01T2209VD"; } }
        public bool AgentMonitoringEnabled { get { return true; } }
        public int Port { get { return 7789; } }
        public string DomainSuffix { get { return "ikm.med.siemens.de"; } }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}