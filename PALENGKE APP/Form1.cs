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
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PALENGKE_APP
{
    public partial class login_form : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke"; 
        public login_form()
        {

            InitializeComponent();
        }

      
        private void signup_lbl_Click(object sender, EventArgs e)
        {

            Registration_form register = new Registration_form();
            register.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        { 

            string iquery = "SELECT * FROM registered WHERE Username='"+username_tb.Text+"' AND Password='"+password_tb.Text+"' AND Role='"+ combobox_log.Text+"'";
   
           
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(iquery, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
        
               
                    if (myReader.HasRows && combobox_log.Text=="Admin")
                    {
                        while (myReader.Read())
                        {
                            Homepage home = new Homepage();
                            home.Show();
                            this.Hide();
                        }
                    }
                    else if (myReader.HasRows && combobox_log.Text=="Seller")
                    {
                      while (myReader.Read())
                {


                    Seller_form_page sell = new Seller_form_page();
                    sell.Show();
                    this.Hide();
                }
                   

                }
                else if (myReader.HasRows && combobox_log.Text == "Customer")
                    {
                    while (myReader.Read())
                    {
                        main_customer main = new main_customer();
                        main.Show();
                        this.Hide();
                    }
                }
                else
                    {
                        MessageBox.Show("No account found");
                    }
                
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                //Shows Errors
                MessageBox.Show(ex.Message);
            }
            using (MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=palengke"))
            {
                connection.Open();
                using (MySqlCommand insertCommand = new MySqlCommand("INSERT INTO `logged`(`Username`) VALUES (@Username)", connection))
                {
                   
                    insertCommand.Parameters.AddWithValue("@Username", username_tb.Text);
                    insertCommand.ExecuteNonQuery();
                }

            }


        }

        private void login_form_Load(object sender, EventArgs e)
        {
            password_tb.UseSystemPasswordChar = true;
        }

        private void showPassword_cb_CheckedChanged(object sender, EventArgs e)
        {

            if (showPassword_cb.Checked)
            {
                password_tb.UseSystemPasswordChar = false;
            }
            else
            {
                password_tb.UseSystemPasswordChar = true;
            }
        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        Color originalColor;
        private void signup_lbl_MouseHover(object sender, EventArgs e)
        {
            signup_lbl.ForeColor= Color.White;
        }


        private void signup_lbl_MouseLeave(object sender, EventArgs e)
        {
            signup_lbl.ForeColor = Color.Black;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
