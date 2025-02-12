using UnityEngine;
using Reflex.Attributes;
using Bastion.Logging;
using Bastion.Storage;
using Color = Bastion.Theme.Color;

namespace Bastion
{
    /// <summary>
    /// The entry point of the application.
    /// </summary>
    [Log(nameof(AppSample), Color = Color.Amber)]
    public class AppSample : MonoBehaviour
    {
        [Inject] private readonly FileManager _fileManager;

        private void Start()
        {
            _fileManager.Initialize();
            
            BastionLogger.LogInfo("Started.");
        }

        private void OnApplicationQuit()
        {
            BastionLogger.LogInfo("Stopped.");
        }
    }
}