using Bastion.Logging;
using UnityEngine;

namespace Bastion.Samples
{
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