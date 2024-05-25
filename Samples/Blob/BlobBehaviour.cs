using Bastion.Storage;
using Reflex.Attributes;
using UnityEngine;

namespace Bastion.Samples.Blob
{
    // Example script to demonstrate how the "Blob" sample is used once it's installed
    public class BlobBehaviour : MonoBehaviour
    {
        [Inject] private readonly BlobFactory _blobFactory;
        [Inject] private readonly BlobRepository _blobs;
        [Inject] private readonly FileManager _fileManager;
        
        private void Start()
        {
            // Generate random blobs
            for (var i = 0; i < 100; i++)
            {
                var blob = _blobFactory.CreateRandom();
                _blobs.Add(i, blob);
            }

            // Store the list of blobs as save data
            var json = _blobs.ToJson(); 
            _fileManager.SaveFile("blobs.json", json);
        }
    }
}