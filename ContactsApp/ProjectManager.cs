using System;
using System.IO;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Сохраняет файл и извлекает из файла список контактов.
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Путь к файлу.
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
        /// Полное имя файла.
        /// </summary>
        public static string DefaultFilePath
        {
            get
            {
                var filePath = DefaultDirectoryPath + @"\ContactsApp.json";
                return filePath;
            }
        }

        /// <summary>
        /// Метод сериализации включает проверку существования пути и файла
        /// при необходимости создает папку и файл.
        /// </summary>
        /// <param name="contacts">Список контактов.</param>
        public static void SaveToFile(Project contacts,string directoruPath, string filePath)
        {
            JsonSerializer serializer = new JsonSerializer();

            if (!Directory.Exists(directoruPath))
            {
                Directory.CreateDirectory(directoruPath);
            }

            if (!File.Exists((filePath)))
            {
                File.Create(filePath);
            }

            using (StreamWriter sw = new StreamWriter(filePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            { 
                serializer.Serialize(writer, contacts);
            }
        }

        /// <summary>
        /// Метод десериализации, включает проверку на существование файла.
        /// </summary>
        /// <returns name="contacts">Список контактов</returns>
        public static Project LoadFromFile()
        {
            
            Project contacts = null;

            if (!File.Exists(DefaultFilePath))
            {
                return new Project();
            }

            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader(DefaultFilePath))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                contacts = (Project) serializer.Deserialize<Project>(reader);
            }

            return contacts;
        }
    }
}
