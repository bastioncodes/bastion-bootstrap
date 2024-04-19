using Reflex.Extensions;
using Reflex.Injectors;
using UnityEngine;

namespace Bastion.Core.Extensions
{
    public static class MonoBehaviourExtensions
    {
        /// <summary>
        /// Instantiate a <see cref="GameObject"/> and automatically resolve dependencies recursively.
        /// </summary>
        public static object InstantiateInjected<T>(this MonoBehaviour monoBehaviour, GameObject original)
        {
            var container = monoBehaviour.gameObject.scene.GetSceneContainer();
            var instance = Object.Instantiate(original);
            GameObjectInjector.InjectRecursive(instance, container);

            return instance;
        }
    }
}