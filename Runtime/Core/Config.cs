using System;
using Bastion.Logging;
using UnityEngine;

namespace Bastion.Core
{
    public abstract class Config : ScriptableObject
    {
        protected static T Load<T>(string path = null) where T : Config
        {
            var type = typeof(T);
            path ??= type.Name;
            var config = Resources.Load<T>(path);

            if (config != null)
                return config;
            
            throw new NullReferenceException($"\"{type.FullName}\" could not be located at path \"{path}\".");
        }
        
        protected static void LogMissingInspectorAssignment(string nameOfField)
        {
            BastionLogger.LogWarning($"The field \"{nameOfField}\" is missing. Please assign it in the inspector.");
        }
    }
}