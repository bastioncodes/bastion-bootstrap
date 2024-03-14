using Reflex.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SebastianFeistl.Winky.Core
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
            return;
            var config = AppConfig.Load();
            
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            var scene = SceneManager.LoadScene(sceneIndex, new LoadSceneParameters(LoadSceneMode.Single));
            ReflexSceneManager.PreInstallScene(scene, builder => builder.AddSingleton("Beautiful"));
        }
#endif
    }
}
