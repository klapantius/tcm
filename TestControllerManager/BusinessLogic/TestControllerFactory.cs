using System;
using System.Linq;
using System.Reflection;


namespace TestControllerManager.BusinessLogic
{
    public class TestControllerFactory : ITestControllerFactory
    {
        public ITestController CreateController(string hostName)
        {
            var controllerObject = ConnectMethodInfo.Invoke(null, new object[] { hostName });
            return new TestController(controllerObject);
        }

        private static Type myControllerConnectionManager;

        private static Type ControllerConnectionManager
        {
            get
            {
                if (myControllerConnectionManager == null)
                {
                    var assembly = typeof(Microsoft.VisualStudio.TestTools.Controller.ConfigReaderHelper).Assembly;
                    myControllerConnectionManager = assembly.GetType("Microsoft.VisualStudio.TestTools.Controller.ControllerConnectionManager");
                }
                return myControllerConnectionManager;
            }
        }

        private static MethodInfo myConnectMethodInfo;

        private static MethodInfo ConnectMethodInfo
        {
            get
            {
                if (myConnectMethodInfo == null)
                {
                    myConnectMethodInfo = ControllerConnectionManager.GetMethods(BindingFlags.Public | BindingFlags.Static)
                        .FirstOrDefault(foo => 
                            foo.Name == "Connect" && foo.GetParameters().Count() == 1 && foo.GetParameters()[0].Name == "fullControllerName");
                }
                return myConnectMethodInfo;
            }
        }
    }
}