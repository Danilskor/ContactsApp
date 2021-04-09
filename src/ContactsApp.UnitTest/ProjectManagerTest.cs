using System;
using NUnit.Framework;
using System.IO;
using System.Reflection;

namespace ContactsApp.UnitTest
{
    [TestFixture]
    public class ProjectManagerTest
    {
        /// <summary>
        /// Путь к катологу исполняемого файла
        /// </summary>
        private string location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// Путь на корректный папку для тестов
        /// </summary>
        private string CorrectDirectoryPath
        {
            get
            {
                return location + @"\TestData";
            }
        }

        /// <summary>
        ///Путь на поврежденный файл
        /// </summary>
        private string UncorrectDirectoryPath
        {
            get
            {
                return location + @"TestData\uncorrectcontactsdata.json";
            }
        }

        /// <summary>
        /// Путь на файл для теста сериализации
        /// </summary>
        private string OutputSaveFilename
        {
            get
            {
                return location + @"\Output";
            }
        }

        private Project CorrectProject
        {
            get
            {
                var project = new Project();
                var contact = new Contact(
                    "Фамилия",
                    "Имя",
                    new DateTime(1990, 01, 10),
                    "test@mail.ru",
                    "id1235456",
                    new PhoneNumber("79069771777"));
                project.Contacts.Add(contact);
                contact = new Contact(
                    "Фамилиядва",
                    "Имядва",
                    new DateTime(1990, 10, 10),
                    "test2@mail.ru",
                    "id12354562",
                    new PhoneNumber("79069771778"));
                project.Contacts.Add(contact);
                return project;
            }
        }

        [TestCase(TestName = "Positive test deserialize")]
        public void ProjectMamager_LoadCorrectionData_FileSavedCorrectly()
        {
            //SetUp
            var expectedProject = CorrectProject;

            //Testing
            var actualProject = ProjectManager.LoadFromFile(CorrectDirectoryPath, @"\correctprojectfile.json");

            //Assert
            Assert.AreEqual(expectedProject.Contacts.Count, actualProject.Contacts.Count);
            Assert.Multiple(() =>
            {
                for (int i = 0; i < expectedProject.Contacts.Count; i++)
                {
                    var expected = expectedProject.Contacts[i];
                    var actual = actualProject.Contacts[i];

                    Assert.AreEqual(expected, actual);
                }
            });
        }

        [TestCase(TestName = "Negative test deserialize, uncorrect file ")]
        public void ProjectManager_LoadUncorrectionData_ReturnsEmptyFile()
        {
            //SetUp
            var excpectedProject = new Project();

            //Testing
            var actualProject = ProjectManager.LoadFromFile(UncorrectDirectoryPath, @"\uncorrectsavefile.json");

            //Assert
            Assert.AreEqual(excpectedProject.Contacts.Count, actualProject.Contacts.Count);

        }

        [TestCase(TestName = "Negative test deserialize, non-existent file ")]
        public void ProjectManager_LoadNonExistFIle_ReturnsEmptyFile()
        {
            var expectedProject = new Project();

            var location = Assembly.GetExecutingAssembly().Location;
            var folder = Path.GetDirectoryName(location);

            //Testing
            var actualProject = ProjectManager.LoadFromFile($@"{folder}\TestData", @"\uncorrectsavefile.json");

            //Assert
            Assert.AreEqual(expectedProject.Contacts.Count, actualProject.Contacts.Count);

        }

        [TestCase(TestName = "Positive test serialize")]
        public void ProjectManager_SaveCorrectionData_FileLoadedCorrectly()
        {
            //SetUp
            var expectedProject = CorrectProject;

            //Testing
            ProjectManager.SaveToFile(expectedProject, OutputSaveFilename, @"\correctsavefile.json");

            //Assert
            var actual = File.ReadAllText(OutputSaveFilename + @"\correctsavefile.json");
            var expected = File.ReadAllText(CorrectDirectoryPath + @"\correctprojectfile.json");
            Assert.AreEqual(expected, actual);

        }
    }
}


