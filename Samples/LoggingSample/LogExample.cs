using Bastion.Logging;
using UnityEngine;
using Color = Bastion.Theme.Color;

namespace Bastion.Samples
{
    [Log(nameof(LogExample), Name = "Log Example")]
    public class LogExample : MonoBehaviour
    {
        private void Start()
        {
            BastionLogger.Log("Hello World");
            BastionLogger.LogInfo("Hello World");
            BastionLogger.LogSuccess("Hello World");
            BastionLogger.LogWarning("Hello World");
            BastionLogger.LogError("Hello World");
        }
    }
}