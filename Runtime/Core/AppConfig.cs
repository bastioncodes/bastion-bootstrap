﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace SebastianFeistl.Winky.Core
{
    [CreateAssetMenu(fileName = "New AppConfig", menuName = "Winky/Configurations/App Config")]
    public class AppConfig : ScriptableObject
    {
        private const string ResourcePath = "Configs/AppConfig";
        
        [Header("Initial Scene Name")]
        [SerializeField] private string sceneName;
        
        public string SceneName => sceneName;

        public static AppConfig Load()
        {
            var config = Resources.Load<AppConfig>(ResourcePath);

            if (config == null)
            {
                throw new NullReferenceException($"{nameof(AppConfig)} could not be located at path \"{ResourcePath}\".");
            }

            return config;
        }
    }
}