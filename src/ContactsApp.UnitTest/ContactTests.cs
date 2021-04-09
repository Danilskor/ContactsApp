using System;
using NUnit.Framework;

//Dot net fraimwork
namespace ContactsApp.UnitTest
{
    [TestFixture]
    public class ContactTests
    {
        [Test(Description = "���������� ���� ������� Surname")]
        public void Surname_GetCorrectValue_ValueGetCorrectly()
        {
            //Setup
            var expected = "�������";
            var contact = new Contact();
            contact.Surname = expected;

            //Act
            var actual = contact.Surname;

            //Assert
            Assert.AreEqual(expected, actual, "������ Surname ���������� ������������ �������");
        }

        [TestCase("", TestName = "���������� ������ ������ � �������� �������")]
        [TestCase("�������-�������-�������-�������-�������-�������-�������",
             TestName = "���������� ������������ ������� ������ 50 ��������")]
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

        [Test(Description = "���������� ���� ������� Name")]
        public void Name_GetCorrectValue_ValueGetCorrectly()
        {
            //Setup
            var expected = "������";
            var contact = new Contact();

            //Act
            contact.Name = expected;
            var actual = contact.Name;

            //Assert
            Assert.AreEqual(expected, actual, "������ Name ���������� ������������ �������");
        }

        [TestCase("", TestName = "���������� ������ ������ � �������� �����")]
        [TestCase("������_������_������_������_������_������_������_������",
            TestName = "���������� ������������� ��� ������ 50 ��������")]
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

        [Test(Description = "���������� ���� ������� BirthDate")]
        public void BirthDate_GetCorrectValue_ValueGetCorrectly()
        {
            //Setup
            DateTime expected = DateTime.Now;
            var contact = new Contact();

            //Act
            contact.BirthDate = expected;
            var actual = contact.BirthDate;

            //Assert
            Assert.AreEqual(expected, actual, "������ BirthDate ���������� ������������ ����");
        }

        [TestCase(("1000-01-01"), TestName = "���������� ������������ ���� 01.01.1000 �������, ��� 01.01.1900")]
        [TestCase(("9999-12-30"), TestName = "���������� ������������ ���� 30.12.9999 �������, ��� ����������� ����")]
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

        [Test(Description = "���������� ���� ������� Email")]
        public void Email_GetCorrectValue_ValueGetCorrectly()
        {
            //Setup
            var expected = "test@mail.ru";
            var contact = new Contact();

            //Act
            contact.Email = expected;
            var actual = contact.Email;

            //Assert
            Assert.AreEqual(expected, actual, "������ Email ���������� ������������ �������");
        }

        [TestCase("", TestName = "���������� ������ ������ � �������� e-mail'a")]
        [TestCase("wrongTestWrongTestWrongTestWrongTestWrongTest@imail.ru",
            TestName = "���������� ������������� e-mail'a ������ 50 ��������")]
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

        [Test(Description = "���������� ���� ������� VkID")]
        public void VkID_GetCorrectValue_ValueGetCorrectly()
        {
            //Setup
            var expected = "id123345678";
            var contact = new Contact();

            //Act
            contact.VkID = expected;
            var actual = contact.VkID;

            //Assert
            Assert.AreEqual(expected, actual, "������ VkID ���������� ������������ �������");
        }

        [TestCase("", TestName = "���������� ������ ������ � �������� VkID")]
        [TestCase("id123345678123456", TestName = "���������� ������������� VkID ������ 15 ��������")]
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

        [Test(Description = "���������� ���� ������������ Contact")]
        public void Contact_Consctuctor_CorrectValue()
        {
            //SetUp
            var expectedSurname = "��������������";
            var expectedName = "�����";
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