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
using MySql.Data.MySqlClient;

namespace PALENGKE_APP
{
    public partial class Registration_form : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;
        public Registration_form()
        {
           
            InitializeComponent();
        }
    
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
        private void signup_lbl_Click(object sender, EventArgs e)
        {
            
            login_form login = new login_form();
            login.Show();
            this.Hide();
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            if (comboBox_reg.Text=="Seller")
            {
                //SELLER
                
                try
                {
                    // Retrieve the entered username from the text box
                    string username = username_tb.Text;

                    // Connect to the database
                    using (MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=palengke"))
                    {
                        connection.Open();

                        // Check if the entered username already exists in the database
                        using (MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM sellers WHERE Username = @Username", connection))
                        {
                            command.Parameters.AddWithValue("@Username", username);
                            int count = Convert.ToInt32(command.ExecuteScalar());

                            if (count > 0)
                            {
                                // Show an error message
                                MessageBox.Show("The entered username already exists. Please choose a different one.");
                            }
                            else
                            {
                                // Insert the new user into the database
                                using (MySqlCommand insertCommand = new MySqlCommand("INSERT INTO sellers (Type, Address, Username, Name, Phone_number, Age, Password) VALUES (@type, @address, @username, @name, @phone, @age, @password)", connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@type", comboBox_type.Text);
                                    insertCommand.Parameters.AddWithValue("@address", address_tb.Text);
                                    insertCommand.Parameters.AddWithValue("@username", username_tb.Text);
                                    insertCommand.Parameters.AddWithValue("@name", name_tb.Text);
                                    insertCommand.Parameters.AddWithValue("@phone", phone_tb.Text);
                                    insertCommand.Parameters.AddWithValue("@age", age_tb.Text);
                                    insertCommand.Parameters.AddWithValue("@password", password_tb.Text);
                                    insertCommand.ExecuteNonQuery();
                                    MessageBox.Show("Account Successfully Created");

                                    
                                   
                      
                                }
                               
                            }
                        }
                    }

                }
                catch (MySqlException ex)
                {
                    // Handle the exception
                    MessageBox.Show("An error occurred while communicating with the database. " + ex.Message);
                }
            }
            else if (comboBox_reg.Text=="Customer")
            {
                try
                {
                    // Retrieve the entered username from the text box
                    string username = username_tb.Text;

                    // Connect to the database
                    using (MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=palengke"))
                    {
                        connection.Open();

                        // Check if the entered username already exists in the database
                        using (MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM customers WHERE Username = @Username", connection))
                        {
                            command.Parameters.AddWithValue("@Username", username);
                            int count = Convert.ToInt32(command.ExecuteScalar());

                            if (count > 0)
                            {
                                // Show an error message
                                MessageBox.Show("The entered username already exists. Please choose a different one.");
                            }
                            else
                            {
                                // Insert the new user into the database
                                using (MySqlCommand insertCommand = new MySqlCommand("INSERT INTO customers ( Address, Username, Name, Phone_number, Age, Password) VALUES (@address, @username, @name, @phone, @age, @password)", connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@address", address_tb.Text);
                                    insertCommand.Parameters.AddWithValue("@username", username_tb.Text);
                                    insertCommand.Parameters.AddWithValue("@name", name_tb.Text);
                                    insertCommand.Parameters.AddWithValue("@phone", phone_tb.Text);
                                    insertCommand.Parameters.AddWithValue("@age", age_tb.Text);
                                    insertCommand.Parameters.AddWithValue("@password", password_tb.Text);
                                    insertCommand.ExecuteNonQuery();
                                    MessageBox.Show("Account Successfully Created");
                                }
                            }
                        }
                    }

                }
                catch (MySqlException ex)
                {
                    // Handle the exception
                    MessageBox.Show("An error occurred while communicating with the database. " + ex.Message);
                }



            }
           
            //OVERALL
            try
            {
                // Retrieve the entered username from the text box
                string username = username_tb.Text;

                // Connect to the database
                using (MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=palengke"))
                {
                    connection.Open();

                    // Check if the entered username already exists in the database
                    using (MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM registered WHERE Username = @Username", connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            // Show an error message
                            MessageBox.Show("The entered username already exists. Please choose a different one.");
                        }
                        else
                        {
                            // Insert the new user into the database
                            using (MySqlCommand insertCommand = new MySqlCommand("INSERT INTO registered (ID, Address, Role, Username, Name, Phone_number, Age, Password) VALUES (NULL, @address, @role, @username, @name, @phone, @age, @password)", connection))
                            {
                                insertCommand.Parameters.AddWithValue("@address", address_tb.Text);
                                insertCommand.Parameters.AddWithValue("@role", comboBox_reg.Text);
                                insertCommand.Parameters.AddWithValue("@username", username_tb.Text);
                                insertCommand.Parameters.AddWithValue("@name", name_tb.Text);
                                insertCommand.Parameters.AddWithValue("@phone", phone_tb.Text);
                                insertCommand.Parameters.AddWithValue("@age", age_tb.Text);
                                insertCommand.Parameters.AddWithValue("@password", password_tb.Text);
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }

            }
            catch (MySqlException ex)
            {
                // Handle the exception
                MessageBox.Show("An error occurred while communicating with the database. " + ex.Message);
            }

           

        }

        private void comboBox_reg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_reg.SelectedItem.ToString() == "Seller")
            {
                comboBox_type.Visible = true;
                type_lbl.Visible = true;
            }
            else
            {
                comboBox_type.Visible = false;
                type_lbl.Visible = false;
            }
        }

        private void Registration_form_Load(object sender, EventArgs e)
        {
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

        private void signupCheck_lbl_MouseHover(object sender, EventArgs e)
        {
            signupCheck_lbl.ForeColor = Color.White;

        }

        private void signupCheck_lbl_MouseLeave(object sender, EventArgs e)
        {
            signupCheck_lbl.ForeColor = Color.Black;
        }
    }
}
