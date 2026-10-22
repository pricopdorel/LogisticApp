using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogisticaDepozit
{
    public partial class AddManagerForm: Form
    {
        MenuForm menuForm;
        SqlConnection myCon = new SqlConnection(HomePageForm.connString);
        private string verificationCode;
        private string userEmail;
        private EmailService emailService;
        private VerificationManager verificationManager;

        public AddManagerForm(MenuForm form)
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            this.menuForm = form;

            emailService = new EmailService();
            verificationManager = new VerificationManager();
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^\p{So}\p{Cn}\s@]+@[^@\s]+\.(ro|com)$";
            return Regex.IsMatch(email, pattern);
        }

        private void addManagerButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "" || emailTextBox.Text == "" || label3.Text == "" || label4.Text == "")
            {
                MessageBox.Show("Completați toate câmpurile!");
                return;
            }

            if (!IsValidEmail(emailTextBox.Text))
            {
                MessageBox.Show("Emailul nu este valid!");
                return;
            }

            if (passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                MessageBox.Show("Parola nu corespunde!");
                return;
            }

            if (usernameTextBox.Text.Length < 5)
            {
                MessageBox.Show("Username-ul trebuie sa aiba minim 5 caractere!");
                return;
            }
            if (passwordTextBox.Text.Length < 7)
            {
                MessageBox.Show("Parola trebuie sa aiba minim 7 caractere!");
                return;
            }

            userEmail = emailTextBox.Text;
            verificationCode = verificationManager.GenerateVerificationCode(userEmail);

            if (emailService.SendVerificationCode(userEmail, verificationCode))
            {
                ManagerVerificationForm verificationForm = new ManagerVerificationForm(emailTextBox.Text, verificationManager, usernameTextBox.Text, HashPassword(passwordTextBox.Text));
                verificationForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Eroare la trimiterea email-ului.");
            }

            this.Close();
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
