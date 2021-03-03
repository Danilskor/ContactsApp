using System;

namespace ContactsApp
{
    /// <summary>
    /// Контакт
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        private string _surname;

        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Дата рождения
        /// </summary>
        private DateTime _birthDate;

        /// <summary>
        /// Email
        /// </summary>
        private string _email;

        /// <summary>
        /// ID Вконтакте
        /// </summary>
        private string _vkID;

        /// <summary>
        /// Свойство номера телефона.
        /// </summary>
        public PhoneNumber PhoneNumber { get; set;}

        /// <summary>
        /// Свойства фамилли с проверкой на валидность данных
        /// Первый символ преобразует в верхний регистр, остальные в нижний.
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                Validator.AssertStringOnLength(value, 50, "Фамилия");
                Validator.ToNameFormat(value);
                _surname = value;
            }
        }

        /// <summary>
        /// Свойство имени с проверкой на валидность данных
        /// Первый символ преобразует в верхний регистр, остальные в нижний.
        /// </summary>

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Validator.AssertStringOnLength(value, 50, "Имя");
                Validator.ToNameFormat(value);
                _name = value;
            }
        }

        /// <summary>
        /// Свойства даты рождения с проверкой на валидность данных
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
                if (value < minimalDate || value > DateTime.Now)
                {
                    throw new ArgumentException(
                        $"Дата рождения не может быть меньше 01.01.1900 и"
                        +$"позже сегодняшнего дня.");
                }

                _birthDate = value;
            }
        }

        /// <summary>
        /// Свойства Email'a.
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
        /// Свойства ID Вконтакте
        /// </summary>
        public string VkID
        {
            get
            {
                return _vkID;
            }
            set
            {
                Validator.AssertStringOnLength(value, 15, "ID Вконтакте");
                VkID = value;
            }
        }

        /// <summary>
        /// Конструктор класса Contact.
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
        /// Метод кланирования объекта Contact.
        /// </summary>
        /// <returns> Склонированный контакт. </returns>
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
    }
}
