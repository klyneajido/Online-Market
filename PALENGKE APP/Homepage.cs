using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using LiveCharts;
using LiveCharts.Wpf;

namespace PALENGKE_APP
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
        private void products_menu_lbl_Click(object sender, EventArgs e)
        {
           
        }

        private void products_menu_label_Click(object sender, EventArgs e)
        {
            Product_form_admin product = new Product_form_admin();
            product.Show();
            this.Hide();

        }

        private void category_menu_label_Click(object sender, EventArgs e)
        {
            category_form_admin category = new category_form_admin();
            category.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Customer_form_admin customer = new Customer_form_admin();
            customer.Show();    
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            login_form logout = new login_form();
            logout.Show();
            this.Hide();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Use the SUM function in a SQL query to get the total of all items in the "items" table
                string query = "SELECT COUNT(*) FROM products";
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
                string query = "SELECT COUNT(*) FROM categories";
                MySqlCommand command = new MySqlCommand(query, connection);

                // Execute the query and store the result in a variable
                object result = command.ExecuteScalar();

                // If the query returns a non-null result, update the label with the total
                if (result != DBNull.Value)
                {
                    int total = Convert.ToInt32(result);
                    category_total.Text = total.ToString();
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

                // Use the SUM function in a SQL query to get the total of all items in the "items" table
                string query = "SELECT COUNT(*) FROM sellers";
                MySqlCommand command = new MySqlCommand(query, connection);

                // Execute the query and store the result in a variable
                object result = command.ExecuteScalar();

                // If the query returns a non-null result, update the label with the total
                if (result != DBNull.Value)
                {
                    int total = Convert.ToInt32(result);
                    seller_total.Text = total.ToString();
                }
                connection.Close();
            }

            //CARTESIAN CHART
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                int[] rowCount = new int[4];
                string[] tableNames = { "products", "categories", "customers", "sellers" };

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
        Values = new ChartValues<double> { rowCount[0], rowCount[1], rowCount[2], rowCount[3] },
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

        private void label13_Click(object sender, EventArgs e)
        {
            Seller_form_admin sell = new Seller_form_admin();
            sell.Show();
            this.Hide();
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

        private void category_menu_label_MouseHover(object sender, EventArgs e)
        {
            category_menu_label.ForeColor= Color.Black;
        }

        private void category_menu_label_MouseLeave(object sender, EventArgs e)
        {
            category_menu_label.ForeColor=Color.White;
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            label10.ForeColor= Color.Black;
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            label10.ForeColor= Color.White;
        }

        private void label13_MouseHover(object sender, EventArgs e)
        {
            label13.ForeColor= Color.Black;
        }

        private void label13_MouseLeave(object sender, EventArgs e)
        {
            label13.ForeColor= Color.White;
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
