﻿using System;
using System.Drawing;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class ContactForm : Form
    {
        /// <summary>
        /// Склонированный контакт
        /// </summary>
        private Contact _cloneContact;
        /// <summary>
        /// Свойства контакта
        /// </summary>
        public Contact Contact { get; set; }
        
        private void ContactForm_Load(object sender, EventArgs e)
        {
            if (Contact == null)
            {
                Contact = new Contact();
                _cloneContact = Contact;
            }
            else
            {
                _cloneContact = (Contact)Contact.Clone();
                SurnameTextBox.Text = _cloneContact.Surname;
                NameTextBox.Text = _cloneContact.Name;
                PhoneTextBox.Text = _cloneContact.PhoneNumber.Number;
                BirthdayDateTimePicker.Value = _cloneContact.BirthDate;
                EmailTextBox.Text = _cloneContact.Email;
                VkTextBox.Text = _cloneContact.VkID;

            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                Contact.Surname = SurnameTextBox.Text;
                Contact.Name = NameTextBox.Text;
                Contact.BirthDate = BirthdayDateTimePicker.Value;
                Contact.PhoneNumber = new PhoneNumber();
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

        private void ErrorColorBackGroundTextBox(bool isCorrect, TextBox textBox)
        {

             if(isCorrect)
             {
                 textBox.BackColor = Color.White;
             }
             else
             {
                 textBox.BackColor = Color.LightCoral;
             }
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = SurnameTextBox.Text;
            try
            {
                _cloneContact.Surname = text;
            }
            catch (Exception exception)
            {
                ErrorColorBackGroundTextBox(false, SurnameTextBox);
                return;
            }

            ErrorColorBackGroundTextBox(true, SurnameTextBox);
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = NameTextBox.Text;
            try
            {
                _cloneContact.Name = text;
            }
            catch (Exception exception)
            {
                ErrorColorBackGroundTextBox(false, NameTextBox);
                return;
            }

            ErrorColorBackGroundTextBox(true, NameTextBox);
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            var number = PhoneTextBox.Text;
            try
            {
                _cloneContact.PhoneNumber.Number = number;
            }
            catch (Exception exception)
            {
                ErrorColorBackGroundTextBox(false, PhoneTextBox);
                return;
            }

            ErrorColorBackGroundTextBox(true, PhoneTextBox);
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = EmailTextBox.Text;
            try
            {
                _cloneContact.Email = text;
            }
            catch (Exception exception)
            {
                ErrorColorBackGroundTextBox(false, EmailTextBox);
                return;
            }

            ErrorColorBackGroundTextBox(true, EmailTextBox);
        }

        private void VkTextBox_TextChanged(object sender, EventArgs e)
        {
            TrySetValueToProperty(nameof(_cloneContact.VkID), (TextBox)sender);
        }

        private void TrySetValueToProperty(string propertyName, TextBox textbox)
        {
            var text = textbox.Text;
            try
            {
                _cloneContact.GetType().GetProperty(propertyName).SetValue(_cloneContact, text);
            }
            catch (Exception exception)
            {
                ErrorColorBackGroundTextBox(false, textbox);
                return;
            }
            _cloneContact.GetType().GetProperty(propertyName).SetValue(_cloneContact, text);
            ErrorColorBackGroundTextBox(true, textbox);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public ContactForm()
        {
            InitializeComponent();
        }

        private void ContactForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
