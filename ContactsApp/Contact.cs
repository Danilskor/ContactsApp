using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class Contact : ICloneable
    {
        private string _surname;

        private string _name;

        private DateTime _birthDate;

        private string _email;

        private string _vkID;

        private PhoneNumber phoneNumber;
        public string Surname
        {
            get { return _surname; }

            set
            {
                ContactValidator(value);
                value.ToLower();
                value = char.ToUpper(value[0]) + value.Substring(1);
                _surname = value;
            }
        }

        public string Name
        {
            get { return _name;}

            set
            {
                ContactValidator(value);
                value.ToLower();
                value = char.ToUpper(value[0]) + value.Substring(1);
                _name = value;
            }
        }

        public DateTime BirthDate
        {
            get { return _birthDate;}

            set
            {
                var minimalDate = new DateTime(1900, 01, 01);
                if (value < minimalDate || value > DateTime.Now)
                {
                    throw new ArgumentException(
                        $"Дата рождения не может быть меньше 01.01.1900 и"
                        +$"позже сегодняшнего дня.");
                }

                _birthDate = value;
            }
        }

        public string Email
        {
            get { return _email;}

            set
            {
                ContactValidator(value);
                _email = value;
            }
        }

        public string VkID
        {
            get { return _vkID;}

            set
            {
                VkIDValidator(value);
                _vkID = value;
            }
        }

        public static void ContactValidator(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Ничего не введено.");
            }

            if (text.Length > 50)
            {
                throw new ArgumentException("Длина фамилии, имени и e-mail должно быть не более 50 символов.");
            }
        }

        public static void VkIDValidator(string vkID)
        {
            if (vkID.Length > 50)
            {
                throw new ArgumentException("Длина ID Вконтакте должно быть не более 15 символов.");
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
