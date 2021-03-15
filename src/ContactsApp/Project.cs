using System.Collections.Generic;

namespace ContactsApp
{
    /// <summary>
    /// Список контактов
    /// Хранит текушие данные пользователя
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список контактов.
        /// </summary>
        public List<Contact> Сontacts { get; set; } = new List<Contact>();
    }
}
