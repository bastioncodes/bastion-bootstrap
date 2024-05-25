using Bastion.Core;
using Reflex.Core;
using UnityEngine;

namespace Bastion.Samples.Blob
{
    public class BlobFactory : Factory<BlobData>
    {
        public BlobFactory(Container container) : base(container)
        {
            //
        }

        public BlobData CreateRandom()
        {
            return CreateWithInjection(() => new BlobData(), blob =>
            {
                blob.size = Mathf.Round(Random.Range(1f, 10f) * 1000) / 1000;
                blob.location = new Vector2(Random.Range(-1000, 1000), Random.Range(-1000, 1000));
                blob.color = Color.red;
            });
        }
    }
}