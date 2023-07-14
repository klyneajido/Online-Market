using LiveCharts.Wpf;
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

namespace PALENGKE_APP
{
    public partial class Seller_form_admin : Form
    {
        public Seller_form_admin()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=palengke");
        MySqlCommand command;
        MySqlDataAdapter adapt;
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
        private void add_btn_Click(object sender, EventArgs e)
        {
            string iquery = "INSERT INTO registered(`ID`,`Address`,`Role`,`Username`, `Name`, `Phone_number`, `Age`, `Password`) VALUES (NULL,'" + textBox_sellAddress.Text + "','Seller','" + textBox_sellUser.Text + "', '" + textBox_sellName.Text + "', '" + textBox_sellPhone.Text + "', '" + textBox_sellAge.Text + "', '" + textBox_sellPassword.Text + "')";
            string iquery2 = "INSERT INTO sellers(`Type`,`Address`,`Username`, `Name`, `Phone_number`, `Age`, `Password`) VALUES ('" + comboBox_type.Text + "','" + textBox_sellAddress.Text + "','" + textBox_sellUser.Text + "', '" + textBox_sellName.Text + "', '" + textBox_sellPhone.Text + "', '" + textBox_sellAge.Text + "', '" + textBox_sellPassword.Text + "')";
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
            category_form_admin cat = new category_form_admin();
            cat.Show();
            this.Hide();
        }

        private void customers_menu_lbl_Click(object sender, EventArgs e)
        {
            Customer_form_admin cust = new Customer_form_admin();
            cust.Show();
            this.Hide();
        }


        private void Seller_form_admin_Load(object sender, EventArgs e)
        {
            try
            {
                string Myconnection3 = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string iquery = "SELECT * FROM sellers;";
                MySqlConnection mycon3 = new MySqlConnection(Myconnection3);
                MySqlCommand Mycommand3 = new MySqlCommand(iquery, mycon3);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();
                myadapter.SelectCommand = Mycommand3;
                DataTable dtable = new DataTable();
                myadapter.Fill(dtable);
                dataGridView_Sellers.DataSource = dtable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=palengke;port=3306; username = root; password="); //open connection
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select Name from categories order by Name ASC", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string Name = reader.GetString("Name");
                    comboBox_type.Items.Add(Name);

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

        private void update_btn_Click(object sender, EventArgs e)
        {

            string iquery = "UPDATE registered set Address='" + textBox_sellAddress.Text + "', Name='" + textBox_sellName.Text + "',Username='" + textBox_sellUser.Text + "', Phone_number='" + textBox_sellPhone.Text + "', Age='" + textBox_sellAge.Text + "',Password='" + textBox_sellPassword.Text + "' WHERE Username='" + textBox_sellUser.Text + "'  ;";

            string iquery2 = "UPDATE sellers set Type='" + comboBox_type.Text + "', Address='" + textBox_sellAddress.Text + "', Name='" + textBox_sellName.Text + "',Username='" + textBox_sellUser.Text + "', Phone_number='" + textBox_sellPhone.Text + "', Age='" + textBox_sellAge.Text + "',Password='" + textBox_sellPassword.Text + "' WHERE Username='" + textBox_sellUser.Text + "'  ;";
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
        //DELETE BUTTON
        private void delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Delete?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
             string iquery = "DELETE FROM registered WHERE Username='" + this.textBox_sellUser.Text + "';";

            string iquery2 = "DELETE FROM sellers WHERE Username='" + this.textBox_sellUser.Text + "';";
            try
            {
                connection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(iquery, connection);
                commandDatabase.ExecuteNonQuery();
                MySqlCommand commandDatabase2 = new MySqlCommand(iquery2, connection);
                commandDatabase2.ExecuteNonQuery();
                MessageBox.Show("Data Successfully Deleted ");
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

        private void fillcombo()
        {
            try
            {
                string Myconnection3 = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string iquery = "SELECT * FROM sellers;";
                MySqlConnection mycon3 = new MySqlConnection(Myconnection3);
                MySqlCommand Mycommand3 = new MySqlCommand(iquery, mycon3);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();
                myadapter.SelectCommand = Mycommand3;
                DataTable dtable = new DataTable();
                myadapter.Fill(dtable);
                dataGridView_Sellers.DataSource = dtable;
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
            customers_menu_lbl.ForeColor= Color.Black;
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
