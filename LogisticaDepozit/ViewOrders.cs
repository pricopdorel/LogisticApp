using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace LogisticaDepozit
{
    public partial class ViewOrders: Form
    {
        private MenuForm menuPage;
        private SqlConnection myCon = new SqlConnection();
        private Panel panel;

        internal string username;

        int lastX = 13, lastY = 33;
        private void insertOrderListed(string orderNumber, string totalPrice, string status, string data, Panel panelOrders)
        {
            double nprice = Convert.ToDouble(totalPrice);
            //
            // Creat Label la fiecare produs din BD
            //
            Label label = new Label();
            label.Text = "Order Number: " + orderNumber + " Price: " + totalPrice + "\nData: "+ data + " Status: " + status;
            label.Location = new Point(lastX, lastY);
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(0, 51, 160);
            panelOrders.Controls.Add(label);
            
            System.Windows.Forms.Button detailsButton = new System.Windows.Forms.Button();
            detailsButton.Text = "details";
            detailsButton.TextAlign = ContentAlignment.MiddleCenter;
            detailsButton.ForeColor = Color.White;
            detailsButton.Size = new Size(100, 40);
            detailsButton.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            detailsButton.Location = new Point(label.Right+150, lastY-5);
            detailsButton.BackColor = Color.FromArgb(30, 70, 160);
            detailsButton.Click += (s, e) =>
            {
                OrderDetailsForm orderDetailsForm = new OrderDetailsForm(orderNumber);
                orderDetailsForm.Show();
            };
            panelOrders.Controls.Add(detailsButton);

            lastY += 55; //Se trece la randul urmator
        }
        public ViewOrders(MenuForm menuPage)
        {
            this.menuPage = menuPage;
            this.username = menuPage.username;
            myCon.ConnectionString = HomePageForm.connString;

            panel = new Panel();
            panel.Size = new Size(630, 300);
            panel.Location = new Point(lastX, lastY + 80);
            panel.AutoScroll = true; // asta face scroll-ul automat, merge folosita si la Order Form
            this.Controls.Add(panel);

            myCon.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Orders WHERE userID LIKE '" + menuPage.userID + "';", myCon);
            SqlDataReader reader = cmd.ExecuteReader();
            int count = 0 ;
            while(reader.Read())
            {
                count++;
                insertOrderListed(reader.GetString(0), reader.GetString(3), reader.GetString(2), reader.GetString(4), panel);
            }
            if (count == 0)
            {
                Label label = new Label();
                label.Text = "No orders made yet";
                label.Location = new Point(lastX, lastY);
                label.AutoSize = true;
                label.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                label.ForeColor = Color.FromArgb(0, 51, 160);
                panel.Controls.Add(label);
            }
            myCon.Close();
            reader.Close();
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            MenuForm menuPage1 = new MenuForm(menuPage.loginPage, menuPage.balance, null);
            menuPage1.Show();
        }

        private void toolStripBackS_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
