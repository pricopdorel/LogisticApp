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
using System.Xml.Linq;

namespace LogisticaDepozit
{
    public partial class SettingsForm: Form
    {
        private MenuForm menuPage;
        private ChangeInfoForm changeInfoPage;
        private AddFundsForm addFundsPage;
        private DeleteAccountForm deleteAccountPage;

        private bool isDarkMode = false;
        private Color defaultColor;
        
        public SettingsForm(MenuForm menuPage)
        {
            InitializeComponent();

            this.menuPage = menuPage;

            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.MaximumSize = new Size(this.Size.Width, this.Size.Height);

            this.overviewUsernameTextBox.Text = this.menuPage.username.ToString();
            this.overviewBalanceTextBox.Text = this.menuPage.balance.ToString() + " RON";
            this.overviewEmailTextBox.Text = this.menuPage.email.ToString();

            this.defaultColor = this.menuPage.BackColor;

            if(menuPage.role == "Owner")
            {
                this.Controls.Remove(this.deleteAccountButton);
            }
        }

        private void changeUsernameClicked(object sender, EventArgs e)
        {
            this.changeInfoPage = new ChangeInfoForm(this, this.menuPage, "username");
            this.changeInfoPage.Show();
        }

        private void changeEmailClicked(object sender, EventArgs e)
        {
            this.changeInfoPage = new ChangeInfoForm(this, this.menuPage, "email");
            this.changeInfoPage.Show();
        }

        private void changePasswordClicked(object sender, EventArgs e)
        {
            this.changeInfoPage = new ChangeInfoForm(this, this.menuPage, "password");
            this.changeInfoPage.Show();
        }

        private void addFundsClick(object sender, EventArgs e)
        {
            this.addFundsPage = new AddFundsForm(this, this.menuPage);
            this.addFundsPage.Show();
        }

        private void deleteAccountButtonClick(object sender, EventArgs e)
        {
            this.deleteAccountPage = new DeleteAccountForm(this, this.menuPage);
            this.deleteAccountPage.Show();
        }
        private void SettingsFormClosing(object sender, FormClosingEventArgs e)
        {
            SqlConnection myCon = new SqlConnection(connectionString: HomePageForm.connString);
            myCon.Open();
            SqlCommand cmd = new SqlCommand("SELECT Username FROM Users WHERE UserID LIKE '" + menuPage.userID + "';", myCon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) {
                MenuForm menuPage1 = new MenuForm(menuPage.loginPage, menuPage.balance, reader.GetString(0));
                menuPage1.Show();
            }
        }
    }
}
