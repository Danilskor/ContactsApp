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
        /// Список контактов хранит контакты после поиска или сортировки
        /// </summary>
        private List<Contact> _usingContacts;

        /// <summary>
        /// Список хранит контакты, у которых сегодня день рождения
        /// </summary>
        private List<Contact> _birthdayProject = new List<Contact>();

        public MainForm()
        {
            InitializeComponent();
            _project = ProjectManager.LoadFromFile(
                ProjectManager.DefaultDirectoryPath, 
                ProjectManager.DefaultFilePath
                );
            _usingContacts = _project.Contacts;

            if (_project == null)
            {
                _project = new Project();
                return;
            }

            RefreshList();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (_project.GetListBirthday().Length > 0)
            {
                BirthdayLabel.Text = $"Сегодня день рождения: {_project.GetListBirthday()} ";
                BirthdayLabel.Visible = true;
                BackgroundPanel.Visible = true;
            }
        }

        private void RefreshList()
        {
            ContactListBox.DataSource = null;
            ContactListBox.DataSource = _usingContacts;
            Project.SortContactsList(_usingContacts);
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
                    _project.Contacts.Remove((Contact)ContactListBox.SelectedItem); ;
                    _usingContacts.Remove((Contact)ContactListBox.SelectedItem);
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
                _usingContacts.Add(form.Contact);
                RefreshList();
            }
        }

        private void AddContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
            _usingContacts = Project.Find(FindTextBox.Text, _project.Contacts);
            RefreshList();
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
           _usingContacts = Project.Find(FindTextBox.Text, _project.Contacts);
           RefreshList();
        }

        private void DeleteContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteContact();
            _usingContacts = Project.Find(FindTextBox.Text, _project.Contacts);
            RefreshList();
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

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            _usingContacts =  Project.Find(FindTextBox.Text, _project.Contacts);
            RefreshList();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                case Keys.Subtract:
                    DeleteContact();
                    break;

                case Keys.Add:
                    AddContact();
                    break;


                case Keys.F1:
                    var form = new AboutForm();
                    form.ShowDialog();
                    break;

                case Keys.Escape:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
