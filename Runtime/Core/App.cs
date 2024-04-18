using UnityEngine;
using Reflex.Attributes;
using Bastion.Compliance;
using Bastion.Storage;

namespace Bastion.Core
{
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