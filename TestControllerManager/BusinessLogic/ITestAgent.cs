using System;
using System.Collections.Generic;


namespace TestControllerManager.BusinessLogic
{
    public enum TestAgentStatus
    {
        NotResponding,
        Offline,
        Ready,
        RunningTest,
        DeployingBuild
    };

    public interface ITestAgent
    {
        string Name { get; }
        IEnumerable<Tuple<string, string>> Attributes { get; }
        bool Online { get; }
        TestAgentStatus Status { get; }
        ITestController TestController { get; }
    }
}