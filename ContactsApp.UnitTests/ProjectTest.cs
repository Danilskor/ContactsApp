using NUnit.Framework;
using System;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ProjectTest
    {
        [TestCase(TestName = "Позитивный тест геттера Project")]
        public void Project__Set_CorrectValue()
        {
            //Setup: Подготовка объекта к тестированию
            var contacts = new Project();
            var expectedSurname = "Фамилия";
            var expectedName = "Имя";
            var expectedBirthday = new DateTime(2000, 09, 28);
            var expectedEmail = "trumail@mail.com";
            var expectedVkID = "id12345678";
            var number = new PhoneNumber();
            number.Number = "71234567890";
            var expectedNumber = number;
            var contact = new Contact(expectedSurname, expectedName,
                expectedBirthday, expectedEmail, expectedVkID, expectedNumber);
            contacts.Сontacts.Add(contact);

            //Testing: Вызов тестируемого метода
            var actualSurname = contacts.Сontacts[0].Surname;
            var actualName = contacts.Сontacts[0].Name;
            var actualNumber = contacts.Сontacts[0].PhoneNumber;
            var actualBirthday = contacts.Сontacts[0].BirthDate;
            var actualEmail = contacts.Сontacts[0].Email;
            var actualIdVK = contacts.Сontacts[0].VkID;

            //Assert : Сравнение результата
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedSurname, actualSurname, "Фамилии не совпали");
                Assert.AreEqual(expectedName, actualName, "Имена не совпали");
                Assert.AreEqual(expectedBirthday, actualBirthday, "Даты рождения не совпали");
                Assert.AreEqual(expectedEmail, actualEmail, "Имейлы не совпали");
                Assert.AreEqual(expectedVkID, actualIdVK, "vkID не совпали");
                Assert.AreEqual(expectedNumber.Number, actualNumber.Number, "Номера не совпали");
            });
        }
    }
}