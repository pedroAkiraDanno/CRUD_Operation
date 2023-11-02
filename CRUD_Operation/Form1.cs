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




namespace CRUD_Operation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection("Data Source=NB-00760\\SQL2022;Initial Catalog=CRUD_SP_DB;Integrated Security=True");




        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            string status = "";
            if(radioButton1.Checked== true)
            {
                status = radioButton1.Text;
            }else  {
                status = (radioButton2.Text);
            }


            SqlCommand com = new SqlCommand("exec dbo.SP_Product_Insert '" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + status + "','" + DateTime.Parse(dateTimePicker1.Text) + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sucessfuly Saved");
            LoadAllRecords();

        }




        void LoadAllRecords()
        {
            SqlCommand com = new SqlCommand("exec dbo.SP_Product_View", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }







    }
}
