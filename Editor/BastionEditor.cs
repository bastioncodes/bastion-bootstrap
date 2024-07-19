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
        [MenuItem("Bastion/Storage/Open Root Path Location %#&p")]
        public static void RevealRootPathInFinder()
        {
            EditorUtility.RevealInFinder(new FileManager().RootPath);
        }
    }   
}