using NUnit.Framework;
using System;

//Dot net fraimwork
//Через библиотеку классов
namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTests
    {
        [Test(Description = "Позитивный тест геттера Surname")]
        public void Test_Surname_Get_CorrectValue()
        {
            var expected = "Смирнов";
            var contact = new Contact();
            contact.Surname = expected;
            var actual = contact.Surname;
            Assert.AreEqual(expected, actual, "Геттер Surname возвращает неправильную фамилию");
        }

        [TestCase("", "Должно возникать исключение, если фамилия - пустая строка",
            TestName = "Присвоение пустой строки в качестве фамилии")]
        [TestCase("Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов",
            "Должно возникать исключение, если фамилия длиннее 50 символов",
            TestName = "Присвоение неправильной фамилии больше 50 символов")]
        public void Test_Surname_Set_ArgumentException(string wrongSurname, string message)
        {
            var contact = new Contact();
            Assert.Throws<ArgumentException>(
                () => { contact.Surname = wrongSurname; },
                message);
        }

        [Test(Description = "Позитивный тест геттера Name")]
        public void Test_Name_Get_CorrectValue()
        {
            var expected = "Андрей";
            var contact = new Contact();
            contact.Name = expected;
            var actual = contact.Name;
            Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильную фамилию");
        }

        [TestCase("", "Должно возникать исключение, если имя - пустая строка",
            TestName = "Присвоение пустой строки в качестве имени")]
        [TestCase("Андрей_Андрей_Андрей_Андрей_Андрей_Андрей_Андрей_Андрей",
            "Должно возникать исключение, если имя длиннее 50 символов",
            TestName = "Присвоение неправильного имя больше 50 символов")]
        public void Test_Name_Set_ArgumentException(string wrongName, string message)
        {
            var contact = new Contact();
            Assert.Throws<ArgumentException>(
                () => { contact.Name = wrongName; },
                message);
        }

        [Test(Description = "Позитивный тест геттера BirthDate")]
        public void Test_BirthDate_Get_CorrectValue()
        {
            DateTime expected = DateTime.Now;
            var contact = new Contact();
            contact.BirthDate = expected;
            var actual = contact.BirthDate;
            Assert.AreEqual(expected, actual, "Геттер BirthDate возвращает неправильную дату");
        }

        [TestCase(("1000-01-01"), "Должно возникать исключение, если дата рождения меньше 1900 года",
            TestName = "Присвоение неправильной даты 01.01.1000 меньшей, чем 01.01.1900")]
        [TestCase(("9999-12-30"), "Должно возникать исключение, если дата рождения больше сегодняшнего дня",
            TestName = "Присвоение неправильной даты 30.12.9999 большей, чем сегодняшний день")]
        public void Test_BirthDate_Set_ArgumentException(DateTime wrongBirthDate, string message)
        {
            var contact = new Contact();
            Assert.Throws<ArgumentException>(
                () => { contact.BirthDate = wrongBirthDate; },
                message);
        }

        [Test(Description = "Позитивный тест геттера Email")]
        public void Test_Email_Get_CorrectValue()
        {
            var expected = "test@mail.ru";
            var contact = new Contact();
            contact.Email = expected;
            var actual = contact.Email;
            Assert.AreEqual(expected, actual, "Геттер Email возвращает неправильную фамилию");
        }

        [TestCase("", "Должно возникать исключение, если Email - пустая строка",
            TestName = "Присвоение пустой строки в качестве e-mail'a")]
        [TestCase("wrongTestWrongTestWrongTestWrongTestWrongTest@imail.ru",
            "Должно возникать исключение, если e-mail длиннее 50 символов",
            TestName = "Присвоение неправильного e-mail'a больше 50 символов")]
        public void Test_Email_Set_ArgumentException(string wrongEmail, string message)
        {
            var contact = new Contact();
            Assert.Throws<ArgumentException>(
                () => { contact.Email = wrongEmail; },
                message);
        }

        [Test(Description = "Позитивный тест геттера VkID")]
        public void Test_VkID_Get_CorrectValue()
        {
            var expected = "id123345678";
            var contact = new Contact();
            contact.VkID = expected;
            var actual = contact.VkID;
            Assert.AreEqual(expected, actual, "Геттер VkID возвращает неправильную фамилию");
        }

        [TestCase("", "Должно возникать исключение, если VkID - пустая строка",
            TestName = "Присвоение пустой строки в качестве VkID")]
        [TestCase("id123345678123456", "Должно возникать исключение, если VkID длиннее 50 символов",
            TestName = "Присвоение неправильного VkID больше 15 символов")]
        public void Test_VkID_Set_ArgumentException(string wrongVkID, string message)
        {
            var contact = new Contact();
            Assert.Throws<ArgumentException>(
                () => { contact.VkID = wrongVkID; },
                message);
        }

        [Test(Description = "Позитивный тест конструктора Contact")]
        public void Contact_Consctuctor_CorrectValue()
        {
            var expectedSurname = "Рождественский";
            var expectedName = "Антон";
            var expectedBirthDate = new DateTime(2000, 09, 28);
            var expectedEmail = "test@mail.ru";
            var expectedVkID = "id150398633";
            var number = new PhoneNumber();
            number.Number = "79234543265";
            var expectedNumber = number;
            var contact = new Contact(expectedSurname, expectedName,
                expectedBirthDate, expectedEmail, expectedVkID, expectedNumber);

            var actualSurname = contact.Surname;
            var actualName = contact.Name;
            var actualBirthDate = contact.BirthDate;
            var actualEmail = contact.Email;
            var actualIdVK = contact.VkID;
            var actualNumber = contact.PhoneNumber;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedSurname, actualSurname, "Фамилии не совпали");
                Assert.AreEqual(expectedName, actualName, "Имена не совпали");
                Assert.AreEqual(expectedBirthDate, actualBirthDate, "Даты рождения не совпали");
                Assert.AreEqual(expectedEmail, actualEmail, "Имейлы не совпали");
                Assert.AreEqual(expectedVkID, actualIdVK, "vkID не совпали");
                Assert.AreEqual(expectedNumber.Number, actualNumber.Number, "Номера не совпали");
            });

        }
    }
}