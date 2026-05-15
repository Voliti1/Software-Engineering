using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AddressBook
{
    public partial class Form1 : Form
    {
        string connStr = "Server = localhost;Database = library;Uid = root;Pwd = root";
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM contact";
                MySqlDataAdapter result = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                result.Fill(dt);
                dataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataView.DataSource = dt;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
