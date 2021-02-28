using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Список контактов
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список контактов.
        /// </summary>
        public List<Contact> _contacts { get; set; } = new List<Contact>();

        /// <summary>
        /// Добавляет новый контакт в список контактов.
        /// </summary>
        /// <param name="newContact">Новый контакт.</param>
        public void AddElement (Contact newContact)
        {
            _contacts.Add(newContact);
        }
    }
}
