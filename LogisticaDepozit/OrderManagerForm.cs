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
    public partial class OrderManagerForm: Form
    {
        private TextBox textBoxTotalPrice = new TextBox();
        private MenuForm menuPage;
        private SettingsForm settingsPage;
        private SqlConnection myCon = new SqlConnection();
        private LoginForm logInForm;

        internal string username;
        internal string role;
        internal string password;
        internal string email;
        internal double balance;
        internal int cartId;
        private Panel panel;

        int lastX = 13, lastY = 33;
        private void insertProductListed(string orderNumber, string userID, string totalPrice, Panel panelOrders)
        {
            double nprice = Convert.ToDouble(totalPrice);
            //
            // Creat Label la fiecare produs din BD
            //
            Label label = new Label();
            label.Text = "Order Number: " + orderNumber + "\nPrice: " + totalPrice + " RON, user ID: " + userID;
            label.Location = new Point(lastX, lastY);
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(0, 51, 160);
            panelOrders.Controls.Add(label);
            //
            // Creat Buton Accept la fiecare produs din BD
            //
            Button declineButton = new Button();
            Button acceptButton = new Button();
            acceptButton.Text = "✔";
            acceptButton.TextAlign = ContentAlignment.MiddleCenter;
            acceptButton.ForeColor = Color.White;
            acceptButton.Size = new Size(40, 40);
            acceptButton.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            acceptButton.Location = new Point(lastX + 290, lastY);
            acceptButton.BackColor = Color.FromArgb(30, 70, 160);
            //
            // Expresie lambda pentru event
            //
            acceptButton.Click += (s, e) =>
            {
                myCon.Open();

                balance += nprice;
                textBoxTotalPrice.Text = balance.ToString() + " RON";
                SqlCommand cmd1 = new SqlCommand("UPDATE Users\n SET Balance = " + balance.ToString() + "WHERE UserID LIKE '" + menuPage.userID + "';", myCon);
                cmd1.ExecuteNonQuery();
                //SqlCommand cmd2 = new SqlCommand("DELETE FROM Orders WHERE OrderID LIKE '" + orderNumber + "';", myCon);
                //cmd2.ExecuteNonQuery();
                cmd1 = new SqlCommand("Update Orders\n Set Status = 'Accepted' WHERE OrderID LIKE '" + orderNumber + "';", myCon);
                cmd1.ExecuteNonQuery();
                cmd1 = new SqlCommand("Update Users\n Set Balance = " + balance.ToString() + "WHERE userID LIKE '" + menuPage.userID + "';", myCon);
                cmd1.ExecuteNonQuery();

                Label acceptLabel = new Label();
                acceptLabel.Text = "Accepted";
                acceptLabel.Location = new Point(acceptButton.Left, acceptButton.Top);
                acceptLabel.Size = new Size(80, 40);
                acceptLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                acceptLabel.ForeColor = Color.FromArgb(0, 51, 160);
                panel.Controls.Add(acceptLabel);
                panel.Controls.Remove(acceptButton);
                panel.Controls.Remove(declineButton);

                myCon.Close();
            };
            panelOrders.Controls.Add(acceptButton);
            //
            // Creat Decline Button la fiecare produs din BD
            //
            declineButton.Text = "✘";
            declineButton.TextAlign = ContentAlignment.MiddleCenter;
            declineButton.ForeColor = Color.White;
            declineButton.Size = new Size(40, 40);
            declineButton.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            declineButton.Location = new Point(acceptButton.Right + 1, lastY);
            declineButton.BackColor = Color.FromArgb(30, 70, 160);
            declineButton.Click += (s, e) => // Tot la fel pt click event
            {
                Label declineLabel = new Label();
                declineLabel.Text = "Declined";
                declineLabel.Location = new Point(acceptButton.Left, acceptButton.Top);
                declineLabel.Size = new Size(80, 40);
                declineLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                declineLabel.ForeColor = Color.FromArgb(0, 51, 160);
                panel.Controls.Add(declineLabel);
                panel.Controls.Remove(acceptButton);
                panel.Controls.Remove(declineButton);

                myCon.Open();
                SqlCommand cmd1 = new SqlCommand("Update Orders\n Set Status = 'Declined' WHERE OrderID LIKE '" + orderNumber + "';", myCon);
                cmd1.ExecuteNonQuery();
                cmd1 = new SqlCommand("SELECT * FROM Users WHERE UserID LIKE '" + userID + "';", myCon);
                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read())
                {
                    SqlConnection myCon2 = new SqlConnection(connectionString: HomePageForm.connString);
                    myCon2.Open();
                    SqlCommand cmd2  = new SqlCommand("Update Users\nSet Balance = " + (Convert.ToDouble(reader.GetString(4))+Convert.ToDouble(totalPrice)).ToString() + " WHERE UserID LIKE '" + userID + "';", myCon2);
                    cmd2.ExecuteNonQuery();
                    myCon2.Close();
                }
                myCon.Close();
                reader.Close();

            };
            panelOrders.Controls.Add(declineButton);

            lastY +=55; //Se trece la randul urmator
        }

        private void toolStripBackS_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuForm menuPage1 = new MenuForm(logInForm, balance, null);
            menuPage1.Show();
        }

        public OrderManagerForm(MenuForm menuPage, double balance)
        {
            this.logInForm = menuPage.loginPage;
            this.menuPage = menuPage;
            this.balance = balance;
            myCon.ConnectionString = HomePageForm.connString;
            
            panel = new Panel();
            panel.Size = new Size(630, 300);
            panel.Location = new Point(lastX, lastY + 80);
            panel.AutoScroll = true; // asta face scroll-ul automat, merge folosita si la Order Form
            this.Controls.Add(panel);
            myCon.Open();
            SqlCommand command = new SqlCommand("SELECT *\nFROM Orders\n", myCon);
            SqlDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                if (reader.GetString(2) == "Processing")
                {
                    count++;
                    insertProductListed(reader.GetString(0), reader.GetString(1), reader.GetString(3), panel);
                }
            }
            if(count == 0)
            {
                Label label = new Label();
                label.Text = "No new orders placed";
                label.Location = new Point(lastX, lastY);
                label.AutoSize = true;
                label.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                label.ForeColor = Color.FromArgb(0, 51, 160);
                panel.Controls.Add(label);
            }

            textBoxTotalPrice.Text = balance.ToString() + " RON";
            textBoxTotalPrice.Location = new Point(368, 65);
            textBoxTotalPrice.Size = new Size(102, 26);
            textBoxTotalPrice.ReadOnly = true;
            this.Controls.Add(textBoxTotalPrice);
            myCon.Close();
            reader.Close();



            InitializeComponent();
        }
    }
}
