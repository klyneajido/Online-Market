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
using MySql.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace PALENGKE_APP
{
    public partial class category_form_admin : Form
    {
        public category_form_admin()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataAdapter adapt;
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
        private void add_btn_Click(object sender, EventArgs e)
        {

            string iquery = "INSERT INTO categories(`ID`, `Name` ) VALUES('" + textBox_catID.Text + "', '" + textBox_catName.Text + "');";
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
            MessageBox.Show("Category Added");
            textBox_catID.Text = "";
            textBox_catName.Text = "";
        }

        private void category_form_admin_Load(object sender, EventArgs e)
        {
            try
            {
                string Myconnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string query = "SELECT * FROM categories;";
                MySqlConnection mycon2 = new MySqlConnection(Myconnection2);
                MySqlCommand Mycommand2 = new MySqlCommand(query, mycon2);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();
                myadapter.SelectCommand = Mycommand2;
                DataTable dtable = new DataTable();
                myadapter.Fill(dtable);
                dataGridView_Category.DataSource = dtable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            try
            {

                string Myconnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string query = "UPDATE categories set ID='" + textBox_catID.Text + "', Name='" + textBox_catName.Text + "' WHERE ID='"+textBox_catID.Text+"';";
                MySqlConnection mycon2 = new MySqlConnection(Myconnection2);
                MySqlCommand Mycommand2 = new MySqlCommand(query, mycon2);
                MySqlDataReader myreader2;
                mycon2.Open();
                myreader2 = Mycommand2.ExecuteReader();
                MessageBox.Show("Category updated");
               
                while (myreader2.Read())
                {
                  
                }
                mycon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox_catID.Text = "";
            textBox_catName.Text = "";
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
                    string query = "DELETE FROM categories WHERE ID='" + this.textBox_catID.Text + "';";
                    MySqlConnection mycon2 = new MySqlConnection(Myconnection2);
                    MySqlCommand Mycommand2 = new MySqlCommand(query, mycon2);

                    if (textBox_catID.Text != "")
                    {
                        MySqlDataReader myreader2;
                        mycon2.Open();
                        myreader2 = Mycommand2.ExecuteReader();
                        MessageBox.Show("Category deleted");
                        textBox_catID.Text = "";
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

        private void dashboard_menu_lbl_Click(object sender, EventArgs e)
        {
            Homepage home = new Homepage();
            home.Show();
            this.Hide();
        }

        private void products_menu_lbl_Click(object sender, EventArgs e)
        {
            Product_form_admin product = new Product_form_admin();
            product.Show();
            this.Hide();
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

        private void dashboard_menu_lbl_Click_1(object sender, EventArgs e)
        {
            Homepage home = new Homepage();
            home.Show();
            this.Hide();
        }

        private void products_menu_lbl_Click_1(object sender, EventArgs e)
        {
            Product_form_admin product = new Product_form_admin();
            product.Show();
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

        private void dataGridView_Category_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }
        private void fillcombo()
        {
            try
            {
                string Myconnection3 = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string iquery = "SELECT * FROM categories;";
                MySqlConnection mycon3 = new MySqlConnection(Myconnection3);
                MySqlCommand Mycommand3 = new MySqlCommand(iquery, mycon3);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();
                myadapter.SelectCommand = Mycommand3;
                DataTable dtable = new DataTable();
                myadapter.Fill(dtable);
                dataGridView_Category.DataSource = dtable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            sellers_menu_lbl.ForeColor = Color.Black;
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
