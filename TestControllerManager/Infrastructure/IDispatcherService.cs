using System;
using System.Windows.Threading;


namespace TestControllerManager
{
    /// <summary>
    /// Interface of dispatcher service
    /// </summary>
    public interface IDispatcherService
    {
        /// <summary>
        /// Invokes action via dispatcher
        /// </summary>
        /// <param name="action">Action to be invoked</param>
        void Invoke(Action action);

        /// <summary>
        /// Invokes action asynchronously via dispatcher  
        /// </summary>
        /// <param name="action">Action to be invoked</param>
        /// <returns>Operation ticket</returns>
        DispatcherOperation InvokeAsync(Action action);

        /// <summary>
        /// Invokes action asynchronously via dispatcher  
        /// </summary>
        /// <param name="action">Action to be invoked</param>
        /// <returns>Operation ticket</returns>
        DispatcherOperation<T> InvokeAsync<T>(Func<T> action);
    }
}