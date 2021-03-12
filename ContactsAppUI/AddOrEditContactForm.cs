using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class AddOrEditContactForm : Form
    {
        private Contact _contact;
        public AddOrEditContactForm()
        {
            InitializeComponent();
        }

        public Contact Contact { get; set; }

        private void AddOrEditContactForm_Load(object sender, EventArgs e)
        {
            if (Contact == null)
            {
                Contact = new Contact();
            }
            else
            {
                SurnameTextBox.Text = Contact.Surname;
                NameTextBox.Text = Contact.Name;
                PhoneTextBox.Text = Contact.PhoneNumber.Number;
                BirthdayDateTimePicker.Value = Contact.BirthDate;
                EmailTextBox.Text = Contact.Email;
                VkTextBox.Text = Contact.VkID;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Contact.Surname = SurnameTextBox.Text;
                Contact.Name = NameTextBox.Text;
                Contact.BirthDate = BirthdayDateTimePicker.Value;
                Contact.PhoneNumber.Number = PhoneTextBox.Text;
                Contact.Email = EmailTextBox.Text;
                Contact.VkID = VkTextBox.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private bool IsNotNumeric(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text, i))
                {
                    return false;
                }
            }

            return true;
        }

        private bool AssertStringOnLength(string text, int length)
        {
            if (text.Length <= length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ErrorColorBackGroundTextBox(bool isCorrect, TextBox textBox)
        {

             if(isCorrect)
             {
                 textBox.BackColor = Color.White;
             }
             else
             {
                 textBox.BackColor = Color.Crimson;
             }
          
        }

        private bool IsCorrectNumber(string number)
        {
            if (number.Length == 11 && number[0] == '7' && long.TryParse(number, out _))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsCorrectName(string name)
        {
            if (AssertStringOnLength(name, 50) && IsNotNumeric(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = SurnameTextBox.Text;
            ErrorColorBackGroundTextBox(IsCorrectName(text), SurnameTextBox);
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = NameTextBox.Text;
            ErrorColorBackGroundTextBox(IsCorrectName(text), NameTextBox);
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            var number = PhoneTextBox.Text;
            ErrorColorBackGroundTextBox(IsCorrectNumber(number), PhoneTextBox);
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = EmailTextBox.Text;
            AssertStringOnLength(text, 50);
        }

        private void VkTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = VkTextBox.Text;
            AssertStringOnLength(text, 15);
        }
    }
}
