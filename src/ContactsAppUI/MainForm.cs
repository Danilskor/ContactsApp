using System;
using System.Linq;
using System.Windows.Forms;
using ContactsApp;
using System.Collections.Generic;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        ///  /// Cписок контактов
        /// </summary>
        private Project _project;

        /// <summary>
        /// Список контактов хранит контакты после поиска
        /// </summary>
        private List<Contact> _substringFindProject = new List<Contact>();

        /// <summary>
        /// Список хранит контакты, у которых сегодня день рождения
        /// </summary>
        private List<Contact> _birthdayProject = new List<Contact>();

        public MainForm()
        {
            InitializeComponent();
            _project = ProjectManager.LoadFromFile(ProjectManager.DefaultDirectoryPath, ProjectManager.DefaultFilePath);
            if (_project == null)
            {
                _project = new Project();
                return;
            }
            RefreshList();
            var surnames = _project.Contacts.
                Select(contact => contact.Surname).
                Select(surname => surname.Contains("Bdfyjd")).
                ToList();
        }

        private void RefreshList()
        {
            ContactListBox.DataSource = null;
            ContactListBox.DataSource = _project.Contacts;
            ContactListBox.DisplayMember = nameof(Contact.Surname);
            ProjectManager.SaveToFile(
                _project,
                ProjectManager.DefaultDirectoryPath, 
                ProjectManager.DefaultFilePath
                );
        }

        /// <summary>
        /// Изменяет контакт.
        /// </summary>
        private void EditContact()
        {
            if (ContactListBox.SelectedItem == null)
            {
                return;
            }

            var form = new ContactForm();
            form.Contact = (Contact)ContactListBox.SelectedItem;
            if (form.ShowDialog() == DialogResult.OK)
            {
                RefreshList();
            }
        }

        /// <summary>
        /// Удаляет контакт.
        /// </summary>
        private void DeleteContact()
        {
            if (ContactListBox.SelectedItem != null)
            {
                var dialogResult = MessageBox.Show
                (
                    "You definitely want to delete a contact?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {
                    _project.Contacts.Remove((Contact)ContactListBox.SelectedItem);
                    RefreshList();
                }
            }
        }

        /// <summary>
        /// Добовляет контакт.
        /// </summary>
        private void AddContact()
        {
            var form = new ContactForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _project.Contacts.Add(form.Contact);
                RefreshList();
            }
        }

        private void AddContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void ContactListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactListBox.SelectedItem == null)
            {
                return;
            }

            var contact = (Contact)ContactListBox.SelectedItem;
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            BirthdayDateTimePicker.Value = contact.BirthDate;
            PhoneTextBox.Text = contact.PhoneNumber.Number;
            EmailTextBox.Text = contact.Email;
            VkTextBox.Text = contact.VkID;
        }

        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
           EditContact();
        }

        private void DeleteContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }
    }
}
