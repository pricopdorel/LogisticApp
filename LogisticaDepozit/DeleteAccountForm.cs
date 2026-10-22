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
    public partial class DeleteAccountForm: Form
    {
        private SqlConnection myCon = new SqlConnection();
        private SettingsForm settingsPage;
        private MenuForm menuPage;
        public DeleteAccountForm(SettingsForm settingsPage, MenuForm menuPage)
        {
            InitializeComponent();

            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.MaximumSize = new Size(this.Size.Width, this.Size.Height);

            this.settingsPage = settingsPage;
            this.menuPage = menuPage;

            this.passwordTextBox.UseSystemPasswordChar = true;
        }
            

        private void yesButtonClicked(object sender, EventArgs e)
        {
            confirmButton.Visible = true;
            passwordTextBox.Visible = true;
            confirmIdentityLabel.Visible = true;

            yesButton.Visible = false;
            noButton.Visible = false;
            questionLabel.Visible = false;
        }

        private void noButtonClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmButtonClicked(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == this.menuPage.password)
            {
                myCon.ConnectionString = HomePageForm.connString;
                myCon.Open();

                SqlCommand command = new SqlCommand("DELETE FROM Users\nWHERE UserID LIKE '" + menuPage.userID + "';", myCon);
                command.ExecuteNonQuery();

                myCon.Close();

                MessageBox.Show("Account deleted");
                menuPage.Close();
                settingsPage.Close();

                menuPage.username = null;
                menuPage.email = null;
                menuPage.password = null;
                menuPage.userID = null;
                menuPage.balance = 0;
                menuPage.role = null;

                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect password");
            }
        }
    }
}
