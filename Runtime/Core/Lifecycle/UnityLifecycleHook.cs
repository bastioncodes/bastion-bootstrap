using System.Collections.Generic;
using Bastion.Logging;
using Bastion.Theme;

namespace Bastion.Core.Lifecycle
{
    public interface IUpdate { void Update(); }
    public interface IFixedUpdate { void FixedUpdate(); }
    public interface ILateUpdate { void LateUpdate(); }
    
    [Log(nameof(UnityLifecycleHook), Color = Color.Sky)]
    public class UnityLifecycleHook : Singleton<UnityLifecycleHook>
    {
        private readonly HashSet<IUpdate> _updateListeners = new();
        private readonly HashSet<IFixedUpdate> _fixedUpdateListeners = new();
        private readonly HashSet<ILateUpdate> _lateUpdateListeners = new();

        private void Update()
        {
            foreach (var listener in _updateListeners)
                listener.Update();
        }

        private void FixedUpdate()
        {
            foreach (var listener in _fixedUpdateListeners)
                listener.FixedUpdate();
        }

        private void LateUpdate()
        {
            foreach (var listener in _lateUpdateListeners)
                listener.LateUpdate();
        }

        public void Register(object listener, bool hasUpdate = false, bool hasFixedUpdate = false, bool hasLateUpdate = false)
        {
            var typeName = LogUtility.Colorize(listener.GetType().Name, Color.Blue);
            BastionLogger.Log($"{typeName} is now listening to Unity events.");
            
            if (hasUpdate && listener is IUpdate u)
                _updateListeners.Add(u);

            if (hasFixedUpdate && listener is IFixedUpdate fu)
                _fixedUpdateListeners.Add(fu);

            if (hasLateUpdate && listener is ILateUpdate lu)
                _lateUpdateListeners.Add(lu);
        }

        public void Unregister(object listener)
        {
            var typeName = LogUtility.Colorize(listener.GetType().Name, Color.Blue);
            BastionLogger.Log($"{typeName} is no longer listening to Unity events.");
            
            if (listener is IUpdate u)
            {
                _updateListeners.Remove(u);
            }

            if (listener is IFixedUpdate fu)
            {
                _fixedUpdateListeners.Remove(fu);
            }

            if (listener is ILateUpdate lu)
            {
                _lateUpdateListeners.Remove(lu);
            }
        }
    }
}