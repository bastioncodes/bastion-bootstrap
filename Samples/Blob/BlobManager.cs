using System;
using Bastion.Core;
using Bastion.Logging;
using Bastion.Theme;
using Reflex.Attributes;

namespace Bastion.Samples.Blob
{
    [Log(nameof(BlobManager), Color = Color.Amber)]
    public class BlobManager : Manager
    {
        [Inject] private readonly BlobRepository _blobs;
        [Inject] private readonly BlobFactory _factory;
        
        public override void Init(Action onComplete = null, Action<Exception> onError = null)
        {
            for (int i = 0; i < 10; i++)
            {
                var blob = _factory.CreateRandom();
                _blobs.Add(i, blob);
            }

            var randomBlob = _blobs.Random();
            randomBlob.SaveToFile("random_blob.json");

            var json = _blobs.Random().ToJson(true);
            BastionLogger.Log($"blob.json\n{json}");
            
            onComplete?.Invoke();
        }
    }
}