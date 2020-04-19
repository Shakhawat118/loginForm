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

namespace loginForm
{
    public partial class Form2 : Form
    {
        string id;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        void Fillcombo()
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cbz\Desktop\sem-7\C#\assignment\loginData.mdf;Integrated Security=True;Connect Timeout=30";
            string sql = string.Format("insert into UserInfo (Id,FirstName,MiddleName,LastName,FatherName,MotherName,PresentAddress) Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", Int32.Parse(id), textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd = new SqlCommand(sql, conn);

            sqlCmd.Connection.Open();

            int rowsAffected = sqlCmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Saved Successfully!!");
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
            sqlCmd.Connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.DataSource = Load_Table();
            comboBox1.DisplayMember = "FirstName";
            comboBox1.ValueMember = "Id";
        }

        public DataTable Load_Table()
        {
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cbz\Desktop\sem-7\C#\assignment\loginData.mdf;Integrated Security=True;Connect Timeout=30";
            string sql = string.Format("select * from UserInfo");
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd = new SqlCommand(sql, conn);
            DataTable dt = new DataTable();
            sqlCmd.Connection.Open();
            dt.Load(sqlCmd.ExecuteReader());
            sqlCmd.Connection.Close();
            return dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
