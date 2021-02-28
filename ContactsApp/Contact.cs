using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Номер телефона
        /// </summary>
        private PhoneNumber _numberPhone;

        /// <summary>
        /// Конструктор класса Contact.
        /// </summary>
        /// <param name="surname"> Фамилия.</param>
        /// <param name="name"> Имя. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="email"> Е-mail. </param>
        /// <param name="vkID"> ID Вконтакте. </param>
        /// <param name="numberPhone"> Телефонный номер. </param>
        public Contact(string surname, string name, DateTime birthDate, string email, string vkID, string numberPhone)
        {
            Surname = surname;
            Name = name;
            BirthDate = birthDate;
            Email = email;
            VkID = vkID;
            NumberPhone = new PhoneNumber(numberPhone);
        }

        /// <summary>
        /// Свойства номера телефона.
        /// </summary>
        public PhoneNumber NumberPhone { get; set;}

        /// <summary>
        /// Свойства фамилли с проверкой на валидность данных
        /// Первый символ преобразует в верхний регистр, остальные в нижний.
        /// </summary>
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

        /// <summary>
        /// Свойства имени с проверкой на валидность данных
        /// Первый символ преобразует в верхний регистр, остальные в нижний.
        /// </summary>

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

        /// <summary>
        /// Свойства даты рождения с проверкой на валидность данных
        /// </summary>
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

        /// <summary>
        /// Свойства Email'a.
        /// </summary>
        public string Email
        {
            get { return _email;}

            set
            {
                ContactValidator(value);
                _email = value;
            }
        }

        /// <summary>
        /// Свойства ID Вконтакте
        /// </summary>
        public string VkID
        {
            get { return _vkID; }

            set
            {
                VkIDValidator(value);
                _vkID = value;
            }
        }

        /// <summary>
        /// Валидатор для фамилии, имени и E-mail'a
        /// Проверяет на наличие введенного текста, а так же
        /// на длину, которая должна быть не более 50 символов.
        /// </summary>
        /// <param name="text">Входной текст.</param>
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

        /// <summary>
        /// Валидатор для ID Вконтакте
        /// Проверят длину строки (не более 15 символов)
        /// </summary>
        /// <param name="vkID"> ID Вконтакте.</param>
        public static void VkIDValidator(string vkID)
        {
            if (vkID.Length > 15)
            {
                throw new ArgumentException("Длина ID Вконтакте должно быть не более 15 символов.");
            }
        }

        /// <summary>
        /// Метод кланирования объекта Contact.
        /// </summary>
        /// <returns> Склонированный контакт. </returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
