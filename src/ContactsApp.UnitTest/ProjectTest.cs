using System;
using NUnit.Framework;

namespace ContactsApp.UnitTest
{
    [TestFixture]
    public class ProjectTest
    {
        [TestCase(TestName = "Позитивный тест геттера Project")]
        public void Project__Set_CorrectValue()
        {
            //Setup:
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
            project.Contacts.Add(contact);

            //Assert:
            Assert.NotNull(project.Contacts);
        }
    }
}