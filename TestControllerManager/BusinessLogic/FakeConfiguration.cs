using System;

namespace TestControllerManager.BusinessLogic
{
    public class FakeConfiguration: DefaultConfiguration, IConfiguration
    {
        public new string Favourites { get { return "TC01,TC02,TC03"; } }
        public new void Save()
        {
            // do nothing
        }
    }
}
