using System;

namespace SebastianFeistl.Winky.Core
{
    public abstract class Manager : IDisposable
    {
        public bool IsInitialized { get; protected set; }
        public abstract void Initialize(Action onComplete = null, Action<Exception> onError = null);
        
        public virtual void Dispose()
        {
            //
        }
    }
}