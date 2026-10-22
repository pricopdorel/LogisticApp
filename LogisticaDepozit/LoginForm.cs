using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogisticaDepozit
{
    public partial class LoginForm: Form
    {
        internal SqlConnection myCon = new SqlConnection();
        public LoginForm()
        {
            myCon.ConnectionString = HomePageForm.connString;
            InitializeComponent();
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.MaximumSize = new Size(this.Size.Width, this.Size.Height);

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

        private void loginButtonClick(object sender, EventArgs e)
        {
            string username = usernameLoginTextBox.Text;
            string enteredPassword = passwordLoginTextBox.Text;
            string hashedPassword = HashPassword(enteredPassword); // hash-uiești parola introdusă

            try
            {
                myCon.Open();

                SqlCommand command = new SqlCommand("SELECT Password FROM Users WHERE Username = @username", myCon);
                command.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string storedHashedPassword = reader.GetString(0);

                    if (hashedPassword == storedHashedPassword)
                    {
                        MenuForm meniu = new MenuForm(this, 0, null);
                        meniu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username or Password Incorrect");
                    }
                }
                else
                {
                    MessageBox.Show("Username or Password Incorrect");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                myCon.Close();
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomePageForm loginForm = Application.OpenForms["Form1"] as HomePageForm; // Get existing Form1
            if (loginForm != null)
            {
                loginForm.Show(); // Show Form1 again
                this.Hide(); // Hide Form2
            }
            else
            {
                loginForm = new HomePageForm(); // Create a new Form1 if it doesn't exist
                loginForm.Show();
                this.Hide(); // Hide Form2
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
