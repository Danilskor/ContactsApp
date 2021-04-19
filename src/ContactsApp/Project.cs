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
        public static List<Contact> SortContactsList(List<Contact> contacts)
        {
            var sortedContacts = new List<Contact>();
            sortedContacts = contacts;
            sortedContacts.Sort();
            return sortedContacts;
        }

        /// <summary>
        /// Поиск фамилии или имени по подстроке
        /// </summary>
        /// <param name="substring">Подстрока для поиска</param>
        /// <param name="contacts">Список контактов</param>
        /// <returns></returns>
        public static List<Contact> Find(string substring, List<Contact> contacts)
        {
            var findContacts = new List<Contact>();

            substring = substring.ToLower();
            string lowerSubstring = substring;
            if (substring.Length >= 1)
            {
                substring = char.ToUpper(substring[0]) + substring.Substring(1);
            }

            foreach (var contact in contacts)
            {
                if (contact.Surname.Contains(substring) || 
                    contact.Name.Contains(substring) ||
                    contact.Name.Contains(lowerSubstring) ||
                    contact.Name.Contains(lowerSubstring)
                    )
                {
                    findContacts.Add(contact);
                }
            };

            return findContacts;
        }

        /// <summary>
        /// Cписок именинников
        /// </summary>
        public string GetListBirthday()
        {
            var listContacts = Contacts.Where(contact =>
                contact.BirthDate.Day == DateTime.Now.Day &&
                contact.BirthDate.Month == DateTime.Now.Month);

            return string.Join(",", 
                listContacts.Select(contact => contact.Surname).ToList());
        }

        
        public List<Contact> CreateBirthdayList(List<Contact> birthdayList)
        {
            var today = DateTime.Today;
            List<Contact> birthdayContactsList = new List<Contact>();
            foreach (var contact in birthdayList)
            {
                if (contact.BirthDate.Day == today.Day &&
                    contact.BirthDate.Month == today.Month)
                {
                    birthdayContactsList.Add(contact);
                }
            }

            return birthdayContactsList;
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
