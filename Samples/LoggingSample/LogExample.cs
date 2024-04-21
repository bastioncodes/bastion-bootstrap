using Bastion.Logging;
using UnityEngine;

namespace Bastion.Samples
{
    public class LogExample : MonoBehaviour, ILoggable
    {
        public string LogName => "My Custom Logger";
        public string LogColor => LoggableColor.Gray;

        private void Start()
        {
            this.Log("Hello World");
            this.LogInfo("Hello World");
            this.LogSuccess("Hello World");
            this.LogWarning("Hello World");
            this.LogError("Hello World");
        }
    }
}