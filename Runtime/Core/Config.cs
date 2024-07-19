using System;
using Bastion.Logging;
using UnityEngine;

namespace Bastion.Core
{
    public abstract class Config : ScriptableObject
    {
        private const string DefaultPath = "";
        
        protected static T Load<T>(string path = null) where T : Config
        {
            var type = typeof(T);
            path ??= DefaultPath + type.Name;
            var config = Resources.Load<T>(path);

            if (config == null)
                throw new NullReferenceException($"{type.FullName} could not be located at path \"{path}\".");

            return config;
        }
        
        protected static void LogMissingInspectorAssignment(string nameOfField)
        {
            BastionLogger.LogWarning($"The field \"{nameOfField}\" is missing. Please assign it in the inspector.");
        }
    }
}