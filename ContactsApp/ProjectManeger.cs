using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContactsApp
{
    public static class ProjectManeger
    {
        private static string FilePath = System.Environment.SpecialFolder.ApplicationData.ToString() +
                                         @"\ContactsApp\ContactsApp.json";

        public static void SaveToFile(List<Contact> contacts)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(FilePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            { 
                serializer.Serialize(writer, contacts);
            }
        }

        public static Contact LoadFromFile()
        {
            
            Contact contact = null;
            
            JsonSerializer serializer = new JsonSerializer();
            
            using (StreamReader sr = new StreamReader(FilePath))
            using (JsonReader reader = new JsonTextReader(sr))
            { 
                contact = (Contact)serializer.Deserialize<Contact>(reader);
            }

            return contact;
        }
    }
}
