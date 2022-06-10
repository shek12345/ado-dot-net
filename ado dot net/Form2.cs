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
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Form2()
        {
            InitializeComponent();
            string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con = new SqlConnection(strConnection);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "insert into course values(@id,@name,@fees)";
                cmd = new SqlCommand(str,con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));
                cmd.Parameters.AddWithValue("@name", (txtcoursename.Text));
                cmd.Parameters.AddWithValue("@fees", Convert.ToInt32(txtcoursefees.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if(result==1)
                {
                    MessageBox.Show("Record Is Inserted");
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

        private void btnupdate_Click(object sender, EventArgs e)
        {

            try
            {


                string str = "update course set Name=@name,Fees=@fees where Id=@id";
                cmd = new SqlCommand(str, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));
                cmd.Parameters.AddWithValue("@name", (txtcoursename.Text));
                cmd.Parameters.AddWithValue("@fees", Convert.ToInt32(txtcoursefees.Text));
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

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {

            

            string str = "select * from course where Id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));
           
            //open database connection//
            con.Open();
            //fire query select//
            dr = cmd.ExecuteReader();
            if (dr.HasRows) //read the record present or not in dr//
            {
                if (dr.Read()) //read the data from dr//
                {
                    txtcoursename.Text = dr["name"].ToString();
                    txtcoursefees.Text = dr["fees"].ToString();
                }
            }
            else
            {
                MessageBox.Show("record is not present");
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {


                string str = "delete from course where Id=@id";
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

        private void btnshowallcourse_Click(object sender, EventArgs e)
        {
            try
            {


                string str = "select * from course";
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

