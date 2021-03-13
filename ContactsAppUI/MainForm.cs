using System;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        private Project _project = new Project();

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        public static string DefaultDirectoryPath
        {
            get
            {
                var directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                                    + @"\ContactsApp";
                return directoryPath;
            }
        }

        /// <summary>
        /// Полное имя файла.
        /// </summary>
        public static string DefaultFilePath
        {
            get
            {
                var filePath = DefaultDirectoryPath + @"\ContactsApp.json";
                return filePath;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            this.Text = "ContactApp";
        }

        private void RefreshList()
        {
            ContactListBox.DataSource = null;
            ContactListBox.DataSource = _project.Сontacts;
            ContactListBox.DisplayMember = "Surname";
            ProjectManager.SaveToFile(_project,ProjectManager.DefaultDirectoryPath, ProjectManager.DefaultFilePath);
        }

        private void AddContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AddOrEditContactForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _project.Сontacts.Add(form.Contact);
                RefreshList();
            }
        }

        private void ContactListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactListBox.SelectedItem != null)
            {
                var contact = (Contact)ContactListBox.SelectedItem;
                SurnameTextBox.Text = contact.Surname;
                NameTextBox.Text = contact.Name;
                BirthdayDateTimePicker.Value = contact.BirthDate;
                PhoneTextBox.Text = contact.PhoneNumber.Number;
                EmailTextBox.Text = contact.Email;
                VkTextBox.Text = contact.VkID;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _project = ProjectManager.LoadFromFile( DefaultFilePath);
            RefreshList();
        }

        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ContactListBox.SelectedItem != null)
            {
                var form = new AddOrEditContactForm();
                form.Contact = (Contact)ContactListBox.SelectedItem;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                }
            }
        }

        private void DeleteContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ContactListBox.SelectedItem != null && MessageBox.Show
                (
                "Вы точно хотите удалить контакт?", "Предупреждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question
                ) == DialogResult.Yes)
            {
                _project.Сontacts.Remove((Contact)ContactListBox.SelectedItem);
                RefreshList();
            }
        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }
    }
}
