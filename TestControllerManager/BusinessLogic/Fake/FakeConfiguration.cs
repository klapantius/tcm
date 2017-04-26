using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestControllerManager.BusinessLogic
{
    class FakeConfiguration : IConfiguration
    {
        private IConfiguration myDefault = new DefaultConfiguration();

        public Uri TpcUri { get { return myDefault.TpcUri; } }
        public string TeamProject { get; private set; }
        public string Favourites { get; private set; }
        public bool AgentMonitoringEnabled { get; private set; }
        public int Port { get; private set; }
        public string DomainSuffix { get; private set; }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
