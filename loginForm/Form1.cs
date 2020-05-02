using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace loginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cbz\Desktop\sem-7\C#\assignment\loginData.mdf;Integrated Security=True;Connect Timeout=30";
            string sql = string.Format("select * from LoginTable where Email='{0}' and Password ='{1}'",txtEmail.Text,txtPassword.Text);
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd = new SqlCommand(sql, conn);
            DataTable dt = new DataTable();
            sqlCmd.Connection.Open();
            dt.Load(sqlCmd.ExecuteReader());
            if(dt.Rows.Count>0)
            {
                MessageBox.Show("login Success");
                MessageBox.Show(dt.Rows[0][0].ToString());
                Form2 customerDetail = new Form2(dt.Rows[0][0].ToString());
                customerDetail.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("UnAuthorized User!!");
            }
            sqlCmd.Connection.Close();
        }

        
    }
}
