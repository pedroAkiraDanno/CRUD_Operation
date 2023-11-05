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

            // Centraliza o formulário na tela
            this.StartPosition = FormStartPosition.CenterScreen;
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

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            string status = "";
            if (radioButton1.Checked == true)
            {
                status = radioButton1.Text;
            }
            else
            {
                status = (radioButton2.Text);
            }


            SqlCommand com = new SqlCommand("exec dbo.SP_Product_Update '" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + status + "','" + DateTime.Parse(dateTimePicker1.Text) + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sucessfuly Update");
            LoadAllRecords();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            
            if (MessageBox.Show("Are you confirm to delete?", "Delete",MessageBoxButtons.YesNo ) == DialogResult.Yes) 
            {

                con.Open();
                SqlCommand com = new SqlCommand("exec dbo.SP_Product_Delete '" + int.Parse(textBox1.Text) + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Sucessfuly Deleted");
                LoadAllRecords();


            }






        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlCommand com = new SqlCommand("exec dbo.SP_Product_Search '"+int.Parse(textBox1.Text)+"' ", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadAllRecords();

        }
    }
}
