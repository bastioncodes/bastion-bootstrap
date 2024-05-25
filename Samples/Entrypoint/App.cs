using UnityEngine;
using Reflex.Attributes;
using Bastion.Compliance;
using Bastion.Storage;

namespace Bastion.Samples.Entrypoint
{
    /// <summary>
    /// The entry point of the application.
    /// </summary>
    public class App : MonoBehaviour
    {
        [Inject] private readonly LegalManager _legalManager;
        [Inject] private readonly FileManager _fileManager;

        private void Start()
        {
            _fileManager.Initialize();
            _legalManager.Initialize();
        }
    }
}