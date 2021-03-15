using System;

namespace ContactsApp
{
    /// <summary>
    /// Телефонный номер
    /// </summary>
    public class PhoneNumber: IEquatable<PhoneNumber>
    {
        /// <summary>
        /// Номер телефона.
        /// </summary>
        private string _phoneNumber;

        public PhoneNumber() {}

        /// <summary>
        /// Свойства номера телефона, с исключениями на валидность значений.
        /// </summary>
        public string Number
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                foreach (var var in value)
                {
                    if (!char.IsDigit(var))
                    {
                        throw new ArgumentException("Строка должна содержать только цифры");
                    }
                }

                if (value.Length != 11)
                {
                    throw new ArgumentException("Номер должен состоять из 11 цифр");
                }

                var abc = value[0];
                if (value[0] != '7')
                {
                    throw new ArgumentException("Код страны должен быть 7");
                }

                _phoneNumber = value;
            }
        }

        /// <summary>
        /// Конструктор класса номер телефона.
        /// </summary>
        /// <param name="numberPhone">Номер телефона.</param>
        public PhoneNumber(string phoneNumber)
        {
            Number = phoneNumber;
        }

        public bool Equals(PhoneNumber other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return _phoneNumber == other._phoneNumber;
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

            return Equals((PhoneNumber) obj);
        }

        public override int GetHashCode()
        {
            return (_phoneNumber != null ? _phoneNumber.GetHashCode() : 0);
        }
    }
}
