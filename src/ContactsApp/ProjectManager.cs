using System;
using System.IO;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Saves the file and extracts the contact list from the file.
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Directory path.
        /// </summary>
        public static string DefaultDirectoryPath
        {
            get
            {
                var directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) 
                                    + @"\ContactsApp";
                return directoryPath;
            }
        }

        /// <summary>
        /// File path.
        /// </summary>
        public static string DefaultFilePath
        {
            get
            {
                var filePath = @"\ContactsApp.json";
                return filePath;
            }
        }

        /// <summary>
        /// The serialization method involves checking for the existence of a path and file,
        /// and creates a folder and file as needed.
        /// </summary>
        /// <param name="contacts">Contact list.</param>
        public static void SaveToFile(Project contacts,string directorPath, string filePath)
        {
            JsonSerializer serializer = new JsonSerializer();

            if (!Directory.Exists(directorPath))
            {
                Directory.CreateDirectory(directorPath);
            }

            using (StreamWriter sw = new StreamWriter(directorPath + filePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            { 
                serializer.Serialize(writer, contacts);
                sw.Close();
            }
        }

        /// <summary>
        /// The deserialization method includes checking for the existence of a file.
        /// </summary>
        /// <returns name="project">Contact list</returns>
        public static Project LoadFromFile(string directorPath, string filePath)
        {
            if (!File.Exists(directorPath + filePath))
            {
                return new Project();
            }

            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader(directorPath + filePath))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                var project = serializer.Deserialize<Project>(reader);
                if (project == null)
                {
                    return new Project();
                }
                return project;
            }
        }
    }
}
