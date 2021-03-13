using NUnit.Framework;
using System;
using System.IO;
using ContactsApp;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ProjectManagerTest
    {
        private static string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\TestContactsApp";
        private static string filePath = directoryPath + "Test.json";

        [TestCase(TestName = "Позитивный тест сохранениия в файл и загрузки из файла")]
        public void SaveToFile_LoadFromFile_CorrectValue()
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
            ProjectManager.SaveToFile(contacts, directoryPath, filePath);

            //Testing: Вызов тестируемого метода
            var actual = new Project();
            actual = ProjectManager.LoadFromFile(filePath);
            var actualSurname = actual.Сontacts[0].Surname;
            var actualName = actual.Сontacts[0].Name;
            var actualNumber = actual.Сontacts[0].PhoneNumber;
            var actualBirthday = actual.Сontacts[0].BirthDate;
            var actualEmail = actual.Сontacts[0].Email;
            var actualIdVK = actual.Сontacts[0].VkID;

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
