using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogisticaDepozit
{
    public partial class AddFundsForm: Form
    {
        private SqlConnection myCon = new SqlConnection();
        private SettingsForm settingsPage;
        private MenuForm menuPage;
        public AddFundsForm(SettingsForm settingsPage, MenuForm menuPage)
        {
            InitializeComponent();

            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.MaximumSize = new Size(this.Size.Width, this.Size.Height);

            this.menuPage = menuPage;
            this.settingsPage = settingsPage;
        }

        private void confirmTransactionClick(object sender, EventArgs e)
        {
            if(Convert.ToInt32(enterSumTextBox.Text) != 0 && cardNumberTextBox.Text.Length == cardNumberTextBox.MaxLength)
            {
                myCon.ConnectionString = HomePageForm.connString;
                myCon.Open();

                double x = Convert.ToDouble(enterSumTextBox.Text) + menuPage.balance;

                SqlCommand command = new SqlCommand("UPDATE Users\nSET Balance = " + x +"\nWHERE UserID LIKE '" + menuPage.userID +"';",myCon);
                command.ExecuteNonQuery();

                if (this.settingsPage != null)
                {
                    foreach (Control c in this.settingsPage.Controls)
                    {
                        if (c.TabIndex == 8)
                        {
                            c.Text = x.ToString() + " RON";
                        }
                    }
                }

                foreach (Control c in this.menuPage.Controls)
                {
                    if (c.TabIndex == 7)
                    {
                        c.Text = x.ToString()+" RON";
                        menuPage.balance = Convert.ToInt32(x.ToString());
                    }
                }

                myCon.Close();
            }
            this.Close();
        }
    }
}
