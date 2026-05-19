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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AddressBook
{
    public partial class Form1 : Form
    {
        int selected = -1;
        string connStr = "Server = localhost;Database = library;Uid = root;Pwd = root";

        private void Clear(){
            textBox1.Clear(); 
            textBox2.Clear(); 
            textBox3.Clear();
            textBox4.Clear();
        }
        
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("이름과 연락처는 무조건 입력해주세요.");
                return;
            }
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
                Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selected == -1)
            {
                MessageBox.Show("수정할 행을 선택하고 수정을 진행해주세요.");
                return;
            }

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("이름과 연락처는 무조건 입력해주세요.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = @"UPDATE contact SET name = @name, phone = @phone, email = @email, address = @address WHERE id= @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@phone", textBox2.Text);
                cmd.Parameters.AddWithValue("@email", textBox3.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                cmd.Parameters.AddWithValue("@id", selected);
                cmd.ExecuteNonQuery();
                MessageBox.Show("정보 수정 완료.");
                LoadData();
                Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (selected == -1)
            {
                MessageBox.Show("삭제할 행을 선택하고 삭제를 진행해주세요.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = @"DELETE FROM contact WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@phone", textBox2.Text);
                cmd.Parameters.AddWithValue("@email", textBox3.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                cmd.Parameters.AddWithValue("@id", selected);
                cmd.ExecuteNonQuery();
                MessageBox.Show("정보 삭제 완료.");
                LoadData();
                Clear();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("불러오기 완료.");
        }

        private void dataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

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

        private void 정보추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnInsert_Click(sender, e);
        }
        private void 정보수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private void 정보삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        }

        private void 불러오기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLoad_Click(sender, e);
        }

        private void 계산기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculator cal = new Calculator();
            cal.ShowDialog(); //모달 창
        }

        private void 숫자맞추기ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FindNumber fn = new FindNumber();
            fn.Show(); //모달리스 창
        }
    }
}
