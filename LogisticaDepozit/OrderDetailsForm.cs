using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LogisticaDepozit
{
    public partial class OrderDetailsForm: Form
    {
        string orderNo;
        int lastX = 12 , lastY = 70;
        

        private void insertProductOrder(string prodName)
        {
            Label label = new Label();
            label.Text = "Product Name: " + prodName;
            label.Location = new Point(lastX, lastY);
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(0, 51, 160);
            this.Controls.Add(label);
            lastY += 20;
        }
        public OrderDetailsForm(string orderNo)
        {
            this.orderNo = orderNo;
            Label orderLabel = new Label();
            orderLabel.Text = "Order " + this.orderNo + " details";
            orderLabel.Location = new Point(12, 9);
            orderLabel.AutoSize = true;
            orderLabel.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            orderLabel.ForeColor = Color.FromArgb(0, 51, 160);
            this.Controls.Add(orderLabel);

            SqlConnection myCon = new SqlConnection(connectionString: HomePageForm.connString);
            myCon.Open();
            SqlCommand cmd = new SqlCommand("SELECT ProductID FROM ProductOrder WHERE OrderID LIKE '" + orderNo + "';",myCon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SqlConnection myCon2 = new SqlConnection(connectionString: HomePageForm.connString);
                myCon2.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT Name FROM Products WHERE ProductID LIKE '" + reader.GetString(0) + "';", myCon2);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                reader2.Read();
                insertProductOrder(reader2.GetString(0));
                reader2.Close();
                myCon2.Close();
            }
            reader.Close();
            myCon.Close();
            InitializeComponent();
        }
    }
}
