using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogisticaDepozit
{
    public partial class MenuForm: Form
    {
        internal LoginForm loginPage;
        private SettingsForm settingsPage;
        private SqlConnection myCon = new SqlConnection();
        private AddFundsForm addBalancePage;
        private ProductStockForm productStock;
        private ShopForm shopForm;

        // accesibile de catre orice clasa din proiectul curent

        internal string username;
        internal string role;
        internal string password;
        internal string email;
        internal double balance;
        internal string userID;
        
        public MenuForm(LoginForm form, double balance, string username)
        {
            this.loginPage = form;
            this.username = username;
            InitializeComponent();

            myCon.ConnectionString = HomePageForm.connString;

            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.MaximumSize = new Size(this.Size.Width, this.Size.Height);

            try
            {
                if (this.username == null)
                {
                    foreach (Control c in this.loginPage.Controls)
                    {
                        if (c is TextBox && c.TabIndex == 6)
                        {
                            this.username = c.Text;
                        }
                    }
                }

                usernameLabel.Text = this.username.ToString();

                myCon.Open();

                SqlCommand command = new SqlCommand("SELECT *\nFROM Users\nWHERE Username LIKE '"+ this.username +"';",myCon);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    this.password = reader.GetString(1);
                    this.email = reader.GetString(2);
                    this.role = reader.GetString(3);
                    this.userID = reader.GetString(0);
                    
                    
                        this.balance = Convert.ToDouble(reader.GetString(4));
                }
                
                if (this.role == "Manager")
                {
                    this.Controls.Remove(addManagerButton);
                }
                
                if (this.role == "Customer")
                {
                    this.Controls.Remove(productStockButton);
                    this.Controls.Remove(orderManagerButton);
                    this.Controls.Remove(addManagerButton);
                }

                this.balanceTextBox.Text = this.balance.ToString() + " RON";
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex);
            }
            myCon.Close();
        }

        private void settingsClicked(object sender, EventArgs e)
        {
            settingsPage = new SettingsForm(this);
            settingsPage.Show();
            this.Hide();
        }

        private void startShoppingClicked(object sender, EventArgs e)
        {
            shopForm = new ShopForm(balance, this);
            shopForm.Show();
            this.Hide();
        }

        private void shoppingCartClicked(object sender, EventArgs e)
        {
            ViewOrders viewOrdersForm = new ViewOrders(this);
            viewOrdersForm.Show();
            this.Hide();
        }

        private void addBalanceClicked(object sender, EventArgs e)
        {
            addBalancePage = new AddFundsForm(null,this);
            addBalancePage.Show();
        }

        private void productStockClicked(object sender, EventArgs e)
        {
            this.Hide();
            productStock = new ProductStockForm(balance, this);
            productStock.Show();
        }

        private void logOutClicked(object sender, EventArgs e)
        {
            username = null;
            role = null;
            password = null;
            email = null;
            balance = 0;
            userID = null;
            loginPage.Show();

            foreach (Control c in this.loginPage.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = null;
                }
            }

            this.Close();
        }

        private void MenuFormClosing(object sender, FormClosingEventArgs e)
        {
            loginPage.Show();
        }

        private void orderManagerButton_Click(object sender, EventArgs e)
        {
            OrderManagerForm orderForm = new OrderManagerForm(this, balance);
            orderForm.Show();
            this.Hide();
        }

        private void addManagerButton_Click(object sender, EventArgs e)
        {
            AddManagerForm addManagerForm = new AddManagerForm(this);
            addManagerForm.Show();
        }
    }
}
