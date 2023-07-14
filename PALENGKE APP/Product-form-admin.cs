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
using MySqlX.XDevAPI.Common;

namespace PALENGKE_APP
{
    public partial class Product_form_admin : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataAdapter adapt;
        DataTable table = new DataTable();
        DataTable sellerstable = new DataTable();
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
        public Product_form_admin()
        {
            InitializeComponent();
        }

           
        private void dashboard_menu_lbl_Click(object sender, EventArgs e)
        {
            Homepage home = new Homepage();
            home.Show();
            this.Hide();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Delete?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                 try
                            {
                                string Myconnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                                string query = "DELETE FROM products WHERE ID='" + this.textBox_prodID.Text+ "';";
                                MySqlConnection mycon2 = new MySqlConnection(Myconnection2);
                                MySqlCommand Mycommand2 = new MySqlCommand(query,mycon2);

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

        private void update_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string Myconnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string query = "UPDATE products SET ID='" + textBox_prodID.Text + "', Name='" + textBox_prodName.Text + "',Price='" + textBox_prodPrice.Text + "', Quantity='" + textBox_prodQty.Text + "',Category='" + comboBox_prodCat.Text + "',Seller='" + comboBox_prodSeller.Text + "', Seller_username = (SELECT Username FROM sellers WHERE sellers.Name = products.Seller) WHERE ID='" + textBox_prodID.Text + "';";
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
     
        private void Product_form_admin_Load(object sender, EventArgs e)
        {
            
            try
            {
                string Myconnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string query = "SELECT * FROM products;";
                MySqlConnection mycon2 = new MySqlConnection(Myconnection2);
                MySqlCommand Mycommand2 = new MySqlCommand(query, mycon2);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();
                myadapter.SelectCommand = Mycommand2;
                DataTable dtable = new DataTable();
                myadapter.Fill(dtable);
                dataGridView_product.DataSource = dtable;

                MySqlConnection con = new MySqlConnection("datasource= localhost; database=palengke;port=3306; username = root; password="); //open connection
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select Name from categories order by Name ASC", con);
            
                MySqlDataReader reader = cmd.ExecuteReader();
               
                while (reader.Read())
                {
                    string Name = reader.GetString("Name");
                    comboBox_prodCat.Items.Add(Name);
                    comboBox_categories.Items.Add(Name);    
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
                    comboBox_prodSeller.Items.Add(Name);
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

        private void add_btn_Click(object sender, EventArgs e)
        {
            string iquery = "INSERT INTO products(`ID`, `Name`, `Price`, `Quantity`, `Category`, `Seller`, `Seller_username`) SELECT '" + textBox_prodID.Text + "', '" + textBox_prodName.Text + "', '" + textBox_prodPrice.Text + "', '" + textBox_prodQty.Text + "', '" + comboBox_prodCat.Text + "','" + comboBox_prodSeller.Text + "', sellers.Username FROM sellers WHERE sellers.Name = '" + comboBox_prodSeller.Text + "';";
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
            comboBox_prodCat.Text = "";
            textBox_prodQty.Text = "";
            comboBox_prodSeller.Text = "";
        }

        private void category_menu_lbl_Click(object sender, EventArgs e)
        {
            category_form_admin category = new category_form_admin();
            category.Show();
            this.Hide();
        }

        private void customers_menu_lbl_Click(object sender, EventArgs e)
        {
            Customer_form_admin customer = new Customer_form_admin();
            customer.Show();
            this.Hide();
        }

        private void logout_menu_lbl_Click(object sender, EventArgs e)
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

        private void sellers_menu_lbl_Click(object sender, EventArgs e)
        {
            Seller_form_admin sell = new Seller_form_admin();
            sell.Show();
            this.Hide();
        }

        private void comboBox_prodCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected category
            string selectedCategory = comboBox_prodCat.Text;

            // Create a DataView to filter the data based on the selected category
            DataView dv = new DataView(sellerstable);
            dv.RowFilter = "Type='" + selectedCategory + "'";

            // Set the DataSource of the second comboBox to the filtered DataView
            comboBox_prodSeller.DataSource = dv;
            comboBox_prodSeller.ValueMember = "Username";
            comboBox_prodSeller.DisplayMember = "Name";

        }
        


        //FILTERING
        private void comboBox_categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillcombo();
            string selectedCategory = comboBox_categories.Text;

            // Create a DataView to filter the data based on the selected category
            DataView dv = new DataView(table);
            dv.RowFilter = "Category='" + selectedCategory + "'";
            // filter the combo box
            DataView dv2 = new DataView(table);
            dataGridView_product.DataSource = dv;
        }
       
 

        private void dataGridView_product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
            
        }

        private void comboBox_categories_SelectedValueChanged(object sender, EventArgs e)
        {

        

        }


        //FILLS OR RELOAD THE DATA GRID VIEW
        public void fillcombo()
        {
            try
            {
                string Myconnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string query = "SELECT * FROM products;";
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
        //REFRESHES THE FILTER
        private void button4_Click(object sender, EventArgs e)
        {
            fillcombo();
            comboBox_categories.Text = "All";
        }

        private void comboBox_prodSeller_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dashboard_menu_lbl_MouseHover(object sender, EventArgs e)
        {
            dashboard_menu_lbl.ForeColor = Color.Black;

        }

        private void dashboard_menu_lbl_MouseLeave(object sender, EventArgs e)
        {
            dashboard_menu_lbl.ForeColor = Color.White;
        }

        private void products_menu_lbl_MouseHover(object sender, EventArgs e)
        {
            products_menu_lbl.ForeColor = Color.Black;
        }

        private void products_menu_lbl_MouseLeave(object sender, EventArgs e)
        {
            products_menu_lbl.ForeColor = Color.White;
        }

        private void category_menu_lbl_MouseHover(object sender, EventArgs e)
        {
            category_menu_lbl.ForeColor = Color.Black;
        }

        private void category_menu_lbl_MouseLeave(object sender, EventArgs e)
        {
            category_menu_lbl.ForeColor = Color.White;
        }

        private void customers_menu_lbl_MouseHover(object sender, EventArgs e)
        {
            customers_menu_lbl.ForeColor = Color.Black;
        }

        private void customers_menu_lbl_MouseLeave(object sender, EventArgs e)
        {
            customers_menu_lbl.ForeColor = Color.White;
        }

        private void sellers_menu_lbl_MouseHover(object sender, EventArgs e)
        {
            sellers_menu_lbl.ForeColor= Color.Black;
        }

        private void sellers_menu_lbl_MouseLeave(object sender, EventArgs e)
        {
            sellers_menu_lbl.ForeColor = Color.White;
        }

        private void logout_menu_lbl_MouseHover(object sender, EventArgs e)
        {
            logout_menu_lbl.ForeColor = Color.Red;
        }

        private void logout_menu_lbl_MouseLeave(object sender, EventArgs e)
        {
            logout_menu_lbl.ForeColor = Color.White;
        }
    }
}
