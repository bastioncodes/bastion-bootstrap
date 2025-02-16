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
        /// Starts and initializes the manager.
        /// Do not override this method. Instead, override <see cref="Start"/>.
        /// </summary>
        /// <param name="onComplete">Callback invoked when initialization is successfully completed.</param>
        /// <param name="onError">Callback invoked if an initialization error occurs.</param>
        public virtual void Awake(Action onComplete = null, Action<Exception> onError = null)
        {
            Start(() =>
            {
                ManagerInitialized?.Invoke(GetType());
                onComplete?.Invoke();
            }, onError);
        }
        
        /// <summary>
        /// Initializes the manager, with optional completion and error handling callbacks.
        /// </summary>
        /// <param name="onComplete">Callback invoked when initialization is successfully completed.</param>
        /// <param name="onError">Callback invoked if an initialization error occurs.</param>
        protected abstract void Start(Action onComplete = null, Action<Exception> onError = null);
        
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            //
        }
    }
}
