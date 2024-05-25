using Bastion.Logging;
using UnityEngine;

namespace Bastion.Boot
{
    public class AppBeforeSceneLoad : MonoBehaviour
    {
#if UNITY_EDITOR
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void InitializeLoadingScene()
        {
            LogConfig.Initialize();
        }
#endif
    }
}
