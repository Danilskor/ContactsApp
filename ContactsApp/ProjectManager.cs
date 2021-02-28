using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private static readonly string DirectoryPath = System.Environment.GetFolderPath(
                                                           System.Environment.SpecialFolder.ApplicationData)
                                                       + @"\ContactsApp";
        /// <summary>
        /// Полное имя файла.
        /// </summary>
        private static readonly string FilePath = DirectoryPath + @"\ContactsApp.json";

        /// <summary>
        /// Метод сериализации включает проверку существования пути и файла
        /// при необходимости создает папку и файл.
        /// </summary>
        /// <param name="contacts">Список контактов.</param>
        public static void SaveToFile(Project contacts)
        {
            JsonSerializer serializer = new JsonSerializer();

            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            if (!File.Exists((FilePath)))
            {
                File.Create(FilePath);
            }

            using (StreamWriter sw = new StreamWriter(FilePath))
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

            if (File.Exists(FilePath))
            {
                JsonSerializer serializer = new JsonSerializer();

                using (StreamReader sr = new StreamReader(FilePath))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    contacts = (Project) serializer.Deserialize<Project>(reader);
                }
            }

            return contacts;
        }
    }
}
