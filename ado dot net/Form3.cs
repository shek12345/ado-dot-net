using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;



namespace ado_dot_net
{
    public partial class Form3 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder scb;
           
        public Form3()
        {
            InitializeComponent();
            string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con = new SqlConnection(strConnection);
        }
        private DataSet GetcourseData()
        {
            da = new SqlDataAdapter("select * from course", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            scb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds,"course");
            return ds;
        }
        

        private void btnsave_Click(object sender, EventArgs e)
        { 
           try
            {
                ds = GetcourseData();
                DataRow row = ds.Tables["course"].NewRow();
                row["id"] = txtid.Text;
                row["Name"] = txtcoursename.Text;
                row["fees"] = txtcoursefees.Text;
                ds.Tables["course"].Rows.Add(row);
                int result = da.Update(ds.Tables["course"]);
                if(result==1)
                {
                    MessageBox.Show("data inserted");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex. Message);
            }
        

        

        }

        private void Form3_Load(object sender, EventArgs e)

        
        
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            try
            {
                ds = GetcourseData();
                DataRow row = ds.Tables["course"].Rows.Find(txtid.Text);
                if (row != null)
                {
                    row["Name"] = txtcoursename.Text;
                    row["fees"] = txtcoursefees.Text;
                    int result = da.Update(ds.Tables["course"]);



                    if (result == 1)
                    {
                        MessageBox.Show("data updated");
                    }


                    else
                    {
                        MessageBox.Show("id does not exixts to update");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetcourseData();
                DataRow row = ds.Tables["course"].Rows.Find(txtid.Text);
                if (row != null)
                {
                    row.Delete();
                    int result = da.Update(ds.Tables["course"]);



                    if (result == 1)
                    {
                        MessageBox.Show("data updated");
                    }


                    else
                    {
                        MessageBox.Show("id does not exixts to update");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetcourseData();
                DataRow row = ds.Tables["course"].Rows.Find(txtid.Text);
                if (row != null)
                {
                    txtcoursename.Text = row["name"].ToString();
                    txtcoursefees.Text = row["fees"].ToString();

                }
                else
                {
                    MessageBox.Show("record does not exixt");

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }






        }

        private void btnshowallcourse_Click(object sender, EventArgs e)
        {
            ds = GetcourseData();
            dataGridView1.DataSource = ds.Tables["course"];
        }
    }
}
