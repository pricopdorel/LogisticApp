using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;


namespace LogisticaDepozit
{
    public partial class SignUpForm : Form
    {
        SqlConnection myCon = new SqlConnection();
        private EmailService emailService;
        private VerificationManager verificationManager;
        private string verificationCode;
        private string userEmail;

        public SignUpForm()
        {
            InitializeComponent();

            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.MaximumSize = new Size(this.Size.Width, this.Size.Height);

            this.FormClosed += Form3_FormClosed;
            myCon.ConnectionString = HomePageForm.connString;

            emailService = new EmailService();
            verificationManager = new VerificationManager();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^\p{So}\p{Cn}\s@]+@[^@\s]+\.(ro|com)$";
            return Regex.IsMatch(email, pattern);
        }


        private void signUpButtonClick(object sender, EventArgs e)
        {
            if (txtBox_UserS.Text == "" || txtBox_MailS.Text == "" || txtBox_PassS.Text == "" || txtBox_ConfPassS.Text == "" )
            {
                MessageBox.Show("Completați toate câmpurile!");
                return;
            }

            if (!IsValidEmail(txtBox_MailS.Text))
            {
                MessageBox.Show("Emailul nu este valid!");
                return;
            }

            if (txtBox_PassS.Text != txtBox_ConfPassS.Text)
            {
                MessageBox.Show("Parola nu corespunde!");
                return;
            }
            if(txtBox_UserS.Text.Length < 5)
            {
                MessageBox.Show("Username-ul trebuie sa aiba minim 5 caractere!");
                return;
            }
            if (txtBox_PassS.Text.Length < 7)
            {
                MessageBox.Show("Parola trebuie sa aiba minim 7 caractere!");
                return;
            }
            userEmail = txtBox_MailS.Text;
            verificationCode = verificationManager.GenerateVerificationCode(userEmail);

            if (emailService.SendVerificationCode(userEmail, verificationCode))
            {
                VerificationForm verificationForm = new VerificationForm(userEmail, verificationManager, txtBox_UserS.Text, HashPassword(txtBox_PassS.Text));
                verificationForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Eroare la trimiterea email-ului.");
            }


        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomePageForm signUpForm = Application.OpenForms["Form1"] as HomePageForm; // Get existing Form1
            if (signUpForm != null)
            {
                signUpForm.Show(); // Show Form1 again
                this.Hide(); // Hide Form2
            }
            else
            {
                signUpForm = new HomePageForm(); // Create a new Form1 if it doesn't exist
                signUpForm.Show();
                this.Hide(); // Hide Form2
            }
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
