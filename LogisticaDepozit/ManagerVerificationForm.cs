using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogisticaDepozit
{
    public partial class ManagerVerificationForm : Form
    {
        private readonly string email;
        private readonly string username;
        private readonly string hashedPassword;
        private readonly VerificationManager verificationManager;

        public ManagerVerificationForm(string email, VerificationManager manager, string username, string hashedPassword)
        {
            InitializeComponent();
            this.email = email;
            this.username = username;
            this.hashedPassword = hashedPassword;
            this.verificationManager = manager;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string inputCode = txtVerificationCode.Text;

            if (verificationManager.ValidateCode(email, inputCode))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(HomePageForm.connString))
                    {
                        conn.Open();

                        SqlCommand cmd1 = new SqlCommand("Select * FROM Users", conn);
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        string role = "Manager";

                        string query = "INSERT INTO Users (UserID, Password, Email, Role, Balance, Username) VALUES (@userID, @password, @email, @role, @balance, @username)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@userID", username);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@balance", role == "Owner" ? 1000000 : 0);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cont creat cu succes!");
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la salvarea utilizatorului: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Cod incorect sau expirat.");
            }


        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
