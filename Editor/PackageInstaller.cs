using System;
using System.IO;
using System.Threading.Tasks;
using Bastion.Boot;
using Bastion.Logging;
using Reflex.Core;
using UnityEditor;
using UnityEngine;
using Color = Bastion.Theme.Color;

namespace Bastion.Editor
{
    [Log(nameof(PackageInstaller), Color = Color.Blue)]
    public static class PackageInstaller
    {
        private const string SourcePath = "Packages/com.bastion.codes.bootstrap/Samples/Entrypoint/AppSample.cs";
        private const string TargetPath = "Assets/Scripts/App.cs";
        
        private const string InstallerSourcePath = "Packages/com.bastion.codes.bootstrap/Samples/Entrypoint/AppInstallerSample.cs";
        private const string InstallerTargetPath = "Assets/Scripts/AppInstaller.cs";
        
        private const string AppConfigTargetPath = "Assets/Resources/AppConfig.asset";
        private const string SceneScopeName = "SceneScope";

        private static GameObject _app;

        [MenuItem("Bastion/Install Package")]
        public static async void Install()
        {
            BastionLogger.LogInfo("Installing Bastion ...");
            
            CreateDirectoryIfNeeded(TargetPath);
            
            // Create entry point file: App.cs
            await CopyFileToTargetAsync(SourcePath, TargetPath);
            
            // Create main installer: AppInstaller.cs
            await CopyFileToTargetAsync(InstallerSourcePath, InstallerTargetPath);
            
            AssetDatabase.Refresh();
            
            CreateAppConfig();
            
            BastionLogger.LogSuccess("Installed Bastion successfully. Create the app in the scene to get started.");
        }
        
        [MenuItem("GameObject/Bastion/Install App in Scene", false, 0)]
        public static void CreateApp()
        {
            // Create app game object
            _app = GameObject.Find("App");
            if (_app != null)
            {
                BastionLogger.LogWarning("App already exists.");
                return;
            }
            
            _app = new GameObject("App");
            AddComponentByTypeName(_app, "Bastion.App");
            BastionLogger.Log("New \"App\" created in scene.");

            // Inject SceneScope game object into current scene
            var sceneScope = CreateSceneScopeIfNeeded();
            AddComponentByTypeName(sceneScope, "Bastion.AppInstaller");
            
            BastionLogger.Log("\"AppInstaller\" has been attached to \"SceneScope\".");
            BastionLogger.LogSuccess("Setup completed!");
            BastionLogger.LogInfo("\"App\" is the entry point where all modules are initialized. Install your global dependencies in \"AppInstaller\" to get started. Good luck!");
        }

        private static void CreateDirectoryIfNeeded(string filePath)
        {
            var targetDir = Path.GetDirectoryName(filePath);
            if (Directory.Exists(targetDir)) return;

            if (targetDir != null)
            {
                Directory.CreateDirectory(targetDir);
                BastionLogger.Log($"New directory created at \"{targetDir}\"");
            }
        }
        
        private static async Task CopyFileToTargetAsync(string sourcePath, string targetPath)
        {
            if (!File.Exists(sourcePath))
            {
                BastionLogger.LogError($"Source file does not exist at \"{sourcePath}\" ");
                return;
            }
            
            var sourceClassName = Path.GetFileNameWithoutExtension(sourcePath);
            var targetClassName = Path.GetFileNameWithoutExtension(targetPath);
            
            var text = await File.ReadAllTextAsync(sourcePath);
            text = text.Replace(sourceClassName, targetClassName);
            await File.WriteAllTextAsync(targetPath, text);
        
            BastionLogger.Log($"New file created at \"{targetPath}\"");
        }

        private static GameObject CreateSceneScopeIfNeeded()
        {
            var go = GameObject.Find(SceneScopeName);

            if (go != null)
            {
                BastionLogger.LogWarning("SceneScope already exists.");
                return go;
            }

            go = new GameObject(SceneScopeName);
            go.AddComponent<SceneScope>();

            BastionLogger.Log("New \"SceneScope\" created in scene.");

            return go;
        }

        private static void CreateAppConfig()
        {
            var appConfig = ScriptableObject.CreateInstance<AppConfig>();
            CreateDirectoryIfNeeded(AppConfigTargetPath);
            AssetDatabase.CreateAsset(appConfig, AppConfigTargetPath);
            AssetDatabase.SaveAssets();
            
            BastionLogger.Log($"New configuration created at \"{AppConfigTargetPath}\"");
        }
        
        private static void AddComponentByTypeName(GameObject gameObject, string typeName)
        {
            if (gameObject == null)
            {
                BastionLogger.LogError("GameObject is null.");
                return;
            }

            var type = GetTypeFromAllAssemblies(typeName);
            if (type != null && type.IsSubclassOf(typeof(Component)))
                gameObject.AddComponent(type);
            else
                BastionLogger.LogError("Failed to find type: " + typeName);
        }

        private static Type GetTypeFromAllAssemblies(string typeName)
        {
            for (var index = 0; index < AppDomain.CurrentDomain.GetAssemblies().Length; index++)
            {
                var assembly = AppDomain.CurrentDomain.GetAssemblies()[index];
                var type = assembly.GetType(typeName);
                if (type != null)
                    return type;
            }

            return null;
        }
    }
}