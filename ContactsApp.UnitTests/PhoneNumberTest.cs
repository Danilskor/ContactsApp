using NUnit.Framework;
using System;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class PhoneNumberTest
    {
        [TestCase("12safd3", "Должно возникать исключение, если в номере будут не цифры",
            TestName = "Присвоение неправильной строки номера телефона с буквами")]
        [TestCase("712345678901", "Должно возникать исключение, если телефон длиннее 11 цифр",
            TestName = "Присвоение неправильной строки номера телефона более 11 цифр")]
        [TestCase("12345678901", "Должно возникать исключение, если в номере первая цифра не 7 ",
            TestName = "Присвоение неправильной строки номера телефона, первая цифра не 7")]
        public void Test_PhoneNumber_Set_ArgumentException(string wrongPhoneNumber, string message)
        {
            //Setup: Подготовка объекта к тестированию
            var phoneNumber = new PhoneNumber();

            //Assert : Сравнение результата
            Assert.Throws<ArgumentException>(
                () => { phoneNumber.Number = wrongPhoneNumber; },
                message);
        }

        [TestCase(TestName = "Позитивный тест конструктора Contact")]
        public void PhoneNumber_Set_CorrectValue()
        {
            //Setup: Подготовка объекта к тестированию
            var number = new PhoneNumber();
            var expected = "79236078890";
            number.Number = expected;

            //Testing: Вызов тестируемого метода
            var actual = number.Number;

            //Assert : Сравнение результата
            Assert.AreEqual(expected, actual, "Номера не совпали");
        }
    }
}
