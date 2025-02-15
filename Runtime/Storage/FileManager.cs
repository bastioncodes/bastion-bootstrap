using System;
using System.IO;
using Bastion.Core;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Bastion.Storage
{
    /// <summary>
    /// Handles writing and reading files from the disk.
    /// </summary>
    public class FileManager : Manager
    {
        private string _rootPath;

        /// <summary>
        /// The application root path where all persistent data files are located.
        /// </summary>
        public string RootPath => _rootPath ??= Application.persistentDataPath + Path.DirectorySeparatorChar;

        public override void Initialize(Action onComplete = null, Action<Exception> onError = null)
        {
            onComplete?.Invoke();
        }

        /// <summary>
        /// Save a file to the persistent data path.
        /// </summary>
        /// <param name="filename">The name and extension of the file.</param>
        /// <param name="content">The content of the file.</param>
        public void SaveFile(string filename, string content)
        {
            string path = Path.Combine(RootPath, filename);
            CreateDirectory(path);
            File.WriteAllText(path, content);
        }

        /// <summary>
        /// Save a file to the persistent data path.
        /// </summary>
        /// <param name="filename">The name and extension of the file.</param>
        /// <param name="content">The content of the file.</param>
        public void SaveFile(string filename, byte[] content)
        {
            string path = Path.Combine(RootPath, filename);
            CreateDirectory(path);
            File.WriteAllBytes(path, content);
        }

        /// <summary>
        /// Save a file to the persistent data path in the specified sub-directories.
        /// </summary>
        /// <param name="directories">The names of the directories.</param>
        /// <param name="filename">The name and extension of the file.</param>
        /// <param name="bytes">The bytes of the file.</param>
        public void SaveFileInDirectory(string[] directories, string filename, byte[] bytes)
        {
            string directoryPath = CreateDirectoryPath(directories);
            SaveFile(Path.Combine(directoryPath, filename), bytes);
        }

        /// <summary>
        /// Build a path from sub-directories and create those directories if they do not exist yet.
        /// </summary>
        /// <param name="directories">The names of the directories.</param>
        /// <returns>The combined path.</returns>
        public string CreateDirectoryPath(string[] directories)
        {
            string directoryPath = "";

            // Build path and ensure directories exist
            for (int i = 0; i < directories.Length; i++)
            {
                directoryPath += directories[i] + Path.DirectorySeparatorChar;
                string fullDirectoryPath = Path.Combine(RootPath, directoryPath);

                // Create directory if it does not exist yet
                if (!Directory.Exists(fullDirectoryPath))
                    Directory.CreateDirectory(fullDirectoryPath);
            }

            return directoryPath;
        }

        /// <summary>
        /// Read the file from the persistent data path.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns>The file content.</returns>
        public string ReadFile(string filePath)
        {
            return File.ReadAllText(Path.Combine(RootPath, filePath));
        }

        /// <summary>
        /// Read the file from the persistent data path.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns>The file content in bytes.</returns>
        public byte[] ReadFileAllBytes(string filePath)
        {
            return File.ReadAllBytes(Path.Combine(RootPath, filePath));
        }
        
        /// <summary>
        /// Rename the file.
        /// </summary>
        /// <param name="filePath">Path of the file relative to the app root path.</param>
        /// <param name="newName">The new file name.</param>
        public void RenameFile(string filePath, string newName)
        {
            if (FileExists(filePath))
            {
                string newFilePath = Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar + newName;
                File.Move(Path.Combine(RootPath, filePath), Path.Combine(RootPath, newFilePath));
            }
        }

        /// <summary>
        /// Delete the file.
        /// </summary>
        /// <param name="filePath">Path of the file relative to the app root path.</param>
        public void DeleteFile(string filePath)
        {
            if (FileExists(filePath))
            {
                File.Delete(Path.Combine(RootPath, filePath));
            }
        }

        /// <summary>
        /// Create subdirectories included in the file path.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        private static void CreateDirectory(string path)
        {
            string directoryPath = Path.GetDirectoryName(path);

            if (directoryPath != null && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        /// <summary>
        /// Remove the directory with all containing files and subdirectories.
        /// </summary>
        /// <param name="directoryPath">Path of the directory relative to the app root path.</param>
        public void DeleteDirectory(string directoryPath)
        {
            if (DirectoryExists(directoryPath))
            {
                DeleteDirectory(Path.Combine(RootPath, directoryPath), true);
            }
        }

        private void DeleteDirectory(string targetDirectory, bool recursive)
        {
            string[] files = Directory.GetFiles(targetDirectory);
            string[] dirs = Directory.GetDirectories(targetDirectory);

            if (recursive)
            {
                foreach (string file in files)
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }

                foreach (string dir in dirs)
                {
                    DeleteDirectory(dir, true);
                }
            }

            Directory.Delete(targetDirectory, false);
        }

        /// <summary>
        /// Removes all files and subdirectories contained inside directoryPath, does not delete directoryPath itself.
        /// </summary>
        /// <param name="directoryPath">Path of the directory relative to the app root path.</param>
        public void DeleteDirectoryContents(string directoryPath)
        {
            if (DirectoryExists(directoryPath))
            {
                DirectoryInfo di = new DirectoryInfo(Path.Combine(RootPath, directoryPath));

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
        }

        /// <summary>
        /// Read a texture file from the persistent data path.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="createMipMaps">If true, mip maps are generated for the texture.</param>
        /// <returns>The texture.</returns>
        public Texture2D ReadTextureFile(string path, bool createMipMaps = true)
        {
            byte[] data = File.ReadAllBytes(Path.Combine(RootPath, path));

            var flags = createMipMaps ? TextureCreationFlags.MipChain : TextureCreationFlags.None;

            Texture2D texture = new(1, 1, DefaultFormat.LDR, flags: flags)
            {
                name = Path.GetFileNameWithoutExtension(path)
            };

            texture.LoadImage(data);

            return texture;
        }

        /// <summary>
        /// Evaluate if a file exists at the specified path.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <returns>True, if the file exists.</returns>
        public bool FileExists(string path)
        {
            return File.Exists(Path.Combine(RootPath, path));
        }

        /// <summary>
        /// Evaluate if the directory exists at the specified path.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <returns>True, if the directory exists.</returns>
        public bool DirectoryExists(string path)
        {
            return Directory.Exists(Path.Combine(RootPath, path));
        }
    }
}