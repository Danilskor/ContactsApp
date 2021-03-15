using NUnit.Framework;
using System;

//Dot net fraimwork
//����� ���������� �������
namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTests
    {
        [Test(Description = "���������� ���� ������� Surname")]
        public void Test_Surname_Get_CorrectValue()
        {
            var expected = "�������";
            var contact = new Contact();
            contact.Surname = expected;
            var actual = contact.Surname;
            Assert.AreEqual(expected, actual, "������ Surname ���������� ������������ �������");
        }

        [TestCase("", "������ ��������� ����������, ���� ������� - ������ ������",
            TestName = "���������� ������ ������ � �������� �������")]
        [TestCase("�������-�������-�������-�������-�������-�������-�������",
            "������ ��������� ����������, ���� ������� ������� 50 ��������",
            TestName = "���������� ������������ ������� ������ 50 ��������")]
        public void Test_Surname_Set_ArgumentException(string wrongSurname, string message)
        {
            var contact = new Contact();
            Assert.Throws<ArgumentException>(
                () => { contact.Surname = wrongSurname; },
                message);
        }

        [Test(Description = "���������� ���� ������� Name")]
        public void Test_Name_Get_CorrectValue()
        {
            var expected = "������";
            var contact = new Contact();
            contact.Name = expected;
            var actual = contact.Name;
            Assert.AreEqual(expected, actual, "������ Name ���������� ������������ �������");
        }

        [TestCase("", "������ ��������� ����������, ���� ��� - ������ ������",
            TestName = "���������� ������ ������ � �������� �����")]
        [TestCase("������_������_������_������_������_������_������_������",
            "������ ��������� ����������, ���� ��� ������� 50 ��������",
            TestName = "���������� ������������� ��� ������ 50 ��������")]
        public void Test_Name_Set_ArgumentException(string wrongName, string message)
        {
            var contact = new Contact();
            Assert.Throws<ArgumentException>(
                () => { contact.Name = wrongName; },
                message);
        }

        [Test(Description = "���������� ���� ������� BirthDate")]
        public void Test_BirthDate_Get_CorrectValue()
        {
            DateTime expected = DateTime.Now;
            var contact = new Contact();
            contact.BirthDate = expected;
            var actual = contact.BirthDate;
            Assert.AreEqual(expected, actual, "������ BirthDate ���������� ������������ ����");
        }

        [TestCase(("1000-01-01"), "������ ��������� ����������, ���� ���� �������� ������ 1900 ����",
            TestName = "���������� ������������ ���� 01.01.1000 �������, ��� 01.01.1900")]
        [TestCase(("9999-12-30"), "������ ��������� ����������, ���� ���� �������� ������ ������������ ���",
            TestName = "���������� ������������ ���� 30.12.9999 �������, ��� ����������� ����")]
        public void Test_BirthDate_Set_ArgumentException(DateTime wrongBirthDate, string message)
        {
            var contact = new Contact();
            Assert.Throws<ArgumentException>(
                () => { contact.BirthDate = wrongBirthDate; },
                message);
        }

        [Test(Description = "���������� ���� ������� Email")]
        public void Test_Email_Get_CorrectValue()
        {
            var expected = "test@mail.ru";
            var contact = new Contact();
            contact.Email = expected;
            var actual = contact.Email;
            Assert.AreEqual(expected, actual, "������ Email ���������� ������������ �������");
        }

        [TestCase("", "������ ��������� ����������, ���� Email - ������ ������",
            TestName = "���������� ������ ������ � �������� e-mail'a")]
        [TestCase("wrongTestWrongTestWrongTestWrongTestWrongTest@imail.ru",
            "������ ��������� ����������, ���� e-mail ������� 50 ��������",
            TestName = "���������� ������������� e-mail'a ������ 50 ��������")]
        public void Test_Email_Set_ArgumentException(string wrongEmail, string message)
        {
            var contact = new Contact();
            Assert.Throws<ArgumentException>(
                () => { contact.Email = wrongEmail; },
                message);
        }

        [Test(Description = "���������� ���� ������� VkID")]
        public void Test_VkID_Get_CorrectValue()
        {
            var expected = "id123345678";
            var contact = new Contact();
            contact.VkID = expected;
            var actual = contact.VkID;
            Assert.AreEqual(expected, actual, "������ VkID ���������� ������������ �������");
        }

        [TestCase("", "������ ��������� ����������, ���� VkID - ������ ������",
            TestName = "���������� ������ ������ � �������� VkID")]
        [TestCase("id123345678123456", "������ ��������� ����������, ���� VkID ������� 50 ��������",
            TestName = "���������� ������������� VkID ������ 15 ��������")]
        public void Test_VkID_Set_ArgumentException(string wrongVkID, string message)
        {
            var contact = new Contact();
            Assert.Throws<ArgumentException>(
                () => { contact.VkID = wrongVkID; },
                message);
        }

        [Test(Description = "���������� ���� ������������ Contact")]
        public void Contact_Consctuctor_CorrectValue()
        {
            var expectedSurname = "��������������";
            var expectedName = "�����";
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
                Assert.AreEqual(expectedSurname, actualSurname, "������� �� �������");
                Assert.AreEqual(expectedName, actualName, "����� �� �������");
                Assert.AreEqual(expectedBirthDate, actualBirthDate, "���� �������� �� �������");
                Assert.AreEqual(expectedEmail, actualEmail, "������ �� �������");
                Assert.AreEqual(expectedVkID, actualIdVK, "vkID �� �������");
                Assert.AreEqual(expectedNumber.Number, actualNumber.Number, "������ �� �������");
            });

        }
    }
}