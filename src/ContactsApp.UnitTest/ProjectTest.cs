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
            var project = new Project();
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
            project.Сontacts.Add(contact);

            //Act: Вызов тестируемого метода
            var actualSurname = project.Сontacts[0].Surname;
            var actualName = project.Сontacts[0].Name;
            var actualNumber = project.Сontacts[0].PhoneNumber;
            var actualBirthday = project.Сontacts[0].BirthDate;
            var actualEmail = project.Сontacts[0].Email;
            var actualIdVK = project.Сontacts[0].VkID;

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