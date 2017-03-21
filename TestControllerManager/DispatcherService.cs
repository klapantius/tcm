using System;
using System.Windows.Threading;

namespace TestControllerManager
{
    public class DispatcherService : IDispatcherService
    {
        private readonly Dispatcher dispatcher;

        public DispatcherService(Dispatcher currentDispatcher)
        {
            dispatcher = currentDispatcher;
        }

        public void Invoke(Action action)
        {
            dispatcher.Invoke(action, DispatcherPriority.Normal);
        }

        public DispatcherOperation InvokeAsync(Action action)
        {
            return dispatcher.InvokeAsync(action, DispatcherPriority.Normal);
        }

        public DispatcherOperation<T> InvokeAsync<T>(Func<T> action)
        {
            return dispatcher.InvokeAsync(action, DispatcherPriority.Normal);
        }
    }
}