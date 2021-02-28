using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class PhoneNumber
    {
        private string _numberPhone;

        public string NumberPhone
        {
            get { return _numberPhone;}

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

                _numberPhone = value;
            }
        }

        public PhoneNumber(string numberPhone)
        {
            NumberPhone = numberPhone;
        }
    }
}
