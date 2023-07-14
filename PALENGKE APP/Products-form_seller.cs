using MySql.Data.MySqlClient;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PALENGKE_APP
{
    public partial class Products_form_seller : Form
    {
       
        public string username;

        public Products_form_seller()
        {
            InitializeComponent();
          
        }

       

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataAdapter adapt;
        DataTable table = new DataTable();
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
       
        private void add_btn_Click(object sender, EventArgs e)
        {
            string iquery = "INSERT INTO products(`ID`, `Name`, `Price`, `Quantity`, `Category`, `Seller`, `Seller_username`) VALUES('" + textBox_prodID.Text + "', '" + textBox_prodName.Text + "', '" + textBox_prodPrice.Text + "', '" + textBox_prodQty.Text + "',(SELECT Type From sellers WHERE Username=(SELECT Username FROM logged LIMIT 1)),(SELECT Name FROM sellers WHERE Username=(SELECT Username FROM logged LIMIT 1)), (SELECT Username FROM logged LIMIT 1));";
           
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(iquery, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                databaseConnection.Close();

            }
            catch (Exception ex)
            {
                //Shows Errors
                MessageBox.Show(ex.Message);
            }
            fillcombo();
            MessageBox.Show("Product Added");
            textBox_prodName.Text = "";
            textBox_prodID.Text = "";
            textBox_prodPrice.Text = "";
            textBox_prodQty.Text = "";
        }

        private void update_btn_Click(object sender, EventArgs e)
        {

         

            try
            {
                string Myconnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string query = "UPDATE products set ID='" + textBox_prodID.Text + "', Name='" + textBox_prodName.Text + "',Price='" + textBox_prodPrice.Text + "', Quantity='" + textBox_prodQty.Text + "', Category=(SELECT Type From sellers WHERE Username = (SELECT Username FROM logged LIMIT 1)), Seller= (SELECT Name FROM sellers WHERE Username = (SELECT Username FROM logged LIMIT 1)), Seller_username=(SELECT Username FROM logged LIMIT 1) WHERE ID='" + textBox_prodID.Text + "';";
                MySqlConnection mycon2 = new MySqlConnection(Myconnection2);
                MySqlCommand Mycommand2 = new MySqlCommand(query, mycon2);
                MySqlDataReader myreader2;
                mycon2.Open();
                myreader2 = Mycommand2.ExecuteReader();
                MessageBox.Show("Product updated");
                textBox_prodID.Text = "";
                while (myreader2.Read())
                {

                }
                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            fillcombo();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Delete?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
              try
                        {
                            string Myconnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                            string query = "DELETE FROM products WHERE ID='" + this.textBox_prodID.Text + "';";
                            MySqlConnection mycon2 = new MySqlConnection(Myconnection2);
                            MySqlCommand Mycommand2 = new MySqlCommand(query, mycon2);

                            if (textBox_prodID.Text != "")
                            {
                                MySqlDataReader myreader2;
                                mycon2.Open();
                                myreader2 = Mycommand2.ExecuteReader();
                                MessageBox.Show("Data deleted");
                                textBox_prodID.Text = "";
                                while (myreader2.Read())
                                {

                                }
                                mycon2.Close();
                            }
                            else
                            {
                                MessageBox.Show("YOU DELETED NOTHING");
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        fillcombo();
            }
          
        }

        private void Products_form_seller_Load(object sender, EventArgs e)
        {
            Seller currentSeller = new Seller();
            Seller_name.Text = currentSeller.SellerName;
            fillcombo();
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

        public void fillcombo()

        {
            try
            {
                string connectionString = "server=127.0.0.1;database=palengke;user id=root;password=;";
              
                string query = "SELECT ID, Name, Price, Quantity FROM products WHERE Seller_username = (SELECT Username FROM logged ORDER BY ID DESC LIMIT 1);";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable data = new DataTable();
                            adapter.Fill(data);
                            dataGridView_product.DataSource = data;
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void label14_Click(object sender, EventArgs e)
        {
            Seller_form_page sell = new Seller_form_page();
            sell.Show();
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

