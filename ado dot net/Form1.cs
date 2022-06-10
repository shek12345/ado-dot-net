using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ado_dot_net
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
            string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con = new SqlConnection(strConnection);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {


                string str = "select * from employee where Id=@id";
                cmd = new SqlCommand(str, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));
                cmd.Parameters.AddWithValue("@name", (textBox2.Text));
                cmd.Parameters.AddWithValue("@salary", Convert.ToDouble(txtsalary.Text));
                //open database connection//
                con.Open();
                //fire query select//
                dr = cmd.ExecuteReader();
                if (dr.HasRows) //read the record present or not in dr//
                {
                    if (dr.Read()) //read the data from dr//
                    {
                        textBox2.Text = dr["name"].ToString();
                        txtsalary.Text = dr["salary"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("record is not present");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {


                string str = "insert into employee values(@id,@name,@salary)";
                cmd = new SqlCommand(str, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));
                cmd.Parameters.AddWithValue("@name", (textBox2.Text));
                cmd.Parameters.AddWithValue("@salary", Convert.ToDouble(txtsalary.Text));
                //open database connection//
                con.Open();
                //fire query insert,update,delete//
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record inserted");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {


                string str = "update employee set Name=@name,Salary=@salary where Id=@id";
                cmd = new SqlCommand(str, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));
                cmd.Parameters.AddWithValue("@name", (textBox2.Text));
                cmd.Parameters.AddWithValue("@salary", Convert.ToDouble(txtsalary.Text));
                //open database connection//
                con.Open();
                //fire query insert,update,delete//
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {

                 
                string str = "delete from employee where Id=@id";
                cmd = new SqlCommand(str, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));
               
                //open database connection//
                con.Open();
                //fire query insert,update,delete//
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record removed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                   
            }
        }

        private void btnshoeallemployess_Click(object sender, EventArgs e)
        {
            try
            {


                string str = "select * from employee";
                cmd = new SqlCommand(str, con);
               
                //open database connection//
                con.Open();
                //fire query insert,update,delete//
                dr = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(dr);
                dataGridView1.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();

            }
        }
    }
}
