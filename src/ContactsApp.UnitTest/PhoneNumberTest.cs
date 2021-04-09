using System;
using NUnit.Framework;

namespace ContactsApp.UnitTest
{
    [TestFixture]
    class PhoneNumberTest
    {
        [TestCase("12safd3", TestName = "Assigning the wrong string to a phone number with letters")]
        [TestCase("712345678901", TestName = "Assigning an invalid phone number string with more than 11 digits")]
        [TestCase("12345678901", TestName = "Assigning a string with an not 7 first digit as a phone number")]
        public void Test_PhoneNumber_Set_ArgumentException(string wrongPhoneNumber)
        {
            //Setup:
            var phoneNumber = new PhoneNumber();

            //Assert
            Assert.Throws<ArgumentException>(() => 
            { 
                phoneNumber.Number = wrongPhoneNumber; 
            });
        }

        [TestCase(TestName = "Позитивный тест конструктора Contact")]
        public void PhoneNumber_SetCorrectValue_PhoneNumberSetCorrectly ()
        {
            //Setup
            var expected = new PhoneNumber();
            expected.Number = "79236078890";

            //Act
            var actual = "79236078890";

            //Assert
            Assert.AreEqual(expected.Number, actual);
        }
    }
}
