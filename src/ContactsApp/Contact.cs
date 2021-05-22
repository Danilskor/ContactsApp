using System;

namespace ContactsApp
{
    /// <summary>
    /// Contact
    /// </summary>
    public class Contact : ICloneable, IEquatable<Contact>, IComparable
    {
        /// <summary>
        /// Surname
        /// </summary>
        private string _surname;

        /// <summary>
        /// Name
        /// </summary>
        private string _name;

        /// <summary>
        /// Birthday
        /// </summary>
        private DateTime _birthDate;

        /// <summary>
        /// Email
        /// </summary>
        private string _email;

        /// <summary>
        /// vk.com ID
        /// </summary>
        private string _vkID;

        /// <summary>
        /// Phone number properties.
        /// </summary>
        public PhoneNumber PhoneNumber { get; set;}

        /// <summary>
        /// Surname properties with valid assert
        /// The first character converts to uppercase, the rest to lowercase.
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                Validator.AssertStringOnLength(value, 50, "Surname");
                Validator.AssertStringOnNumbers(value, "Surname");
                value = Validator.ToNameFormat(value);
                _surname = value;
            }
        }

        /// <summary>
        /// Name properties with valid assert
        /// The first character converts to uppercase, the rest to lowercase.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Validator.AssertStringOnLength(value, 50, "Name");
                Validator.AssertStringOnNumbers(value, "Name");
                value = Validator.ToNameFormat(value);
                _name = value;
            }
        }

        /// <summary>
        /// Birthday properties with valid assert
        /// </summary>
        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                var minimalDate = new DateTime(1900, 01, 01);
                if (value < minimalDate || value.Date > DateTime.Now)
                {
                    throw new ArgumentException(
                        $"Birthday cannot be less then 01.01.1900 and "
                        +$"later than today.");
                }

                _birthDate = value;
            }
        }

        /// <summary>
        /// Email properties.
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                Validator.AssertStringOnLength(value, 50, "E-mail");
                _email = value;
            }
        }

        /// <summary>
        /// vk.com ID properties
        /// </summary>
        public string VkID
        {
            get
            {
                return _vkID;
            }
            set
            {
                Validator.AssertStringOnLength(value, 15, "ID Vk");
                _vkID = value;
            }
        }

        /// <summary>
        /// Contact constructor.
        /// </summary>
        /// <param name="surname"> Фамилия.</param>
        /// <param name="name"> Имя. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="email"> Е-mail. </param>
        /// <param name="vkID"> ID Вконтакте. </param>
        /// <param name="phoneNumber"> Телефонный номер. </param>
        public Contact(string surname, string name, DateTime birthDate, string email, string vkID,
            PhoneNumber phoneNumber)
        {
            Surname = surname;
            Name = name;
            BirthDate = birthDate;
            Email = email;
            VkID = vkID;
            PhoneNumber = new PhoneNumber(phoneNumber.Number);
        }

        /// <summary>
        /// Contact constructor.
        /// </summary>
        public Contact()
        {
            PhoneNumber = new PhoneNumber();
        }

        /// <summary>
        /// Clone Contact.
        /// </summary>
        /// <returns> Cloned contact. </returns>
        public object Clone()
        {
            return new Contact(Surname, Name, BirthDate, Email, VkID, PhoneNumber)
            {
                Surname = this.Surname,
                Name = this.Name,
                BirthDate = this.BirthDate,
                Email = this.Email,
                VkID = this.VkID,
                PhoneNumber = new PhoneNumber(this.PhoneNumber.Number)
            };
        }

        public bool Equals(Contact other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return _surname == other._surname && 
                   _name == other._name && 
                   _birthDate.Equals(other._birthDate) && 
                   _email == other._email && 
                   _vkID == other._vkID && 
                   PhoneNumber.Equals(other.PhoneNumber);
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

            return Equals((Contact)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_surname != null ? _surname.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _birthDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (_email != null ? _email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_vkID != null ? _vkID.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PhoneNumber != null ? PhoneNumber.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        public int CompareTo(object obj)
        {
            Contact comparableContact = (Contact)obj;
            return String.Compare(this.Surname, comparableContact.Surname);
        }
    }
}
