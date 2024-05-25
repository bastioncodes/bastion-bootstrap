using System;
using System.Runtime.Serialization;
using Bastion.Core;
using UnityEngine;

namespace Bastion.Samples.Blob
{
    [Serializable]
    public class BlobData : Data
    {
        [DataMember(Name = "size")]
        public float size;

        [DataMember(Name = "location")]
        public Vector2 location;

        [DataMember(Name = "color")]
        public Color color;
    }
}