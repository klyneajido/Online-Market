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
    public partial class Customer_form_admin : Form
    {
        public Customer_form_admin()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=palengke");
        MySqlCommand command;
        MySqlDataAdapter adapt;
        DataTable table = new DataTable();
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";

       
      

        private void Customer_form_page_Load(object sender, EventArgs e)
        {
            fillcombo();


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

       

      

        private void logout_menu_lbl_Click(object sender, EventArgs e)
        {
            login_form logout = new login_form();
            logout.Show();
            this.Hide();
        }

        private void fillcombo()
        {
            try
            {
                string Myconnection3 = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string iquery = "SELECT * FROM customers;";
                MySqlConnection mycon3 = new MySqlConnection(Myconnection3);
                MySqlCommand Mycommand3 = new MySqlCommand(iquery, mycon3);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();
                myadapter.SelectCommand = Mycommand3;
                DataTable dtable = new DataTable();
                myadapter.Fill(dtable);
                dataGridView_customer.DataSource = dtable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            string iquery = "INSERT INTO registered(`ID`,`Address`,`Role`,`Username`, `Name`, `Phone_number`, `Age`, `Password`) VALUES (NULL,'" + textBox_custAddress.Text + "','Seller','" + textBox_custUser.Text + "', '" + textBox_custName.Text + "', '" + textBox_custPhone.Text + "', '" + textBox_custAge.Text + "', '" + textBox_custPassword.Text + "')";
            string iquery2 = "INSERT INTO customers(`Address`,`Username`, `Name`, `Phone_number`, `Age`, `Password`) VALUES ('" + textBox_custAddress.Text + "','" + textBox_custUser.Text + "', '" + textBox_custName.Text + "', '" + textBox_custPhone.Text + "', '" + textBox_custAge.Text + "', '" + textBox_custPassword.Text + "')";
            try
            {
                connection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(iquery, connection);
                commandDatabase.ExecuteNonQuery();
                MySqlCommand commandDatabase2 = new MySqlCommand(iquery2, connection);
                commandDatabase2.ExecuteNonQuery();
                MessageBox.Show("Data Successfully Inserted to registered and sellers table");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            fillcombo();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Delete?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                 string iquery = "DELETE FROM registered WHERE Username='" + this.textBox_custUser.Text + "';";

                            string iquery2 = "DELETE FROM customers WHERE Username='" + this.textBox_custUser.Text + "';";
                            try
                            {
                                connection.Open();
                                MySqlCommand commandDatabase = new MySqlCommand(iquery, connection);
                                commandDatabase.ExecuteNonQuery();
                                MySqlCommand commandDatabase2 = new MySqlCommand(iquery2, connection);
                                commandDatabase2.ExecuteNonQuery();
                                MessageBox.Show("Data Successfully Deleted");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                connection.Close();
                            }
                            fillcombo();
            }
        
       
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            string iquery = "UPDATE registered set Address='" + textBox_custAddress.Text + "', Name='" + textBox_custName.Text + "',Username='" + textBox_custUser.Text + "', Phone_number='" + textBox_custPhone.Text + "', Age='" + textBox_custAge.Text + "',Password='" + textBox_custPassword.Text + "' WHERE Username='" + textBox_custUser.Text + "'  ;";
            string iquery2 = "UPDATE customers set  Address='" + textBox_custAddress.Text + "', Name='" + textBox_custName.Text + "',Username='" + textBox_custUser.Text + "', Phone_number='" + textBox_custPhone.Text + "', Age='" + textBox_custAge.Text + "',Password='" + textBox_custPassword.Text + "' WHERE Username='" + textBox_custUser.Text + "'  ;";
            try
            {
                connection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(iquery, connection);
                commandDatabase.ExecuteNonQuery();
                MySqlCommand commandDatabase2 = new MySqlCommand(iquery2, connection);
                commandDatabase2.ExecuteNonQuery();
                MessageBox.Show("Data Successfully UPDATED ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            fillcombo();

        }

        private void logout_menu_lbl_Click_1(object sender, EventArgs e)
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

        private void dashboard_menu_lbl_Click_1(object sender, EventArgs e)
        {
            Homepage home = new Homepage();
            home.Show();
            this.Hide();
        }

        private void products_menu_lbl_Click_1(object sender, EventArgs e)
        {
            Product_form_admin prod = new Product_form_admin();
            prod.Show();
            this.Hide();
        }

        private void category_menu_lbl_Click(object sender, EventArgs e)
        {
            category_form_admin cat = new category_form_admin();
            cat.Show();
            this.Hide();
        }

        private void sellers_menu_lbl_Click(object sender, EventArgs e)
        {
            Seller_form_admin sell = new Seller_form_admin();
            sell.Show();
            this.Hide();
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
            category_menu_lbl.ForeColor= Color.Black;
        }

        private void category_menu_lbl_MouseLeave(object sender, EventArgs e)
        {
            category_menu_lbl.ForeColor =  Color.White;
        }

        private void customers_menu_lbl_MouseHover(object sender, EventArgs e)
        {
            customers_menu_lbl.ForeColor = Color.Black;
        }

        private void customers_menu_lbl_MouseLeave(object sender, EventArgs e)
        {
            customers_menu_lbl.ForeColor=Color.White;
        }

        private void sellers_menu_lbl_MouseHover(object sender, EventArgs e)
        {
            sellers_menu_lbl.ForeColor=Color.Black;
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
