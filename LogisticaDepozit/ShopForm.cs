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
    public partial class ShopForm: Form
    {
        private MenuForm menuPage;
        private SettingsForm settingsPage;
        private SqlConnection myCon = new SqlConnection();
        private DataSet dsUsers;
        private AddFundsForm addBalancePage;
        private LoginForm logInForm;

        // accesibile de catre orice clasa din proiectul curent

        internal string username;
        internal string role;
        internal string password;
        internal string email;
        internal double balance;

        private List<string> cartIds = new List<string>();
        private int lastX = 13; // tinem minte pozitia pe x initiala (pt coloana) - se modifica in functie de preferinte
        private int lastY = 33; // tinem minte pozitia pe y initiala (pt linie)
        private Panel panel; // asta e panel-ul in care o sa apara toate elementele din baza de date
        internal int lastIndex; // asta e o variabila care sa tina minte care e ultimul primary key al elementelor din BD, pentru a adauga un element nou
        //
        // Asta e functia ce se apeleaza la fiecare produs gasit in BD
        //
        private void insertProductListed(string productName, string qty, string price, Panel panelNames)
        {
            int nqty = Convert.ToInt32(qty);
            double nprice = Convert.ToDouble(price);
            //
            // Creat Label la fiecare produs din BD
            //
            Label label = new Label();
            label.Text = productName + "(" + price + " RON" + ") " + qty + " in stock";
            label.Location = new Point(lastX, lastY);
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(0, 51, 160);
            panelNames.Controls.Add(label);
            //
            // Creat TaxtBox la fiecare produs din BD
            //
            TextBox textBox = new TextBox();
            textBox.Text = "0";
            //
            // Creat Buton Minus la fiecare produs din BD
            //
            Button minusButton = new Button();
            minusButton.Text = "-";
            minusButton.TextAlign = ContentAlignment.MiddleCenter;
            minusButton.ForeColor = Color.White;
            minusButton.Size = new Size(40, 40);
            minusButton.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            minusButton.Location = new Point(lastX + 420, lastY);
            minusButton.BackColor = Color.FromArgb(30, 70, 160);
            //
            // Expresie lambda pentru event
            //
            minusButton.Click += (s, e) =>
            {
                if (Convert.ToInt32(textBox.Text) - 1 >= 0)
                {
                    textBox.Text = (Convert.ToInt32(textBox.Text) - 1).ToString();
                    textBoxTotalPrice.Text = (Convert.ToDouble(textBoxTotalPrice.Text) - nprice).ToString();
                    
                    
                        myCon.Open();
                        SqlCommand cmd = new SqlCommand("Select ProductID FROM Products WHERE Name LIKE '" + productName + "';", myCon);
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        
                        cartIds.Remove(reader.GetString(0));
                        myCon.Close();
                        reader.Close();
                    
                }
                else
                    MessageBox.Show("Quantity can't be negative");

            };
            panelNames.Controls.Add(minusButton);
            //
            // Continuat de updatat paramentrii textBox-ului pentru ca aveam nevoide de minusButton
            //
            textBox.Size = new Size(60, 27);
            textBox.Location = new Point(minusButton.Right + 1, lastY);
            textBox.ReadOnly = true;
            panelNames.Controls.Add(textBox);
            //
            // Creat Plus Button la fiecare produs din BD
            //
            Button plusButton = new Button();
            plusButton.Text = "+";
            plusButton.TextAlign = ContentAlignment.MiddleCenter;
            plusButton.ForeColor = Color.White;
            plusButton.Size = new Size(40, 40);
            plusButton.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            plusButton.Location = new Point(textBox.Right + 1, lastY);
            plusButton.BackColor = Color.FromArgb(30, 70, 160);
            plusButton.Click += (s, e) => // Tot la fel pt click event
            {
                if (Convert.ToInt32(textBox.Text) < nqty)
                {
                    textBox.Text = (Convert.ToInt32(textBox.Text) + 1).ToString();
                    textBoxTotalPrice.Text = (Convert.ToDouble(textBoxTotalPrice.Text) + nprice).ToString();
                    myCon.Open();
                    SqlCommand cmd = new SqlCommand("Select ProductID FROM Products WHERE Name LIKE '" + productName + "';", myCon);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    cartIds.Add(reader.GetString(0));
                    myCon.Close();
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Insufficient stock");
                }
                
            };
            panelNames.Controls.Add(plusButton);

            lastY += 35; //Se trece la randul urmator
        }
        public ShopForm(double balance, MenuForm menuPage)
        {
            this.balance = balance;
            this.menuPage = menuPage;
            this.username = menuPage.username;
            this.logInForm = menuPage.loginPage;
            this.textBoxTotalPrice = new TextBox();
            this.labelOrderTotal = new Label();
            this.buttonPlaceOreder = new Button();

            //DE SCHIMBAT STRING-UL IN FUNCTIE DE PC
            myCon.ConnectionString = HomePageForm.connString;

            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);

            panel = new Panel();
            panel.Size = new Size(630, 300);
            panel.Location = new Point(lastX, lastY + 80);
            panel.AutoScroll = true; // asta face scroll-ul automat, merge folosita si la Order Form
            this.Controls.Add(panel);
            //
            // Creat balance textBox care se updateaza la fiecare actiune, de asta e creat in constructor
            //
            TextBox textBoxTotalPrice = new TextBox();
            textBoxTotalPrice.Text = balance.ToString() + " RON";
            textBoxTotalPrice.Location = new Point(485, 70);
            textBoxTotalPrice.Size = new Size(102, 26);
            textBoxTotalPrice.ReadOnly = true;
            this.Controls.Add(textBoxTotalPrice);
            //
            // Cautam produsele in BD
            //
            myCon.Open();
            SqlCommand command = new SqlCommand("SELECT *\nFROM Products\n", myCon);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lastIndex = Convert.ToInt32(reader.GetString(0));
                insertProductListed(reader.GetString(1), reader.GetString(3), reader.GetString(2), panel);
            }
            myCon.Close();
            reader.Close();
            InitializeComponent();
        }
        //
        // Asta e acelasi lucru ca si in menu page
        //
        private void addBalanceButton_Click(object sender, EventArgs e)
        {
            addBalancePage = new AddFundsForm(null, menuPage);
            addBalancePage.Show();
        }
        //
        // Butonu de place order
        //
        private void buttonPlaceOreder_Click(object sender, EventArgs e)
        {
            if (this.balance > Convert.ToDouble(textBoxTotalPrice.Text))
            {
                this.balance -= Convert.ToDouble(textBoxTotalPrice.Text);
                menuPage.balance = this.balance;
                int panelIndex = 2; // Avem nevoie de index-ul asta ca fiecare quantity textbox creat cu functia ce se apeleaza de mai multe ori e salvat in this.Controls, in cazul nostru in panel.Controls
                int productIndex = 0; // Asta e ca sa navigam printre PK
                SqlConnection myCon2 = new SqlConnection(myCon.ConnectionString); // Avem nevoie de 2 conexiuni deoarece apelam BD simultan de 2 ori (in while)
                myCon2.Open();
                myCon.Open();
                string query = "UPDATE Users\n Set Balance = " + this.balance.ToString() + "\nWHERE UserID LIKE '" + menuPage.userID + "';";
                SqlCommand cmd3 = new SqlCommand(query, myCon);
                cmd3.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("SELECT Qty FROM Products", myCon);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read() && panelIndex < panel.Controls.Count)
                {
                    string qtyAdded = panel.Controls[panelIndex].Text;
                    SqlCommand cmd2 = new SqlCommand("UPDATE Products\nSet Qty = " + (Convert.ToInt32(reader1.GetString(0)) - Convert.ToInt32(qtyAdded)).ToString() + "\nWHERE ProductID LIKE '" + (productIndex + 1).ToString() + "';", myCon2);
                    cmd2.ExecuteNonQuery();
                    panelIndex += 4; // Asta este pasul la care se gasesc prin Controale textBox-urile  ce ne trebe
                    productIndex++;
                }
                reader1.Close();
                
                SqlCommand cmd4 = new SqlCommand("SELECT * FROM Orders",myCon2);
                SqlDataReader reader3;
                reader3 = cmd4.ExecuteReader();
                int lastIndex = 0;
                while(reader3.Read())
                    lastIndex = Convert.ToInt32(reader3.GetString(0));
                reader3.Close();
                Random rnd = new Random();
                int norderNo = rnd.Next(10000,100000);
                string orderNo = norderNo.ToString();
                string id = menuPage.userID;
                string totalprice = textBoxTotalPrice.Text;
                
                SqlCommand cmd5 = new SqlCommand("INSERT INTO Orders(OrderID, userID, Status, TotalPrice, PlacedData) VALUES (@orderID, @userID, @status, @totalPrice, @placedData)", myCon2);
                cmd5.Parameters.AddWithValue("@orderID", orderNo);
                cmd5.Parameters.AddWithValue("@userID", id);
                cmd5.Parameters.AddWithValue("@status", "Processing");
                cmd5.Parameters.AddWithValue("@totalPrice", totalprice);
                cmd5.Parameters.AddWithValue("@placedData", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
                cmd5.ExecuteNonQuery();

                cmd5 = new SqlCommand("SELECT ID FROM ProductOrder",myCon);
                SqlDataReader reader4 = cmd5.ExecuteReader();
                int lastIndex2 = 0;
                while(reader4.Read())
                    lastIndex2 = Convert.ToInt32(reader4.GetString(0));
                reader4.Close();
                foreach (string prodID in cartIds)
                {
                    lastIndex2++;
                    SqlCommand cmd6 = new SqlCommand("INSERT INTO ProductOrder(ID, OrderID, ProductID) VALUES (@ID, @orderID, @productID)", myCon2);
                    cmd6.Parameters.AddWithValue("@ID", lastIndex2.ToString());
                    cmd6.Parameters.AddWithValue("@orderID", orderNo);
                    cmd6.Parameters.AddWithValue("@productID", prodID);
                    cmd6.ExecuteNonQuery();
                }
                myCon.Close();
                myCon2.Close();

                MessageBox.Show("Order places succesfully\nAn operator will confirm your order shortly");
                //
                // Dam refresh
                //
                ShopForm shopForm1 = new ShopForm(balance, menuPage);
                this.Close();
                shopForm1.Show();
            }
            else
            {
                MessageBox.Show("Insufficient Funds");
            }
        }
        private void ProductStockFormClosing(object sender, FormClosingEventArgs e)
        {
            menuPage.Show();
        }
        private void toolStripBackS_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            MenuForm menuPage1 = new MenuForm(logInForm, balance, null);
            //menuPage1.balance = this.balance;
            menuPage1.Show();
        }
    }
}
