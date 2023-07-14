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
    public partial class reciept : Form
    {
        public reciept()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataAdapter adapt;

        DataTable table = new DataTable();
        DataTable sellerstable = new DataTable();
        DataTable bought = new DataTable();
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reciept_Load(object sender, EventArgs e)
        {
           date.Text = DateTime.Now.ToString();
           fillcombo();
        }

        public void fillcombo()
        {
            try
            {
                string Myconnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
                string query = "SELECT Name, Price, Seller FROM bought ORDER BY Seller ASC;";
                MySqlConnection mycon2 = new MySqlConnection(Myconnection2);
                MySqlCommand Mycommand2 = new MySqlCommand(query, mycon2);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();
                myadapter.SelectCommand = Mycommand2;
                table.Clear();
                myadapter.Fill(table);
                dataGridView_bought.DataSource = table; // change here
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
                    total.Text = totalPrice.ToString();
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

    }
}
