using Bastion.Logging;
using Reflex.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bastion.Boot
{
    public class AppLoader : MonoBehaviour
    {
#if UNITY_EDITOR
        /// <summary>
        /// Load the boot scene before loading any other scene.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void InitializeLoadingScene()
        {
            BastionLogger.LogInfo("Loading scene ...");
            
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            var scene = SceneManager.LoadScene(sceneIndex, new LoadSceneParameters(LoadSceneMode.Single));
            ReflexSceneManager.PreInstallScene(scene, builder =>
            {
                // Scene loaded
            });
        }
#endif
    }
}
