using NUnit.Framework;
using System;
using System.IO;
using ContactsApp;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ProjectManagerTest
    {
        //[TestCase(Description = "Позитивный тест геттера Project manajer", TestName = "Создание файла project")]
        //public void ProjectManagerMakeCorrectProject()
        //{
        //    var project = new Project();
        //    var contact = new Contact(
        //        "Фамилия",
        //        "Имя",
        //        new DateTime(1990, 01, 10),
        //        "test@mail.ru",
        //        "id1235456",
        //        new PhoneNumber("79069771777"));
        //    project.Сontacts.Add(contact);
        //    contact = new Contact(
        //        "Фамилиядва",
        //        "Имядва",
        //        new DateTime(1990, 10, 10),
        //        "test2@mail.ru",
        //        "id12354562",
        //        new PhoneNumber("79069771778"));
        //    project.Сontacts.Add(contact);

        //    ProjectManager.SaveToFile(project, @"TestData", @"TestData\correctprojectfile.json");
        //}

        [TestCase(Description = "Правильная загрузка Project manajer'a",
            TestName = "Тест на правильную загрузку Project manajer")]
        public void ProjectManagerCorrectLoadProject()
        {
            //Setup
            var expectedProject = new Project();
            var contact = new Contact(
                "Фамилия",
                "Имя",
                new DateTime(1990, 01, 10),
                "test@mail.ru",
                "id1235456",
                new PhoneNumber("79069771777"));
            expectedProject.Сontacts.Add(contact);
            contact = new Contact(
                "Фамилиядва",
                "Имядва",
                new DateTime(1990, 10, 10),
                "test2@mail.ru",
                "id12354562",
                new PhoneNumber("79069771778"));
            expectedProject.Сontacts.Add(contact);

            //Act
            var actualProject = ProjectManager.LoadFromFile(@"TestData\correctprojectfile.json");

            //Assert
            Assert.AreEqual(expectedProject.Сontacts.Count, actualProject.Сontacts.Count);

            Assert.Multiple(() =>
            {
                for (int i = 0; i < expectedProject.Сontacts.Count; i++)
                {
                    var expected = expectedProject.Сontacts[i];
                    var actual = actualProject.Сontacts[i];

                    Assert.AreEqual(expected.Surname, actual.Surname);
                    Assert.AreEqual(expected.Name, actual.Name);
                    Assert.AreEqual(expected.Name, actual.Name);
                    Assert.AreEqual(expected.BirthDate, actual.BirthDate);
                    Assert.AreEqual(expected.PhoneNumber.Number, actual.PhoneNumber.Number);
                    Assert.AreEqual(expected.Email, actual.Email);
                }
            });

        }
    }
}


