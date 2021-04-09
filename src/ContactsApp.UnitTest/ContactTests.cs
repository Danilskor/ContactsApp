using System;
using NUnit.Framework;

//Dot net fraimwork
namespace ContactsApp.UnitTest
{
    [TestFixture]
    public class ContactTests
    {
        [Test(Description = "Позитивный тест геттера Surname")]
        public void Surname_GetCorrectValue_ValueGetCorrectly()
        {
            //Setup
            var expected = "Смирнов";
            var contact = new Contact();
            contact.Surname = expected;

            //Act
            var actual = contact.Surname;

            //Assert
            Assert.AreEqual(expected, actual, "Геттер Surname возвращает неправильную фамилию");
        }

        [TestCase("", TestName = "Присвоение пустой строки в качестве фамилии")]
        [TestCase("Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов",
             TestName = "Присвоение неправильной фамилии больше 50 символов")]
        public void Surname_SetUncorrectValue_ThrowsException(string wrongSurname)
        {
            //Setup
            var contact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            { 
                contact.Surname = wrongSurname; 
            });
        }

        [Test(Description = "Позитивный тест геттера Name")]
        public void Name_GetCorrectValue_ValueGetCorrectly()
        {
            //Setup
            var expected = "Андрей";
            var contact = new Contact();

            //Act
            contact.Name = expected;
            var actual = contact.Name;

            //Assert
            Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильную фамилию");
        }

        [TestCase("", TestName = "Присвоение пустой строки в качестве имени")]
        [TestCase("Андрей_Андрей_Андрей_Андрей_Андрей_Андрей_Андрей_Андрей",
            TestName = "Присвоение неправильного имя больше 50 символов")]
        public void Name_SetUncorrectValue_ThrowsException(string wrongName)
        {
            //Setup
            var contact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(() => 
            { 
                contact.Name = wrongName; 
            });
        }

        [Test(Description = "Позитивный тест геттера BirthDate")]
        public void BirthDate_GetCorrectValue_ValueGetCorrectly()
        {
            //Setup
            DateTime expected = DateTime.Now;
            var contact = new Contact();

            //Act
            contact.BirthDate = expected;
            var actual = contact.BirthDate;

            //Assert
            Assert.AreEqual(expected, actual, "Геттер BirthDate возвращает неправильную дату");
        }

        [TestCase(("1000-01-01"), TestName = "Присвоение неправильной даты 01.01.1000 меньшей, чем 01.01.1900")]
        [TestCase(("9999-12-30"), TestName = "Присвоение неправильной даты 30.12.9999 большей, чем сегодняшний день")]
        public void BirthDate_SetUncorrectValue_ThrowsException(DateTime wrongBirthDate)
        {
            //Setup
            var contact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(() => 
            { 
                contact.BirthDate = wrongBirthDate;
            });
        }

        [Test(Description = "Позитивный тест геттера Email")]
        public void Email_GetCorrectValue_ValueGetCorrectly()
        {
            //Setup
            var expected = "test@mail.ru";
            var contact = new Contact();

            //Act
            contact.Email = expected;
            var actual = contact.Email;

            //Assert
            Assert.AreEqual(expected, actual, "Геттер Email возвращает неправильную фамилию");
        }

        [TestCase("", TestName = "Присвоение пустой строки в качестве e-mail'a")]
        [TestCase("wrongTestWrongTestWrongTestWrongTestWrongTest@imail.ru",
            TestName = "Присвоение неправильного e-mail'a больше 50 символов")]
        public void Email_SetUncorrectValue_ThrowsException(string wrongEmail)
        {
            //Setup
            var contact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(() => 
            { 
                contact.Email = wrongEmail; 
            });
        }

        [Test(Description = "Позитивный тест геттера VkID")]
        public void VkID_GetCorrectValue_ValueGetCorrectly()
        {
            //Setup
            var expected = "id123345678";
            var contact = new Contact();

            //Act
            contact.VkID = expected;
            var actual = contact.VkID;

            //Assert
            Assert.AreEqual(expected, actual, "Геттер VkID возвращает неправильную фамилию");
        }

        [TestCase("", TestName = "Присвоение пустой строки в качестве VkID")]
        [TestCase("id123345678123456", TestName = "Присвоение неправильного VkID больше 15 символов")]
        public void VkID_SetUncorrectValue_ThrowsException(string wrongVkID)
        {
            //Setup
            var contact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(() => 
            { 
                contact.VkID = wrongVkID; 
            });
        }

        [Test(Description = "Позитивный тест конструктора Contact")]
        public void Contact_Consctuctor_CorrectValue()
        {
            //SetUp
            var expectedSurname = "Рождественский";
            var expectedName = "Антон";
            var expectedBirthDate = new DateTime(2000, 09, 28);
            var expectedEmail = "test@mail.ru";
            var expectedVkID = "id150398633";
            var number = new PhoneNumber();
            number.Number = "79234543265";
            var expectedNumber = number;
            var expectedContact = new Contact(expectedSurname, expectedName,
                expectedBirthDate, expectedEmail, expectedVkID, expectedNumber);

            //Act
            var actualSurname = expectedContact.Surname;
            var actualName = expectedContact.Name;
            var actualBirthDate = expectedContact.BirthDate;
            var actualEmail = expectedContact.Email;
            var actualVkID = expectedContact.VkID;
            var actualNumber = expectedContact.PhoneNumber;
            var actualContact = new Contact(actualSurname, actualName,
                actualBirthDate, actualEmail, actualVkID, actualNumber);

            //Assert
            Assert.AreEqual(expectedContact, actualContact);
        }
    }
}