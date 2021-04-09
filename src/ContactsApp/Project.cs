using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsApp
{
    /// <summary>
    /// Contacts list
    /// Stores current user data
    /// </summary>
    public class Project : IEquatable<Project>
    {
        /// <summary>
        /// Contacts list.
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
        /// Метод выполняет сортировку списка контактов по фамилии
        /// </summary>
        /// <param name="contacts">Список контактов</param>
        /// <returns></returns>
        public Project SortProject(Project contacts)
        {
            Project sortedContacts = new Project();
            var result = contacts.Contacts.OrderBy(contact => contact.Surname);
            foreach (var contact in result)
            {
                sortedContacts.Contacts.Add(contact);
            }

            return sortedContacts;
        }

        /// <summary>
        /// Метод выполняет сортировку списка контактов по подстроке, сортировка по фамилии и по имени.
        /// </summary>
        /// <param name="substring">Подстрока для сортировки</param>
        /// <param name="contacts">Список контактов</param>
        /// <returns></returns>
        public Project SortProject(string substring, Project project)
        {
            var sortedContacts = new Project();
            var result = from contact in project.Contacts
                         where contact.Surname.Contains(substring) || contact.Name.Contains(substring)
                         orderby contact.Surname, contact.Name
                         select contact;
            foreach (var contact in result)
            {
                sortedContacts.Contacts.Add(contact);
            }

            return sortedContacts;

        }

        /// <summary>
        /// Cписок именинников
        /// </summary>
        /// <param name="birthdayList"></param>
        /// <returns></returns>
        public List<Contact> CreateBirthdayList(List<Contact> birthdayList)
        {
            var today = DateTime.Today;
            List<Contact> birthdayContacts = new List<Contact>();
            foreach (var contact in birthdayList)
            {
                if (contact.BirthDate.Day == today.Day &&
                    contact.BirthDate.Month == today.Month)
                {
                    birthdayContacts.Add(contact);
                }
            }

            return birthdayContacts;

        }
        public bool Equals(Project other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.Contacts.Count == other.Contacts.Count)
            {
                for (int i = 0; i < this.Contacts.Count; i++)
                {
                    if (!this.Contacts[i].Equals(other.Contacts[i]))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Project)obj);
        }

        public override int GetHashCode()
        {
            return (Contacts != null ? Contacts.GetHashCode() : 0);
        }
    }
}
