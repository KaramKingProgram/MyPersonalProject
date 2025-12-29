using ExpenseManager;
using Guna.UI2.WinForms;
using MyBuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPersonalApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            CheckValidatingError(sender, e,txtFirstName);
        }

        private void CheckValidatingError(object sender, CancelEventArgs e, Guna2TextBox text)
        {
            if (string.IsNullOrWhiteSpace(text.Text))
            {

                text.Focus();
                errorProvider1.SetError(text, "This Item Should Have A Value!!");


            }
            else
            {

                errorProvider1.SetError(text, "");
            }


        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            CheckValidatingError(sender,e,txtUserName);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            CheckValidatingError(sender, e, txtPassword);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!IsValidInput())
                return;
            
            bool isRegistered = clsUsers.Register(
                txtFirstName.Text,
                txtLastName.Text,
                txtEmail.Text,
                dtpDateOfBirth.Value,
                txtCountryName.Text,
                txtPhone.Text,
                txtUserName.Text,
                txtPassword.Text);

            MessageBox.Show(
                isRegistered ? "Account created successfully ✅" : "Registration failed ❌",
                "Register",
                MessageBoxButtons.OK,
                isRegistered ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (isRegistered)
            {
                this.Close();
               
            }
             new LoginForm().Show();

        }

        private bool IsValidInput()
        {
            return !string.IsNullOrWhiteSpace(txtFirstName.Text)
                && !string.IsNullOrWhiteSpace(txtUserName.Text)
                && !string.IsNullOrWhiteSpace(txtPassword.Text);
        }


    }
}
