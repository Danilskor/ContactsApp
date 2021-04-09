using System;

namespace ContactsApp
{
    /// <summary>
    /// Phone number
    /// </summary>
    public class PhoneNumber: IEquatable<PhoneNumber>
    {
        /// <summary>
        /// Phone number.
        /// </summary>
        private string _phoneNumber;

        public PhoneNumber() {}

        /// <summary>
        /// Phone number properties.
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
                        throw new ArgumentException("The string must contain only numbers");
                    }
                }

                if (value.Length != 11)
                {
                    throw new ArgumentException("The number must be 11 digits");
                }

                var abc = value[0];
                if (value[0] != '7')
                {
                    throw new ArgumentException("Country code must be 7");
                }

                _phoneNumber = value;
            }
        }

        /// <summary>
        /// Phone number constructor.
        /// </summary>
        /// <param name="numberPhone">Phone number.</param>
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
