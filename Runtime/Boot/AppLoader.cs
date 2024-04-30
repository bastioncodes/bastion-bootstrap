using Bastion.Core;
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
        public static void InitLoadingScene()
        {
            // TODO: Preload initial boot scene here
            return;
            var config = AppConfig.Load();
            
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            var scene = SceneManager.LoadScene(sceneIndex, new LoadSceneParameters(LoadSceneMode.Single));
            ReflexSceneManager.PreInstallScene(scene, builder => builder.AddSingleton("Beautiful"));
        }
#endif
    }
}
