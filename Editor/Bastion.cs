using UnityEditor;
using System.IO;
using Bastion.Storage;
using UnityEngine;

namespace Bastion.Editor
{
    /**
     * Experimental boilerplate code generator.
     * This should become the one-click-installer for the framework.
     */
    public static class BoilerplateGenerator
    {
        [MenuItem("Bastion/Configuration/Publish App File")]
        public static void GenerateAppBoilerplate()
        {
            string templatePath = "Packages/codes.bastion/Samples/Boilerplate/App.cs";
            string targetPath = "Assets/Scripts/App.cs";

            // Ensure the target directory exists
            string targetDir = Path.GetDirectoryName(targetPath);
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            // Copy the file
            if (File.Exists(templatePath))
            {
                File.Copy(templatePath, targetPath, true);
                
                // Copy scripts
                // TODO: Copy AppInstaller.cs to scripts folder
                // TODO: Copy App.cs to scripts folder
                
                // Copy prefabs
                // TODO: Copy ProjectScope (or AppScope) to resource folder
                
                // Add files to scene
                // TODO: Add SceneScope GameObject to scene 
                // TODO: Add App GameObject in initial scene
                AssetDatabase.Refresh();
                Debug.Log("Installed Bastion successfully.");
            }
            else
            {
                Debug.LogError($"Template file not found at {templatePath}");
            }
        }

        [MenuItem("Bastion/Storage/Open Root Path Location %#&p")]
        public static void RevealRootPathInFinder()
        {
            EditorUtility.RevealInFinder(new FileManager().RootPath);
        }
    }   
}