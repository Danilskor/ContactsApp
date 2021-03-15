using System;
using System.Linq;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        private Project _project;

        public MainForm()
        {
            InitializeComponent();
            _project = ProjectManager.LoadFromFile(ProjectManager.DefaultFilePath);
            if (_project == null)
            {
                _project = new Project();
                return;
            }
            RefreshList();
            var surnames = _project.Сontacts.
                Select(contact => contact.Surname).
                Select(surname => surname.Contains("Bdfyjd")).
                ToList();
        }

        private void RefreshList()
        {
            ContactListBox.DataSource = null;
            ContactListBox.DataSource = _project.Сontacts;
            ContactListBox.DisplayMember = nameof(Contact.Surname);
            ProjectManager.SaveToFile(_project,ProjectManager.DefaultDirectoryPath, ProjectManager.DefaultFilePath);
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
                    _project.Сontacts.Remove((Contact)ContactListBox.SelectedItem);
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
                _project.Сontacts.Add(form.Contact);
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
