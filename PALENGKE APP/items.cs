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
    public partial class items : UserControl
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=palengke";
        public items()
        {
            InitializeComponent();
        }

        private void items_Load(object sender, EventArgs e)
        {
        
        }

       
    }
}
