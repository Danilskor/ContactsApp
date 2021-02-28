using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class Project
    {
        public List<Contact> _contacts { get; set; } = new List<Contact>();

        public void AddElement (Contact newContact)
        {
            _contacts.Add(newContact);
        }
    }
}
