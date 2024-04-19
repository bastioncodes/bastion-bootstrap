using System;

namespace Bastion.Core
{
    public abstract class Manager : IDisposable
    {
        public abstract void Initialize(Action onComplete = null, Action<Exception> onError = null);
        
        public virtual void Dispose()
        {
            //
        }
    }
}