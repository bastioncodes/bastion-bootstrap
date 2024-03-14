using UnityEngine;
using Reflex.Attributes;
using SebastianFeistl.Winky.Compliance;
using SebastianFeistl.Winky.Storage;

namespace SebastianFeistl.Winky.Core
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