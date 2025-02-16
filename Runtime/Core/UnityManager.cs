using System;
using Bastion.Core.Lifecycle;

namespace Bastion.Core
{
    public abstract class UnityManager : Manager, IUpdate, IFixedUpdate, ILateUpdate
    {
        public override void Awake(Action onComplete = null, Action<Exception> onError = null)
        {
            // Only register the lifecycle methods that the derived class overrides
            UnityLifecycleHook.Instance.Register(this, 
                hasUpdate: GetType().GetMethod(nameof(Update))?.DeclaringType != typeof(UnityManager),
                hasFixedUpdate: GetType().GetMethod(nameof(FixedUpdate))?.DeclaringType != typeof(UnityManager),
                hasLateUpdate: GetType().GetMethod(nameof(LateUpdate))?.DeclaringType != typeof(UnityManager)
            );
            
            base.Awake(onComplete, onError);
        }
        
        public override void Dispose()
        {
            UnityLifecycleHook.Instance.Unregister(this);
        }

        public virtual void Update()
        {
            //
        }

        public virtual void FixedUpdate()
        {
            //
        }

        public virtual void LateUpdate()
        {
            //
        }
    }
}