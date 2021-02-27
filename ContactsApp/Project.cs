using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    class Project
    {
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public void AddElement (Contact newContact)
        {
            Contacts.Add(newContact);
        }
    }
}
