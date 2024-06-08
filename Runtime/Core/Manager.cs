using System;

namespace Bastion.Core
{
    /// <summary>
    /// Provides a base class for managing application resources and operations, 
    /// allowing for explicit control over initialization and disposal processes.
    /// </summary>
    public abstract class Manager : IDisposable
    {
        public static event Action<Type> ManagerInitialized;
        
        /// <summary>
        /// Initializes the manager, with optional completion and error handling callbacks.
        /// </summary>
        /// <param name="onComplete">Callback invoked when initialization is successfully completed.</param>
        /// <param name="onError">Callback invoked if an initialization error occurs.</param>
        public abstract void Initialize(Action onComplete = null, Action<Exception> onError = null);
        
        /// <summary>
        /// Notifies subscribers about the completion of the manager's initialization.
        /// This method should be called during the initialization to trigger global notifications.
        /// </summary>
        /// <param name="onComplete">The appropriate Action of the <see cref="Initialize"/> method.</param>
        protected void NotifyCompleted(Action onComplete)
        {
            ManagerInitialized?.Invoke(GetType());
            onComplete?.Invoke();
        }
        
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            //
        }
    }
}
