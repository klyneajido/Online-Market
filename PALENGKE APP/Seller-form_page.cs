using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using LiveCharts.Wpf;
using LiveCharts;
using System.Net;

namespace PALENGKE_APP
{
    public partial class Seller_form_page : Form
    {


        public Seller_form_page()
        {
            InitializeComponent();

        }
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;
        public string username;
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
        private void Seller_form_page_Load(object sender, EventArgs e)
        {
            Seller currentSeller = new Seller();
            Seller_name.Text = currentSeller.SellerName;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Use the SUM function in a SQL query to get the total of all items in the "items" table
                string query = "SELECT COUNT(*) FROM products WHERE Seller_username=(SELECT Username FROM logged ORDER BY ID DESC LIMIT 1)";
                MySqlCommand command = new MySqlCommand(query, connection);

                // Execute the query and store the result in a variable
                object result = command.ExecuteScalar();

                // If the query returns a non-null result, update the label with the total
                if (result != DBNull.Value)
                {
                    int total = Convert.ToInt32(result);
                    product_total.Text = total.ToString();
                }
                connection.Close();
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Use the SUM function in a SQL query to get the total of all items in the "items" table
                string query = "SELECT COUNT(*) FROM customers";
                MySqlCommand command = new MySqlCommand(query, connection);

                // Execute the query and store the result in a variable
                object result = command.ExecuteScalar();

                // If the query returns a non-null result, update the label with the total
                if (result != DBNull.Value)
                {
                    int total = Convert.ToInt32(result);
                    customer_total.Text = total.ToString();
                }
                connection.Close();
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                int[] rowCount = new int[2];
                string[] tableNames = { "products", "customers" };

                for (int i = 0; i < tableNames.Length; i++)
                {
                    // Use the COUNT function in a SQL query to get the number of rows in the table
                    string query = $"SELECT COUNT(*) FROM {tableNames[i]}";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        rowCount[i] = Convert.ToInt32(result);
                    }
                }
                cartesianChart1.Series = new SeriesCollection
    {
       new ColumnSeries
    {
        Title = "Rows Count",
        Values = new ChartValues<double> { rowCount[0], rowCount[1]},
        PointGeometry = DefaultGeometries.Circle,
    }

    };
                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Tables",
                    Labels = tableNames
                });
                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Rows Count",
                });
                connection.Close();
            }
        }
        private void products_menu_label_Click(object sender, EventArgs e)
        {
            Products_form_seller prodSell = new Products_form_seller();
            prodSell.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                login_form logout = new login_form();
                logout.Show();
                this.Hide();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("DELETE FROM logged", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }

        }
        class Seller
        {
            public string SellerName { get; set; }

            public Seller()
            {
                string username = GetLatestUsername();
                if (!string.IsNullOrEmpty(username))
                {
                    GetSellerName(username);
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

            private void GetSellerName(string username)
            {
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string getCustomerNameQuery = "SELECT Name FROM sellers WHERE Username = @username";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand command = new MySqlCommand(getCustomerNameQuery, connection);
                    command.Parameters.AddWithValue("@username", username);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        SellerName = reader["Name"].ToString();
                    }
                    reader.Close();
                    connection.Close();
                }
            }
        }

        private void label14_MouseHover(object sender, EventArgs e)
        {
            label14.ForeColor = Color.Black;
        }

        private void label14_MouseLeave(object sender, EventArgs e)
        {
            label14.ForeColor = Color.White;
        }

        private void products_menu_label_MouseHover(object sender, EventArgs e)
        {
            products_menu_label.ForeColor = Color.Black;
        }

        private void products_menu_label_MouseLeave(object sender, EventArgs e)
        {
            products_menu_label.ForeColor = Color.White;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}

