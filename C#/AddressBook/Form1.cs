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
        int selected = -1;
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = @"INSERT INTO contact(name, phone, email, address) values(@name, @phone, @email, @address)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@phone", textBox2.Text);
                cmd.Parameters.AddWithValue("@email", textBox3.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("정보 추가 완료.");
                LoadData();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = @"UPDATE contact SET (name = @name, phone = @phone, email = @email, address = @address)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@phone", textBox2.Text);
                cmd.Parameters.AddWithValue("@email", textBox3.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("정보 수정 완료.");
                LoadData();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("불러오기 완료.");
        }

        private void dataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                if (!dataView.Rows[e.RowIndex].IsNewRow)
                {
                    DataGridViewRow row = dataView.Rows[e.RowIndex];
                    selected = Convert.ToInt32(row.Cells["id"].Value);
                    textBox1.Text = row.Cells["name"].Value.ToString();
                    textBox2.Text = row.Cells["phone"].Value.ToString();
                    textBox3.Text = row.Cells["email"].Value.ToString();
                    textBox4.Text = row.Cells["address"].Value.ToString();
                }
            }
            
        }
    }
}
