using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PALENGKE_APP
{
    public partial class main_customer : Form
    {
        public main_customer()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataAdapter adapt;
        public string username;
        DataTable table = new DataTable();
        DataTable sellerstable = new DataTable();
        DataTable bought = new DataTable();
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
        private void main_customer_Load(object sender, EventArgs e)
        {
            Customer currentCustomer = new Customer();
            Customer_name.Text = currentCustomer.CustomerName;

            time.Text = DateTime.Now.ToString();
            dataGridView_product.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_bought.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                string Myconnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string query = "SELECT Category, Name, Price, Quantity, Seller FROM products;";
                MySqlConnection mycon2 = new MySqlConnection(Myconnection2);
                MySqlCommand Mycommand2 = new MySqlCommand(query, mycon2);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();
                myadapter.SelectCommand = Mycommand2;
                
                myadapter.Fill(table);
                dataGridView_product.DataSource = table;

                MySqlConnection con = new MySqlConnection("datasource= localhost; database=palengke;port=3306; username = root; password="); //open connection
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select Name from categories order by Name ASC", con);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string Name = reader.GetString("Name");
                    comboBox_category2.Items.Add(Name);
                }
                cmd.Dispose();
                reader.Close();
                con.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string Myconnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string query = "SELECT * FROM sellers;";
                MySqlConnection mycon2 = new MySqlConnection(Myconnection2);
                MySqlCommand Mycommand2 = new MySqlCommand(query, mycon2);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();
                myadapter.SelectCommand = Mycommand2;

                myadapter.Fill(sellerstable);

                MySqlConnection con2 = new MySqlConnection("datasource= localhost; database=palengke;port=3306; username = root; password="); //open connection
                con2.Open();

                MySqlCommand cmd2 = new MySqlCommand("select Name from sellers order by Name ASC", con2);

                MySqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    string Name = reader2.GetString("Name");
                    comboBox_seller2.Items.Add(Name);
                }
                cmd2.Dispose();
                reader2.Close();
                con2.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void comboBox_category2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected category
            string selectedCategory = comboBox_category2.Text;

            // Create a DataView to filter the data based on the selected category
            DataView dv = new DataView(table);
            dv.RowFilter = "Category='" + selectedCategory + "'";
            // filter the combo box
            DataView dv2 = new DataView(sellerstable);
            dv2.RowFilter = "Type='" + selectedCategory + "'";
            comboBox_seller2.DataSource = dv2;

            comboBox_seller2.DisplayMember = "Name";
            comboBox_seller2.ValueMember = "Name";
            // Update the DataGridView with the filtered data
            dataGridView_product.DataSource = dv;
        }

        private void comboBox_seller2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSeller = comboBox_seller2.Text;

            // Create a DataView to filter the data based on the selected seller
            DataView dv = new DataView(table);
            dv.RowFilter = "Seller='" + selectedSeller + "'";

            // Set the DataSource of the DataGridView to the filtered DataView
            dataGridView_product.DataSource = dv;
        }

        private void dataGridView_product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView_product_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                string productName = dataGridView_product.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                string productPrice = dataGridView_product.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                string productSeller = dataGridView_product.Rows[e.RowIndex].Cells["Seller"].Value.ToString();

                try
                {
                    string insertQuery = "INSERT INTO bought (Name, Price,Seller) VALUES (@name, @price, @seller)";
                    MySqlConnection connection = new MySqlConnection(connectionString);
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@name", productName);
                    command.Parameters.AddWithValue("@price", productPrice);
                    command.Parameters.AddWithValue("@seller", productSeller);
                    command.ExecuteNonQuery();
                    connection.Close();
                    PopulateDataGridView_Bought();
                    
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (e.RowIndex >= 0)
            {
                int selectedRow = e.RowIndex;
                int currentQuantity = Convert.ToInt32(dataGridView_product.Rows[selectedRow].Cells["Quantity"].Value);
                if (currentQuantity > 0)
                {
                    dataGridView_product.Rows[selectedRow].Cells["Quantity"].Value = currentQuantity - 1;
                }
                try
                {
                    // Decrement the current quantity by 1
                    int updatedQuantity = currentQuantity - 1;

                    // Get the product name and seller from the selected row
                    string productName = dataGridView_product.Rows[selectedRow].Cells["Name"].Value.ToString();
                    string productSeller = dataGridView_product.Rows[selectedRow].Cells["Seller"].Value.ToString();

                    // Open the connection to the database
                    MySqlConnection connection = new MySqlConnection(connectionString);
                    connection.Open();

                    // Create the update command
                    string updateCommand = "UPDATE products SET Quantity = @quantity WHERE Name = @name AND Seller = @seller";
                    MySqlCommand command = new MySqlCommand(updateCommand, connection);

                    // Add the updated quantity, product name and product seller as parameters
                    command.Parameters.AddWithValue("@quantity", updatedQuantity);
                    command.Parameters.AddWithValue("@name", productName);
                    command.Parameters.AddWithValue("@seller", productSeller);

                    // Execute the update command
                    command.ExecuteNonQuery();

                    // Close the connection to the database
                    connection.Close();

                    // Update the dataGridView_product to reflect the updated quantity
                    dataGridView_product.Rows[selectedRow].Cells["Quantity"].Value = updatedQuantity;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PopulateDataGridView_Bought()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT ID, Name, Price, Seller FROM bought", connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView_bought.DataSource = table;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SumPrice();
        }

        private void SumPrice()
        {
            try
            {
                MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=palengke");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT SUM(Price) as totalPrice FROM bought", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    double totalPrice = reader.GetDouble("totalPrice");
                    total_label.Text = totalPrice.ToString();
                }
                cmd.Dispose();
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Delete?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
             if (dataGridView_bought.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridView_bought.SelectedRows[0];

                    // Get the values of the selected product
                    string productName = selectedRow.Cells["Name"].Value.ToString();
                    string productSeller = selectedRow.Cells["Seller"].Value.ToString();

                    // Delete the selected row from the DataGridView
                    dataGridView_bought.Rows.Remove(selectedRow);

                    // Increment the quantity of the product in the "products" table
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string updateQuery = "UPDATE products SET Quantity = Quantity + 1 WHERE Name = @Name AND Seller = @Seller";
                        using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Name", productName);
                            command.Parameters.AddWithValue("@Seller", productSeller);

                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                            using (MySqlConnection connection = new MySqlConnection(connectionString))
                            {
                                connection.Open();

                                string deleteQuery = "DELETE FROM bought WHERE Name = @Name AND Seller = @Seller";
                                using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@Name", productName);
                                    command.Parameters.AddWithValue("@Seller", productSeller);

                                    command.ExecuteNonQuery();
                                }
                                connection.Close();
                            }
                        }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
                        SumPrice();
                        fillcombo();

            }
        // Check if a row is selected in the DataGridView
   
        }

       
     


        public void fillcombo()
        {
            try
            {
                string Myconnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string query = "SELECT Category, Name, Price, Quantity, Seller FROM products;";
                MySqlConnection mycon2 = new MySqlConnection(Myconnection2);
                MySqlCommand Mycommand2 = new MySqlCommand(query, mycon2);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();
                myadapter.SelectCommand = Mycommand2;
                table.Clear();
                myadapter.Fill(table);
                dataGridView_product.DataSource = table; // change here
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void buy_btn_Click(object sender, EventArgs e)
        {
           MessageBox.Show("Order has been placed, please wait for delivery.");
            reciept rec = new reciept();
            rec.Show();

            string date = time.Text;
            string name = "";
            string price = "";
            string seller = "";
            string total = "";
            string username = "";
            string address = "";
            string customer = "";

            // Get the latest logged in username
            string getUsernameQuery = "SELECT Username FROM logged ORDER BY ID DESC LIMIT 1";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(getUsernameQuery, connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                username = reader["Username"].ToString();
            }
            reader.Close();
            connection.Close();

            // Get the address and name of the customer with the matching username
            string getCustomerInfoQuery = "SELECT Address, Name FROM customers WHERE Username = @username";
            command = new MySqlCommand(getCustomerInfoQuery, connection);
            command.Parameters.AddWithValue("@username", username);
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                address = reader["Address"].ToString();
                customer = reader["Name"].ToString();
            }
            reader.Close();
            connection.Close();
            // Get name, price and seller from the bought table
            string getOrderInfoQuery = "SELECT Name, Price, Seller FROM bought";
            command = new MySqlCommand(getOrderInfoQuery, connection);
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                name = reader["Name"].ToString();
                price = reader["Price"].ToString();
                seller = reader["Seller"].ToString();
            }
            reader.Close();
            connection.Close();
            // Get the total from label
            total = total_label.Text;
            // Insert the date, name, price, seller, total, address, and name of the customer into the 'order' table
            string insertQuery = "INSERT INTO `order` (`Date`, `Customer`, `Total`, `Address`) VALUES (@date, @customer, @total, @address)";
            command = new MySqlCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@total", total);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@customer", customer);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                login_form login = new login_form();
                login.Show();
                this.Hide();
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM logged";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM bought";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        class Customer
        {
            public string CustomerName { get; set; }

            public Customer()
            {
                string username = GetLatestUsername();
                if (!string.IsNullOrEmpty(username))
                {
                    GetCustomerName(username);
                }
            }

            private string GetLatestUsername()
            {
                string latestUsername = "";
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string getUsernameQuery = "SELECT Username FROM logged ORDER BY ID DESC LIMIT 1";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand command = new MySqlCommand(getUsernameQuery, connection);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        latestUsername = reader["Username"].ToString();
                    }
                    reader.Close();
                    connection.Close();
                }
                return latestUsername;
            }

            private void GetCustomerName(string username)
            {
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string getCustomerNameQuery = "SELECT Name FROM customers WHERE Username = @username";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand command = new MySqlCommand(getCustomerNameQuery, connection);
                    command.Parameters.AddWithValue("@username", username);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        CustomerName = reader["Name"].ToString();
                    }
                    reader.Close();
                    connection.Close();
                }
            }
        }

        private void Customer_name_Click(object sender, EventArgs e)
        {

        }

        private void label11_MouseHover(object sender, EventArgs e)
        {
            label11.ForeColor = Color.Red;

        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            label11.ForeColor = Color.White;
        }
    }
}
