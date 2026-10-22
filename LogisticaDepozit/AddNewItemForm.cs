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
    
    public partial class AddNewItemForm: Form
    {
        internal int lastIndex;
        private ProductStockForm productStockForm;
        private MenuForm menuPage;
        private SqlConnection myCon = new SqlConnection();
        public AddNewItemForm(ProductStockForm productStockForm, MenuForm menuPage)
        {
            this.menuPage = menuPage;
            this.productStockForm = productStockForm;
            this.lastIndex = productStockForm.lastIndex;
            myCon.ConnectionString = HomePageForm.connString;
            InitializeComponent();
        }

        private void buttonPlaceOreder_Click(object sender, EventArgs e)
        {
            try
            {
                myCon.Open();
                SqlCommand cmd = new SqlCommand("Insert INTO Products(ProductID, Name, Price, Qty) VALUES (@productID, @name, @price, @qty) ", myCon);
                cmd.Parameters.AddWithValue("@productID", (lastIndex + 1).ToString());
                cmd.Parameters.AddWithValue("@name", textBox_name.Text);
                cmd.Parameters.AddWithValue("@price", textBox_price.Text);
                cmd.Parameters.AddWithValue("@qty", "0");
                cmd.ExecuteNonQuery();
                myCon.Close();

                this.Hide();
                productStockForm.Controls.Clear();
                productStockForm.Close();
                ProductStockForm productStockForm1 = new ProductStockForm(productStockForm.balance, menuPage);
                productStockForm1.Show();
            }
            catch (Exception ex) {
                MessageBox.Show("Failed to add product. Check for blank boxes\n" + ex.Message);
            }
        }
    }
}
