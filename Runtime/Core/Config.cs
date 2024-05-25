using Bastion.Logging;
using UnityEngine;

namespace Bastion.Core
{
    public abstract class Config : ScriptableObject
    {
        protected void LogMissingInspectorAssignment(string nameOfField)
        {
            BastionLogger.LogWarning($"The field \"{nameOfField}\" is missing. Please assign it in the inspector.");
        }
    }
}